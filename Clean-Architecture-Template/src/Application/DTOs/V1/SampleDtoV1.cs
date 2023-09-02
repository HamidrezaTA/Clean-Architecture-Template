using System.ComponentModel.DataAnnotations;
using Domain.Enums;

namespace Application.DTOs.V1;

public class SampleDtoV1
{
    public string Title { get; set; }
    public string Description { get; set; }
    public SampleStateEnum State { get; set; }
}
