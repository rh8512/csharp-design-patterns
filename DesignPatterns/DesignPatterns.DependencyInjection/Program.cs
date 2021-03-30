using System;


/// <summary>
/// Constructor Injection
/// </summary>
AppointmentManager appointmentManagerOne = new(new DBStorage());
appointmentManagerOne.Save();

AppointmentManager appointmentManagerTwo = new(new FileStorage());
appointmentManagerTwo.Save();

/// <summary>
/// Property Injection
/// </summary>
AppointmentManager appointmentManagerThree = new();
appointmentManagerThree.Storage = new DBStorage();
appointmentManagerThree.Save();

AppointmentManager appointmentManagerFour = new();
appointmentManagerFour.Storage = new FileStorage();
appointmentManagerFour.Save();

/// <summary>
/// Method Injection
/// </summary>
AppointmentManager appointmentManagerFive = new();
appointmentManagerFive.Save(new DBStorage());

AppointmentManager appointmentManagerSix = new();
appointmentManagerSix.Save(new FileStorage());

class Appointment { }
interface IAppointmentStorage
{
    void SaveAppointment(Appointment appointment);
    Appointment GetAppointment(int id);
}


class DBStorage : IAppointmentStorage
{
    public Appointment GetAppointment(int id)
    {
        Console.WriteLine("DB storage get appointment");
        return new Appointment();
    }

    public void SaveAppointment(Appointment appointment) => Console.WriteLine("DB storage save appointment");

}

class FileStorage : IAppointmentStorage
{
    public Appointment GetAppointment(int id)
    {
        Console.WriteLine("File storage get appointment");
        return new Appointment();
    }

    public void SaveAppointment(Appointment appointment) => Console.WriteLine("File storage save appointment");

}

class AppointmentManager
{
    private IAppointmentStorage _storage;
    public AppointmentManager() { }

    /// <summary>
    /// Constructor Injection
    /// </summary>
    /// <param name="storage">Storage Interface</param>
    public AppointmentManager(IAppointmentStorage storage) => _storage = storage;

    /// <summary>
    /// Property Injection
    /// </summary>
    public IAppointmentStorage Storage { set => _storage = value; }

    public void Save() => _storage.SaveAppointment(new Appointment());
    public Appointment Get() => _storage.GetAppointment(1);


    /// <summary>
    /// Method Injection
    /// </summary>
    /// <param name="appointmentStorage"></param>
    public void Save(IAppointmentStorage appointmentStorage) => appointmentStorage.SaveAppointment(new Appointment());

}