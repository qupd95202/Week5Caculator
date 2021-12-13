using System.Linq;
using NCalc;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Concurrent;

namespace Week5Calculator.Services
{
    public class CalculatorService
    {
        /// <summary>
        /// 紀錄是誰輸入、輸入什麼、結果是什麼
        /// </summary>
        private ConcurrentDictionary<string, CommandAndValue> userRecord = new ConcurrentDictionary<string, CommandAndValue>();
        /// <summary>
        /// 使用者流水號
        /// </summary>
        private int id = 0;
        private const int USER_UP_LIMIT = 10;

        /// <summary>
        /// 輸入指令
        /// </summary>
        /// <param name="userID">用戶</param>
        /// <param name="input">指令</param>
        /// <returns>當前指令</returns>
        public ActionResult<string> Input(string userID, string input)
        {
            if (!userRecord.ContainsKey(userID))
            {
                return new NotFoundResult();
            }

            char lastChar = userRecord[userID].Command.LastOrDefault();

            if (input != null && input == "+" || input == "-" || input == "*" || input == "/" || input == ".") //連續輸入運算子會取代
            {
                if (lastChar == '+' || lastChar == '-' || lastChar == '*' || lastChar == '/' || lastChar == '.')
                {
                    DeleteOne(userID);
                }
            }
            lock (userRecord)
            {
                userRecord[userID].Command += input;
            }

            return userRecord[userID].Command;
        }

        /// <summary>
        /// 執行計算
        /// </summary>
        /// <param name="userID">用戶</param>
        private ActionResult<double> ExcuteCalculation(string userID)
        {
            var userCommandValue = userRecord[userID];
            string inputCommand;

            if (userCommandValue.Command == "") //指令為空白時，顯示為原本計算結果
            {
                if (userCommandValue.Value < 0)
                {
                    inputCommand = $"0{userCommandValue.Value}";
                }
                else
                {
                    inputCommand = $"{userCommandValue.Value}";
                }
            }
            else if (Regex.IsMatch(userCommandValue.Command, "^[\\+\\-\\*\\/]")) //運算子開頭，就要加上原本計算結果；反之直接算
            {
                if (userCommandValue.Value < 0)
                {
                    inputCommand = $"(0-{userCommandValue.Value * -1}){userCommandValue.Command}";
                }
                else
                {
                    inputCommand = $"{userCommandValue.Value}{userCommandValue.Command}";
                }
            }
            else
            {
                inputCommand = $"{userCommandValue.Command}";
            }

            if (Regex.IsMatch(inputCommand, "[\\+\\-\\*\\/\\.\\(\\)]$")) //運算子結尾就按等於的，刪除最後一個運算子
            {
                DeleteOne(userID);
            }

            var result = Calculate(inputCommand);
            if (result.Result != null)
            {
                return new BadRequestObjectResult("指令有誤");
            }
            else
            {
                userCommandValue.Value = result.Value;
                lock (userRecord)
                {
                    userRecord[userID].Command = "";
                }
                return userCommandValue.Value;
            }
        }

        /// <summary>
        /// 計算過程
        /// </summary>
        /// <param name="command">指令</param>
        /// <returns>計算結果</returns>
        public ActionResult<double> Calculate(string command)
        {
            Expression e = new Expression(command);
            //StringToFormula stringToFormula = new StringToFormula();
            if (e.HasErrors())
            {
                return new BadRequestResult();
            }

            return Calculator.Evaluate(command);
        }

        /// <summary>
        /// = 鍵
        /// </summary>
        /// <param name="userID">用戶</param>
        /// <returns>計算結果</returns>
        public ActionResult<double> GetAnser(string userID)
        {
            if (!userRecord.ContainsKey(userID))
            {
                return new NotFoundResult();
            }
            return ExcuteCalculation(userID);
        }

        /// <summary>
        /// 清空
        /// </summary>
        /// <param name="userID">用戶</param>
        /// <returns>結果</returns>
        public ActionResult Clear(string userID)
        {
            if (userRecord.ContainsKey(userID))
            {
                lock (userRecord)
                {
                    userRecord[userID].Command = "";
                    userRecord[userID].Value = 0;
                }
                return new NoContentResult();
            }
            return new NotFoundResult();
        }

        /// <summary>
        /// 刪除最後一個指令
        /// </summary>
        /// <param name="userID">用戶</param>
        /// <returns>結果</returns>
        public ActionResult<string> DeleteOne(string userID)
        {
            if (!userRecord.ContainsKey(userID))
            {
                return new NotFoundResult();
            }
            if (userRecord[userID].Command != "")
            {
                int lastIndex = userRecord[userID].Command.Length - 1;
                userRecord[userID].Command = userRecord[userID].Command.Remove(lastIndex, 1);
            }
            return userRecord[userID].Command;
        }

        /// <summary>
        /// 創建用戶
        /// </summary>
        /// <param name="userID">用戶id</param>
        public string CreatUserID()
        {
            if (id < USER_UP_LIMIT)
            {
                id++;
            }
            else
            {
                id = 1;
            }

            var userID = $"user{id}";
            if (userRecord.ContainsKey(userID))
            {
                lock (userRecord)
                {
                    userRecord[userID] = new CommandAndValue();
                }
            }
            else
            {
                userRecord.TryAdd(userID, new CommandAndValue());
            }
            return userID;
        }
    }
}
