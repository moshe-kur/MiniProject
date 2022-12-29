using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int SuplierID { get; set; }
        public int CategoryID { get; set; }
        public string QuantityPerUnit{ get; set; }
        public SqlMoney UnitPrice { get; set; }
        public Int16 UnitInStock { get; set; }
        public Int16 UnitsOnOrder { get; set; }   
        public Int16 ReorderLevel { get; set; }
        public bool Discontinued { get; set; }

    }
}
