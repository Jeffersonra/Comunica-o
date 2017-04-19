using HumanAPIClient.Model;
using HumanAPIClient.Service;
using Interfile.Framework.Model;
using System;
using System.Collections.Generic;
using Interfile.Framework.Util.String;
using Interfile.Framework.BLL.Properties;
using Interfile.Framework.DAL;

namespace Interfile.Framework.BLL
{
    public class SmsBLL
    {
        public ApiResult Send(string numberTo, string message, DateTime? date = null)

        {
            SimpleSending cliente = null;
            SimpleMessage simpleMessage = new SimpleMessage();
            var unitOfWork = new UnitOfWork(new ServiceContext());

            try
            {
                numberTo = numberTo.GetNumericChars();

                cliente = new SimpleSending(Settings.Default.ZenviaLogin, Settings.Default.ZenviaPassword);

                #region Validações
                if (string.IsNullOrWhiteSpace(numberTo) || string.IsNullOrWhiteSpace(message))
                {
                    throw new Exception("O numero e Menssagem não podem ser vazios");

                }
                if (!(numberTo.Length == 13))
                {
                    throw new Exception("O numero deve seguir o modelo 5511123456789 ");
                }

                #endregion

                #region Fluxo principal

                simpleMessage.To = numberTo;
                simpleMessage.Message = message;
                simpleMessage.Schedule = (date.HasValue ? date.Value.ToString() : DateTime.Now.ToString());

                List<String> retornos = cliente.send(simpleMessage);

                if (retornos == null || retornos.Count == 0)
                    throw new Exception("Não foi possível obter o retorno do serviço.");

                if (!retornos[0].Contains("000"))
                    throw new Exception(retornos[0]);

                //enviar sms 
                #endregion

                #region Log

                unitOfWork.LogsCommunication.Add(new LogCommunication
                {
                    CommunicationType = Model.Enum.CommunicationType.SMS,
                    Result = retornos[0],
                    Success = true,
                    ServiceID = 1
                });

                #endregion

                #region Retorno
                return new ApiResult
                {
                    Data = "Token",
                    Status = Model.Enum.ApiReturnStatus.Success,
                    SuccessMessage = "Sms foi enviado"                    
                };
                #endregion
            }
            catch (Exception ex)
            {
                unitOfWork.LogsCommunication.Add(new LogCommunication
                {
                    CommunicationType = Model.Enum.CommunicationType.SMS,
                    Result = ex.Message,
                    Success = false,
                    ServiceID = 1
                });

                return new ApiResult
                {
                    Status = Model.Enum.ApiReturnStatus.Error,
                    ErrorMessage = string.Format("Erro ao enviar SMS: {0}", ex.Message)
                };

            }
            finally
            {
                cliente = null;
                simpleMessage = null;

                unitOfWork.SaveChanges();

                unitOfWork.Dispose();
            }
        }
    }
}
