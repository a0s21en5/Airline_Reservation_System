using Airline_Reservation_System.Context;
using Airline_Reservation_System.Models;
using System.Collections.Generic;
using System.Linq;

namespace Airline_Reservation_System.Repository
{
    public class PlainRepository: IPlainRepository
    {
        readonly AirlineReservationSystemContextDb _airlineReservationSystemContextDb;
        public PlainRepository(AirlineReservationSystemContextDb airlineReservationSystemContextDb)
        {
            _airlineReservationSystemContextDb = airlineReservationSystemContextDb;
        }

        //Show All Plain
        public List<Plain> GetAllPlain()
        {
            return _airlineReservationSystemContextDb.plains.ToList();  
        }

        //AddPlain
        public bool AddPlain(Plain plain)
        {
            _airlineReservationSystemContextDb.plains.Add(plain);
            return _airlineReservationSystemContextDb.SaveChanges() == 1 ? true : false;
        }

        //GetPlainByName
        public Plain GetPlainByName(string name)
        {
            return _airlineReservationSystemContextDb.plains.Where(p => p.plainName == name).FirstOrDefault();
        }

        //checkEdit
        public Plain checkEdit(int id)
        {
            return _airlineReservationSystemContextDb.plains.Where(p => p.plainId == id).FirstOrDefault();
        }

        //Edit
        public bool Edit(Plain plain)
        {
            Plain editPlain = GetPlainById(plain.plainId);
            editPlain.plainName = plain.plainName;
            editPlain.Source = plain.Source;
            editPlain.Destination = plain.Destination;
            return _airlineReservationSystemContextDb.SaveChanges() == 1 ? true : false;
        }

        private Plain GetPlainById(int id)
        {
            return _airlineReservationSystemContextDb.plains.Where(p => p.plainId == id).FirstOrDefault();
        }

        public bool Delete(int id)
        {
            _airlineReservationSystemContextDb.plains.Remove(GetPlainById(id));
            return _airlineReservationSystemContextDb.SaveChanges() == 1 ? false : true;
        }

        public Plain Details(int id)
        {
            Plain searchPlain = GetPlainById(id);
            return searchPlain;
        }
    }
}
