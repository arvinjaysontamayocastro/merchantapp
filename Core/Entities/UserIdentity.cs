using System;

namespace Core.Entities;

public class UserIdentity : BaseEntity
// Derive from BaseEntityClass
{
    // public int Id { get; set; }
    // accessor
    // public: EF
    // private: class
    // protected: class, derived
    // [Key]
    // get set property, inside table, inside database

    public required string UserId { get; set; }
    public required string FullName { get; set; }
    public required string Email { get; set; }
    public required string SourceSystem { get; set; }
    public DateTime LastUpdated { get; set; }
    public required bool IsActive { get; set; }

}
