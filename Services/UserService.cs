using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace Services
{
    public class UserService
    {
        private static List<User> _users;

        public UserService(List<User> users)
        {
            _users = users;
            if (_users.Count == 0)
            {
                User user = new User() { Username = "Lion", Nickname = "lio", Password = "123456789L!" };
                _users.Add(user); 
            }
                    
        }
        public void Add(User user)
        {
            _users.Add(user);
        }

        public void Delete(string username)
        {
            var user = Get(username);
            if (user == null) { return; }
            _users.Remove(user);
        }
        //someone else is changing the details
        public void Edit(User user)
        {
            var u = Get(user.Username);
            if (u == null) { return; }
            u.Nickname = user.Nickname;
            
           
        }

        public User? Get(string? username)
        {
            if (username == null)
            {
                return null;
            }
            var user = _users.FirstOrDefault(u => u.Username == username);
            if (user == null) { return null; }
            return user;
        }

        public List<User> GetAll()
        {
            return _users;
        }

        public bool UserExists(string username,string password)
        {
            return _users.FirstOrDefault(u => u.Username == username && u.Password==password) != null;
        }
    }
}

