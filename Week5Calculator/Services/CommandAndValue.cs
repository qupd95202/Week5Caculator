using NCalc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Week5Calculator.Services
{
    /// <summary>
    /// 輸入之指令和運算結果
    /// </summary>
    public class CommandAndValue
    {
        public CommandAndValue()
        {
            Command = "";
            Value = 0;
        }

        public string Command { get; set; }

        public double Value { get; set; }
    }
}
