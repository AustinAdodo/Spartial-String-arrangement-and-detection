﻿//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Spartial_String_arrangement_and_detection
//{
//    internal class Invoice
//    {
//    }

//    public class Subscription
//    {
//        public Subscription() { }
//        public Subscription(int id, int customerId, int monthlyPriceInDollars)
//        {
//            this.Id = id;
//            this.CustomerId = customerId;
//            this.MonthlyPriceInDollars = monthlyPriceInDollars;
//        }

//        public int Id;
//        public int CustomerId;
//        public int MonthlyPriceInDollars;
//    }

//    public class User
//    {
//        public User() { }
//        public User(int id, string name, DateTime activatedOn, DateTime deactivatedOn, int customerId)
//        {
//            this.Id = id;
//            this.Name = name;
//            this.ActivatedOn = activatedOn;
//            this.DeactivatedOn = deactivatedOn;
//            this.CustomerId = customerId;
//        }

//        public int Id;
//        public string Name;
//        public DateTime ActivatedOn;
//        public DateTime DeactivatedOn;
//        public int CustomerId;
//    }

//    public class Challenge
//    {
//        /// Computes the monthly charge for a given subscription.
//        ///
//        /// @returns The total monthly bill for the customer in dollars and cents, rounded to two decimal places.
//        /// If there are no active users or the subscription is null, returns 0.
//        ///
//        /// @param month - Always present
//        ///   Has the following structure:
//        ///   "2022-04"  // April 2022 in YYYY-MM format
//        ///
//        /// @param activeSubscription - May be null
//        ///   If present, has the following structure (see Subscription class):
//        ///   {
//        ///     Id: 763,
//        ///     CustomerId: 328,
//        ///     MonthlyPriceInDollars: 4  // price per active user per month
//        ///   }
//        ///
//        /// @param users - May be empty, but not null
//        ///   Has the following structure (see User class):
//        ///   [
//        ///     {
//        ///       Id: 1,
//        ///       Name: "Employee #1",
//        ///       CustomerId: 1,
//        ///
//        ///       // when this user started
//        ///       ActivatedOn: new Date("2021-11-04"),
//        ///
//        ///       // last day to bill for user
//        ///       // should bill up to and including this date
//        ///       // since user had some access on this date
//        ///       DeactivatedOn: new Date("2022-04-10")
//        ///     },
//        ///     {
//        ///       Id: 2,
//        ///       Name: "Employee #2",
//        ///       CustomerId: 1,
//        ///
//        ///       // when this user started
//        ///       ActivatedOn: new Date("2021-12-04"),
//        ///
//        ///       // hasn't been deactivated yet
//        ///       DeactivatedOn: DateTime.MaxValue
//        ///     },
//        ///   ]

//        public static Decimal BillFor(string month, Subscription activeSubscription, User[] users)
//        {
//            //get all list of users for this subsription to fit in a 2 dimensional array 
//            List<User> UsersHere = users.Where(a => a.CustomerId == activeSubscription.CustomerId).ToList();

//            //get 2 dmesional array to hold result.
//            List<List<decimal>> resultarray = new List<List<decimal>>();

//            //Dictionary for months and number of days
//            Dictionary<string, int> monthDays = new Dictionary<string, int>()
//{
//    { "01", 31 },
//    { "02", 28 },
//    { "03", 31 },
//    { "04", 30 },
//    { "05", 31 },
//    { "06", 30 },
//    { "07", 31 },
//    { "08", 31 },
//    { "09", 30 },
//    { "10", 31 },
//    { "11", 30 },
//    { "12", 31 }
//};
//            //var firstDayfortheMonth = firstDayfortheMonth();

//            //case users for this subscription is null
//            if (UsersHere.Count == 0) return 0;

//            //calculate subsription on or before last days of month.
//            //perform null check for every user
//            foreach (var user in UsersHere)
//            {
//                if(user != null && monthDays.Keys.Contains( user.DeactivatedOn.ToString()))
//            }
           
//            //retrieve customer ID for this current query set.
//            int CustomerID = activeSubscription.CustomerId;

//            //calculate total charge for the month for a partcular customer.
//            decimal totalChargeformonth = 0;

//            //compensate for Leap years where February has 29 days.

//            return totalChargeformonth;
//        }

//        /*******************
//        * Helper functions *
//        *******************/

//        /**
//        Takes a DateTime object and returns a DateTime which is the first day
//        of that month. For example:

//        FirstDayOfMonth(new DateTime(2019, 2, 7)) // => new DateTime(2019, 2, 1)
//        **/
//        private static DateTime FirstDayOfMonth(DateTime date)
//        {
//            return new DateTime(date.Year, date.Month, 1);
//        }

//        /**
//        Takes a DateTime object and returns a DateTime which is the last day
//        of that month. For example:

//        LastDayOfMonth(new DateTime(2019, 2, 7)) // => new DateTime(2019, 2, 28)
//        **/
//        private static DateTime LastDayOfMonth(DateTime date)
//        {
//            return new DateTime(date.Year, date.Month, DateTime.DaysInMonth(date.Year, date.Month));
//        }

//        /**
//        Takes a DateTime object and returns a DateTime which is the next day.
//        For example:

//        NextDay(new DateTime(2019, 2, 7))  // => new DateTime(2019, 2, 8)
//        NextDay(new DateTime(2019, 2, 28)) // => new DateTime(2019, 3, 1)
//        **/
//        private static DateTime NextDay(DateTime date)
//        {
//            return date.AddDays(1);
//        }
//    }

//}
