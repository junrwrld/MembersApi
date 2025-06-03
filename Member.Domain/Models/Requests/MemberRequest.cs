using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Member.API.DTO
{
    public class MemberRequest
    {
        public class MemberRequestDTO 
        {
            [Required(ErrorMessage = "O nome é obrigatório.")]
            public string name { get; set; }
            [Required(ErrorMessage = "A data de nascimento é obrigatória.")]

            [JsonConverter(typeof(DateOnlyJsonConverter))]
            public DateTime BirthDate { get; set; }
            [Required(ErrorMessage = "O cargo é obrigatório.")]
            public string Cargo { get; set; }
        }
    }
}
