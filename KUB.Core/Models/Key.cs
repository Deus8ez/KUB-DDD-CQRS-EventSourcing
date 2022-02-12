using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Models
{
    public class Key
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string HashedKey { get; set; }
    }
}
