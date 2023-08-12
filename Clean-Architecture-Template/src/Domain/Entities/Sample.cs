namespace Domain.Entities;

using Domain.Enums;

public class Sample : BaseEntity
{
    public required string Title { get; set; }
    public required string Description { get; set; }
    public SampleStateEnum State { get; set; }
}
