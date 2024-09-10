using BookingApp.Model;
using System.Collections.Generic;
using System.ComponentModel;

namespace BookingApp.DTO
{
    public class HotelDTO : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private string id;
        public string Id
        {
            get { return id; }
            set
            {
                if (id != value)
                {
                    id = value;
                    OnPropertyChanged(nameof(Id));
                }
            }
        }

        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                if (name != value)
                {
                    name = value;
                    OnPropertyChanged(nameof(Name));
                }
            }
        }

        private int yearOpened;
        public int YearOpened
        {
            get { return yearOpened; }
            set
            {
                if (yearOpened != value)
                {
                    yearOpened = value;
                    OnPropertyChanged(nameof(YearOpened));
                }
            }
        }

        private int stars;
        public int Stars
        {
            get { return stars; }
            set
            {
                if (stars != value)
                {
                    stars = value;
                    OnPropertyChanged(nameof(Stars));
                }
            }
        }

        private string ownerJmbg;
        public string OwnerJmbg
        {
            get { return ownerJmbg; }
            set
            {
                if (ownerJmbg != value)
                {
                    ownerJmbg = value;
                    OnPropertyChanged(nameof(OwnerJmbg));
                }
            }
        }

        private Dictionary<int, ApartmentDTO> apartments;
        public Dictionary<int, ApartmentDTO> Apartments
        {
            get { return apartments; }
            set
            {
                if (apartments != value)
                {
                    apartments = value;
                    OnPropertyChanged(nameof(Apartments));
                }
            }
        }

        public HotelDTO(Hotel hotel)
        {
            Id = hotel.Id;
            Name = hotel.Name;
            YearOpened = hotel.YearOpened;
            Stars = hotel.Stars;
            OwnerJmbg = hotel.OwnerJmbg;

            Apartments = new Dictionary<int, ApartmentDTO>();
            if (hotel.Apartments != null)
            {
                foreach (var apartment in hotel.Apartments)
                {
                    Apartments.Add(apartment.Key, new ApartmentDTO(apartment.Value));
                }
            }
        }

        public HotelDTO() { }

        public Hotel ToHotel()
        {
            Dictionary<int, Apartment> apartments = new Dictionary<int, Apartment>();
            foreach (var apartmentDTO in Apartments)
            {
                apartments.Add(apartmentDTO.Key, apartmentDTO.Value.ToApartment());
            }

            return new Hotel(Id, Name, YearOpened, apartments, Stars, OwnerJmbg);
        }

        protected virtual void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
