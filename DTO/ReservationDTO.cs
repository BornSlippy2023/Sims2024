using BookingApp.Model;
using System;
using System.ComponentModel;

namespace BookingApp.DTO
{
    public class ReservationDTO : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private int reservationId;
        public int ReservationId
        {
            get { return reservationId; }
            set
            {
                if (reservationId != value)
                {
                    reservationId = value;
                    OnPropertyChanged(nameof(ReservationId));
                }
            }
        }

        private int hotelId;
        public int HotelId
        {
            get { return hotelId; }
            set
            {
                if (hotelId != value)
                {
                    hotelId = value;
                    OnPropertyChanged(nameof(HotelId));
                }
            }
        }

        private int userId;
        public int UserId
        {
            get { return userId; }
            set
            {
                if (userId != value)
                {
                    userId = value;
                    OnPropertyChanged(nameof(UserId));
                }
            }
        }

        private DateOnly reservationDate;
        public DateOnly ReservationDate
        {
            get { return reservationDate; }
            set
            {
                if (reservationDate != value)
                {
                    reservationDate = value;
                    OnPropertyChanged(nameof(ReservationDate));
                }
            }
        }

        public ReservationDTO(Reservation reservation)
        {
            ReservationId = reservation.ReservationId;
            HotelId = reservation.HotelId;
            UserId = reservation.UserId;
            ReservationDate = reservation.ReservationDate;
        }

        public ReservationDTO() { }

        public Reservation ToReservation()
        {
            return new Reservation(ReservationId, HotelId, UserId, ReservationDate);
        }

        protected virtual void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
