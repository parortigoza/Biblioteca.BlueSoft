using Biblioteca.Models.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteca.Models.Data
{
    public class Log4Net: IServiceLog4Net
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="error"></param>
        public void EscribeLog4Net(string error)
        {
            log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            log.Error(error);
        }
    }
}
