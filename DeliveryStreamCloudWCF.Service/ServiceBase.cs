//2013.12.19 FSWW, Ramesh M Added For CR#61549 added String DeviceID, DateTime GMT
//2014.01.28 Ramesh M Added For CR#62026 Prompt to update the version
//2014.02.10 Ramesh M Added TrailerCode For CR#62211
//2014.02.24  Ramesh M Added For CR#62406 For DriverID,VechileID,UserLoginID on login itself so the user type putted as comma
//2014.03.17  Ramesh M Added For CR#62668 to get home terminal details
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using DeliveryStreamCloudWCF.Utils;
using DeliveryStreamCloudWCF.DataAccess;

namespace DeliveryStreamCloudWCF.Service
{
    /// <summary>
    /// ServiceBase class
    /// </summary>
    public class ServiceBase
    {
        /// <summary>
        /// Default constructor for ServiceBase
        /// </summary>
        static ServiceBase()
        {

        }

        /// <summary>
        /// GetConnectionString
        /// Function to get connection string for connection
        /// </summary>
        /// <returns>Connection string</returns>
        private static string GetConnectionString()
        {
            ConnectionStringSettingsCollection connectionStrings = ConfigurationManager.ConnectionStrings;

            foreach (ConnectionStringSettings connection in connectionStrings)
            {
                if (connection.Name != ApplicationConstants.Connection.ConnectionString)
                    continue;
                return connection.ConnectionString;
            }

            throw new ApplicationException(String.Format(ApplicationConstants.Errors.ConnectionString, ApplicationConstants.Connection.ConnectionString));
        }

        /// <summary>
        /// GetSession
        /// Function to get new session
        /// </summary>
        /// <returns>session - ISession</returns>
        protected static ISession GetSession()
        {
            ISession session = new Session(GetConnectionString());

            session.Open();
            return session;
        }

        /// <summary>
        /// Function to close current session
        /// </summary>
        /// <param name="session">Session object</param>
        protected static void CloseSession(ISession session)
        {
            try
            {
                session.Close();
                session = null;
            }
            catch (Exception ex)
            {
                session = null;
                //2013.06.24 FSWW, Ramesh M Added For CR#58976 To Add More Details about calling function in Error log file.
                Logging.LogError(ex,"Error DateTime-"+DateTime.Now.ToString()+"\n");
            }

        }

        /// <summary>
        /// GetNewSession
        /// Function to get new session
        /// </summary>
        /// <returns>session - ISession</returns>
        public static ISession GetNewSession()
        {
            ISession session = new Session(GetConnectionString());
            session.Open();
            return session;
        }

        /// <summary>
        /// ValidateUserLogin
        /// Function to validate user credientials
        /// </summary>
        /// <param name="userID">User ID</param>
        /// <param name="password">Password</param>
        /// <param name="companyID">Company ID</param>
        /// <param name="vehicleID">Vehicle ID</param>      
        /// <returns>True = Valid user, False = Failed</returns>

        protected Boolean ValidateUserLogin(String userID, String password, String companyID, String vehicleID, String VersionNo = "")
        {
            ISession session = null;
            try
            {
                session = GetSession();
                String ePassword = Encryption.doEncrypt(password);
                if (!DataAccess.DALMethods.ValidateUserLogin(userID, ePassword, companyID, session,VersionNo))
                {
                    throw new ApplicationException(ApplicationConstants.Errors.InvalidUserCredentials);
                }

                if (String.IsNullOrWhiteSpace(vehicleID) || DataAccess.DALMethods.GetVehicleID(vehicleID, companyID, session, VersionNo) == 0)
                {
                    throw new ApplicationException(ApplicationConstants.Errors.InvalidVehicleCode);
                }

                CloseSession(session);

            }
            catch (ApplicationException ex)
            {
                CloseSession(session);
                throw ex;
            }
            catch (Exception ex)
            {
                CloseSession(session);
                // 2013.06.24 FSWW, Ramesh M Added For CR#58976 To Add More Details about calling function in Error log file.
                Logging.LogError(ex, "CustomerID-" + companyID + ", LoginUserID-" + userID + "\n");
                throw ex;
            }
            finally
            {
                if (session != null)
                {
                    CloseSession(session);
                }
            }

            return true;
        }

