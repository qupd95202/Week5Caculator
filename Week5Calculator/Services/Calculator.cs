using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Week5Calculator.Operators;

namespace Week5Calculator.Services
{
    public class Calculator
    {
        /// <summary>
        /// 先乘除、後加減、括號先算
        /// </summary>
        /// <param name="expr">輸入的運算式</param>
        /// <returns>結果</returns>
        public static double Evaluate(string expr)
        {
            //儲存運算式
            Stack<string> mainStack = new Stack<string>();
            //儲存乘除專用
            Stack<string> subStack = new Stack<string>();
            //運算子們
            string operators = "+-*/";
            //暫存值
            string tempValue = "";
            for (int i = 0; i < expr.Length; i++)
            {
                string currentString = expr.Substring(i, 1);

                //如果是運算子，且暫存值有東西，把運算子丟進stack
                if (operators.Contains(currentString) && tempValue != "")
                {   
                    //有乘除時先算
                    if (subStack.Count != 0)
                    {
                        subStack.Push(tempValue);
                        mainStack.Push(Calculate(subStack).ToString());
                        tempValue = "";
                    }
                    else
                    {
                        mainStack.Push(tempValue);
                        tempValue = "";
                    }
                }

                //遇到括號
                if (currentString.Equals("("))
                {
                    string innerExp = ""; //括號內的運算式
                    i++;
                    int bracketCount = 0; //括號數量
                    for (; i < expr.Length; i++)
                    {
                        currentString = expr.Substring(i, 1); //下一個字元

                        if (currentString.Equals("("))
                        {
                            bracketCount++;
                        }

                        if (currentString.Equals(")"))
                        {
                            if (bracketCount == 0)
                            {
                                break;
                            }

                            else
                            {
                                bracketCount--;
                            }
                        }
                        innerExp += currentString;
                    }

                    if (subStack.Count != 0)
                    {
                        tempValue += Evaluate(innerExp).ToString(); //遞迴傳進暫存值
                    }
                    else
                    {
                        mainStack.Push(Evaluate(innerExp).ToString()); //遞迴傳進stack
                    }
                }
                //加減運算子直接放
                if (currentString.Equals("+") || currentString.Equals("-"))
                {
                    mainStack.Push(currentString);
                }
                //乘除運算子放優先處理的stack的
                else if (currentString.Equals("*") || currentString.Equals("/"))
                {
                    subStack.Push(mainStack.Pop());
                    subStack.Push(currentString);
                }
                //最後一個為括號
                else if (currentString.Equals(")"))
                {
                    if (i == (expr.Length - 1))
                    {
                        if (subStack.Count != 0)
                        {
                            subStack.Push(tempValue);
                            mainStack.Push(Calculate(subStack).ToString());
                        }
                        else
                        {
                            mainStack.Push(tempValue);
                        }
                    }
                }
                //數字
                else if (Regex.IsMatch(currentString, "^[\\d.]$"))
                {
                    tempValue += currentString;

                    //最後一個
                    if (i == (expr.Length - 1))
                    {
                        if (subStack.Count != 0)
                        {
                            subStack.Push(tempValue);
                            mainStack.Push(Calculate(subStack).ToString());
                        }
                        else
                        {
                            mainStack.Push(tempValue);
                        }
                    }
                }
            }
            return Calculate(mainStack);
        }

        /// <summary>
        /// 計算邏輯
        /// </summary>
        /// <param name="input">運算式</param>
        /// <returns></returns>
        private static double Calculate(Stack<string> input)
        {
            double result = 0;
            //倒著取出放進另一個stack，以求由左至右
            Stack<string> reverse = new Stack<string>();
            while (input.Count != 0)
            {
                reverse.Push(input.Pop());
            }

            //取出數字+運算子+數字的規律來計算，並放回去stack
            while (reverse.Count >= 3)
            {

                double left = Convert.ToDouble(reverse.Pop());
                string op = reverse.Pop();
                double right = Convert.ToDouble(reverse.Pop());

                if (op == "+")
                {
                    result = left + right;
                }
                else if (op == "-")
                {
                    result = left - right;
                }
                else if (op == "*")
                {
                    result = left * right;
                }
                else if (op == "/")
                {
                    result = left / right;
                }
                reverse.Push(result.ToString());
            }
            return Convert.ToDouble(reverse.Pop());
        }
    }
}
