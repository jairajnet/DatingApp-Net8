using System;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;
[ApiController]
[Route("api/[controller]")]
public class UsersController(DataContext context) : ControllerBase
{
    //public DataContext _Context { get; } = context;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
    {
        var users = await context.Users.ToListAsync();
        return Ok(users);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<AppUser>> GetUser(int id)
    {
        //var users = context.Users.Select(x=>x.Id==id);
        var user = await context.Users.FindAsync(id);
        if (user == null) return NotFound();
        return user;
    }
}
