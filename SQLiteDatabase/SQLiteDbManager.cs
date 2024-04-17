using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MauiTestApp.Models;
using MauiTestApp.Models.Login;
using MauiTestApp.Models.OTP;

namespace MauiTestApp.Database
{
    public static class SQLiteDbManager
    {
        public static SQLiteConnection _SQLiteConnection;
        public static void InitializeDatabase()
        {
            try
            {
                _SQLiteConnection = DependencyService.Get<ISQLiteDatabase>().GetConnection();
                _SQLiteConnection.CreateTable<SessionUser>();
                _SQLiteConnection.CreateTable<LoginResponseResult>();
                //_SQLiteConnection.CreateTable<OTPAccessTokenCreateResponse>();
                _SQLiteConnection.CreateTable<ChangeVerificationMethodRequest>();
                _SQLiteConnection.CreateTable<VerifiedUser>();




            }
            catch (Exception ex)
            {
                
                return;
            }

        }
        public static int SaveSessionUser(SessionUser model)
        {
            _SQLiteConnection.DeleteAll<SessionUser>();
            return _SQLiteConnection.Insert(model);
        }
        public static int DeleteSessionUser()
        {

            return _SQLiteConnection.DeleteAll<SessionUser>();
        }
        public static SessionUser GetSessionUser()
        {
            return _SQLiteConnection.Table<SessionUser>().FirstOrDefault();
        }
        public static int SaveVerifiedUser(VerifiedUser model)
        {
            _SQLiteConnection.DeleteAll<VerifiedUser>();
            return _SQLiteConnection.Insert(model);
        }
        public static int DeleteVerifiedUser()
        {

            return _SQLiteConnection.DeleteAll<VerifiedUser>();
        }
        public static VerifiedUser GetVerifiedUser()
        {
            return _SQLiteConnection.Table<VerifiedUser>().FirstOrDefault();
        }

        public static int SaveChangeVerificationMethodRequest(ChangeVerificationMethodRequest model)
        {
            _SQLiteConnection.DeleteAll<ChangeVerificationMethodRequest>();
            return _SQLiteConnection.Insert(model);
        }
        public static int DeleteChangeVerificationMethodRequest()
        {

            return _SQLiteConnection.DeleteAll<ChangeVerificationMethodRequest>();
        }
        public static ChangeVerificationMethodRequest GetChangeVerificationMethodRequest()
        {
            return _SQLiteConnection.Table<ChangeVerificationMethodRequest>().FirstOrDefault();
        }

        //public static int SaveOTPAccessTokenCreateResponse(OTPAccessTokenCreateResponse model)
        //{
        //    _SQLiteConnection.DeleteAll<OTPAccessTokenCreateResponse>();
        //    return _SQLiteConnection.Insert(model);
        //}
        //public static int DeleteOTPAccessTokenCreateResponse()
        //{

        //    return _SQLiteConnection.DeleteAll<OTPAccessTokenCreateResponse>();
        //}
        //public static OTPAccessTokenCreateResponse GetOTPAccessTokenCreateResponse()
        //{
        //    return _SQLiteConnection.Table<OTPAccessTokenCreateResponse>().FirstOrDefault();
        //}

        public static int SaveLoginResponseResult(LoginResponseResult model)
        {
            _SQLiteConnection.DeleteAll<LoginResponseResult>();
            return _SQLiteConnection.Insert(model);
        }
        public static int DeleteLoginResponseResult()
        {

            return _SQLiteConnection.DeleteAll<LoginResponseResult>();
        }
        public static LoginResponseResult GetLoginResponseResult()
        {
            return _SQLiteConnection.Table<LoginResponseResult>().FirstOrDefault();
        }

        public static void RemoveEverythingFromDB()
        {
            _SQLiteConnection.DeleteAll<SessionUser>();
            _SQLiteConnection.DeleteAll<LoginResponseResult>();
            _SQLiteConnection.DeleteAll<ChangeVerificationMethodRequest>();
            _SQLiteConnection.DeleteAll<VerifiedUser>();
        }


    }
}
