using System;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class UserIdentityRepository(StoreContext context) : IUserIdentityRepository
{
    public void AddUserIdentity(UserIdentity userIdentity)
    {
        context.UserIdentities.Add(userIdentity);
    }

    public void DeleteUserIdentity(UserIdentity userIdentity)
    {
        context.UserIdentities.Remove(userIdentity);
    }

    public async Task<UserIdentity?> GetUserIdentityByIdAsync(int id)
    {
        return await context.UserIdentities.FindAsync(id);
    }

    public async Task<IReadOnlyList<UserIdentity>> GetUserIdentitiesAsync()
    {
        return await context.UserIdentities.ToListAsync();
    }

    public bool UserIdentityExists(int id)
    {
        return context.UserIdentities.Any(x => x.Id == id);
    }

    public async Task<bool> SaveChangesAsync()
    {
        return await context.SaveChangesAsync() > 0;
    }

    public void UpdateUserIdentity(UserIdentity userIdentity)
    {
        context.Entry(userIdentity).State = EntityState.Modified;
    }
}