        //2013.09.06 FSWW, Ramesh M Added For CR#60100 WarehouseLoads
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="password"></param>
        /// <param name="companyID"></param>
        /// <param name="SiteCode"></param>
        /// <returns></returns>
        protected Boolean ValidateUserLoginAndSiteID(String userID, String password, String companyID, String SiteCode, String VersionNo = "")
        {
            ISession session = null;
            try
            {
                session = GetSession();
                String ePassword = Encryption.doEncrypt(password);
                if (!DataAccess.DALMethods.ValidateUserLogin(userID, ePassword, companyID, session, VersionNo))
                {
                    throw new ApplicationException(ApplicationConstants.Errors.InvalidUserCredentials);
                }

                if (String.IsNullOrWhiteSpace(SiteCode) || DataAccess.DALMethods.GetSiteID(SiteCode, companyID, session, VersionNo) == 0)
                {
                    throw new ApplicationException(ApplicationConstants.Errors.InvalidSiteCode);
                }

                CloseSession(session);

            }
            catch (ApplicationException ex)
            {
                CloseSession(session);
                throw ex;
            }
            catch (Exception ex)
            {
                CloseSession(session);
                // 2013.06.24 FSWW, Ramesh M Added For CR#58976 To Add More Details about calling function in Error log file.
                Logging.LogError(ex, "CustomerID-" + companyID + ", LoginUserID-" + userID + "\n");
                throw ex;
            }
            finally
            {
                if (session != null)
                {
                    CloseSession(session);
                }
            }

            return true;
        }

        /// <summary>
        /// 2013.4.30, Suresh Madhesan, CR#?
        /// New login validate function and to return the user type
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="password"></param>
        /// <param name="companyID"></param>
        /// <param name="vehicleID"></param>   
        /// <param name="UserType"></param>
        /// <returns></returns>
        // 2013.08.07 FSWW, Ramesh M Added For CR#59829... To Validate User with User type Added UserType Parameter as input
        protected String ValidateUserLogin3(String userID, String password, String companyID, String vehicleID, String UserType, String VersionNo = "")
        {
            ISession session = null;
            String sResult = "F";
            try
            {
                session = GetSession();
                String ePassword = Encryption.doEncrypt(password);
                sResult = DataAccess.DALMethods.ValidateUserAndGetType(userID, ePassword, companyID, UserType, session, VersionNo);

                if (UserType.ToLower() == "g")
                    sResult = DataAccess.DALMethods.ValidateUserAndGetType(userID, ePassword, companyID, "D", session, VersionNo);
                else
                    sResult = DataAccess.DALMethods.ValidateUserAndGetType(userID, ePassword, companyID, UserType, session, VersionNo);

                if (sResult == "F")
                {
                    throw new ApplicationException(ApplicationConstants.Errors.InvalidUserCredentials);
                }

                //// 2013.09.05 FSWW, Ramesh M Added For CR#59829... To validate site code if user type is "W" Warehouse user
                if (UserType.ToLower() == "d")
                {
                    if (String.IsNullOrWhiteSpace(vehicleID) || DataAccess.DALMethods.GetVehicleID(vehicleID, companyID, session, VersionNo) == 0)
                    {
                        throw new ApplicationException(ApplicationConstants.Errors.InvalidVehicleCode);
                    }
                }
                // 2013.12.02 FSWW, Ramesh M Added For CR#60893 validate SiteCode
                else if (UserType.ToLower() == "w")
                {
                    if (String.IsNullOrWhiteSpace(vehicleID) || DataAccess.DALMethods.GetSiteID(vehicleID, companyID, session, VersionNo) == 0)
                    {
                        throw new ApplicationException(ApplicationConstants.Errors.InvalidSiteCode);
                    }
                }

                if (UserType.ToLower() == "g")
                {
                    sResult = "G";
                    if (DALMethods.GetVehicleTypeCount(DALMethods.GetVehicleID(vehicleID, companyID, session, VersionNo), Convert.ToInt32(companyID), session, VersionNo) == 0)
                        throw new ApplicationException(ApplicationConstants.Errors.InvalidTankWagonVehicle);
                }

                CloseSession(session);

            }
            catch (ApplicationException ex)
            {
                CloseSession(session);
                throw ex;
            }
            catch (Exception ex)
            {
                CloseSession(session);
                // 2013.06.24 FSWW, Ramesh M Added For CR#58976 To Add More Details about calling function in Error log file.
                Logging.LogError(ex, "CustomerID-" + companyID + ", LoginUserID-" + userID + "\n");
                throw ex;
            }
            finally
            {
                if (session != null)
                {
                    CloseSession(session);
                }
            }

            return sResult;
        }

