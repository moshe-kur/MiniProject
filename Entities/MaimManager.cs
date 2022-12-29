using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{

    public class MaimManager
    {
        //private Product std = new Product();
        //public Hashtable Products = new Hashtable();

        private static readonly MaimManager _Instace = new MaimManager();
        public static MaimManager Instace { get { return _Instace; } }
        private MaimManager() { }

        public Products products = new Products();
        public UserMessages usersMessage = new UserMessages();
    }
}
