using Member.API.DTO;
using Member.Domain.Interfaces;
using Member.Domain.Interfaces.Services;
using Member.Domain.Models.Entities;
using Member.Domain.Utils;
using Microsoft.AspNetCore.Mvc;

namespace Member.API.Controllers.v1
{
    [ApiController]
    [Route("api/[controller]")]
    public class MembersController : MainController
    {
        private readonly IMemberService _memberService;

        public MembersController(IMemberService memberService, INotificationService notificationService)
            : base(notificationService)
        {
            _memberService = memberService;
        }

        [HttpPost]
        public async Task<IActionResult> AddMember([FromBody] MemberRequest.MemberRequestDTO member)
        {
            var result = await _memberService.AddMember(member);

            return CustomResponse(result);
        }
    }
}
