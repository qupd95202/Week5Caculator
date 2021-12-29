using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Week5Calculator.Operators
{
    /// <summary>
    /// 左括號運算子
    /// </summary>
    internal class LeftBracketOperator : Operator
    {
        internal LeftBracketOperator()
        {
            Sign = Operators.Sign.LEFT_BRACKET_SIGN;
            Priority = Operators.Priority.LEFT_BRACKET;
        }

        /// <summary>
        /// 括號不需要計算
        /// </summary>
        /// <param name="nums">運算元</param>
        /// <returns>計算結果</returns>
        public override double Operate(params double[] nums)
        {
            throw new NotImplementedException();
        }
    }
}
