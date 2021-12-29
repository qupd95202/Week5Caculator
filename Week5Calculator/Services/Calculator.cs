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
        /// 計算 [把字串轉成物件，再轉成後序式]
        /// </summary>
        /// <param name="input">中序運算式</param>
        /// <returns></returns>
        public static double Solve(string input)
        {
            List<Object> objectList = TransToPostfix(TransToOperator(input));
            Stack<double> stack = new Stack<double>();
            foreach (var item in objectList)
            {   //數字放進數字專用stack
                if (item is double number)
                {
                    stack.Push(number);
                }
                else if (item is Operator @operator)
                {   //遇到運算子就依照各個運算子的運算方法，取前兩個數字做運算(後序式定義)
                    double[] parameters = new double[2];
                    for (int i = parameters.Length - 1; i >= 0; i--)
                    {
                        parameters[i] = stack.Pop();
                    }
                    //算完放回數字專用stack
                    stack.Push(@operator.Operate(parameters));
                }
            }
            return stack.Peek();
        }


        /// <summary>
        /// 轉後序式
        /// </summary>
        /// <param name="input">中序運算式</param>
        /// <returns></returns>
        private static List<Object> TransToPostfix(List<Object> input)
        {
            List<Object> objectList = new List<object>();
            Stack<Operator> tempStack = new Stack<Operator>();
            foreach (object item in input)
            {
                if (item is double number)
                {
                    objectList.Add(number);
                }

                if (item is Operator @operator)
                {   
                    //遇到右括號時
                    if (@operator.GetType() == typeof(RightBracketOperator))
                    {   
                        //存起來的運算子都丟過去
                        while (tempStack.Peek().GetType() != typeof(LeftBracketOperator))
                        {
                            objectList.Add(tempStack.Pop());
                        }
                        // 移除左括號
                        tempStack.Pop();
                    }
                    //優先順序，大者直接進運算式
                    else if (tempStack.Count == 0 || @operator.Priority > tempStack.Peek().Priority || tempStack.Peek().GetType() == typeof(LeftBracketOperator))
                    {
                        tempStack.Push(@operator);
                    }
                    else
                    {   //小或等於，則交換位置【迴圈直到最小運算子在stack最前端】
                        while (tempStack.Count != 0 && @operator.Priority <= tempStack.Peek().Priority)
                        {
                            objectList.Add(tempStack.Pop());
                        }
                        tempStack.Push(@operator);
                    }
                }
            }
            //將剩餘的運算子丟出
            while (tempStack.Count > 0)
            {
                objectList.Add(tempStack.Pop());
            }
            return objectList;
        }


        /// <summary>
        /// string轉成物件
        /// </summary>
        /// <param name="input">字串</param>
        /// <returns></returns>
        private static List<Object> TransToOperator(string exp)
        {
            List<Object> objectList = new List<object>();
            string tempValue = string.Empty;
            foreach (char c in exp)
            {   
                //數字連起來
                if (Sign.IsNumeric(c))
                {
                    tempValue += c;
                }
                else
                {   //數字丟進去算式
                    if (tempValue != string.Empty)
                    {
                        double result;
                        double.TryParse(tempValue, out result);
                        objectList.Add(result);
                        tempValue = string.Empty;
                    }
                    //運算子丟進算式
                    objectList.Add(OperatorFactory.GetOperator(c));
                }
            }
            //最後有數字丟數字回去算式
            if (tempValue != string.Empty)
            {
                double result;
                double.TryParse(tempValue, out result);
                objectList.Add(result);
            }
            return objectList;
        }
    }
}
