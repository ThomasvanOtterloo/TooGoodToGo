﻿using Core.Domain;

namespace Portal.Models;

public class PackageViewModel
{
    public int Id { get; set; }
    public int StudentId { get; set; }
    public int CanteenId { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public City City { get; set; }
    
    public DateTime PickUp { get; set; }
    public double Price { get; set; }
    public Meal Meal { get; set; }
    public bool Adult { get; set; }
    
    public DateTime LastUntil { get; set; }
}