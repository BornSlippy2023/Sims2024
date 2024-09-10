using BookingApp.DTO;
using BookingApp.Model;
using BookingApp.Repository;
using System;
using System.Windows;
using System.Windows.Controls;

namespace BookingApp.View
{
    public partial class MakeReservationPage : Window
    {
        private readonly ReservationRepository _reservationRepository;
        private readonly User _currentUser;
        private readonly HotelDTO _selectedHotel;

        public MakeReservationPage(User currentUser, HotelDTO selectedHotel)
        {
            InitializeComponent();
            _reservationRepository = new ReservationRepository();
            _currentUser = currentUser;
            _selectedHotel = selectedHotel;
        }

        private void MakeReservation_Click(object sender, RoutedEventArgs e)
        {
            if (ReservationDatePicker.SelectedDate.HasValue)
            {
                DateOnly reservationDate = DateOnly.FromDateTime(ReservationDatePicker.SelectedDate.Value);
                Reservation reservation = new Reservation
                {
                    ReservationId = _reservationRepository.NextId(), // Assuming you have a method to get the next ID
                    HotelId = Convert.ToInt32(_selectedHotel.Id),
                    UserId = Convert.ToInt32(_currentUser.Id), // Assuming you have a property to get UserId
                    ReservationDate = reservationDate
                };

                try
                {
                    _reservationRepository.Save(reservation);
                    MessageBox.Show("Reservation successfully made!");
                    Close(); // Close the window after successful reservation
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Please select a reservation date.");
            }
        }
    }
}
