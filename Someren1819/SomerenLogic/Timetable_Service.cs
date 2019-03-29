using SomerenDAL;
using SomerenModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomerenLogic
{
    public class Timetable_Service
    {
        Timetable_DAO timetable_db = new Timetable_DAO();

        public List<Activity> GetTimetableData()
        {
            try
            {
                List<Activity> activityList = timetable_db.Db_Get_All_Activities();
                return activityList;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Dictionary<int, string> GetTeacherNames()
        {
            try
            {
                Dictionary<int, string> teachers = timetable_db.Db_Get_Teacher_Names();
                return teachers;

            } catch (Exception e)
            {
                throw e;
            }
        }
    }
}
