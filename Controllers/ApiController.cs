using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class MessageController : ControllerBase
{
    // GET api/message
    [HttpGet]
    public IActionResult SendMessageByMail()
    {
        return Ok("Test a zebbi TESSTTT");
    }

    // POST api/message
    [HttpPost]
    public IActionResult PostMessageInDatabase([FromBody] Message message)
    {
        // Here you would typically handle the message, e.g., save it to a database
        return Ok($"Kanker Post werkt: {message.Content}");
    }
}
