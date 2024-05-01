using Microsoft.AspNetCore.Mvc;
using HYDRANT;
using System.Text.Json;
//Jia Tan?
namespace Firehose2;

[ApiController]
[Route("[controller]")]
public class ArticlesController : ControllerBase
{

    [HttpGet("GetArticles")]
    public IActionResult GetArticles(int limit = 9999999)
    {
        try
        {
            // ReSharper disable once RedundantTypeArgumentsOfMethod
            return Ok(JsonSerializer.Serialize<List<Article>>(Article.GetArticlesFromDB(limit,0)));
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpGet("GetURLs")]
    public IActionResult GetURLs()
    {
        try
        {
            var urls = Article.GetURLs();
            return Ok(urls);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
}