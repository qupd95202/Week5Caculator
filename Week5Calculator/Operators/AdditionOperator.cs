﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Week5Calculator.Operators
{
    /// <summary>
    /// 加法運算
    /// </summary>
    public class AdditionOperator : Operator
    {
        public AdditionOperator()
        {
            Priority = Operators.Priority.ADDITION;
            Sign = Operators.Sign.ADDITION_SIGN;
        }

        /// <summary>
        /// 執行加法計算
        /// </summary>
        /// <param name="nums">參與運算的運算元</param>
        /// <returns>運算結果</returns>
        public override double Operate(params double[] nums)
        {
            return nums[0] + nums[1];
        }
    }
}
