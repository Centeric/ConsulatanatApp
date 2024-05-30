using CaseTracker.DataAccessLayer.DataContext;
using CaseTracker.DataAccessLayer.IDataServices;
using CaseTracker.DataAccessLayer.Models;
using CaseTracker.DataAccessLayer.Responses;
using CaseTracker.Service.Common;
using CaseTracker.Service.DataLogics.IServices;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseTracker.Service.DataLogics.Services
{
    public class NotificationService : INotificationService
    {
        private readonly INotificationRepo _notificationRepo;
        private readonly ApplicationDbContext _context;
        public NotificationService(INotificationRepo notificationRepo, ApplicationDbContext context)
        {
            _notificationRepo = notificationRepo;
            _context = context;
        }
        public async Task CreateNotificationAsync(string consultationId, string title, string body)
        {
            try
            {
                var notification = new Notifications
                {
                    
                    ConsultationId = consultationId,
                    Title = title,
                    Body = body,
                    NotificationDate = DateOnly.FromDateTime(DateTime.UtcNow),
                    IsSeen = false
                };

                await _context.Notification.AddAsync(notification);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                Result.Failure(Constants.Error, "Failed to create notification.");
            }
        }
        //public async Task CreateNotificationAsync(int consultantId, string title, string body)
        //{
        //    try
        //    {
        //        var notification = new Notification
        //        {
        //            ConsultantId = consultantId,
        //            Title = title,
        //            Body = body,
        //            NotificationDate = DateOnly.FromDateTime(DateTime.UtcNow),
        //            IsSeen = false
        //        };

        //        await _context.Notifications.AddAsync(notification);
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (Exception ex)
        //    {
        //        Result.Failure(Constants.Error, "Failed to create notification."); // Handle exception appropriately

        //    }
        //}

    }
}
