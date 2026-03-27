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
    public IActionResult Step9() => View();
    public IActionResult Step10() => View();
    public IActionResult Step11() => View();
    public IActionResult Step12() => View();
    public IActionResult Step14() => View();
public IActionResult Step17() => View();

    public IActionResult StepEnd() => View();
}