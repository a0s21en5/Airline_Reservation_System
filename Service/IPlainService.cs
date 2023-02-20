using Airline_Reservation_System.Models;
using System.Collections.Generic;

namespace Airline_Reservation_System.Service
{
    public interface IPlainService
    {
        List<Plain> GetAllPlain();
        bool AddPlain(Plain plain);
        Plain checkEdit(int id);
        bool Edit(Plain plain);

        bool Delete(int id);
        Plain Details(int id);
    }
}
