using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Week5Calculator.Parameters
{   
    public class UserID
    {
        public UserID(string userID)
        {
            this.userID = userID;
        }
        /// <summary>
        /// 用戶ID
        /// </summary>
        public string userID { get; set; }
    }
}
