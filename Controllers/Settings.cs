using Microsoft.AspNetCore.Mvc;

[ApiController]
public class Settings : ControllerBase
{
    // Initiation to SettingsControler configuration
    private readonly IConfiguration _configuration;

    public Settings(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    [HttpGet]
    [Route("api/settings")]
    public IActionResult GetConnectionString()
    {
        var connectionString = _configuration.GetConnectionString("DefaultConnection");
        return Ok(connectionString);
    }
}