        /// <summary>
        /// ValidateUserSession
        /// Function to validate user Session
        /// </summary>
        /// <param name="sessionID">Session ID</param>
        /// <returns>True = Valid user, False = Failed</returns>
        protected Boolean validateUserSession(Guid sessionID, String VersionNo = "")
        {
            ISession session = null;
            try
            {
                session = GetSession();
                if (!DataAccess.DALMethods.ValidateUserSession(sessionID, session, VersionNo))
                {
                    throw new ApplicationException(ApplicationConstants.Errors.InvalidSessionID);
                }
            }
            catch (ApplicationException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                // 2013.06.24 FSWW, Ramesh M Added For CR#58976 To Add More Details about calling function in Error log file.
                Logging.LogError(ex, "SessionID-" + sessionID +  "\n");
                throw ex;
            }
            finally
            {
                if (session != null)
                {
                    CloseSession(session);
                }
            }

            return true;
        }

        /// <summary>
        /// ValidateCustomerLogin
        /// Function to validate customer credientials
        /// </summary>
        /// <param name="companyID">Company ID</param>
        /// <param name="password">Password</param>
        /// <returns>True = Valid customer, False = Failed</returns>
        protected Boolean ValidateCustomerLogin(String companyID, String password, String VersionNo = "")
        {
            Boolean isValid = false;
            ISession session = null;
            try
            {
                session = GetSession();
                if (!DataAccess.DALMethods.ValidateCustomerLogin(companyID, password, session, VersionNo))
                {
                    throw new ApplicationException(ApplicationConstants.Errors.InvalidCustomerCredentials);
                }
                isValid = true;
                CloseSession(session);
            }
            catch (ApplicationException ex)
            {
                CloseSession(session);
                isValid = false;
                throw ex;
            }
            catch (Exception ex)
            {
                CloseSession(session);
                isValid = false;
                // 2013.06.24 FSWW, Ramesh M Added For CR#58976 To Add More Details about calling function in Error log file.
                Logging.LogError(ex,"CustomerID-"+companyID+"\n");
                throw ex;
            }
            finally
            {
                if (session != null)
                {
                    CloseSession(session);
                }
            }

            return isValid;
        }


        /// <summary>
        /// Function to validate device token.
        /// For now just checked if it is not null or empty
        /// </summary>
        /// <param name="deviceToken">device token</param>
        /// <returns>result</returns>
        protected bool IsValidDevideToken(String deviceToken)
        {
            return !String.IsNullOrWhiteSpace(deviceToken);
        }

