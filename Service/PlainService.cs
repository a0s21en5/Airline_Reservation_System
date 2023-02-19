using Airline_Reservation_System.Models;
using Airline_Reservation_System.Repository;
using System.Collections.Generic;

namespace Airline_Reservation_System.Service
{
    public class PlainService: IPlainService
    {
        readonly IPlainRepository _plainRepository;
        public PlainService(IPlainRepository plainRepository)
        {
            _plainRepository = plainRepository;
        }

        //Show All Plain
        public List<Plain> GetAllPlain()
        {
            return _plainRepository.GetAllPlain();
        }

        //AddPlain
        public bool AddPlain(Plain plain)
        {
            var PlainExistsStatus = _plainRepository.GetPlainByName(plain.plainName);
            if (PlainExistsStatus == null)
            {
                _plainRepository.AddPlain(plain);
            }
            return false;
        }
        public Plain checkEdit(int id)
        {
            return _plainRepository.checkEdit(id);
        }

        public bool Edit(Plain plain)
        {
            return _plainRepository.Edit(plain);
        }


        public bool Delete(int id)
        {
            return _plainRepository.Delete(id);
        }

        public Plain Details(int id)
        {
            return _plainRepository.Details(id);
        }
    }
}
