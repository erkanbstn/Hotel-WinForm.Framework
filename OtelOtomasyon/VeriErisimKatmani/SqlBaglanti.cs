using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeriErisimKatmani
{
    public static class SqlBaglanti  // Veritabanı bağlantılarımızı sağlamak için Bağlantı cümleciğimizi her yere çağırmak yerine
        // Tek yerden çağırmak ve işimizi kolaylaştırmak için tanımlanan Sınıf
    {
        // Bağlantı cümleciği
        public static SqlConnection con = new SqlConnection("Data Source=GEOPC\\SQLEXPRESS;Initial Catalog=OtelDB;Integrated Security=True;MultipleActiveResultSets=True");
        // Bağlantı Cümleciğinin İşlevsel olmasını sağlayan kod bloğu                   
    }
}
