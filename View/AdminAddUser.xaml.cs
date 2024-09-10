using BookingApp.DTO;
using BookingApp.Model;
using BookingApp.Repository;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;

namespace BookingApp.View
{
    public partial class AdminAddUser : Window, INotifyPropertyChanged
    {
        private UserDTO _userDTO;
        private UserRepository _userRepository;

        public AdminAddUser()
        {
            InitializeComponent();
            _userDTO = new UserDTO(); // Initialize the DTO
            DataContext = _userDTO; // Set DataContext to the DTO
            _userRepository = new UserRepository(); // Initialize the repository
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            var passwordBox = sender as PasswordBox;
            if (passwordBox != null)
            {
                _userDTO.Password = passwordBox.Password;
            }
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            var user = _userDTO.ToUser();

            // Check if a user with the same ID or email already exists
            var existingUserById = _userRepository.GetById(user.Id);
            var existingUserByEmail = _userRepository.GetByEmail(user.Email);

            if (existingUserById != null)
            {
                MessageBox.Show("A user with this ID already exists.");
                return;
            }

            if (existingUserByEmail != null)
            {
                MessageBox.Show("A user with this email already exists.");
                return;
            }

            // Save the new user if no duplicates are found
            _userRepository.Save(user);
            MessageBox.Show($"User {user.FirstName} {user.LastName} added successfully!");
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

