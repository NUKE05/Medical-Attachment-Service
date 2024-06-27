using Medical_Attachment_Service.Contracts;
using MedicalAttach.Core.Abstractions;
using MedicalAttach.Core.Models;
using MedicalAttach.DataAccess;
using MedicalAttachment.Application.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace Medical_Attachment_Service.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersControllers : ControllerBase
    {
        private readonly IUserService _userService;
        public UsersControllers(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserResponce>>> GetUsers()
        {
            var users = await _userService.GetAllUsers();

            var responce = users.Select(u => new UserResponce(u.Id, u.Login, u.Password, u.IsAdmin, u.MedicalOrganizationId));

            return Ok(responce);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateUser([FromBody] UserRequest request)
        {
            var (user, error) = MedicalAttach.Core.Models.User.Create(
                Guid.NewGuid(),
                request.Login,
                request.Password,
                request.isAdmin,
                request.MedicalOrganizationId);

            if (!string.IsNullOrEmpty(error))
            {
                return BadRequest(error);
            }

            var userId = await _userService.CreateUser(user);

            return Ok(userId);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<Guid>> UpdateUsers(Guid id, [FromBody] UserRequest request)
        {
            var UserId = await _userService.UpdateUser(id,request.Login, request.Password, request.isAdmin, request.MedicalOrganizationId);

            return Ok(UserId);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<Guid>> DeletePatient(Guid id)
        {
            return Ok(await _userService.DeleteUser(id));
        }
    }
}
