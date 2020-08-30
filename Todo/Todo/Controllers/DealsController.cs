using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Todo.Contracts;

namespace Todo.Controllers
{
    [ApiController]
    public class DealsController : ControllerBase
    {
        private readonly ILogger<DealsController> _logger;
        private readonly ToDoDatabaseContext _context;

        public DealsController(ILogger<DealsController> logger, ToDoDatabaseContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpPost("~/tasks")]
        public IActionResult AddNewTask([FromBody] AddTaskRequest request)
        {
            _context.Deals.Add(new TodoDeal
            {
                DateTime = request.DateTime,
                Priority = request.Priority,
                TaskName = request.TaskName
            });

            _context.SaveChanges();
            return Ok();
        }

        [HttpGet("~/tasks")]
        public async Task<IActionResult> GetTasks(CancellationToken token)
        {
            var allDeals = await _context.Deals.ToArrayAsync(token);
            return Ok(allDeals);
        }
    }
}
