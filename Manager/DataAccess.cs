using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager
{
    internal class DataAccess
    {
        public int InsertProduct(string connectionString)
        {
            string productName, price, categoryId, description, imageUrl;

            Console.WriteLine("insert productName");
            productName = Console.ReadLine();
            Console.WriteLine("insert price");
            price = Console.ReadLine();
            Console.WriteLine("insert categoryId");
            categoryId = Console.ReadLine();
            Console.WriteLine("insert description");
            description = Console.ReadLine();
            Console.WriteLine("insert imageUrl");
            imageUrl = Console.ReadLine();

            string query = "INSERT INTO Products(PRODUCT_NAME, PRICE, CATEGORY_ID, DESCRIPTION, IMAGE_URL)" +
                "VALUES (@ProductName, @Price, @CategoryId, @Description, @ImageUrl)";
            
            using(SqlConnection cn=new SqlConnection(connectionString))
            using (SqlCommand cmd=new SqlCommand(query,cn))
            {
                cmd.Parameters.Add("@ProductName", SqlDbType.VarChar, 50).Value = productName;
                cmd.Parameters.Add("@Price", SqlDbType.VarChar, 50).Value = price;
                cmd.Parameters.Add("@CategoryId", SqlDbType.VarChar, 50).Value = categoryId;
                cmd.Parameters.Add("@Description", SqlDbType.VarChar, 50).Value = description;
                cmd.Parameters.Add("@ImageUrl", SqlDbType.VarChar, 50).Value = imageUrl;

                cn.Open();
                int rowsEffected = cmd.ExecuteNonQuery();
                cn.Close();

                return rowsEffected;
            }
        }



        public int InsertCategory(string connectionString)
        {
            string categorytName;

            Console.WriteLine("insert categorytName");
            categorytName = Console.ReadLine();
            

            string query = "INSERT INTO Categories(CATEGORY_NAME)" +
                "VALUES (@CategorytName)";

            using (SqlConnection cn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, cn))
            {
                cmd.Parameters.Add("@CategorytName", SqlDbType.VarChar, 50).Value = categorytName;
         

                cn.Open();
                int rowsEffected = cmd.ExecuteNonQuery();
                cn.Close();

                return rowsEffected;
            }
        }

        internal void readProducts(string connectionString)
        {
            string queryString = "select * from Products";
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(queryString, cn);
                try
                {
                    cn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine("\t{0}\t{1}\t{2}\t{3}\t{4}\t{5}",
                            reader[0], reader[1], reader[2], reader[3], reader[4], reader[5]);
                    }
                    reader.Close();
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
               
            }
            
            
        }


        internal void readCategories(string connectionString)
        {
            string queryString = "select * from Categories";
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(queryString, cn);
                try
                {
                    cn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine("\t{0}\t{1}",
                            reader[0], reader[1]);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }


        }

        internal void createItem(string connectionString)
        {
            string letter;
            string toContinue = "y";
            
            while (toContinue=="y")
            {
                Console.WriteLine("Press p for product and c for category");
                letter = Console.ReadLine();
                if (letter == "p")
                    {
                        InsertProduct(connectionString);
                    }
               if (letter == "c")
                    {
                        InsertCategory(connectionString);
                    }
               //else
               //     {
               //         Console.WriteLine("Incorrect input");
               //     }
                Console.WriteLine("Would you want to continue? press y/n.");
                toContinue = Console.ReadLine();
            }
            Console.WriteLine("Products:");
            readProducts(connectionString);

            Console.WriteLine("Categories:");
            readCategories(connectionString);
            Console.ReadLine();
        }

    }
}
