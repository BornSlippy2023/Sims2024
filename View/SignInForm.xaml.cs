using BookingApp.Model;
using BookingApp.Repository;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace BookingApp.View
{
    /// <summary>
    /// Interaction logic for SignInForm.xaml
    /// </summary>
    public partial class SignInForm : Window
    {

        private readonly UserRepository _repository;

        private string _email;
        public string Email
        {
            get => _email;
            set
            {
                if (value != _email)
                {
                    _email = value;
                    OnPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public SignInForm()
        {
            InitializeComponent();
            DataContext = this;
            _repository = new UserRepository();
        }

        private void SignIn(object sender, RoutedEventArgs e)
        {
            User user = _repository.GetByEmail(Email);
            if (user != null)
            {
                if(user.Password == txtPassword.Password)
                {
                    CheckUserRole(user);
                } 
                else
                {
                    MessageBox.Show("Wrong password!");
                }
            }
            else
            {
                MessageBox.Show("Wrong username!");
            }
            
        }
        /*
        public void CheckUserRole(User user)
        {
            if (user.Role == UserRole.GUEST)
            {
                GuestMainWindow guestMainWindow = new GuestMainWindow(user);
                guestMainWindow.Show();
                Close();
            }
        }
        */

        public void CheckUserRole( User user)
        {
            switch (user.Role)
            {
                case UserRole.GUEST:
                    GuestMainWindow guestMainWindow = new GuestMainWindow(user);
                    guestMainWindow.Show();
                    break;
                case UserRole.ADMIN:
                    AdminMainWindow adminMainWindow = new AdminMainWindow(user);
                    adminMainWindow.Show();
                    break;
                case UserRole.OWNER:
                    OwnerMainWindow ownerMainWindow = new OwnerMainWindow(user);
                    ownerMainWindow.Show();
                    break;
            }
        }
    }
}
