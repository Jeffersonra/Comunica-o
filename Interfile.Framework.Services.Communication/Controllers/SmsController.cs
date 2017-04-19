using HumanAPIClient.Model;
using HumanAPIClient.Service;
using Interfile.Framework.Model;
using Interfile.Framework.Services.Communication.Properties;
using System;
using System.Collections.Generic;
using System.Web.Http;
using Interfile.Framework.Util.String;
using Interfile.Framework.DAL;
using Interfile.Framework.BLL;

namespace Interfile.Framework.Services.Communication.Controllers
{
    public class SmsController : ApiController
    {
        [HttpGet]
        [Route("api/Sms/Send")]

        public ApiResult Send(string numberTo, string message, DateTime? date = null)

        {
            SimpleSending cliente = null;
            SimpleMessage simpleMessage = new SimpleMessage();

            try
            {

                #region Fluxo principal

                SmsBLL smsBLL = new SmsBLL();

                ApiResult result = smsBLL.Send(numberTo, message, date);

                #endregion

                #region Retorno
                return result;
                #endregion
            }
            catch (Exception ex)
            {
                //using (EFContext context = new EFContext())
                //{
                //    context.LogsCommunication.Add(new LogCommunication
                //    {
                //        CommunicationType = Model.Enum.CommunicationType.SMS,
                //        Result = ex.Message,
                //        Success = false,
                //        ServiceID = 1
                //    });
                //    context.SaveChanges();
                //}

                return new ApiResult
                {
                    Status = Model.Enum.ApiReturnStatus.Error,
                    ErrorMessage = string.Format("Erro ao enviar SMS: {0}", ex.Message)
                };

            }
           
        }
    }

}
