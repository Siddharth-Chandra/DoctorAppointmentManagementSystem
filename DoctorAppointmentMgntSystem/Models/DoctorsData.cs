using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DoctorAppointmentMgntSystem.Models
{
    public class DoctorsData
    {
        public int Id { get; set; }
        public string DoctorName { get; set; }

        [NotMapped]
        public SelectList DoctorsList { get; set; }
    }
}
