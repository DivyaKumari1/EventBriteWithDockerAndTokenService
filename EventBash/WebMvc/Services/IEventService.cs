using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMvc.Models;

namespace WebMvc.Services
{
    public interface IEventService
    {
        Task<Event> GetEventItemsAsync(int page, int size,
                int? category, int? venue);

        Task<IEnumerable<SelectListItem>> GetCategoriesAsync();
        Task<IEnumerable<SelectListItem>> GetVenuesAsync();
    }
}
