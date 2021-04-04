using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Enyapo.API.Utility
{
    public class UserMessages
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="type">type=1:Success, type=2:Error, type=3:Warning</param>
        /// <param name="name_operation"> İşlemi yazınız örneğin Döküman silme</param>
        /// <returns></returns>
        public static object UserMessagesFunction(int type, string name_operation)//1 döküman ekleme
        {
            if (type == 1)//SUCCESS
                return new { message = name_operation + " işlemi başarıyla gerçekleştirildi.", type = 1 };

            if (type == 2)//ERROR
                return new { message = name_operation + " işlemi gerçekleştirilemedi.", type = 2 };

            else//WARNING
                return new { message = name_operation, type = 3 };
        }
    }
}
