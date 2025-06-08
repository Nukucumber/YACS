namespace CloudStorageService.Web.Controllers;

using Microsoft.AspNetCore.Mvc;

using Application.UseCases;
using System.Text.Json;

[Route("[Controller]")]
public class TestController : ControllerBase
{
    private TestUseCases _test;

    public TestController(TestUseCases test)
    {
        _test = test;
    }


    [HttpGet("{param}")]
    public IActionResult Get(string param)
    {
        var file = _test.Handle(param: param);

        var response = file.GetData();

        return Ok(JsonSerializer.SerializeToDocument(response));
    }
}