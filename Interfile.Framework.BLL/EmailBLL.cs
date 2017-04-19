using Interfile.Framework.DAL;
using Interfile.Framework.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Interfile.Framework.BLL
{
    public class EmailBLL
    {
        
        public ApiResult SendMail(string emailFrom, string emailTo, string emailBody, string emailSubject, string emailCC = "", string emailBcc = "", string Anexo = "" ) //Parametros
        {
            var unitOfWork = new UnitOfWork(new ServiceContext());
            try
            {
                #region Validações
                if (string.IsNullOrWhiteSpace(emailFrom) || string.IsNullOrWhiteSpace(emailTo))
                {
                    throw new Exception("emailFrom e emailTo não podem ser vazios");
                }

                string[] arrEmailFrom = emailFrom.Replace(",", ";").Split(";".ToCharArray());
                string[] arrEmailTo = emailTo.Replace(",", ";").Split(";".ToCharArray());

                foreach (var email in arrEmailFrom)
                {
                    if (string.IsNullOrWhiteSpace(email))
                    {
                        throw new Exception("emailFrom inválido");
                    }
                }

                foreach (var email in arrEmailTo)
                {
                    if (string.IsNullOrWhiteSpace(email))
                    {
                        throw new Exception("emailTo inválido");
                    }
                }
                #endregion

                #region Fluxo principal

                MailMessage objEmail = new MailMessage();

                objEmail.From = new MailAddress(emailFrom); // Remetente
                objEmail.To.Add(emailTo); //Destinario
                if (!string.IsNullOrWhiteSpace(emailCC))
                {
                    objEmail.CC.Add(emailCC); // email copia
                }
                if (!string.IsNullOrWhiteSpace(emailBcc))
                {
                    objEmail.Bcc.Add(emailBcc); //Copia oculta
                }
                objEmail.Priority = MailPriority.Normal; // Prioridade do e-mail
                objEmail.IsBodyHtml = true; //define o formato do e-mail em html
                objEmail.Subject = emailSubject; // emailSubject; // assunto do e-mail
                objEmail.Body = emailBody;  // emailBody; // Corpo do Email
                if (!string.IsNullOrWhiteSpace(Anexo))
                {
                    objEmail.Attachments.Add(new Attachment(Anexo)); // Anexo 
                }
                objEmail.SubjectEncoding = System.Text.Encoding.GetEncoding("ISO-8859-1"); // Enconding
                objEmail.BodyEncoding = System.Text.Encoding.GetEncoding("ISO-8859-1"); // Enconding
                //configuração do servidor SMTP
                SmtpClient objSmtp = new SmtpClient(); // Cconfig SMTP
                objSmtp.Host = "0000"; // servidor SMTP
                objSmtp.Port = 21; // 25// porta SMTP
                objSmtp.EnableSsl = false; // Definir SSL parão como false

                objSmtp.Send(objEmail);


                #endregion

                #region Retorno
                return new ApiResult
                {
                    Data = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"),
                    Status = Model.Enum.ApiReturnStatus.Success,
                    SuccessMessage = "Seu email foi enviado"

                };
                #endregion

            }
            catch (Exception ex)
            {
                unitOfWork.LogsCommunication.Add(new LogCommunication
                {
                    CommunicationType = Model.Enum.CommunicationType.Email,
                    Result = ex.Message,
                    Success = false,
                    ServiceID = 1
                });

                return new ApiResult
                {
                    Data = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"),
                    Status = Model.Enum.ApiReturnStatus.Error,
                    ErrorMessage = "Não foi possível enviar email"
                };
            }
        }
    }

}
