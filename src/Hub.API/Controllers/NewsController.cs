using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Hub.Domain.Entities;
using Hub.Domain.Context;
using Hub.API.Wrappers;
using Hub.API.Filter;
using Hub.API.Services;
using Hub.API.Helpers;

namespace Hub.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
	{
        private readonly ScorehubDbContext _dbContext;
        private readonly IUriService _uriService;
        private readonly ILogger<NewsController> _logger;

        public NewsController(ScorehubDbContext dbContext, IUriService uriService, ILogger<NewsController> logger)
        {
            _dbContext = dbContext;
            _uriService = uriService;
            _logger = logger;
        }

        [ActionName("[action]")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var news = await _dbContext.News.Where(c => c.Id == id).FirstOrDefaultAsync();
            return Ok(new Response<News>(data: news));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] PaginationFilter filter)
        {
            _logger.LogInformation("Starting pagination");
            _logger.LogError("Starting pagination");
            var route = Request.Path.Value;
            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);
            var pagedData = await _dbContext.News
                .Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
                .Take(validFilter.PageSize)
                .ToListAsync();
            var totalRecords = await _dbContext.News.CountAsync();
            var pagedReponse = PaginationHelpers.CreatePagedReponse<News>(pagedData, validFilter, totalRecords, _uriService, route);
            return Ok(pagedReponse);
        }
    }
}

