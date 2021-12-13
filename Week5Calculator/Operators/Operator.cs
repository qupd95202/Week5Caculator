using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Week5Calculator.Operators
{
    /// <summary>
    /// 運算子抽象類別
    /// </summary>
    public abstract class Operator
    {
        /// <summary>
        /// 運算子的優先權
        /// </summary>
        internal int Priority { get; set; }

        /// <summary>
        /// 運算子符號
        /// </summary>
        internal char Sign { get; set; }

        /// <summary>
        /// 執行運算抽象函式
        /// </summary>
        /// <param name="nums">參與運算的運算元</param>
        /// <returns>運算結果</returns>
        public abstract decimal Operate(params decimal[] nums);

        /// <summary>
        /// 回傳運算符號
        /// </summary>
        /// <returns>運算符號</returns>
        public override string ToString()
        {
            return Sign.ToString();
        }
    }
}
