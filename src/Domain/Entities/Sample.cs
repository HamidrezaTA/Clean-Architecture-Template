using System.ComponentModel.DataAnnotations;
using Domain.Enums;

namespace Domain.Entities
{
    public class Sample : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public SampleStateEnum State { get; set; }
    }
}
