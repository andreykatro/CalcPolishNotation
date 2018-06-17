using System.ComponentModel.DataAnnotations;

namespace CalcPolishNotation.Models{
  public class PostfixNotationExpression
  {
    [Required]
    public string Id { get; set; }
    public string Expression { get; set; }
    [Required]
    public int Result { get; set; }
    public bool Passed { get; set; }
  }
}