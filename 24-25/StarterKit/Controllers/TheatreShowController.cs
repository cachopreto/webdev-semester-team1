using Microsoft.AspNetCore.Mvc;
using StarterKit.Models;
using StarterKit.Services;

namespace StarterKit.Controllers;

[Route("api/v1/theatreShow")]
public class TheatreShowController : Controller
{
    private readonly TheatreShowService _service;

    public TheatreShowController(TheatreShowService service)
    {
        _service = service;
    }

    [HttpGet("")]
    public IActionResult GetAllTheatreShows()
    {
        return Ok(_service.GetAllTheatreShows());
    }

    [HttpGet("GetById")]
    public IActionResult GetTheatreShow([FromQuery] int id)
    {
        var theatreShow = _service.GetTheatreShowById(id);
        if (theatreShow == null)
        {
            return NotFound($"No theatre show found with id: {id}");
        }
        return Ok(theatreShow);
    }

    [HttpPost("PostTheatreShow")]
    public IActionResult PostTheatreShow([FromBody] TheatreShow theatreShow)
    {
        _service.PostTheatreShow(theatreShow);
        return CreatedAtAction(nameof(GetTheatreShow), new { id = theatreShow.TheatreShowId }, theatreShow);
    }

    [HttpDelete("DeleteById")]
    public IActionResult DeleteTheatreShow([FromQuery] int id)
    {
        var theatreShow = _service.GetTheatreShowById(id);
        if (theatreShow == null) return NotFound();

        _service.DeleteTheatreShow(id);
        return Ok($"Theatre show with id: {id} successfully deleted");
    }

    [HttpPut("UpdateTheatreShow")]
    public IActionResult UpdateTheatreShow([FromQuery] int id, [FromBody] TheatreShow updatedTheatreShow)
    {
        var theatreShow = _service.GetTheatreShowById(id);
        if (theatreShow == null) return NotFound();

        _service.UpdateTheatreShow(id, updatedTheatreShow);
        return Ok("Updated theatre show successfully");
    }

    [HttpPost("PostVenue")]
    public IActionResult PostVenue([FromBody] Venue venue)
    {
        _service.PostVenue(venue);
        return Ok("Posted venue successfully");
    }

    [HttpDelete("DeleteVenue")]
    public IActionResult DeleteVenue([FromQuery] int id)
    {
        _service.DeleteTheatreShow(id);
        return Ok($"Venue with id: {id} successfully deleted");
    }

    [HttpPost("PostTheatreShowDate")]
    public IActionResult PostTheatreShowDate([FromBody] TheatreShowDate theatreShowDate)
    {
        _service.PostTheatreShowDate(theatreShowDate);
        return Ok("Posted theatre show date successfully");
    }

    [HttpDelete("DeleteDate")]
    public IActionResult DeleteDate([FromQuery] int id)
    {
        _service.DeleteTheatreShow(id);
        return Ok($"Theatre show date with id: {id} successfully deleted");
    }
}
