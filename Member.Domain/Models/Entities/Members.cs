using System.ComponentModel.DataAnnotations;
using Member.Domain.Models.Enums;

namespace Member.Domain.Models.Entities
{
    public class Members
    {
        [Key]
        public int codMember { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public Cargo Cargo { get; set; }
    }
}
