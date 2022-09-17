using System.Collections.Concurrent;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

public class QueueController : Controller
{
  private readonly ConcurrentDictionary<string, int> _dict = new();
  public void Put(string key, int number){
    _dict[key] = number;
  }

  public int Get(string key){
    return _dict[key];
  }
}