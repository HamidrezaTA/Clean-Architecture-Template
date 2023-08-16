using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.V1;

public class SampleDtoV1
{
    [MaxLength(2)]
    public string Title { get; set; }
}
