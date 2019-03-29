using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Collections.ObjectModel;
using SomerenModel;
using System.Configuration;

namespace SomerenDAL
{
    public class Supervisor_DAO : Base
    {
        public List<Supervisor> Db_Get_All_Supervisors()
        {
            string query = "SELECT S.LecturerID, T.first_name, last_name FROM [Supervisor] AS S JOIN [Teacher] AS T ON S.LecturerID = T.teacher_id";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }

        private List<Supervisor> ReadTables(DataTable dataTable)
        {
            List<Supervisor> supervisors = new List<Supervisor>();

            foreach (DataRow sv in dataTable.Rows)
            {
                Supervisor supervisor = new Supervisor()
                {
                    SupervisorID = (int)sv["LecturerID"],
                    Name = (String)(sv["first_name"].ToString() + sv["last_name"].ToString()),

                };
                supervisors.Add(supervisor);
            }
            return supervisors;
        }
        //adding to DB
        public void AddSup(string ID)
        {
            string constring = ConfigurationManager.ConnectionStrings["SomerenDatabase"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(constring))
            {
                using (SqlCommand cmd = new SqlCommand("INSERT INTO [dbo].[Supervisor] (LecturerID) VALUES (@ID)", conn))
                {

                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@ID", ID);
                    conn.Open();
                    int rowsAffect = cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }
        //removing it from DB
        public void RemoveSup(string ID)
        {
            string constring = ConfigurationManager.ConnectionStrings["SomerenDatabase"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(constring))
            {
                using (SqlCommand cmd = new SqlCommand("DELETE FROM [dbo].[Supervisor] WHERE LecturerID = @ID", conn))
                {

                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@ID", ID);
                    conn.Open();
                    int rowsAffect = cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }
    }
}
