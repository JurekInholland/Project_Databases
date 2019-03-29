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
    public class Activity_Service
    {
        Activity_DAO activity_db = new Activity_DAO();

        public List<Activity> GetActivities()
        {
            try
            {
                List<Activity> activity = activity_db.Db_Get_All_Activities();
                return activity;
            }
            catch (Exception e)
            {
                // Todo: Improve error logic.
                throw new Exception("Someren couldn't connect to the database " + e);
            }

        }

        public void AddActivity(Activity a)
        {
            try
            {
                activity_db.Db_Insert(a);


            }
            catch (Exception e)
            {
                // Todo: Improve error logic.
                throw new Exception("Someren couldn't connect to the database " + e);
            }

        }
        public void EditActivity(Activity a)
        {
            try
            {
                activity_db.Db_Edit(a);


            }
            catch (Exception e)
            {
                // Todo: Improve error logic.
                throw new Exception("Someren couldn't connect to the database " + e);
            }

        }
        public void RemoveActivity(Activity a)
        {
            try
            {
                activity_db.Db_Remove(a);


            }
            catch (Exception e)
            {
                // Todo: Improve error logic.
                throw new Exception("Someren couldn't connect to the database " + e);
            }



        }


    }



}


