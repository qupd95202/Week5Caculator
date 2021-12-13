using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Week5Calculator.ValidationAttributes
{
    /// <summary>
    /// 驗證輸入的指令格式
    /// </summary>
    public class CommandAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var command = (string)value;
            if (!Regex.IsMatch(command, "^[\\+\\-\\*\\/\\.\\d\\(\\)]$"))
            {
                return new ValidationResult("格式有錯，僅能輸入【+-*/.()】和數字，且一次只能輸入一個字元");
            }
            return ValidationResult.Success;
        }
    }
}
