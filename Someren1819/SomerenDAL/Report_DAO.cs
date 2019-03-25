using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SomerenModel;
using System.Data;
using System.Data.SqlClient;

namespace SomerenDAL
{
    public class Report_DAO : Base
    {
        //public List<Report> Db_Get_Reports_In_Range(DateTime start, DateTime end)
        //{

        //}

        public List<Report> Db_Get_All_Reports()
        {


            //selecting and sorting the items
            string query = "SELECT date, student_id, item, quantity, cost " +
                           "FROM [Purchase] ";

            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }

        private List<Report> ReadTables(DataTable dataTable)
        {
            List<Report> reportList = new List<Report>();

            foreach (DataRow dr in dataTable.Rows)
            {
       
                Report report = new Report()
                {
                    Date = (DateTime)dr["date"],
                    //Date = DateTime.Now,
                    Student_id = (int)(dr["student_id"]),
                    Item = (int)dr["item"],
                    Cost = (int)dr["cost"],
                    Quantity = Convert.ToInt16(dr["quantity"])
                };
                //Console.WriteLine("GEN REPORT: " + report.Date);
                reportList.Add(report);
            }

            return reportList;
        }
    }
}
