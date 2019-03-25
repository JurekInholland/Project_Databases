using SomerenDAL;
using SomerenModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomerenLogic
{
    public class Report_Service
    {
        Report_DAO report_db = new Report_DAO();

        public List<Report> GetReports()
        {
            try
            {
                List<Report> reportList = report_db.Db_Get_All_Reports();
                return reportList;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
