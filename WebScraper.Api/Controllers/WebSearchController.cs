using Microsoft.AspNetCore.Mvc;
using WebScraper.Api.Mappings;
using WebScraper.Application.Interfaces;
using WebScraper.Contracts;
using WebScraper.Domain.Models;

namespace WebScraper.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WebSearchController : ControllerBase
    {
        private readonly IWebSearchService _webSearchService;

        public WebSearchController(IWebSearchService webSearchService)
        {
            _webSearchService = webSearchService;
        }

        [HttpPost]
        [ProducesResponseType<WebSearch>(StatusCodes.Status201Created)]
        [ProducesResponseType<WebSearch>(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create([FromBody] WebSearchRequest request)
        {
            var searchResult = await _webSearchService.CreateSearchAsync(request.SearchExpression, request.SearchProvider, request.IsAdHoc);
            return CreatedAtAction(nameof(GetById), new { id = searchResult.WebSearchId }, searchResult.MapToResponse());
        }

        [HttpPut("{id:guid}")]
        [ProducesResponseType<WebSearch>(StatusCodes.Status200OK)]
        [ProducesResponseType<WebSearch>(StatusCodes.Status404NotFound)]
        [ProducesResponseType<WebSearch>(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> RepeatSearch([FromRoute] Guid id)
        {
            var searchResult = await _webSearchService.RepeatSearchAsync(id);
            if (searchResult == null)
            {
                return NotFound();
            }

            var response = searchResult.MapToResponse();
            return Ok(response);
        }

        [HttpGet]
        [ProducesResponseType<WebSearch>(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var webSearches = await _webSearchService.GetAllAsync();
            var response = webSearches.Select(x => x.MapToResponse()).ToList();
            return Ok(response);
        }

        [HttpGet("{id:guid}")]
        [ProducesResponseType<WebSearch>(StatusCodes.Status200OK)]
        [ProducesResponseType<WebSearch>(StatusCodes.Status404NotFound)]
        [ProducesResponseType<WebSearch>(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var webSearch = await _webSearchService.GetByIdAsync(id);
            if (webSearch == null)
            {
                return NotFound();
            }

            var response = webSearch.MapToResponse();
            return Ok(response);
        }
    }
}
