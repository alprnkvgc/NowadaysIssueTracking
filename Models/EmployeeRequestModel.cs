﻿namespace NowadaysIssueTracking.Models;

public class EmployeeRequestModel
{
    public int Id { get; set; }
    public string TCKimlikNo { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int BirthYear { get; set; }
}