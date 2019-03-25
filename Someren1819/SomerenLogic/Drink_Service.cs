using SomerenDAL;
using SomerenModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomerenLogic
{
    public class Drink_Service
    {
        Drinks_DAO drinks_db = new Drinks_DAO();

        public List<Drink> GetDrinks()
        {
            try
            {
                List<Drink> drink = drinks_db.Db_Get_All_Drinks();
                return drink;
            }
            catch (Exception e)
            {
                throw (e);
            }
        }
    }
}
