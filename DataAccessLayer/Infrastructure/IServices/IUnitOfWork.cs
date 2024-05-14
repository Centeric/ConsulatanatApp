using LawyerApp.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawyerApp.DataAccessLayer.Infrastructure.IServices
{
    public interface IUnitOfWork:IDisposable
    {
        IConsultantRepository Consultants { get; }
        IAuthRepository Users { get; }
        INextStepsRepository NextSteps { get; }
        ICommunicationUpdateRepository CommunicationUpdates { get; }

     
        int Save();
    }
}
