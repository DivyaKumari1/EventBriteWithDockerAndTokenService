using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserAPI.Domain;

namespace UserAPI.Data
{
    public static class UserSeed
    {
        public static void Seed(UserContext context)
        {
            context.Database.Migrate();

            if (!context.UserPermissions.Any())
            {
                context.UserPermissions.AddRange(GetPreconfiguredPermissions());
                context.SaveChanges();
            }
            if (!context.UserInformation.Any())
            {
                context.UserInformation.AddRange(GetPreconfiguredUserInformation());
                context.SaveChanges();
            }

        }

        private static IEnumerable<UserInformation> GetPreconfiguredUserInformation()
        {
            return new List<UserInformation>() {

                new UserInformation() {FirstName="Thor",LastName="Odinson",UserName="thundergod",Password="admin",Email="godOfThunder@avengers.com",Organization="ADMIN",PhoneNumber=42512312345,BillingAddress="Private Miltary Base, WA",CreditCardNumber=1200130014001500,CVV=100,PermissionId=1},
                new UserInformation() {FirstName="Steve",LastName="Rogers",UserName="capamerica",Password="admin",Email="captainAmerica@avengers.com",Organization="ADMIN",PhoneNumber=42512312345,BillingAddress="Private Miltary Base, CA",CreditCardNumber=1200130014001500,CVV=100,PermissionId=1},
                new UserInformation() {FirstName="Admin",LastName="User",UserName="admin",Password="admin",Email="ADMIN@avengers.com",Organization="ADMIN",PhoneNumber=42512312345,BillingAddress="ADMIN",CreditCardNumber=1200130014001500,CVV=100,PermissionId=1},
                new UserInformation() {FirstName="Tony",LastName="Stark",UserName="ironman",Password="host",Email="tonystark@avengers.com",Organization="HOST",PhoneNumber=42512312345,BillingAddress="Private Miltary Base, USA",CreditCardNumber=1200130014001500,CVV=100,PermissionId=2},
                new UserInformation() {FirstName="Carol",LastName="Danvers",UserName="capmarval",Password="host",Email="captainMarval@avengers.com",Organization="HOST",PhoneNumber=42512312345,BillingAddress="spacestation,Planet",CreditCardNumber=1200130014001500,CVV=100,PermissionId=2},
                new UserInformation() {FirstName="Host",LastName="User",UserName="host",Password="host",Email="host@avengers.com",Organization="HOST",PhoneNumber=42512312345,BillingAddress="host",CreditCardNumber=1200130014001500,CVV=100,PermissionId=2},
                new UserInformation() {FirstName="Flora",LastName="colossus",UserName="groot",Password="host",Email="iamgroot@avengers.com",Organization="GENERAL",PhoneNumber=42512312345,BillingAddress="Planet X",CreditCardNumber=1200130014001500,CVV=100,PermissionId=3},
                new UserInformation() {FirstName="Scott",LastName="Lang",UserName="antman",Password="general",Email="antman@avengers.com",Organization="GENERAL",PhoneNumber=42512312345,BillingAddress="Michigan USA",CreditCardNumber=1200130014001500,CVV=100,PermissionId=3},
                new UserInformation() {FirstName="Bruce",LastName="Banner",UserName="hulk",Password="general",Email="hulk@avengers.com",Organization="GENERAL",PhoneNumber=42512312345,BillingAddress="Private home, Maui, Hawaii",CreditCardNumber=1200130014001500,CVV=100,PermissionId=3},
                new UserInformation() {FirstName="General",LastName="User",UserName="general",Password="general",Email="general@avengers.com",Organization="GENERAL",PhoneNumber=42512312345,BillingAddress="General",CreditCardNumber=1200130014001500,CVV=100,PermissionId=3},
                new UserInformation() {FirstName="Thanos",LastName="Titan",UserName="thanos",Password="disabled",Email="thanos@avengers.com",Organization="DISABLED",PhoneNumber=42512312345,BillingAddress="Planet Saturn moon",CreditCardNumber=1200130014001500,CVV=100,PermissionId=4},
                new UserInformation() {FirstName="Invalid",LastName="user",UserName="disabled",Password="disabled",Email="disabled@avengers.com",Organization="DISABLED",PhoneNumber=42512312345,BillingAddress="DISABLED",CreditCardNumber=1200130014001500,CVV=100,PermissionId=4}
           };
        }

        private static IEnumerable<Permissions> GetPreconfiguredPermissions()
        {
            return new List<Permissions>()
            {
                new Permissions(){ Type="Admin",Description="Admin permission to a User will enable the user to have a full control of add/edit/delete on all the users/events of the application" },
                new Permissions(){ Type="Host",Description="Host User is can create his events or enable or disable his events" },
                new Permissions(){ Type="General",Description=" General user can just view events and buy tickets for the event" },
                new Permissions(){ Type="Invalid",Description="When the Permission Level of the user is set to Invalid. That means he is not a valid user to this system" }
            };
        }
    }
}
