namespace SibSample.API.Features.v1
{
    using Configuration;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Options;

    [ApiController]
    [ApiVersion("1")]
    [Route("v{version:apiVersion}/repositories")]
    [Produces("application/json")]
    public class RepositoryController : ControllerBase
    {
        private readonly ProjectConfig _projectConfig;

        public RepositoryController(IOptions<ProjectConfig> projectConfig)
        {
            _projectConfig = projectConfig.Value;
        }

        [HttpGet("showmethecode")]
        public IActionResult ShowMeTheCode()
        {
            return Ok(_projectConfig);
        }
    }
}