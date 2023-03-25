using Plane_API_for_Airline_Reservation_System.Models;
using Plane_API_for_Airline_Reservation_System.Repository;

namespace Plane_API_for_Airline_Reservation_System.Service
{
    public class PlaneService : IPlaneService
    {
        readonly IPlaneRepository _planeRepository;
        public PlaneService(IPlaneRepository planeRepository)
        {
            _planeRepository = planeRepository;
        }

        //Get All Plain
        public List<Plain> GetAllPlain()
        {
            return _planeRepository.GetAllPlain();
        }

        //Add Course
        public bool AddPlain(Plain plain)
        {
            Plain PlainAddExistStatus = _planeRepository.GetPlainByName(plain.Name);
            if (PlainAddExistStatus == null)
            {
                _planeRepository.AddPlain(plain);
            }
            return true;
        }

        //Plain Delete
        public bool Delete(int id)
        {
            Plain PlainDeleteExistsStatus = _planeRepository.GetPlainById(id);
            if (PlainDeleteExistsStatus != null)
            {
                _planeRepository.Delete(id);
            }
            return true;
        }

        //Plain Details
        public Plain Details(int id)
        {
            return _planeRepository.Details(id);
        }

        //GetPlainById
        public Plain GetPlainById(int id)
        {
            return _planeRepository.GetPlainById(id);
        }

        //Edit Plain
        public bool EditPlain(int id, Plain plain)
        {
            plain.Id = id;
            int PlainEditStatus = _planeRepository.EditPlain(plain);
            if (PlainEditStatus == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Plain> GetPlainBySourceToDestination(string source, string destination)
        {
            return _planeRepository.GetPlainBySourceToDestination(source, destination);
        }

        //GetPlainBySourceToDestination

    }
}
