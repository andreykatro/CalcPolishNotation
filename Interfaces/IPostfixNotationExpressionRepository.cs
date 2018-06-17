using System.Collections.Generic;
using CalcPolishNotation.Models;

namespace CalcPolishNotation.Interfaces
{
    public interface IPostfixNotationExpressionRepository
    {
      PostfixNotationExpression NewExpression();
      IEnumerable<PostfixNotationExpression> All{ get; }
      PostfixNotationExpression Find(string id);
      void Update(PostfixNotationExpression item);
    }
}