using Airline_Reservation_System.Models;
using Airline_Reservation_System.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace Airline_Reservation_System.Controllers
{
    //[Authorize]
    public class PlainController : Controller
    {
        readonly IPlainService _plainService;
        readonly ITokenGenerator _tokenGenerator;
        readonly IConfiguration _configuration;
        public PlainController(IPlainService plainService, ITokenGenerator tokenGenerator, IConfiguration configuration)
        {
            _plainService = plainService;
            _tokenGenerator = tokenGenerator;
            _configuration = configuration;
        }

        //Show All Product
        public ActionResult GetAllPlain()
        {
            List<Plain> AllPlain = _plainService.GetAllPlain();
            return View(AllPlain);
        }

        //Add Product
        [HttpGet]
        public ActionResult AddPlain()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddPlain(Plain plain)
        {
            if (ModelState.IsValid)
            {
                bool ProductExistsStatus = _plainService.AddPlain(plain);
                return RedirectToAction("GetAllPlain");
            }
            else
            {
                return View(plain);
            }
        }

        //Edit Product
        [HttpGet]
        public ActionResult Edit(int id)
        {
            Plain editPlain = _plainService.checkEdit(id);
            return View(editPlain);
        }

        [HttpPost]
        public ActionResult Edit(Plain plain)
        {
            _plainService.Edit(plain);
            return RedirectToAction("GetAllPlain");
        }

        //Delete Product
        public ActionResult Delete(int id)
        {
            _plainService.Delete(id);
            return RedirectToAction("GetAllPlain");
        }

        //Details User
        public ActionResult Details(int id)
        {
            Plain plainDetails = _plainService.Details(id);
            return View(plainDetails);
        }

        [Authorize]
        public ActionResult AdminDashBoard()
        {
            var userToken = HttpContext.Session.GetString("userToken");
            if (userToken == null)
            {
                return RedirectToAction("Login","User");
            }
            //audience
            var userSecretKey = _configuration["JwtValidationParameters:UserSecretKey"];
            var userIssuer = _configuration["JwtValidationParameters:UserIssuer"];
            var userAudience = _configuration["JwtValidationParameters:UserAudience"];



            bool isTokenValid = _tokenGenerator.IsTokenValid(userToken, userSecretKey, userIssuer, userAudience);
            if(isTokenValid)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "User");
            }
        }
    }
}
