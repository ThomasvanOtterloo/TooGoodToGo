using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain
{
    abstract class User
    {
        public int Id { get; set; }

        private string Email { get; set; }

        private string Password { get; set; }



    }
}
