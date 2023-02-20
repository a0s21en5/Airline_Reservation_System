using Airline_Reservation_System.Models;
using System.Collections.Generic;

namespace Airline_Reservation_System.Repository
{
    public interface IPlainRepository
    {
        bool AddPlain(Plain plain);
        Plain checkEdit(int id);
        bool Delete(int id);
        Plain Details(int id);
        bool Edit(Plain plain);
        List<Plain> GetAllPlain();

        Plain GetPlainByName(string name);
    }
}
