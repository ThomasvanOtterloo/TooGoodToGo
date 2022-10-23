using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain
{
    public class PackageProducts
    {
        public int Id { get; set; }
        public int PackageId { get; set; }
        public int ProductId { get; set; }
        public Package Package { get; set; }
        public Product Product { get; set; }
    }
}
