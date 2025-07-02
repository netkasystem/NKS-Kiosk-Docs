using Microsoft.AspNetCore.Mvc;

public class LoginController : BaseController
{
    private readonly ILogger<LoginController> _logger;

    public LoginController(ILogger<LoginController> logger) : base(logger)
    {
        _logger = logger;
    }

    public IActionResult Index() => View();
}