        /// <summary>
        /// GetSessionDetail
        /// Function to GetSessionDetail if any earlier session is existing 
        /// </summary>
        /// <param name="userName">userName</param>
        /// <param name="password">Password</param>
        /// <param name="companyID">Company ID</param>
        /// <param name="vehicleID">Vehicle ID</param>
        /// <param name="loginTime">loginTime</param>
        /// <returns>SessionID</returns>
        protected Guid GetSessionDetail(String userName, String password, String companyID, String vehicleID, DateTime loginTime, String VersionNo = "")
        {
            ISession session = null;
            Guid sessionID = new Guid();
            try
            {
                session = GetSession();
                Int32 userID = DataAccess.DALMethods.GetUserID(userName, companyID, session, VersionNo);
                Int32 iVehicleID = DataAccess.DALMethods.GetVehicleID(vehicleID, companyID, session, VersionNo);
                sessionID = DataAccess.DALMethods.GetSessionDetail(userID, password, companyID, iVehicleID, loginTime, session, VersionNo);
                CloseSession(session);
            }
            catch (ApplicationException ex)
            {
                CloseSession(session);
                throw ex;
            }
            catch (Exception ex)
            {
                CloseSession(session);
                // 2013.06.24 FSWW, Ramesh M Added For CR#58976 To Add More Details about calling function in Error log file.
                Logging.LogError(ex,"CustomerID-"+companyID+", SessionID-"+sessionID+"\n");
                throw ex;
            }
            finally
            {
                if (session != null)
                {
                    CloseSession(session);
                }
            }

            return sessionID;
        }

        /// <summary>
        /// validateUser
        /// Function to validate user login
        /// </summary>
        /// <param name="UserName">User name</param>
        /// <param name="vehicleID">Vehicle ID</param>
        /// <param name="password">Password</param>
        /// <param name="companyID">Company ID</param>
        /// <param name="deviceToken">Device Token</param>        
        /// <param name="deviceTime">deviceTime</param>
        /// <param name="dateTime">dateTime</param>
        /// <param name="isNewLogin">Is New Login</param>
        /// <returns>SessionID</returns>
        protected Guid validateUser(String UserName, String vehicleID, String password, String companyID, String deviceToken, DateTime deviceTime, DateTime dateTime, bool isNewLogin, String DeviceID, DateTime GMT, String TrailerCode, String IOSVersion, String VersionNo = "")
        {
            Guid sessionID = new Guid();
            ISession session = GetSession();

            try
            {
                // 2013.5.6, Suresh Madhesan, CR#?, To avoid multiple logins
                //if (DataAccess.DALMethods.GetLoginCount(UserName, companyID, session) > 0)
                //{
                //    throw new ApplicationException(ApplicationConstants.Errors.MultipleLoginError);
                //}

                if (ValidateUserLogin(UserName, password, companyID, vehicleID, VersionNo))
                {
                    // Comment and created the session variable in the beginning of the function
                    // 2013.5.6, Suresh Madhesan, CR#?, To avoid multiple logins
                    //ISession session = null;
                    //try
                    //{
                    session = GetSession();
                    Int32 userID = DataAccess.DALMethods.GetUserID(UserName, companyID, session, VersionNo);
                    Int32 iVehicleID = DataAccess.DALMethods.GetVehicleID(vehicleID, companyID, session, VersionNo);
                    sessionID = GetSessionDetail(UserName, password, companyID, vehicleID, deviceTime, VersionNo);

                    if (!isNewLogin)
                    {
                        return sessionID;
                    }
                    else if (sessionID != Guid.Empty)
                    {
                        //LogOff Current session
                        DALMethods.UpdateLoginHistory(sessionID, deviceTime, session, VersionNo);
                        DALMethods.removeLoginSession(sessionID, session, VersionNo);
                    }

                    sessionID = Guid.NewGuid();
                    Entities.LoginHistory history = new Entities.LoginHistory();
                    history.LoginID = userID;
                    history.VehicleID = iVehicleID;
                    history.CustomerID = companyID;
                    history.DeviceToken = deviceToken;
                    history.DateTime = dateTime;
                    history.IsValidToken = IsValidDevideToken(deviceToken);
                    history.DeviceTime = deviceTime;
                    history.SessionID = sessionID;
                    //2013.12.19 FSWW, Ramesh M Added For CR#61549 added String DeviceID, DateTime GMT
                    history.DeviceID = DeviceID;
                    history.GMT = GMT;
                    // 2014.02.10 Ramesh M Added TrailerCode For CR#62211
                    history.TrailerCode = TrailerCode;
                    history.IOSVersion = IOSVersion;
                    DataAccess.DALMethods.AddLoginHistory(history, session, VersionNo);

                    Entities.LoginSession loginSession = new Entities.LoginSession();
                    loginSession.SessionID = sessionID;
                    loginSession.LoginID = userID;
                    loginSession.CurrentVehicle = iVehicleID;
                    loginSession.Active = true;
                    loginSession.LogonTime = deviceTime;
                    //TODO: Check for DeviceID
                    loginSession.DeviceID = DeviceID;
                    loginSession.Version = VersionNo;
                    loginSession.IOSVersion = IOSVersion;
                    DataAccess.DALMethods.AddLoginSession(loginSession, session, VersionNo);

                    CloseSession(session);

                }
            }
            catch (Exception ex)
            {
                if (session != null)
                {
                    CloseSession(session);
                }
                // 2013.06.24 FSWW, Ramesh M Added For CR#58976 To Add More Details about calling function in Error log file.
                Logging.LogError(ex,"CustomerID-"+companyID+", SessionID-"+sessionID+"\n");
                throw ex;
            }
            finally
            {
                if (session != null)
                {
                    CloseSession(session);
                }


            }
            return sessionID;

        }


