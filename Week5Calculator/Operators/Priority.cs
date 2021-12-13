using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Week5Calculator.Operators
{
    /// <summary>
    /// 運算優先權
    /// </summary>
    public class Priority
    {
        /// <summary>
        /// 乘法優先權
        /// </summary>
        internal const int MULTIPLICATION = 1;

        /// <summary>
        /// 除法優先權
        /// </summary>
        internal const int DIVISION = 1;

        /// <summary>
        /// 加法優先權
        /// </summary>
        internal const int ADDITION = 0;

        /// <summary>
        /// 減法優先權
        /// </summary>
        internal const int SUBTRACTION = 0;

        /// <summary>
        /// 左括弧優先權
        /// </summary>
        internal const int LEFT_BRACKET = int.MaxValue;

        /// <summary>
        /// 右括弧優先權
        /// </summary>
        internal const int RIGHT_BRACKET = int.MinValue;
    }
}
