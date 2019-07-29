using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventCatalogAPI.Domains;
using Microsoft.EntityFrameworkCore;

namespace EventCatalogAPI.Data
{
    public static class EventSeed
    {
        public static void Seed(EventContext context)
        {
            context.Database.Migrate(); 

            //Only fill up the database if you don't have anything in there.
            if (!context.EventVenues.Any())
            {
                context.EventVenues.AddRange(GetPreconfiguredEventVenues());       

                context.SaveChanges();
            }
            else
            {
                context.EventVenues.AttachRange(GetPreconfiguredEventVenues());
                context.SaveChanges();
            }
            
            

           if (!context.EventCategories.Any())
            {
                context.EventCategories.AddRange(GetPreconfiguredEventCategories());

                context.SaveChanges();
           }

       if (!context.EventItems.Any())
           {
                context.EventItems.AddRange(GetPreconfiguredEventItems());

             context.SaveChanges();
         }


        }

        private static IEnumerable<EventItem> GetPreconfiguredEventItems()
        {
            return new List<EventItem>
           {

                  new EventItem() { EventCategoryId=3, EventStartDate = "11/23/19",EventVenueId=6, EventDescription="Dummy Data DELETE"  , EventName="DummyDATA"   , EventCost=20.00m   , EventAddress="DUMMY DAta", EventCity="Seattle", EventState="Washington"  , EventZip=98109  , EventFavorite=false , EventTicketsAvailable=100 , EventStartTime="8:00"  ,  EventEndDate="11/23/19", EventEndTime="17:00", EventPictureUrl="http://externaleventcatalogbaseurltobereplaced/api/pic/1"  , EventUrl="https://tedxseattle.com/" },
                  new EventItem() { EventCategoryId=3, EventStartDate = "11/23/19",EventVenueId=6, EventDescription="Talk Talk Talks on a moment of change from one position to another, whether it be in relationships, beliefs, cultures, perspectives or the world"  , EventName="TEDxSeattle 2019: SHIFT"   , EventCost=20.00m   , EventAddress="321 Mercer St" , EventCity="Seattle"  , EventState="Washington"  , EventZip=98109  , EventFavorite=false , EventTicketsAvailable=100 , EventStartTime="8:00"  ,  EventEndDate="11/23/19", EventEndTime="17:00", EventPictureUrl="http://externaleventcatalogbaseurltobereplaced/api/pic/1"  , EventUrl="https://tedxseattle.com/" },
                  new EventItem() { EventCategoryId=2, EventStartDate = "7/14/19", EventVenueId=5, EventDescription="Food and wine celebration of Bastille Day"  , EventName="Bastille Day Patio Party", EventCost=19.00m, EventAddress="1416 34Th Ave" , EventCity="Seattle"  , EventState="Washington"  , EventZip=98122  , EventFavorite=false , EventTicketsAvailable=100 , EventStartTime="15:00"  ,  EventEndDate="7/14/19" ,  EventEndTime="18:00"  , EventPictureUrl="http://externaleventcatalogbaseurltobereplaced/api/pic/2"   , EventUrl="http://www.bottlehouseseattle.com/happenings/" },
                  new EventItem() { EventCategoryId=2, EventStartDate = "11/23/19",EventVenueId=4, EventDescription="Specialty food show connecting local food craftsman with everyday customers."  , EventName="Gobble Up Seattle"   , EventCost=0.00m, EventAddress="6310 NE 74th St " , EventCity="Seattle"  , EventState="Washington"  , EventZip=98115 , EventFavorite=false, EventTicketsAvailable=200 , EventStartTime="10:00"  ,  EventEndDate="11/23/19",  EventEndTime="17:00"  , EventPictureUrl="http://externaleventcatalogbaseurltobereplaced/api/pic/3" , EventUrl="https://gobbleupnorthwest.com/" },
                  new EventItem() { EventCategoryId=2, EventStartDate = "8/22/19",EventVenueId=3, EventDescription="Formal instruction on pairing cheese with Lauren Ashton wine selections."  , EventName="The Art of Cheese"   , EventCost=85.00m, EventAddress="14545 148th Ave NE, Suite 211" , EventCity="Woodinville"  , EventState="Washington" , EventZip=98072 , EventFavorite=false , EventTicketsAvailable=30 , EventStartTime="18:00" ,  EventEndDate="8/22/19" ,  EventEndTime="20:00"  , EventPictureUrl="http://externaleventcatalogbaseurltobereplaced/api/pic/4"  , EventUrl="http://laurenashtoncellars.com/calevent/the-art-of-cheese/" },
                  new EventItem() { EventCategoryId=1, EventStartDate = "7/27/19",EventVenueId=2, EventDescription="70’s & 80’s Music All Night Long!"  , EventName="Bohemian Rhapsody - Queen Inspired Dance Party"   , EventCost=5.00m   , EventAddress="925 East Pike Street" , EventCity="Seattle"  , EventState="Washington" , EventZip=98122  , EventFavorite=false , EventTicketsAvailable=100 , EventStartTime="11:00"  ,  EventEndDate="7/28/10" ,  EventEndTime="1:00"  , EventPictureUrl="http://externaleventcatalogbaseurltobereplaced/api/pic/5"  , EventUrl="http://www.neumos.com/event/1864161-bohemian-rhapsody-queen-seattle/" },
                  new EventItem() { EventCategoryId=2, EventStartDate = "9/6/19",EventVenueId=1, EventDescription="Live summer concert with Pink Martini and singer China Forbes"  , EventName="An Evening with Pink Martini with singer China Forbes"   , EventCost=79.00m   , EventAddress="14111 NE 145th Street" , EventCity="Woodinville"  , EventState="Washington"  , EventZip=98072  , EventFavorite=false , EventTicketsAvailable=100 , EventStartTime="19:00"  ,  EventEndDate="9/6/19" ,  EventEndTime="21:00"  , EventPictureUrl="http://externaleventcatalogbaseurltobereplaced/api/pic/6"  , EventUrl="https://www.ste-michelle.com/visit-us/events-calendar/an-evening-with-pink-martini-with-singer-china-forbes?concert=1" },
                  new EventItem() { EventCategoryId=1, EventStartDate = "8/4/19",EventVenueId=2, EventDescription="The Yacht Rock Revue is everything the late ‘70s and early ‘80s should’ve been!"  , EventName="Yacht Rock Revue"   , EventCost=25.00m   , EventAddress="925 East Pike Street" , EventCity="Seattle"  , EventState="Washington"  , EventZip=98122  , EventFavorite=false , EventTicketsAvailable=125 , EventStartTime="20:00"  ,  EventEndDate="8/4/19" ,  EventEndTime="23:55"  , EventPictureUrl="http://externaleventcatalogbaseurltobereplaced/api/pic/7"  , EventUrl="http://www.neumos.com/event/1861114-yacht-rock-revue-seattle/" },

                
                  new EventItem() { EventCategoryId=6, EventStartDate = "8/3/19",EventVenueId=10, EventDescription="Take in the sights of Seafair on a vintage Washington State Ferry Boat." , EventName="Seaferry Boat Cruise" , EventCost=65.00m , EventAddress="860 Terry Avenue North" , EventCity="Seattle" , EventState="Washington" , EventZip= 98109 , EventFavorite=false , EventTicketsAvailable=200 , EventStartTime="12:30" , EventEndDate="8/3/19" , EventEndTime="16:30" , EventPictureUrl="http://externaleventcatalogbaseurltobereplaced/api/pic/8" , EventUrl="https://onthehiyu.com/events-on-the-hiyu/" },
                  new EventItem() { EventCategoryId=4, EventStartDate = "8/30/19",EventVenueId=11, EventDescription="The premier all-women adventure film festival on tour internationally."  , EventName="No Man's Land Film Festival | August 30, 2019" , EventCost=15.00m , EventAddress="7700 Sand Point Way Northeast" , EventCity="Seattle" , EventState="Washington" , EventZip= 98115 , EventFavorite=false , EventTicketsAvailable=150 , EventStartTime="16:30" , EventEndDate="8/30/19" , EventEndTime="23:00" , EventPictureUrl="http://externaleventcatalogbaseurltobereplaced/api/pic/9" ,  EventUrl="https://www.eventbrite.com/o/the-mountaineers-3124892190" },
                  new EventItem() { EventCategoryId=1, EventStartDate = "8/13/19", EventVenueId=13, EventDescription="Lukas Nelson and the Promise of the Real in a concert you don't want to miss!" , EventName="Charles Smith's 20th Anniversary: Lukas Nelson & Promise of the Real" , EventCost=45.00m , EventAddress="1136 South Albro Place " , EventCity="Seattle" , EventState="Washington" , EventZip=98108 , EventFavorite=false , EventTicketsAvailable=500 , EventStartTime="19:00" , EventEndDate="8/13/19" , EventEndTime="22:30" , EventPictureUrl="http://externaleventcatalogbaseurltobereplaced/api/pic/10" , EventUrl="http://lukasnelson.com/music/" },
                  new EventItem() { EventCategoryId=3, EventStartDate = "8/7/19", EventVenueId=14, EventDescription="Town hall to discuss the future of health and wellness in the U.S" , EventName="Future of Nursing 2030 Seattle Town Hall" , EventCost=0.00m , EventAddress="1959 NE Pacific St Ste H-680" , EventCity="Seattle" , EventState="Washington" , EventZip=98195 , EventFavorite=false, EventTicketsAvailable=300 , EventStartTime="8:30" , EventEndDate="8/7/19" , EventEndTime="12:30" , EventPictureUrl="http://externaleventcatalogbaseurltobereplaced/api/pic/11" , EventUrl="https://nam.edu/publications/the-future-of-nursing-2020-2030/"   },
                  new EventItem() { EventCategoryId=1, EventStartDate = "8/10/19", EventVenueId=2,  EventDescription="Summer Salt will perform their latest album, Happy Camper." , EventName="Summer Salt with Dante Elephante + Motel Radio" , EventCost=20.00m , EventAddress="925 East Pike Street" , EventCity="Seattle" , EventState="Washington" , EventZip=98122 , EventFavorite=false , EventTicketsAvailable=400 , EventStartTime="19:00" , EventEndDate="8/10/19" , EventEndTime="21:00" , EventPictureUrl="http://externaleventcatalogbaseurltobereplaced/api/pic/12" , EventUrl="https://www.neumos.com/event/1842953-summer-salt-seattle/"  },
                  new EventItem() { EventCategoryId=2, EventStartDate = "8/16/19", EventVenueId=15, EventDescription="National Nordic Museum’s special Summer Crayfish Party!" , EventName="Summer Crayfish Party" , EventCost=100.00m , EventAddress="2655 Northwest Market Street " , EventCity="Seattle" , EventState="Washington" , EventZip=98107 , EventFavorite=false, EventTicketsAvailable=100, EventStartTime="18:00" , EventEndDate="8/16/19" , EventEndTime="21:00" ,  EventPictureUrl="http://externaleventcatalogbaseurltobereplaced/api/pic/13" , EventUrl="https://www.nordicmuseum.org/product/2602"  },
                  new EventItem() { EventCategoryId=2, EventStartDate = "8/2/19", EventVenueId=16, EventDescription="Celebrating the history of aperitivo with Italian recipes, cocktails, gelato, and live music!" , EventName="Princi Seattle | Summer Like an Italian" , EventCost=20.00m , EventAddress="2118 Westlake Avenue" , EventCity="Seattle" , EventState="Washington" , EventZip= 98121 , EventFavorite=false , EventTicketsAvailable=200 , EventStartTime="12:00" , EventEndDate="8/2/19" , EventEndTime="15:00" , EventPictureUrl="http://externaleventcatalogbaseurltobereplaced/api/pic/14" , EventUrl="https://www.eventbrite.com/o/princi-18303929851"   },
                  new EventItem() { EventCategoryId=1, EventStartDate = "8/6/19", EventVenueId=17, EventDescription="A funky and unforgettable set that pays tribute to the golden era of rap. " , EventName="Classic Hip Hop Night" , EventCost=10.00m , EventAddress="412 North 36th Street " , EventCity="Seattle", EventState="Washington" , EventZip= 98103 , EventFavorite=false , EventTicketsAvailable=200 , EventStartTime="21:00" , EventEndDate="8/3/19" , EventEndTime="2:00" ,  EventPictureUrl="http://externaleventcatalogbaseurltobereplaced/api/pic/15"  , EventUrl="https://nectarlounge.com/calendar/" },
                  new EventItem() { EventCategoryId=1, EventStartDate = "9/13/19", EventVenueId=12, EventDescription="Bristol based triad, Elder Island, in concert" , EventName="The Crocodile presents: Elder Island" , EventCost=15.00m , EventAddress="2200 2nd Avenue" , EventCity="Seattle" , EventState="Washington" , EventZip= 98121 , EventFavorite=false , EventTicketsAvailable=250 , EventStartTime="20:00" , EventEndDate="9/13/19" , EventEndTime="23:00" , EventPictureUrl="http://externaleventcatalogbaseurltobereplaced/api/pic/16" , EventUrl="https://www.thecrocodile.com/e/elder-island-58878538293/"},
                  new EventItem() { EventCategoryId=3, EventStartDate = "9/13/19", EventVenueId=18, EventDescription="Conference attendees will develop a network of knowledgeable women business owners" , EventName="Women in Business Conference" , EventCost=45.00m , EventAddress="8236 SE 24th St" , EventCity="Seattle" , EventState="Washington" , EventZip=98040 , EventFavorite=false , EventTicketsAvailable=400 , EventStartTime="9:00"  , EventEndDate="9/13/19" , EventEndTime="14:00" , EventPictureUrl="http://externaleventcatalogbaseurltobereplaced/api/pic/17" , EventUrl=" https://seattle.score.org/"   },
                  new EventItem() { EventCategoryId=6, EventStartDate = "8/10/19", EventVenueId=7,  EventDescription="Enjoy thousands of water lanterns gently floating on the water at this one night only event" , EventName="1000 Lights Water Lantern Festival 2019" , EventCost=25.00m , EventAddress="9703 Northeast Juanita Drive " , EventCity="Kirkland" , EventState="Washington" , EventZip= 98034 , EventFavorite=false , EventTicketsAvailable=1000 , EventStartTime="18:00" , EventEndDate="8/10/19" , EventPictureUrl="http://externaleventcatalogbaseurltobereplaced/api/pic/18" , EventUrl="https://www.1000lights.com/" },
                  new EventItem() { EventCategoryId=6, EventStartDate = "8/10/19", EventVenueId=8,  EventDescription="Join us as we set sail from Downtown Kirkland on Argosy Cruise Lines" , EventName="YOGACRUISE 2019 benefiting Seattle Children's" , EventCost=100.00m , EventAddress="25 Lakeshore Plaza" , EventCity="Kirkland" , EventState="Washington" , EventZip=98033 , EventFavorite=false , EventTicketsAvailable=250 , EventStartTime= "18:30" , EventEndDate="8/10/19" , EventEndTime="22:00" , EventPictureUrl="http://externaleventcatalogbaseurltobereplaced/api/pic/19" , EventUrl="https://www.seattlechildrens.org/" },
                  new EventItem() { EventCategoryId=6, EventStartDate = "8/8/19", EventVenueId=9,  EventDescription="Come kickoff the Making Strides Against Breast Cancer of Seattle season with a night of networking" , EventName="Wild for a Cure" , EventCost=0.00m , EventAddress="5500 Phinney Avenue North" , EventCity="Seattle" , EventState="Washington" , EventZip=98103 , EventFavorite=false , EventTicketsAvailable=400 , EventStartTime="19:00" , EventEndDate="8/8/19" , EventEndTime="22:00" , EventPictureUrl="http://externaleventcatalogbaseurltobereplaced/api/pic/20" , EventUrl="http://www.makingstrideswalk.org/seattlewa"},
                  new EventItem() { EventCategoryId=4, EventStartDate = "9/19/19", EventVenueId=19, EventDescription="KUOW is bringing Week in Review to Edmonds and we want to see you there!" , EventName="Week in Review Live: Edmonds" , EventCost=0.00m , EventAddress="410 4th Avenue North" , EventCity="Edmonds" , EventState="Washington" , EventZip=98020 , EventFavorite=false , EventTicketsAvailable=300 , EventStartTime="19:00" , EventEndDate="9/19/19" , EventEndTime="21:00" ,  EventPictureUrl="http://externaleventcatalogbaseurltobereplaced/api/pic/21" , EventUrl="https://kuow.org/radioactive"},
                  new EventItem() { EventCategoryId=5, EventStartDate = "8/17/19", EventVenueId=20, EventDescription="Adventure and obstacle course race series for kids." , EventName="Subaru Kids Obstacle Challenge - Seattle - Saturday" , EventCost=45.00m , EventAddress="2000 NW Sammamish Rd" , EventCity="Sammamish" , EventState="Washington" , EventZip=98027 , EventFavorite=false , EventTicketsAvailable=500 , EventStartTime="8:30" , EventEndDate="8/17/19" , EventEndTime="12:30" , EventPictureUrl="http://externaleventcatalogbaseurltobereplaced/api/pic/22" , EventUrl="https://www.kidsobstaclechallenge.com/seattle" },
           };
        }

