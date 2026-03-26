using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ProxyApiController : ControllerBase
{
    private readonly IHttpClientFactory _httpClientFactory;

    public ProxyApiController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    [HttpGet("proxy")]
    public async Task<IActionResult> Proxy([FromQuery] string url)
    {
        if (string.IsNullOrEmpty(url))
            return BadRequest("Missing url");

        try
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync(url);

            if (!response.IsSuccessStatusCode)
                return StatusCode((int)response.StatusCode, "Error fetching content");

            var html = await response.Content.ReadAsStringAsync();

            // คืน HTML ตรง ๆ
            return Content(html, "text/html");
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
}