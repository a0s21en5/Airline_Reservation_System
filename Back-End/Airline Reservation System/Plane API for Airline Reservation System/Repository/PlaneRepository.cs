using Plane_API_for_Airline_Reservation_System.Context;
using Plane_API_for_Airline_Reservation_System.Models;
using System.Xml.Linq;

namespace Plane_API_for_Airline_Reservation_System.Repository
{
    public class PlaneRepository : IPlaneRepository
    {
        readonly AirlineReservationSystemContextDb _airlineReservationSystemContextDb;
        public PlaneRepository(AirlineReservationSystemContextDb airlineReservationSystemContextDb)
        {
            _airlineReservationSystemContextDb = airlineReservationSystemContextDb;
        }

        //Add Plain
        public void AddPlain(Plain plain)
        {
            _airlineReservationSystemContextDb.Add(plain);
            _airlineReservationSystemContextDb.SaveChanges();
        }

        //Delete Plain
        public void Delete(int id)
        {
            _airlineReservationSystemContextDb.Remove(GetPlainById(id));
            _airlineReservationSystemContextDb.SaveChanges();
        }

        //Details Plain
        public Plain Details(int id)
        {
            Plain searchPlain = GetPlainById(id);
            return searchPlain;
        }

        //EditPlain
        public int EditPlain(Plain plain)
        {
            _airlineReservationSystemContextDb.Entry(plain).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            return _airlineReservationSystemContextDb.SaveChanges();
        }

        //Get All Plain
        public List<Plain> GetAllPlain()
        {
            return _airlineReservationSystemContextDb.plains.ToList();
        }

        //Get Plain By Id
        public Plain GetPlainById(int id)
        {
            return _airlineReservationSystemContextDb.plains.Where(c => c.Id == id).FirstOrDefault();
        }

        //Get Plain By Name
        public Plain GetPlainByName(string name)
        {
            return _airlineReservationSystemContextDb.plains.Where(c => c.Name == name).FirstOrDefault();
        }

        //GetPlainBySourceToDestination
        public List<Plain> GetPlainBySourceToDestination(string source, string destination)
        {
            return _airlineReservationSystemContextDb.plains.Where(c => c.Source == source && c.Destination == destination).ToList();
        }
    }
}
