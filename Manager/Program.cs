using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Data Source = SRV2\\PUPILS; Initial Catalog = SHOP_214928673; Integrated Security = True; Encrypt = False";
            DataAccess da = new DataAccess();
            //da.InsertData(connectionString);
            //da.readData(connectionString);
            //da.fillDataSet(connectionString);
            da.createItem(connectionString);
        }
    }
}
