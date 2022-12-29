using Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace MinibigProject.Data.Sql
{
   
    public class Products
    {
        /*
        public Dictionary<string, Model.Product> ReadFromDB(SqlDataReader reader)
        {
            Dictionary<string, Model.Product> DicProducts = new Dictionary<string, Model.Product>();
            DicProducts.Clear();
            while (reader.Read())
            {
                Model.Product product = new Model.Product();
                product.ID = reader.GetInt32(0);
                product.Name = reader.GetString(1);
                product.SuplierID = reader.GetInt32(2);
                product.CategoryID = reader.GetInt32(3);
                product.QuantityPerUnit = reader.GetString(4);
                product.UnitPrice = reader.GetSqlMoney(5);
                product.UnitInStock = reader.GetInt16(6);
                product.UnitsOnOrder = reader.GetInt16(7);
                product.ReorderLevel = reader.GetInt16(8);
                product.Discontinued = reader.GetBoolean(9);


                DicProducts.Add(product.Name, product);
            }

            return  DicProducts;
             
        }
        */

             Model.Product OneProducts = new Model.Product();
        public Model.Product ReadOneFromDB(SqlDataReader reader)
        {
            if (reader.Read())
            {
                OneProducts.ID = reader.GetInt32(0);
                OneProducts.Name = reader.GetString(1);
                OneProducts.SuplierID = reader.GetInt32(2);
                OneProducts.CategoryID = reader.GetInt32(3);
                OneProducts.QuantityPerUnit = reader.GetString(4);
                OneProducts.UnitPrice = reader.GetSqlMoney(5);
                OneProducts.UnitInStock = reader.GetInt16(6);
                OneProducts.UnitsOnOrder = reader.GetInt16(7);
                OneProducts.ReorderLevel = reader.GetInt16(8);
                OneProducts.Discontinued = reader.GetBoolean(9);


            }

            return OneProducts;

        }


        Dictionary<string, Model.Product> DicProducts = new Dictionary<string, Model.Product>();
        public Dictionary<string, Model.Product> SetDataReader(SqlDataReader reader)
        {
            
            DicProducts.Clear();
            while (reader.Read())
            {
                Model.Product product = new Model.Product();
                product.ID = reader.GetInt32(0);
                product.Name = reader.GetString(1);
                product.SuplierID = reader.GetInt32(2);
                product.CategoryID = reader.GetInt32(3);
                product.QuantityPerUnit = reader.GetString(4);
                product.UnitPrice = reader.GetSqlMoney(5);
                product.UnitInStock = reader.GetInt16(6);
                product.UnitsOnOrder = reader.GetInt16(7);
                product.ReorderLevel = reader.GetInt16(8);
                product.Discontinued = reader.GetBoolean(9);


                DicProducts.Add(product.Name, product);
            }

            return DicProducts;


            return null;    
        }

        public Dictionary<string, Model.Product> SendToReadFroDB()
        {
            
            string sqlQuery = "select * from Products";
            SqlDataReader ret =  DAL.SqlQuery.ReadFromDB(sqlQuery,SetDataReader);
            return DicProducts;

        }

        public Model.Product SendToReadFroDB(string IdNumber)
        {
            string sqlQuery = "select * from Products where ProductID =" + IdNumber;
            SqlDataReader ret = DAL.SqlQuery.ReadFromDB(sqlQuery, ReadOneFromDB);

            return OneProducts;

            
        }
    }
}
