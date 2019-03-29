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
    public class Activity_DAO : Base
    {

        public List<Activity> Db_Get_All_Activities()
        {
            string query = "SELECT activity_id, name, numberofstudents, numberofsupervisors FROM [Activity]";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }

        private List<Activity> ReadTables(DataTable dataTable)
        {
            List<Activity> activities = new List<Activity>();

            foreach (DataRow dr in dataTable.Rows)
            {
                Activity activity = new Activity()
                {
                    activity_id = (int)dr["activity_id"],
                    // change name in the future
                    name = (String)(dr["name"].ToString()),
                    numberofstudents = (int)(dr["numberofstudents"]),
                    numberofsupervisors = (int)(dr["numberofsupervisors"]),
                };
                activities.Add(activity);
            }
            return activities;
        }


        public void Db_Insert(Activity a)
        {
            string query = "INSERT INTO Activity (name, numberofstudents, numberofsupervisors)" +
            "VALUES(@name, @numberofstudents, @numberofsupervisors)";


            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@name", a.name),
                new SqlParameter("@numberofstudents", a.numberofstudents),
                new SqlParameter("@numberofsupervisors", a.numberofsupervisors)
            };
            ExecuteEditQuery(query, sqlParameters);

        }

        public void Db_Edit(Activity a)
        {
            string query = "UPDATE Activity SET name = @name,numberofstudents = @numberofstudents, numberofsupervisors = @numberofsupervisors" +
                " WHERE activity_id = @activity_id";

            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@activity_id", a.activity_id),
                new SqlParameter("@name", a.name),
                new SqlParameter("@numberofstudents", a.numberofstudents),
                new SqlParameter("@numberofsupervisors", a.numberofsupervisors)
            };
            ExecuteEditQuery(query, sqlParameters);

        }

        public void Db_Remove(Activity a)
        {
            string query = "DELETE FROM Activity WHERE" +
                "activity_id = @activity_id AND name = @name AND numberofstudents = @numberofstudents AND numberofsupervisors = @numberofsupervisors";



            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@activity_id", a.activity_id),
                new SqlParameter("@name", a.name),
                new SqlParameter("@numberofstudents", a.numberofstudents),
                new SqlParameter("@numberofsupervisors", a.numberofsupervisors)
            };
            ExecuteEditQuery(query, sqlParameters);

        }




    }
}
