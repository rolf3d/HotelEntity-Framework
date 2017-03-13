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
                                    join r in db.Rooms on hr.Hotel_No equals r.Room_No into HotelRoomGroup
                                    select new { HotelNavn = r., Products = HotelRoomGroup };

                //test kode
                var innerGroupJoinQuery =
               from category in categories 
               join prod in products on category.ID equals prod.CategoryID into prodGroup
               select new { CategoryName = category.Name, Products = prodGroup };

            }







            Console.ReadLine();
        }
    }
}
