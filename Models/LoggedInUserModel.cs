namespace WebParkingApp.Models
{
    public class LoggedInUserModel
    {
        public int Id { get; set; }
        public UserModel User { get; set; }


        public void Reset()
        {
            Id = 0;
            User = null;
        }

        public void Clear()
        {
            Id = 0;
            User = new UserModel();
        }
    }
}
