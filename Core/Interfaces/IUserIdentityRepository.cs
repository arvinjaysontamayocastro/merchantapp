using System;
using Core.Entities;

namespace Core.Interfaces;

public interface IUserIdentityRepository
{
    Task<IReadOnlyList<UserIdentity>> GetUserIdentitiesAsync();
    Task<UserIdentity?> GetUserIdentityByIdAsync(int id);
    void AddUserIdentity(UserIdentity userIdentity);
    void UpdateUserIdentity(UserIdentity userIdentity);
    void DeleteUserIdentity(UserIdentity userIdentity);
    bool UserIdentityExists(int id);
    Task<bool> SaveChangesAsync();
}