        /// <summary>
        /// 2013.4.30, Suresh Madhesan, CR#?
        /// Function to added to get the usertype while login
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="vehicleID"></param>
        /// <param name="password"></param>
        /// <param name="companyID"></param>
        /// <param name="deviceToken"></param>
        /// <param name="deviceTime"></param>
        /// <param name="dateTime"></param>
        /// <param name="isNewLogin"></param>
        /// <param name="VersionNo"></param>
        /// <param name="UserType"></param>
        /// <param name="DeviceID"></param>
        /// <param name="GMT"></param>
        /// <returns></returns>
        ///  2013.08.07 FSWW, Ramesh M Added For CR#?... To Validate User with User type Added UserType Parameter as input
        ///  2013.11.27 FSWW, Ramesh M Added For CR#60210 Added deviceID in parameter
        ///  2013.12.04 FSWW, Ramesh M Added For CR#61305 Added GMT in parameter
        ///  2014.02.10 Ramesh M Added TrailerCode For CR#62211
        protected String validateUser3(String UserName, String vehicleID, String password, String companyID, String deviceToken, DateTime deviceTime, DateTime dateTime, bool isNewLogin, String VersionNo, String UserType, String DeviceID, DateTime GMT,String TrailerCode, String IOSVersion="",String AppInstalledON = "")
        {
            Guid sessionID = new Guid();
            String sUserType=null;
            ISession session = null;
            session = GetSession();
            //2013.06-21 Fsww Ramesh M Added For CR#?.. To Validate application Version in Database
            //if (DataAccess.DALMethods.GetVersionNo(VersionNo,session)>0)
            //{           
            sUserType = ValidateUserLogin3(UserName, password, companyID, vehicleID, UserType, VersionNo);
            // 2014.01.28 Ramesh M Added For CR#62026 Prompt to update the version
            if ((VersionNo != "1.27") && ((sUserType.ToLower() == "d") || (sUserType.ToLower() == "w") || (sUserType.ToLower() == "g")))
            {
                if (sUserType != "F")
                {

                    try
                    {

                        Int32 userID = DataAccess.DALMethods.GetUserID(UserName, companyID, session, VersionNo);
                        Int32 iVehicleID = DataAccess.DALMethods.GetVehicleID(vehicleID, companyID, session, VersionNo);
                        sessionID = GetSessionDetail(UserName, password, companyID, vehicleID, deviceTime, VersionNo);

                        // 2013-5-29, Fsww Ramesh M added for CR?..  for avoiding multiple logins,added following a line code and if condition
                        Int32 iLoginIDCount = DataAccess.DALMethods.GetCurrentLoginIDCountByUserNameAndCustomerID(UserName, companyID, session, VersionNo);
                        if (iLoginIDCount == 0)
                        {
                            if (!isNewLogin)
                            {
                                return sessionID.ToString();
                            }
                            else if (sessionID != Guid.Empty)
                            {
                                //LogOff Current session
                                DALMethods.UpdateLoginHistory(sessionID, deviceTime, session, VersionNo);
                                DALMethods.removeLoginSession(sessionID, session, VersionNo);
                            }

                            sessionID = Guid.NewGuid();
                            Entities.LoginHistory history = new Entities.LoginHistory();
                            history.LoginID = userID;
                            history.VehicleID = iVehicleID;
                            history.CustomerID = companyID;
                            history.DeviceToken = deviceToken;
                            history.DateTime = dateTime;
                            history.IsValidToken = IsValidDevideToken(deviceToken);
                            history.DeviceTime = deviceTime;
                            history.SessionID = sessionID;
                            history.DeviceID = DeviceID;
                            //  2013.12.04 FSWW, Ramesh M Added For CR#61305 Added GMT in parameter
                            history.GMT = GMT;
                            // 2014.02.10 Ramesh M Added TrailerCode For CR#62211
                            history.TrailerCode = TrailerCode;
                            history.IOSVersion = IOSVersion;
                           
                            DataAccess.DALMethods.InsertLoginHistory(history, session, VersionNo,AppInstalledON);
                           

                            Entities.LoginSession loginSession = new Entities.LoginSession();
                            loginSession.SessionID = sessionID;
                            loginSession.LoginID = userID;
                            loginSession.CurrentVehicle = iVehicleID;
                            loginSession.Active = true;
                            loginSession.LogonTime = deviceTime;
                            //TODO: Check for DeviceID
                            //loginSession.DeviceID = "";
                            loginSession.DeviceID = DeviceID;
                            loginSession.Version = VersionNo;
                            loginSession.IOSVersion = IOSVersion;
                            DataAccess.DALMethods.AddLoginSession(loginSession, session, VersionNo);

                            CloseSession(session);

                        }
                        else
                        {
                            // 2013.12.09 FSWW, Ramesh M Added For CR#61409. make the session id to be empty value
                            sessionID = Guid.Empty;
                            sUserType = "N";
                        }

                    }
                    catch (Exception ex)
                    {
                        if (session != null)
                        {
                            CloseSession(session);
                        }
                        // 2013.06.24 FSWW, Ramesh M Added For CR#58976 To Add More Details about calling function in Error log file.
                        Logging.LogError(ex, "CustomerID-" + companyID + ", SessionID-" + sessionID + "\n");
                    }
                    finally
                    {
                        if (session != null)
                        {
                            CloseSession(session);
                        }
                    }

                }
                //}
                //else
                //{               
                //    sUserType = "V";
                //}
            }
            else
            {
                sUserType = "V";
            }
            //2014.02.24  Ramesh M Added For CR#62406 For DriverID,VechileID,UserLoginID on login itself so the user type putted as comma
            return sessionID.ToString() +","+ sUserType ;

        }

       

