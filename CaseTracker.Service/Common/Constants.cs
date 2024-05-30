using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseTracker.Service.Common
{
    public static class Constants
    {
        public const string Error = "Error in process";
        public const string IdNotFound = "Id not found.";
        public const string DataLoaded = "Data Loaded successfully.";
        public const string Added = "Data entered successfully";
        public const string NotAdded = "Data not entered successfully";
        public const string Deleted = "Data deleted successfully.";
        public const string Updated = "Data updated successfully.";
        public const string NotUpdated = "Data not updated successfully.";
        public const string DataNotFound = "Data Not Found";
        public const string EnterData="Please Enter Data";
        public const string NotificationLoad="Notification Load Successfully";
        public const string NotificationL = "Notification Load Successfully";
        public const string NotAllowed = "ConsultationId is not Valid";


        public class _User
        {
            public const string LoggedIn = "User logged in successfully!";
            public const string EmailError = "Email not found.";
            public const string PasswordError = "Incorrect password.";
        }
        public class _ConsultantStatus
        {
            public const string StatusPending="Pending";
            public const string StatusCompleted="Completed";
            public const string StatusOnGoing="On-Going";
            public const string StatusDocument = "Awaiting Return Of Documents";
            public const string UpdatedPayment = "Awaiting Payment";
        }
    }
}
