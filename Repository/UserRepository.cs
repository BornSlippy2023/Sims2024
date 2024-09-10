using BookingApp.Model;
using BookingApp.Serializer;
using System.Collections.Generic;
using System.Linq;

namespace BookingApp.Repository
{
    public class UserRepository
    {
        private const string FilePath = "../../../Resources/Data/users.csv";

        private readonly Serializer<User> _serializer;

        private List<User> _users;

        public UserRepository()
        {
            _serializer = new Serializer<User>();
            _users = _serializer.FromCSV(FilePath);
        }

        public User GetByEmail(string email)
        {
            _users = _serializer.FromCSV(FilePath);
            return _users.FirstOrDefault(u => u.Email == email);
        }

        public List<User> GetAll()
        {
            return _serializer.FromCSV(FilePath);
        }

        public User Save(User user)
        {
            user.Id = NextId();
            _users = _serializer.FromCSV(FilePath);
            _users.Add(user);
            _serializer.ToCSV(FilePath, _users);
            return user;
        }

        public int NextId()
        {
            _users = _serializer.FromCSV(FilePath);
            if(_users.Count < 1 )
            {
                return 1;
            }
            return _users.Max(C => C.Id) + 1;
        }

        public void Delete(User user)
        {
            _users = _serializer.FromCSV(FilePath);
            User selectedUser = _users.Find(c =>  c.Id == user.Id);
            _users.Remove(selectedUser);
            _serializer.ToCSV(FilePath, _users);
        }

        public User Update(User user)
        {
            _users = _serializer.FromCSV(FilePath);
            User selectedUser = _users.Find(c => c.Id == user.Id);
            int index = _users.IndexOf(selectedUser);
            _users.Remove(selectedUser);
            _users.Insert(index, user);
            _serializer.ToCSV(FilePath, _users);
            return user;
        }

        public User GetById(int id)
        {
            _users = _serializer.FromCSV(FilePath);
            return _users.FirstOrDefault(u => u.Id == id);
        }
    }
}
