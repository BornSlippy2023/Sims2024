using BookingApp.Model;
using BookingApp.Serializer;
using System.Collections.Generic;
using System.Linq;

namespace BookingApp.Repository
{
    public class HotelRepository
    {
        private const string FilePath = "../../../Resources/Data/hotels.csv";
        private readonly Serializer<Hotel> _serializer;
        private List<Hotel> _hotels;

        public HotelRepository()
        {
            _serializer = new Serializer<Hotel>();
            _hotels = _serializer.FromCSV(FilePath);
        }

        public List<Hotel> GetAll()
        {
            return _serializer.FromCSV(FilePath);
        }

        public Hotel GetById(string id)
        {
            _hotels = _serializer.FromCSV(FilePath);
            return _hotels.FirstOrDefault(h => h.Id == id);
        }

        public Hotel Save(Hotel hotel)
        {
            _hotels = _serializer.FromCSV(FilePath);
            _hotels.Add(hotel);
            _serializer.ToCSV(FilePath, _hotels);
            return hotel;
        }

        public void Delete(Hotel hotel)
        {
            _hotels = _serializer.FromCSV(FilePath);
            Hotel selectedHotel = _hotels.Find(h => h.Id == hotel.Id);
            _hotels.Remove(selectedHotel);
            _serializer.ToCSV(FilePath, _hotels);
        }

        public Hotel Update(Hotel hotel)
        {
            _hotels = _serializer.FromCSV(FilePath);
            Hotel selectedHotel = _hotels.Find(h => h.Id == hotel.Id);
            int index = _hotels.IndexOf(selectedHotel);
            _hotels.Remove(selectedHotel);
            _hotels.Insert(index, hotel);
            _serializer.ToCSV(FilePath, _hotels);
            return hotel;
        }
    }
}
