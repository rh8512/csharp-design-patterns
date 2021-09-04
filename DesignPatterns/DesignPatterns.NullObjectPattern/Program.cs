using System;

IAppointment appointmentNo1 = AppointmentManager.GetAppointment(1);
IAppointment appointmentNo2 = AppointmentManager.GetAppointment(2);
IAppointment appointmentNo6 = AppointmentManager.GetAppointment(6);


appointmentNo1.CancelAppointment();
appointmentNo2.CancelAppointment();
appointmentNo6.CancelAppointment();


public interface IAppointment
{
    void CancelAppointment();
}

public class NullAppointment : IAppointment
{
    public void CancelAppointment()
    {
        //Hands Free, doing nothing is also doing
        Console.WriteLine("Nothing to cancel");
    }
}

public class Appointment : IAppointment
{
    public void CancelAppointment()
    {
        Console.WriteLine("Appointment canceled");
    }
}

public class AppointmentManager
{
    public static IAppointment GetAppointment(int id)
    {
        if (id > 0 && id < 5) return new Appointment();
        else return new NullAppointment();
    }
}
