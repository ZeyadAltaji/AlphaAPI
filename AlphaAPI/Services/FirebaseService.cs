using FirebaseAdmin;
using FirebaseAdmin.Messaging;
using Google.Apis.Auth.OAuth2;
using System.Collections.Generic;
using System;
using System.IO;
using System.Threading.Tasks;
using static AlphaAPI.Controllers.AlphaHRController;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;

namespace AlphaAPI.Services
{
    public class FirebaseService
    {
        private readonly FirebaseApp _firebaseApp;
        private readonly FirebaseMessaging _firebaseMessaging;

        public FirebaseService ()
        {
            string wwwrootPath = Path.Combine(Directory.GetCurrentDirectory() , "wwwroot");
            string path = Path.Combine(wwwrootPath , "FcmNotification" , "gcesoft-78e0d-firebase-adminsdk-brzao-08a915fd84.json");

            _firebaseApp = FirebaseApp.Create(new AppOptions()
            {
                Credential = GoogleCredential.FromFile(path) ,
            });
            _firebaseMessaging = FirebaseMessaging.DefaultInstance;

        }
        public async Task<string> SendNotificationToTopicAsync (NotificationModel notification , string topic)
        {
            var response ="";
            //var message = new Message
            //{
            //    Notification = new Notification
            //    {
            //        Title = notification.Title ,
            //        Body = notification.Body,

            //    } ,
            //    Topic = topic

            //};

            //string response = await _firebaseMessaging.SendAsync(message);
            return response;
        }
        public async Task<object> SendNotificationVacationOrLeave (string CRR , int UsersTarget , long FID , short CompNo , int RequestType , short VacationOrLeave , int OwnerUser , string form , string ActionStat , string fDescAr , string EmpName)
        {
            string topic = $"/topics/hr-{CRR}-ClientNumber-{CompNo}-UsersTarget-{UsersTarget}";

            var notification = new NotificationModel
            {
                Title = "نظام الخدمة الذاتية" ,
                Body = fDescAr
            };

            // Use the fully qualified name for Message
            var message = new FirebaseAdmin.Messaging.Message
            {
                Notification = new FirebaseAdmin.Messaging.Notification
                {
                    Title = notification.Title ,
                    Body = notification.Body ,
                } ,
                Topic = topic ,
                Data = new Dictionary<string , string>
        {
            { "Type", CRR.ToLower() },
            { "EmpName", EmpName },
            { "FID", FID.ToString() },
            { "RequestType", RequestType.ToString() },
            { "VacationOrLeave", VacationOrLeave.ToString() },
            { "fDescAr", fDescAr },
            { "addDate", DateTime.Now.ToString("yyyy-MM-dd") },
            { "form", form }
        }
            };

            string response = await _firebaseMessaging.SendAsync(message);
            return response;
        }
    }
}
