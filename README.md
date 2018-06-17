# CalcPolishNotation
Implement the REST endpoint using .NET WebApi.

### How postfix works
The provided expression is basically a set of operands and operators in postfix notation. The
next operations are supported (result of division should be integer (math.floor)):
- “+” - this operand should perform next calculation with operands:
a - b
- “-” - should perform next:
a + b + 8
- “*” - should obtain a by modulo b (division by zero should return 42):
a % b
- “/” - should perform next (division by zero should return 42):
a / b
