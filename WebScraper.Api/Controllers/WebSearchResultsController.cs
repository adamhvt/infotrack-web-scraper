using Microsoft.AspNetCore.Mvc;
using WebScraper.Api.Mappings;
using WebScraper.Application.Interfaces;
using WebScraper.Domain.Models;

namespace WebScraper.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WebSearchResultsController : ControllerBase
    {
        private readonly IWebSearchResultService _searchResultService;

        public WebSearchResultsController(IWebSearchResultService searchResultService)
        {
            _searchResultService = searchResultService;
        }

        [HttpGet]
        [ProducesResponseType<WebSearch>(StatusCodes.Status200OK)]
        [ProducesResponseType<WebSearch>(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAll([FromQuery] Guid? webSearchId)
        {
            var webSearchResults = await _searchResultService.GetAllAsync(webSearchId);
            var response = webSearchResults.Select(x => x.MapToResponse()).ToList();
            return Ok(response);
        }

        [HttpGet("{id:guid}")]
        [ProducesResponseType<WebSearch>(StatusCodes.Status200OK)]
        [ProducesResponseType<WebSearch>(StatusCodes.Status404NotFound)]
        [ProducesResponseType<WebSearch>(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var webSearchResult = await _searchResultService.GetByIdAsync(id);
            if (webSearchResult == null)
            {
                return NotFound();
            }

            var response = webSearchResult.MapToResponse();
            return Ok(response);
        }
    }
}
