using System;
using System.Collections.Generic;
using System.Linq;
using CrowdfundCore.Model;
using CrowdfundCore.Services.Options;

namespace CrowdfundCore.Services
{
    public class UserService
    {
        private readonly Data.CrowdfundDbContext context_;

        public UserService(Data.CrowdfundDbContext context)
        {
            context_ = context ??
                throw new ArgumentException(nameof(context));
        }
        public List<User> Userlist = new List<User>();
        public User AddUser(AddUserOptions options)
        {
            if (options == null) {
                return null;
            }
            if (string.IsNullOrEmpty(options.firstname)) {
                return null;
            }
            if (string.IsNullOrEmpty(options.lastname)) {
                return null;
            }
            if (string.IsNullOrEmpty(options.email)) {
                return null;
            }
            if (string.IsNullOrEmpty(options.phone)) {
                return null;
            }
            var newUser = new User()
            {
                lastname = options.lastname,
                firstname = options.firstname,
                email = options.email,
                phone = options.phone
            };
            var exist = Userlist.Contains(newUser);
            if (exist) {
                return null;
            }
            context_.Add(newUser);
            try {
                context_.SaveChanges();
            } catch (Exception ex) {
                return null;
            }
            return newUser;
        }
        public bool UpdateBackerOptions(int user_id, UpdateUserOptions options)
        {
            if (user_id == null) {
                return false;
            }
            if (options == null) {
                return false;
            }
            var user = Userlist.Find(p => p.id_user == user_id);
            if (user == null) {
                return false;
            }
            if (!string.IsNullOrWhiteSpace(options.firstname)) {
                user.firstname = options.firstname;
            }
            if (!string.IsNullOrWhiteSpace(options.lastname)) {
                user.lastname = options.lastname;
            }
            if (!string.IsNullOrWhiteSpace(options.email)) {
                user.email = options.email;
            }
            if (!string.IsNullOrWhiteSpace(options.phone)) {
                user.phone = options.phone;
            }
            return true;
        }

        public User SearchUserById(int id)
        {
            if (id == null) {
                return null;
            }
            var user = Userlist.Where(p => p.id_user == id).FirstOrDefault();
            return user;
        }
    }
}

