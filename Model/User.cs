using BookingApp.Serializer;
using System;
using System.Security.Cryptography.Pkcs;

namespace BookingApp.Model
{
    public enum UserRole { ADMIN, GUEST, OWNER}
    public class User : ISerializable
    {
        public int Id { get; set; }
        public string Jmbg { get; set; }
        public string Email { get; set; }

        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public UserRole Role { get; set; }


        public User() { }

        public User(string jmbg, string email, string password, string firstName, string lastName, string phoneNumber, UserRole role)
        {
            Jmbg = jmbg;
            Email = email;
            Password = password;
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Role = role;
        }

        public User(int id, string jmbg, string email, string password, string firstName, string lastName, string phoneNumber, UserRole role)
        {
            Id = id;
            Jmbg = jmbg;
            Email = email;
            Password = password;
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Role = role;
        }

        public string[] ToCSV()
        {
            string[] csvValues = { Id.ToString(), Jmbg, Email, Password, FirstName, LastName, PhoneNumber, Role.ToString() };
            return csvValues;
        }

        public void FromCSV(string[] values)
        {
            Id = Convert.ToInt32(values[0]);
            Jmbg = values[1];
            Email = values[2];
            Password = values[3];
            FirstName = values[4];
            LastName = values[5];
            PhoneNumber = values[6];
            Role = (UserRole)Convert.ToInt32(values[7]);
        }
    }
}
