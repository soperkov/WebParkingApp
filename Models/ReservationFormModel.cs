using System.ComponentModel.DataAnnotations;

namespace WebParkingApp.Models
{
    public class ReservationFormModel
    {
        [Required(ErrorMessage = "Potreban je datum početka rezervacije.")]
        public DateOnly? StartDate { get; set; }

        [Required(ErrorMessage = "Potrebno je vrijeme početka rezervacije.")]
        public TimeOnly? StartTime { get; set; }

        [Required(ErrorMessage = "Potreban je datum kraja rezervacije.")]
        public DateOnly? EndDate { get; set; }

        [Required(ErrorMessage = "Potrebno je vrijeme kraja rezervacije.")]
        public TimeOnly? EndTime { get; set; }
    }
}
