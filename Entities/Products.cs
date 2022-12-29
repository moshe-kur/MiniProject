using MinibigProject.Data.Sql;
using Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Products
    {
        
        public Dictionary<string,Product> DicProducts = new Dictionary<string,Product>();
       
        public Dictionary<string, Product> getProductFromDB()
        {
           MinibigProject.Data.Sql.Products products = new MinibigProject.Data.Sql.Products();
            DicProducts = products.SendToReadFroDB();
            return DicProducts;
        }
        public Model.Product getOneProductFromDB(string Idnumber)
        {
            MinibigProject.Data.Sql.Products OneProduct  = new MinibigProject.Data.Sql.Products();
            return OneProduct.SendToReadFroDB(Idnumber);
        }
    }
}
