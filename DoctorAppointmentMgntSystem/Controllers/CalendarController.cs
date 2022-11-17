using DoctorAppointmentMgntSystem.Data;
using DoctorAppointmentMgntSystem.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoctorAppointmentMgntSystem.Controllers
{
    public class CalendarController : Controller
    {
        private readonly IPatientsDataRepository _patientsRepository;

        public CalendarController(IPatientsDataRepository patientsDataRepository)
        {
            _patientsRepository = patientsDataRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Calendar()
        {
            var appointments = _patientsRepository.GetPatientsAppointmentData();
            List<Appointment> appointmentsData = new List<Appointment>();
            foreach (var item in appointments)
            {

                var data = new Appointment
                {
                    Id = item.Id,
                    Title = item.PatientName,
                    StartDate = item.AppointmentDate.ToString("yyyy-MM-dd")
                };

                appointmentsData.Add(data);
            
             }


            ViewData["appointments"] = appointmentsData.ToArray();


   

            return View();
        }


    }
}
