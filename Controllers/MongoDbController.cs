using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly MongoDbService _mongoDbService;
    private readonly IMongoCollection<Message> _userCollection;

    public UserController(MongoDbService mongoDbService)
    {
        _mongoDbService = mongoDbService;
        _userCollection = _mongoDbService.GetCollection<Message>("requests");
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Message>>> GetUsers()
    {
        var users = await _userCollection.Find(user => true).ToListAsync();
        return Ok(users);
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser([FromBody] Message newUser)
    {
        await _userCollection.InsertOneAsync(newUser);
        return CreatedAtAction(nameof(GetUsers), new { id = newUser.Id }, newUser);
    }
}
