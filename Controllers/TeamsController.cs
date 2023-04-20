using Microsoft.AspNetCore.Mvc;
using PostgresDB.Models;
using PostgresDB.Services;
using System;



[ApiController]
[Route("[controller]")]
public class TeamsController : ControllerBase
{


    private readonly ILogger<TeamsController> _logger;
    private readonly IUnitOfWork _unitOfWork;

    public TeamsController(
        ILogger<TeamsController> logger,
        IUnitOfWork unitOfWork)
    {
        _logger = logger;
        _unitOfWork = unitOfWork;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var team = await _unitOfWork.Teams.All();


        return Ok(team);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetItem(int id)
    {
        var team = await _unitOfWork.Teams.GetById(id);

        if (team == null)
            return NotFound();

        return Ok(team);
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser(string name, int year)
    {
        var now = DateTime.UtcNow;
        Guid guidValue = Guid.NewGuid();
        int intValue = guidValue.GetHashCode();

        var team = new Team
        {
            Id = intValue,
            Name = name,
            Year = year,


        };

        team.DateAdded = now;
        team.DateModified = now;
        team.Status = 1;

        if (ModelState.IsValid)
        {


            await _unitOfWork.Teams.Add(team);
            await _unitOfWork.CompleteAsync();

            return CreatedAtAction("GetItem", new
            {
                team.Id
            }, team);
        }

        return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
    }












}
