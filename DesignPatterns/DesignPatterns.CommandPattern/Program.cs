using System;

Appointment appointment = new();

AppointmentManager appointmentManager = new(new CreateAppointmentCommand(appointment), new CancelAppoitmentCommand(appointment));

Console.WriteLine(appointment.ToString());

appointmentManager.CreateAppointment();

Console.WriteLine(appointment.ToString());

appointmentManager.CancelAppointment();

Console.WriteLine(appointment.ToString());


public class AppointmentManager
{
    private readonly ICommand createAppointmentCommand;
    private readonly ICommand cancelAppointmentCommand;

    public AppointmentManager(ICommand createCommand, ICommand cancelCommand)
    {
        createAppointmentCommand = createCommand;
        cancelAppointmentCommand = cancelCommand;
    }

    public void CreateAppointment()
    {
        createAppointmentCommand.Execute();
    }

    public void CancelAppointment()
    {
        cancelAppointmentCommand.Execute();
    }
}

public interface ICommand
{
    void Execute();
}

class CreateAppointmentCommand : ICommand
{
    private Appointment Appointment { get; }
    public CreateAppointmentCommand(Appointment appointment) => Appointment = appointment;

    public void Execute()
    {
        Appointment.Create();
        Console.WriteLine($"Appointment saved");
    }
}

class CancelAppoitmentCommand : ICommand
{
    private Appointment Appointment { get; }
    public CancelAppoitmentCommand(Appointment appointment) => Appointment = appointment;
    public void Execute()
    {
        Appointment.IsCanceled = true;
        Console.WriteLine($"Appointment canceled");
    }
}

class Appointment
{
    public Guid Id { get; set; }
    public DateTime Date { get; set; }
    public bool IsCanceled { get; set; }

    public void Create() {
        Id = Guid.NewGuid();
        Date = DateTime.UtcNow;
        IsCanceled = false;
    }
    public void Cancel() {
        IsCanceled = true;
    }

    public override string ToString()
    {
        return $"{Id} - {Date.ToShortTimeString()} - Canceled: {IsCanceled}";
    }
}