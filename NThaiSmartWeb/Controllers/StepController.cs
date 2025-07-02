using Microsoft.AspNetCore.Mvc;

public class StepController : BaseController
{
    private readonly ILogger<StepController> _logger;

    public StepController(ILogger<StepController> logger) : base(logger)
    {
        _logger = logger;
    }

    public IActionResult Step1() => View();

    public IActionResult Step2() => View();

    public IActionResult Step3() => View();

    public IActionResult Step4() => View();

    public IActionResult Step5() => View();

    public IActionResult Step6() => View();

    public IActionResult Step7() => View();

    public IActionResult Step8() => View();
}