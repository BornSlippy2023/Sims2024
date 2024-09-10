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
    public partial class GuestMainWindow : Window, INotifyPropertyChanged
    {
        private HotelRepository hotelRepository;
        public ObservableCollection<HotelDTO> _hotelDTOs { get; set; }
        private User CurrentUser { get; set; }
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
                    ApplyFilter(); // Call ApplyFilter directly
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
                    ApplyFilter(); // Call ApplyFilter directly
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
                    ApplyFilter(); // Call ApplyFilter directly
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
                    ApplyFilter(); // Call ApplyFilter directly
                }
            }
        }

        public GuestMainWindow(User currentUser)
        {
            InitializeComponent();
            DataContext = this;
            CurrentUser = currentUser;
            hotelRepository = new HotelRepository();
            _hotelDTOs = new ObservableCollection<HotelDTO>();
            SelectedHotel = new HotelDTO();
            SelectedHotel.Id = "-1";

            _searchName = string.Empty;
            _searchId = string.Empty;
            _searchStars = "0";
            _searchYear = "0";
            ApplyFilter(); // Initialize the filter
        }

        private void ApplyFilters_Click(object sender, RoutedEventArgs e)
        {
            ApplyFilter();
        }

        private void ApplyFilter()
        {
            try
            {
                string searchId = SearchId.ToLower();
                string searchName = SearchName.ToLower();
                int searchYears = Int32.Parse(SearchYear);
                int searchStars = Int32.Parse(SearchStars);

                var filteredHotels = hotelRepository.GetAll().Select(h => new HotelDTO(h)).Where(a =>
                    (string.IsNullOrEmpty(searchId) || a.Id.ToLower().Contains(searchId)) &&
                    (string.IsNullOrEmpty(searchName) || a.Name.ToLower().Contains(searchName)) &&
                    (searchYears == 0 || searchYears == a.YearOpened) &&
                    (searchStars == 0 || searchStars == a.Stars)
                    ).ToList();

                _hotelDTOs.Clear();
                foreach (var accommodation in filteredHotels)
                {
                    _hotelDTOs.Add(accommodation);
                }
            }
            catch
            {
                MessageBox.Show("Wrong values in search");
            }
        }

        private void MakeReservation_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedHotel.Id == "-1")
            {
                MessageBox.Show("Select hotel first");
            }
            else
            {
                MakeReservationPage reservationView = new MakeReservationPage(CurrentUser, SelectedHotel);
                reservationView.Show();
            }
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
