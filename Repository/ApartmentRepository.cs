using BookingApp.Model;
using BookingApp.Serializer;
using System.Collections.Generic;
using System.Linq;

namespace BookingApp.Repository
{
    public class ApartmentRepository
    {
        private const string FilePath = "../../../Resources/Data/apartments.csv";
        private readonly Serializer<Apartment> _serializer;
        private List<Apartment> _apartments;

        public ApartmentRepository()
        {
            _serializer = new Serializer<Apartment>();
            _apartments = _serializer.FromCSV(FilePath);
        }

        public List<Apartment> GetAll()
        {
            return _serializer.FromCSV(FilePath);
        }

        public Apartment GetById(int id)
        {
            _apartments = _serializer.FromCSV(FilePath);
            return _apartments.FirstOrDefault(a => a.Id == id);
        }

        public Apartment Save(Apartment apartment)
        {
            apartment.Id = NextId();
            _apartments = _serializer.FromCSV(FilePath);
            _apartments.Add(apartment);
            _serializer.ToCSV(FilePath, _apartments);
            return apartment;
        }

        public int NextId()
        {
            _apartments = _serializer.FromCSV(FilePath);
            if (_apartments.Count < 1)
            {
                return 1;
            }
            return _apartments.Max(a => a.Id) + 1;
        }

        public void Delete(Apartment apartment)
        {
            _apartments = _serializer.FromCSV(FilePath);
            Apartment selectedApartment = _apartments.Find(a => a.Id == apartment.Id);
            _apartments.Remove(selectedApartment);
            _serializer.ToCSV(FilePath, _apartments);
        }

        public Apartment Update(Apartment apartment)
        {
            _apartments = _serializer.FromCSV(FilePath);
            Apartment selectedApartment = _apartments.Find(a => a.Id == apartment.Id);
            int index = _apartments.IndexOf(selectedApartment);
            _apartments.Remove(selectedApartment);
            _apartments.Insert(index, apartment);
            _serializer.ToCSV(FilePath, _apartments);
            return apartment;
        }
    }
}