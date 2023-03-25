using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Plane_API_for_Airline_Reservation_System.Models;
using Plane_API_for_Airline_Reservation_System.Service;

namespace Plane_API_for_Airline_Reservation_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class PlaneController : ControllerBase
    {
        readonly IPlaneService _planeService;

        public PlaneController(IPlaneService planeService)
        {
            _planeService = planeService;
        }

        //Get All Plain
        [Route("GetAllPlain")]
        [HttpGet]
        public ActionResult GetAllPlain()
        {
            List<Plain> AllPlane = _planeService.GetAllPlain();
            return Ok(AllPlane);
        }

        //Add Plain
        [Route("AddPlain")]
        [HttpPost]
        public ActionResult AddPlain(Plain plain)
        {
            bool addPlainStatus = _planeService.AddPlain(plain);
            return Created("addPlainStatus", addPlainStatus);
        }

        //Delete Plain
        [Route("Delete")]
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            bool deletePlainStatus = _planeService.Delete(id);
            return Ok(deletePlainStatus);
        }

        //Details Plain
        [Route("DetailsPlain")]
        [HttpGet]
        public ActionResult Details(int id)
        {
            Plain detailsPlainStatus = _planeService.Details(id);
            return Ok(detailsPlainStatus);
        }

        //Edit Plain
        [Route("EditPlain/{id:int}")]
        [HttpPut]
        public ActionResult EditPlain(int id, Plain plain)
        {
            bool editPlainStatus = _planeService.EditPlain(id, plain);
            return Ok(editPlainStatus);
        }

        //GetPlainById
        [Route("GetPlainById/{id:int}")]
        [HttpGet]
        public ActionResult GetPlainById(int id)
        {
            Plain plain = _planeService.GetPlainById(id);
            return Ok(plain);
        }

        //GetPlainBySourceToDestination
        [Route("GetPlainBySourceToDestination")]
        [HttpGet]
        public ActionResult GetPlainBySourceToDestination(string source, string destination)
        {
            List<Plain> SourceToDestinationPlainStatus = _planeService.GetPlainBySourceToDestination(source, destination);
            return Ok(SourceToDestinationPlainStatus);
        }
    }
}
