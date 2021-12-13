using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Week5Calculator.Parameters;
using Week5Calculator.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Week5Calculator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {
        /// <summary>
        /// 計算機服務
        /// </summary>
        private readonly CalculatorService service;
        public CalculatorController(CalculatorService service)
        {
            this.service = service;
        }

        /// <summary>
        /// 取得ID
        /// </summary>
        /// <returns>ID</returns>
        // GET api/<CalculatorController>/
        [HttpGet("UserID")]
        public UserID GetUserID()
        {
            return new UserID(service.CreatUserID());
        }

        /// <summary>
        /// 得到答案
        /// </summary>
        /// <remarks>
        /// Here is a sample remarks placeholder.
        /// </remarks>
        /// <param name="id">用戶</param>
        /// <returns>螢幕顯示</returns>
        // GET api/<CalculatorController>/
        [HttpGet("Answer/{id}")]
        public ActionResult GetAnswer(string id)
        {
            var result = service.GetAnser(id);
            if (result.Result != null)
            {
                return result.Result;
            }
            return Ok($"螢幕顯示:{result.Value}");
        }

        /// <summary>
        /// 輸入指令
        /// </summary>
        /// <param name="id">用戶</param>
        /// <param name="command">指令</param>
        /// <returns>目前運算結果</returns>
        // POST api/<CalculatorController>
        [HttpPost("Command/{id}")]
        public ActionResult PostNumber(string id, [FromBody] InputCommandParameter command)
        {
            var result = service.Input(id, command.InputCommand);
            if (result.Result != null)
            {
                return NotFound();
            }
            return Ok($"目前輸入的運算式:{result.Value}");
        }


        /// <summary>
        /// 清空
        /// </summary>
        /// <param name="id">用戶</param>
        /// <returns>清空結果</returns>
        // PUT api/<CalculatorController>/
        [HttpPut("C/{id}")]
        public ActionResult CleanAllCommands(string id)
        {
            return service.Clear(id);
        }

        /// <summary>
        /// 刪除最後一個指令
        /// </summary>
        /// <param name="id">用戶</param>
        /// <returns>刪除結果</returns>
        // DELETE api/<CalculatorController>/5
        [HttpDelete("OneCommand/{id}")]
        public ActionResult DeleteOneCommand(string id)
        {
            var result = service.DeleteOne(id);
            if (result.Result != null)
            {
                return NotFound();
            }
            return Ok($"目前輸入的運算式:{result.Value}");
        }
    }
}
