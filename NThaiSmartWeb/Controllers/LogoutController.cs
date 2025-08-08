using Microsoft.AspNetCore.Mvc;

public class LogoutController : BaseController
{
    private readonly ILogger<LoginController> _logger;

    public LogoutController(ILogger<LoginController> logger) : base(logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        NSDXSession.Clear();
        return RedirectToAction("Index", "Login");
    }
}