        private static IEnumerable<EventVenue> GetPreconfiguredEventVenues()
        {
            return new List<EventVenue>()
            {
                //Here, add the list of venues I created to populate db.
                new EventVenue() {Venue= "Chateau Ste Michelle"},    /// 1
                new EventVenue() {Venue= "Neumos"},  /// 2
                new EventVenue() {Venue= "Lauren Ashton Cellars"},   /// 3
                new EventVenue() {Venue= "Magnussen Park Hangar 30"},    /// 4
                new EventVenue() {Venue= "Bottle House Seattle"},    /// 5
                new EventVenue() {Venue= "McCaw Hall"},    /// 6
                new EventVenue() {Venue= "Juanita Beach Park"},    /// 7
                new EventVenue() {Venue= "Kirkland City Dock"},    /// 8
                new EventVenue() {Venue= "Woodland Park Zoo"},    /// 9
                new EventVenue() {Venue= "Museum of History & Industry (MOHAI)"},   /// 10
                new EventVenue() {Venue= "The Mountaineers Seattle Program Center"},   /// 11
                new EventVenue() {Venue= "The Crocodile"},    /// 12
                new EventVenue() {Venue= "Charles Smith Wineries Jet City"},    /// 13
                new EventVenue() {Venue= "University of Washington"},    /// 14
                new EventVenue() {Venue= "National Nordic Museum"},   /// 15
                new EventVenue() {Venue= "Princi Bakery"},   /// 16
                new EventVenue() {Venue= "Nectar Lounge"},   /// 17
                new EventVenue() {Venue= "Creative Learning Center"},    ///18
                new EventVenue() {Venue= "Edmonds Center for the Arts"},  ///19
                new EventVenue() {Venue= "Lake Sammamish State Park"},    ///20
                new EventVenue() {Venue= "Karma Wineyards"},//21


            };
        }
       
        
        private static IEnumerable<EventCategory> GetPreconfiguredEventCategories()
        {
            return new List<EventCategory>
            {
                new EventCategory() {Category = "Music"},     /// Id = 1
                new EventCategory() {Category = "Food & Drink" },   /// Id = 2
                new EventCategory() {Category = "Seminars" },      /// Id = 3
                new EventCategory() {Category = "Film & Media"},   /// Id = 4
                new EventCategory() {Category = "Kids" },   /// Id = 5
                new EventCategory() {Category = "Other"}   /// Id = 6

            };
        }


    }
}
