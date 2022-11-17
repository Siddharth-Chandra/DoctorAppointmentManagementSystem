using DoctorAppointmentMgntSystem.Data;
using DoctorAppointmentMgntSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoctorAppointmentMgntSystem.Views
{
    public class PatientController : Controller
    {
        private readonly ILogger<PatientController> _logger;
        private readonly IDoctorDataRepository _doctorDataRepository;
        private readonly IPatientsDataRepository _patientsDataRepository;

        public PatientController(ILogger<PatientController> logger, IDoctorDataRepository doctorDataRepository,IPatientsDataRepository patientsDataRepository)
        {
            _logger = logger;
            _doctorDataRepository = doctorDataRepository;
            _patientsDataRepository = patientsDataRepository;
        }
       
        public IActionResult Create()
        {
            PatientsData patients = new PatientsData()
            {
                DoctorsData= new DoctorsData
                {
                    DoctorsList= new SelectList(_doctorDataRepository.GetDoctorsDatas(), "DoctorName", "DoctorName")
                }
            };
          
            return View(patients);
        }

        [HttpPost]
        public IActionResult Create(PatientsData patientsData)
        {
            PatientsData patients = new PatientsData()
            {
                DoctorsData = new DoctorsData
                {
                    DoctorsList = new SelectList(_doctorDataRepository.GetDoctorsDatas(), "DoctorName", "DoctorName")
                }
            };

            if (ModelState.IsValid)
            
            {

                var dbData = _patientsDataRepository.GetPatientsAppointmentData();

                if (patientsData.AppointmentDate < DateTime.Now)
                {
                    ViewBag.Message = "Old date is not allowed";
                }
                else if (patientsData.AppointmentDate.Date.DayOfWeek == DayOfWeek.Saturday || patientsData.AppointmentDate.Date.DayOfWeek == DayOfWeek.Sunday)
                {
                    ViewBag.Message = "Cant schedule on weekends";
                }
                else if(patientsData.AppointmentDate.Hour>=9 && /*(patientsData.AppointmentDate.Hour == 18 && patientsData.AppointmentDate.Minute==00)&&*/ patientsData.AppointmentDate.Hour<=18)
                {
                    bool appointmentExist = false;
                    if (dbData.Count()==0)
                    {
                        ViewBag.Message = $"Appointment scheduled";
                        _patientsDataRepository.InsertPatientDetails(patientsData);
                    }

                    foreach(var item in dbData)
                    {
                        
                        if(item.DoctorName==patientsData.DoctorsData.DoctorName &&item.AppointmentDate.Date.ToShortDateString()==patientsData.AppointmentDate.Date.ToShortDateString())
                        {
                            appointmentExist = true;
                            ViewBag.Message = $"There is already an appointment for Dr.{item.DoctorName} today";
                        }
                      
                    }
                    if(!appointmentExist)
                    {
                        ViewBag.Message = $"Appointment scheduled";
                        _patientsDataRepository.InsertPatientDetails(patientsData);
                    }
                }
                else
                {
                    //Save to DB
                    ViewBag.Message = $"Appointment scheduled";
                    _patientsDataRepository.InsertPatientDetails(patientsData);
                  
                }
           
               
            }
            
            return View(patients);
        }
    }
}
