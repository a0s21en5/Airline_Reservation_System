using User_API_for_Airline_Reservation_System.Exception;
using User_API_for_Airline_Reservation_System.Models;
using User_API_for_Airline_Reservation_System.Repository;

namespace User_API_for_Airline_Reservation_System.Service
{
    public class UserService : IUserService
    {
        readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        //Get All User
        public List<User> GetAllUser()
        {
            return _userRepository.GetAllUser();
        }

        //Add User
        public bool AddUser(User user)
        {
            User UserAddExistStatus = _userRepository.GetUserByName(user.Name);
            if (UserAddExistStatus == null)
            {
                _userRepository.AddUser(user);
            }
            return true;
        }

        //Delete User
        public bool Delete(int id)
        {
            var UserDeleteExistsStatus = _userRepository.GetUserById(id);
            if (UserDeleteExistsStatus != null)
            {
                _userRepository.Delete(id);
            }
            return true;
        }

        //Details User
        public User Details(int id)
        {
            return _userRepository.Details(id);
        }

        //Login User
        public User Login(UserLogin userLogin)
        {
            User user = _userRepository.Login(userLogin);
            if (user != null)
            {
                return user;
            }
            else
            {
                throw new UserCredentialsInvalidException($"{userLogin.Email} and Password are Invalid!!");
            }
        }

        //GetUserById
        public User GetUserById(int id)
        {
            return _userRepository.GetUserById(id);
        }

        //EditUser
        public bool EditUser(int id, User user)
        {
            user.Id = id;
            int UserEditStatus = _userRepository.EditUser(user);
            if (UserEditStatus == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
