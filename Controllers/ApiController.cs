using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

[Route("api/[controller]")]
[ApiController]
public class MessageController : ControllerBase

{
    private readonly MongoDbService _mongoDbService;
    private readonly IMongoCollection<Message> _userCollection;
    public MessageController(MongoDbService mongoDbService)
    {
        _mongoDbService = mongoDbService;
        _userCollection = _mongoDbService.GetCollection<Message>("requests");
    }
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
