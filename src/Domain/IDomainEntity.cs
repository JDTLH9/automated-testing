using System;

namespace Domain
{
    public interface IDomainEntity
    {
        Guid Id { get; set; }
    }
}
