namespace Domain.Entities;

using System;

public class BaseEntitySoftDelete: BaseEntity
{
    public DateTimeOffset? DeletedAt { get; set; }
}
