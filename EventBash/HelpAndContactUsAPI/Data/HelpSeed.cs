using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelpAndContactUsAPI.Domain;
using Microsoft.EntityFrameworkCore;

namespace HelpAndContactUsAPI.Data
{
    public class HelpSeed
    {
        public static void Seed(HelpContext context)
        {
            context.Database.Migrate();
            if (!context.Helps.Any())
            {
                context.Helps
                    .AddRange(GetPreConfiguredHelps());

                context.SaveChanges();
            }

            if (!context.ContactUs.Any())
            {
                context.ContactUs
                    .AddRange(GetPreConfiguredContactUs());

                context.SaveChanges();
            }
        }

        private static IEnumerable<ContactUS> GetPreConfiguredContactUs()
        {
            return new List<ContactUS>()
            {
                new ContactUS() { PhoneNumber = 123456789  ,EmailId ="customercare@cs.com"}
            };


        }

        private static IEnumerable<Help> GetPreConfiguredHelps()
        {
            return new List<Help>()
            {
                new Help() { Query = "How do I contact Eventbrite?"   , Answer ="Call us at 123-456-789"},
                new Help() { Query = "How do I get a refund from Eventbrite?"   , Answer ="1.Check the event's refund policy 2.Find your order on the tickets page in EventBrite 3.Choose request a Refund"},
                new Help() { Query = "How much does it cost to use Eventbrite?"   , Answer ="Eventbrite's maximum fee per ticket is $20."},
                new Help() { Query = "How long does it take to get refund from  Eventbrite?"   , Answer ="If your refund has been issued, it can take up to 7 business days to show up in your account"},
                new Help() { Query = "Is it free to use Eventbrite?"   , Answer ="It is free for organizers to use Eventbrite if you are not charging for tickets!There are no monthly charges,enrollement costs."},
                new Help() { Query = "Can you cancel tickets on Eventbrite?"   , Answer ="Just log in to Eventbrite, go to tickets page and cancel order"}
              
            };

           
        }
    }
}
