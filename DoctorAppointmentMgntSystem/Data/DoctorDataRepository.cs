using Dapper;
using DoctorAppointmentMgntSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace DoctorAppointmentMgntSystem.Data
{
    public interface IDoctorDataRepository
    {
        public IEnumerable<DoctorsData> GetDoctorsDatas();
    }

    public class DoctorDataRepository:IDoctorDataRepository
    {
        private readonly AppDBContext _appDBContext;
        private readonly string _connectionString;

        public DoctorDataRepository(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
            _connectionString = _appDBContext._connectionString;

        }

        public IEnumerable<DoctorsData> GetDoctorsDatas()
        {
            //string query = "Select DoctorName from DoctorsData";
                SqlConnection con = new SqlConnection(_connectionString);
            var result = con.Query<DoctorsData>("sp_GetDoctorNames", commandType: System.Data.CommandType.StoredProcedure);
            //var result = con.Query<DoctorsData>(query);
                return result;
            
        }
    }
}
