using KUB.SharedKernel.DTOModels.Tournament;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KUB.SharedKernel.DTOModels
{
    public class SchoolDto : Dto
    {
        public Guid Id { get; set; }
        public string SchoolName { get; set; }
    }
}
