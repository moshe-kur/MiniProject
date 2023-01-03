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
       
        

             Model.Product OneProducts = new Model.Product();
        public Model.Product ReadOneFromDB(SqlDataReader reader)
        {
            if (reader.Read())
            {
                OneProducts.ProductID = reader.GetInt32(0);
                OneProducts.ProductName = reader.GetString(1);
                OneProducts.SupplierID = reader.GetInt32(2);
                OneProducts.CategoryID = reader.GetInt32(3);
                OneProducts.QuantityPerUnit = reader.GetString(4);
                OneProducts.UnitPrice = reader.GetDecimal(5);
                OneProducts.UnitsInStock = reader.GetInt16(6);
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
                product.ProductID = reader.GetInt32(0);
                product.ProductName = reader.GetString(1);
                product.SupplierID = reader.GetInt32(2);
                product.CategoryID = reader.GetInt32(3);
                product.QuantityPerUnit = reader.GetString(4);
                product.UnitPrice = reader.GetDecimal(5);
                product.UnitsInStock = reader.GetInt16(6);
                product.UnitsOnOrder = reader.GetInt16(7);
                product.ReorderLevel = reader.GetInt16(8);
                product.Discontinued = reader.GetBoolean(9);


                DicProducts.Add(product.ProductName, product);
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

        public void SendFromDSToDal(Product product)
        {
            string sqlQuery = string.Format("update Products set  ProductName ='{0}',SupplierID={1},CategoryID={2},QuantityPerUnit='{3}',UnitPrice={4},UnitsInStock={5},UnitsOnOrder={6},ReorderLevel={7} where ProductID ={8} ", product.ProductName, product.SupplierID, product.CategoryID, product.QuantityPerUnit, product.UnitPrice, product.UnitsInStock, product.UnitsOnOrder , product.ReorderLevel,product.ProductID);
            DAL.SqlQuery.SendToDB(sqlQuery);
        }

        public void DeleteFromDB(string IdNumber)
        {
            string sqlQuery = "delete Products where ProductID =" + IdNumber;
            DAL.SqlQuery.SendToDB(sqlQuery);
        }

    }
}
