﻿using Airline_Reservation_System.Models;
using Airline_Reservation_System.Repository;
using System.Collections.Generic;

namespace Airline_Reservation_System.Service
{
    public class UserService : IUserService
    {
        readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        //Show All User
        public List<User> GetAllUser()
        {
            return _userRepository.GetAllUser();
        }

        //Add User
        public bool AddUser(User user)
        {
            var UserExist = _userRepository.GetUserByName(user.userName);
            if (UserExist == null)
            {
                _userRepository.AddUser(user);
            }
            return false;
        }

        //Delete User
        public bool Delete(int id)
        {
            var UserExistsStatus = _userRepository.GetUserById(id);
            if (UserExistsStatus != null)
            {
                _userRepository.Delete(id);
            }
            return false;
        }

        public void Edit(User user)
        {
            _userRepository.Edit(user);
        }

        public User checkEdit(int id)
        {
            return _userRepository.checkEdit(id);
        }

        public User Details(int id)
        {
            return _userRepository.Details(id);
        }
    }
}
