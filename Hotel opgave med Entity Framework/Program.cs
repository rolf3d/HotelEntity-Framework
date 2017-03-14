using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_opgave_med_Entity_Framework
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new HotelContext())
            {
                //Opgave2_1
                var hotelList = from h in db.Hotels
                                select h;

                //List alle informationer om alle hotellerne 
                Console.WriteLine("List alle informationer om alle hotellerne");
                foreach (var item in hotelList)
                {
                    Console.WriteLine(item.ToString());
                }

                //Opgave2_2 //
                var GuestList = from g in db.Guests
                    select g;
                //List alle informationer om alle kunderne
                Console.WriteLine("List alle informationer om alle kunderne");
                foreach (var itemg in GuestList)
                {
                    Console.WriteLine(itemg.ToString());
                }

                //Opgave3_1
                var HotelAndRooms = from hr in db.Hotels
                    join r in db.Rooms on hr.Hotel_No equals r.Hotel_No
                    select new {hotelnavn = hr.Name,hoteladdress = hr.Address, roompris = r.Price, roomtype = r.Types, Roomnumber = r.Room_No};

                //Ud skriv info om Hotel og info om deres rum
                Console.WriteLine("");
                Console.WriteLine("Ud skriv info om Hotel og info om deres rum");
                foreach (var itemhr in HotelAndRooms)
                {
                    Console.WriteLine("Hotel navn: " + itemhr.hotelnavn + "Address: "+ itemhr.hoteladdress + " Room pris: " +  itemhr.roompris + " Room type: " + itemhr.roomtype + " Room number: " + itemhr.Roomnumber);
                }

                //Opgave3_2
                var HotelAndRoomsAndBookings = from hr in db.Hotels
                                    join r in db.Rooms on hr.Hotel_No equals r.Hotel_No
                                    join b in db.Bookings on r.Room_No equals b.Room_No
                                    orderby hr.Hotel_No
                                    select new { hotelnavn = hr.Name, hoteladdress = hr.Address, roompris = r.Price, roomtype = r.Types, Roomnumber = r.Room_No, bookinginfo = b.Room_No };

                //Ud skriv info om Hotel og info om deres rum
                Console.WriteLine("");
                Console.WriteLine("Ud skriv info om Hotel og info om deres rum");
                foreach (var itemhr in HotelAndRoomsAndBookings)
                {
                    Console.WriteLine("Hotel navn: " + itemhr.hotelnavn + "Address: " + itemhr.hoteladdress + " Room pris: " + itemhr.roompris + " Room type: " + itemhr.roomtype + " Room number: " + itemhr.Roomnumber + " Booking info: " + itemhr.bookinginfo);
                }

                // Opgave 4
                //Guest Rolf = new Guest() {Address = "på vejen",Guest_No = 65,Name = "Rolf Petersen"};

                //db.Guests.Add(Rolf);
                //db.SaveChanges();
                Console.WriteLine("Data indsat");

                foreach (var gæster in GuestList)
                {
                    Console.WriteLine("Alle guest info " + gæster.Guest_No);
                }

                //Booking nybook01 = new Booking();
                //nybook01.Booking_id = 90;
                //nybook01.Hotel_No = 2;
                //nybook01.Guest_No = 65;
                //nybook01.Date_From = new DateTime(2017,03,17);
                //nybook01.Date_To = new DateTime(2017,03,19);
                //nybook01.Room_No = 22;

                //db.Bookings.Add(nybook01);
                //db.SaveChanges();


                //Booking nybook02 = new Booking();
                //nybook02.Booking_id = 91;
                //nybook02.Hotel_No = 2;
                //nybook02.Guest_No = 65;
                //nybook02.Date_From = new DateTime(2017,03,18);
                //nybook02.Date_To = new DateTime(2017,03,19);
                //nybook02.Room_No = 21;

                //db.Bookings.Add(nybook02);
                //db.SaveChanges();




                //test kode
                // var innerGroupJoinQuery =
                //from category in categories 
                //join prod in products on category.ID equals prod.CategoryID into prodGroup
                //select new { CategoryName = category.Name, Products = prodGroup };

            }







            Console.ReadLine();
        }
    }
}
