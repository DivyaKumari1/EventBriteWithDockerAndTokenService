using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WebMvc.Infrastructure;
using WebMvc.Models;

namespace WebMvc.Services
{
    //EventService.cs implements IEventService
    public class EventService : IEventService
    {
        private readonly IHttpClient _client;
        private readonly string _baseUri; //

        public EventService(IHttpClient httpclient, IConfiguration config)
        {
            _client = httpclient;
            _baseUri = $"{config["EventCatalogUrl"]}/api/events/";

        }

        public async Task<IEnumerable<SelectListItem>> GetCategoriesAsync()
        {
            var categoryUri = ApiPaths.Events.GetAllCategories(_baseUri); //Once token service is added, you may need to add tokens to this.
            var dataString = await _client.GetStringAsync(categoryUri);

            var items = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Value=null,
                    Text="All",
                    Selected=true //selected will be true by default
                }
            };
            var categories = JArray.Parse(dataString);
            foreach(var category in categories)
            {
                items.Add(
                    new SelectListItem
                    {
                        Value = category.Value<string>("id"),
                        Text = category.Value<string>("category")
                    }
                    );
            }
            return items;
        }

        public async Task<IEnumerable<SelectListItem>> GetVenuesAsync()
        {
            var venueUri = ApiPaths.Events.GetAllVenues(_baseUri); //Once token service is added, you may need to add tokens to this.
            var dataString = await _client.GetStringAsync(venueUri);

            var items = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Value = null,
                    Text = "All",
                    Selected = true
                }
            };

            var venues = JArray.Parse(dataString);
            foreach (var venue in venues)
            {
                items.Add(
                new SelectListItem
                {
                    Value = venue.Value<string>("id"),
                    Text = venue.Value<string>("venue")
                }

                );
            }

            return items;
        }

        public async Task<Event> GetEventItemsAsync(int page, int size, int? category, int? venue)
        {
            var eventItemsUri = ApiPaths.Events.GetAllEventItems(_baseUri,
                    page, size, category, venue);

            var dataString = await _client.GetStringAsync(eventItemsUri);

            var response = JsonConvert.DeserializeObject<Event>(dataString); //Event is the WebMvc Model for paginated view model (from Events Catalog msvce)

            return response;
        }


    }
}
