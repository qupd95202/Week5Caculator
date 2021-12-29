using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Week5Calculator.Operators
{
    /// <summary>
    /// 右括號運算子
    /// </summary>
    internal class RightBracketOperator : Operator
    {
        internal RightBracketOperator()
        {
            Sign = Operators.Sign.RIGHT_BRACKET_SIGN;
            Priority = Operators.Priority.RIGHT_BRACKET;
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
