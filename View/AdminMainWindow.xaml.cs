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
        public AdminMainWindow(User currentUser)
        {
            InitializeComponent();
            DataContext = this;
            CurrentUser = currentUser;
            hotelRepository = new HotelRepository();
            _hotelDTOs = new ObservableCollection<HotelDTO>();
            SelectedHotel = new HotelDTO();
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

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
