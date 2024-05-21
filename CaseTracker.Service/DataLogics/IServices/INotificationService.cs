using CaseTracker.DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseTracker.Service.DataLogics.IServices
{
    public interface INotificationService
    {
        Task CreateNotificationAsync(string title, string body);
    }
}
