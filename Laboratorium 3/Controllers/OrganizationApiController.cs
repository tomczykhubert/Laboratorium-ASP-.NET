using Data;
using Data.Migrations;
using Microsoft.AspNetCore.Mvc;

namespace Laboratorium_3.Controllers;

[Route("api/organizations")]
[ApiController]
public class OrganizationApiController : ControllerBase
{
    private readonly AppDbContext _context;

    public OrganizationApiController(AppDbContext context)
    {
        _context = context;
    }

    public IActionResult GetOrganizationByName(string? q)
    {
        return Ok(q == null
            ? _context.Organizations.Select(o => new {name = o.Name, id = o.Id}).ToList()
            : _context.Organizations.Where(o => o.Name.ToUpper().StartsWith(q)).Select(o => new {name = o.Name, id = o.Id}).ToList());
    }
    [Route("{id}")]
    public IActionResult GetById(int id)
    {
        var organization = _context.Organizations.Find(id);
        if (organization == null)
            return NotFound();
        else
            return Ok(organization);
    }
}