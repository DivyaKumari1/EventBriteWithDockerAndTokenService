using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserAPI.Data;
using UserAPI.Domain;
using UserAPI.ViewModels;

namespace UserAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserContext _context;
        public UserController(UserContext context)
        {
            _context = context;
        }

        //GET api/userinformation/users?pageSize=10&pageIndex=2
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> Users([FromQuery]int pageSize = 5,[FromQuery]int pageIndex =0)
        {
            var usersCount = await _context.UserInformation.LongCountAsync();

            var users = await _context.UserInformation
                  .OrderBy(c => c.FirstName)
                  .Skip(pageSize * pageIndex)
                  .Take(pageSize)
                  .ToListAsync();
            var model = new PaginatedUsersViewModel<UserInformation>
            {
                PageSize = pageSize,
                PageIndex = pageIndex,
                Count = usersCount,
                Data = users
            };
            return Ok(model);

        }
        [HttpGet]
        [Route("items/{id:int}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Incorrect Id!");

            }

            var user = await _context.UserInformation.SingleOrDefaultAsync(c => c.Id == id);

            if (user == null)
            {
                return NotFound("User information not found");
            }

            return Ok(user);

        }
 
    }
}