using Dapper;
using DoctorAppointmentMgntSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace DoctorAppointmentMgntSystem.Data
{

    public interface IPatientsDataRepository
    {
        void InsertPatientDetails(PatientsData patientsData);

        IEnumerable<PatientsDetails> GetPatientsAppointmentData();
    }
    public class PatientsDataRepository : IPatientsDataRepository
    {
        private readonly AppDBContext _appDBContext;
        private readonly string _connectionString;
        public PatientsDataRepository(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
            _connectionString = _appDBContext._connectionString;
        }

        public IEnumerable<PatientsDetails> GetPatientsAppointmentData()
        {
            string query = "Select * from PatientsData";
            SqlConnection con = new SqlConnection(_connectionString);
            //var result = con.Query<DoctorsData>("sp_GetDoctorNames", commandType: System.Data.CommandType.StoredProcedure);
            var result = con.Query<PatientsDetails>(query);
            return result;
        }

        public void InsertPatientDetails(PatientsData patientsData)
        {
            using (SqlConnection db = new SqlConnection(_connectionString))
            {
                string insertQuery = @"INSERT INTO [dbo].[PatientsData]([PatientName], [PatientEmail], [AppointmentDate], [DoctorName], [Message]) VALUES (@PatientName, @PatientEmail, @AppointmentDate, @DoctorName, @Message)";

                var result = db.Execute(insertQuery, new 
                {patientsData.PatientName,patientsData.PatientEmail,patientsData.AppointmentDate,patientsData.DoctorsData.DoctorName,patientsData.Message
                    });
            }
        }



    }
}
