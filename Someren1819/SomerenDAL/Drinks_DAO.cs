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
    public class Drinks_DAO : Base
    {
        public List<Drink> Db_Get_All_Drinks()
        {
            //selecting and sorting the items
            string query = "SELECT drink_name, price, stock, sold " +
                           "FROM [Drink] " +
                           "WHERE stock > 1 AND price > 1 " +
                           "ORDER BY stock, price, sold ";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }

        private List<Drink> ReadTables(DataTable dataTable)
        {
            List<Drink> drinkList = new List<Drink>();

            foreach (DataRow dr in dataTable.Rows)
            {

                if (dr["drink_name"].ToString() == "Water" || dr["drink_name"].ToString() == "Orangeade" || dr["drink_name"].ToString() == "Cherry juice")
                {
                    //not to include water and the indicated juices to the list
                    continue;
                }
                Drink drinks = new Drink()
                {
                    Token = (int)dr["price"],
                    Name = (String)(dr["drink_name"].ToString()),
                    Stock = (int)dr["stock"],
                    DrinksSold = (int)dr["sold"],

                };
                drinkList.Add(drinks);
            }
            return drinkList;
        }
    }
}
