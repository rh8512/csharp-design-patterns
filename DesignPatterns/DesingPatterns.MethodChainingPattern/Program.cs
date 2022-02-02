AppointmentChain appointmentChain = new AppointmentChain().ScheduleFor("Piotr Penza").SetScheduleDate(DateTime.UtcNow);


public class AppointmentChain
{
    private Appointment appointment = new();

    private class Appointment
    {
        public string? PatientName;
        public DateTime? AppointmentDate;
    }

    public AppointmentChain ScheduleFor(string patientName)
    {
        appointment.PatientName = patientName;
        return this;
    }

    public AppointmentChain SetScheduleDate(DateTime scheduleDate)
    {
        appointment.AppointmentDate = scheduleDate;
        return this;
    }
}