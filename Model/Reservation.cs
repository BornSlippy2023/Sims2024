using BookingApp.Serializer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Model
{
    public class Reservation : ISerializable
    {

        public int ReservationId { get; set; }
        public int HotelId { get; set; }
        public int UserId { get; set; }
        public DateOnly ReservationDate { get; set; }

        public Reservation() { }
        public Reservation(int reservationId, int hotelId, int userId, DateOnly reservationDate)
        {
            ReservationId = reservationId;
            HotelId = hotelId;
            UserId = userId;
            ReservationDate = reservationDate;
        }

        public void FromCSV(string[] values)
        {
            ReservationId = Convert.ToInt32(values[0]);
            HotelId = Convert.ToInt32(values[1]);
            UserId = Convert.ToInt32(values[2]);
            ReservationDate = DateOnly.ParseExact(values[3], "dd-MMM-yy", null);
        }

        public string[] ToCSV()
        {
            string[] csvValues = { ReservationId.ToString(), HotelId.ToString(), UserId.ToString(), ReservationDate.ToString("dd-MMM-yy")};

            return csvValues;
        }
    }
}
