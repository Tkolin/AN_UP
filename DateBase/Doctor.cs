using System;

namespace AN_UP.DateBase;

public class Doctor
{
    public int Id { get; set; }
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public string Patronymic { get; set; }
    public DateTime EmploymentDate { get; set; }
    public int PositionID { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }
}