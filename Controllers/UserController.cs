using Airline_Reservation_System.Models;
using Airline_Reservation_System.Service;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Airline_Reservation_System.Controllers
{
    public class UserController : Controller
    {
        readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
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
            if(ModelState.IsValid)
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
    }
}
