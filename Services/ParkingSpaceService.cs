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

        public double GetParkingSpacePrice(int id)
        {
            return _context.ParkingSpaces.FirstOrDefault(s => s.Id == id).Price;
        }

        public List<ParkingSpaceModel> GetParkingSpaces() 
        {
            return _context.ParkingSpaces.ToList();
        }

        public async Task<bool> ReserveParkingSpaceAsync(ReservationModel reservation)
        {
            var existingReservation = _context.Reservations
                .Where(r => r.UserId == reservation.UserId)
                .Where(r => r.StartDate <= reservation.EndDate && r.EndDate >= reservation.StartDate)
                .FirstOrDefault();

            if (existingReservation != null)
            {
                return false;
            }

            _context.Reservations.Add(reservation);
            await _context.SaveChangesAsync();

            return true;
        }

        public List<ReservationModel> GetReservations(int userId)
        {
            return _context.Reservations.Where(s => s.UserId == userId)
                .Where(s => s.EndDate > DateTime.Now).ToList();
        }

        public List<ParkingSpaceModel> GetAvailableSpaces(DateTime sDate, DateTime eDate)
        {
            if (sDate < DateTime.Now || eDate < DateTime.Now)
            {
                return null;
            }
            List<ParkingSpaceModel> availableSpaces = GetParkingSpaces();

            foreach (var reservation in _context.Reservations)
            {
                if(sDate < reservation.EndDate &&
                    eDate > reservation.StartDate ||
                    sDate < DateTime.Now)
                {
                    var parkingSpace = availableSpaces.FirstOrDefault(s => s.Id == reservation.ParkingId);

                    if (parkingSpace != null)
                    {
                        availableSpaces.Remove(parkingSpace);
                    }
                }
            }

            return availableSpaces;
        }

        public List<string> GetZonesByReservation (List<ReservationModel> reservations)
        {
            List<string> zones = new();

            foreach (var reservation in reservations)
            {
                var zone = _context.ParkingSpaces.FirstOrDefault(s => s.Id == reservation.ParkingId).ParkingName;
                zones.Add(zone);
            }
            return zones;
        }

        public string GetReservationZone (ReservationModel reservation)
        {
            return _context.ParkingSpaces.FirstOrDefault(s => s.Id == reservation.ParkingId).ParkingName;
        }
    }
}
