using BookingApp.Model;
using System.ComponentModel;

namespace BookingApp.DTO
{
    public class ApartmentDTO : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private int id;
        public int Id
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

        private string description;
        public string Description
        {
            get { return description; }
            set
            {
                if (description != value)
                {
                    description = value;
                    OnPropertyChanged(nameof(Description));
                }
            }
        }

        private int numberOfRooms;
        public int NumberOfRooms
        {
            get { return numberOfRooms; }
            set
            {
                if (numberOfRooms != value)
                {
                    numberOfRooms = value;
                    OnPropertyChanged(nameof(NumberOfRooms));
                }
            }
        }

        private int maxCapacity;
        public int MaxCapacity
        {
            get { return maxCapacity; }
            set
            {
                if (maxCapacity != value)
                {
                    maxCapacity = value;
                    OnPropertyChanged(nameof(MaxCapacity));
                }
            }
        }

        public ApartmentDTO(Apartment apartment)
        {
            Id = apartment.Id;
            Name = apartment.Name;
            Description = apartment.Description;
            NumberOfRooms = apartment.NumberOfRooms;
            MaxCapacity = apartment.MaxCapacity;
        }

        public ApartmentDTO() { }

        public Apartment ToApartment()
        {
            return new Apartment(Id, Name, Description, NumberOfRooms, MaxCapacity);
        }

        protected virtual void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
