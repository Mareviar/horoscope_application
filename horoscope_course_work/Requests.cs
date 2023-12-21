using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace horoscope_course_work
{
    class Requests
    {
        public string name = "",
        request_log = "SELECT * FROM [dbo].[USERS] WHERE [login] = '",
        request_log_hash = "' AND [password] = '",
        request_hash = "SELECT * FROM [dbo].[USERS] WHERE [password] = '",
        request_with_sign = "INSERT INTO [dbo].[USERS] VALUES ('",
        request_counter = "UPDATE [USERS] SET COUNTER=COUNTER-1 WHERE [login] = '",
        
        reqest_change = "UPDATE [USERS] SET PASSWORD = '";
    }
}
