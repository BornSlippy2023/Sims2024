using BookingApp.Model;
using BookingApp.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace BookingApp.View
{
    public partial class AdminAddHotel : Window, INotifyPropertyChanged
    {
        private Hotel _hotel;
        private HotelRepository _hotelRepository;

        public AdminAddHotel()
        {
            InitializeComponent();
            _hotel = new Hotel(); // Initialize the hotel
            DataContext = _hotel; // Set DataContext to the hotel
            _hotelRepository = new HotelRepository(); // Initialize repository
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            // Check if a hotel with the same Id already exists
            if (_hotelRepository.GetById(_hotel.Id) != null)
            {
                MessageBox.Show("A hotel with the same Id already exists.");
                return;
            }

            // Save the new hotel data
            _hotelRepository.Save(_hotel);
            MessageBox.Show($"Hotel {_hotel.Name} added successfully!");
            this.Close(); // Close the window after submission
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close(); // Close the window
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
