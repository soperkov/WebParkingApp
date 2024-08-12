using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;
using System.ComponentModel.DataAnnotations;

namespace WebParkingApp.Models
{
    public class ParkingSpaceModel
    {
        [Key]public int Id { get; set; }
        public string? ParkingName { get; set; }
        public double Price { get; set; }
    }
}
