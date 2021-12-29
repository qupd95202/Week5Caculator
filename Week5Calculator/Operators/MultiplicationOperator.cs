using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Week5Calculator.Operators
{
    /// <summary>
    /// 乘法運算
    /// </summary>
    internal class MultiplicationOperator : Operator
    {
        internal MultiplicationOperator()
        {
            Priority = Operators.Priority.MULTIPLICATION;
            Sign = Operators.Sign.MULTIPLICATION_SIGN;
        }

        /// <summary>
        /// 執行乘法計算
        /// </summary>
        /// <param name="nums">參與運算的運算元</param>
        /// <returns>運算結果</returns>
        public override double Operate(double[] nums)
        {
            return nums[0] * nums[1];
        }
    }
}
