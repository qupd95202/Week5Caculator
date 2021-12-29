using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Week5Calculator.Operators
{
    /// <summary>
    /// 創建並提供 Operator
    /// </summary>
    public static class OperatorFactory
    {
        private static Dictionary<char, Operator> Operators;

        /// <summary>
        /// 初始化時創建所有 operator
        /// </summary>
        static OperatorFactory()
        {
            Operators = new Dictionary<char, Operator>()
            {
                {Sign.ADDITION_SIGN, new AdditionOperator()},
                {Sign.SUBTRACTION_SIGN, new SubtractionOperator()},
                {Sign.MULTIPLICATION_SIGN, new MultiplicationOperator()},
                {Sign.DIVISION_SIGN, new DivisionOperator()},
                {Sign.LEFT_BRACKET_SIGN, new LeftBracketOperator()},
                {Sign.RIGHT_BRACKET_SIGN, new RightBracketOperator()},
            };
        }

        /// <summary>
        /// 字元轉物件
        /// </summary>
        /// <param name="operatorSign">輸入的字元</param>
        /// <returns>物件</returns>
        public static Operator GetOperator(char operatorSign)
        {
            return Operators[operatorSign];
        }
    }
}
