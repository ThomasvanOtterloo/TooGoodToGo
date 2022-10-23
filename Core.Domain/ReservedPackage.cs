using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain
{
    public class ReservedPackage
    {


        public int Id { get; set; }
        public int StudentId { get; set; }
        public int PackageId { get; set; }
        public Student Student { get; set; }
        public Package Package { get; set; }
    }
}
