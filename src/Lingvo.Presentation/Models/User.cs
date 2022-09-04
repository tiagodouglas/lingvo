﻿namespace Lingvo.Presentation.Models;

public class User
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Token { get; set; }
    public DateTime ExpDate { get; set; }
}
