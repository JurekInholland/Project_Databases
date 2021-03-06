﻿using System;
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
    public class Timetable_DAO : Base
    {

        // Retrieve a dictionary of teachers names.
        public Dictionary<int, string> Db_Get_Teacher_Names()
        {
            string query = "SELECT teacher_id, first_name, last_name FROM [Teacher]";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTeachers(ExecuteSelectQuery(query, sqlParameters));
        }
        private Dictionary<int, string> ReadTeachers(DataTable dataTable)
        {
            var dictionary = new Dictionary<int, string>();

            foreach (DataRow dr in dataTable.Rows)
            {
                string fullName = (String)(dr["first_name"]) + " " + (String)(dr["last_name"]);
                dictionary.Add((int)dr["teacher_id"], fullName);
            }
            return dictionary;
        }



        public List<Activity> Db_Get_All_Activities()
        {
            string query = "SELECT activity_id, date, name, numberofstudents, supervisor1, supervisor2 FROM [Activity]";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }

        private List<Activity> ReadTables(DataTable dataTable)
        {
            List<Activity> activities = new List<Activity>();

            foreach (DataRow dr in dataTable.Rows)
            {
                int supervisor1Id = 0;
                int supervisor2Id = 0;

                Console.WriteLine("ID: " + dr["activity_id"] + " sup:" + dr["supervisor1"].ToString());
                if (dr["supervisor1"].ToString() != "")
                {
                    supervisor1Id = (int)dr["supervisor1"];
                } 

                if (dr["supervisor2"].ToString() != "")
                {
                    supervisor2Id = (int)dr["supervisor2"];
                }
                

                Activity activity = new Activity()
                {
                    activity_id = (int)dr["activity_id"],
                    //date = (DateTime)["date"],
                    date = (DateTime)dr["date"],

                    
                    supervisor1 = supervisor1Id,
                    supervisor2 = supervisor2Id,
                    name = (string)dr["name"]

                };
                activities.Add(activity);
            }
            return activities;
        }

    }
}
