using Plane_API_for_Airline_Reservation_System.Models;

namespace Plane_API_for_Airline_Reservation_System.Repository
{
    public interface IPlaneRepository
    {
        void AddPlain(Plain plain);
        void Delete(int id);
        Plain Details(int id);
        int EditPlain(Plain plain);
        List<Plain> GetAllPlain();
        Plain GetPlainById(int id);
        Plain GetPlainByName(string name);
        List<Plain> GetPlainBySourceToDestination(string source, string destination);
    }
}
