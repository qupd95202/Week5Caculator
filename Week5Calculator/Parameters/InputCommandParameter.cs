using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Week5Calculator.ValidationAttributes;

namespace Week5Calculator.Parameters
{   
    //指令參數
    public class InputCommandParameter
    {   
        [Command]
        public string InputCommand { get; set; }
    }
}
