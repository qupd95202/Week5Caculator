using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Week5Calculator.Operators
{
    /// <summary>
    /// 存全域常數
    /// </summary>
    public class Sign
    {
        /// <summary>
        /// 加法符號
        /// </summary>
        public const char ADDITION_SIGN = '+';

        /// <summary>
        /// 減法符號
        /// </summary>
        public const char SUBTRACTION_SIGN = '-';

        /// <summary>
        /// 乘法符號
        /// </summary>
        public const char MULTIPLICATION_SIGN = '*';

        /// <summary>
        /// 除法符號
        /// </summary>
        public const char DIVISION_SIGN = '/';

        /// <summary>
        /// 左括弧符號
        /// </summary>
        public const char LEFT_BRACKET_SIGN = '(';

        /// <summary>
        /// 右括弧符號
        /// </summary>
        public const char RIGHT_BRACKET_SIGN = ')';

        /// <summary>
        /// 判斷是否是數字
        /// </summary>
        /// <param name="input">傳入的字元</param>
        /// <returns></returns>
        public static bool IsNumeric(char input)
        {
            if (input == RIGHT_BRACKET_SIGN || input == LEFT_BRACKET_SIGN || input == DIVISION_SIGN
                || input == ADDITION_SIGN || input == SUBTRACTION_SIGN || input == MULTIPLICATION_SIGN)
            {
                return false;
            }
            return true;
        }
    }
}
