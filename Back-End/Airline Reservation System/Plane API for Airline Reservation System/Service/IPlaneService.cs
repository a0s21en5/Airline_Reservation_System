using Plane_API_for_Airline_Reservation_System.Models;

namespace Plane_API_for_Airline_Reservation_System.Service
{
    public interface IPlaneService
    {
        List<Plain> GetAllPlain();
        bool AddPlain(Plain plain);
        bool Delete(int id);
        Plain Details(int id);
        bool EditPlain(int id, Plain plain);
        Plain GetPlainById(int id);
        List<Plain> GetPlainBySourceToDestination(string source, string destination);
    }
}
