using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebMvc.Services;
using WebMvc.ViewModels;

namespace WebMvc.Controllers
{
    public class EventsCatalogController : Controller
    {
       
        //similar to CatalogController in Jewels WebMvc
        private readonly IEventService _service;

        public EventsCatalogController(IEventService service) =>
            _service = service;

        public async Task<IActionResult> Index(int? category, int? venue, int? page)
        {
            var itemsOnPage = 10;
            
            var eventCatalog = await _service.GetEventItemsAsync(page ?? 0, 
                                     itemsOnPage, category, venue);

            var vm = new EventIndexViewModel
            {
                PaginationInfo = new PaginationInfo
                {
                    ActualPage = page ?? 0,
                    ItemsPerPage = itemsOnPage,
                    TotalItems = eventCatalog.Count,
                    TotalPages = (int)Math.Ceiling((decimal)eventCatalog.Count / itemsOnPage),

                },

                EventItems = eventCatalog.Data,
                Categories = await _service.GetCategoriesAsync(),
                Venues = await _service.GetVenuesAsync(),
                CategoryFilterApplied = category ?? 0,
                VenueFilterApplied = venue ?? 0

            };
            vm.PaginationInfo.Previous = (vm.PaginationInfo.ActualPage == 0) ? "is-disabled" : " ";
            vm.PaginationInfo.Next = (vm.PaginationInfo.ActualPage == vm.PaginationInfo.TotalPages - 1) ? "is-disabled" : "";

            return View(vm);
        }

        [Authorize]
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }
    }
}