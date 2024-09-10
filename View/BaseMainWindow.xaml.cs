using BookingApp.DTO;
using BookingApp.Repository;
using BookingApp.Model;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;

namespace BookingApp.View
{
    public partial class BaseMainWindow : Window, INotifyPropertyChanged
    {
        protected HotelRepository hotelRepository;
        public ObservableCollection<HotelDTO> _hotelDTOs { get; set; }
        protected User CurrentUser { get; set; }
        public HotelDTO SelectedHotel { get; set; }

        private string _searchName;
        public string SearchName
        {
            get { return _searchName; }
            set
            {
                if (_searchName != value)
                {
                    _searchName = value;
                    OnPropertyChanged();
                    UpdateHotels();
                }
            }
        }

        private string _searchStars;
        public string SearchStars
        {
            get { return _searchStars; }
            set
            {
                if (_searchStars != value)
                {
                    _searchStars = value;
                    OnPropertyChanged();
                    UpdateHotels();
                }
            }
        }

        private string _searchId;
        public string SearchId
        {
            get { return _searchId; }
            set
            {
                if (_searchId != value)
                {
                    _searchId = value;
                    OnPropertyChanged();
                    UpdateHotels();
                }
            }
        }

        private string _searchYear;
        public string SearchYear
        {
            get { return _searchYear; }
            set
            {
                if (_searchYear != value)
                {
                    _searchYear = value;
                    OnPropertyChanged();
                    UpdateHotels();
                }
            }
        }

        public BaseMainWindow()
        {
            InitializeComponent();
            DataContext = this;
            hotelRepository = new HotelRepository();
            _hotelDTOs = new ObservableCollection<HotelDTO>();
            SelectedHotel = new HotelDTO();

            // Initialize filters with default values
            _searchName = string.Empty;
            _searchId = string.Empty;
            _searchStars = "0";
            _searchYear = "0";

            UpdateHotels();
        }

        // Updates the ObservableCollection of hotels by fetching data and applying filters
        public void UpdateHotels()
        {
            _hotelDTOs.Clear();
            foreach (Hotel hotel in hotelRepository.GetAll())
            {
                _hotelDTOs.Add(new HotelDTO(hotel));
            }
            ApplyFilter();
        }

        // Applies the filter based on search criteria
        protected void ApplyFilter()
        {
            try
            {
                string searchId = SearchId.ToLower();
                string searchName = SearchName.ToLower();
                int searchYear = int.Parse(SearchYear);
                int searchStars = int.Parse(SearchStars);

                var filteredHotels = _hotelDTOs.Where(hotel =>
                    (string.IsNullOrEmpty(searchId) || hotel.Id.ToLower().Contains(searchId)) &&
                    (string.IsNullOrEmpty(searchName) || hotel.Name.ToLower().Contains(searchName)) &&
                    (searchYear == 0 || searchYear == hotel.YearOpened) &&
                    (searchStars == 0 || searchStars == hotel.Stars)
                ).ToList();

                _hotelDTOs.Clear();
                foreach (var hotel in filteredHotels)
                {
                    _hotelDTOs.Add(hotel);
                }
            }
            catch
            {
                MessageBox.Show("Invalid search criteria. Please check your input.");
            }
        }

        // Event handler for when search filters are updated (could be invoked by role-specific windows)
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
