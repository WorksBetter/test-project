using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly MongoDbContext _context;

    public UsersController(MongoDbContext context)
    {
        _context = context;
    }

    // Read (Get all users)
    [HttpGet]
    public async Task<IActionResult> GetUsers()
    {
        // Exclude logically deleted users
        var users = await _context.Users.Find(u => u.DeletedAt == null).ToListAsync();
        return Ok(users);
    }

    // Create (Add a new user)
    [HttpPost]
    public async Task<IActionResult> CreateUser([FromBody] User user)
    {
        await _context.Users.InsertOneAsync(user);
        return Ok(user);
    }

    // Implement GDPR Delete User operation
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(string id)
    {
        // Find the user by ID
        var user = await _context.Users.Find(u => u.Id == id).FirstOrDefaultAsync();

        if (user == null)
        {
            return NotFound(); // If user not found, return 404
        }

        // Check if the user has provided GDPR consent
        if (user.ConsentGiven)
        {
            // GDPR consent given, perform logical deletion (set DeletedAt)
            user.DeletedAt = DateTime.UtcNow;
            await _context.Users.ReplaceOneAsync(u => u.Id == id, user);
            return NoContent(); // Return success, no data
        }
        else
        {
            // GDPR consent not given, perform physical deletion
            var deleteResult = await _context.Users.DeleteOneAsync(u => u.Id == id);

            if (deleteResult.DeletedCount == 0)
            {
                return NotFound(); // If no user was deleted, return 404
            }

            return NoContent(); // Return success, no data
        }
    }

    // GDPR - Access and Portability
    [HttpGet("{id}/data")]
    public async Task<IActionResult> GetUserData(string id)
    {
        var user = await _context.Users.Find(u => u.Id == id).FirstOrDefaultAsync();
        if (user == null)
        {
            return NotFound();
        }

        // Log the access time
        user.DataAccessedAt = DateTime.UtcNow;
        await _context.Users.ReplaceOneAsync(u => u.Id == id, user);

        return Ok(user); // Return user data in JSON format
    }

    // GDPR - Update user (Rectification)
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateUser(string id, [FromBody] User updatedUser)
    {
        var existingUser = await _context.Users.Find(u => u.Id == id).FirstOrDefaultAsync();
        if (existingUser == null)
        {
            return NotFound();
        }

        // Check if consent status has changed
        bool consentChanged = existingUser.ConsentGiven != updatedUser.ConsentGiven;

        existingUser.Name = updatedUser.Name;
        existingUser.Email = updatedUser.Email;
        existingUser.ConsentGiven = updatedUser.ConsentGiven;

        // If consent is changed from true to false
        if (consentChanged && existingUser.ConsentGiven == false)
        {
            // If the user was logically deleted (DeletedAt is set), physically delete them
            if (existingUser.DeletedAt != null)
            {
                // Physically delete the user
                var deleteResult = await _context.Users.DeleteOneAsync(u => u.Id == id);

                if (deleteResult.DeletedCount == 0)
                {
                    return NotFound(); // If no user was deleted, return 404
                }

                return NoContent(); // User was physically deleted
            }
        } else if (consentChanged && existingUser.ConsentGiven == true)
        {
            // If consent is changed from false to true, reactivate the user by clearing the DeletedAt field
            if (existingUser.DeletedAt != null)
            {
                // Remove the logical deletion by clearing the DeletedAt timestamp
                existingUser.DeletedAt = null;
            }
        }

        await _context.Users.ReplaceOneAsync(u => u.Id == id, existingUser);
        return Ok(existingUser);
    }
}