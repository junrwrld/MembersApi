using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Member.Domain.Models.Responses
{
    public class MemberResponse
    {
        public class MemberResponseDTO
        {
            public int CodMember { get; set; }
            public string Name { get; set; }
            public DateTime BirthDate { get; set; }
            public string Cargo { get; set; }  // Pode deixar string para mostrar o nome do enum
        }
    }
}
