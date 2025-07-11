﻿namespace cwiczenia12.Models;


public class AssignClientDto
{
    public string FirstName { get; set; } = null!;
    
    public string LastName { get; set; } = null!;
    
    public string Email { get; set; } = null!;
    
    public string Telephone { get; set; } = null!;
    
    public string Pesel { get; set; } = null!;
    
    public DateTime? PaymentDate { get; set; }
}
