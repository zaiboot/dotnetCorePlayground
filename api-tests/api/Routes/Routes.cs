namespace Api.Routing;
using System.Collections.Concurrent;
public static class Routes
{
    public static WebApplication MapRoutes(this WebApplication app)
    {
        app.MapGet("api/Queue/",
          (ConcurrentQueue<int> _queue, ILogger<Program> _logger ) =>
        {
            int? result = null;
            if (_queue.TryDequeue(out var result1))
            {
                result = result1;
                _logger.LogDebug($"{result} dequeued ");
            }
            return result;
        });

        app.MapPut("api/Queue/{number}",
          (int number, ConcurrentQueue<int> _queue,  ILogger<Program> _logger) =>
        {
            _queue.Enqueue(number);
            _logger.LogDebug($"{number} added , count= {_queue.Count}");
        });
        return app;
    }
}