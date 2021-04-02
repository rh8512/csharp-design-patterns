using System;
using System.Collections.Generic;

Appointment appointment = new() { IsVip = true, PatientBirthDate = DateTime.Now };

List<IValidation> validations = new List<IValidation>()
{
    new IsVipValidation(),
    new IsAdultValidation()
};

foreach(var validation in validations)
{
    var result = validation.Validate(appointment);

    Console.WriteLine($"{validation.GetType()} result: {result}");
}

class Appointment
{
    public DateTime PatientBirthDate { get; set; }
    public bool IsVip { get; set; }
} 
interface  IValidation
{
    public bool Validate(Appointment appointment);
}

class IsAdultValidation : IValidation
{
    public bool Validate(Appointment appointment)
    {
        return (DateTime.Now.Year - appointment.PatientBirthDate.Year >= 18);
    }
}

class IsVipValidation : IValidation
{
    public bool Validate(Appointment appointment)
    {
        return appointment.IsVip;
    }
}

