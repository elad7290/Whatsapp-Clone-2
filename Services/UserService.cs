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
            //delete Meeeeeeee
            if (_users.Count == 0)
            {
                User user = new User() { Username = "Lion", Nickname = "lio", Password = "1" };
                _users.Add(user); 
            }
                    
        }
        public void Add(User user)
        {
            _users.Add(user);
        }
        public void AddChat(string username,Chat chat)
        {
            var user = Get(username);
            if (user == null) { return; }
            if (!user.Chats.ContainsKey(chat))
            {
                user.Chats.Add(chat, new List<Message>());
            }

        }
        public List<Chat>? GetChats(string username)
        {
            User? user = Get(username);
            if (user == null) { return null; }
            return user.Chats.Keys.ToList();
        }

        public Chat? GetChat(string username,string id)
        {

            var chats=GetChats(username);
            if (chats == null) { return null; }
            Chat? chat =chats.Where(c => c.Id == id).FirstOrDefault();
            if (chat == null) { return null; }
            return chat;

        }

        public bool ChatExist(string username, string id)
        {
            return GetChat(username, id) != null;
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



        public void DeleteChat(string username,string id)
        {
            User? user = Get(username);
            if (user == null) { return; }
            var chat = GetChat(username, id);
            if (chat == null) { return; }
            user.Chats.Remove(chat);
        }

        public List<Message>? GetMessages(string username, string id)
        {
            User? user = Get(username);
            if (user == null) { return null; }
            var chat = GetChat(username,id);
            if(chat == null) { return null; }
            return user.Chats[chat];
        }

        public void AddMessage(string username, string id, Message message)
        {
            var user = Get(username);
            if (user == null) { return; }
            var chat = GetChat(username, id);
            if (chat == null) { return; }
            //var maxValueKey = user.Chats.Aggregate((x, y) => x. > y.Key ? x : y).Key;
            int nextId = user.Chats.Values.Max(c => c.Max(m=> m.Id)) + 1;
            message.Id = nextId; 
            user.Chats[chat].Add(message);

        }
    }
}

