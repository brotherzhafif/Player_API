using Microsoft.AspNetCore.Mvc;

[ApiController]
public class SettingsController : ControllerBase
{
    // Initiation to SettingsControler configuration
    private readonly IConfiguration _configuration;

    public SettingsController(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    [HttpGet]
    [Route("GetConnection")]
    public IActionResult GetConnectionString()
    {
        var connectionString = _configuration.GetConnectionString("DefaultConnection");
        return Ok(connectionString);
    }
}
