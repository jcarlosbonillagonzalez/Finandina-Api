using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finandina_Domain.Packager
{
    public class ParameterFilter : BasicPaginationParams
    {
        public string? Search { get; set; }
    }
}
