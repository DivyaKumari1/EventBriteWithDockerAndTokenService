using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMvc.Models
{
    //this is your EventCatalogAPI Paginated view model for WebMvc. 
    public class Event
    {
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
        public long Count { get; set; }
        public List<EventItem> Data { get; set; } 
    }
}
