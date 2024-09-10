using BookingApp.Model;
using BookingApp.Serializer;
using System.Collections.Generic;
using System.Linq;

namespace BookingApp.Repository
{
    public class ReservationRepository
    {
        private const string FilePath = "../../../Resources/Data/reservations.csv";
        private readonly Serializer<Reservation> _serializer;
        private List<Reservation> _reservations;

        public ReservationRepository()
        {
            _serializer = new Serializer<Reservation>();
            _reservations = _serializer.FromCSV(FilePath);
        }

        public List<Reservation> GetAll()
        {
            return _serializer.FromCSV(FilePath);
        }

        public Reservation GetById(int id)
        {
            _reservations = _serializer.FromCSV(FilePath);
            return _reservations.FirstOrDefault(r => r.ReservationId == id);
        }

        public Reservation Save(Reservation reservation)
        {
            reservation.ReservationId = NextId();
            _reservations = _serializer.FromCSV(FilePath);
            _reservations.Add(reservation);
            _serializer.ToCSV(FilePath, _reservations);
            return reservation;
        }

        public int NextId()
        {
            _reservations = _serializer.FromCSV(FilePath);
            if (_reservations.Count < 1)
            {
                return 1;
            }
            return _reservations.Max(r => r.ReservationId) + 1;
        }

        public void Delete(Reservation reservation)
        {
            _reservations = _serializer.FromCSV(FilePath);
            Reservation selectedReservation = _reservations.Find(r => r.ReservationId == reservation.ReservationId);
            if (selectedReservation != null)
            {
                _reservations.Remove(selectedReservation);
                _serializer.ToCSV(FilePath, _reservations);
            }
        }

        public Reservation Update(Reservation reservation)
        {
            _reservations = _serializer.FromCSV(FilePath);
            Reservation selectedReservation = _reservations.Find(r => r.ReservationId == reservation.ReservationId);
            if (selectedReservation != null)
            {
                int index = _reservations.IndexOf(selectedReservation);
                _reservations.Remove(selectedReservation);
                _reservations.Insert(index, reservation);
                _serializer.ToCSV(FilePath, _reservations);
            }
            return reservation;
        }
    }
}
