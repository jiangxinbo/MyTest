using EFTest.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Mapping;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Infrastructure;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFTest
{
    class Program
    {
        static void Main(string[] args)
        {

            using (var db = new DB())
            {
                //一次性触发所有的DbContext进行mapping views的生成操作——调用StorageMappingItemCollection的GenerateViews()方法。
                var objectContext = ((IObjectContextAdapter)db).ObjectContext;
                var mappingCollection = (StorageMappingItemCollection)objectContext.MetadataWorkspace.GetItemCollection(DataSpace.CSSpace);
                mappingCollection.GenerateViews(new List<EdmSchemaError>());
                ///////////////////////////////////////////////////////////////////////////

                var data = (from n in db.integral_log
                           let cc = n.create_time
                           orderby n.valuta descending,n.create_time descending
                           select n);


                Console.WriteLine("数据共计：" + data.Count());

                foreach (var item in data)
                {
                    Console.WriteLine(item.valuta+"--------------"+item.create_time);
                }

                Console.WriteLine();

            }
        }
    }
}
