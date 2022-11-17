using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DoctorAppointmentMgntSystem.Models
{
    public class PatientsData
    {
        [Key]
        
        public int Id { get; set; }

        [Required(ErrorMessage = "Please provide name")]
        [Display(Name ="Name")]
        public string PatientName { get; set; }

        [Required(ErrorMessage = "Please provide email")]
        [Display(Name = "Email")]
        public string PatientEmail { get; set; }

        [Required]
        [Display(Name = "Appointment Date")]
        public DateTime AppointmentDate { get; set; }

        [Required]
        [Display(Name = "Doctor Name")]
        public DoctorsData DoctorsData { get; set; }

        [Required]
        public string Message { get; set; }
    }

    public class PatientsDetails
    {
        [Key]

        public int Id { get; set; }

        [Required(ErrorMessage = "Please provide name")]
        [Display(Name = "Name")]
        public string PatientName { get; set; }

        [Required(ErrorMessage = "Please provide email")]
        [Display(Name = "Email")]
        public string PatientEmail { get; set; }

        [Required]
        [Display(Name = "Appointment Date")]
        public DateTime AppointmentDate { get; set; }

        [Required]
        [Display(Name = "Doctor Name")]
        public string DoctorName { get; set; }

        [Required]
        public string Message { get; set; }
    }
}
