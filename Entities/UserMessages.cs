using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class UserMessages
    {
        public void SendQueryToDB(string SqlQuery)
        {
            //function must me static
            DAL.SqlQuery.SendToDB(SqlQuery);
        }
    }
}
