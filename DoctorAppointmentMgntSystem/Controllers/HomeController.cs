using DoctorAppointmentMgntSystem.Data;
using DoctorAppointmentMgntSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace DoctorAppointmentMgntSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IDoctorDataRepository _doctorDataRepository;

        public HomeController(ILogger<HomeController> logger,IDoctorDataRepository doctorDataRepository)
        {
            _logger = logger;
            _doctorDataRepository = doctorDataRepository;
        }

        public IActionResult Index()
        {
           
            DoctorsData doctorsData = new DoctorsData();
            doctorsData.DoctorsList = new SelectList(_doctorDataRepository.GetDoctorsDatas(),"Id","DoctorName");
            return View(doctorsData);
        }


        //[HttpPost]
        //public IActionResult Index(PatientsData patientsData)
        //{
        //    if(ModelState.IsValid)
        //    {

        //    }
         
        //    return View(patientsData);
        //}

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
