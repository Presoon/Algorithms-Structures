using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ONP_Notation__Conversion_
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            const string infix = "2 ^ 5 + ( 4 - ( 2 * 1 ) ) / 5";
            Console.WriteLine(PRNP("19  2  5 * 2  23  1  5/*-++"));
            var tokens = infix.Split(' ');

            var stack = new Stack<string>();
            var outList = new List<string>();

            foreach (string c in tokens)
            {
                if (!int.TryParse(c.ToString(), out int n))
                {
                    switch (c)
                    {
                        case "(":
                            stack.Push(c);
                            break;
                        case ")":
                        {
                            while (stack.Count != 0 && stack.Peek() != "(")
                            {
                                outList.Add(stack.Pop());
                            }

                            stack.Pop();
                            break;
                        }
                        default:
                        {
                            if (IsOperator(c) == true)
                            {
                                while (stack.Count != 0 && OperatorWeight(stack.Peek()) >= OperatorWeight(c))
                                {
                                    outList.Add(stack.Pop());
                                }

                                stack.Push(c);
                            }

                            break;
                        }
                    }
                }
                else
                {
                    outList.Add(c);
                }
            }
            while (stack.Count != 0)
            {
                outList.Add(stack.Pop());
            }
            foreach (var t in outList)
            {
                Console.Write("{0}", t);
            }

            Console.ReadLine();
        }


        private static string PRNP(string data)
        {
            StringBuilder output = new StringBuilder();
            var decStack = new Stack<string>();

            bool isDecimal = false;

            foreach (char i in data)
            {
                if (i < 58 && i > 47)
                {
                    if (isDecimal)
                    {
                        string x = decStack.Pop().ToString() + i.ToString();
                        decStack.Push(x);
                    }
                    else
                    {
                        decStack.Push(i.ToString());
                        isDecimal = true;
                    }
                }
                else
                {
                    isDecimal = false;
                    switch (i)
                    {
                        case '+':
                        case '-':
                        case '*':
                        case '/':
                        case '^':
                            StringBuilder str = new StringBuilder();
                            string tmp = decStack.Pop().ToString();
                            try
                            {
                                str.Append('(').Append(decStack.Pop()).Append(i).Append(tmp).Append(')');
                            }
                            catch
                            {
                                return "Error";
                            }
                            decStack.Push(str.ToString());
                            break;
                        case ' ':
                            break;
                    }
                }
            }
            foreach (var i in decStack)
            {
                output.Append(i);
            }

            return output.ToString();
        }

        private static int OperatorWeight(string c)
        {
            switch (c)
            {
                case "^":
                    return 3;
                case "*":
                case "/":
                    return 2;
                case "+":
                case "-":
                    return 1;
                default:
                    return 0;
            }
        }

        private static bool IsOperator(string c)
        {
            return c == "+" || c == "-" || c == "*" || c == "/" || c == "^";
        }
    }
}
