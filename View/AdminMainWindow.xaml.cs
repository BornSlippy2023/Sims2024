using BookingApp.DTO;
using BookingApp.Repository;
using BookingApp.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Runtime.CompilerServices;

namespace BookingApp.View
{
    /// <summary>
    /// Interaction logic for AdminMainWindow.xaml
    /// </summary>
    public partial class AdminMainWindow : Window, INotifyPropertyChanged
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
                if(_searchName != value)
                {
                    _searchName = value;
                    OnPropertyChanged();
                    Update();
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
                    Update();
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
                    Update();
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
                    Update();
                }
            }
        }




        public AdminMainWindow(User currentUser)
        {
            InitializeComponent();
            DataContext = this;
            CurrentUser = currentUser;
            hotelRepository = new HotelRepository();
            _hotelDTOs = new ObservableCollection<HotelDTO>();
            SelectedHotel = new HotelDTO();

            _searchName = string.Empty;
            _searchId = string.Empty;
            _searchStars = "0";
            _searchYear = "0";
            Update();


        }

        public void Update()
        {
            _hotelDTOs.Clear();
            foreach (Hotel hotel in hotelRepository.GetAll())
            {
                _hotelDTOs.Add(new HotelDTO(hotel));

            }
        }

        private void ApplyFilters_Click(object sender, RoutedEventArgs e)
        {
            ApplyFilter();
        }

        private void AddNewUser_Click(object sender, RoutedEventArgs e)
        {
            AddNewUser();
        }

        private void AddNewHotel_Click(object sender, RoutedEventArgs e)
        {
            AddNewHotel();
        }

        private void AddNewHotel()
        {
            AdminAddHotel adminAddHotel = new AdminAddHotel();
            adminAddHotel.Show();
        }

        private void AddNewUser()
        {
            AdminAddUser aminAddUser = new AdminAddUser();
            aminAddUser.Show();
        }

        private void ApplyFilter()
        {
            try
            {
                string searchId = SearchId.ToLower();
                string searchName = SearchName.ToLower();
                int searchYears = Int32.Parse(SearchYear);
                int searchStars = Int32.Parse(SearchStars);


                var filteredHotels = _hotelDTOs.Where(a =>
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

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
