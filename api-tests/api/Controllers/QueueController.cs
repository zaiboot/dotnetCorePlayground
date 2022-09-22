using System.Collections.Concurrent;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class QueueController : ControllerBase
{
  private readonly ConcurrentQueue<int> _queue = new();
  private readonly ILogger<QueueController> _logger;

  public QueueController(ILogger<QueueController> logger)
  {
    this._logger = logger;
  }

  [HttpPut("{number}")]
  public void Put(int number)
  {
    _queue.Enqueue(number);
    _logger.LogDebug($"{number} added ");
  }

  [HttpGet]
  public int? Get()
  {
    int? result = null;
    if (_queue.TryDequeue(out var result1))
    {
      result = result1;
    }
    return result;
  }
}