using WebParkingApp.Models;

namespace WebParkingApp.Services
{
    public class ParkingSpaceService
    {
        private readonly AppDbContext _context;
        public ParkingSpaceService(AppDbContext context) 
        { 
            _context = context;
        }

        public ParkingSpaceModel GetParkingSpace(int id)
        {
            return _context.ParkingSpaces.FirstOrDefault(s => s.Id == id);
        }

        public bool ReserveParkingSpace(ReservationModel reservation)
        {
            var parkingSpaces = _context.Reservations
                .Where(s => s.ParkingId == reservation.ParkingId).ToList();
            bool canReserve = true;
            foreach (var parkingSpace in parkingSpaces)
            {
                if (reservation.StartDate < parkingSpace.EndDate && 
                    reservation.EndDate > parkingSpace.StartDate ||
                    reservation.StartDate < DateTime.Now)
                {
                    canReserve = false;
                }
            }
            if (canReserve) {
                _context.Reservations.Add(reservation);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public List<ReservationModel> GetReservations(int userId)
        {
            return _context.Reservations.Where(s => s.UserId == userId)
                .Where(s => s.EndDate > DateTime.Now).ToList();
        }
    }
}
