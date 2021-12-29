using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Week5Calculator.Operators
{
    /// <summary>
    /// 除法運算
    /// </summary>
    internal class DivisionOperator : Operator
    {
        internal DivisionOperator()
        {
            Priority = Operators.Priority.DIVISION;
            Sign = Operators.Sign.DIVISION_SIGN;
        }

        /// <summary>
        /// 執行除法計算
        /// </summary>
        /// <param name="nums">參與運算的運算元</param>
        /// <returns>運算結果</returns>
        public override double Operate(double[] nums)
        {
            if (nums[1] == 0)
            {
                throw new DivideByZeroException("無法除以 0");
            }
            return nums[0] / nums[1];
        }
    }
}
