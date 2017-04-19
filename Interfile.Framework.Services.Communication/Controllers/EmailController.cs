using Interfile.Framework.Model;
using System;
using System.Web.Http;
using Interfile.Framework.BLL;
using Interfile.Framework.DAL;

namespace Interfile.Framework.Services.Communication.Controllers
{


    public class EmailController : ApiController
    {
        [HttpGet]
        [Route("api/Email/SendMail")]
        public ApiResult SendMail(string emailFrom, string emailTo, string emailBody, string emailSubject, string emailCC="", string emailBcc="") //Parametros
        {
            try
            {
                #region Fluxo Principal
                EmailBLL emailBLL = new EmailBLL();
                ApiResult result = emailBLL.SendMail(emailFrom, emailTo, emailBody, emailSubject, emailCC, emailBcc);
                #endregion

                return result;


            }
            catch (Exception ex)
            {
                //logar o erro ex
                return new ApiResult
                {
                    Status = Model.Enum.ApiReturnStatus.Error,
                    ErrorMessage = "Não foi possível enviar email"
                };
            }
        }
    }
}
