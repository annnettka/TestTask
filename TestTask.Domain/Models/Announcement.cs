﻿namespace TestTask.Domain.Models;

public class Announcement
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime DateAdded { get; set; }
}