namespace AutomotiveSols.BLL.Models
{
   public class CarAppointment
    {
        public int Id { get; set; }
        public int AppointmentId { get; set; }

        public Appointments Appointments { get; set; }

        public int CarId { get; set; }

        public Car Car { get; set; }

    }
}