        /// <summary>
        /// 
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="vehicleID"></param>
        /// <param name="password"></param>
        /// <param name="companyID"></param>
        /// <param name="deviceToken"></param>
        /// <param name="deviceTime"></param>
        /// <param name="VersionNo"></param>
        /// <param name="UserType"></param>
        /// <param name="DeviceID"></param>
        /// <param name="GMT"></param>
        /// <returns></returns>
        protected String ServerCurrentVersion(String UserName, String vehicleID, String password, String companyID, String deviceToken, DateTime deviceTime, String VersionNo, String UserType, String DeviceID, DateTime GMT)
        {
            String CurrentVersion = VersionNo;
            ISession session = null;
            session = GetSession();
            try
            {
                CurrentVersion = DALMethods.GetVersionNo(VersionNo,session);
            }
            catch (Exception ex)
            {
                if (session != null)
                {
                    CloseSession(session);
                }
                // 2013.06.24 FSWW, Ramesh M Added For CR#58976 To Add More Details about calling function in Error log file.
                Logging.LogError(ex, "CustomerID-" + companyID + ", UserName-" + UserName + "vehicleID-" + vehicleID + "UserType-" + UserType + "\n");
            }
            finally
            {
                if (session != null)
                {
                    CloseSession(session);
                }
            }
            return CurrentVersion;
        }
    

    
    }
}
