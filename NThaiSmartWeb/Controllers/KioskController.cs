using Microsoft.AspNetCore.Mvc;

public class KioskController : BaseController
{
    private readonly ILogger<BaseController> _logger;

    public KioskController(ILogger<BaseController> logger) : base(logger)
    {
        _logger = logger;
    }

    public IActionResult Index() => List();

    public IActionResult CardReader() => View();

    public IActionResult Setup() => View();

    public IActionResult List() => View();
}