using Airline_Reservation_System.Models;
using System.Collections.Generic;

namespace Airline_Reservation_System.Service
{
    public interface IPlainService
    {
        bool AddPlain(Plain plain);
        Plain checkEdit(int id);
        bool Delete(int id);
        Plain Details(int id);
        bool Edit(Plain plain);
        List<Plain> GetAllPlain();
    }
}
