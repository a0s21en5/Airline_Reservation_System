using Airline_Reservation_System.Exception;
using Airline_Reservation_System.Models;
using Airline_Reservation_System.Repository;
using System.Collections.Generic;

namespace Airline_Reservation_System.Service
{
    public class UserService: IUserService
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

        //checkEdit
        public User checkEdit(int id)
        {
            return _userRepository.checkEdit(id);
        }

        //Edit
        public void Edit(User user)
        {
            _userRepository.Edit(user);
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

        //Details
        public User Details(int id)
        {
            return _userRepository.Details(id);
        }

        public User Login(UserLogin userLogin)
        {
            User user = _userRepository.Login(userLogin);
            if(user != null)
            {
                return user;
            }
            else
            {
                throw new UserCredentialsInvalidException($"{userLogin.Name} and Password are Invalid!!");
            }
        }

        public List<Plain> UserGetAllPlains()
        {
            return _userRepository.UserGetAllPlains();
        }

        public User FindUser(string userName)
        {
            return _userRepository.GetUserByName(userName);
        }

        public Ticket FindIdFromTicket(int userId, int id)
        {
            return _userRepository.FindIdFromTicket(userId, id);
        }

        public bool BookTicket(Ticket ticket)
        {
            _userRepository.BookTicket(ticket);
            return true;
        }

        public List<Ticket> BookingHistory(int userId)
        {
            return _userRepository.BookingHistory(userId);
        }
    }
}
