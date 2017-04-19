using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Interfile.Framework.DAL;

namespace Interfile.Framework.Tests
{
    [TestClass]
    public class UnitOfWorkTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var context = new ServiceContext();
            var unitOfWork = new UnitOfWork(context);

            try
            {
                var log = new Model.LogCommunication
                {
                    Result = "OK",
                    Success = true,
                    CommunicationType = Model.Enum.CommunicationType.SMS,
                    ServiceID = 1,
                    Message = "Hello Monike!",
                    InsertDate = DateTime.Now
                };

                unitOfWork.LogsCommunication.Add(log);
                unitOfWork.SaveChanges();

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                unitOfWork.SaveChanges();
            }
        }
    }
}
