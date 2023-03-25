using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using User_API_for_Airline_Reservation_System.Exception;
using User_API_for_Airline_Reservation_System.Models;
using User_API_for_Airline_Reservation_System.Service;

namespace User_API_for_Airline_Reservation_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        readonly IUserService _userService;
        readonly ITokenGenerator _tokenGenerator;
        public UserController(IUserService userService, ITokenGenerator tokenGenerator)
        {
            _userService = userService;
            _tokenGenerator = tokenGenerator;
        }

        //Get All User
        [Route("GetAllUser")]
        [HttpGet]
        public ActionResult GetAllUser()
        {
            List<User> AllUser = _userService.GetAllUser();
            return Ok(AllUser);
        }

        //Add User
        [Route("AddUser")]
        [HttpPost]
        public ActionResult RegisterUser(User user)
        {
            bool addUserStatus = _userService.AddUser(user);
            return Created("addUserStatus", addUserStatus);
        }

        //Delete User
        [Route("DeleteUser")]
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            bool deleteUserStatus = _userService.Delete(id);
            return Ok(deleteUserStatus);
        }

        //Details
        [Route("DetailsUser")]
        [HttpGet]
        public ActionResult Details(int id)
        {
            User detailsUserStatus = _userService.Details(id);
            return Ok(detailsUserStatus);
        }

        //Edit
        [Route("EditUser/{id:int}")]
        [HttpPut]
        public ActionResult EditUser(int id, User user)
        {
            bool editUserStatus = _userService.EditUser(id, user);
            return Ok(editUserStatus);
        }

        //GetUserById
        [Route("GetUserById/{id:int}")]
        [HttpGet]
        public ActionResult GetUserById(int id)
        {
            User user = _userService.GetUserById(id);
            return Ok(user);
        }

        //Login
        [Route("Login")]
        [HttpPost]
        public ActionResult Login(UserLogin userLogin)
        {
            try
            {
                User user = _userService.Login(userLogin);
                string userToken = _tokenGenerator.GenerateToken(user.Id, user.Name, user.Role);
                return Ok(userToken);
            }
            catch (UserCredentialsInvalidException uaex)
            {
                return StatusCode(500, uaex.Message);
            }
        }
    }
}