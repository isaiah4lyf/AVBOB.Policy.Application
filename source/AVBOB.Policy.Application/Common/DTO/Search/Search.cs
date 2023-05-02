using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Search
{
    public class Search<T>
    {
        public int Id { get; set; }
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
        public int Count { get; set; }
        public T? Results { get; set; }
    }
}
