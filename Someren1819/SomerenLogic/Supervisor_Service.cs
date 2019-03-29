using SomerenDAL;
using SomerenModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace SomerenLogic
{
    public class Supervisor_Service
    {
        Supervisor_DAO supervisor_db = new Supervisor_DAO();

        public List<Supervisor> GetSupervisors()
        {
            try
            {
                List<Supervisor> supervisor = supervisor_db.Db_Get_All_Supervisors();
                return supervisor;
            }
            catch (Exception e)
            {
                throw (e);
            }

        }
    }
}
