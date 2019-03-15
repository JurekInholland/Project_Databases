using SomerenDAL;
using SomerenModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomerenLogic
{
    public class Lecturer_Service
    {
        Lecturer_DAO lecturer_db = new Lecturer_DAO();

        public List<Teacher> GetTeachers()
        {
            try
            {
                List<Teacher> teacher = lecturer_db.Db_Get_All_Lecturers();
                return teacher;
            }
            catch (Exception e)
            {
                throw (e);
            }

        }
    }
}
