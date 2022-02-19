using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KUB.Core.Models
{
    public class BaseEntity
    {
        public Guid Id { get; set; }  = Guid.NewGuid();
    }
}
