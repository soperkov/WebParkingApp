using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;
using System.ComponentModel.DataAnnotations;

namespace WebParkingApp.Models
{
    public class ReservationModel
    {
        [Key]public int Id { get; set; }
        public int UserId { get; set; }
        public int ParkingId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
