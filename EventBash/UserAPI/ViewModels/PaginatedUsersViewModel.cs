using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserAPI.ViewModels
{
    public class PaginatedUsersViewModel<TEntity>
        where TEntity : class
    {
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
        public long Count { get; set; }

        public IEnumerable<TEntity> Data { get; set; }
    }
            
}
