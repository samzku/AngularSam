using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;

namespace API.Controllers;
[ApiController]
[Route("api/[controller]")]  //api/users

public class UsersController(DataContext context) : ControllerBase
{
    private readonly DataContext _context = context;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
    {
        var users = await _context.Users.ToListAsync();
        return Ok(users);
    }

    [HttpGet("{id:int}")]  //api/users/2

    public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers(int id)
    {
        var users = await _context.Users.FindAsync(id);
        if(users == null)
        return NotFound();
        return Ok(users);
    }
}