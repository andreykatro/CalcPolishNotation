using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using CalcPolishNotation.Models;
using CalcPolishNotation.Interfaces;
using System.Collections.Generic;

namespace CalcPolishNotation.Controllers
{
  [Route("[controller]")]
  [ApiController]
  public class CalculatesController : ControllerBase
  {
    private readonly IPostfixNotationExpressionRepository _pneRepository;

    public CalculatesController(IPostfixNotationExpressionRepository pneRepository)
    {
      _pneRepository = pneRepository;
    }

    [HttpGet]
    public IActionResult Get()
    {
      var item = _pneRepository.NewExpression();
      return Ok(new { id = item.Id, expression = item.Expression });
    }

    [HttpGet("{history}")]
    public ActionResult GetHistory()
    {
      return Ok(_pneRepository.All.Select(x => new{id = x.Id, expression = x.Expression, passed = x.Passed }));
    }

    [HttpPost]
    public IActionResult Post(PostfixNotationExpression item)
    {
      try
      {
        if (item == null || !ModelState.IsValid)
        {
          return BadRequest(ModelState);
        }

        var dbItem = _pneRepository.Find(item.Id);

        if (dbItem == null)
        {
          return NotFound();
        }

        if (dbItem.Result == item.Result)
        {
          item.Passed = true;
          _pneRepository.Update(item);
        }

      }
      catch (Exception)
      {
        return BadRequest();
      }
      return Ok(new { id = item.Id, passed = item.Passed });
    }
  }
}