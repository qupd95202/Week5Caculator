using Microsoft.VisualStudio.TestTools.UnitTesting;
using Week5Calculator.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Week5Calculator.Services.Tests
{
    [TestClass()] //
    public class CalculatorServiceTests
    {
        private CalculatorService testService = new CalculatorService();

        /// <summary>
        /// 沒有此ID的時候
        /// </summary>
        [TestMethod()]
        public void InputTest()
        {

            string userID = "user17";
            string teseString = "1";

            Assert.AreEqual(testService.Input(userID, teseString).Result.GetType(), typeof(NotFoundResult));
        }

        /// <summary>
        /// 傳入字串是否成功
        /// </summary>
        [TestMethod()]
        public void InputTest2()
        {
            string userID = "user1";
            string teseString = "1";

            testService.CreatUserID();


            Assert.AreSame(testService.Input(userID, teseString).Value, "1");
        }

        /// <summary>
        /// 刪除前一個指令
        /// </summary>
        [TestMethod()]
        public void DeleteOneTest()
        {
            testService.CreatUserID();
            testService.Input("user1", "1+5+7-34");

            Assert.AreEqual(testService.DeleteOne("user1").Value, "1+5+7-3");
        }

        /// <summary>
        /// 若沒指令時刪除前一個指令，結果應該要一樣
        /// </summary>
        [TestMethod()]
        public void DeleteOneTest2()
        {
            testService.CreatUserID();
            testService.Input("user1", "");

            Assert.AreEqual(testService.DeleteOne("user1").Value, "");
        }

        /// <summary>
        /// 測試括號
        /// </summary>
        [TestMethod()]
        public void CalculateTest1()
        {
            //arrange
            string test1 = "1*(5+3)";

            Assert.AreEqual(testService.Calculate(test1).Value, 8);
        }

        /// <summary>
        /// 測試不符合規範值之值1
        /// </summary>
        [TestMethod()]
        public void CalculateTest2()
        {

            string test2 = "++3--";

            Assert.AreEqual(testService.Calculate(test2).Result.GetType(), typeof(BadRequestResult));
        }

        /// <summary>
        /// 測試不符合規範值之值2
        /// </summary>
        [TestMethod()]
        public void CalculateTest3()
        {

            string test3 = "-";

            Assert.AreEqual(testService.Calculate(test3).Result.GetType(), typeof(BadRequestResult));
        }

        /// <summary>
        /// 測試一般四則運算
        /// </summary>
        [TestMethod()]
        public void CalculateTest4()
        {
            string test4 = "3*(4+3*(3-6))-2*(3-4)-0.2";

            Assert.AreEqual(testService.Calculate(test4).Value, -13.2);
        }

        /// <summary>
        /// 測試一般四則運算
        /// </summary>
        [TestMethod()]
        public void CalculateTest5()
        {
            string test5 = "7*8*3/2*0.7";

            Assert.AreEqual(testService.Calculate(test5).Value, 58.8);
        }

    }
}