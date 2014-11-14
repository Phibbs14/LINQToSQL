using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _415Project.DAL
{
    class Test
    {
        public static void TestMethod() 
        {
            DataContext db = new DataContext(Properties.Settings.Default.dbConnection);
        }
    }
}
