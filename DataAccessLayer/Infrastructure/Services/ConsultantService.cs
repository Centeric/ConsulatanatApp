using LawyerApp.DataAccessLayer.Infrastructure.IServices;
using LawyerApp.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawyerApp.DataAccessLayer.Infrastructure.Services
{
    public class ConsultantService : IConsultantService
    {
        public IUnitOfWork _unitOfWork;
        public ConsultantService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> Create(Consultant consultant)
        {
            if (consultant != null)     
            {
                await _unitOfWork.Consultants.Add(consultant);

                var result = _unitOfWork.Save();

                if (result > 0)
                    return true;
                else
                    return false;
            }
            return false;
        }

        //public Task<bool> DeleteProduct()
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<IEnumerable<Consultant>> GetAll()
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<Consultant> GetConsultantById()
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<bool> UpdateProduct(Consultant consultant)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
