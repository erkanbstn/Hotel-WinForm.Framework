using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtelOtomasyon.EntityModel
{
    public static class EntityConnect // Veritabanı Entity bağlantılarımızı sağlamak için Bağlantı cümleciğimizi her yere çağırmak yerine
                                      // Tek yerden çağırmak ve işimizi kolaylaştırmak için tanımlanan Sınıf
    {
        // Bağlantı cümleciği
        public static OtelDBEntities db = new OtelDBEntities();
        // Bağlantı Cümleciğinin İşlevsel olmasını sağlayan kod bloğu 
    }
}
