﻿using DataAccessLayer;
using LawyerApp.DataAccessLayer.Infrastructure.IServices;
using LawyerApp.Models.Model;
using LawyerApp.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawyerApp.DataAccessLayer.Infrastructure.Services
{
    public class AuthRepository : Repository<User>, IAuthRepository
    {
        public AuthRepository(ApplicationDbContext context) : base(context) { }
    }
}
