﻿using TestTask.Domain.Models;

namespace TestTask.Domain.Stores;

public interface IAnnouncementStore
{
    Task<IEnumerable<Announcement>> GetAsync();
    Task<IEnumerable<Announcement>> GetAsync(Guid id);
    Task AddAsync(Announcement announcement);
    Task UpdateAsync(Announcement announcement);
    Task DeleteAsync(Guid id);
    Task<IEnumerable<Announcement>> GetSimilarAnnouncementAsync(Guid id);
}