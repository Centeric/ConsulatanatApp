using LawyerApp.DataAccessLayer.Infrastructure.IServices;
using LawyerApp.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawyerApp.CommonHelper.CustomGeneric
{
    public interface IGenericClass<T> : IRepository<T> where T : class
    {
        Task<Consultant> GetByConsultationId(string consultationId);
        Task<User> GetByEmail(string email);
    }
}

