using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Collections.ObjectModel;
using SomerenModel;

namespace SomerenDAL
{
    public class Lecturer_DAO : Base
    {

        public List<Teacher> Db_Get_All_Lecturers()
        {
            string query = "SELECT teacher_id, first_name, last_name, supervisor FROM [Teacher]";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            DataTable dttest = ExecuteSelectQuery(query, sqlParameters);
            List<Teacher> tlist = ReadTables(dttest);
            return tlist;
        }

        private List<Teacher> ReadTables(DataTable dataTable)
        {
            List<Teacher> teachers = new List<Teacher>();
            foreach (DataRow dr in dataTable.Rows)
            {
                Teacher teacher = new Teacher()
                {
                    Number = (int)dr["teacher_id"],
                    FirstName = (String)(dr["first_name"]),
                    LastName = (String)(dr["last_name"]),
                    Supervisor = (int)(dr["supervisor"]),
                };
                teachers.Add(teacher);
            }
            return teachers;
        }

    }
}
