using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Week5Calculator.Operators
{
    /// <summary>
    /// 減法運算
    /// </summary>
    public class SubtractionOperator : Operator
    {
        public SubtractionOperator()
        {
            Priority = Operators.Priority.SUBTRACTION;
            Sign = Operators.Sign.SUBTRACTION_SIGN;
        }

        /// <summary>
        /// 執行減法計算
        /// </summary>
        /// <param name="nums">運算元</param>
        /// <returns>運算結果</returns>
        public override double Operate(double[] nums)
        {
            return nums[0] - nums[1];
        }
    }
}
