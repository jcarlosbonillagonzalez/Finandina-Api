using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finandina_Domain.Packager
{
    public class BasicPaginationParams
    {
        private const int MaxPageSize = 50;
        private const int MinPageIndex = 1;

        private int _pageSize = 10;
        private int _pageIndex = 1;

        public int PageIndex
        {
            get => _pageIndex;
            set => _pageIndex = value <= 0 ? MinPageIndex : value;
        }

        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = value == -1
                                 ? int.MaxValue
                                 : (value > MaxPageSize
                                     ? MaxPageSize
                                     : (value == 0 ? 10 : value));
        }
    }
}
