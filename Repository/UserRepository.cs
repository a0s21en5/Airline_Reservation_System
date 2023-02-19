using Airline_Reservation_System.Context;
using Airline_Reservation_System.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Airline_Reservation_System.Repository
{
    public class UserRepository: IUserRepository
    {
        readonly AirlineReservationSystemContextDb _airlineReservationSystemContextDb;
        public UserRepository(AirlineReservationSystemContextDb airlineReservationSystemContextDb)
        {
            _airlineReservationSystemContextDb = airlineReservationSystemContextDb;
        }

        //Show All User
        public List<User> GetAllUser()
        {
            return _airlineReservationSystemContextDb.users.ToList();
        }

        //Add user
        public void AddUser(User user)
        {
            _airlineReservationSystemContextDb.users.Add(user);
            _airlineReservationSystemContextDb.SaveChanges();
        }


        //Get User By Name
        public User GetUserByName(string name)
        {
            return _airlineReservationSystemContextDb.users.Where(u => u.userName == name).FirstOrDefault();
        }

        //checkEdit
        public User checkEdit(int id)
        {
            return _airlineReservationSystemContextDb.users.Where(U => U.userId == id).FirstOrDefault();
        }

        //Edit User
        public void Edit(User user)
        {
            User editSearch = GetUserById(user.userId);
            editSearch.userName = user.userName;
            editSearch.userEmail = user.userEmail;
            editSearch.userPassword = user.userPassword;
            editSearch.userImage = user.userImage;
            _airlineReservationSystemContextDb.SaveChanges();
        }

        //Get User By Id
        public User GetUserById(int id)
        {
            return _airlineReservationSystemContextDb.users.Where(U => U.userId == id).FirstOrDefault();
        }

        //Delete User
        public bool Delete(int id)
        {
            _airlineReservationSystemContextDb.users.Remove(GetUserById(id));
            return _airlineReservationSystemContextDb.SaveChanges() == 1 ? false : true;
        }

        //Details User
        public User Details(int id)
        {
            User searchUser = GetUserById(id);
            return searchUser;
        }

        public User Login(UserLogin userLogin)
        {
            return _airlineReservationSystemContextDb.users.Where(u => u.userName == userLogin.Name && u.userPassword == userLogin.Password).FirstOrDefault();
        }

        public List<Plain> GetAllPlain()
        {
            throw new NotImplementedException();
        }

        public List<Plain> UserGetAllPlains()
        {
            return _airlineReservationSystemContextDb.plains.ToList();
        }

        public Ticket FindIdFromTicket(int userId, int id)
        {
            return _airlineReservationSystemContextDb.BookingTickets.Where(x=>x.userId == userId && x.plainId== id).FirstOrDefault();  
        }

        public bool BookTicket(Ticket ticket)
        {
            _airlineReservationSystemContextDb.BookingTickets.Add(ticket);
            _airlineReservationSystemContextDb.SaveChanges();
            return true;
        }

        public List<Ticket> BookingHistory(int userId)
        {
            return _airlineReservationSystemContextDb.BookingTickets.Where(x=>x.userId==userId).Include(x=>x.Plain).ToList();
        }
    }
}
