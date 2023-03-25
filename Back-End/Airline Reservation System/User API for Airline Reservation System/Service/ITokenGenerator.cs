namespace User_API_for_Airline_Reservation_System.Service
{
    public interface ITokenGenerator
    {
        string GenerateToken(int id, string name, string role);
    }
}
