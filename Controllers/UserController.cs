using Airline_Reservation_System.Exception;
using Airline_Reservation_System.Models;
using Airline_Reservation_System.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Airline_Reservation_System.Controllers
{
    public class UserController : Controller
    {
        readonly IUserService _userService;
        readonly ITokenGenerator _tokenGenerator;
        public UserController(IUserService userService, ITokenGenerator tokenGenerator)
        {
            _userService = userService;
            _tokenGenerator = tokenGenerator;
        }

        public ActionResult Index()
        {
            return View();
        }

        //Show All User
        public ActionResult GetAllUser()
        {
            List<User> AllUser = _userService.GetAllUser();
            return View(AllUser);
        }

        //Add User
        [HttpGet]
        public ActionResult RegisterUser()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RegisterUser(User user)
        {
            if (ModelState.IsValid)
            {
                bool addUserStatus = _userService.AddUser(user);
                return RedirectToAction("GetAllUser");
            }
            else
            {
                return View(user);
            }
        }

        //Edit User

        [HttpGet]
        public ActionResult Edit(int id)
        {
            User editSearch = _userService.checkEdit(id);
            return View(editSearch);
        }

        [HttpPost]
        public ActionResult Edit(User user)
        {
            _userService.Edit(user);
            return RedirectToAction("GetAllUser");
        }

        //Delete User
        public ActionResult Delete(int id)
        {
            _userService.Delete(id);
            return RedirectToAction("GetAllUser");
        }

        //Details User
        public ActionResult Details(int id)
        {
            User userDetails = _userService.Details(id);
            return View(userDetails);
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserLogin userLogin)
        {
            try
            {
                User user = _userService.Login(userLogin);
                string userToken = _tokenGenerator.GenerateToken(user.userId, user.userName);
                
                HttpContext.Session.SetString("UserToken", userToken);
                HttpContext.Session.SetString("USERNAME", user.userName);

                if (user.Role == "admin")
                {
                    //return RedirectToAction("GetAllPlain", "Plain"); 
                    return RedirectToAction("AdminDashBoard", "Plain");
                }
                else
                {
                    return RedirectToAction("UserDashBoard");
                }

            }
            catch(UserCredentialsInvalidException uaex)
            {
                return StatusCode(500, uaex.Message);
            }
        }

        public ActionResult UserDashBoard()
        {
            return RedirectToAction("UserGetAllPlains");
        }

        public ActionResult UserGetAllPlains()
        {
            List<Plain> allPlains = _userService.UserGetAllPlains();
            return View(allPlains);
        }

        public ActionResult BookTicket(int id)
        {
            var userName = HttpContext.Session.GetString("USERNAME");
            User user = _userService.FindUser(userName);
            Ticket alreadyPresent = _userService.FindIdFromTicket(user.userId, id);

            if (alreadyPresent != null)
            {
                return View(alreadyPresent);
            }
            else
            {
                Ticket ticket = new Ticket()
                {
                    plainId= id,
                    userId= user.userId
                };
                bool status = _userService.BookTicket(ticket);
                if (status)
                {
                    TempData["BookTicket"] = "Ticket Add Successfully";
                    return RedirectToAction("UserDashBoard");
                }
            }
            return RedirectToAction("UserDashBoard");
        }

        public ActionResult BookingHistory()
        {
            var userName = HttpContext.Session.GetString("USERNAME");
            User user = _userService.FindUser(userName);
            List<Ticket> Alltickets = _userService.BookingHistory(user.userId);
            if(Alltickets.Count==0)
            {
                TempData["TicketHistoryNull"] = "Ticket History is Empty";
                ViewData["userName"] = user;
                return View();
            }
            else
            {
                return View(Alltickets);
            }
        }
    }
}
