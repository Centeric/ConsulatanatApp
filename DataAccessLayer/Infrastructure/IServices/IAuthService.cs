﻿using LawyerApp.Models.Model;
using LawyerApp.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawyerApp.DataAccessLayer.Infrastructure.IServices
{
    public interface IAuthService
    {
        Task<bool> Add(User user);
        Task<LoginView> Login(string email, string password);
    }
}
