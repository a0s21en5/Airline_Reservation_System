using System;

namespace Airline_Reservation_System.Exception
{
    public class UserCredentialsInvalidException:ApplicationException
    {
        public UserCredentialsInvalidException()
        {

        }

        public UserCredentialsInvalidException(string msg) : base(msg)
        {

        }
    }
}
