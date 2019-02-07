/* Mod Log
// 2013.10.03  Ramesh M Added For CR#60534 Removed 34 hour reset code in Cloud, this will be done in ipad itself.
// 2013.10.24  Ramesh M Added gpsHist.PreviousLongitude,gpsHist.PreviousLatitude- parmeters for CR#60386
// 2013.12.19  Ramesh M Added For CR#61549 added String DeviceID, DateTime GMT
// 2013.12.24  Ramesh M Added For Add CR#60902 for CR Reopen
// 2014.01.03  Ramesh M Added For Versioning handling CR#61147
// 2014.01.10  Ramesh M Added For CR#61759 Added to full From Site business rule
// 2014.01.16  Ramesh M Added For  CR#61759 to get from site list 
// 2014.01.23  Ramesh M Added For CR#61759 to get from site list based on shiptoID
// 2014.01.28  Ramesh M Added For CR#62026 Prompt to update the version
// 2014.02.06  Ramesh M Added For CR#62166 For DOT OverRide Details
// 2014.02.10  Ramesh M Added TrailerCode For CR#62211
// 2014.02.17  Ramesh M Added UserType For Warehouse user duplication CR#62289
// 2014.02.20  Ramesh M Added For CR#62301 For Driver status Screen in Ipad
// 2014.02.20  Ramesh M Added For CR#62292 For driver summary log and commented above code, moved logic to stored procedure.
// 2014.02.24  Ramesh M Added For CR#62406 For DriverID,VechileID,UserLoginID on login itself
// 2014.03.05  Ramesh M Added For CR#62301 For City added
// 2014.03.17  Ramesh M Added For CR#62668 to get home terminal details
// 2014.03.17  Ramesh M Added For CR#62613 to Auto logoff through Ipad
// 2014.03.18  Ramesh M Added For CR#62719 added  TrailerCode in input parameters
// 2014.03.20  Ramesh M Added For CR#62322 added  Version testing method.  
// 05-14-2014  MadhuVenkat K - Added for CR 63396 - Add Time Remaining Section to Driver Summary
// 05-20-2014  MadhuVenkat k - Added for CR 63346 - PO & Priority No to Load Information Screen 
// 06-26-2014  MadhuVenkat k - Added for CR 64058  - For Add orderDispatchHistory 
// 06-26-2014  MadhuVenkat k - Added for CR 64058  - For Update Status in OrderDipatchHistory
// 06-26-2014  MadhuVenkat k - Added for CR 64058  - For Geting List of OrderDipatchHistory details
// 07-09-2014  MadhuVenkat k - Modified for CR 64172 - Modified For unable to process loads in ipad when a Vehicle Code is alpha numeric value
// 07-14-2014  Madhuvenkat K - Modified for CR 64247 - Included Order Status "Vehicle At Supply Point" for processing Dispatch order changes 
                                                        from ASCEND to DeliveryStream.
// 07-16-2014  Madhuvenkat K - Modified for CR 64247 - Included Order Status "Enroute to Supply Point - E" for processing Dispatch order changes from ASCEND to DeliveryStream.
// 08-14-2014  MadhuVenkat K - Added for CR 64639 - Add CurrentDriverStatus to Driver Summary
// 09-09-2014  CR#64208, Madhu, Add Modified date to GetInspectionElementsData
// 09-23-2014  MadhuVenkat k - Added for CR#65002  added SupplierCode and SupplyPointCode.
// 11-17-2014  MadhuVenkat K Modified for CR 65550 - Updating wrong status to the GPS History on driving
// 12-17-2014  MadhuVenkat K Added for CR 65762 - In Multi BOL processing, the gross qty and Net qty not updating correct qty.
// 2015.02.02 Madhu Added For CR#66160 For Add App Version No in the login session table for every login sessions
// 2015.03.17  MadhuVenkat K Added IsSessionIDExist - for loginsession is check available or not in loginsession table.
*/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel.Activation;
using System.ServiceModel;
using DeliveryStreamCloudWCF.Entities;
using DeliveryStreamCloudWCF.DataAccess;
using DeliveryStreamCloudWCF.Utils;
using System.Text.RegularExpressions;
using System.Configuration;
using System.Xml;
using System.Reflection;
using System.Data;
using System.IO;
using System.Xml.Serialization;
using System.Diagnostics;

namespace DeliveryStreamCloudWCF.Service
{
    /// <summary>
    /// CloudService class
    /// </summary>
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class CloudService : ServiceBase, ICloudService
    {
        string LoggingStatus = null;
        /// <summary>
        /// 
        /// </summary>
        public CloudService()
        {
            LoggingStatus = ConfigurationManager.AppSettings["FunctionCallingErrorLog"].ToString().ToLower();
        }
        #region ICloudService Members

        #region Login Details

        // 2014.02.10 Ramesh M Added TrailerCode For CR#62211
        /// <summary>
        /// CheckUserLogin
        /// Function to validate user login
        /// </summary>
        /// <param name="UserName">User name</param>
        /// <param name="vehicleID">Vehicle ID</param>
        /// <param name="password">Password</param>
        /// <param name="companyID">Company ID</param>
        /// <param name="deviceToken">Device Token</param>
        /// <returns>True = Valid customer, False = Failed</returns>
        public Boolean CheckUserLogin(String UserName, String vehicleID, String password, String companyID, String deviceToken, String DeviceID, DateTime GMT, String TrailerCode)
        {
            Guid SessionID = validateUser(UserName, vehicleID, password, companyID, deviceToken, DateTime.Now, DateTime.Now, true, DeviceID, GMT, TrailerCode, "");
            Boolean isValid = false;

            if (SessionID != Guid.Empty)
            {
                isValid = true;
            }

            return isValid;
        }

        public Boolean Test()
        {
            return true;
        }

        // 2014.02.10 Ramesh M Added TrailerCode For CR#62211
        /// <summary>
        /// CheckUserLogin
        /// Function to validate user login
        /// </summary>
        /// <param name="UserName">User name</param>
        /// <param name="vehicleID">Vehicle ID</param>
        /// <param name="password">Password</param>
        /// <param name="companyID">Company ID</param>
        /// <param name="deviceToken">Device Token</param>
        /// <param name="deviceTime">device Time</param>
        /// <returns>SessionID</returns>
        public Guid CheckUserLogin2(String UserName, String vehicleID, String password, String companyID, String deviceToken, DateTime deviceTime, String DeviceID, DateTime GMT, String TrailerCode)
        {

            return validateUser(UserName, vehicleID, password, companyID, deviceToken, deviceTime, DateTime.Now, true, DeviceID, GMT, TrailerCode, "");
        }

        /// <summary>
        /// 2013.4.30, Suresh Madhesan, CR#?
        /// Function added to get the user type while login
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
        // 2013.08.07 FSWW, Ramesh M Added For CR#?... To Validate User with User type Added UserType Parameter as input
        // 2013.11.27 FSWW, Ramesh M Added For CR#60210 Added deviceID in parameter
        // 2013.12.04 FSWW, Ramesh M Added For CR#61305 Added GMT in parameter
        // 2014.02.10 Ramesh M Added TrailerCode For CR#62211
        public String CheckUserLogin3(String UserName, String vehicleID, String password, String companyID, String deviceToken, DateTime deviceTime, String VersionNo, String UserType, String DeviceID, DateTime GMT, String TrailerCode, String IOSVersion = "",String AppInstalledON = "")
        {

            OperationContext context = OperationContext.Current;
            System.ServiceModel.Channels.MessageProperties messageProperties = context.IncomingMessageProperties;
            System.ServiceModel.Channels.RemoteEndpointMessageProperty endpointProperty = messageProperties[System.ServiceModel.Channels.RemoteEndpointMessageProperty.Name] as System.ServiceModel.Channels.RemoteEndpointMessageProperty;

            String sIPAndPort = endpointProperty.Address.ToString() + " - " + endpointProperty.Port.ToString();
            //Logging.WriteLog("IOS Version- " + IOSVersion , System.Diagnostics.EventLogEntryType.Error);

            String sGuidAndUserType = validateUser3(UserName, vehicleID, password, companyID, deviceToken, deviceTime, DateTime.Now, true, VersionNo, UserType, DeviceID, GMT, TrailerCode, IOSVersion == null ? "" : IOSVersion, AppInstalledON == null ? "" : AppInstalledON);

            Int32 UserDriverID = 0;
            Int32 UserVehileID = 0;
            Int32 UserLoginID = 0;
            ISession session = null;
            session = GetSession();

            string IsGPSUpdate = DALMethods.IsEnabledGPSUpdate(companyID, session, VersionNo);
            string IsEnabledDeliveryDateSort = DALMethods.IsEnabledDeliveryDateSort(companyID, session, VersionNo);
            string IsEnabledFrtChargeChanges = DALMethods.IsEnabledFreightChargeChanges(companyID, session, VersionNo);


            string IsEableRemoveLoad = string.Empty;
            IsEableRemoveLoad = DALMethods.IsEnableRemoveLoad(companyID, session, VersionNo);
            string CustomizedStatusViewFalg = string.Empty;
            CustomizedStatusViewFalg = DALMethods.GetCustomizeStatusViewFlag(companyID, session, VersionNo);

            if (CustomizedStatusViewFalg == string.Empty)
            {
                Logging.WriteLog("CustomizedStatusViewFalg", EventLogEntryType.Information);
                CustomizedStatusViewFalg = "N";
            }

            // 2014.01.28 Ramesh M Added For CR#62026 Prompt to update the version
            if (sGuidAndUserType != "00000000-0000-0000-0000-000000000000V")
            {
                //Logging.WriteLog("User logged in with the session ID and followed by user type ID- " + sGuidAndUserType + " from the IP - " + sIPAndPort, System.Diagnostics.EventLogEntryType.Error);



                // 2014.02.24  Ramesh M Added For CR#62406 For DriverID,VechileID,UserLoginID on login itself
                if (UserType.ToLower() == "d" || UserType.ToLower() == "g")
                {
                    UserVehileID = DataAccess.DALMethods.GetVehicleID(vehicleID, companyID, session, VersionNo);
                    UserDriverID = DataAccess.DALMethods.GetDriverID(UserName, companyID, session, VersionNo);
                    UserLoginID = DataAccess.DALMethods.GetUserID(UserName, companyID, session, VersionNo);
                }
                else
                {
                    UserVehileID = DataAccess.DALMethods.GetSiteID(vehicleID, companyID, session, VersionNo);
                    UserDriverID = DataAccess.DALMethods.GetLoginuserSiteID(UserName, companyID, session, VersionNo);
                    UserLoginID = DataAccess.DALMethods.GetUserID(UserName, companyID, session, VersionNo);
                }
                CloseSession(session);
            }
            if (VersionNo.ToLower() == "1.27")
            {
                // 2014.03.20  Ramesh M commented userloginID For CR#62322 
                sGuidAndUserType = sGuidAndUserType.Split(',')[0].ToString() + sGuidAndUserType.Split(',')[1].ToString();// +"," + UserLoginID;
                return sGuidAndUserType + "," + IsGPSUpdate + "," + IsEnabledDeliveryDateSort + "," + IsEnabledFrtChargeChanges;
            }
            else
            {
                //Logging.LogInfoAboutCallingFunction("Function Called:-CheckUserLogin3 VersionNo Else; " + "sGuidAndUserType-" + sGuidAndUserType);
                if (UserType.ToLower() == "g")
                {

                    if ((sGuidAndUserType.Split(',')[1].ToString() == "N" || sGuidAndUserType.Split(',')[1].ToString() == "V"))
                    {
                        return sGuidAndUserType + "," + UserDriverID.ToString() + "," + UserVehileID.ToString() + "," + UserLoginID + "," + IsGPSUpdate + "," + IsEnabledDeliveryDateSort + "," + IsEnabledFrtChargeChanges + "," + IsEableRemoveLoad + "," + companyID + "," + CustomizedStatusViewFalg;
                    }
                    else
                    {
                        return sGuidAndUserType.Split(',')[0].ToString() + ",G" + "," + UserDriverID.ToString() + "," + UserVehileID.ToString() + "," + UserLoginID + "," + IsGPSUpdate + "," + IsEnabledDeliveryDateSort + "," + IsEnabledFrtChargeChanges + "," + IsEableRemoveLoad + "," + companyID + "," + CustomizedStatusViewFalg;
                    }

                }
                else
                {
                    return sGuidAndUserType + "," + UserDriverID.ToString() + "," + UserVehileID.ToString() + "," + UserLoginID + "," + IsGPSUpdate + "," + IsEnabledDeliveryDateSort + "," + IsEnabledFrtChargeChanges + "," + IsEableRemoveLoad + "," + companyID + "," + CustomizedStatusViewFalg;
                }
            }

        }


        // 2014.01.03 FSWW, Ramesh M Added For Versioning handling
        // 2014.02.10 Ramesh M Added TrailerCode For CR#62211
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
        public String CheckUserLogin4(String UserName, String vehicleID, String password, String companyID, String deviceToken, DateTime deviceTime, String VersionNo, String UserType, String DeviceID, DateTime GMT, String TrailerCode, String IOSVersion = "", String AppInstalledON = "")
        {
            OperationContext context = OperationContext.Current;
            System.ServiceModel.Channels.MessageProperties messageProperties = context.IncomingMessageProperties;
            System.ServiceModel.Channels.RemoteEndpointMessageProperty endpointProperty = messageProperties[System.ServiceModel.Channels.RemoteEndpointMessageProperty.Name] as System.ServiceModel.Channels.RemoteEndpointMessageProperty;

            String sIPAndPort = endpointProperty.Address.ToString() + " - " + endpointProperty.Port.ToString();
            String ServerVersion = ServerCurrentVersion(UserName, vehicleID, password, companyID, deviceToken, deviceTime, VersionNo, UserType, DeviceID, GMT);

            Int32 UserDriverID = 0;
            Int32 UserVehileID = 0;
            Int32 UserLoginID = 0;
            ISession session = null;
            session = GetSession();
            string IsGPSUpdate = DALMethods.IsEnabledGPSUpdate(companyID, session, VersionNo);
            string IsEnabledDeliveryDateSort = DALMethods.IsEnabledDeliveryDateSort(companyID, session, VersionNo);
            string IsEnabledFrtChargeChanges = DALMethods.IsEnabledFreightChargeChanges(companyID, session, VersionNo);
            string DeliveryImageBSRule = "";
            string BOLDeliveryBSRule = DALMethods.BOLDeliveryBSRule(companyID, ref DeliveryImageBSRule, session, VersionNo);

            string IsEableRemoveLoad = string.Empty;
            IsEableRemoveLoad = DALMethods.IsEnableRemoveLoad(companyID, session, VersionNo);
            string CustomizedStatusViewFalg = string.Empty;
            CustomizedStatusViewFalg = DALMethods.GetCustomizeStatusViewFlag(companyID, session, VersionNo);

            if (CustomizedStatusViewFalg == string.Empty)
            {
                Logging.WriteLog("CustomizedStatusViewFalg", EventLogEntryType.Information);
                CustomizedStatusViewFalg = "N";
            }

            if ( Convert.ToDouble(ServerVersion) <= Convert.ToDouble(VersionNo))
            {
                String sGuidAndUserType = validateUser3(UserName, vehicleID, password, companyID, deviceToken, deviceTime, DateTime.Now, true, VersionNo, UserType, DeviceID, GMT, TrailerCode, IOSVersion == null ? "" : IOSVersion, AppInstalledON == null ? "" : AppInstalledON);

                if (UserType.ToLower() == "g")
                {

                    if (DALMethods.GetVehicleTypeCount(DALMethods.GetVehicleID(vehicleID, companyID, session, VersionNo), Convert.ToInt32(companyID), session, VersionNo) == 0)
                        throw new ApplicationException(ApplicationConstants.Errors.InvalidTankWagonVehicle);
                }

                //// 2014.02.24  Ramesh M Added For CR#62406 For DriverID,VechileID,UserLoginID on login itself
                if (UserType.ToLower() == "d" || UserType.ToLower() == "g")
                {
                    UserVehileID = DataAccess.DALMethods.GetVehicleID(vehicleID, companyID, session, VersionNo);
                    UserDriverID = DataAccess.DALMethods.GetDriverID(UserName, companyID, session, VersionNo);
                    UserLoginID = DataAccess.DALMethods.GetUserID(UserName, companyID, session, VersionNo);
                }
                else
                {
                    UserVehileID = DataAccess.DALMethods.GetSiteID(vehicleID, companyID, session, VersionNo);
                    UserDriverID = DataAccess.DALMethods.GetLoginuserSiteID(UserName, companyID, session, VersionNo);
                    UserLoginID = DataAccess.DALMethods.GetUserID(UserName, companyID, session, VersionNo);
                }
                CloseSession(session);
                // 2014.02.24  Ramesh M Added For CR#62406 For DriverID,VechileID,UserLoginID on login itself
                return sGuidAndUserType + "," + UserDriverID.ToString() + "," + UserVehileID.ToString() + "," + UserLoginID + "," + IsGPSUpdate + "," + IsEnabledDeliveryDateSort + "," + IsEnabledFrtChargeChanges + "," + BOLDeliveryBSRule + "," + IsEableRemoveLoad + "," + companyID + "," + CustomizedStatusViewFalg + "," + DeliveryImageBSRule;
            }
            else
            {
                Guid sessionID = new Guid();


                if (UserType.ToLower() == "g")
                {

                    if (DALMethods.GetVehicleTypeCount(DALMethods.GetVehicleID(vehicleID, companyID, session, VersionNo), Convert.ToInt32(companyID), session, VersionNo) == 0)
                        throw new ApplicationException(ApplicationConstants.Errors.InvalidTankWagonVehicle);
                }

                if ((ServerVersion.ToLower() == "1.28") && (VersionNo.ToLower() == "1.27"))
                {
                    return sessionID.ToString() + "V";
                }
                else
                {
                    // 2014.02.24  Ramesh M Added For CR#62406 For DriverID,VechileID,UserLoginID on login itself



                    return sessionID.ToString() + "," + "L" + "," + UserDriverID.ToString() + "," + UserVehileID.ToString() + "," + UserLoginID + "," + IsGPSUpdate + "," + IsEnabledDeliveryDateSort + "," + IsEnabledFrtChargeChanges + "," + BOLDeliveryBSRule + "," + IsEableRemoveLoad + "," + companyID + "," + CustomizedStatusViewFalg;
                }

            }

        }


        /// <summary>
        /// CheckCustomerLogin
        /// Function to validate customer login
        /// </summary>
        /// <param name="companyID">Company ID</param>
        /// <param name="password">Password</param>
        /// <returns>True = Valid customer, False = Failed</returns>
        public Boolean CheckCustomerLogin(String companyID, String password, String VersionNo = "")
        {
            return ValidateCustomerLogin(companyID, password, VersionNo);
        }
        // 2014.03.17  Ramesh M Added For CR#62613 to get home terminal details

        /// <summary>
        /// GetLoginHomeTerminalDetails
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="password"></param>
        /// <param name="companyID"></param>
        /// <param name="UserType"></param>
        /// <param name="VersionNo"></param>
        /// <returns></returns>
        public List<LoginHomeTerminalDetails> GetLoginHomeTerminalDetails(String userID, String password, String companyID, String UserType, String VersionNo = "")
        {
            List<LoginHomeTerminalDetails> lstHomeTerminalDetails = new List<LoginHomeTerminalDetails>();
            ISession session = null;
            try
            {
                session = GetSession();
                lstHomeTerminalDetails = DALMethods.GetHomeTerminalDetails(userID, password, companyID, UserType, session, VersionNo);
                CloseSession(session);
            }
            catch (Exception ex)
            {
                if (session != null)
                {
                    CloseSession(session);
                }
                throw ex;
            }
            return lstHomeTerminalDetails;
        }



        // 06-26-2014  MadhuVenkat k - Added for CR 64058  - For Geting List of OrderDipatchHistory details
        // 07-09-2014  MadhuVenkat k - Modified for CR 64172 - Modified For unable to process loads in ipad when a Vehicle Code is alpha numeric value.
        /// <summary>
        /// GetUnAssignedOrders
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="password"></param>
        /// <param name="companyID"></param>
        /// <param name="OldDriverID"></param>
        /// <param name="OldVehicleID"></param>
        /// <returns>OrderDispatchHistory object</returns>
        /// 
        public List<OrderDispatchHistory> GetUnAssignedOrders(String UserName, String password, String companyID, String OldDriverID, String OldVehicleID, DateTime? deviceTime = null, String VersionNo = "")
        {
            List<OrderDispatchHistory> lstOrderDispatchHistoryDetails = new List<OrderDispatchHistory>();

            OrderDispatchHistory orderdispatch = new OrderDispatchHistory();

            ISession session = null;
            try
            {
                session = GetSession();
                if (ValidateUserLogin(UserName, password, companyID, OldVehicleID.ToString(), VersionNo))
                {
                    Int32 DriverId = DALMethods.GetDriverID(UserName, companyID, session, VersionNo);
                    Int32 VehicleId = DataAccess.DALMethods.GetVehicleID(OldVehicleID, companyID, session, VersionNo);
                    lstOrderDispatchHistoryDetails = DALMethods.GetOrderDispatchHistory(companyID, DriverId, VehicleId, session, VersionNo);
                    //for (var i = 0; i < 1; i++)
                    //{
                    //    orderdispatch = new OrderDispatchHistory();
                    //    if (deviceTime != Convert.ToDateTime("1/1/1753 12:00:00 AM") && deviceTime != Convert.ToDateTime("1/1/1753 12:00:00 PM"))
                    //    {
                    //        orderdispatch.CompletedLoad = DALMethods.GetCompletedLoads(companyID, deviceTime, session, VersionNo);
                    //    }
                    //    else
                    //    {
                    //        orderdispatch.CompletedLoad = new List<CompletedLoads>();
                    //    }

                    //}
                    if (deviceTime.HasValue)
                    {
                        if (deviceTime != Convert.ToDateTime("1/1/1753 12:00:00 AM") && deviceTime != Convert.ToDateTime("1/1/1753 12:00:00 PM"))
                        {
                            if (lstOrderDispatchHistoryDetails.Count > 0)
                                lstOrderDispatchHistoryDetails[0].CompletedLoad = DALMethods.GetCompletedLoads(companyID, deviceTime, session, VersionNo);
                            else
                            {
                                orderdispatch.CompletedLoad = DALMethods.GetCompletedLoads(companyID, deviceTime, session, VersionNo);

                                lstOrderDispatchHistoryDetails.Add(orderdispatch);
                            }
                        }
                    }
                }
                CloseSession(session);
            }
            catch (Exception ex)
            {
                if (session != null)
                {
                    CloseSession(session);
                }
                throw ex;
            }
            return lstOrderDispatchHistoryDetails;
        }


        // 2014.03.17  Ramesh M Added For CR#62613 to Auto logoff through Ipad
        /// <summary>
        /// EndPreviousLogin
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
        /// <param name="TrailerCode"></param>
        /// <returns></returns>
        public Boolean EndPreviousLogin(String UserName, String vehicleID, String password, String companyID, String deviceToken, DateTime deviceTime, String VersionNo, String UserType, String DeviceID, DateTime GMT, String TrailerCode)
        {
            Boolean bEndPreviousSession = false;
            ISession session = null;
            try
            {
                session = GetSession();
                bEndPreviousSession = DALMethods.EndPreviousLogin(UserName, password, companyID, UserType, vehicleID, deviceToken, deviceTime, DeviceID, GMT, TrailerCode, session, VersionNo);
                bEndPreviousSession = true;
                CloseSession(session);
            }
            catch (Exception ex)
            {
                if (session != null)
                {
                    CloseSession(session);
                }
                throw ex;
            }
            return bEndPreviousSession;
        }

        #endregion  Login Details

        #region Get Details

        /// <summary>
        /// GetLastLogOffTime
        /// Function to get last logofftime from LoginHistory table
        /// </summary>
        /// <param name="sessionID">SessionID</param>
        /// <returns>LastLogoffTime</returns>
        public DateTime? GetLastLogoffTime(Guid sessionID, String VersionNo = "")
        {
            DateTime? lastLogoffTime = null;
            ISession session = null;

            try
            {
                //2013.08.01 FSWW, Ramesh M Added For Add if condition for Error log ON/OFF switch control
                if (LoggingStatus == "on")
                {

                }
                session = GetSession();

                if (validateUserSession(sessionID, VersionNo))
                {
                    lastLogoffTime = DALMethods.GetLastLogoffTime(sessionID, session, VersionNo);
                }

                CloseSession(session);
            }
            catch (ApplicationException ex)
            {
                if (session != null)
                {
                    CloseSession(session);
                }
                // 2013.07.22 FSWW, Ramesh M Added For Add More Details about calling function in Error log file.
                Logging.LogError(ex, "SessionID-" + sessionID + "\n");
                throw ex;

            }
            catch (Exception ex)
            {
                if (session != null)
                {
                    CloseSession(session);
                }
                // 2013.06.24 FSWW, Ramesh M Added For CR#58976 To Add More Details about calling function in Error log file.
                Logging.LogError(ex, "SessionID-" + sessionID + "\n");
                throw ex;
            }
            finally
            {
                if (session != null)
                {
                    CloseSession(session);
                }

            }

            return lastLogoffTime;
        }

        // 06-26-2014  MadhuVenkat k - Added for CR 64058  - For Add orderDispatchHistory 
        /// <summary>
        /// AddOrderDipatchHistory
        /// </summary>
        /// <param name="SysTrxNo">SysTrxNo</param>
        /// <param name="companyID">companyID</param>
        /// <param name="password">password</param>
        /// <param name="DefDriverID">DefDriverID</param>
        /// <param name="DefVehicleID">DefVehicleID</param>
        /// <param name="OldDriverID">OldDriverID</param>
        /// <param name="OldVehicleID">OldVehicleID</param>
        /// <returns>True = Inserted successfully, False = Faile</returns>
        public Boolean AddOrderDipatchHistory(Decimal SysTrxNo, String companyID, String password, Int32 DefDriverID, Int32 DefVehicleID, Int32 OldDriverID, Int32 OldVehicleID, String VersionNo = "")
        {
            Boolean status = false;
            ISession session = null;
            Boolean NeedUpdate = true;
            try
            {
                //2013.08.01 FSWW, Ramesh M Added For Add if condition for Error log ON/OFF switch control
                if (LoggingStatus == "on")
                {

                }
                session = GetSession();
                if (ValidateCustomerLogin(companyID, password, VersionNo))
                {

                    DALMethods.AddOrderDipatchHistory(SysTrxNo, companyID, DefDriverID, DefVehicleID, OldDriverID, OldVehicleID, NeedUpdate, session, VersionNo);

                    status = true;
                }
                CloseSession(session);

            }
            catch (ApplicationException ex)
            {
                if (session != null)
                {
                    CloseSession(session);
                }
                // 2013.07.22 FSWW, Ramesh M Added For Add More Details about calling function in Error log file.
                Logging.LogError(ex, "AddOrderDipatchHistory : CustomerID-" + companyID + ", VehicleID-" + SysTrxNo + "\n");
                throw ex;
            }
            catch (Exception ex)
            {
                if (session != null)
                {
                    CloseSession(session);
                }
                // 2013.06.24 FSWW, Ramesh M Added For CR#58976 To Add More Details about calling function in Error log file.
                Logging.LogError(ex, "AddOrderDipatchHistory : CustomerID-" + companyID + ", VehicleID-" + SysTrxNo + "\n");
                throw ex;
            }
            finally
            {
                if (session != null)
                {
                    CloseSession(session);
                }
            }

            return status;
        }

        // 06-26-2014  MadhuVenkat k - Added for CR 64058  - For Update Status in OrderDipatchHistory
        /// <summary>
        /// UpdateOrderDipatchHistory
        /// Function to update the records into OrderDipatchHistory table
        /// </summary>
        /// <param name="UserName">User name</param>
        /// <param name="password">Password</param>
        /// <param name="SysTrxNo">SysTrxNo</param>
        /// <param name="customerID">Customer ID</param> 
        /// <param name="customerID">Customer ID</param> 
        /// <param name="OldVehicleID">OldVehicleID</param>
        public Boolean UpdateOrderDipatchHistory(String UserName, String password, Decimal SysTrxNo, String companyID, Int32 OldVehicleID, String VersionNo = "")
        {
            Boolean status = false;
            ISession session = null;

            try
            {
                //2013.08.01 FSWW, Ramesh M Added For Add if condition for Error log ON/OFF switch control
                if (LoggingStatus == "on")
                {

                }
                session = GetSession();
                if (ValidateUserLogin(UserName, password, companyID, OldVehicleID.ToString(), VersionNo))
                {

                    DALMethods.UpdateOrderDipatchHistory(SysTrxNo, companyID, session, VersionNo);

                    status = true;
                }
                CloseSession(session);

            }
            catch (ApplicationException ex)
            {
                if (session != null)
                {
                    CloseSession(session);
                }
                // 2013.07.22 FSWW, Ramesh M Added For Add More Details about calling function in Error log file.
                Logging.LogError(ex, "UpdateOrderDipatchHistory : CustomerID-" + companyID + ", VehicleID-" + SysTrxNo + "\n");
                throw ex;
            }
            catch (Exception ex)
            {
                if (session != null)
                {
                    CloseSession(session);
                }
                // 2013.06.24 FSWW, Ramesh M Added For CR#58976 To Add More Details about calling function in Error log file.
                Logging.LogError(ex, "UpdateOrderDipatchHistory : CustomerID-" + companyID + ", VehicleID-" + SysTrxNo + "\n");
                throw ex;
            }
            finally
            {
                if (session != null)
                {
                    CloseSession(session);
                }
            }

            return status;
        }

        /// <summary>
        /// GetLoads
        /// Function to get the load records from load table
        /// </summary>
        /// <param name="UserName">User name</param>
        /// <param name="password">Password</param>
        /// <param name="vehicleID">Vehicle ID</param>
        /// <param name="companyID">Company ID</param>
        /// <param name="loadID">Load ID</param>
        /// <param name="loadNo">Load number</param>
        /// <param name="loadStatusID">Load status ID</param>
        /// <param name="includeOrders">Include orders</param>
        /// <param name="includeOrderItems">Include order items</param>
        /// <returns>List of load</returns>
        public List<Load> GetLoads(String UserName, String password, String vehicleID, String companyID, Guid loadID, String loadNo, String loadStatusID, Boolean includeOrders, Boolean includeOrderItems, DateTime? deviceTime = null, String VersionNo = "")
        {
            List<Load> lstLoads = new List<Load>();
            ISession session = null;
            try
            {
                if (!deviceTime.HasValue)
                    deviceTime = Convert.ToDateTime("1/1/1753 12:00:00 AM");
                //2013.08.01 FSWW, Ramesh M Added For Add if condition for Error log ON/OFF switch control
                if (LoggingStatus == "on")
                {
                }
                session = GetSession();
                if (ValidateUserLogin(UserName, password, companyID, vehicleID, VersionNo))
                {
                    Int32 driverID = DALMethods.GetDriverID(UserName, companyID, session, VersionNo);
                    if (driverID == 0)
                    {
                        //This exception will be rare if driver id set for current user is 0
                        throw new ApplicationException("Invalid driverID set for current user");
                    }
                    Int32 loginID = DALMethods.GetUserID(UserName, companyID, session, VersionNo);

                    lstLoads = DALMethods.GetLoads(true, ApplicationConstants.TimeToRemoveRCLoads, loginID, companyID, loadID, loadNo, loadStatusID, DataAccess.DALMethods.GetVehicleID(vehicleID, companyID, session, VersionNo), driverID, includeOrders, includeOrderItems, deviceTime, session, VersionNo);

                }

                CloseSession(session);

                //if (lstLoads.Count > 0)
                //{
                //    for (int i = 0; i < lstLoads.Count; i++)
                //    {
                //        if (lstLoads[i].Orders.Count > 0)
                //        {
                //            for (int j = 0; j < lstLoads[i].Orders.Count; i++)
                //            {
                //                if (lstLoads[i].Orders[j].OrderItems.Count > 0)
                //                {
                //                    for (int k = 0; k < lstLoads[i].Orders[j].OrderItems.Count; i++)
                //                    {
                //                        if (lstLoads[i].Orders[j].OrderItems[k].OrderItemComponent.Count > 0)
                //                        {
                //                            for (int l = 0; l < lstLoads[i].Orders[j].OrderItems[k].OrderItemComponent.Count; i++)
                //                            {

                //                            }
                //                        }
                //                    }
                //                }
                //            }
                //        }
                //    }
                //}
            }
            catch (ApplicationException ex)
            {
                if (session != null)
                {
                    CloseSession(session);
                }
                // 2013.07.22 FSWW, Ramesh M Added For Add More Details about calling function in Error log file.
                Logging.LogError(ex, "GetLoads : CustomerID-" + companyID + ", LoadID-" + loadID + "\n");
                throw ex;
            }
            catch (Exception ex)
            {
                if (session != null)
                {
                    CloseSession(session);
                }

                // 2013.07.22 FSWW, Ramesh M Added For Add More Details about calling function in Error log file.
                Logging.LogError(ex, "GetLoads : CustomerID-" + companyID + ", LoadID-" + loadID + "\n");
                //Logging.LogError(ex);
                throw ex;
            }
            finally
            {
                if (session != null)
                {
                    CloseSession(session);
                }
            }

            return lstLoads;
        }

        //2013.09.06 FSWW, Ramesh M Added For CR#60100 WarehouseLoads
        /// <summary>
        /// 
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="password"></param>
        /// <param name="vehicleID">Its SiteCode</param>
        /// <param name="companyID"></param>
        /// <param name="loadID"></param>
        /// <param name="loadNo"></param>
        /// <param name="loadStatusID"></param>
        /// <param name="includeOrders"></param>
        /// <param name="includeOrderItems"></param>
        /// <returns></returns>
        public List<WarehouseLoad> GetWareHouseLoads(String UserName, String password, String vehicleID, String companyID, Guid loadID, String loadNo, String loadStatusID, Boolean includeOrders, Boolean includeOrderItems, String VersionNo = "")
        {
            List<WarehouseLoad> lstLoads = new List<WarehouseLoad>();
            ISession session = null;
            try
            {
                //2013.08.01 FSWW, Ramesh M Added For Add if condition for Error log ON/OFF switch control
                if (LoggingStatus == "on")
                {
                }
                session = GetSession();
                if (ValidateUserLoginAndSiteID(UserName, password, companyID, vehicleID, VersionNo))
                {

                    Int32 loginID = DALMethods.GetUserID(UserName, companyID, session, VersionNo);


                    lstLoads = DALMethods.GetWareHouseLoads(true, ApplicationConstants.TimeToRemoveRCLoads, loginID, companyID, loadID, loadNo, loadStatusID, vehicleID, includeOrders, includeOrderItems, session, VersionNo);
                    //lstLoads = DALMethods.GetWareHouseLoads(ApplicationConstants.TimeToRemoveRCLoads, loginID, companyID, includeOrders, includeOrderItems, session);

                }
                CloseSession(session);
            }
            catch (ApplicationException ex)
            {
                if (session != null)
                {
                    CloseSession(session);
                }
                // 2013.07.22 FSWW, Ramesh M Added For Add More Details about calling function in Error log file.
                Logging.LogError(ex, "GetWareHouseLoads : CustomerID-" + companyID + ", LoadID-" + loadID + "\n");
                throw ex;
            }
            catch (Exception ex)
            {
                if (session != null)
                {
                    CloseSession(session);
                }

                // 2013.07.22 FSWW, Ramesh M Added For Add More Details about calling function in Error log file.
                Logging.LogError(ex, "GetWareHouseLoads : CustomerID-" + companyID + ", LoadID-" + loadID + "\n");
                //Logging.LogError(ex);
                throw ex;
            }
            finally
            {
                if (session != null)
                {
                    CloseSession(session);
                }
            }

            return lstLoads;
        }

        /// <summary>
        /// GetWagonLoads
        /// Function to get the load records from load table
        /// </summary>
        /// <param name="UserName">User name</param>
        /// <param name="password">Password</param>
        /// <param name="vehicleID">Vehicle ID</param>
        /// <param name="companyID">Company ID</param>
        /// <param name="loadID">Load ID</param>
        /// <param name="loadNo">Load number</param>
        /// <param name="loadStatusID">Load status ID</param>
        /// <param name="includeOrders">Include orders</param>
        /// <param name="includeOrderItems">Include order items</param>
        /// <returns>List of load</returns>
        public List<Load> GetWagonLoads(String UserName, String password, String vehicleID, String companyID, Guid loadID, String loadNo, String loadStatusID, Boolean includeOrders, Boolean includeOrderItems, String VersionNo = "")
        {
            List<Load> lstLoads = new List<Load>();
            ISession session = null;
            try
            {
                //2013.08.01 FSWW, Ramesh M Added For Add if condition for Error log ON/OFF switch control
                if (LoggingStatus == "on")
                {
                }
                session = GetSession();
                if (ValidateUserLogin(UserName, password, companyID, vehicleID, VersionNo))
                {
                    Int32 driverID = DALMethods.GetDriverID(UserName, companyID, session, VersionNo);
                    if (driverID == 0)
                    {
                        //This exception will be rare if driver id set for current user is 0
                        throw new ApplicationException("Invalid driverID set for current user");
                    }
                    Int32 loginID = DALMethods.GetUserID(UserName, companyID, session, VersionNo);

                    lstLoads = DALMethods.GetLoads(true, ApplicationConstants.TimeToRemoveRCLoads, loginID, companyID, loadID, loadNo, loadStatusID, DataAccess.DALMethods.GetVehicleID(vehicleID, companyID, session, VersionNo), driverID, includeOrders, includeOrderItems, Convert.ToDateTime("1/1/1753 12:00:00 AM"), session, VersionNo);

                }
                CloseSession(session);
            }
            catch (ApplicationException ex)
            {
                if (session != null)
                {
                    CloseSession(session);
                }
                // 2013.07.22 FSWW, Ramesh M Added For Add More Details about calling function in Error log file.
                Logging.LogError(ex, "GetWagonLoads : CustomerID-" + companyID + ", LoadID-" + loadID + "\n");
                throw ex;
            }
            catch (Exception ex)
            {
                if (session != null)
                {
                    CloseSession(session);
                }

                // 2013.07.22 FSWW, Ramesh M Added For Add More Details about calling function in Error log file.
                Logging.LogError(ex, "GetWagonLoads : CustomerID-" + companyID + ", LoadID-" + loadID + "\n");
                //Logging.LogError(ex);
                throw ex;
            }
            finally
            {
                if (session != null)
                {
                    CloseSession(session);
                }
            }

            return lstLoads;
        }


        /// <summary>
        /// GetLoadStatus
        /// Function to get the load status related to load id and login user id
        /// </summary>
        /// <param name="UserName">User name</param>
        /// <param name="password">Password</param>
        /// <param name="vehicleID">Vehicle ID</param>
        /// <param name="companyID">Company ID</param>
        /// <param name="loadID">Load ID</param>
        /// <returns>Load status</returns>
        public String GetLoadStatus(String UserName, String password, String vehicleID, String companyID, Guid loadID, String VersionNo = "")
        {
            String status = "I";
            ISession session = null;
            try
            {
                //2013.08.01 FSWW, Ramesh M Added For Add if condition for Error log ON/OFF switch control
                if (LoggingStatus == "on")
                {
                }
                session = GetSession();
                if (ValidateUserLogin(UserName, password, companyID, vehicleID, VersionNo))
                {
                    if (DALMethods.IsLoadUndispatchRequest(loadID, session, VersionNo))
                    {
                        status = "K";
                    }
                    else
                    {
                        Int32 loginID = DALMethods.GetUserID(UserName, companyID, session, VersionNo);
                        status = DALMethods.GetLoadStatus(loginID, loadID, session, VersionNo);
                    }
                }
                CloseSession(session);
            }
            catch (ApplicationException ex)
            {
                if (session != null)
                {
                    CloseSession(session);
                }
                // 2013.07.22 FSWW, Ramesh M Added For More Details about calling function in Error log file.
                Logging.LogError(ex, "GetLoadStatus : CustomerID-" + companyID + ", LoadID-" + loadID + "\n");
                throw ex;
            }
            catch (Exception ex)
            {
                if (session != null)
                {
                    CloseSession(session);
                }
                // 2013.06.24 FSWW, Ramesh M Added For CR#58976 To Add More Details about calling function in Error log file.
                Logging.LogError(ex, "GetLoadStatus :CustomerID-" + companyID + ", LoadID-" + loadID + "\n");
                throw ex;
            }
            finally
            {
                if (session != null)
                {
                    CloseSession(session);
                }
            }

            return status;
        }

        /// <summary>
        /// GetOrderStatus
        /// Function to get the order status related to login user id and order id
        /// </summary>
        /// <param name="UserName">User name</param>
        /// <param name="password">Password</param>
        /// <param name="vehicleID">Vehicle ID</param>
        /// <param name="companyID">Company ID</param>
        /// <param name="orderID">Order ID</param>
        /// <returns>Order status</returns>
        public String GetOrderStatus(String UserName, String password, String vehicleID, String companyID, Guid orderID, String VersionNo = "")
        {
            String status = "I";
            ISession session = null;
            try
            {
                //2013.08.01 FSWW, Ramesh M Added For Add if condition for Error log ON/OFF switch control
                if (LoggingStatus == "on")
                {
                }
                session = GetSession();
                if (ValidateUserLogin(UserName, password, companyID, vehicleID, VersionNo))
                {
                    Int32 loginID = DALMethods.GetUserID(UserName, companyID, session, VersionNo);
                    status = DALMethods.GetOrderStatus(loginID, orderID, session, VersionNo);
                }
                CloseSession(session);
            }
            catch (ApplicationException ex)
            {
                if (session != null)
                {
                    CloseSession(session);
                }

                // 2013.07.22 FSWW, Ramesh M Added For Add More Details about calling function in Error log file.
                Logging.LogError(ex, "GetOrderStatus : CustomerID-" + companyID + ", OrderID-" + orderID + "\n");
                throw ex;

            }
            catch (Exception ex)
            {
                if (session != null)
                {
                    CloseSession(session);
                }
                // 2013.06.24 FSWW, Ramesh M Added For CR#58976 To Add More Details about calling function in Error log file.
                Logging.LogError(ex, "GetOrderStatus : CustomerID-" + companyID + ", OrderID-" + orderID + "\n");
                throw ex;
            }
            finally
            {
                if (session != null)
                {
                    CloseSession(session);
                }
            }

            return status;
        }

        /// <summary>
        /// GetOrderCountByStatus
        /// Function to get count of order related to order status ID
        /// </summary>
        /// <param name="UserName">User name</param>
        /// <param name="password">Password</param>
        /// <param name="vehicleID">Vehicle ID</param>
        /// <param name="companyID">Company ID</param>
        /// <param name="loadID">Load ID</param>
        /// <param name="orderStatusID">Order status ID</param>
        /// <returns>Count of order</returns>
        public Int32 GetOrderCountByStatus(String UserName, String password, String vehicleID, String companyID, Guid loadID, String orderStatusID, String VersionNo = "")
        {
            Int32 cnt = 0;
            ISession session = null;
            try
            {
                //2013.08.01 FSWW, Ramesh M Added For Add if condition for Error log ON/OFF switch control
                if (LoggingStatus == "on")
                {
                }
                session = GetSession();
                if (ValidateUserLogin(UserName, password, companyID, vehicleID, VersionNo))
                {
                    cnt = DALMethods.GetOrderCountByStatus(loadID, orderStatusID, session, VersionNo);
                }
                CloseSession(session);

            }
            catch (ApplicationException ex)
            {
                if (session != null)
                {
                    CloseSession(session);
                }
                // 2013.07.22 FSWW, Ramesh M Added For Add More Details about calling function in Error log file.
                Logging.LogError(ex, "GetOrderCountByStatus : CustomerID-" + companyID + ", LoadID-" + loadID + "\n");
                throw ex;
            }
            catch (Exception ex)
            {
                if (session != null)
                {
                    CloseSession(session);
                }
                // 2013.06.24 FSWW, Ramesh M Added For CR#58976 To Add More Details about calling function in Error log file.
                Logging.LogError(ex, "GetOrderCountByStatus : CustomerID-" + companyID + ", LoadID-" + loadID + "\n");
                throw ex;
            }
            finally
            {
                if (session != null)
                {
                    CloseSession(session);
                }
            }

            return cnt;
        }

        /// <summary>
        /// GetBolHdrs
        /// Function to get records from BOL header table
        /// </summary>
        /// <param name="UserName">User name</param>
        /// <param name="password">Password</param>
        /// <param name="vehicleID">Vehicle ID</param>
        /// <param name="companyID">Company ID</param>
        /// <param name="bolHdrID">BOL header ID</param>
        /// <param name="loadID">Load ID</param>
        /// <param name="bolNo">BOL number</param>
        /// <returns>List of BOL header</returns>
        public List<BolHdr> GetBolHdrs(String UserName, String password, String vehicleID, String companyID, Guid bolHdrID, Guid loadID, String bolNo, String VersionNo = "")
        {
            List<BolHdr> lstBolHdrs = new List<BolHdr>();
            ISession session = null;
            try
            {
                //2013.08.01 FSWW, Ramesh M Added For Add if condition for Error log ON/OFF switch control
                if (LoggingStatus == "on")
                {
                }
                session = GetSession();
                if (ValidateUserLogin(UserName, password, companyID, vehicleID, VersionNo))
                {
                    lstBolHdrs = DALMethods.GetBolhdr(bolHdrID, loadID, bolNo, true, session, VersionNo);
                }
                CloseSession(session);

            }
            catch (ApplicationException ex)
            {
                if (session != null)
                {
                    CloseSession(session);
                }
                // 2013.07.22 FSWW, Ramesh M Added For Add More Details about calling function in Error log file.
                Logging.LogError(ex, "GetBolHdrs : CustomerID-" + companyID + ", LoadID-" + loadID + "\n");
                throw ex;
            }
            catch (Exception ex)
            {
                if (session != null)
                {
                    CloseSession(session);
                }
                // 2013.06.24 FSWW, Ramesh M Added For CR#58976 To Add More Details about calling function in Error log file.
                Logging.LogError(ex, "GetBolHdrs : CustomerID-" + companyID + ", LoadID-" + loadID + "\n");
                throw ex;
            }
            finally
            {
                if (session != null)
                {
                    CloseSession(session);
                }
            }

            return lstBolHdrs;
        }


        /// <summary>
        /// GetBOLHdrDetails
        /// Function to get records from BOL header table
        /// </summary>
        /// <param name="UserName">User name</param>
        /// <param name="password">Password</param>
        /// <param name="vehicleID">Vehicle ID</param>
        /// <param name="companyID">Company ID</param>
        /// <param name="loadID">Load ID</param>
        ///  <param name="VersionNo">VersionNo</param>
        public List<BolHdr> GetBOLHdrDetails(String UserName, String password, String vehicleID, String companyID, Guid loadID, String VersionNo = "")
        {
            List<BolHdr> lstBolHdrs = new List<BolHdr>();
            ISession session = null;
            try
            {
                //2013.08.01 FSWW, Ramesh M Added For Add if condition for Error log ON/OFF switch control
                if (LoggingStatus == "on")
                {
                }
                session = GetSession();
                if (ValidateUserLogin(UserName, password, companyID, vehicleID, VersionNo))
                {
                    lstBolHdrs = DALMethods.GetBolhdrDetails(loadID, session, VersionNo);
                }
                CloseSession(session);

            }
            catch (ApplicationException ex)
            {
                if (session != null)
                {
                    CloseSession(session);
                }
                // 2013.07.22 FSWW, Ramesh M Added For Add More Details about calling function in Error log file.
                Logging.LogError(ex, "GetBOLHdrDetails : CustomerID-" + companyID + ", LoadID-" + loadID + "\n");
                throw ex;
            }
            catch (Exception ex)
            {
                if (session != null)
                {
                    CloseSession(session);
                }
                // 2013.06.24 FSWW, Ramesh M Added For CR#58976 To Add More Details about calling function in Error log file.
                Logging.LogError(ex, "GetBOLHdrDetails : CustomerID-" + companyID + ", LoadID-" + loadID + "\n");
                throw ex;
            }
            finally
            {
                if (session != null)
                {
                    CloseSession(session);
                }
            }

            return lstBolHdrs;
        }

        /// <summary>
        /// GetBolitems
        /// Function to get records from BOL item table
        /// </summary>
        /// <param name="UserName">User name</param>
        /// <param name="password">Password</param>
        /// <param name="vehicleID">Vehicle ID</param>
        /// <param name="companyID">Company ID</param>
        /// <param name="bolItemID">BOL Item ID</param>
        /// <param name="bolHdrID">BOL header ID</param>
        /// <param name="SysTrxNo">System transaction number</param>
        /// <param name="sysTrxLine">System transaction line</param>
        /// <param name="componentNo">Component number</param>
        /// <returns>List of BOL item</returns>
        public List<Bolitem> GetBolitems(String UserName, String password, String vehicleID, String companyID, Guid bolItemID, Guid bolHdrID, Decimal SysTrxNo, Int32 sysTrxLine, Int32 componentNo, String VersionNo = "")
        {
            List<Bolitem> lstBolitems = new List<Bolitem>();
            ISession session = null;
            try
            {
                //2013.08.01 FSWW, Ramesh M Added For Add if condition for Error log ON/OFF switch control
                if (LoggingStatus == "on")
                {
                }
                session = GetSession();
                if (ValidateUserLogin(UserName, password, companyID, vehicleID, VersionNo))
                {
                    lstBolitems = DALMethods.GetBolitem(bolItemID, bolHdrID, SysTrxNo, sysTrxLine, componentNo, session, VersionNo);
                }
                CloseSession(session);

            }
            catch (ApplicationException ex)
            {
                if (session != null)
                {
                    CloseSession(session);
                }
                // 2013.07.22 FSWW, Ramesh M Added For Add More Details about calling function in Error log file.
                Logging.LogError(ex, "GetBolitems : CustomerID-" + companyID + "\n");
                throw ex;
            }
            catch (Exception ex)
            {
                {
                    CloseSession(session);
                }
                // 2013.06.24 FSWW, Ramesh M Added For CR#58976 To Add More Details about calling function in Error log file.
                Logging.LogError(ex, "GetBolitems : CustomerID-" + companyID + "\n");
                throw ex;
            }
            finally
            {
                if (session != null)
                {
                    CloseSession(session);
                }
            }

            return lstBolitems;
        }

        /// <summary>
        /// GetDeliveryDetails
        /// Function to get records from delivery details table
        /// </summary>
        /// <param name="UserName">User name</param>
        /// <param name="password">Password</param>
        /// <param name="vehicleID">Vehicle ID</param>
        /// <param name="companyID">Company ID</param>
        /// <param name="orderItemID">Order item ID</param>
        /// <returns>List of delivery details</returns>
        public List<DeliveryDetails> GetDeliveryDetails(String UserName, String password, String vehicleID, String companyID, Guid orderItemID, String VersionNo = "")
        {
            List<DeliveryDetails> lstDelitems = new List<DeliveryDetails>();
            ISession session = null;
            try
            {
                //2013.08.01 FSWW, Ramesh M Added For Add if condition for Error log ON/OFF switch control
                if (LoggingStatus == "on")
                {
                }
                session = GetSession();
                if (ValidateUserLogin(UserName, password, companyID, vehicleID, VersionNo))
                {
                    lstDelitems = DALMethods.GetDeliveryDetails(orderItemID, session, VersionNo);
                }
                CloseSession(session);

            }
            catch (ApplicationException ex)
            {
                if (session != null)
                {
                    CloseSession(session);
                }
                // 2013.07.22 FSWW, Ramesh M Added For Add More Details about calling function in Error log file.
                Logging.LogError(ex, "GetDeliveryDetails : CustomerID-" + companyID + "\n");
                throw ex;
            }
            catch (Exception ex)
            {
                if (session != null)
                {
                    CloseSession(session);
                }
                // 2013.06.24 FSWW, Ramesh M Added For CR#58976 To Add More Details about calling function in Error log file.
                Logging.LogError(ex, "GetDeliveryDetails : CustomerID-" + companyID + "\n");
                throw ex;
            }
            finally
            {
                if (session != null)
                {
                    CloseSession(session);
                }
            }

            return lstDelitems;
        }

        /// <summary>
        /// lstOrderFrtitems
        /// Function to get records from OrderFrt table
        /// </summary>
        /// <param name="UserName">User name</param>
        /// <param name="password">Password</param>
        /// <param name="vehicleID">Vehicle ID</param>
        /// <param name="companyID">Company ID</param>
        /// <param name="orderID">Order ID</param>
        /// <returns>List of OrderFrt</returns>
        public List<OrderFrt> GetOrderFrts(String UserName, String password, String vehicleID, String companyID, Guid orderID, String VersionNo = "")
        {
            List<OrderFrt> lstOrderFrtitems = new List<OrderFrt>();
            ISession session = null;
            try
            {
                //2013.08.01 FSWW, Ramesh M Added For Add if condition for Error log ON/OFF switch control
                if (LoggingStatus == "on")
                {
                }
                session = GetSession();
                if (ValidateUserLogin(UserName, password, companyID, vehicleID, VersionNo))
                {
                    lstOrderFrtitems = DALMethods.GetOrderFrts(orderID, session, VersionNo);
                }
                CloseSession(session);

            }
            catch (ApplicationException ex)
            {
                if (session != null)
                {
                    CloseSession(session);
                }
                // 2013.07.22 FSWW, Ramesh M Added For Add More Details about calling function in Error log file.
                Logging.LogError(ex, "GetOrderFrts : CustomerID-" + companyID + ", OrderID-" + orderID + "\n");
                throw ex;
            }
            catch (Exception ex)
            {
                if (session != null)
                {
                    CloseSession(session);
                }
                // 2013.06.24 FSWW, Ramesh M Added For CR#58976 To Add More Details about calling function in Error log file.
                Logging.LogError(ex, "GetOrderFrts : CustomerID-" + companyID + ", OrderID-" + orderID + "\n");
                throw ex;
            }
            finally
            {
                if (session != null)
                {
                    CloseSession(session);
                }
            }

            return lstOrderFrtitems;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="companyID"></param>
        /// <param name="password"></param>
        /// <param name="SysTrxNo"></param>
        /// <returns></returns>
        public SignatureImage GetSignatureImage(String companyID, String password, Decimal SysTrxNo, String VersionNo = "")
        {
            SignatureImage signatureImage = null;
            ISession session = null;
            try
            {
                //2013.08.01 FSWW, Ramesh M Added For Add if condition for Error log ON/OFF switch control
                if (LoggingStatus == "on")
                {
                }
                session = GetSession();
                if (ValidateCustomerLogin(companyID, password, VersionNo))
                {
                    if (DALMethods.GetSignatureImage(SysTrxNo, companyID, session, VersionNo) != null)
                    {
                        List<SignatureImage> lstSignatureImages = DALMethods.GetSignatureImage(SysTrxNo, companyID, session, VersionNo);

                        if (lstSignatureImages != null && lstSignatureImages.Count > 0)
                        {
                            signatureImage = lstSignatureImages[0];
                        }
                    }
                }
                CloseSession(session);

            }
            catch (ApplicationException ex)
            {
                if (session != null)
                {
                    CloseSession(session);
                }
                // 2013.07.22 FSWW, Ramesh M Added For Add More Details about calling function in Error log file.
                Logging.LogError(ex, "GetSignatureImage : CustomerID-" + companyID + "\n");
                throw ex;
            }
            catch (Exception ex)
            {
                if (session != null)
                {
                    CloseSession(session);
                }
                // 2013.06.24 FSWW, Ramesh M Added For CR#58976 To Add More Details about calling function in Error log file.
                Logging.LogError(ex, "GetSignatureImage : CustomerID-" + companyID + "\n");
                throw ex;
            }
            finally
            {
                if (session != null)
                {
                    CloseSession(session);
                }
            }

            return signatureImage;

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="companyID"></param>
        /// <param name="password"></param>
        /// <param name="SysTrxNo"></param>
        /// <returns></returns>
        // public Boolean UpdateSignatureStatus(String companyID, String password, Decimal SysTrxNo)
        // {
        //    ISession session = null;
        //   try
        //   {
        //       session = GetSession();
        //       DALMethods.UpdateSignatureStatus(SysTrxNo, companyID, session);
        //      CloseSession(session);

        //   }
        //   catch (ApplicationException ex)
        //   {
        //       if (session != null)
        //      {
        //         CloseSession(session);
        //    }
        //     throw ex;
        // }
        //  catch (Exception ex)
        //  {
        //      if (session != null)
        //     {
        //        CloseSession(session);
        //      }
        //      Logging.LogError(ex);
        //     throw ex;
        //  }
        //  finally
        //  {
        //      if (session != null)
        //      {
        //         CloseSession(session);
        //      }
        //   }

        //   return true;
        // }

        //  05-08-2013 FSWW Ramesh M added following code
        /// <summary>
        /// 
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="password"></param>
        /// <param name="vehicleID"></param>
        /// <param name="companyID"></param>
        /// <param name="orderID"></param>
        /// <param name="includeOrderItems"></param>
        /// <returns></returns>
        public List<OrderItem> GetPickedOrderItemDetails(String UserName, String password, String vehicleID, String companyID, Guid orderID, Boolean includeOrderItems, String VersionNo = "")
        {
            List<OrderItem> lstOrderItem = new List<OrderItem>();
            ISession session = null;
            try
            {
                //2013.08.01 FSWW, Ramesh M Added For Add if condition for Error log ON/OFF switch control
                if (LoggingStatus == "on")
                {
                }
                session = GetSession();
                if (ValidateUserLogin(UserName, password, companyID, vehicleID, VersionNo))
                {
                    lstOrderItem = DALMethods.GetPickedOrderItemDetails(orderID, includeOrderItems, session, VersionNo);
                }
                CloseSession(session);

            }
            catch (ApplicationException ex)
            {
                if (session != null)
                {
                    CloseSession(session);
                }
                // 2013.07.22 FSWW, Ramesh M Added For Add More Details about calling function in Error log file.
                Logging.LogError(ex, "GetPickedOrderItemDetails : CustomerID-" + companyID + ", OrderID-" + orderID + "\n");
                throw ex;
            }
            catch (Exception ex)
            {
                if (session != null)
                {
                    CloseSession(session);
                }
                // 2013.06.24 FSWW, Ramesh M Added For CR#58976 To Add More Details about calling function in Error log file.
                Logging.LogError(ex, "GetPickedOrderItemDetails : CustomerID-" + companyID + ", OrderID-" + orderID + "\n");
                throw ex;
            }
            finally
            {
                if (session != null)
                {
                    CloseSession(session);
                }
            }
            return lstOrderItem;


        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="password"></param>
        /// <param name="vehicleID"></param>
        /// <param name="companyID"></param>
        /// <param name="UserType"></param>
        /// <returns></returns>
        public List<GetDriverDetails> GetDriverDetails(String UserName, String password, String vehicleID, String companyID, String UserType, String VersionNo = "")
        {
            List<GetDriverDetails> lstDriver = new List<GetDriverDetails>();
            ISession session = null;
            try
            {
                //2013.08.01 FSWW, Ramesh M Added For Add if condition for Error log ON/OFF switch control
                if (LoggingStatus == "on")
                {
                }
                session = GetSession();
                if (ValidateUserLoginAndSiteID(UserName, password, companyID, vehicleID, VersionNo))
                {
                    lstDriver = DALMethods.GetDriverDetails(companyID, UserType, session, VersionNo);

                }
                CloseSession(session);

            }
            catch (ApplicationException ex)
            {
                if (session != null)
                {
                    CloseSession(session);
                }
                // 2013.07.22 FSWW, Ramesh M Added For Add More Details about calling function in Error log file.
                Logging.LogError(ex, "GetDriverDetails : CustomerID-" + companyID + "\n");
                throw ex;
            }
            catch (Exception ex)
            {
                if (session != null)
                {
                    CloseSession(session);
                }
                // 2013.06.24 FSWW, Ramesh M Added For CR#58976 To Add More Details about calling function in Error log file.
                Logging.LogError(ex, "GetDriverDetails : CustomerID-" + companyID + "\n");
                throw ex;
            }
            finally
            {
                if (session != null)
                {
                    CloseSession(session);
                }
            }
            return lstDriver;

        }

        /// <summary>
        /// GetVehicleDetails
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="password"></param>
        /// <param name="vehicleID"></param>
        /// <param name="companyID"></param>
        /// <returns></returns>
        // 2013.08.16 FSWW, Ramesh M Added For CR#59832 To Get Vehicle Details
        public List<GetVehicleDetails> GetVehicleDetails(String UserName, String password, String vehicleID, String companyID, String VersionNo = "")
        {
            List<GetVehicleDetails> lstVehicle = new List<GetVehicleDetails>();
            ISession session = null;
            try
            {
                //2013.08.01 FSWW, Ramesh M Added For Add if condition for Error log ON/OFF switch control
                if (LoggingStatus == "on")
                {
                }
                session = GetSession();
                //if (ValidateUserLogin(UserName, password, companyID, vehicleID))
                if (ValidateUserLoginAndSiteID(UserName, password, companyID, vehicleID, VersionNo))
                {
                    lstVehicle = DALMethods.GettingVehicleDetails(companyID, session, VersionNo);

                }
                CloseSession(session);

            }
            catch (ApplicationException ex)
            {
                if (session != null)
                {
                    CloseSession(session);
                }
                // 2013.07.22 FSWW, Ramesh M Added For Add More Details about calling function in Error log file.
                Logging.LogError(ex, "GetVehicleDetails : CustomerID-" + companyID + "\n");
                throw ex;
            }
            catch (Exception ex)
            {
                if (session != null)
                {
                    CloseSession(session);
                }
                // 2013.06.24 FSWW, Ramesh M Added For CR#58976 To Add More Details about calling function in Error log file.
                Logging.LogError(ex, "GetVehicleDetails : CustomerID-" + companyID + "\n");
                throw ex;
            }
            finally
            {
                if (session != null)
                {
                    CloseSession(session);
                }
            }
            return lstVehicle;

        }

        // 2013.08.27 FSWW, Ramesh M Added For CR#?.. To Get Inspection ElemetsID
        // 09-09-2014  CR#64208, Madhu, Add Modified date to GetInspectionElementsData
        /// <summary>
        /// GetInspectionElementsID
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="password"></param>
        /// <param name="vehicleID"></param>
        /// <param name="companyID"></param>
        /// <returns></returns>

        public List<InspectionElements> GetInspectionElementsID(String UserName, String password, String vehicleID, String companyID, String Modified, String VersionNo = "")
        {
            List<InspectionElements> lstElementsDetails = new List<InspectionElements>();
            ISession session = null;
            DateTime? ModifiedDate = Convert.ToDateTime(Modified);
            try
            {
                //2013.08.01 FSWW, Ramesh M Added For Add if condition for Error log ON/OFF switch control
                if (LoggingStatus == "on")
                {
                }
                session = GetSession();
                if (ValidateUserLogin(UserName, password, companyID, vehicleID, VersionNo))
                {
                    lstElementsDetails = DALMethods.GettingInspectionElementsDetails(companyID, ModifiedDate, session, VersionNo);

                }
                CloseSession(session);

            }
            catch (ApplicationException ex)
            {
                if (session != null)
                {
                    CloseSession(session);
                }
                // 2013.07.22 FSWW, Ramesh M Added For Add More Details about calling function in Error log file.
                Logging.LogError(ex, "GetInspectionElementsID : CustomerID-" + companyID + "\n");
                throw ex;
            }
            catch (Exception ex)
            {
                if (session != null)
                {
                    CloseSession(session);
                }
                // 2013.06.24 FSWW, Ramesh M Added For CR#58976 To Add More Details about calling function in Error log file.
                Logging.LogError(ex, "GetInspectionElementsID : CustomerID-" + companyID + "\n");
                throw ex;
            }
            finally
            {
                if (session != null)
                {
                    CloseSession(session);
                }
            }
            return lstElementsDetails;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sessionID"></param>
        /// <returns></returns>
        public Boolean IsSessionIDExist(Guid sessionID, ISession session, String VersionNo = "")
        {
            //ISession session = null;
            Boolean IsSessionExist = false;
            //try
            //{
            //    //2013.08.01 FSWW, Ramesh M Added For Add if condition for Error log ON/OFF switch control
            //    //if (LoggingStatus == "on")
            //    //{
            //    //    //2013.07.22 FSWW, Ramesh M Added For Add More Details about calling function in Error log file
            //    //    Logging.LogInfoAboutCallingFunction("Function Called:- IsSessionIDExist ; " + "SessionID-" + sessionID);
            //    //}
            //    session = GetSession();

            IsSessionExist = DALMethods.ValidateCurrentUserSession(sessionID, session, VersionNo);

            //    CloseSession(session);

            //}
            //catch (ApplicationException ex)
            //{
            //    //if (session != null)
            //    //{
            //    //    CloseSession(session);
            //    //}
            //    // 2013.07.22 FSWW, Ramesh M Added For  Add More Details about calling function in Error log file.
            //    Logging.LogError(ex, "SessionID-" + sessionID + "\n");
            //    throw ex;
            //}
            //catch (Exception ex)
            //{
            //    //if (session != null)
            //    //{
            //    //    CloseSession(session);
            //    //}
            //    // 2013.06.24 FSWW, Ramesh M Added For CR#58976 To Add More Details about calling function in Error log file.
            //    Logging.LogError(ex, "SessionID-" + sessionID + "\n");
            //    throw ex;
            //}
            //finally
            //{
            //    if (session != null)
            //    {
            //        if (LoggingStatus == "on")
            //        {
            //            //2013.09.11 FSWW, Ramesh M Added For Add More Details about calling function in Error log file
            //            Logging.LogInfoAboutCallingFunction("Function Called:- IsSessionIDExist ; " + " SessionID-" + sessionID + " , Session Exist Status - " + IsSessionExist);
            //        }

            //        CloseSession(session);
            //    }
            //}
            return IsSessionExist;
        }


        //2013.10.09 FSWW, Ramesh M Added For  CR#60620. 
        /// <summary>
        /// 
        /// </summary>
        /// <param name="CustomerID"></param>
        /// <returns></returns>
        public String ListOFLoadNosToMerge(String CustomerID, String VersionNo = "")
        {
            String LoadNos = null;
            LoadNos = DALMethods.ListOFLoadNosToMerge(CustomerID, ConfigurationManager.ConnectionStrings["DeliveryStreamCloud"].ToString(), VersionNo);
            return LoadNos;
        }
        //2013.10.09 FSWW, Ramesh M Added For  CR#60620. 
        /// <summary>
        /// 
        /// </summary>
        /// <param name="CustomerID"></param>        
        /// <param name="OrderNo"></param>
        /// <param name="OrderStatus"></param>
        /// <returns></returns>
        public Boolean ListOFOrderNosToUpdate(String CustomerID, String OrderNo, String OrderStatus, String VersionNo = "")
        {
            return DALMethods.ListOFOrderNosToMerge(CustomerID, OrderNo, OrderStatus, ConfigurationManager.ConnectionStrings["DeliveryStreamCloud"].ToString(), VersionNo);
        }


        //2014.01.16 Ramesh M Added For  CR#61759 to get from site list 
        /// <summary>
        /// 
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="password"></param>
        /// <param name="vehicleID"></param>
        /// <param name="companyID"></param>
        /// <param name="VersionNo"></param>
        /// <returns></returns>
        public List<SupplierSupplypointList> GetSupplierFromSiteList(String UserName, String password, String vehicleID, String companyID, String VersionNo = "")
        {
            List<SupplierSupplypointList> lstGetFromSiteList = new List<SupplierSupplypointList>();
            ISession session = null;
            try
            {
                //2013.08.01 FSWW, Ramesh M Added For Add if condition for Error log ON/OFF switch control
                if (LoggingStatus == "on")
                {
                }
                session = GetSession();
                if (ValidateUserLogin(UserName, password, companyID, vehicleID, VersionNo))
                {
                    lstGetFromSiteList = DALMethods.GettingFromSiteList(companyID, session, VersionNo);

                }
                CloseSession(session);

            }
            catch (ApplicationException ex)
            {
                if (session != null)
                {
                    CloseSession(session);
                }
                // 2013.07.22 FSWW, Ramesh M Added For Add More Details about calling function in Error log file.
                Logging.LogError(ex, "GetSupplierFromSiteList : CustomerID-" + companyID + "\n");
                throw ex;
            }
            catch (Exception ex)
            {
                if (session != null)
                {
                    CloseSession(session);
                }
                // 2013.06.24 FSWW, Ramesh M Added For CR#58976 To Add More Details about calling function in Error log file.
                Logging.LogError(ex, "GetSupplierFromSiteList : CustomerID-" + companyID + "\n");
                throw ex;
            }
            finally
            {
                if (session != null)
                {
                    CloseSession(session);
                }
            }
            return lstGetFromSiteList;

        }
        // 2014.01.23  Ramesh M Added For CR#61759 to get from site list based on shiptoID
        /// <summary>
        /// 
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="password"></param>
        /// <param name="vehicleID"></param>
        /// <param name="companyID"></param>
        /// <param name="ShipToID"></param>
        /// <param name="VersionNo"></param>
        /// <returns></returns>
        public List<SupplierSupplypointList> GetShipToBasedFromSiteList(String UserName, String password, String vehicleID, String companyID, String ShipToID, String VersionNo = "")
        {
            List<SupplierSupplypointList> lstGetFromSiteList = new List<SupplierSupplypointList>();
            ISession session = null;
            try
            {
                //2013.08.01 FSWW, Ramesh M Added For Add if condition for Error log ON/OFF switch control
                if (LoggingStatus == "on")
                {
                }
                session = GetSession();
                if (ValidateUserLogin(UserName, password, companyID, vehicleID, VersionNo))
                {
                    lstGetFromSiteList = DALMethods.GettingShipToFromSiteList(companyID, ShipToID, session, VersionNo);
                }
                CloseSession(session);

            }
            catch (ApplicationException ex)
            {
                if (session != null)
                {
                    CloseSession(session);
                }
                // 2013.07.22 FSWW, Ramesh M Added For Add More Details about calling function in Error log file.
                Logging.LogError(ex, "GetShipToBasedFromSiteList : CustomerID-" + companyID + "ShipToID-" + ShipToID + "\n");
                throw ex;
            }
            catch (Exception ex)
            {
                if (session != null)
                {
                    CloseSession(session);
                }
                // 2013.06.24 FSWW, Ramesh M Added For CR#58976 To Add More Details about calling function in Error log file.
                Logging.LogError(ex, "GetShipToBasedFromSiteList : CustomerID-" + companyID + "\n");
                throw ex;
            }
            finally
            {
                if (session != null)
                {
                    CloseSession(session);
                }
            }
            return lstGetFromSiteList;

        }


        /// <summary>
        /// GetDeliveryData
        /// Function to get records from BOLHDR and BOLITEM table
        /// </summary>
        /// <param name="UserName">User name</param>
        /// <param name="password">Password</param>
        /// <param name="vehicleID">Vehicle ID</param>
        /// <param name="companyID">Company ID</param>
        /// <param name="orderItemID">Order item ID</param>
        /// <returns>List of delivery details</returns>
        public List<DeliveryDetailsData> GetDeliveryData(String UserName, String password, String vehicleID, String companyID, Guid orderID, String VersionNo = "")
        {
            List<DeliveryDetailsData> lstDelitems = new List<DeliveryDetailsData>();
            ISession session = null;
            try
            {
                //2013.08.01 FSWW, Ramesh M Added For Add if condition for Error log ON/OFF switch control
                if (LoggingStatus == "on")
                {
                }
                session = GetSession();
                if (ValidateUserLogin(UserName, password, companyID, vehicleID, VersionNo))
                {
                    lstDelitems = DALMethods.GetDeliveryData(orderID, session, VersionNo);
                }
                CloseSession(session);

            }
            catch (ApplicationException ex)
            {
                if (session != null)
                {
                    CloseSession(session);
                }
                // 2013.07.22 FSWW, Ramesh M Added For Add More Details about calling function in Error log file.
                Logging.LogError(ex, "GetDeliveryData : CustomerID-" + companyID + "\n");
                throw ex;
            }
            catch (Exception ex)
            {
                if (session != null)
                {
                    CloseSession(session);
                }
                // 2013.06.24 FSWW, Ramesh M Added For CR#58976 To Add More Details about calling function in Error log file.
                Logging.LogError(ex, "GetDeliveryData : CustomerID-" + companyID + "\n");
                throw ex;
            }
            finally
            {
                if (session != null)
                {
                    CloseSession(session);
                }
            }

            return lstDelitems;
        }


        #endregion Get Details

        #region Update details

        //// 2013.07.03 FSWW Ramesh M Added String sStatus parmeter for CR#59047
        ///// <summary>
        ///// UpdateGPSHistory2
        ///// Function to insert the records into GPS history table
        ///// </summary>
        ///// <param name="longitude">Longitude</param>
        ///// <param name="latitude">Latitude</param>
        /////  <param name="sessionID">SessionID</param>
        ///// <param name="deviceTime">DeviceTime</param>
        ///// <returns>True = Updated successfully, False = Failed</returns>
        //public Boolean UpdateGPSHistory2(String longitude, String latitude, Guid sessionID, DateTime deviceTime, DateTime GMT, String sGpsStrength, String sStatus, String PreviousLongitude, String PreviousLatitude)
        //{
        //    Boolean updateStatus = false;
        //    ISession session = null;
        //    try
        //    {
        //        //2013.08.01 FSWW, Ramesh M Added For Add if condition for Error log ON/OFF switch control
        //        if (LoggingStatus == "on")
        //        {
        //            //2013.07.22 FSWW, Ramesh M Added For Add More Details about calling function in Error log file
        //            Logging.LogInfoAboutCallingFunction("Function Called:- UpdateGPSHistory2 ; " + "SessionID-" + sessionID);
        //        }
        //        session = GetSession();
        //        if (string.IsNullOrWhiteSpace(longitude) || string.IsNullOrWhiteSpace(latitude))
        //        {
        //            return false;
        //        }
        //        if (longitude.Equals("0") && latitude.Equals("0"))
        //        {
        //            return false;
        //        }
        //        if (validateUserSession(sessionID))
        //        {
        //            DALMethods.AddGPSHistory(longitude, latitude, sessionID, deviceTime, session, GMT, sGpsStrength, sStatus,PreviousLongitude,PreviousLatitude);
        //        }
        //        updateStatus = true;
        //    }
        //    catch (ApplicationException ex)
        //    {
        //        // 2013.07.22 FSWW, Ramesh M Added For Add More Details about calling function in Error log file.
        //        Logging.LogError(ex, "SessionID-" + sessionID + "\n");
        //        throw ex;
        //    }
        //    catch (Exception ex)
        //    {
        //        // 2013.06.24 FSWW, Ramesh M Added For CR#58976 To Add More Details about calling function in Error log file.
        //        Logging.LogError(ex, "SessionID-" + sessionID + "\n");
        //        throw ex;
        //    }
        //    finally
        //    {
        //        if (session != null)
        //        {
        //            CloseSession(session);
        //        }
        //    }

        //    return updateStatus;
        //}

        /// <summary>
        /// UpdateGPSHistory
        /// Function to insert the records into GPS history table
        /// </summary>
        /// <param name="lstGPSHist">GPSHistory</param>
        /// <returns>True = Updated successfully, False = Failed</returns>
        public Boolean UpdateGPSHistoryList(List<GPSHistory> lstGPSHist, String VersionNo = "")
        {
            Boolean updateStatus = false;
            ISession session = null;
            // 2013.11.19 FSWW, Ramesh M Added For CR#61151 
            Int32 ConfiguredSpeedLimit = Int32.MinValue;
            // 2013.06.24 FSWW, Ramesh M Added For CR#58976  To Get SessionID to Log Exception
            String SessionID = null;
            ConfiguredSpeedLimit = Convert.ToInt32(ConfigurationManager.AppSettings["ConfiguredSpeedLimit"]);
            try
            {
                session = GetSession();
                foreach (GPSHistory gpsHist in lstGPSHist)
                {
                    if (!string.IsNullOrWhiteSpace(gpsHist.Longitude) && !string.IsNullOrWhiteSpace(gpsHist.Latitude))
                    {
                        // 2015.03.17  MadhuVenkat K Added IsSessionIDExist - for loginsession is check available or not.
                        if (IsSessionIDExist(gpsHist.SessionID, session, VersionNo))
                        {
                            if (validateUserSession(gpsHist.SessionID, VersionNo))
                            {

                                // 2013.06.24 FSWW, Ramesh M Added For CR#58976 To Get SessionID to Log Exception
                                SessionID = gpsHist.SessionID.ToString();
                                // 2013.07.03 FSWW Ramesh M Added gpsHist.Status parmeter for CR#59047
                                // 2013.10.24 FSWW Ramesh M Added gpsHist.PreviousLongitude,gpsHist.PreviousLatitude- parmeters for CR#60386
                                // 2013.10.24 FSWW Ramesh M Added gpsHist.TruckSpeed For CR#61148, and removed gpsHist.PreviousLongitude,gpsHist.PreviousLatitude- parmeters
                                // 2014.03.05  Ramesh M Added For CR#62301 For City added
                                // 2014.11.17  MadhuVenkat K Modified for CR 65550 - Updating wrong status to the GPS History on driving
                                String lStatusUpdate = "S";
                                if ((string.IsNullOrWhiteSpace(gpsHist.StatusUpdate)) || (gpsHist.StatusUpdate == "M"))
                                {
                                    lStatusUpdate = "M";
                                }
                                //DateTime dt = gpsHist.DeviceTime.ToUniversalTime();
                                //Logging.LogInfoAboutCallingFunction("UpdateGPSHistoryList: DeviceTime " + gpsHist.DeviceTime + " GMT Time: " + gpsHist.DeviceTime.ToUniversalTime() + " SpecifyKind: " + DateTime.SpecifyKind(dt, DateTimeKind.Utc) + " LocalTime " + dt.ToLocalTime());
                                DALMethods.AddGPSHistory(gpsHist.Longitude, gpsHist.Latitude, gpsHist.SessionID, gpsHist.DeviceTime, session, gpsHist.DeviceTime.ToUniversalTime(), gpsHist.GpsStrength, gpsHist.Status, gpsHist.TruckSpeed, ConfiguredSpeedLimit, gpsHist.State, gpsHist.DriverID, gpsHist.VehicleID, gpsHist.CustomerID, gpsHist.LoginID, gpsHist.IsNewSession, gpsHist.City, lStatusUpdate, VersionNo);
                            }
                        }
                    }
                }
                //2013.08.01 FSWW, Ramesh M Added For Add if condition for Error log ON/OFF switch control
                if (LoggingStatus == "on")
                {
                }
                updateStatus = true;

            }
            catch (ApplicationException ex)
            {
                // 2013.07.22 FSWW, Ramesh M Added For Add More Details about calling function in Error log file.
                Logging.LogError(ex, "UpdateGPSHistoryList : SessionID-" + SessionID + "\n");
                throw ex;
            }
            catch (Exception ex)
            {
                // 2013.06.24 FSWW, Ramesh M Added For CR#58976 To Add More Details about calling function in Error log file.
                Logging.LogError(ex, "UpdateGPSHistoryList : SessionID-" + SessionID + "\n");
                throw ex;
            }
            finally
            {
                if (session != null)
                {
                    CloseSession(session);
                }
            }

            return updateStatus;
        }

        /// <summary>
        /// UpdateGPSHistory
        /// Function to insert the records into GPS history table
        /// </summary>
        /// /// <param name="UserName">User name</param>
        /// <param name="password">Password</param>
        /// <param name="vehicleID">Vehicle ID</param>
        /// <param name="companyID">Company ID</param>
        /// <param name="longitude">Longitude</param>
        /// <param name="latitude">Latitude</param>
        ///  <param name="deviceID">deviceID</param>
        /// <param name="deviceTime">DeviceTime</param>
        /// <returns>True = Updated successfully, False = Failed</returns>
        public Boolean UpdateGPSHistory(String UserName, String password, String vehicleID, String companyID, String longitude, String latitude, String deviceID, DateTime deviceTime, DateTime GMT, String VersionNo = "")
        {
            Boolean updateStatus = false;
            ISession session = null;
            try
            {
                //2013.08.01 FSWW, Ramesh M Added For Add if condition for Error log ON/OFF switch control
                if (LoggingStatus == "on")
                {
                }
                session = GetSession();
                if (string.IsNullOrWhiteSpace(longitude) || string.IsNullOrWhiteSpace(latitude))
                {
                    return false;
                }

                if (longitude.Equals("0") && latitude.Equals("0"))
                {
                    return false;
                }
                if (ValidateUserLogin(UserName, password, companyID, vehicleID, VersionNo))
                {
                    Int32 loginID = DALMethods.GetUserID(UserName, companyID, session, VersionNo);
                    //DateTime dt = deviceTime.ToUniversalTime();
                    //Logging.LogInfoAboutCallingFunction("UpdateGPSHistory: DeviceTime " + deviceTime + " GMT Time: " + deviceTime.ToUniversalTime() + " SpecifyKind: " + DateTime.SpecifyKind(dt, DateTimeKind.Utc) + " LocalTime: " + dt.ToLocalTime());
                    DALMethods.AddGPSHistoryByUser(loginID, longitude, latitude, deviceTime, session, deviceTime.ToUniversalTime(), VersionNo);
                    updateStatus = true;
                }
            }
            catch (ApplicationException ex)
            {
                // 2013.07.22 FSWW, Ramesh M Added For  Add More Details about calling function in Error log file.
                Logging.LogError(ex, "UpdateGPSHistory : CustomerID-" + companyID + "\n");
                throw ex;
            }
            catch (Exception ex)
            {
                // 2013.06.24 FSWW, Ramesh M Added For CR#58976 To Add More Details about calling function in Error log file.
                Logging.LogError(ex, "UpdateGPSHistory : CustomerID-" + companyID + "\n");
                throw ex;
            }
            finally
            {
                if (session != null)
                {
                    CloseSession(session);
                }
            }
            return updateStatus;
        }

        /// <summary>
        /// UpdateLoadStatus
        /// Function to insert the records into load status history table
        /// </summary>
        /// <param name="UserName">User name</param>
        /// <param name="password">Password</param>
        /// <param name="vehicleID">Vehicle ID</param>
        /// <param name="companyID">Company ID</param>
        /// <param name="loadID">Load ID</param>
        /// <param name="loadStatusID">Load status ID</param>
        /// <param name="longitude">Longitude</param>
        /// <param name="latitude">Latitude</param>
        /// <param name="deviceID">deviceID</param>
        /// <param name="deviceTime">DeviceTime</param>
        /// <returns>True = Updated successfully, False = Failed</returns>
        public Boolean UpdateLoadStatus(String UserName, String password, String vehicleID, String companyID, Guid loadID, String loadStatusID, String longitude, String latitude, String city, String state, String deviceID, DateTime deviceTime, String VersionNo = "", String RejectedNotes = "")
        {
            Boolean updateStatus = true;
            ISession session = null;
            string LoadtypeByLoadID = string.Empty;
            try
            {
                //2013.08.01 FSWW, Ramesh M Added For Add if condition for Error log ON/OFF switch control
                if (LoggingStatus == "on")
                {
                }
                session = GetSession();
                if (ValidateUserLogin(UserName, password, companyID, vehicleID, VersionNo))
                {
                    //Check Load is exist or not
                    if (DALMethods.LoadNotExist(loadID, session, VersionNo))
                    {
                        return updateStatus;
                    }
                    //2013.12.24 FSWW, Ramesh M Added For Add CR#60902 for CR Reopen
                    LoadtypeByLoadID = DALMethods.GetLoadtypeByLoadID(loadID, session, VersionNo).ToLower();
                    if ((LoadtypeByLoadID == "v" || LoadtypeByLoadID == "z") && ((loadStatusID != "D") || (loadStatusID != "U")))
                    {
                        //if ((DALMethods.GetLoadtypeByLoadID(loadID, session, VersionNo).ToLower() == "v") && ((loadStatusID != "D") || (loadStatusID != "U")))
                        //{
                        Int32 loginID = DALMethods.GetUserID(UserName, companyID, session, VersionNo);
                        DALMethods.AddLoadStatus(loadID, loginID, loadStatusID, longitude, latitude, city, state, deviceID, deviceTime, session, VersionNo);
                        DALMethods.UpdateLoadTime(loadID, deviceTime, session, VersionNo);
                        if ((loadStatusID == "A") || (loadStatusID == "R"))
                        {
                            Int32 driverID = DALMethods.GetDriverID(UserName, companyID, session, VersionNo);
                            if (driverID == 0)
                            {
                                //This exception will be rare if driver id set for current user is 0
                                throw new ApplicationException("Invalid driverID set for current user");
                            }
                            else
                            {
                                DALMethods.UpdateLoadDetails(loadID, companyID, DataAccess.DALMethods.GetVehicleID(vehicleID, companyID, session, VersionNo), driverID, RejectedNotes, loadStatusID == "R" ? true : false, session, VersionNo);
                            }
                        }
                        else if (loadStatusID == "Z")
                        {
                            //DALMethods.DeleteLoad(loadID, session);
                        }
                        else if (loadStatusID == "B")
                        {
                            DALMethods.UpdateIsDeleteLoadFlag(loadID, deviceTime, session);
                        }
                    }
                    //For Warehouse Shipped Loads
                    else if ((loadStatusID == "D") || (loadStatusID == "U"))
                    {
                        Int32 loginID = DALMethods.GetUserID(UserName, companyID, session);
                        DALMethods.AddLoadStatus(loadID, loginID, loadStatusID, longitude, latitude, city, state, deviceID, deviceTime, session, VersionNo);
                        DALMethods.UpdateLoadTime(loadID, deviceTime, session, VersionNo);
                        if ((loadStatusID == "A") || (loadStatusID == "R"))
                        {
                            Int32 driverID = DALMethods.GetDriverID(UserName, companyID, session, VersionNo);
                            if (driverID == 0)
                            {
                                //This exception will be rare if driver id set for current user is 0
                                throw new ApplicationException("Invalid driverID set for current user");
                            }
                            else
                            {
                                DALMethods.UpdateLoadDetails(loadID, companyID, DataAccess.DALMethods.GetVehicleID(vehicleID, companyID, session, VersionNo), driverID, RejectedNotes, loadStatusID == "R" ? true : false, session, VersionNo);
                            }
                        }
                        else if (loadStatusID == "Z")
                        {
                            //DALMethods.DeleteLoad(loadID, session, VersionNo);
                        }
                        else if (loadStatusID == "B")
                        {
                            DALMethods.UpdateIsDeleteLoadFlag(loadID, deviceTime, session);
                        }
                    }
                    else if (DALMethods.GetLoadtypeByLoadID(loadID, session, VersionNo).ToLower() == "w")
                    {
                        Int32 loginID = DALMethods.GetUserID(UserName, companyID, session, VersionNo);

                        Int32 AssignedDriverID = DALMethods.GetDriverIDByUsingLoginId(loginID, companyID, session, VersionNo);
                        if ((loadStatusID == "A") || (loadStatusID == "R"))
                        {
                            if ((loadStatusID == "R"))
                            {
                                //For Update LoadStatushistory Table details
                                DALMethods.AddLoadStatus(loadID, loginID, loadStatusID, longitude, latitude, city, state, deviceID, deviceTime, session, VersionNo);
                                DALMethods.UpdateLoadTime(loadID, deviceTime, session, VersionNo);
                            }
                            else if ((loadStatusID == "A"))
                            {
                                DALMethods.UpdateLoadStatus(loadID, loginID, session, VersionNo);
                                DALMethods.UpdateLoadTime(loadID, deviceTime, session, VersionNo);

                                //For Update Load Table details
                                DALMethods.UpdateLoadDetails(loadID, companyID, DataAccess.DALMethods.GetVehicleID(vehicleID, companyID, session, VersionNo), AssignedDriverID, RejectedNotes, loadStatusID == "R" ? true : false, session, VersionNo);
                            }
                        }
                        else if (loadStatusID == "Z")
                        {
                            //DALMethods.DeleteLoad(loadID, session, VersionNo);
                        }
                        else if (loadStatusID == "B")
                        {
                            DALMethods.UpdateIsDeleteLoadFlag(loadID, deviceTime, session);
                        }
                    }

                }
                CloseSession(session);
            }
            catch (ApplicationException ex)
            {
                updateStatus = false;
                if (session != null)
                {
                    CloseSession(session);
                }
                // 2013.07.22 FSWW, Ramesh M Added For Add More Details about calling function in Error log file.
                //Logging.LogError(ex, "UpdateLoadStatus : CustomerID-" + companyID + ", LoadID-" + loadID + "\n");
                Logging.LogError(ex, "UpdateLoadStatus : CustomerID-" + companyID + ", LoadID-" + loadID + ", UserName- " + UserName + ", vehicleID-" + vehicleID + "\n");
                throw ex;
            }
            catch (Exception ex)
            {
                updateStatus = false;
                if (session != null)
                {
                    CloseSession(session);
                }
                // 2013.06.24 FSWW, Ramesh M Added For CR#58976 To Add More Details about calling function in Error log file.
                //Logging.LogError(ex, "UpdateLoadStatus : CustomerID-" + companyID + ", LoadID-" + loadID + "\n");
                Logging.LogError(ex, "UpdateLoadStatus : CustomerID-" + companyID + ", LoadID-" + loadID + ", UserName- " + UserName + ", vehicleID-" + vehicleID + "\n");
                throw ex;
            }
            finally
            {
                if (session != null)
                {
                    CloseSession(session);
                }
            }

            return updateStatus;
        }

        //2013.09.26 FSWW, Ramesh M Added For CR#59831 Separate Method for Accepting Warehouse loads
        /// <summary>
        /// AcceptWarehouseLoad
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="password"></param>
        /// <param name="SiteCode"></param>
        /// <param name="companyID"></param>
        /// <param name="loadID"></param>
        /// <param name="loadStatusID"></param>
        /// <param name="longitude"></param>
        /// <param name="latitude"></param>
        /// <param name="deviceID"></param>
        /// <param name="deviceTime"></param>
        /// <returns>True = Updated successfully, False = Failed</returns>
        public Boolean AcceptWarehouseLoad(String UserName, String password, String SiteCode, String companyID, Guid loadID, String loadStatusID, String longitude, String latitude, String deviceID, DateTime deviceTime, String VersionNo = "")
        {
            Boolean updateStatus = true;
            ISession session = null;
            try
            {
                //2013.08.01 FSWW, Ramesh M Added For Add if condition for Error log ON/OFF switch control
                if (LoggingStatus == "on")
                {
                }
                session = GetSession();

                if (loadStatusID.ToUpper() == "H")
                {
                    if (ValidateUserLoginAndSiteID(UserName, password, companyID, SiteCode, VersionNo))
                    {
                        //Check Load is exist or not
                        if (DALMethods.LoadNotExist(loadID, session, VersionNo))
                        {
                            return updateStatus;
                        }
                        Int32 loginID = DALMethods.GetUserID(UserName, companyID, session, VersionNo);
                        //DALMethods.AddLoadStatus(loadID, loginID, loadStatusID, longitude, latitude, deviceID, deviceTime, session, VersionNo);
                        DALMethods.UpdateLoadTime(loadID, deviceTime, session, VersionNo);
                    }
                }
                CloseSession(session);
            }
            catch (ApplicationException ex)
            {
                updateStatus = false;
                if (session != null)
                {
                    CloseSession(session);
                }
                // 2013.07.22 FSWW, Ramesh M Added For Add More Details about calling function in Error log file.
                Logging.LogError(ex, "AcceptWarehouseLoad : CustomerID-" + companyID + ", LoadID-" + loadID + "\n");
                throw ex;
            }
            catch (Exception ex)
            {
                updateStatus = false;
                if (session != null)
                {
                    CloseSession(session);
                }
                // 2013.06.24 FSWW, Ramesh M Added For CR#58976 To Add More Details about calling function in Error log file.
                Logging.LogError(ex, "AcceptWarehouseLoad : CustomerID-" + companyID + ", LoadID-" + loadID + "\n");
                throw ex;
            }
            finally
            {
                if (session != null)
                {
                    CloseSession(session);
                }
            }

            return updateStatus;
        }

        //2013.09.26 FSWW, Ramesh M Added For CR#59831 Separate Method for Shipping Warehouse loads
        /// <summary>
        /// ShippedWarehouseLoad
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="password"></param>
        /// <param name="SiteCode"></param>
        /// <param name="companyID"></param>
        /// <param name="loadID"></param>
        /// <param name="loadStatusID"></param>
        /// <param name="longitude"></param>
        /// <param name="latitude"></param>
        /// <param name="deviceID"></param>
        /// <param name="deviceTime"></param>
        /// <param name="driverID"></param>
        /// <param name="vehicleID"></param>
        /// <returns>True = Updated successfully, False = Failed</returns>
        public Boolean AcceptAndShippedWarehouseLoad(String UserName, String password, String SiteCode, String companyID, Guid loadID, String loadStatusID, String longitude, String latitude, String deviceID, DateTime deviceTime, Int32 driverID, Int32 vehicleID, String VersionNo = "")
        {
            Boolean updateStatus = true;
            Int32 AssignedDriverloginID = 0;
            Int32 WarehouseUserloginID = 0;
            Int32? AssignedVehicleID = null;
            Int32? AssignedDriverID = null;
            ISession session = null;
            try
            {

                //2013.08.01 FSWW, Ramesh M Added For Add if condition for Error log ON/OFF switch control
                if (LoggingStatus == "on")
                {
                }
                session = GetSession();
                if (loadStatusID.ToUpper() == "H")
                {
                    if (ValidateUserLoginAndSiteID(UserName, password, companyID, SiteCode, VersionNo))
                    {
                        //Check Load is exist or not
                        if (DALMethods.LoadNotExist(loadID, session, VersionNo))
                        {
                            return updateStatus;
                        }
                        WarehouseUserloginID = DALMethods.GetUserID(UserName, companyID, session, VersionNo);
                        //DALMethods.AddLoadStatus(loadID, WarehouseUserloginID, loadStatusID, longitude, latitude, deviceID, deviceTime, session, VersionNo);
                        DALMethods.UpdateLoadTime(loadID, deviceTime, session, VersionNo);


                    }
                }
                else
                {
                    //Either One is mandatory: DriverID/VehicleID
                    if ((driverID != -1) || (vehicleID != -1))
                    {
                        if (loadStatusID.ToUpper() == "L" || loadStatusID.ToUpper() == "R")
                        {
                            if (ValidateUserLoginAndSiteID(UserName, password, companyID, SiteCode, VersionNo))
                            {
                                //Check Load is exist or not
                                if (DALMethods.LoadNotExist(loadID, session, VersionNo))
                                {
                                    return updateStatus;
                                }

                                //if (driverID == -1)
                                //{
                                //    WarehouseUserloginID = DALMethods.GetUserID(UserName, companyID, session);
                                //}
                                //else if (driverID != 0)
                                //{
                                //    AssignedDriverloginID = driverID;
                                //    //loginID = DALMethods.GetUserIDByDriverID(driverID, companyID, session);
                                //}

                                WarehouseUserloginID = DALMethods.GetUserID(UserName, companyID, session, VersionNo);
                                if ((driverID != -1) && (driverID != 0))
                                {
                                    AssignedDriverloginID = driverID;
                                }

                                // Int32 loginID = DALMethods.GetUserID(UserName, companyID, session);

                                if ((driverID == -1) || (vehicleID == -1))
                                {
                                    //DALMethods.AddLoadStatus(loadID, WarehouseUserloginID, loadStatusID, longitude, latitude, deviceID, deviceTime, session, VersionNo);
                                }
                                else
                                {
                                    //DALMethods.AddLoadStatus(loadID, AssignedDriverloginID, loadStatusID, longitude, latitude, deviceID, deviceTime, session, VersionNo);
                                }
                                DALMethods.UpdateLoadTime(loadID, deviceTime, session, VersionNo);
                                //Load Accepted by Warehouse User
                                if (loadStatusID.ToUpper() == "L")
                                {
                                    if (driverID == -1)
                                    {
                                        AssignedDriverID = null;
                                    }
                                    else if (driverID != 0)
                                    {
                                        //Updating UpdatedBy column in loadstatushistory table with origional drivers loginID
                                        //DALMethods.UpdateLoadStatus(loadID, driverID, session);

                                        //Getting assigned drivers driverId using assigned drivers loginId
                                        AssignedDriverID = DALMethods.GetDriverIDByUsingLoginId(AssignedDriverloginID, companyID, session, VersionNo);
                                    }
                                    if (vehicleID != -1)
                                    {
                                        AssignedVehicleID = vehicleID;
                                    }

                                    DALMethods.UpdateLoadDetailsByWarehouse(loadID, companyID, AssignedVehicleID, AssignedDriverID, session, VersionNo);

                                }

                            }
                        }
                        else if (loadStatusID == "Z")
                        {
                            DALMethods.DeleteLoad(loadID, session, VersionNo);
                        }
                    }
                    else
                    {
                        if (loadStatusID.ToUpper() == "R")
                        {
                            WarehouseUserloginID = DALMethods.GetUserID(UserName, companyID, session, VersionNo);

                            //DALMethods.AddLoadStatus(loadID, WarehouseUserloginID, loadStatusID, longitude, latitude, deviceID, deviceTime, session, VersionNo);
                            DALMethods.UpdateLoadTime(loadID, deviceTime, session, VersionNo);
                        }
                        else
                        {
                            updateStatus = false;
                        }
                    }
                }
                CloseSession(session);

            }
            catch (ApplicationException ex)
            {
                updateStatus = false;
                if (session != null)
                {
                    CloseSession(session);
                }
                // 2013.07.22 FSWW, Ramesh M Added For Add More Details about calling function in Error log file.
                Logging.LogError(ex, "AcceptAndShippedWarehouseLoad : CustomerID-" + companyID + ", LoadID-" + loadID + "\n");
                throw ex;
            }
            catch (Exception ex)
            {
                updateStatus = false;
                if (session != null)
                {
                    CloseSession(session);
                }
                // 2013.06.24 FSWW, Ramesh M Added For CR#58976 To Add More Details about calling function in Error log file.
                Logging.LogError(ex, "AcceptAndShippedWarehouseLoad : CustomerID-" + companyID + ", LoadID-" + loadID + "\n");
                throw ex;
            }
            finally
            {
                if (session != null)
                {
                    CloseSession(session);
                }
            }

            return updateStatus;
        }


        /// <summary>
        /// UpdateOrderStatus
        /// Function to insert the records into order status history table
        /// </summary>
        /// <param name="UserName">User name</param>
        /// <param name="password">Password</param>
        /// <param name="vehicleID">Vehicle ID</param>
        /// <param name="companyID">Company ID</param>
        /// <param name="loadID">Load ID</param>
        /// <param name="orderID">Order ID</param>
        /// <param name="orderStatusID">Order Status ID</param>
        /// <param name="longitude">Longitude</param>
        /// <param name="latitude">Latitude</param>
        /// <param name="deviceID">deviceID</param>
        /// <param name="deviceTime">DeviceTime</param>
        /// <returns>True = Updated successfully, False = Failed</returns>
        public Boolean UpdateOrderStatus(String UserName, String password, String vehicleID, String companyID, Guid loadID, Guid orderID, String orderStatusID, String longitude, String latitude, String deviceID, DateTime deviceTime, String VersionNo = "")
        {
            Boolean updateStatus = true;
            ISession session = null;
            try
            {
                //2013.08.01 FSWW, Ramesh M Added For Add if condition for Error log ON/OFF switch control
                if (LoggingStatus == "on")
                {
                }
                session = GetSession();
                if (ValidateUserLogin(UserName, password, companyID, vehicleID, VersionNo))
                {
                    //Check Load is exist or not
                    if (DALMethods.LoadNotExist(loadID, session, VersionNo))
                    {
                        return updateStatus;
                    }
                    Int32 loginID = DALMethods.GetUserID(UserName, companyID, session, VersionNo);
                    DALMethods.AddOrderStatus(orderID, loginID, orderStatusID, longitude, latitude, deviceID, deviceTime, session, VersionNo);

                }
                CloseSession(session);
            }
            catch (ApplicationException ex)
            {
                updateStatus = false;
                if (session != null)
                {
                    CloseSession(session);
                }
                // 2013.07.22 FSWW, Ramesh M Added For  Add More Details about calling function in Error log file.
                Logging.LogError(ex, "UpdateOrderStatus :  CustomerID-" + companyID + ", LoadID-" + loadID + "\n");
                throw ex;
            }
            catch (Exception ex)
            {
                updateStatus = false;
                if (session != null)
                {
                    CloseSession(session);
                }
                // 2013.06.24 FSWW, Ramesh M Added For CR#58976 To Add More Details about calling function in Error log file.
                Logging.LogError(ex, "UpdateOrderStatus : CustomerID-" + companyID + ", LoadID-" + loadID + "\n");
                throw ex;
            }
            finally
            {
                if (session != null)
                {
                    CloseSession(session);
                }
            }

            return updateStatus;
        }

        //2013.08.29 FSWW, Ramesh M Added For CR#?.. Added User Type as InputParameter
        // 2014.03.17  Ramesh M Added For CR#62668 to get home terminal details
        /// <summary>
        /// UpdateDriver
        /// Function to update the driver
        /// </summary>
        /// <param name="companyID">Company ID</param>
        /// <param name="password">Password</param>
        /// <param name="driverID">Driver ID</param>
        /// <param name="UserName">User name</param>
        /// <param name="UserPassword">User Password</param>
        /// <param name="Email">Email</param>
        /// <param name="FirstName">First Name</param>
        /// <param name="MiddleName">Middle Name</param>
        /// <param name="LastName">Last Name</param>
        /// <param name="UserType">UserType</param>
        /// <returns>True = Updated successfully, False = Failed</returns>
        public Boolean UpdateDriver(String companyID, String password, Int32 driverID, String UserName, String UserPassword, String Email, String FirstName, String MiddleName, String LastName, String UserType,
                                    String Co_Name, String Co_Addr1, String Co_City, String Co_State, String Co_Zip, String HT_Descr, String HT_Addr1, String HT_City, String HT_State, String HT_Zip, DateTime HazMatDate, String VersionNo = "")
        {
            Boolean status = false;
            ISession session = null;
            try
            {
                //2013.08.01 FSWW, Ramesh M Added For Add if condition for Error log ON/OFF switch control
                if (LoggingStatus == "on")
                {
                }
                session = GetSession();
                if (ValidateCustomerLogin(companyID, password, VersionNo))
                {
                    if (!DALMethods.CheckDriver(companyID, driverID, session, VersionNo))
                    {
                        DALMethods.AddDrivers(companyID, driverID, session, VersionNo);
                    }
                    if (driverID > 0 && !String.IsNullOrWhiteSpace(UserName) && !String.IsNullOrWhiteSpace(UserPassword))
                    {
                        LoginUser loginUser = new LoginUser();
                        loginUser.CustomerID = companyID;
                        loginUser.DriverID = driverID;
                        loginUser.UserName = UserName;
                        loginUser.Password = UserPassword;
                        loginUser.Email = Email;
                        loginUser.FirstName = FirstName;
                        loginUser.MiddleName = MiddleName;
                        loginUser.LastName = LastName;
                        loginUser.UserType = UserType;
                        // 2014.03.17  Ramesh M Added For CR#62668 to get home terminal details
                        loginUser.Co_Name = Co_Name;
                        loginUser.Co_Addr1 = Co_Addr1;
                        loginUser.Co_City = Co_City;
                        loginUser.Co_State = Co_State;
                        loginUser.Co_Zip = Co_Zip;
                        loginUser.HT_Descr = HT_Descr;
                        loginUser.HT_Addr1 = HT_Addr1;
                        loginUser.HT_City = HT_City;
                        loginUser.HT_State = HT_State;
                        loginUser.HT_Zip = HT_Zip;
                        loginUser.HazMatDate = HazMatDate;

                        // 2014.02.17  Ramesh M Added UserType For Warehouse user duplication CR#62289
                        DALMethods.AddOrUpdateLoginDetails(loginUser, "D", session, VersionNo);
                    }


                    status = true;
                }
                CloseSession(session);

            }
            catch (ApplicationException ex)
            {
                if (session != null)
                {
                    CloseSession(session);
                }
                // 2013.07.22 FSWW, Ramesh M Added For Add More Details about calling function in Error log file.
                Logging.LogError(ex, "UpdateDriver : CustomerID-" + companyID + ", DriverID-" + driverID + "\n");
                throw ex;
            }
            catch (Exception ex)
            {
                if (session != null)
                {
                    CloseSession(session);
                }
                // 2013.06.24 FSWW, Ramesh M Added For CR#58976 To Add More Details about calling function in Error log file.
                Logging.LogError(ex, "UpdateDriver : CustomerID-" + companyID + ", DriverID-" + driverID + "\n");
                throw ex;
            }
            finally
            {
                if (session != null)
                {
                    CloseSession(session);
                }
            }

            return status;
        }

        //2013.08.29 FSWW, Ramesh M Added For CR#?.. To Update WareHouse Users in deliverystream from Ascend
        /// <summary>
        /// UpdateWareHouseUser
        /// </summary>
        /// <param name="companyID"></param>
        /// <param name="password"></param>
        /// <param name="SiteID"></param>
        /// <param name="SiteCode"></param>
        /// <param name="UserName"></param>
        /// <param name="UserPassword"></param>
        /// <param name="UserType"></param>
        /// <returns></returns>
        public Boolean UpdateWareHouseUser(String companyID, String password, Int32 SiteID, String SiteCode, String UserName, String UserPassword, String UserType, String VersionNo = "")
        {
            Boolean status = false;
            ISession session = null;
            try
            {
                //2013.08.01 FSWW, Ramesh M Added For Add if condition for Error log ON/OFF switch control
                if (LoggingStatus == "on")
                {
                }
                session = GetSession();
                if (ValidateCustomerLogin(companyID, password, VersionNo))
                {
                    ////2013.12.24 FSWW, Ramesh M commented Adding Driver For CR#61273
                    // For Driver Table
                    //if (!DALMethods.CheckDriver(companyID, SiteID, session))
                    //{
                    //    DALMethods.AddDrivers(companyID, SiteID, session);
                    //}

                    //For Warehouse Table
                    if (!DALMethods.CheckSiteID(companyID, SiteID, SiteCode, session, VersionNo))
                    {
                        DALMethods.AddSiteID(companyID, SiteID, SiteCode, session, VersionNo);
                    }
                    // For Loginuser table
                    if (SiteID > 0 && !String.IsNullOrWhiteSpace(UserName) && !String.IsNullOrWhiteSpace(UserPassword))
                    {
                        // In Ascend InsiteTable Password Value is not Encrypted
                        String ePassword = Encryption.doEncrypt(UserPassword);

                        LoginUser loginUser = new LoginUser();
                        loginUser.CustomerID = companyID;
                        loginUser.DriverID = SiteID;
                        loginUser.UserName = UserName;
                        loginUser.Password = ePassword;
                        loginUser.Email = null;
                        loginUser.FirstName = null;
                        loginUser.MiddleName = null;
                        loginUser.LastName = null;
                        loginUser.UserType = UserType;
                        // 2014.02.17  Ramesh M Added UserType For Warehouse user duplication CR#62289
                        DALMethods.AddOrUpdateLoginDetails(loginUser, "W", session, VersionNo);
                    }



                    status = true;
                }
                CloseSession(session);

            }
            catch (ApplicationException ex)
            {
                if (session != null)
                {
                    CloseSession(session);
                }
                // 2013.07.22 FSWW, Ramesh M Added For Add More Details about calling function in Error log file.
                Logging.LogError(ex, "UpdateWareHouseUser : CustomerID-" + companyID + ", SiteID-" + SiteID + "\n");
                throw ex;
            }
            catch (Exception ex)
            {
                if (session != null)
                {
                    CloseSession(session);
                }
                // 2013.06.24 FSWW, Ramesh M Added For CR#58976 To Add More Details about calling function in Error log file.
                Logging.LogError(ex, "UpdateWareHouseUser : CustomerID-" + companyID + ", SiteID-" + SiteID + "\n");
                throw ex;
            }
            finally
            {
                if (session != null)
                {
                    CloseSession(session);
                }
            }


            return status;
        }

        /// <summary>
        /// UpdateVehicle
        /// </summary>
        /// <param name="companyID">companyID</param>
        /// <param name="password">password</param>
        /// <param name="VehicleID">VehicleID</param>
        /// <param name="VehicleCode">VehicleCode</param>
        /// <returns>True = Inserted successfully, False = Faile</returns>
        public Boolean UpdateVehicle(String companyID, String password, Int32 VehicleID, String VehicleCode, Int32 VehicleType, Int32 OverShortSiteID, String VersionNo = "")
        {
            Boolean status = false;
            ISession session = null;
            try
            {
                //2013.08.01 FSWW, Ramesh M Added For Add if condition for Error log ON/OFF switch control
                if (LoggingStatus == "on")
                {
                }
                session = GetSession();
                if (ValidateCustomerLogin(companyID, password, VersionNo))
                {

                    DALMethods.AddOrUpdateVehicle(companyID, VehicleID, VehicleCode, false, VehicleType, OverShortSiteID, session, VersionNo);

                    status = true;
                }
                CloseSession(session);

            }
            catch (ApplicationException ex)
            {
                if (session != null)
                {
                    CloseSession(session);
                }
                // 2013.07.22 FSWW, Ramesh M Added For Add More Details about calling function in Error log file.
                Logging.LogError(ex, "UpdateVehicle : CustomerID-" + companyID + ", VehicleID-" + VehicleID + "\n");
                throw ex;
            }
            catch (Exception ex)
            {
                if (session != null)
                {
                    CloseSession(session);
                }
                // 2013.06.24 FSWW, Ramesh M Added For CR#58976 To Add More Details about calling function in Error log file.
                Logging.LogError(ex, "UpdateVehicle : CustomerID-" + companyID + ", VehicleID-" + VehicleID + "\n");
                throw ex;
            }
            finally
            {
                if (session != null)
                {
                    CloseSession(session);
                }
            }

            return status;
        }

        /// <summary>
        /// Update Signature Status
        /// </summary>
        /// <param name="companyID">companyID</param>
        /// <param name="password">password</param>
        /// <param name="SysTrxNo">SysTrxNo</param>
        /// <returns>Boolean</returns>
        public Boolean UpdateSignatureStatus(String companyID, String password, Decimal SysTrxNo, String VersionNo = "")
        {
            ISession session = null;
            try
            {
                //2013.08.01 FSWW, Ramesh M Added For Add if condition for Error log ON/OFF switch control
                if (LoggingStatus == "on")
                {
                }
                session = GetSession();
                DALMethods.UpdateSignatureStatus(SysTrxNo, companyID, session, VersionNo);
                CloseSession(session);

            }
            catch (ApplicationException ex)
            {
                if (session != null)
                {
                    CloseSession(session);
                }
                // 2013.07.22 FSWW, Ramesh M Added For  Add More Details about calling function in Error log file.
                Logging.LogError(ex, "UpdateSignatureStatus : CustomerID-" + companyID + ", SysTrxNo-" + SysTrxNo + "\n");
                throw ex;
            }
            catch (Exception ex)
            {
                if (session != null)
                {
                    CloseSession(session);
                }
                // 2013.06.24 FSWW, Ramesh M Added For CR#58976 To Add More Details about calling function in Error log file.
                Logging.LogError(ex, "UpdateSignatureStatus : CustomerID-" + companyID + ", SysTrxNo-" + SysTrxNo + "\n");
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
        /// UpdateFSDriverLogSched
        /// </summary>
        /// <param name="companyID">companyID</param>
        /// <param name="password">password</param>
        /// <param name="loadNo">loadNo</param>
        /// <returns>Boolean</returns>

        public Boolean UpdateFSDriverLogSched(String companyID, String password, int DriverLogSched, String VersionNo = "")
        {
            ISession session = null;
            Boolean updateStatus = false;
            try
            {
                //2013.08.01 FSWW, Ramesh M Added For Add if condition for Error log ON/OFF switch control
                if (LoggingStatus == "on")
                {
                }
                if (ValidateCustomerLogin(companyID, password, VersionNo))
                {
                    session = GetSession();
                    updateStatus = DALMethods.UpdateFSDriverLogSched(companyID, DriverLogSched, session, VersionNo);
                }
            }
            catch (Exception ex)
            {
                // 2013.06.24 FSWW, Ramesh M Added For CR#58976 To Add More Details about calling function in Error log file.
                Logging.LogError(ex, "UpdateFSDriverLogSched : CustomerID-" + companyID + ", DriverLogSched-" + DriverLogSched + "\n");
                throw ex;
            }
            finally
            {
                if (session != null)
                {
                    CloseSession(session);
                }
            }

            return updateStatus;
        }
        /// <summary>
        /// Update UndispatchLoad
        /// </summary>
        /// <param name="companyID">companyID</param>
        /// <param name="password">password</param>
        /// <param name="loadNo">loadNo</param>
        /// <returns>Boolean</returns>

        public Boolean UpdateUndispatchLoad(String companyID, String password, string loadNo, String VersionNo = "")
        {
            ISession session = null;
            try
            {
                //2013.08.01 FSWW, Ramesh M Added For Add if condition for Error log ON/OFF switch control
                if (LoggingStatus == "on")
                {
                }
                if (ValidateCustomerLogin(companyID, password, VersionNo))
                {
                    session = GetSession();
                    string status = DALMethods.UpdateUndispatchStatus(loadNo, companyID, session, VersionNo);
                    if (status == "S")
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                // 2013.06.24 FSWW, Ramesh M Added For CR#58976 To Add More Details about calling function in Error log file.
                Logging.LogError(ex, "UpdateUndispatchLoad : CustomerID-" + companyID + ", loadNo-" + loadNo + "\n");
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
        /// Update Load Undispatched Status
        /// </summary>
        /// <param name="sessionID">sessionID</param>
        /// <param name="loadIDs">List of loadID</param>
        /// <param name="UndispatchedStatus">UndispatchedStatus</param>
        /// <returns>Boolean</returns>
        public Boolean UpdateLoadUndispatchedStatus(Guid sessionID, List<Guid> loadIDs, int UndispatchedStatus, String VersionNo = "")
        {
            Boolean errorStatus = false;
            ISession session = null;
            if (validateUserSession(sessionID, VersionNo))
            {
                try
                {
                    //2013.08.01 FSWW, Ramesh M Added For Add if condition for Error log ON/OFF switch control
                    if (LoggingStatus == "on")
                    {
                    }
                    if (loadIDs != null && loadIDs.Count > 0)
                    {
                        session = GetSession();
                        foreach (Guid loadID in loadIDs)
                        {
                            DALMethods.UpdateUndispatched(UndispatchedStatus, loadID, session, VersionNo);//Added for both Undispatch and Deleted Loads
                        }
                    }
                    errorStatus = true;
                }
                catch (Exception ex)
                {
                    // 2013.06.24 FSWW, Ramesh M Added For CR#58976 To Add More Details about calling function in Error log file.
                    Logging.LogError(ex, "UpdateLoadUndispatchedStatus : SessionID-" + sessionID + "\n");
                }
                finally
                {
                    if (session != null)
                    {
                        CloseSession(session);
                    }
                }
            }

            return errorStatus;
        }

        // 2014.01.17 Ramesh M Added For  CR#61759 to get from site list 
        /// <summary>
        /// 
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="password"></param>
        /// <param name="vehicleID"></param>
        /// <param name="companyID"></param>
        /// <param name="OrderID"></param>
        /// <param name="SuppliersupplyPtID"></param>
        /// <param name="SupplierDescr"></param>
        /// <param name="SupplyPtDescr"></param>
        /// <param name="VersionNo"></param>
        /// <returns></returns>
        public Boolean UpdateOrderSuppliersupplyPt(String UserName, String password, String vehicleID, String companyID, Guid OrderID, Int32 SuppliersupplyPtID, String SupplierDescr, String SupplyPtDescr, String VersionNo = "")
        {
            Boolean updateStatus = true;
            ISession session = null;
            try
            {
                //2013.08.01 FSWW, Ramesh M Added For Add if condition for Error log ON/OFF switch control
                if (LoggingStatus == "on")
                {
                }
                session = GetSession();
                if (ValidateUserLogin(UserName, password, companyID, vehicleID, VersionNo))
                {
                    updateStatus = DALMethods.UpdateSuppliersupplyPt(companyID, OrderID, SuppliersupplyPtID, SupplierDescr, SupplyPtDescr, session, VersionNo);
                }
                CloseSession(session);
            }
            catch (ApplicationException ex)
            {
                updateStatus = false;
                if (session != null)
                {
                    CloseSession(session);
                }
                Logging.LogError(ex, "UpdateOrderSuppliersupplyPt : CustomerID-" + companyID + ", OrderID-" + OrderID + "\n");
                throw ex;
            }
            catch (Exception ex)
            {
                updateStatus = false;
                if (session != null)
                {
                    CloseSession(session);
                }
                Logging.LogError(ex, "UpdateOrderSuppliersupplyPt : CustomerID-" + companyID + ", OrderID-" + OrderID + "\n");
                throw ex;
            }
            finally
            {
                if (session != null)
                {
                    CloseSession(session);
                }
            }

            return updateStatus;
        }



        // 2014.01.10  Ramesh M Added For CR#61759 Added to full From Site business rule
        /// <summary>
        /// UpdateFromSiteBSRule
        /// </summary>
        /// <param name="companyID"></param>
        /// <param name="password"></param>
        /// <param name="FromSiteBSRule"></param>
        /// <param name="VersionNo"></param>
        /// <returns></returns>
        public Boolean UpdateFromSiteBSRule(String companyID, String password, Int32 FromSiteBSRule, Int32 MultiBOLBSRule, String VersionNo = "")
        {
            Boolean status = false;
            ISession session = null;
            try
            {
                if (LoggingStatus == "on")
                {
                }
                session = GetSession();
                if (ValidateCustomerLogin(companyID, password, VersionNo))
                {

                    DALMethods.UpdateFromSiteBSRule(companyID, FromSiteBSRule, MultiBOLBSRule, session, VersionNo);

                    status = true;
                }
                CloseSession(session);

            }
            catch (ApplicationException ex)
            {
                if (session != null)
                {
                    CloseSession(session);
                }
                // 2013.07.22 FSWW, Ramesh M Added For Add More Details about calling function in Error log file.
                Logging.LogError(ex, "UpdateFromSiteBSRule : CustomerID-" + companyID + "\n");
                throw ex;
            }
            catch (Exception ex)
            {
                if (session != null)
                {
                    CloseSession(session);
                }
                // 2013.06.24 FSWW, Ramesh M Added For CR#58976 To Add More Details about calling function in Error log file.
                Logging.LogError(ex, "UpdateFromSiteBSRule : CustomerID-" + companyID + "\n");
                throw ex;
            }
            finally
            {
                if (session != null)
                {
                    CloseSession(session);
                }
            }

            return status;
        }

        // 2014.01.10  Ramesh M Added For CR#61759 For supplierSupplyPt
        /// <summary>
        /// 
        /// </summary>
        /// <param name="companyID"></param>
        /// <param name="password"></param>
        /// <param name="ShiptoID"></param>
        /// <param name="SuppliersupplyPtID"></param>
        /// <param name="SupplierDescr"></param>
        /// <param name="SupplyPtDescr"></param>
        /// <param name="Address1"></param>
        /// <param name="Address2"></param>
        /// <param name="SupplierCode"></param>
        /// <param name="SupplyPtCode"></param>
        /// <param name="VersionNo"></param>
        /// <returns></returns>
        public Boolean UpdateFromSite(String companyID, String password, Int32? ShiptoID, Int32 SuppliersupplyPtID, Int32 SupplierID, Int32 SupplyPtID, String SupplierDescr, String SupplyPtDescr, String Address1, String Address2, String SupplierCode, String SupplyPtCode, String VersionNo = "")
        {
            Boolean status = false;
            ISession session = null;
            try
            {
                if (LoggingStatus == "on")
                {
                }
                session = GetSession();
                if (ValidateCustomerLogin(companyID, password, VersionNo))
                {
                    DALMethods.AddOrUpdateFromSite(companyID, ShiptoID, SuppliersupplyPtID, SupplierID, SupplyPtID, SupplierDescr, SupplyPtDescr, Address1, Address2, SupplierCode, SupplyPtCode, session, VersionNo);
                    status = true;
                }
                CloseSession(session);

            }
            catch (ApplicationException ex)
            {
                if (session != null)
                {
                    CloseSession(session);
                }
                // 2013.07.22 FSWW, Ramesh M Added For Add More Details about calling function in Error log file.
                Logging.LogError(ex, "UpdateFromSite : CustomerID-" + companyID + ", ShiptoID-" + ShiptoID + "\n");
                throw ex;
            }
            catch (Exception ex)
            {
                if (session != null)
                {
                    CloseSession(session);
                }
                // 2013.06.24 FSWW, Ramesh M Added For CR#58976 To Add More Details about calling function in Error log file.
                Logging.LogError(ex, "UpdateFromSite : CustomerID-" + companyID + ", ShiptoID-" + ShiptoID + "\n");
                throw ex;
            }
            finally
            {
                if (session != null)
                {
                    CloseSession(session);
                }
            }

            return status;
        }

        // 2014.01.10  Ramesh M Added For CR#61759 For supplierSupplyPt
        /// <summary>
        /// 
        /// </summary>
        /// <param name="companyID"></param>
        /// <param name="password"></param>
        /// <param name="ShiptoID"></param>
        /// <param name="SuppliersupplyPtID"></param>
        /// <param name="SupplierDescr"></param>
        /// <param name="SupplyPtDescr"></param>
        /// <param name="Address1"></param>
        /// <param name="Address2"></param>
        /// <param name="SupplierCode"></param>
        /// <param name="SupplyPtCode"></param>
        /// <param name="VersionNo"></param>
        /// <returns></returns>
        public Boolean DeleteFromSite(String companyID, String password, Int32 OEDefID, Int32 SupplierID, Int32 SupplyPtID, String VersionNo = "")
        {
            Boolean status = false;
            ISession session = null;
            try
            {
                if (LoggingStatus == "on")
                {
                }
                session = GetSession();
                if (ValidateCustomerLogin(companyID, password, VersionNo))
                {
                    DALMethods.DeleteFromSite(companyID, OEDefID, SupplierID, SupplyPtID, session, VersionNo);
                    status = true;
                }
                CloseSession(session);

            }
            catch (ApplicationException ex)
            {
                if (session != null)
                {
                    CloseSession(session);
                }
                Logging.LogError(ex, "DeleteFromSite : CustomerID-" + companyID + ", OEDefID-" + OEDefID + "\n");
                throw ex;
            }
            catch (Exception ex)
            {
                if (session != null)
                {
                    CloseSession(session);
                }
                Logging.LogError(ex, "DeleteFromSite : CustomerID-" + companyID + ", OEDefID-" + OEDefID + "\n");
                throw ex;
            }
            finally
            {
                if (session != null)
                {
                    CloseSession(session);
                }
            }

            return status;
        }

        /// <summary>
        /// UpdateFrtBreakdown
        /// </summary>
        /// <param name="companyID">companyID</param>
        /// <param name="password">password</param>
        /// <param name="FrtBrkdown">FrtBrkdown</param>
        /// <returns>Boolean</returns>

        public void UpdateFrtBreakdown(String companyID, String password, char FrtBrkdown, String VersionNo = "")
        {
            ISession session = null;
            try
            {
                //2013.08.01 FSWW, Ramesh M Added For Add if condition for Error log ON/OFF switch control
                if (LoggingStatus == "on")
                {
                }
                if (ValidateCustomerLogin(companyID, password, VersionNo))
                {
                    session = GetSession();
                    DALMethods.UpdateFrtBreakdown(companyID, FrtBrkdown, session, VersionNo);
                }
            }
            catch (Exception ex)
            {
                // 2013.06.24 FSWW, Ramesh M Added For CR#58976 To Add More Details about calling function in Error log file.
                Logging.LogError(ex, "UpdateFrtBreakdown :  CustomerID-" + companyID + ", FrtBrkdown-" + FrtBrkdown + "\n");
                throw ex;
            }
            finally
            {
                if (session != null)
                {
                    CloseSession(session);
                }
            }
        }

        // 2015-Oct-23 Vinoth Added For Resubmit bol image
        public Boolean UpdateBolImage(String UserName, String password, String vehicleID, String companyID, String bolHdrID, Guid loadID, String bolNo, String Image, String VersionNo = "")
        {
            Boolean UpdateStatus = false;
            ISession session = null;
            try
            {
                //2013.08.01 FSWW, Ramesh M Added For Add if condition for Error log ON/OFF switch control
                if (LoggingStatus == "on")
                {
                }
                session = GetSession();
                if (ValidateUserLogin(UserName, password, companyID, vehicleID, VersionNo))
                {
                    UpdateStatus = DALMethods.UpdateBolImage(bolHdrID, loadID, bolNo, Image, session, VersionNo);
                }
                CloseSession(session);

            }
            catch (ApplicationException ex)
            {
                if (session != null)
                {
                    CloseSession(session);
                }
                // 2013.07.22 FSWW, Ramesh M Added For Add More Details about calling function in Error log file.
                Logging.LogError(ex, "UpdateBolImage : CustomerID-" + companyID + ", LoadID-" + loadID + "\n");
                throw ex;
            }
            catch (Exception ex)
            {
                if (session != null)
                {
                    CloseSession(session);
                }
                // 2013.06.24 FSWW, Ramesh M Added For CR#58976 To Add More Details about calling function in Error log file.
                Logging.LogError(ex, "UpdateBolImage : CustomerID-" + companyID + ", LoadID-" + loadID + "\n");
                throw ex;
            }
            finally
            {
                if (session != null)
                {
                    CloseSession(session);
                }
            }

            return UpdateStatus;
        }

        /// <summary>
        /// UpdateDeliveryDateSort
        /// </summary>
        /// <param name="companyID">companyID</param>
        /// <param name="password">password</param>
        /// <param name="DeliveryDateSort">DeliveryDateSort</param>
        /// <returns>Boolean</returns>
        //2016.01.06 FSWW, Vinoth P Added For Update DeliveryDateSort flag to customer
        public void UpdateDeliveryDateSort(String companyID, String password, char DeliveryDateSort, String VersionNo = "")
        {
            ISession session = null;
            try
            {
                //2016.01.06 FSWW, Vinoth P Added Add if condition for Error log ON/OFF switch control
                if (LoggingStatus == "on")
                {
                }
                if (ValidateCustomerLogin(companyID, password, VersionNo))
                {
                    session = GetSession();
                    DALMethods.UpdateDeliveryDateSort(companyID, DeliveryDateSort, session, VersionNo);
                }
            }
            catch (Exception ex)
            {
                //2016.01.06 FSWW, Vinoth P Added For To Add More Details about calling function in Error log file.
                Logging.LogError(ex, "UpdateDeliveryDateSort : CustomerID-" + companyID + ", DeliveryDateSort-" + DeliveryDateSort + "\n");
                throw ex;
            }
            finally
            {
                if (session != null)
                {
                    CloseSession(session);
                }
            }
        }

        /// <summary>
        /// UpdateBOLImageRule
        /// </summary>
        /// <param name="companyID">companyID</param>
        /// <param name="password">password</param>
        /// <param name="DeliveryDateSort">RequireBOLImage</param>
        /// <returns>Boolean</returns>
        //2016.10.12 FSWW, Dinesh Added For Update UpdateBOLImageRule flag to customer
        public void UpdateBOLImageVolumeStartEndBOLRule(String companyID, String password, char RequireBOLImage, char RequireDeliveryImage, char DeliveryVolumeBSRule, char BOLStartEndDateBSRule, String VersionNo = "")
        {
            ISession session = null;
            try
            {
                //2016.01.06 FSWW, Vinoth P Added Add if condition for Error log ON/OFF switch control
                if (LoggingStatus == "on")
                {
                }
                if (ValidateCustomerLogin(companyID, password, VersionNo))
                {
                    session = GetSession();
                    DALMethods.UpdateBOLImageVolumeStartEndBOLRule(companyID, RequireBOLImage, RequireDeliveryImage, DeliveryVolumeBSRule, BOLStartEndDateBSRule, session, VersionNo);
                }
            }
            catch (Exception ex)
            {
                //2016.01.06 FSWW, Vinoth P Added For To Add More Details about calling function in Error log file.
                Logging.LogError(ex, "UpdateBOLImageVolumeStartEndBOLRule : CustomerID-" + companyID + ", UpdateBOLImageRule-" + RequireBOLImage + "\n");
                throw ex;
            }
            finally
            {
                if (session != null)
                {
                    CloseSession(session);
                }
            }
        }

        public void UpdateRemoveLoadFlag(String customerId, String password, string removeLoadFlag, String VersionNo = "")
        {
            ISession session = null;
            try
            {
                session = GetSession();
                if (ValidateCustomerLogin(customerId, password, VersionNo))
                {
                    DALMethods.UpdateRemoveLoadByDriverFlag(customerId, removeLoadFlag, session, VersionNo);
                }
            }
            catch (Exception ex)
            {
                Logging.LogError(ex, "UpdateRemoveLoadFlag : CustomerID -" + customerId + ", Remove Load Flag-" + removeLoadFlag + "\n");
            }
            finally
            {
                if (session != null)
                {
                    CloseSession(session);
                }
            }
        }

        #endregion Update details

        #region Get Summary

        #region DriverSummaryCommentedCode
        //        /// <summary>
        //        /// GetDriverSummarys
        //        /// </summary>
        //        /// <param name="sessionID">sessionID</param>
        //        /// <param name="startTime">startTime</param>
        //        /// <param name="endTime">endTime</param>
        //        /// <returns>XmlDocument</returns>
        //        public List<DriverSummary> GetDriverSummary(Guid sessionID, DateTime startTime, DateTime endTime,String VersionNo="")
        //        {
        //            ISession session = null;
        //            List<DriverSummary> lstDriverStatus = new List<DriverSummary>();
        //            List<DriverSummary> lstDriverStatus1 = new List<DriverSummary>();
        //            try
        //            {
        //                //2013.08.01 FSWW, Ramesh M Added For Add if condition for Error log ON/OFF switch control
        //                if (LoggingStatus == "on")
        //                {
        //                    //2013.07.22 FSWW, Ramesh M Added For Add More Details about calling function in Error log file
        //                    //2013.12.05 FSWW, Ramesh M Added For CR#60646 Added start time and time in logging
        //                    Logging.LogInfoAboutCallingFunction("Function Called:- GetDriverSummary ; " + "SessionID-" + sessionID + ",StartTime-" + startTime + ",EndTime-" + endTime);
        //                }
        //                session = GetSession();
        //                if (validateUserSession(sessionID,VersionNo))
        //                {
        //                    List<DriverSummary> lstDriverSummary = DALMethods.GetDriverSummary(sessionID, startTime, endTime, session,VersionNo);
        //                    string state = null;
        //                    DateTime statusStartTime = DateTime.MinValue;
        //                    Guid TempSessionID = Guid.Empty;
        //                    int count = 0;
        //                    Boolean DantHaveGapOnlyStatusChange = false;


        //                    //List<DriverSummary> lstDriverStatus1 = new List<DriverSummary>();
        //                    DriverSummary summary = null;

        //                    count = lstDriverSummary.Count;
        //                    //IF GetDriverSummary record count is zero (i.e) No Records for Last seven days 
        //                    if (count != 0)
        //                    {
        //                        state = lstDriverSummary[0].DriverState;
        //                        statusStartTime = lstDriverSummary[0].StartTime;
        //                        TempSessionID = lstDriverSummary[0].SessionID;

        //                        //For Data Grouping First phase of Process
        //                        for (int i = 0; i < count; i++)
        //                        {
        //                            if (lstDriverSummary[i].DriverState != state)
        //                            {
        //                                //2013.08.01 FSWW, Ramesh M Added For IF session end with drivring status,report fine tuning
        //                                if (lstDriverSummary[i].SessionID != TempSessionID && (state == "D"))
        //                                {
        //                                    summary = new DriverSummary();
        //                                    summary.CurrentLoginID = lstDriverSummary[i].CurrentLoginID;
        //                                    summary.DriverState = state;
        //                                    summary.StartTime = statusStartTime;
        //                                    summary.EndTime = lstDriverSummary[i-1].EndTime;
        //                                    summary.SessionID = lstDriverSummary[i].SessionID;
        //                                    summary.IsOverride = lstDriverSummary[i].IsOverride;
        //                                    lstDriverStatus1.Add(summary);


        //                                    state = lstDriverSummary[i].DriverState;
        //                                    statusStartTime = lstDriverSummary[i].StartTime;
        //                                    TempSessionID = lstDriverSummary[i].SessionID;
        //                                }
        //                                else
        //                                {
        //                                    // 2013.12.30 FSWW, Ramesh M Added for If same sessionID ends with 'D' and missing some data then starts with 'P' means gap is inserted with 'P'
        //                                    if ((TempSessionID == lstDriverSummary[i].SessionID) && ((state == "D") && (lstDriverSummary[i].DriverState=="P")))
        //                                    {
        //                                        summary = new DriverSummary();
        //                                        summary.CurrentLoginID = lstDriverSummary[i].CurrentLoginID;
        //                                        summary.DriverState = state;
        //                                        summary.StartTime = statusStartTime;
        //                                        summary.EndTime = lstDriverSummary[i-1].EndTime;
        //                                        summary.SessionID = lstDriverSummary[i].SessionID;
        //                                        summary.IsOverride = lstDriverSummary[i].IsOverride;
        //                                        lstDriverStatus1.Add(summary);

        //                                        state = lstDriverSummary[i].DriverState;
        //                                        statusStartTime = lstDriverSummary[i-1].EndTime;
        //                                        TempSessionID = lstDriverSummary[i].SessionID;
        //                                        if(lstDriverSummary[i-1].EndTime==lstDriverSummary[i].StartTime)
        //                                        {
        //                                            DantHaveGapOnlyStatusChange = true;
        //                                        }
        //                                    }
        //                                    if (DantHaveGapOnlyStatusChange == false)
        //                                    {
        //                                        summary = new DriverSummary();
        //                                        summary.CurrentLoginID = lstDriverSummary[i].CurrentLoginID;
        //                                        summary.DriverState = state;
        //                                        summary.StartTime = statusStartTime;
        //                                        summary.EndTime = lstDriverSummary[i].EndTime;
        //                                        summary.SessionID = lstDriverSummary[i].SessionID;
        //                                        summary.IsOverride = lstDriverSummary[i].IsOverride;
        //                                        lstDriverStatus1.Add(summary);

        //                                        state = lstDriverSummary[i].DriverState;
        //                                        statusStartTime = lstDriverSummary[i].EndTime;
        //                                        TempSessionID = lstDriverSummary[i].SessionID;
        //                                    }
        //                                    else
        //                                    {
        //                                        DantHaveGapOnlyStatusChange = false;
        //                                    }

        //                                }
        //                            }
        //                            else if (TempSessionID != lstDriverSummary[i].SessionID && lstDriverSummary[i].DriverState == state)
        //                            {
        //                                summary = new DriverSummary();
        //                                summary.CurrentLoginID = lstDriverSummary[i].CurrentLoginID;
        //                                summary.DriverState = state;
        //                                summary.StartTime = statusStartTime;
        //                                summary.EndTime = lstDriverSummary[i - 1].EndTime;
        //                                summary.SessionID = TempSessionID;
        //                                summary.IsOverride = lstDriverSummary[i].IsOverride;
        //                                lstDriverStatus1.Add(summary);

        //                                state = lstDriverSummary[i].DriverState;
        //                                statusStartTime = lstDriverSummary[i].EndTime;
        //                                TempSessionID = lstDriverSummary[i].SessionID;
        //                            }
        //                            // 2013.12.30 FSWW, Ramesh M Added for If same sessionID ends with 'D' and missing some data then starts with 'D' means gap is inserted with 'P'
        //                            else if ((TempSessionID == lstDriverSummary[i].SessionID) && ((state == "D") && (lstDriverSummary[i].DriverState == "D"))
        //                                     && ((lstDriverSummary[i - 1].EndTime) != (lstDriverSummary[i].StartTime)))
        //                            {
        //                                //Closing Driving 'D' Record
        //                                summary = new DriverSummary();
        //                                summary.CurrentLoginID = lstDriverSummary[i].CurrentLoginID;
        //                                summary.DriverState = state;
        //                                summary.StartTime = statusStartTime;
        //                                summary.EndTime = lstDriverSummary[i - 1].EndTime;
        //                                summary.SessionID = lstDriverSummary[i].SessionID;
        //                                summary.IsOverride = lstDriverSummary[i].IsOverride;
        //                                lstDriverStatus1.Add(summary);

        //                                //Inserting Onduty Record 'P' Record
        //                                summary = new DriverSummary();
        //                                summary.CurrentLoginID = lstDriverSummary[i].CurrentLoginID;
        //                                summary.DriverState = "P";
        //                                summary.StartTime = lstDriverSummary[i - 1].EndTime;
        //                                summary.EndTime = lstDriverSummary[i].StartTime;
        //                                summary.SessionID = lstDriverSummary[i].SessionID;
        //                                summary.IsOverride = lstDriverSummary[i].IsOverride;
        //                                lstDriverStatus1.Add(summary);

        //                                state = lstDriverSummary[i].DriverState;
        //                                statusStartTime = lstDriverSummary[i].StartTime;
        //                                TempSessionID = lstDriverSummary[i].SessionID;

        //                            }
        //                            if (i + 1 == count)
        //                            {
        //                                summary = new DriverSummary();
        //                                summary.CurrentLoginID = lstDriverSummary[i].CurrentLoginID;
        //                                summary.DriverState = state;
        //                                summary.StartTime = statusStartTime;
        //                                summary.EndTime = lstDriverSummary[i].EndTime;
        //                                summary.SessionID = lstDriverSummary[i].SessionID;
        //                                summary.IsOverride = lstDriverSummary[i].IsOverride;
        //                                lstDriverStatus1.Add(summary);
        //                            }

        //                        }

        //                        //For Missing Data Insertion Second phase of Process
        //                        //2013.12.30 FSWW, Ramesh M Commented for Testing--Done so coding comments removed on 2014.01.02 
        //                        count = lstDriverStatus1.Count;
        //                        state = "A";
        //                        statusStartTime = startTime;
        //                        TempSessionID = sessionID;
        //                        for (int i = 0; i < count; i++)
        //                        {
        //                            if (lstDriverStatus1[i].StartTime != statusStartTime)
        //                            {
        //                                //For Missing Record
        //                                summary = new DriverSummary();
        //                                summary.CurrentLoginID = lstDriverStatus1[i].CurrentLoginID;
        //                                summary.DriverState = state;
        //                                summary.StartTime = statusStartTime;
        //                                summary.EndTime = lstDriverStatus1[i].StartTime;
        //                                summary.SessionID = lstDriverStatus1[i].SessionID;
        //                                summary.IsOverride = lstDriverSummary[i].IsOverride;
        //                                lstDriverStatus.Add(summary);

        //                                summary = new DriverSummary();
        //                                //Current Record
        //                                summary.CurrentLoginID = lstDriverStatus1[i].CurrentLoginID;
        //                                summary.DriverState = lstDriverStatus1[i].DriverState;
        //                                summary.StartTime = lstDriverStatus1[i].StartTime;
        //                                summary.EndTime = lstDriverStatus1[i].EndTime;
        //                                summary.SessionID = lstDriverStatus1[i].SessionID;
        //                                summary.IsOverride = lstDriverSummary[i].IsOverride;
        //                                lstDriverStatus.Add(summary);

        //                                statusStartTime = lstDriverStatus1[i].EndTime;
        //                                TempSessionID = lstDriverStatus1[i].SessionID;
        //                            }
        //                            else
        //                            {
        //                                //Current Record
        //                                summary = new DriverSummary();
        //                                summary.CurrentLoginID = lstDriverStatus1[i].CurrentLoginID;
        //                                summary.DriverState = lstDriverStatus1[i].DriverState;
        //                                summary.StartTime = lstDriverStatus1[i].StartTime;
        //                                summary.EndTime = lstDriverStatus1[i].EndTime;
        //                                summary.SessionID = lstDriverStatus1[i].SessionID;
        //                                summary.IsOverride = lstDriverSummary[i].IsOverride;
        //                                lstDriverStatus.Add(summary);

        //                                statusStartTime = lstDriverStatus1[i].EndTime;
        //                                TempSessionID = lstDriverStatus1[i].SessionID;
        //                            }
        //                        }
        //                        //If Current session dont have Record in GpsHistory table  Add values for that

        //                        #region Current session dont have Record
        //                        //var list = new List<MyClass>();
        //                        //2014.01.20  Ramesh M Commented for 1 minute offduty, so if current session  has record then report will generate other wise no report will generate.
        //                       /* var item = lstDriverStatus.Find(x => x.SessionID == sessionID);
        //                        if (item == null)
        //                        {
        //                            DateTime Devicetime = DateTime.MinValue;
        //                            Devicetime=DALMethods.GetDeviceLoginTime(sessionID, session);

        //                            summary = new DriverSummary();
        //                            summary.CurrentLoginID = 0;
        //                            summary.DriverState = "A";
        //                            summary.StartTime = statusStartTime;
        //                            summary.EndTime = Devicetime.AddMinutes(1);
        //                            summary.SessionID = sessionID;
        //                            lstDriverStatus.Add(summary);

        //                            //2013.12.24 FSWW, Ramesh M Added Report Fine Tuning CR#60835
        //                            summary = new DriverSummary();
        //                            summary.CurrentLoginID = 0;
        //                            summary.DriverState = "P";
        //                            summary.StartTime = Devicetime.AddMinutes(1);
        //                            summary.EndTime = endTime.AddMinutes(1);
        //                            summary.SessionID = sessionID;
        //                            lstDriverStatus.Add(summary);
        //                        }*/
        //                       #endregion
        //                    }
        //                    else
        //                    {
        //                        summary = new DriverSummary();
        //                        summary.CurrentLoginID = 0;
        //                        summary.DriverState = "A";
        //                        summary.StartTime = startTime;
        //                        summary.EndTime = endTime;
        //                        summary.SessionID = sessionID;
        //                        lstDriverStatus.Add(summary);

        //                        //2013.12.24 FSWW, Ramesh M Added Report Fine Tuning CR#60835
        //                        summary = new DriverSummary();
        //                        summary.CurrentLoginID = 0;
        //                        summary.DriverState = "P";
        //                        summary.StartTime = endTime;
        //                        summary.EndTime = endTime.AddMinutes(1);
        //                        summary.SessionID = sessionID;
        //                        lstDriverStatus.Add(summary);
        //                    }

        //                    #region OLD CODE
        ////                    // 2013.10.03 FSWW, Ramesh M CR#60534 Removed 34 hour reset code in Cloud, this will be done in ipad itself.
        ////                    List<DriverSummary> lstDriverSummary = DALMethods.GetDriverSummary(sessionID, startTime, endTime, session);
        ////                    string state = "";
        ////                    DateTime statusStartTime = DateTime.MinValue;
        ////                    int count = 0;
        ////                    foreach (DriverSummary driverSummary in lstDriverSummary)
        ////                    {
        ////                        count++;
        ////                        if (string.IsNullOrEmpty(state))
        ////                        {
        ////                            state = driverSummary.DriverState;
        ////                            statusStartTime = driverSummary.StartTime;
        ////                        }
        ////                        if (driverSummary.DriverState != state)
        ////                        {
        ////                            DriverSummary summary = new DriverSummary();
        ////                            summary.CurrentLoginID = driverSummary.CurrentLoginID;
        ////                            summary.DriverState = state;
        ////                            summary.StartTime = statusStartTime;
        ////                            summary.EndTime = driverSummary.StartTime;
        ////                            summary.SessionID = driverSummary.SessionID;
        ////                            lstDriverStatus.Add(summary);
        ////                            state = driverSummary.DriverState;
        ////                            statusStartTime = driverSummary.StartTime;
        ////                        }
        ////                        if (lstDriverSummary.Count == count)
        ////                        {
        ////                            DriverSummary summary = new DriverSummary();
        ////                            summary.CurrentLoginID = driverSummary.CurrentLoginID;
        ////                            summary.DriverState = state;
        ////                            summary.StartTime = statusStartTime;
        ////                            summary.EndTime = driverSummary.EndTime;
        ////                            summary.SessionID = driverSummary.SessionID;
        ////                            lstDriverStatus.Add(summary);
        ////                        }
        ////                    }

        //#endregion

        //                    #region 34hrFormatCode
        //                    //List<DriverSummary> lstDriverSummary = DALMethods.GetDriverSummary(sessionID, startTime, endTime, session);
        //                    //string state = "";
        //                    //DateTime statusStartTime = DateTime.MinValue;                   
        //                    //int count = 0;

        //                    ////2013.06.27 FSWW Ramesh M Added For CR#59019
        //                    //DateTime ThirtyFourHoursStatusStartTime = DateTime.MinValue;
        //                    //TimeSpan TimeOffDuty = TimeSpan.MinValue;


        //                    //foreach (DriverSummary driverSummary in lstDriverSummary)
        //                    //{
        //                    //    count++;
        //                    //    if (string.IsNullOrEmpty(state))
        //                    //    {
        //                    //        state = driverSummary.DriverState;
        //                    //        statusStartTime = driverSummary.StartTime;

        //                    //        //2013.06.27 FSWW Ramesh M Added For CR#59019
        //                    //        ThirtyFourHoursStatusStartTime = driverSummary.StartTime; 
        //                    //    }

        //                    //    if (driverSummary.DriverState != state)
        //                    //    {
        //                    //        DriverSummary summary = new DriverSummary();
        //                    //        summary.CurrentLoginID = driverSummary.CurrentLoginID;
        //                    //        summary.DriverState = state;
        //                    //        summary.StartTime = statusStartTime;
        //                    //        summary.EndTime = driverSummary.StartTime;
        //                    //        summary.SessionID = driverSummary.SessionID;
        //                    //        summary.ThirtyFourHourReset = driverSummary.ThirtyFourHourReset;
        //                    //        lstDriverStatus.Add(summary);
        //                    //        state = driverSummary.DriverState;
        //                    //        statusStartTime = driverSummary.StartTime;

        //                    //        /////2013.06.27 FSWW Ramesh M Added For CR#59019 
        //                    //        if (driverSummary.DriverState == "A")
        //                    //        {
        //                    //            TimeOffDuty = (driverSummary.EndTime - ThirtyFourHoursStatusStartTime);

        //                    //            if (TimeOffDuty.TotalMinutes > (34 * 60))
        //                    //            {
        //                    //                Double Result = double.MinValue;
        //                    //                Result = DateUtil.CalculateTimeSpanHours(ThirtyFourHoursStatusStartTime, driverSummary.EndTime, 1, 5);
        //                    //                if (Result >= 480)
        //                    //                {
        //                    //                    //2013.10.01 FSWW Ramesh M Added For ThirtyFourHourReset column added
        //                    //                   // lstDriverStatus.Where(s => s.ThirtyFourHourReset == "N").ToList().ForEach(s => s.ThirtyFourHourReset = "Y");

        //                    //                    lstDriverStatus.ForEach(s => s.ThirtyFourHourReset = "Y");
        //                    //                    //lstDriverStatus.Clear();
        //                    //                    ThirtyFourHoursStatusStartTime = driverSummary.StartTime;
        //                    //                }
        //                    //            }
        //                    //            TimeOffDuty = TimeSpan.MinValue;

        //                    //            ThirtyFourHoursStatusStartTime = driverSummary.StartTime;
        //                    //        }


        //                    //    }
        //                    //    if (lstDriverSummary.Count == count)
        //                    //    {
        //                    //        DriverSummary summary = new DriverSummary();
        //                    //        summary.CurrentLoginID = driverSummary.CurrentLoginID;
        //                    //        summary.DriverState = state;
        //                    //        summary.StartTime = statusStartTime;
        //                    //        summary.EndTime = driverSummary.EndTime;
        //                    //        summary.SessionID = driverSummary.SessionID;
        //                    //        summary.ThirtyFourHourReset = driverSummary.ThirtyFourHourReset;
        //                    //        lstDriverStatus.Add(summary);
        //                    //    }
        //                    //}
        //                    #endregion
        //                }

        //                CloseSession(session);
        //            }
        //            catch (ApplicationException ex)
        //            {
        //                if (session != null)
        //                {
        //                    CloseSession(session);
        //                }
        //                // 2013.07.22 FSWW, Ramesh M Added For Add More Details about calling function in Error log file.
        //                Logging.LogError(ex, "SessionID-" + sessionID + ",StartTime-" + startTime + ",EndTime-" + endTime +"\n");
        //                throw ex;
        //            }
        //            catch (Exception ex)
        //            {
        //                if (session != null)
        //                {
        //                    CloseSession(session);
        //                }
        //                // 2013.06.24 FSWW, Ramesh M Added For CR#58976 To Add More Details about calling function in Error log file.
        //                Logging.LogError(ex, "SessionID-" + sessionID + ",StartTime-" + startTime + ",EndTime-" + endTime + "\n");
        //                throw ex;
        //            }
        //            finally
        //            {
        //                if (session != null)
        //                {
        //                    CloseSession(session);
        //                }
        //            }

        //            // 2013.06.24 FSWW, Ramesh M Added For Testing
        //            //if (lstDriverStatus.Count > 10)
        //            //{
        //            //    lstDriverStatus.RemoveRange(0, lstDriverStatus.Count-10);
        //            //}

        //            //2013.12.30 FSWW, Ramesh M Commented for Testing--Done so coding comments removed on 2014.01.02
        //            return lstDriverStatus;
        //           // return lstDriverStatus1;
        //        }
        #endregion



        // 05-14-2014 MadhuVenkat K - Added for CR 63396 - Add Time Remaining Section to Driver Summary
        // 08-14-2014  MadhuVenkat K - Added for CR 64639 - Add CurrentDriverStatus to Driver Summary
        public List<RemainingTimeSummary> GetRemainingTimeSummary(Guid sessionID, DateTime LoginDatetime, DateTime startTime, DateTime endTime)
        {
            ISession session = null;
            List<RemainingTimeSummary> lstRemainingTimeSummary = new List<RemainingTimeSummary>();
            try
            {
                session = GetSession();
                if (validateUserSession(sessionID))
                {
                    lstRemainingTimeSummary = DALMethods.GetRemainingTimeSummary(sessionID, LoginDatetime, startTime, endTime, session);
                }
                CloseSession(session);
            }
            catch (ApplicationException ex)
            {
                if (session != null)
                {
                    CloseSession(session);
                }
                throw ex;
            }
            catch (Exception ex)
            {
                if (session != null)
                {
                    CloseSession(session);
                }
                //Logging.LogError(ex);
                throw ex;
            }
            return lstRemainingTimeSummary;
        }

        // 2014.02.20  Ramesh M Added For CR#62292 For driver summary log and commented above code, moved logic to stored procedure.
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sessionID"></param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        public List<DriverSummary> GetDriverSummary(Guid sessionID, DateTime startTime, DateTime endTime, DateTime? modifiedTime = null)
        {
            ISession session = null;
            List<DriverSummary> lstDriverSummary = new List<DriverSummary>();
            try
            {
                session = GetSession();
                if (!modifiedTime.HasValue)
                    modifiedTime = Convert.ToDateTime("1/1/1753 12:00:00 AM");
                if (validateUserSession(sessionID))
                {
                    DataTable dt = DALMethods.GetDriverLogDetails(sessionID, startTime, endTime, modifiedTime, session);
                    if (dt.Rows.Count > 0)
                    {
                        lstDriverSummary = DALMethods.GetDriverSummary(sessionID, Convert.ToDateTime(dt.Rows[0]["StartDate"].ToString()), Convert.ToDateTime(dt.Rows[0]["EndDate"].ToString()), session);
                        lstDriverSummary[0].IsModified = dt.Rows[0]["IsModified"].ToString();
                        lstDriverSummary[0].ModifiedDate = Convert.ToDateTime(dt.Rows[0]["ModifiedDate"].ToString());

                    }

                }
                CloseSession(session);
            }
            catch (ApplicationException ex)
            {
                if (session != null)
                {
                    CloseSession(session);
                }
                throw ex;
            }
            catch (Exception ex)
            {
                if (session != null)
                {
                    CloseSession(session);
                }
                //Logging.LogError(ex);
                throw ex;
            }
            return lstDriverSummary;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sessionID"></param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        public List<CumulativeShiftSummaryResponse> CummulativeGetDriverSummary(Guid sessionID, DateTime startTime, DateTime endTime, String VersionNo = "")
        {
            ISession session = null;
            List<DriverSummary> lstDriverStatus = new List<DriverSummary>();
            try
            {
                //2013.08.01 FSWW, Ramesh M Added For Add if condition for Error log ON/OFF switch control
                if (LoggingStatus == "on")
                {
                }
                session = GetSession();
                if (validateUserSession(sessionID, VersionNo))
                {
                    List<DriverSummary> lstDriverSummary = DALMethods.GetDriverSummary(sessionID, startTime, endTime, session, VersionNo);
                    string state = "";
                    DateTime statusStartTime = DateTime.MinValue;
                    int count = 0;

                    //2013.06.27 FSWW Ramesh M Added For CR#59019
                    DateTime ThirtyFourHoursStatusStartTime = DateTime.MinValue;
                    TimeSpan TimeOffDuty = TimeSpan.MinValue;


                    foreach (DriverSummary driverSummary in lstDriverSummary)
                    {
                        count++;
                        if (string.IsNullOrEmpty(state))
                        {
                            state = driverSummary.DriverState;
                            statusStartTime = driverSummary.StartTime;

                            //2013.06.27 FSWW Ramesh M Added For CR#59019
                            ThirtyFourHoursStatusStartTime = driverSummary.StartTime;
                        }

                        if (driverSummary.DriverState != state)
                        {
                            DriverSummary summary = new DriverSummary();
                            summary.CurrentLoginID = driverSummary.CurrentLoginID;
                            summary.DriverState = state;
                            summary.StartTime = statusStartTime;
                            summary.EndTime = driverSummary.StartTime;
                            summary.SessionID = driverSummary.SessionID;
                            lstDriverStatus.Add(summary);
                            state = driverSummary.DriverState;
                            statusStartTime = driverSummary.StartTime;

                            /////2013.06.27 FSWW Ramesh M Added For CR#59019 
                            if (driverSummary.DriverState == "A")
                            {
                                TimeOffDuty = (driverSummary.EndTime - ThirtyFourHoursStatusStartTime);

                                if (TimeOffDuty.TotalMinutes > (34 * 60))
                                {
                                    Double Result = double.MinValue;
                                    Result = DateUtil.CalculateTimeSpanHours(ThirtyFourHoursStatusStartTime, driverSummary.EndTime, 1, 5);
                                    if (Result >= 480)
                                    {
                                        lstDriverStatus.Clear();
                                        ThirtyFourHoursStatusStartTime = driverSummary.StartTime;
                                    }
                                }
                                TimeOffDuty = TimeSpan.MinValue;

                                ThirtyFourHoursStatusStartTime = driverSummary.StartTime;
                            }


                        }
                        if (lstDriverSummary.Count == count)
                        {
                            DriverSummary summary = new DriverSummary();
                            summary.CurrentLoginID = driverSummary.CurrentLoginID;
                            summary.DriverState = state;
                            summary.StartTime = statusStartTime;
                            summary.EndTime = driverSummary.EndTime;
                            summary.SessionID = driverSummary.SessionID;
                            lstDriverStatus.Add(summary);
                        }
                    }
                }

                CloseSession(session);
            }
            catch (ApplicationException ex)
            {
                if (session != null)
                {
                    CloseSession(session);
                }
                // 2013.06.24 FSWW, Ramesh M Added For CR#58976 To Add More Details about calling function in Error log file.
                Logging.LogError(ex, "CummulativeGetDriverSummary : SessionID-" + sessionID + "\n");
                throw ex;
            }
            catch (Exception ex)
            {
                if (session != null)
                {
                    CloseSession(session);
                }
                // 2013.06.24 FSWW, Ramesh M Added For CR#58976 To Add More Details about calling function in Error log file.
                Logging.LogError(ex, "CummulativeGetDriverSummary : SessionID-" + sessionID + "\n");
                throw ex;
            }
            finally
            {
                if (session != null)
                {
                    CloseSession(session);
                }
            }

            // 2013.07.09 FSWW, Ramesh M Added For Testing
            //if (lstDriverStatus.Count > 10)
            //{
            //    lstDriverStatus.RemoveRange(0, lstDriverStatus.Count-10);
            //}
            TimeSpan iOFFDutyTime = TimeSpan.Zero;
            TimeSpan iONDutyTime = TimeSpan.Zero;
            TimeSpan iSleeperRigDutyTime = TimeSpan.Zero;
            TimeSpan iDrivingDutyTime = TimeSpan.Zero;

            if (lstDriverStatus.Count > 0)
            {
                for (int i = 0; i < lstDriverStatus.Count(); i++)
                {
                    //For OFF Duty
                    if (lstDriverStatus[i].DriverState.ToLower() == "a")
                    {
                        iOFFDutyTime = iOFFDutyTime.Add(lstDriverStatus[i].EndTime - lstDriverStatus[i].StartTime);
                    }
                    //For ON Duty
                    if (lstDriverStatus[i].DriverState.ToLower() == "p")
                    {
                        iONDutyTime = iONDutyTime.Add(lstDriverStatus[i].EndTime - lstDriverStatus[i].StartTime);
                    }
                    //For Sleeper Rig
                    if (lstDriverStatus[i].DriverState.ToLower() == "s")
                    {
                        iSleeperRigDutyTime = iSleeperRigDutyTime.Add(lstDriverStatus[i].EndTime - lstDriverStatus[i].StartTime);
                    }
                    //For Driving
                    if (lstDriverStatus[i].DriverState.ToLower() == "d")
                    {
                        iDrivingDutyTime = iDrivingDutyTime.Add(lstDriverStatus[i].EndTime - lstDriverStatus[i].StartTime);
                    }
                }
            }

            CumulativeShiftSummaryResponse lstSummary = new CumulativeShiftSummaryResponse();
            lstSummary.OnDuty = Convert.ToDecimal(iONDutyTime.TotalHours);
            lstSummary.SleeperRig = Convert.ToDecimal(iSleeperRigDutyTime.TotalHours);
            lstSummary.Driving = Convert.ToDecimal(iDrivingDutyTime.TotalHours);
            lstSummary.OffDuty = Convert.ToDecimal(iOFFDutyTime.TotalHours);
            List<CumulativeShiftSummaryResponse> ListCummulativesummary = new List<CumulativeShiftSummaryResponse>();
            ListCummulativesummary.Add(lstSummary);

            return ListCummulativesummary;
        }



        /// <summary>GetDriverLog</summary>
        /// <param name="sessionID">sessionID</param>
        /// <param name="currentTime">currentTime</param>
        /// <returns>SummaryLogResponse</returns>
        public SummaryLogResponse GetSummaryLogInformation(Guid sessionID, DateTime currentTime, String VersionNo = "")
        {
            ISession session = null;
            //  List<DriverLogs> lstDriverLogs = new List<DriverLogs>();
            SummaryLogResponse logResponse = new SummaryLogResponse();
            try
            {
                //2013.08.01 FSWW, Ramesh M Added For Add if condition for Error log ON/OFF switch control
                if (LoggingStatus == "on")
                {
                }
                session = GetSession();
                if (validateUserSession(sessionID, VersionNo))
                {
                    int prevDay = Convert.ToInt32(ConfigurationManager.AppSettings["PrevDays"]);
                    DateTime endTime = currentTime.AddDays(-prevDay).Date;
                    DriverLogs driverLogs = DALMethods.GetDriverLog(sessionID, endTime, currentTime, session)[0];
                    logResponse.currentShift.SessionID = sessionID;
                    logResponse.currentShift.Driving = driverLogs.CurrentDriving;
                    logResponse.currentShift.OnDuty = driverLogs.CurrentOnDuty;
                    logResponse.currentShift.OffDuty = driverLogs.CurrentOffDuty;
                    logResponse.currentShift.SleeperRig = driverLogs.CurrentSleeping;

                    logResponse.cumulativeShift.Driving = driverLogs.LastDriving;
                    logResponse.cumulativeShift.OnDuty = driverLogs.LastOnDuty;
                    logResponse.cumulativeShift.OffDuty = driverLogs.LastOffDuty;
                    logResponse.cumulativeShift.SleeperRig = driverLogs.LastSleeping;
                }
                CloseSession(session);
            }
            catch (ApplicationException ex)
            {
                if (session != null)
                {
                    CloseSession(session);
                }
                // 2013.07.22 FSWW, Ramesh M Added For  Add More Details about calling function in Error log file.
                Logging.LogError(ex, "GetSummaryLogInformation : SessionID-" + sessionID + "\n");
                throw ex;
            }
            catch (Exception ex)
            {
                if (session != null)
                {
                    CloseSession(session);
                }
                // 2013.06.24 FSWW, Ramesh M Added For CR#58976 To Add More Details about calling function in Error log file.
                Logging.LogError(ex, "GetSummaryLogInformation : SessionID-" + sessionID + "\n");
                throw ex;
            }
            finally
            {
                if (session != null)
                {
                    CloseSession(session);
                }
            }
            return logResponse;
        }

        // 2014.02.20  Ramesh M Added For CR#62301 For Driver status Screen in Ipad
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sessionID"></param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <param name="VersionNo"></param>
        /// <returns></returns>
        public List<DriverLogStatus> GetDriverLogStatus(Guid sessionID, DateTime startTime, DateTime endTime, String VersionNo = "")
        {
            ISession session = null;
            List<DriverLogStatus> lstDriverLogStatus = new List<DriverLogStatus>();
            try
            {
                session = GetSession();
                if (validateUserSession(sessionID))
                {
                    lstDriverLogStatus = DALMethods.GettingDriverLogStatus(sessionID, startTime, endTime, session);
                }
                CloseSession(session);
            }
            catch (ApplicationException ex)
            {
                if (session != null)
                {
                    CloseSession(session);
                }
                throw ex;
            }
            catch (Exception ex)
            {
                if (session != null)
                {
                    CloseSession(session);
                }
                //Logging.LogError(ex);
                throw ex;
            }
            return lstDriverLogStatus;
        }

        #endregion

        #region Add Details

        // 2013-09-06 FSWW Ramesh M ,For CR#60100 Added LoadType for segregate load type (warehouse,Driver)

        /// <summary>
        /// AddLoad
        /// Function to insert records into load table
        /// </summary>
        /// <param name="companyID">Company ID</param>
        /// <param name="password">Password</param>
        /// <param name="load">Load object</param>
        /// <param name="vehicleCode">Vehicle Code</param>
        /// <param name="SleeperRig">SleeperRig</param>
        /// <param name="UserName">User name</param>
        /// <param name="UserPassword">User Password</param>
        /// <param name="Email">Email</param>
        /// <param name="FirstName">First Name</param>
        /// <param name="MiddleName">Middle Name</param>
        /// <param name="LastName">Last Name</param>
        /// <param name="LoadType">LoadType</param>
        /// <returns>True = Inserted successfully, False = Failed</returns>
        public Boolean AddLoad(String companyID, String password, Load load, String vehicleCode, Boolean SleeperRig, String UserName, String UserPassword, String Email, String FirstName, String MiddleName, String LastName, String LoadType, String VersionNo = "")
        {
            Boolean addStatus = false;
            ISession session = null;
            Guid loadId = Guid.NewGuid();
            try
            {
                if (LoadType.ToLower() == "v")
                {
                    //2013.08.01 FSWW, Ramesh M Added For Add if condition for Error log ON/OFF switch control
                    if (LoggingStatus == "on")
                    {
                    }
                    session = GetSession();
                    if (ValidateCustomerLogin(companyID, password, VersionNo))
                    {
                        VersionNo = DALMethods.GetVersionByDriver(companyID, UserName, UserPassword, session);
                        DALMethods.AddOrUpdateVehicle(companyID, load.VehicleID, vehicleCode, SleeperRig, 0, 0, session, VersionNo);
                        
                        Logging.LogInfoAboutCallingFunction("DriverID" + load.DriverID);
                        if (load.DriverID > 0)
                        {
                            if (!DALMethods.CheckDriver(companyID, load.DriverID, session, VersionNo))
                            {
                                DALMethods.AddDrivers(companyID, load.DriverID, session, VersionNo);


                                if (!String.IsNullOrWhiteSpace(UserName) && !String.IsNullOrWhiteSpace(UserPassword))
                                {
                                    LoginUser loginUser = new LoginUser();
                                    loginUser.CustomerID = companyID;
                                    loginUser.DriverID = load.DriverID;
                                    loginUser.UserName = UserName;
                                    loginUser.Password = UserPassword;
                                    loginUser.Email = Email;
                                    loginUser.FirstName = FirstName;
                                    loginUser.MiddleName = MiddleName;
                                    loginUser.LastName = LastName;
                                    loginUser.HazMatDate = null;
                                    //2014.02.17  Ramesh M Added UserType For Warehouse user duplication CR#62289
                                    DALMethods.AddOrUpdateLoginDetails(loginUser, LoadType, session);
                                }
                            }

                        }
                        //Logging.LogInfoAboutCallingFunction("Vinoth 1" + "CustomerID-" + companyID);
                        List<Load> existingLoads = DALMethods.GetLoads(false, 60, 0, companyID, Guid.Empty, load.LoadNo, string.Empty, 0, 0, false, false, Convert.ToDateTime("1/1/1753 12:00:00 AM"), session, VersionNo);
                        
                        //Logging.LogInfoAboutCallingFunction("Vinoth 2" + "existingLoads-" + existingLoads.Count.ToString());
                        if (existingLoads.Count > 0)
                        {
                            Logging.LogInfoAboutCallingFunction("existingLoads" + existingLoads.Count);
                            foreach (Load existingLoad in existingLoads)
                            {
                                String status = DALMethods.GetLoadStatus(load.LoadNo, companyID, session);
                                Logging.LogInfoAboutCallingFunction("status" + status);

                                if (status == "B" || status == "V" || status == "I" || status == "R" || status == "Z")
                                {
                                    if (existingLoad.DriverID != load.DriverID)
                                    {
                                        DALMethods.InsertDispatchChangeLoad(session, existingLoad.ID, existingLoad.LoadNo, existingLoad.CustomerID, existingLoad.DriverID);
                                    }
                                    DALMethods.DeleteLoad(existingLoad.ID, session, VersionNo);
                                }
                                else
                                {
                                    //2013.12.09 FSWW, Ramesh M Added For CR#60644 Added CompanyId,LoadNo in Exception Message
                                    throw new ApplicationException("CompanyID-" + companyID + ", Load No-" + load.LoadNo + "; Can not add load as Load is already assigned and accepted by driver.");
                                }
                            }
                        }
                        
                        Logging.LogInfoAboutCallingFunction("AddLoad IS CALLED");
                        DALMethods.AddLoad(companyID, load, loadId, true, true, true, session, VersionNo);
                        //AddNotification(companyID, load, session);
                        addStatus = true;
                    }
                    CloseSession(session);
                }
                else if (LoadType.ToLower() == "w")
                {
                    //2013.08.01 FSWW, Ramesh M Added For Add if condition for Error log ON/OFF switch control
                    if (LoggingStatus == "on")
                    {
                    }
                    session = GetSession();
                    if (ValidateCustomerLogin(companyID, password, VersionNo))
                    {
                        VersionNo = DALMethods.GetVersionByDriver(companyID, UserName, UserPassword, session);
                        List<Load> existingLoads = DALMethods.GetLoads(false, 60, 0, companyID, Guid.Empty, load.LoadNo, string.Empty, 0, 0, false, false, Convert.ToDateTime("1/1/1753 12:00:00 AM"), session, VersionNo);
                        if (existingLoads.Count > 0)
                        {
                            foreach (Load existingLoad in existingLoads)
                            {
                                String status = DALMethods.GetLoadStatus(load.LoadNo, companyID, session, VersionNo);

                                if (status == "B" || status == "V" || status == "I" || status == "R" || status == "Z")
                                {
                                    if (existingLoad.DriverID != load.DriverID)
                                    {
                                        DALMethods.InsertDispatchChangeLoad(session, existingLoad.ID, existingLoad.LoadNo, existingLoad.CustomerID, existingLoad.DriverID);
                                    }
                                    DALMethods.DeleteLoad(existingLoad.ID, session, VersionNo);
                                }
                                else
                                {
                                    //2013.12.09 FSWW, Ramesh M Added For CR#60644 Added CompanyId,LoadNo in Exception Message
                                    throw new ApplicationException("CompanyID-" + companyID + ", Load No-" + load.LoadNo + "; Can not add load as Load is already assigned and accepted by driver.");
                                }
                            }
                        }
                        DALMethods.AddLoad(companyID, load, loadId, true, true, true, session, VersionNo);
                        //AddNotification(companyID, load, session);
                        addStatus = true;
                    }
                    CloseSession(session);
                }
                else if (LoadType.ToLower() == "z")
                {
                    //2013.08.01 FSWW, Ramesh M Added For Add if condition for Error log ON/OFF switch control
                    if (LoggingStatus == "on")
                    {
                    }
                    session = GetSession();
                    if (ValidateCustomerLogin(companyID, password, VersionNo))
                    {
                        VersionNo = DALMethods.GetVersionByDriver(companyID, UserName, UserPassword, session);
                        List<Load> existingLoads = DALMethods.GetLoads(false, 60, 0, companyID, Guid.Empty, load.LoadNo, string.Empty, 0, 0, false, false, Convert.ToDateTime("1/1/1753 12:00:00 AM"), session, VersionNo);

                        if (existingLoads.Count > 0)
                        {
                            foreach (Load existingLoad in existingLoads)
                            {

                                // 07-14-2014  Madhuvenkat K - Modified for CR 64247 - Included Order Status "Vehicle At Supply Point - S" for processing Dispatch order changes from ASCEND to DeliveryStream.
                                // 07-16-2014  Madhuvenkat K - Modified for CR 64247 - Included Order Status "Enroute to Supply Point - E" for processing Dispatch order changes from ASCEND to DeliveryStream.

                                String status = DALMethods.GetLoadStatus(load.LoadNo, companyID, session, VersionNo);
                                if (status == "B" || status == "V" || status == "I" || status == "R" || status == "Z" || status == "A" || status == "S" || status == "E")
                                {
                                    if (existingLoad.DriverID != load.DriverID)
                                    { 
                                        DALMethods.InsertDispatchChangeLoad(session, existingLoad.ID, existingLoad.LoadNo, existingLoad.CustomerID, existingLoad.DriverID);
                                    }

                                    DALMethods.AddLoadDispatchChangeHistory(existingLoad.ID, existingLoad.LoadNo, existingLoad.CustomerID, existingLoad.VehicleID, existingLoad.DriverID, loadId, GetSession());
                                    DALMethods.DeleteLoad(existingLoad.ID, session, VersionNo);
                                }
                                else
                                {
                                    //2013.12.09 FSWW, Ramesh M Added For CR#60644 Added CompanyId,LoadNo in Exception Message
                                    throw new ApplicationException("CompanyID-" + companyID + ", Load No-" + load.LoadNo + "; Can not add load as Load is already assigned and accepted by driver.");
                                }
                            }
                        }
                        DALMethods.AddLoad(companyID, load, loadId, true, true, true, session, VersionNo);
                        //AddNotification(companyID, load, session);
                        addStatus = true;
                    }
                    CloseSession(session);
                }

            }
            catch (ApplicationException ex)
            {
                if (session != null)
                {
                    CloseSession(session);
                }
                // 2013.07.22 FSWW, Ramesh M Added For Add More Details about calling function in Error log file.
                Logging.LogError(ex, "AddLoad : CustomerID-" + companyID + "\n");
                //throw ex;
            }
            catch (Exception ex)
            {
                if (session != null)
                {
                    CloseSession(session);
                }
                // 2013.06.24 FSWW, Ramesh M Added For CR#58976 To Add More Details about calling function in Error log file.
                Logging.LogError(ex, "AddLoad : CustomerID-" + companyID + "\n");
                // throw ex;
            }
            finally
            {
                if (session != null)
                {
                    CloseSession(session);
                }
            }

            return addStatus;
        }

        /// <summary>
        /// This function is used to Delete Load information
        /// </summary>
        /// <param name="companyID"></param>
        /// <param name="password"></param>
        /// <param name="load"></param>
        /// <param name="vehicleCode"></param>
        /// <param name="SleeperRig"></param>
        /// <param name="UserName"></param>
        /// <param name="UserPassword"></param>
        /// <param name="Email"></param>
        /// <param name="FirstName"></param>
        /// <param name="MiddleName"></param>
        /// <param name="LastName"></param>
        /// <returns></returns>
        public Boolean DeleteLoad(String companyID, String password, Load load, String vehicleCode, Boolean SleeperRig, String UserName, String UserPassword, String Email, String FirstName, String MiddleName, String LastName, String VersionNo = "")
        {
            Boolean addStatus = false;
            ISession session = null;
            try
            {
                //2013.08.01 FSWW, Ramesh M Added For Add if condition for Error log ON/OFF switch control
                if (LoggingStatus == "on")
                {
                }
                session = GetSession();
               
                if (ValidateCustomerLogin(companyID, password, VersionNo))
                {
               
                    List<Load> existingLoads = DALMethods.GetLoads(false, 60, 0, companyID, Guid.Empty, load.LoadNo, string.Empty, 0, 0, false, false, Convert.ToDateTime("1/1/1753 12:00:00 AM"), session, VersionNo);
                    if (existingLoads.Count > 0)
                    {
                        foreach (Load existingLoad in existingLoads)
                        {
                          
                            DALMethods.UpdatedDeletedLoads(existingLoad.ID, DateTime.Now, session, VersionNo);                          
                        }
                    }

                    addStatus = true;

                }
                CloseSession(session);

            }
            catch (ApplicationException ex)
            {
                if (session != null)
                {
                    CloseSession(session);
                }
                // 2013.07.22 FSWW, Ramesh M Added For  Add More Details about calling function in Error log file.
                Logging.LogError(ex, "DeleteLoad : CustomerID-" + companyID + "\n");
                throw ex;
            }
            catch (Exception ex)
            {
                if (session != null)
                {
                    CloseSession(session);
                }
                // 2013.06.24 FSWW, Ramesh M Added For CR#58976 To Add More Details about calling function in Error log file.
                Logging.LogError(ex, "DeleteLoad : CustomerID-" + companyID + "\n");
                throw ex;
            }
            finally
            {
                if (session != null)
                {
                    CloseSession(session);
                }
            }

            return addStatus;
        }


        //private void AddNotification(String customerID, Load load, ISession session)
        //{
        //    try
        //    {

        //        LoginHistory history = DALMethods.GetLatestLoginHistory(load.DriverID, load.VehicleID, session);
        //        if (history != null && history.IsValidToken)
        //        {
        //            List<Load> lstLoads = DALMethods.GetLoads(true, ApplicationConstants.TimeToRemoveRCLoads, history.LoginID, customerID, Guid.Empty,String.Empty, "I", load.VehicleID, load.DriverID, false, false, session);
        //            lstLoads.RemoveAll(item => item.DriverID == 0);
        //            DALMethods.AddNotification(history.LoginID, lstLoads.Count, session);
        //        }
        //    }
        //    catch 
        //    {
        //        //Logging.LogError(ex);
        //    }

        //}

        // 12-17-2014  MadhuVenkat K  Added for CR 65762 - In Multi BOL processing, the gross qty and Net qty not updating correct qty.
        /// <summary>
        /// AddDeliveryDetails
        /// Function to insert the records into delivery details table
        /// </summary>
        /// <param name="UserName">User name</param>
        /// <param name="password">Password</param>
        /// <param name="vehicleID">Vehicle ID</param>
        /// <param name="companyID">Company ID</param>
        /// <param name="orderItemID">Order item ID</param>
        /// <param name="grossQty">Gross quantity</param>
        /// <param name="netQty">Net quantity</param>
        /// <param name="delivDtTm">Delivery date time</param>
        /// <param name="deviceID">deviceID</param>
        /// <param name="deviceTime">DeviceTime</param>
        /// <param name="beforeVolume">Before Volume</param>
        /// <param name="afterVolume">After Volume</param>
        /// <returns>True = Inserted successfully, False = Faile</returns>
        public Boolean AddDeliveryDetails(String UserName, String password, String vehicleID, String companyID, Guid orderItemID, Decimal grossQty, Decimal netQty, DateTime delivDtTm, String deviceID, DateTime deviceTime, Decimal? beforeVolume, Decimal? afterVolume, String delivered, String DeliveryQtyVarianceReason, String BOLNo, String VersionNo, String Image = "", String Notes = "", String PONo = "", Guid PreOrderItemID = new Guid())
        {
            Boolean updateStatus = false;
            ISession session = null;
            //string[] sptcustomerID = ConfigurationManager.AppSettings["DeliverProcClient"].ToString().Trim().Split(',');

            try
            {
                //2013.08.01 FSWW, Ramesh M Added For Add if condition for Error log ON/OFF switch control
                if (LoggingStatus == "on")
                {
                }
                session = GetSession();
                //Logging.LogInfoAboutCallingFunction("before login AddDeliveryDetails: CustomerID- " + companyID + " orderItemID : " + orderItemID + " BOLNo : " + BOLNo + " vehicleID: " + vehicleID + " UserName : " + UserName + " VersionNo: " + VersionNo);
                if (ValidateUserLogin(UserName, password, companyID, vehicleID, VersionNo))
                {
                    if (DALMethods.IsSplitLoad(new Guid(), orderItemID, 0, session))
                    {
                        DALMethods.UpdateBOLItemsAtDelivery(orderItemID, BOLNo, PreOrderItemID, session);
                    }
                    else
                    {
                        //Added by Venkatesh(At the time of delivery shipmentment will go to ascend)
                        try
                        {
                            DALMethods.UpdateShipNeedUpdate(session, orderItemID);
                        }
                        catch (Exception ex)
                        {
                            Logging.LogError(ex, "UpdateShipNeedUpdate : CustomerID-" + companyID + "orderItemID:" + orderItemID + "BOLNo:" + BOLNo + "\n");
                        }
                    }

                    //Logging.LogInfoAboutCallingFunction("Success AddDeliveryDetails: CustomerID-" + companyID + "orderItemID: " + orderItemID + "BOLNo:" + BOLNo + " vehicleID: " + vehicleID + " UserName : " + UserName + "VersionNo:" + VersionNo);
                    Int32 loginID = DALMethods.GetUserID(UserName, companyID, session, VersionNo);

                    //bool procCompId = false;
                    //for (int c = 0; c < sptcustomerID.Length; c++)
                    //{
                    //    if (companyID.Trim() == sptcustomerID[c].Trim())
                    //    {
                    //        procCompId = true;
                    //        break;
                    //    }
                    //}

                    DALMethods.AddDeliveryDetailsNew(orderItemID, grossQty, netQty, grossQty, delivDtTm, loginID, deviceID, deviceTime, beforeVolume, afterVolume, session, delivered, DeliveryQtyVarianceReason, BOLNo, Image, Notes, PONo, PreOrderItemID, companyID, VersionNo);

                    DALMethods.UpdateSignatureStatusByOrderItemID(orderItemID, session, VersionNo);
                    updateStatus = true;
                }
                CloseSession(session);
            }
            catch (ApplicationException ex)
            {
                if (session != null)
                {
                    CloseSession(session);
                }
                // 2013.07.22 FSWW, Ramesh M Added For  Add More Details about calling function in Error log file.
                Logging.LogError(ex, "AddDeliveryDetails : CustomerID-" + companyID + "orderItemID:" + orderItemID + "BOLNo:" + BOLNo + "\n");
                throw ex;
            }
            catch (Exception ex)
            {
                if (session != null)
                {
                    CloseSession(session);
                }
                // 2013.06.24 FSWW, Ramesh M Added For CR#58976 To Add More Details about calling function in Error log file.
                Logging.LogError(ex, "CustomerID-" + companyID + "orderItemID:" + orderItemID + "BOLNo:" + BOLNo + "\n");
                Logging.LogInfoAboutCallingFunction(ex + "Error AddDeliveryDetails: CustomerID-" + companyID + "orderItemID: " + orderItemID + "BOLNo:" + BOLNo);
                throw ex;
            }
            finally
            {
                if (session != null)
                {
                    CloseSession(session);
                }
            }

            return updateStatus;
        }

        public List<DeliveryXMLResponse> AddDeliveryDetailsXML(List<DeliveryDetailsXML> lsDeliveryDetails, String UserName, String password, String vehicleID, String companyID, String VersionNo = "")
        {
            List<DeliveryXMLResponse> lsDeliveryDetailsXML = new List<DeliveryXMLResponse>();
            DeliveryXMLResponse deliveryDetailsXML = new DeliveryXMLResponse();
            deliveryDetailsXML.Status = false;
            deliveryDetailsXML.OrderID = Guid.Empty;
            ISession session = null;
            //string[] sptcustomerID = ConfigurationManager.AppSettings["DeliverProcClient"].ToString().Trim().Split(',');

            try
            {
                //string ItemsXML = string.Empty;
                //using (StringWriter sw = new StringWriter())
                //{
                //    XmlSerializer xs = new XmlSerializer(typeof(List<DeliveryDetailsXML>));
                //    xs.Serialize(sw, lsDeliveryDetails);
                //    ItemsXML = sw.ToString().Replace("utf-16", "utf-8");
                //}

                //DALMethods.AddBolDetailsTemp(Guid.NewGuid(), ItemsXML, GetSession());

                if (lsDeliveryDetails != null)
                {
                    if (lsDeliveryDetails.Count > 0)
                    {
                        for (var i = 0; i < lsDeliveryDetails.Count; i++)
                        {
                            try
                            {
                                //2013.08.01 FSWW, Ramesh M Added For Add if condition for Error log ON/OFF switch control
                                if (LoggingStatus == "on")
                                {
                                }
                                session = GetSession();
                                if (ValidateUserLogin(UserName, password, companyID, vehicleID, VersionNo))
                                {

                                    if (DALMethods.IsSplitLoad(new Guid(), lsDeliveryDetails[i].OrderItemID, 0, session))
                                    {
                                        Logging.LogInfoAboutCallingFunction("AddDeliveryDetailsXml: orderItemID-" + lsDeliveryDetails[i].OrderItemID + "BOLNo: " + lsDeliveryDetails[i].BOLNo + "PreOrderItemID:" + lsDeliveryDetails[i].PreOrderItemID);
                                        DALMethods.UpdateBOLItemsAtDelivery(lsDeliveryDetails[i].OrderItemID, lsDeliveryDetails[i].BOLNo, lsDeliveryDetails[i].PreOrderItemID, session);
                                    }
                                    else
                                    {
                                        //Added by Venkatesh(At the time of delivery shipmentment will go to ascend)
                                        try
                                        {
                                            DALMethods.UpdateShipNeedUpdate(session, lsDeliveryDetails[i].OrderItemID);
                                        }
                                        catch (Exception ex)
                                        {
                                            Logging.LogError(ex, "UpdateShipNeedUpdate : CustomerID-" + companyID + "orderItemID:" + lsDeliveryDetails[i].OrderItemID + "BOLNo:" + lsDeliveryDetails[i].BOLNo + "\n");
                                        }

                                        //Thread.Sleep(2000);//Wait for 2 seconds to complete the shipment fully
                                    }

                                    //Logging.LogInfoAboutCallingFunction("Success AddDeliveryDetails: CustomerID-" + companyID + "orderItemID: " + orderItemID + "BOLNo:" + BOLNo + " vehicleID: " + vehicleID + " UserName : " + UserName + "VersionNo:" + VersionNo);
                                    Int32 loginID = DALMethods.GetUserID(UserName, companyID, session, VersionNo);

                                    //bool procCompId = false;
                                    //for (int c = 0; c < sptcustomerID.Length; c++)
                                    //{
                                    //    if (companyID.Trim() == sptcustomerID[c].Trim())
                                    //    {
                                    //        procCompId = true;
                                    //        break;
                                    //    }
                                    //}

                                    DALMethods.AddDeliveryDetailsNew(lsDeliveryDetails[i].OrderItemID, lsDeliveryDetails[i].GrossQty, lsDeliveryDetails[i].NetQty, lsDeliveryDetails[i].GrossQty, lsDeliveryDetails[i].DelivDtTm, loginID, lsDeliveryDetails[i].DeviceID, lsDeliveryDetails[i].DeviceTime, lsDeliveryDetails[i].BeforeVolume, lsDeliveryDetails[i].AfterVolume, session, lsDeliveryDetails[i].Delivered, lsDeliveryDetails[i].DeliveryQtyVarianceReason, lsDeliveryDetails[i].BOLNo, lsDeliveryDetails[i].Image, lsDeliveryDetails[i].Notes, lsDeliveryDetails[i].PONo, lsDeliveryDetails[i].PreOrderItemID, companyID, VersionNo);

                                    DALMethods.UpdateSignatureStatusByOrderItemID(lsDeliveryDetails[i].OrderItemID, session, VersionNo);
                                }

                                deliveryDetailsXML.OrderID = DALMethods.GetOrderIDFromOrderItemID(lsDeliveryDetails[0].OrderItemID, session, VersionNo);
                                deliveryDetailsXML.Status = true;
                                lsDeliveryDetailsXML.Add(deliveryDetailsXML);

                                //Logging.LogInfoAboutCallingFunction("lsDeliveryDetailsXML - " + lsDeliveryDetailsXML.Count);

                                CloseSession(session);


                            }
                            catch (ApplicationException ex)
                            {
                                if (session != null)
                                {
                                    CloseSession(session);
                                }
                                // 2013.07.22 FSWW, Ramesh M Added For  Add More Details about calling function in Error log file.                            
                                Logging.LogInfoAboutCallingFunction(ex + "Error AddDeliveryDetailsXML: CustomerID-" + companyID + "orderItemID: " + lsDeliveryDetails[i].OrderItemID + "BOLNo:" + lsDeliveryDetails[i].BOLNo);
                                throw ex;
                            }
                            catch (Exception ex)
                            {
                                if (session != null)
                                {
                                    CloseSession(session);
                                }
                                // 2013.06.24 FSWW, Ramesh M Added For CR#58976 To Add More Details about calling function in Error log file.                           
                                Logging.LogInfoAboutCallingFunction(ex + "Error AddDeliveryDetailsXML: CustomerID-" + companyID + "orderItemID: " + lsDeliveryDetails[i].OrderItemID + "BOLNo:" + lsDeliveryDetails[i].BOLNo);
                                throw ex;
                            }
                            finally
                            {
                                if (session != null)
                                {
                                    CloseSession(session);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logging.LogInfoAboutCallingFunction("AddDeliveryDetailsXML " + ex.Message);
            }

            return lsDeliveryDetailsXML;
        }

        //2013.07.04 FSWW, Ramesh M Added For CR#59047 
        /// <summary>
        /// 
        /// </summary>
        /// <param name="SessionID"></param>
        /// <param name="BreakStartTime"></param>
        /// <param name="BreakEndTime"></param>
        /// <param name="TimeViolation"></param>
        /// <param name="MovingViolation"></param>
        /// <param name="NoBreakViolation"></param>
        /// <returns></returns>
        public Boolean AddBreakDetails(Guid SessionID, DateTime BreakStartTime, DateTime? BreakEndTime, String TimeViolation, String MovingViolation, String NoBreakViolation, String VersionNo = "")
        {
            Boolean InsertStatus = false;
            ISession session = null;
            try
            {
                //2013.08.01 FSWW, Ramesh M Added For Add if condition for Error log ON/OFF switch control
                if (LoggingStatus == "on")
                {
                }
                session = GetSession();
                DALMethods.AddBreakDetails(SessionID, BreakStartTime, BreakEndTime, TimeViolation, MovingViolation, NoBreakViolation, session, VersionNo);
                InsertStatus = true;

                CloseSession(session);
            }
            catch (ApplicationException ex)
            {
                if (session != null)
                {
                    CloseSession(session);
                }
                // 2013.07.22 FSWW, Ramesh M Added For  Add More Details about calling function in Error log file.
                Logging.LogError(ex, "AddBreakDetails : SessionID-" + SessionID + "\n");
                throw ex;
            }
            catch (Exception ex)
            {
                if (session != null)
                {
                    CloseSession(session);
                }
                // 2013.06.24 FSWW, Ramesh M Added For CR#58976 To Add More Details about calling function in Error log file.
                Logging.LogError(ex, "AddBreakDetails : SessionID-" + SessionID + "\n");
                throw ex;
            }
            finally
            {
                if (session != null)
                {
                    CloseSession(session);
                }
            }

            return InsertStatus;
        }
        //2013.07.04 FSWW, Ramesh M Added For CR#59047 
        /// <summary>
        /// 
        /// </summary>
        /// <param name="SessionID"></param>
        /// <param name="BreakStartTime"></param>
        /// <param name="BreakEndTime"></param>
        /// <returns></returns>
        public Boolean UpdateBreakDetails(Guid SessionID, DateTime BreakStartTime, DateTime BreakEndTime, String VersionNo = "")
        {
            Boolean InsertStatus = false;
            ISession session = null;
            try
            {
                //2013.08.01 FSWW, Ramesh M Added For Add if condition for Error log ON/OFF switch control
                if (LoggingStatus == "on")
                {
                }
                session = GetSession();
                DALMethods.UpdateBreakDetails(SessionID, BreakStartTime, BreakEndTime, session, VersionNo);
                InsertStatus = true;

                CloseSession(session);
            }
            catch (ApplicationException ex)
            {
                if (session != null)
                {
                    CloseSession(session);
                }
                // 2013.07.22 FSWW, Ramesh M Added For  Add More Details about calling function in Error log file.
                Logging.LogError(ex, "UpdateBreakDetails : SessionID-" + SessionID + "\n");
                throw ex;
            }
            catch (Exception ex)
            {
                if (session != null)
                {
                    CloseSession(session);
                }
                // 2013.06.24 FSWW, Ramesh M Added For CR#58976 To Add More Details about calling function in Error log file.
                Logging.LogError(ex, "UpdateBreakDetails : SessionID-" + SessionID + "\n");
                throw ex;
            }
            finally
            {
                if (session != null)
                {
                    CloseSession(session);
                }
            }

            return InsertStatus;
        }



        // 2014.02.16  Ramesh M Added For CR#62166 For DOT OverRide

        /// <summary>
        /// 
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="password"></param>
        /// <param name="vehicleID"></param>
        /// <param name="companyID"></param>
        /// <param name="SessionID"></param>
        /// <param name="StartTime"></param>
        /// <param name="EndTime"></param>
        /// <param name="TimeViolation"></param>
        /// <param name="MovingViolation"></param>
        /// <param name="NoBreakViolation"></param>
        /// <param name="ExceptionType"></param>
        /// <param name="ExceptionReason"></param>
        /// <param name="VersionNo"></param>
        /// <returns></returns>
        public Boolean AddDriverTimeExceptions(String UserName, String password, String vehicleID, String companyID, Guid SessionID, DateTime StartTime,
                                               DateTime? EndTime, String TimeViolation, String MovingViolation, String NoBreakViolation, String ExceptionType, String ExceptionReason, String VersionNo = "")
        {
            Boolean InsertStatus = false;
            ISession session = null;
            try
            {
                //2013.08.01 FSWW, Ramesh M Added For Add if condition for Error log ON/OFF switch control
                if (LoggingStatus == "on")
                {
                }
                session = GetSession();
                if (IsSessionIDExist(SessionID, session, VersionNo))
                {
                    if (ValidateUserLogin(UserName, password, companyID, vehicleID, VersionNo))
                    {
                        DALMethods.DriverTimeExceptions(SessionID, StartTime, EndTime, TimeViolation, MovingViolation, NoBreakViolation, ExceptionType, ExceptionReason, session, VersionNo);
                    }
                }
                InsertStatus = true;
                CloseSession(session);
            }
            catch (ApplicationException ex)
            {
                if (session != null)
                {
                    CloseSession(session);
                }
                // 2013.07.22 FSWW, Ramesh M Added For  Add More Details about calling function in Error log file.
                Logging.LogError(ex, "AddDriverTimeExceptions : SessionID-" + SessionID + "\n");
                throw ex;
            }
            catch (Exception ex)
            {
                if (session != null)
                {
                    CloseSession(session);
                }
                // 2013.06.24 FSWW, Ramesh M Added For CR#58976 To Add More Details about calling function in Error log file.
                Logging.LogError(ex, "AddDriverTimeExceptions : SessionID-" + SessionID + "\n");
                throw ex;
            }
            finally
            {
                if (session != null)
                {
                    CloseSession(session);
                }
            }

            return InsertStatus;
        }

        //2013.08.12 FSWW, Ramesh M Added For CR#?... Added AssignedDriverLoginID in input details.
        //2013.08.22 FSWW, Ramesh M Added For CR#?... Added AssignedVehicleID in input details.
        //2013.08.22 FSWW, Ramesh M Added For CR#61432 Added LoadType
        //2014.01.28 Ramesh M Added For Support Multi BOL ites added ExtSysTrxLine For CR#62038
        //2014.03.18 Ramesh M Added For CR#62719 added  TrailerCode in input parameters
        //09-23-2014 MadhuVenkat k - Added for CR#65002  added SupplierCode and SupplyPointCode.
        /// <summary>
        /// AddShipmentDetails
        /// Function to add shipment details
        /// </summary>
        /// <param name="UserName">User name</param>
        /// <param name="password">Password</param>
        /// <param name="vehicleID">Vehicle ID</param>
        /// <param name="companyID">Company ID</param>
        /// <param name="loadID">Load ID</param>
        /// <param name="bolNo">BOL number</param>
        /// <param name="bolDateTime">BOL date time</param>
        /// <param name="sysTrxNo">System transaction number</param>
        /// <param name="sysTrxLine">System transaction line</param>
        /// <param name="componentNo">Component number</param>
        /// <param name="grossQty">Gross quantity</param>
        /// <param name="netQty">Net quantity</param>
        /// <param name="images">Images</param>
        /// <param name="deviceID">deviceID</param>
        /// <param name="deviceTime">DeviceTime</param>
        /// <param name="BOLWaitTime">BOLWaitTime</param>
        /// <param name="BOLWaitTime_Comment">BOLWaitTime_Comment</param>
        /// <param name="BOLWaitTime_Start">BOLWaitTime_Start</param>
        /// <param name="BOLWaitTime_End">BOLWaitTime_End</param>
        /// <param name="BOLQtyVarianceReason">BOL Qty Variance Reason </param>
        /// <param name="AssignedDriverLoginID">AssignedDriverLoginID</param>
        /// <param name="AssignedVehicleID">AssignedVehicleID</param>
        /// <param name="LoadType">LoadType</param>
        /// <returns>True = Inserted successfully, False = Faile</returns>
        public Boolean AddShipmentDetails(String UserName, String password, String vehicleID, String companyID, Guid loadID, String bolNo, DateTime bolDateTime, DateTime? bolDateTimeEnd, Decimal sysTrxNo, Int32 sysTrxLine, Int32 componentNo, Decimal grossQty, Decimal netQty, String images, String deviceID, DateTime deviceTime, Boolean BOLWaitTime, String BOLWaitTime_Comment, DateTime? BOLWaitTime_Start, DateTime? BOLWaitTime_End, String BOLQtyVarianceReason, Int32 AssignedDriverLoginID, Int32 AssignedVehicleID, String LoadType, Int32 ExtSysTrxLine, String TrailerCode, String SupplierCode, String SupplyPointCode, String VersionNo, Guid OrderItemID = new Guid())
        {

            Boolean updateStatus = false;
            //Boolean IsSplitLoad = false;
            //Boolean NeedUpdate = false;
            ISession session = null;
            //2013.08.22 FSWW, Ramesh M Added For CR#61432
            Boolean ValidSession = false;
            try
            {
                //2013.08.01 FSWW, Ramesh M Added For Add if condition for Error log ON/OFF switch control
                if (LoggingStatus == "on")
                {
                }
                session = GetSession();
                //IsSplitLoad = DALMethods.IsSplitLoad(loadID, new Guid(), 1, session);
                //if (IsSplitLoad == true && IsShipDocAtDelivery == "Y")
                //{
                //    NeedUpdate = false;
                //}
                //else
                //{
                //    NeedUpdate = true;
                //}
                //2013.08.22 FSWW, Ramesh M Added For CR#61432
                if (LoadType.ToLower() == "w")
                {
                    if (ValidateUserLoginAndSiteID(UserName, password, companyID, vehicleID, VersionNo))
                    {
                        ValidSession = true;
                    }
                }
                else if (LoadType.ToLower() == "v")
                {
                    if (ValidateUserLogin(UserName, password, companyID, vehicleID, VersionNo))
                    {
                        ValidSession = true;
                    }
                }
                //2013.08.22 FSWW, Ramesh M Added For CR#61432
                if (ValidSession == true)
                {
                    Int32 loginID = DALMethods.GetUserID(UserName, companyID, session, VersionNo);
                    DALMethods.UpdateUndispatched(0, loadID, session, VersionNo);//Added for both Undispatch and Deleted Loads
                    Guid bolHdrID = Guid.Empty;
                    List<BolHdr> lstBolHdr = DALMethods.GetBolhdr(Guid.Empty, loadID, bolNo, false, session, VersionNo);
                    if (lstBolHdr.Count > 0)
                    {
                        bolHdrID = lstBolHdr[0].ID;
                    }
                    else
                    {
                        bolHdrID = Guid.NewGuid();
                        byte[] image = null;
                        try
                        {
                            if (!String.IsNullOrWhiteSpace(images))
                            {
                                image = System.Convert.FromBase64String(images);
                            }
                        }
                        catch
                        {
                            image = null;
                        }
                        //2014.03.18 Ramesh M, Added For CR#62719 added  TrailerCode in input parameters 
                        //09-23-2014  MadhuVenkat k - Added for CR#65002  added SupplierCode and SupplyPointCode.
                        DALMethods.AddBolHdr(bolHdrID, loadID, bolNo, image, bolDateTime, bolDateTimeEnd, loginID, BOLWaitTime, BOLWaitTime_Comment, BOLWaitTime_Start, BOLWaitTime_End, session, TrailerCode, SupplierCode, SupplyPointCode, VersionNo);
                    }
                    componentNo = componentNo == 0 ? 1 : componentNo;
                    //2014.01.28  Ramesh M Added For Support Multi BOL ites added ExtSysTrxLine For CR#62038
                    DALMethods.AddBolItem(bolHdrID, sysTrxNo, sysTrxLine, componentNo, grossQty, netQty, loginID, deviceID, deviceTime, BOLQtyVarianceReason, AssignedDriverLoginID, AssignedVehicleID, session, ExtSysTrxLine, OrderItemID, VersionNo);
                    updateStatus = true;
                }
                CloseSession(session);
            }
            catch (ApplicationException ex)
            {
                if (session != null)
                {
                    CloseSession(session);
                }
                // 2013.07.22 FSWW, Ramesh M Added For Add More Details about calling function in Error log file.               
                Logging.LogInfoAboutCallingFunction("AddShipmentDetails - Errors: CustomerID - " + companyID + " LoadID : " + loadID + "bolNo : " + bolNo + " VersionNo : " + VersionNo + "Exception :" + ex);
                throw ex;
            }
            catch (Exception ex)
            {
                if (session != null)
                {
                    CloseSession(session);
                }
                // 2013.06.24 FSWW, Ramesh M Added For CR#58976 To Add More Details about calling function in Error log file.               
                Logging.LogInfoAboutCallingFunction("AddShipmentDetails - Errors: CustomerID - " + companyID + " LoadID : " + loadID + "bolNo : " + bolNo + " VersionNo : " + VersionNo + "Exception :" + ex);
                throw ex;
            }
            finally
            {
                if (session != null)
                {
                    CloseSession(session);
                }
            }


            return updateStatus;
        }


        /// <summary>
        /// UpdateStuckLoads
        /// Function to UpdateStuckLoads
        /// </summary>
        public Boolean UpdateStuckLoads(String UserName, String password, String vehicleID, String companyID, Guid loadID, String VersionNo)
        {
            Boolean updateStatus = false;
            ISession session = null;
            //2013.08.22 FSWW, Ramesh M Added For CR#61432
            Boolean ValidSession = false;
            try
            {
                if (LoggingStatus == "on")
                {
                }
                session = GetSession();

                if (ValidateUserLogin(UserName, password, companyID, vehicleID, VersionNo))
                {
                    ValidSession = true;
                }
                DALMethods.UpdateStuckLoads(companyID, loadID, session, VersionNo);
                updateStatus = true;
                CloseSession(session);
            }
            catch (ApplicationException ex)
            {
                if (session != null)
                {
                    CloseSession(session);
                }
                Logging.LogError(ex, "Function Called:- UpdateStuckLoads ; " + "CustomerID-" + companyID + "LoadID " + loadID + "\n");
                throw ex;
            }
            catch (Exception ex)
            {
                if (session != null)
                {
                    CloseSession(session);
                }
                Logging.LogError(ex, "Function Called:- UpdateStuckLoads ; " + "CustomerID-" + companyID + "LoadID " + loadID + "\n");
                throw ex;
            }
            finally
            {
                if (session != null)
                {
                    CloseSession(session);
                }
            }

            return updateStatus;
        }

        /// <summary>
        /// AddShipmentDetailsXML
        /// Function to add shipment details
        /// </summary>
        public Boolean AddShipmentDetailsXML(List<BolHdrXML> lsBolHdrXML, String UserName, String password, String vehicleID, String companyID, Guid loadID, String LoadType, String VersionNo)
        {
            Boolean updateStatus = false;
            ISession session = null;
            //2013.08.22 FSWW, Ramesh M Added For CR#61432
            Boolean ValidSession = false;
            try
            {

                //string ItemsXML = string.Empty;
                //using (StringWriter sw = new StringWriter())
                //{
                //    XmlSerializer xs = new XmlSerializer(typeof(List<BolHdrXML>));
                //    xs.Serialize(sw, lsBolHdrXML);
                //    ItemsXML = sw.ToString().Replace("utf-16", "utf-8");
                //}

                //DALMethods.AddBolDetailsTemp(loadID, ItemsXML, GetSession());

                if (lsBolHdrXML != null)
                {
                    if (lsBolHdrXML.Count > 0)
                    {

                        for (var i = 0; i < lsBolHdrXML.Count; i++)
                        {

                            if (lsBolHdrXML[i].ZBolitemXML != null)
                            {
                                if (lsBolHdrXML[i].ZBolitemXML.Count > 0)
                                {

                                    for (var j = 0; j < lsBolHdrXML[i].ZBolitemXML.Count; j++)
                                    {
                                        try
                                        {
                                            //2013.08.01 FSWW, Ramesh M Added For Add if condition for Error log ON/OFF switch control
                                            if (LoggingStatus == "on")
                                            {
                                            }
                                            session = GetSession();

                                            //2013.08.22 FSWW, Ramesh M Added For CR#61432
                                            if (LoadType.ToLower() == "w")
                                            {
                                                if (ValidateUserLoginAndSiteID(UserName, password, companyID, vehicleID, VersionNo))
                                                {
                                                    ValidSession = true;
                                                }
                                            }
                                            else if (LoadType.ToLower() == "v")
                                            {
                                                if (ValidateUserLogin(UserName, password, companyID, vehicleID, VersionNo))
                                                {
                                                    ValidSession = true;
                                                }
                                            }
                                            //2013.08.22 FSWW, Ramesh M Added For CR#61432
                                            if (ValidSession == true)
                                            {
                                                Int32 loginID = DALMethods.GetUserID(UserName, companyID, session, VersionNo);
                                                DALMethods.UpdateUndispatched(0, loadID, session, VersionNo);//Added for both Undispatch and Deleted Loads
                                                Guid bolHdrID = Guid.Empty;
                                                List<BolHdr> lstBolHdr = DALMethods.GetBolhdr(Guid.Empty, loadID, lsBolHdrXML[i].BOLNo.ToString(), false, session, VersionNo);
                                                if (lstBolHdr.Count > 0)
                                                {
                                                    bolHdrID = lstBolHdr[0].ID;
                                                }
                                                else
                                                {
                                                    bolHdrID = Guid.NewGuid();
                                                    byte[] image = null;
                                                    try
                                                    {
                                                        if (!String.IsNullOrWhiteSpace(lsBolHdrXML[i].Image.ToString()))
                                                        {
                                                            image = System.Convert.FromBase64String(lsBolHdrXML[i].Image.ToString());
                                                        }
                                                    }
                                                    catch
                                                    {
                                                        image = null;
                                                    }
                                                    //2014.03.18 Ramesh M, Added For CR#62719 added  TrailerCode in input parameters 
                                                    //09-23-2014  MadhuVenkat k - Added for CR#65002  added SupplierCode and SupplyPointCode.
                                                    DALMethods.AddBolHdr(bolHdrID, loadID, lsBolHdrXML[i].BOLNo.ToString(), image, lsBolHdrXML[i].BOLDateTime, lsBolHdrXML[i].BOLDateTimeEnd, loginID, lsBolHdrXML[i].BOLWaitTime, lsBolHdrXML[i].BOLWaitTimeComment, lsBolHdrXML[i].BOLWaitTimeStart, lsBolHdrXML[i].BOLWaitTimeEnd, session, lsBolHdrXML[i].TrailerCode, lsBolHdrXML[i].SupplierCode, lsBolHdrXML[i].SupplyPointCode, VersionNo);
                                                }
                                                lsBolHdrXML[i].ZBolitemXML[j].ComponentNo = lsBolHdrXML[i].ZBolitemXML[j].ComponentNo == 0 ? 1 : lsBolHdrXML[i].ZBolitemXML[j].ComponentNo;
                                                //DALMethods.GetVehicleID(vehicleID, companyID, session, VersionNo)
                                                //DALMethods.AddBolItem(bolHdrID, lsBolHdrXML[i].ZBolitemXML[j].SysTrxNo, lsBolHdrXML[i].ZBolitemXML[j].SysTrxLine, lsBolHdrXML[i].ZBolitemXML[j].ComponentNo, lsBolHdrXML[i].ZBolitemXML[j].GrossQty, lsBolHdrXML[i].ZBolitemXML[j].NetQty, loginID, lsBolHdrXML[i].ZBolitemXML[j].DeviceID, lsBolHdrXML[i].ZBolitemXML[j].DeviceTime, lsBolHdrXML[i].ZBolitemXML[j].BOLQtyVarianceReason, lsBolHdrXML[i].ZBolitemXML[j].AssignedDriverLoginID, lsBolHdrXML[i].ZBolitemXML[j].AssignedVehicleID, session, lsBolHdrXML[i].ZBolitemXML[j].ExtSysTrxLine, lsBolHdrXML[i].ZBolitemXML[j].OrderItemID, VersionNo);
                                                DALMethods.AddBolItem(bolHdrID, lsBolHdrXML[i].ZBolitemXML[j].SysTrxNo, lsBolHdrXML[i].ZBolitemXML[j].SysTrxLine, lsBolHdrXML[i].ZBolitemXML[j].ComponentNo, lsBolHdrXML[i].ZBolitemXML[j].GrossQty, lsBolHdrXML[i].ZBolitemXML[j].NetQty, loginID, lsBolHdrXML[i].ZBolitemXML[j].DeviceID, lsBolHdrXML[i].ZBolitemXML[j].DeviceTime, lsBolHdrXML[i].ZBolitemXML[j].BOLQtyVarianceReason, lsBolHdrXML[i].ZBolitemXML[j].AssignedDriverLoginID, DALMethods.GetVehicleID(lsBolHdrXML[i].ZBolitemXML[j].AssignedVehicleID, companyID, session, VersionNo), session, lsBolHdrXML[i].ZBolitemXML[j].ExtSysTrxLine, lsBolHdrXML[i].ZBolitemXML[j].OrderItemID, VersionNo);
                                                updateStatus = true;
                                            }
                                            else
                                            {
                                                //Logging.LogInfoAboutCallingFunction("AddShipmentDetailsXML - Invalid Session.");
                                            }
                                            CloseSession(session);
                                        }
                                        catch (ApplicationException ex)
                                        {
                                            if (session != null)
                                            {
                                                CloseSession(session);
                                            }
                                            Logging.LogInfoAboutCallingFunction("AddShipmentDetails - Errors: CustomerID - " + companyID + " LoadID : " + loadID + "bolNo : " + lsBolHdrXML[i].BOLNo.ToString() + " VersionNo : " + VersionNo + "Exception :" + ex);
                                            throw ex;
                                        }
                                        catch (Exception ex)
                                        {
                                            if (session != null)
                                            {
                                                CloseSession(session);
                                            }
                                            Logging.LogInfoAboutCallingFunction("AddShipmentDetails - Errors: CustomerID - " + companyID + " LoadID : " + loadID + "bolNo : " + lsBolHdrXML[i].BOLNo.ToString() + " VersionNo : " + VersionNo + "Exception :" + ex);
                                            throw ex;
                                        }
                                        finally
                                        {
                                            if (session != null)
                                            {
                                                CloseSession(session);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logging.LogInfoAboutCallingFunction("AddShipmentDetailsXML " + ex.Message);
            }
            return updateStatus;
        }

        public List<ShipmentXMLResponse> AddShipmentXML(List<BolHdrXML> lsBolHdrXML, String UserName, String password, String vehicleID, String companyID, Guid loadID, String LoadType, String VersionNo)
        {
            List<ShipmentXMLResponse> lstShipmentXML = new List<ShipmentXMLResponse>();
            ShipmentXMLResponse shipmentXML = new ShipmentXMLResponse();
            shipmentXML.Status = false;
            shipmentXML.LoadID = Guid.Empty;
            ISession session = null;
            //2013.08.22 FSWW, Ramesh M Added For CR#61432
            Boolean ValidSession = false;
            try
            {

                //string ItemsXML = string.Empty;
                //using (StringWriter sw = new StringWriter())
                //{
                //    XmlSerializer xs = new XmlSerializer(typeof(List<BolHdrXML>));
                //    xs.Serialize(sw, lsBolHdrXML);
                //    ItemsXML = sw.ToString().Replace("utf-16", "utf-8");
                //}

                //DALMethods.AddBolDetailsTemp(loadID, ItemsXML, GetSession());

                if (lsBolHdrXML != null)
                {
                    if (lsBolHdrXML.Count > 0)
                    {
                        for (var i = 0; i < lsBolHdrXML.Count; i++)
                        {

                            if (lsBolHdrXML[i].ZBolitemXML != null)
                            {
                                if (lsBolHdrXML[i].ZBolitemXML.Count > 0)
                                {

                                    for (var j = 0; j < lsBolHdrXML[i].ZBolitemXML.Count; j++)
                                    {

                                        try
                                        {
                                            //2013.08.01 FSWW, Ramesh M Added For Add if condition for Error log ON/OFF switch control
                                            if (LoggingStatus == "on")
                                            {
                                            }
                                            session = GetSession();

                                            //2013.08.22 FSWW, Ramesh M Added For CR#61432
                                            if (LoadType.ToLower() == "w")
                                            {
                                                if (ValidateUserLoginAndSiteID(UserName, password, companyID, vehicleID, VersionNo))
                                                {
                                                    ValidSession = true;
                                                }
                                            }
                                            else if (LoadType.ToLower() == "v")
                                            {

                                                if (ValidateUserLogin(UserName, password, companyID, vehicleID, VersionNo))
                                                {
                                                    ValidSession = true;
                                                }
                                            }
                                            //2013.08.22 FSWW, Ramesh M Added For CR#61432
                                            if (ValidSession == true)
                                            {
                                                Int32 loginID = DALMethods.GetUserID(UserName, companyID, session, VersionNo);
                                                DALMethods.UpdateUndispatched(0, loadID, session, VersionNo);//Added for both Undispatch and Deleted Loads
                                                Guid bolHdrID = Guid.Empty;
                                                List<BolHdr> lstBolHdr = DALMethods.GetBolhdr(Guid.Empty, loadID, lsBolHdrXML[i].BOLNo.ToString(), false, session, VersionNo);
                                                if (lstBolHdr.Count > 0)
                                                {
                                                    bolHdrID = lstBolHdr[0].ID;
                                                }
                                                else
                                                {
                                                    bolHdrID = Guid.NewGuid();
                                                    byte[] image = null;
                                                    try
                                                    {
                                                        if (!String.IsNullOrWhiteSpace(lsBolHdrXML[i].Image.ToString()))
                                                        {
                                                            image = System.Convert.FromBase64String(lsBolHdrXML[i].Image.ToString());
                                                        }
                                                    }
                                                    catch
                                                    {
                                                        image = null;
                                                    }

                                                    //2014.03.18 Ramesh M, Added For CR#62719 added  TrailerCode in input parameters 
                                                    //09-23-2014  MadhuVenkat k - Added for CR#65002  added SupplierCode and SupplyPointCode.
                                                    Logging.WriteLog($"UserAcknowledgeZero - {lsBolHdrXML[i].ZBolitemXML[j].UserAcknowledgeZero}",EventLogEntryType.Information);
                                                    DALMethods.SaveBolHdr(bolHdrID, loadID, lsBolHdrXML[i].BOLNo.ToString(), image, lsBolHdrXML[i].BOLDateTime, lsBolHdrXML[i].BOLDateTimeEnd, loginID, lsBolHdrXML[i].BOLWaitTime, lsBolHdrXML[i].BOLWaitTimeComment, lsBolHdrXML[i].BOLWaitTimeStart, lsBolHdrXML[i].BOLWaitTimeEnd, session, lsBolHdrXML[i].TrailerCode, lsBolHdrXML[i].SupplierCode, lsBolHdrXML[i].SupplyPointCode, VersionNo, lsBolHdrXML[i].ZBolitemXML[j].UserAcknowledgeZero);
                                                }
                                                lsBolHdrXML[i].ZBolitemXML[j].ComponentNo = lsBolHdrXML[i].ZBolitemXML[j].ComponentNo == 0 ? 1 : lsBolHdrXML[i].ZBolitemXML[j].ComponentNo;

                                                //DALMethods.AddBolItem(bolHdrID, lsBolHdrXML[i].ZBolitemXML[j].SysTrxNo, lsBolHdrXML[i].ZBolitemXML[j].SysTrxLine, lsBolHdrXML[i].ZBolitemXML[j].ComponentNo, lsBolHdrXML[i].ZBolitemXML[j].GrossQty, lsBolHdrXML[i].ZBolitemXML[j].NetQty, loginID, lsBolHdrXML[i].ZBolitemXML[j].DeviceID, lsBolHdrXML[i].ZBolitemXML[j].DeviceTime, lsBolHdrXML[i].ZBolitemXML[j].BOLQtyVarianceReason, lsBolHdrXML[i].ZBolitemXML[j].AssignedDriverLoginID, lsBolHdrXML[i].ZBolitemXML[j].AssignedVehicleID, session, lsBolHdrXML[i].ZBolitemXML[j].ExtSysTrxLine, lsBolHdrXML[i].ZBolitemXML[j].OrderItemID, VersionNo);
                                                DALMethods.AddBolItem(bolHdrID, lsBolHdrXML[i].ZBolitemXML[j].SysTrxNo, lsBolHdrXML[i].ZBolitemXML[j].SysTrxLine, lsBolHdrXML[i].ZBolitemXML[j].ComponentNo, lsBolHdrXML[i].ZBolitemXML[j].GrossQty, lsBolHdrXML[i].ZBolitemXML[j].NetQty, loginID, lsBolHdrXML[i].ZBolitemXML[j].DeviceID, lsBolHdrXML[i].ZBolitemXML[j].DeviceTime, lsBolHdrXML[i].ZBolitemXML[j].BOLQtyVarianceReason, lsBolHdrXML[i].ZBolitemXML[j].AssignedDriverLoginID, DALMethods.GetVehicleID(lsBolHdrXML[i].ZBolitemXML[j].AssignedVehicleID, companyID, session, VersionNo), session, lsBolHdrXML[i].ZBolitemXML[j].ExtSysTrxLine, lsBolHdrXML[i].ZBolitemXML[j].OrderItemID, VersionNo);

                                            }
                                            else
                                            {
                                                //Logging.LogInfoAboutCallingFunction("AddShipmentDetailsXML - Invalid Session.");
                                            }
                                            CloseSession(session);
                                        }
                                        catch (ApplicationException ex)
                                        {
                                            if (session != null)
                                            {
                                                CloseSession(session);
                                            }
                                            //Logging.LogError(ex, "CustomerID-" + companyID + "LoadID" + loadID + "\n");
                                            Logging.LogInfoAboutCallingFunction("AddShipmentDetails - Errors: CustomerID - " + companyID + " LoadID : " + loadID + "bolNo : " + lsBolHdrXML[i].BOLNo.ToString() + " VersionNo : " + VersionNo + "Exception :" + ex);
                                            throw ex;
                                        }
                                        catch (Exception ex)
                                        {
                                            if (session != null)
                                            {
                                                CloseSession(session);
                                            }

                                            //Logging.LogError(ex, "CustomerID-" + companyID + "LoadID" + loadID + "\n");
                                            Logging.LogInfoAboutCallingFunction("AddShipmentDetails - Errors: CustomerID - " + companyID + " LoadID : " + loadID + "bolNo : " + lsBolHdrXML[i].BOLNo.ToString() + " VersionNo : " + VersionNo + "Exception :" + ex);
                                            throw ex;
                                        }
                                        finally
                                        {
                                            if (session != null)
                                            {
                                                CloseSession(session);
                                            }
                                        }
                                    }

                                    shipmentXML.LoadID = loadID;
                                    shipmentXML.Status = true;
                                    lstShipmentXML.Add(shipmentXML);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logging.LogInfoAboutCallingFunction("AddShipmentDetailsXML " + ex.Message);
            }
            finally
            {
                if (session != null)
                {
                    CloseSession(session);
                }
            }

            return lstShipmentXML;
        }

        /// <summary>
        /// AddOrderFrt
        /// Function to insert the records into OrderFrt table
        /// </summary>
        /// <param name="UserName">User name</param>
        /// <param name="password">Password</param>
        /// <param name="vehicleID">Vehicle ID</param>
        /// <param name="companyID">Company ID</param>
        /// <param name="OrderID">OrderID</param>
        /// <param name="SiteWaitTime">SiteWaitTime</param>
        /// <param name="SiteWaitTime_Comment">SiteWaitTime_Comment</param>
        /// <param name="SiteWaitTime_Start">SiteWaitTime_Start</param>
        /// <param name="SiteWaitTime_End">SiteWaitTime_End</param>
        /// <param name="SplitLoad">SplitLoad</param>
        /// <param name="SplitLoad_Comment">SplitLoad_Comment</param>
        /// <param name="SplitDrop">SplitDrop</param>
        /// <param name="SplitDrop_Comment">SplitDrop_Comment</param>
        /// <param name="PumpOut">PumpOut</param>
        /// <param name="PumpOut_Comment">PumpOut_Comment</param>
        /// <param name="Diversion">Diversion</param>
        /// <param name="Diversion_Comment">Diversion_Comment</param>
        /// <param name="MinimumLoad">MinimumLoad</param>
        /// <param name="MinimumLoad_Comment">MinimumLoad_Comment</param>
        /// <param name="Other">Other</param>
        /// <param name="Other_Comment">Other_Comment</param>
        /// <param name="DeviceID">deviceID</param>
        /// <param name="DeviceTime">DeviceTime</param>
        /// <returns>True = Inserted successfully, False = Faile</returns>
        public Boolean AddOrderFrt(String UserName, String password, String vehicleID, String companyID, Guid OrderID, Boolean? SiteWaitTime, string SiteWaitTime_Comment, DateTime? SiteWaitTime_Start, DateTime? SiteWaitTime_End, Boolean? SplitLoad, string SplitLoad_Comment, Boolean? SplitDrop, string SplitDrop_Comment, Boolean? PumpOut, string PumpOut_Comment, Boolean? Diversion, string Diversion_Comment, Boolean? MinimumLoad, string MinimumLoad_Comment, Boolean? Other, string Other_Comment, string DeviceID, DateTime DeviceTime, string signatureImage, String VersionNo = "")
        {
            Boolean updateStatus = false;
            ISession session = null;
            try
            {
                //2013.08.01 FSWW, Ramesh M Added For Add if condition for Error log ON/OFF switch control
                if (LoggingStatus == "on")
                {
                }
                session = GetSession();
                if (ValidateUserLogin(UserName, password, companyID, vehicleID, VersionNo))
                {
                    Int32 loginID = DALMethods.GetUserID(UserName, companyID, session, VersionNo);
                    DALMethods.AddOrderFrt(OrderID, SiteWaitTime, SiteWaitTime_Comment, SiteWaitTime_Start, SiteWaitTime_End, SplitLoad, SplitLoad_Comment, SplitDrop, SplitDrop_Comment, PumpOut, PumpOut_Comment, Diversion, Diversion_Comment, MinimumLoad, MinimumLoad_Comment, Other, Other_Comment, loginID, DeviceID, DeviceTime, session, VersionNo);

                    updateStatus = true;
                }
                CloseSession(session);
            }
            catch (ApplicationException ex)
            {
                if (session != null)
                {
                    CloseSession(session);
                }
                // 2013.07.22 FSWW, Ramesh M Added For Add More Details about calling function in Error log file.
                Logging.LogError(ex, "AddOrderFrt : CustomerID-" + companyID + ", OrderID" + OrderID + "\n");
                throw ex;
            }
            catch (Exception ex)
            {
                if (session != null)
                {
                    CloseSession(session);
                }
                // 2013.06.24 FSWW, Ramesh M Added For CR#58976 To Add More Details about calling function in Error log file.
                Logging.LogError(ex, "AddOrderFrt : CustomerID-" + companyID + ", OrderID" + OrderID + "\n");
                throw ex;
            }
            finally
            {
                if (session != null)
                {
                    CloseSession(session);
                }
            }

            return updateStatus;
        }

        /// <summary>
        /// AddPreDutyInspectionDetails
        /// Function to insert the record into Inspection table
        /// </summary>
        /// <param name="sessionID">SessionID</param>
        /// <param name="PreDuty_Inspection">PreDuty_Inspection</param>
        /// <param name="PreDuty_InspectionDateTime">PreDuty_InspectionDateTime</param>
        /// <param name="PreDutyViolation">PreDutyViolation</param>
        /// <param name="PreDutyFaults">PreDutyFaults</param>
        /// <param name="BeginningOdometer">BeginningOdometer</param>
        /// <param name="UserName"></param>
        /// <param name="VehicleCode"></param>
        /// <returns>True = Inserted successfully, False = Failed</returns>
        ///2013.08.01 FSWW, Ramesh M Added For CR#?... PredutyFaults and BeginingOdometer
        ///2013.12.04 FSWW, Ramesh M Added For CR#60646 Addded String UserName,String VehicleCode For logging purpose
        public Boolean AddPreDutyInspectionDetails(Guid sessionID, Boolean PreDuty_Inspection, DateTime? PreDuty_InspectionDateTime, Boolean PreDutyViolation, Int32 PreDutyFaults, Decimal BeginningOdometer, String UserName, String VehicleCode, String VersionNo = "")
        {
            Boolean updateStatus = false;
            ISession session = null;
            List<Inspection> lstInspection = new List<Inspection>();
            try
            {
                //2013.08.01 FSWW, Ramesh M Added For Add if condition for Error log ON/OFF switch control
                if (LoggingStatus == "on")
                {
                }
                session = GetSession();
                if (validateUserSession(sessionID, VersionNo))
                {
                    if (DALMethods.IsPreDutyVoilationSet(sessionID, session))
                    {
                        throw new ApplicationException(ApplicationConstants.Errors.PreDutyInspectionVoilationError);
                    }
                    if (PreDuty_Inspection == true && PreDutyViolation == true)
                    {
                        throw new ApplicationException(ApplicationConstants.Errors.PreDutyInspectionError);
                    }

                    DALMethods.AddPreDutyInspectionDetails(sessionID, PreDuty_Inspection, PreDuty_InspectionDateTime, PreDutyViolation, PreDutyFaults, BeginningOdometer, session, VersionNo);
                    updateStatus = true;
                }
            }
            catch (ApplicationException ex)
            {
                // 2013.07.22 FSWW, Ramesh M Added For Add More Details about calling function in Error log file.
                Logging.LogError(ex, "AddPreDutyInspectionDetails : SessionID-" + sessionID + ",UserName-" + UserName + ",VehicleCode-" + VehicleCode + "\n");
                throw ex;
            }
            catch (Exception ex)
            {
                // 2013.06.24 FSWW, Ramesh M Added For CR#58976 To Add More Details about calling function in Error log file.
                Logging.LogError(ex, "AddPreDutyInspectionDetails : SessionID-" + sessionID + ",UserName-" + UserName + ",VehicleCode-" + VehicleCode + "\n");
                throw ex;
            }
            finally
            {
                if (session != null)
                {
                    CloseSession(session);
                }
            }

            return updateStatus;
        }

        /// <summary>
        /// AddPostDutyInspectionDetails
        /// Function to insert the record into Inspection table
        /// </summary>
        /// <param name="sessionID">SessionID</param>
        /// <param name="PostDuty_Inspection">PostDuty_Inspection</param>
        /// <param name="PostDuty_InspectionDateTime">PostDuty_InspectionDateTime</param>
        /// <param name="PostDutyViolation">PostDutyViolation</param>
        /// <param name="PostDutyFaults">PostDutyFaults</param>
        /// <param name="BeginningOdometer">BeginningOdometer</param>
        /// <param name="EndingOdometer">EndingOdometer</param>
        /// <param name="NextLubrication">NextLubrication</param>
        /// <param name="DriverSignature">DriverSignature</param>
        /// <returns>True = Inserted successfully, False = Failed</returns>
        /// 2013.08.01 FSWW, Ramesh M Added For CR#?... PostdutyFaults,BeginingOdometer,EndingOdometer,NextLubrication,DriverSignature
        public Boolean AddPostDutyInspectionDetails(Guid sessionID, Boolean PostDuty_Inspection, DateTime? PostDuty_InspectionDateTime, Boolean PostDutyViolation, Int32 PostDutyFaults, Decimal BeginningOdometer, Decimal EndingOdometer, Decimal NextLubrication, string DriverSignature, String VersionNo = "")
        {
            Boolean updateStatus = false;
            ISession session = null;
            try
            {
                byte[] image = null;
                //2013.08.01 FSWW, Ramesh M Added For Add if condition for Error log ON/OFF switch control
                if (LoggingStatus == "on")
                {
                }
                session = GetSession();
                if (validateUserSession(sessionID, VersionNo))
                {
                    if (DALMethods.IsPostDutyVoilationSet(sessionID, session, VersionNo))
                    {
                        throw new ApplicationException(ApplicationConstants.Errors.PostDutyInspectionVoilationError);
                    }
                    if (PostDuty_Inspection == true && PostDutyViolation == true)
                    {
                        throw new ApplicationException(ApplicationConstants.Errors.PostDutyInspectionError);
                    }
                    image = System.Convert.FromBase64String(DriverSignature);
                    DALMethods.AddPostDutyInspectionDetails(sessionID, PostDuty_Inspection, PostDuty_InspectionDateTime, PostDutyViolation, PostDutyFaults, BeginningOdometer, EndingOdometer, NextLubrication, image, session, VersionNo);
                    updateStatus = true;
                }
            }
            catch (ApplicationException ex)
            {
                // 2013.07.22 FSWW, Ramesh M Added For  Add More Details about calling function in Error log file.
                Logging.LogError(ex, "AddPostDutyInspectionDetails : SessionID-" + sessionID + "\n");
                throw ex;
            }
            catch (Exception ex)
            {
                // 2013.06.24 FSWW, Ramesh M Added For CR#58976 To Add More Details about calling function in Error log file.
                Logging.LogError(ex, "AddPostDutyInspectionDetails : SessionID-" + sessionID + "\n");
                throw ex;
            }
            finally
            {
                if (session != null)
                {
                    CloseSession(session);
                }
            }

            return updateStatus;
        }

        /// <summary>
        /// AddAdverseConditionDetails
        /// Function to insert the record into AdverseCondition table
        /// </summary>
        /// <param name="sessionID">SessionID</param>
        /// <param name="AdverseCondition">AdvereseCondition</param>
        /// <param name="AdverseConditionReason">AdverseConditionReason</param>
        /// <param name="AdverseConditionDateTime">AdverseConditionDateTime</param>
        /// <returns>True = Inserted successfully, False = Failed</returns>
        public Boolean AddAdverseConditionDetails(Guid sessionID, Boolean AdverseCondition, String AdverseConditionReason, DateTime AdverseConditionDateTime, String VersionNo = "")
        {
            Boolean updateStatus = false;
            ISession session = null;
            try
            {
                //2013.08.01 FSWW, Ramesh M Added For Add if condition for Error log ON/OFF switch control
                if (LoggingStatus == "on")
                {
                }
                session = GetSession();
                if (validateUserSession(sessionID, VersionNo))
                {
                    DALMethods.AddAdverseConditionDetails(sessionID, AdverseCondition, AdverseConditionReason, AdverseConditionDateTime, session, VersionNo);
                    updateStatus = true;
                }
            }
            catch (ApplicationException ex)
            {
                // 2013.07.22 FSWW, Ramesh M Added For Add More Details about calling function in Error log file.
                Logging.LogError(ex, "AddAdverseConditionDetails : SessionID-" + sessionID + "\n");
                throw ex;
            }
            catch (Exception ex)
            {
                // 2013.06.24 FSWW, Ramesh M Added For CR#58976 To Add More Details about calling function in Error log file.
                Logging.LogError(ex, "AddAdverseConditionDetails : SessionID-" + sessionID + "\n");
                throw ex;
            }
            finally
            {
                if (session != null)
                {
                    CloseSession(session);
                }
            }

            return updateStatus;
        }

        /// <summary>
        /// AddSleeperRigTimeDetails
        /// Function to insert the record into SleeperRig table
        /// </summary>
        /// <param name="sessionID">SessionID</param>
        /// <param name="startTime">StartTime</param>
        /// <param name="endTime">EndTime</param>
        /// <returns>True = Inserted successfully, False = Failed</returns>
        public Boolean AddSleeperRigTimeDetails(Guid sessionID, DateTime startTime, DateTime endTime, String VersionNo = "")
        {
            Boolean updateStatus = false;
            ISession session = null;
            try
            {
                //2013.08.01 FSWW, Ramesh M Added For Add if condition for Error log ON/OFF switch control
                if (LoggingStatus == "on")
                {
                }
                session = GetSession();
                if (validateUserSession(sessionID, VersionNo))
                {
                    Int32 loginID = DALMethods.GetUserIDOnSession(sessionID, session, VersionNo);
                    DALMethods.AddSleeperRigTimeDetails(sessionID, Guid.NewGuid(), startTime, endTime, loginID, session, VersionNo);
                    //2013.10.18 FSWW, Ramesh M Added For CR#60839.. To update SleeperRig in gps History Table 
                    DALMethods.UpdateSleeperRigTimeToGpsHistory(sessionID, startTime, endTime, loginID, session, VersionNo);
                    updateStatus = true;
                }
            }
            catch (ApplicationException ex)
            {
                // 2013.07.22 FSWW, Ramesh M Added For Add More Details about calling function in Error log file.
                Logging.LogError(ex, "AddSleeperRigTimeDetails : SessionID-" + sessionID + "\n");
                throw ex;
            }
            catch (Exception ex)
            {
                // 2013.06.24 FSWW, Ramesh M Added For CR#58976 To Add More Details about calling function in Error log file.
                Logging.LogError(ex, "AddSleeperRigTimeDetails : SessionID-" + sessionID + "\n");
                throw ex;
            }
            finally
            {
                if (session != null)
                {
                    CloseSession(session);
                }
            }

            return updateStatus;
        }

        //2013.12.19 FSWW, Ramesh M Added For CR#61549 added String DeviceID, DateTime GMT
        // 2014.02.10 Ramesh M Added TrailerCode For CR#62211
        // 2015.02.02 Madhu Added For CR#66160 For Add App Version No in the login session table for every login sessions
        /// <summary>
        /// AddLoginSession
        /// Function to insert the record into LoginSession table
        /// </summary>
        /// <param name="UserName">User name</param>
        /// <param name="password">Password</param>
        /// <param name="vehicleID">Vehicle ID</param>
        /// <param name="companyID">Company ID</param>
        /// <param name="deviceToken">Device Token</param> 
        /// <param name="loginTime">LoginTime</param>
        /// <param name="deviceTime">DeviceTime</param>
        /// <returns>SessionID</returns>
        public Guid AddLoginSession(String UserName, String password, String vehicleID, String companyID, String deviceToken, DateTime loginTime, DateTime deviceTime, String DeviceID, DateTime GMT, String TrailerCode, String VersionNo, String IOSVersion = "")
        {
            TimeSpan span = deviceTime.Subtract(loginTime);
            DateTime dateTime = DateTime.Now.Subtract(span);
            return validateUser(UserName, vehicleID, password, companyID, deviceToken, loginTime, dateTime, true, DeviceID, GMT, TrailerCode, IOSVersion == null ? "" : IOSVersion, VersionNo);
        }

        /// <summary>
        /// Add Truck Fueling Details 
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="sessionID"></param>
        /// <param name="companyID"></param>
        /// <param name="vehicleID"></param>
        /// <param name="driverID"></param>
        /// <param name="deviceDateTime"></param>
        /// <param name="odometer"></param>
        /// <param name="qty"></param>
        /// <param name="fuelType"></param>
        /// <param name="latitude"></param>
        /// <param name="longitude"></param>
        /// <param name="state"></param>
        /// <param name="fuelTaxPaid"></param>
        /// <param name="fuelingLocation"></param>
        /// <param name="MPG"></param>
        public void AddTruckFuelingDetails(String userName, String password, Guid sessionID, String companyID, String vehicleID, String driverID, String deviceDateTime, Decimal odometer, Decimal qty, String fuelType, String latitude, String longitude, String state, Boolean fuelTaxPaid, String fuelingLocation, Decimal MPG, String VersionNo = "")
        {
            ISession session = null;

            try
            {
                //2013.08.01 FSWW, Ramesh M Added For Add if condition for Error log ON/OFF switch control
                if (LoggingStatus == "on")
                {
                }
                session = GetSession();
                DALMethods.AddTruckFuelingDetails(userName, password, sessionID, companyID, vehicleID, driverID, deviceDateTime, odometer, qty, fuelType, latitude, longitude, state, fuelTaxPaid, fuelingLocation, MPG, session, VersionNo);
            }
            catch (ApplicationException ex)
            {
                // 2013.07.22 FSWW, Ramesh M Added For Add More Details about calling function in Error log file.
                Logging.LogError(ex, "AddTruckFuelingDetails : CustomerID-" + companyID + ", SessionID-" + sessionID + "\n");
                throw ex;
            }
            catch (Exception ex)
            {
                // 2013.06.24 FSWW, Ramesh M Added For CR#58976 To Add More Details about calling function in Error log file.
                Logging.LogError(ex, "AddTruckFuelingDetails : CustomerID-" + companyID + ", SessionID-" + sessionID + "\n");
                throw ex;
            }
            finally
            {
                if (session != null)
                {
                    CloseSession(session);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="OrderNo"></param>
        /// <param name="LoadNo"></param>
        /// <param name="OrderItemId"></param>
        /// <param name="PickedBy"></param>
        /// <param name="CustomerId"></param>
        /// <param name="Status"></param>

        public void AddOrUpdateOrderPickingDetails(String OrderNo, String LoadNo, String OrderItemId, Int32 PickedBy, String CustomerId, String Status, String VersionNo = "")
        {
            ISession session = null;

            try
            {
                //2013.08.01 FSWW, Ramesh M Added For Add if condition for Error log ON/OFF switch control
                if (LoggingStatus == "on")
                {
                }
                session = GetSession();
                DALMethods.AddOrUpdateOrderPickingDetails(OrderNo, LoadNo, OrderItemId, PickedBy, CustomerId, Status, session, VersionNo);
            }
            catch (ApplicationException ex)
            {
                // 2013.07.22 FSWW, Ramesh M Added For Add More Details about calling function in Error log file.
                Logging.LogError(ex, "AddOrUpdateOrderPickingDetails : CustomerID-" + CustomerId + "OrderNo" + OrderNo + "\n");
                throw ex;
            }
            catch (Exception ex)
            {
                // 2013.06.24 FSWW, Ramesh M Added For CR#58976 To Add More Details about calling function in Error log file.
                Logging.LogError(ex, "AddOrUpdateOrderPickingDetails : CustomerID-" + CustomerId + "OrderNo" + OrderNo + "\n");
                throw ex;
            }
            finally
            {
                if (session != null)
                {
                    CloseSession(session);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="OrderNo"></param>
        /// <param name="LoadNo"></param>
        /// <param name="OrderItemId"></param>
        /// <param name="PickedBy"></param>
        /// <param name="CustomerId"></param>
        /// <param name="Status"></param>

        public void DeleteOrderPickingDetails(String OrderNo, String LoadNo, String OrderItemId, Int32 PickedBy, String CustomerId, String Status, String VersionNo = "")
        {
            ISession session = null;

            try
            {
                //2013.08.01 FSWW, Ramesh M Added For Add if condition for Error log ON/OFF switch control
                if (LoggingStatus == "on")
                {
                }
                session = GetSession();
                DALMethods.DeleteOrderPickingDetails(OrderNo, LoadNo, OrderItemId, PickedBy, CustomerId, Status, session, VersionNo);
            }
            catch (ApplicationException ex)
            {
                // 2013.07.22 FSWW, Ramesh M Added For  Add More Details about calling function in Error log file.
                Logging.LogError(ex, "DeleteOrderPickingDetails : CustomerID-" + CustomerId + "OrderNo" + OrderNo + "\n");
                throw ex;
            }
            catch (Exception ex)
            {
                // 2013.06.24 FSWW, Ramesh M Added For CR#58976 To Add More Details about calling function in Error log file.
                Logging.LogError(ex, "DeleteOrderPickingDetails : CustomerID-" + CustomerId + "OrderNo" + OrderNo + "\n");
                throw ex;
            }
            finally
            {
                if (session != null)
                {
                    CloseSession(session);
                }
            }
        }

        /// <summary>
        /// AddSignatureImage
        /// Function to insert recoed in Add SignatureImage
        /// <param name="sessionID">session ID</param>
        /// <param name="orderID">orderID</param>
        /// <param name="signatureImage">signature Image</param>
        /// <param name="signatureDateTime">signatureDateTime</param>
        /// </summary>
        ///  public Boolean AddSignatureImage(Guid sessionID, Guid orderID, string signatureImage, DateTime signatureDateTime)
        public Boolean ç(Guid sessionID, Guid orderID, string signatureImage, DateTime signatureDateTime)
        {
            Boolean updateStatus = false;
            ISession session = null;
            try
            {
                //2013.08.01 FSWW, Ramesh M Added For Add if condition for Error log ON/OFF switch control
                if (LoggingStatus == "on")
                {
                }
                session = GetSession();
                if (validateUserSession(sessionID))
                {
                    byte[] image = null;
                    try
                    {
                        Int32 loginID = DALMethods.GetUserIDOnSession(sessionID, session);
                        if (!String.IsNullOrWhiteSpace(signatureImage))
                        {
                            image = System.Convert.FromBase64String(signatureImage);
                            DALMethods.UpdateSignatureImage(orderID, image, signatureDateTime, loginID, null, session);
                        }
                    }
                    catch
                    {
                        image = null;
                    }
                }
                updateStatus = true;
            }
            catch (ApplicationException ex)
            {
                // 2013.07.22 FSWW, Ramesh M Added For Add More Details about calling function in Error log file.
                Logging.LogError(ex, "ç : SessionID-" + sessionID + "OrderID" + orderID + "\n");
                throw ex;
            }
            catch (Exception ex)
            {
                // 2013.06.24 FSWW, Ramesh M Added For CR#58976 To Add More Details about calling function in Error log file.
                Logging.LogError(ex, "ç : SessionID-" + sessionID + "OrderID" + orderID + "\n");
                throw ex;
            }
            finally
            {
                if (session != null)
                {
                    CloseSession(session);
                }
            }

            return updateStatus;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sessionID"></param>
        /// <param name="orderID"></param>
        /// <param name="signatureImage"></param>
        /// <param name="signatureDateTime"></param>
        /// <returns></returns>
        public Boolean AddSignatureImage(Guid sessionID, Guid orderID, string signatureImage, DateTime signatureDateTime, String VersionNo = "")
        {
            Boolean updateStatus = false;
            ISession session = null;
            try
            {
                //2013.08.01 FSWW, Ramesh M Added For Add if condition for Error log ON/OFF switch control
                if (LoggingStatus == "on")
                {
                }
                session = GetSession();
                if (validateUserSession(sessionID, VersionNo))
                {
                    byte[] image = null;
                    try
                    {
                        Int32 loginID = DALMethods.GetUserIDOnSession(sessionID, session, VersionNo);
                        if (!String.IsNullOrWhiteSpace(signatureImage))
                        {
                            image = System.Convert.FromBase64String(signatureImage);
                            DALMethods.UpdateSignatureImage(orderID, image, signatureDateTime, loginID, null, session, VersionNo);
                        }
                    }
                    catch
                    {
                        image = null;
                    }
                }
                updateStatus = true;
            }
            catch (ApplicationException ex)
            {
                // 2013.07.22 FSWW, Ramesh M Added For  Add More Details about calling function in Error log file.
                Logging.LogError(ex, "AddSignatureImage : SessionID-" + sessionID + "OrderID" + orderID + "\n");
                throw ex;
            }
            catch (Exception ex)
            {
                // 2013.06.24 FSWW, Ramesh M Added For CR#58976 To Add More Details about calling function in Error log file.
                Logging.LogError(ex, "AddSignatureImage : SessionID-" + sessionID + "OrderID" + orderID + "\n");
                throw ex;
            }
            finally
            {
                if (session != null)
                {
                    CloseSession(session);
                }
            }

            return updateStatus;
        }

        //  2013.08.12 FSWW, Ramesh M Added For CR#...? For Package Lube shippment Details
        /// <summary>
        /// AddPackageLubeShipmentDetails
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="password"></param>
        /// <param name="vehicleID"></param>
        /// <param name="companyID"></param>
        /// <param name="loadID"></param>
        /// <param name="OrderedQty"></param>
        /// <param name="deviceID"></param>
        /// <param name="deviceTime"></param>
        /// <param name="DriverName"></param>
        /// <returns></returns>
        //public Boolean AddPackageLubeShipmentDetails(String UserName, String password, String vehicleID, String companyID, Guid loadID, Decimal OrderedQty, String deviceID, DateTime deviceTime, String DriverName)
        //{
        //    Boolean updateStatus = false;
        //    ISession session = null;
        //    try
        //    {
        //        //2013.08.01 FSWW, Ramesh M Added For Add if condition for Error log ON/OFF switch control
        //        if (LoggingStatus == "on")
        //        {
        //            //2013.07.22 FSWW, Ramesh M Added For Add More Details about calling function in Error log file
        //            Logging.LogInfoAboutCallingFunction("Function Called:- AddShipmentDetails ; " + "CustomerID-" + companyID + "LoadID" + loadID);
        //        }
        //        session = GetSession();
        //        if (ValidateUserLogin(UserName, password, companyID, vehicleID))
        //        {
        //            Int32 loginID = DALMethods.GetUserID(UserName, companyID, session);
        //            DALMethods.UpdateUndispatched(0, loadID, session);
        //            DALMethods.AddPackageShippmentDetail(vehicleID, loginID, companyID, loadID, OrderedQty, deviceID, deviceTime, DriverName, session);
        //            updateStatus = true;
        //        }
        //        CloseSession(session);
        //    }
        //    catch (ApplicationException ex)
        //    {
        //        if (session != null)
        //        {
        //            CloseSession(session);
        //        }
        //        // 2013.07.22 FSWW, Ramesh M Added For Add More Details about calling function in Error log file.
        //        Logging.LogError(ex, "CustomerID-" + companyID + "LoadID" + loadID + "\n");
        //        throw ex;
        //    }
        //    catch (Exception ex)
        //    {
        //        if (session != null)
        //        {
        //            CloseSession(session);
        //        }
        //        // 2013.06.24 FSWW, Ramesh M Added For CR#58976 To Add More Details about calling function in Error log file.
        //        Logging.LogError(ex, "CustomerID-" + companyID + "LoadID" + loadID + "\n");
        //        throw ex;
        //    }
        //    finally
        //    {
        //        if (session != null)
        //        {
        //            CloseSession(session);
        //        }
        //    }

        //    return updateStatus;
        //}


        ///  2013.08.27 FSWW, Ramesh M Added For CR#...? For InspectionDetails
        public Boolean AddInspectionDetails(Guid sessionID, Int32 InspectionTypeID, String InspectionElementsID, String VersionNo = "")
        {
            Boolean updateStatus = false;
            ISession session = null;
            try
            {
                //2013.08.01 FSWW, Ramesh M Added For Add if condition for Error log ON/OFF switch control
                if (LoggingStatus == "on")
                {
                }
                session = GetSession();
                if (validateUserSession(sessionID, VersionNo))
                {
                    DALMethods.AddInspectionDetails(sessionID, InspectionTypeID, InspectionElementsID, session, VersionNo);
                    updateStatus = true;
                }
            }
            catch (ApplicationException ex)
            {
                // 2013.07.22 FSWW, Ramesh M Added For  Add More Details about calling function in Error log file.
                Logging.LogError(ex, "AddInspectionDetails : SessionID-" + sessionID + "\n");
                throw ex;
            }
            catch (Exception ex)
            {
                // 2013.06.24 FSWW, Ramesh M Added For CR#58976 To Add More Details about calling function in Error log file.
                Logging.LogError(ex, "AddInspectionDetails : SessionID-" + sessionID + "\n");
                throw ex;
            }
            finally
            {
                if (session != null)
                {
                    CloseSession(session);
                }
            }

            return updateStatus;
        }

        //  2014.02.06  Ramesh M Added For CR#62166 For DOT OverRide Details
        //  2014.02.10  Ramesh M Added For CR#62210 For DOT OverRideReason Details
        /// <summary>
        /// 
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="password"></param>
        /// <param name="vehicleID"></param>
        /// <param name="companyID"></param>
        /// <param name="sessionID"></param>
        /// <param name="StartDate"></param>
        /// <param name="EndDate"></param>
        /// <param name="OverRideType"></param>
        /// <param name="VersionNo"></param>
        /// <returns></returns>
        public Boolean AddDOTOverRideDetails(String UserName, String password, String vehicleID, String companyID, Guid sessionID, DateTime StartDate, DateTime EndDate, String OverRideType, String OverRideReason, String VersionNo = "")
        {
            Boolean InsertStatus = false;
            ISession session = null;
            try
            {
                //2013.08.01 FSWW, Ramesh M Added For Add if condition for Error log ON/OFF switch control
                if (LoggingStatus == "on")
                {
                }
                session = GetSession();
                if (ValidateUserLogin(UserName, password, companyID, vehicleID, VersionNo))
                {
                    DALMethods.AddDOTOverRide(sessionID, StartDate, EndDate, OverRideType, OverRideReason, session, VersionNo);

                    InsertStatus = true;
                }
                CloseSession(session);
            }
            catch (Exception ex)
            {
                if (session != null)
                {
                    CloseSession(session);
                }
                // 2013.06.24 FSWW, Ramesh M Added For CR#58976 To Add More Details about calling function in Error log file.
                Logging.LogError(ex, "AddDOTOverRideDetails : CustomerID-" + companyID + ", sessionID" + sessionID + "\n");
                throw ex;
            }
            finally
            {
                if (session != null)
                {
                    CloseSession(session);
                }
            }

            return InsertStatus;
        }

        #endregion Add Details


        //#region GetBOLDetails

        public List<BolHdr> GetBOLDetails(String UserName, String password, String vehicleID, String companyID, Guid loadID, String VersionNo = "")
        {
            List<BolHdr> lstBolHdrs = new List<BolHdr>();
            ISession session = null;
            try
            {
                //2013.08.01 FSWW, Ramesh M Added For Add if condition for Error log ON/OFF switch control
                if (LoggingStatus == "on")
                {
                }
                session = GetSession();
                if (ValidateUserLogin(UserName, password, companyID, vehicleID, VersionNo))
                {
                    lstBolHdrs = DALMethods.GetBOLDetails(companyID, loadID, session, VersionNo);
                }
                CloseSession(session);

            }
            catch (ApplicationException ex)
            {
                if (session != null)
                {
                    CloseSession(session);
                }
                // 2013.07.22 FSWW, Ramesh M Added For Add More Details about calling function in Error log file.
                Logging.LogError(ex, "GetBOLDetails : CustomerID-" + companyID + ", LoadID-" + loadID + "\n");
                throw ex;
            }
            catch (Exception ex)
            {
                if (session != null)
                {
                    CloseSession(session);
                }
                // 2013.06.24 FSWW, Ramesh M Added For CR#58976 To Add More Details about calling function in Error log file.
                Logging.LogError(ex, "GetBOLDetails : CustomerID-" + companyID + ", LoadID-" + loadID + "\n");
                throw ex;
            }
            finally
            {
                if (session != null)
                {
                    CloseSession(session);
                }
            }

            return lstBolHdrs;
        }

        /// <summary>
        /// GetDataToDeleteOldDataFromApp
        /// Function to get records to Delete Old Data From App table
        /// </summary>
        /// <param name="UserName">User name</param>
        /// <param name="password">Password</param>
        /// <param name="vehicleID">Vehicle ID</param>
        /// <param name="companyID">Company ID</param>
        /// <returns>string</returns>
        public string GetDataToDeleteOldDataFromApp(String UserName, String password, String vehicleID, String companyID, String VersionNo = "")
        {
            string getDataToDeleteOldDataFromApp = string.Empty;
            ISession session = null;
            try
            {
                if (UserName != "" && password != "")
                {
                    if (LoggingStatus == "on")
                    {
                    }
                    session = GetSession();
                    if (ValidateUserLogin(UserName, password, companyID, vehicleID, VersionNo))
                    {
                        getDataToDeleteOldDataFromApp = DALMethods.GetDataToDeleteOldDataFromApp(companyID, session, VersionNo);
                    }
                    CloseSession(session);
                }
                else
                {
                    getDataToDeleteOldDataFromApp = "0,0";
                }
            }
            catch (ApplicationException ex)
            {
                if (session != null)
                {
                    CloseSession(session);
                }
                //Logging.LogError(ex, "GetDataToDeleteOldDataFromApp : CustomerID-" + companyID + "\n");
                Logging.LogError(ex, "GetDataToDeleteOldDataFromApp : CustomerID-" + companyID + ", UserName-" + UserName + ", Password-"+ password + ",vehicleID-" + vehicleID + "\n");
                throw ex;
            }
            catch (Exception ex)
            {
                if (session != null)
                {
                    CloseSession(session);
                }
                //Logging.LogError(ex, "GetDataToDeleteOldDataFromApp : CustomerID-" + companyID + "\n");
                Logging.LogError(ex, "GetDataToDeleteOldDataFromApp : CustomerID-" + companyID + ", UserName-" + UserName + ", Password-" + password + ",vehicleID-" + vehicleID + "\n");
                throw ex;
            }
            finally
            {
                if (session != null)
                {
                    CloseSession(session);
                }
            }

            return getDataToDeleteOldDataFromApp;
        }

        //#endregion

        #region Logout Details

        ///// <summary>
        ///// Logout
        ///// Function to logout user and end user login session
        ///// </summary>
        ///// <param name="sessionID">Session ID</param>
        ///// <param name="logoutTime">Logout Time</param>
        ///// <returns>True = User logout successfull, False = User logout Failed</returns>
        //public Boolean Logout(Guid sessionID, DateTime logoutTime)
        //{
        //    Boolean logoutStatus = false;
        //    ISession session = null;
        //    if (validateUserSession(sessionID))
        //    {
        //        try
        //        {
        //            //2013.08.01 FSWW, Ramesh M Added For Add if condition for Error log ON/OFF switch control
        //            if (LoggingStatus == "on")
        //            {
        //                //2013.07.22 FSWW, Ramesh M Added For Add More Details about calling function in Error log file
        //                Logging.LogInfoAboutCallingFunction("Function Called:- Logout ; " + "SessionID-" + sessionID);
        //            }
        //            session = GetSession();

        //            // Calculate Driver Dots for this session
        //            DALMethods.UpdateLoginHistory(sessionID, logoutTime, session);
        //            DALMethods.removeLoginSession(sessionID, session);
        //            logoutStatus = true;
        //        }
        //        catch (Exception ex)
        //        {
        //            // 2013.06.24 FSWW, Ramesh M Added For CR#58976 To Add More Details about calling function in Error log file.
        //            Logging.LogError(ex, "SessionID-" + sessionID +  "\n");
        //        }
        //        finally
        //        {
        //            if (session != null)
        //            {
        //                CloseSession(session);
        //            }
        //        }
        //    }

        //    return logoutStatus;
        //}

        /// <summary>
        /// Logout
        /// Function to logout user and end user login session
        /// </summary>
        /// <param name="sessionID">Session ID</param>
        /// <param name="logoutTime">Logout Time</param>
        /// <param name="CalledBy">CalledBy</param>
        /// <returns>True = User logout successfull, False = User logout Failed</returns>
        //2013.09.11 FSWW, Ramesh M Added For CR#...? For Logout Called By Function Identification
        public Boolean Logout(Guid sessionID, DateTime logoutTime, String CalledBy, String VersionNo = "")
        {
            Boolean logoutStatus = false;
            ISession session = null;
            if (validateUserSession(sessionID, VersionNo))
            {
                try
                {
                    //2013.08.01 FSWW, Ramesh M Added For Add if condition for Error log ON/OFF switch control
                    if (LoggingStatus == "on")
                    {
                    }
                    session = GetSession();

                    // Calculate Driver Dots for this session
                    Logging.WriteLog(string.Format("Before UpdateLoginHistory -sessionID-{0},logoutTime-{1},session-{2},VersionNo-{3} ", sessionID, logoutTime, session, VersionNo), EventLogEntryType.Information);
                    DALMethods.UpdateLoginHistory(sessionID, logoutTime, session, VersionNo);
                    Logging.WriteLog("After UpdateLoginHistory", EventLogEntryType.Information);

                    DALMethods.removeLoginSession(sessionID, session, VersionNo);

                    logoutStatus = true;
                }
                catch (Exception ex)
                {
                    // 2013.06.24 FSWW, Ramesh M Added For CR#58976 To Add More Details about calling function in Error log file.
                    Logging.LogError(ex, "Logout : SessionID-" + sessionID + "\n");
                }
                finally
                {
                    if (session != null)
                    {
                        CloseSession(session);
                    }
                }
            }

            return logoutStatus;
        }

        #endregion Logout Details

        #region App Exception Report

        /// <summary>
        /// To log App exception
        /// </summary>
        /// <param name="sessionID"></param>
        /// <param name="errorMessage"></param>
        public void AppExceptionReport(Guid sessionID, String errorMessage, String VersionNo = "")
        {
            //  06-11-2013 FSWW Ramesh M added For CR#? The 'ExceptionReportLogWrite' value added in configuration file.
            if (ConfigurationManager.AppSettings["ExceptionReportLogWrite"].ToString().ToLower() == "true")
            {
                Logging.WriteLog("App Exception Report - " + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString() + " - " + sessionID.ToString() + " - " + errorMessage, System.Diagnostics.EventLogEntryType.Error);
            }
        }

        #endregion

        // 2014.03.18  Ramesh M Added For CR#62322 added  Version testing method
        #region TestingPurpose
        public List<VersionTest> GetVersionTestingData(Guid sessionID, String VersionNo = "", DateTime? startTime = null, DateTime? endTime = null)
        {
            ISession session = null;
            List<VersionTest> lstVersionTest = new List<VersionTest>();
            try
            {
                session = GetSession();
                if (validateUserSession(sessionID))
                {
                    lstVersionTest = DALMethods.VersionTestSampleData(sessionID, session, VersionNo, startTime, endTime);
                }
                CloseSession(session);
            }
            catch (ApplicationException ex)
            {
                if (session != null)
                {
                    CloseSession(session);
                }
                throw ex;
            }
            catch (Exception ex)
            {
                if (session != null)
                {
                    CloseSession(session);
                }
                //Logging.LogError(ex);
                throw ex;
            }
            return lstVersionTest;
        }

        #endregion

        #region TankWagon Details


        // 06-26-2014  MadhuVenkat k - Added for CR 64058  - For Add orderDispatchHistory 
        /// <summary>
        /// AddOrderDipatchHistory
        /// </summary>
        /// <param name="SysTrxNo">SysTrxNo</param>
        /// <param name="companyID">companyID</param>
        /// <param name="password">password</param>
        /// <param name="DefDriverID">DefDriverID</param>
        /// <param name="DefVehicleID">DefVehicleID</param>
        /// <param name="OldDriverID">OldDriverID</param>
        /// <param name="OldVehicleID">OldVehicleID</param>
        /// <returns>True = Inserted successfully, False = Faile</returns>
        public Boolean AddVehicleCompartment(String companyID, String password, Int32 VehicleID, Int32 CompartmentID, String Code, Int32 Capacity, String VersionNo = "")
        {
            Boolean status = false;
            ISession session = null;
            Boolean NeedUpdate = true;
            try
            {
                session = GetSession();
                string IsEnabledTW = DALMethods.IsEnabledTankwagon(companyID, session, VersionNo);
                if (IsEnabledTW.ToUpper().Trim() == "Y")
                {
                    //2013.08.01 FSWW, Ramesh M Added For Add if condition for Error log ON/OFF switch control
                    if (LoggingStatus == "on")
                    {
                    }
                    //session = GetSession();
                    if (ValidateCustomerLogin(companyID, password, VersionNo))
                    {

                        DALMethods.AddVehicleCompartment(VehicleID, companyID, CompartmentID, Code, Capacity, session, VersionNo = "");

                        status = true;
                    }
                }
                CloseSession(session);

            }
            catch (ApplicationException ex)
            {
                if (session != null)
                {
                    CloseSession(session);
                }
                // 2013.07.22 FSWW, Ramesh M Added For Add More Details about calling function in Error log file.
                Logging.LogError(ex, "AddVehicleCompartment : CustomerID-" + companyID + ", VehicleID-" + VehicleID + "\n");
                throw ex;
            }
            catch (Exception ex)
            {
                if (session != null)
                {
                    CloseSession(session);
                }
                // 2013.06.24 FSWW, Ramesh M Added For CR#58976 To Add More Details about calling function in Error log file.
                Logging.LogError(ex, "AddVehicleCompartment : CustomerID-" + companyID + ", VehicleID-" + VehicleID + "\n");
                throw ex;
            }
            finally
            {
                if (session != null)
                {
                    CloseSession(session);
                }
            }

            return status;
        }

        // 2013.08.27 FSWW, Ramesh M Added For CR#?.. To Get Inspection ElemetsID
        // 09-09-2014  CR#64208, Madhu, Add Modified date to GetInspectionElementsData
        /// <summary>
        /// GetVehicleCompartment
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="password"></param>
        /// <param name="vehicleID"></param>
        /// <param name="companyID"></param>
        /// <returns></returns>

        public List<VehicleCompartment> GetVehicleCompartment(String UserName, String password, String vehicleID, Int32 UpdatedBy, String SessionID, String companyID, String VersionNo = "")
        {
            List<VehicleCompartment> lstVehicleCompartmentDetails = new List<VehicleCompartment>();
            //Vehicle veh = new Vehicle();
            //veh.VehicleCode = "test";
            //ve.BolCompartment.Add(veh);
            //lstVehicleCompartmentDetails.Add(ve);

            ISession session = null;
            try
            {
                session = GetSession();
                string IsEnabledTW = DALMethods.IsEnabledTankwagon(companyID, session, VersionNo);
                if (IsEnabledTW.ToUpper().Trim() == "Y")
                {
                    //2013.08.01 FSWW, Ramesh M Added For Add if condition for Error log ON/OFF switch control
                    if (LoggingStatus == "on")
                    {
                    }
                    //session = GetSession();
                    if (ValidateUserLogin(UserName, password, companyID, vehicleID, VersionNo))
                    {
                        int newvehicleID = DALMethods.GetVehicleID(vehicleID, companyID, session, "");
                        lstVehicleCompartmentDetails = DALMethods.GetVehicleCompartment(companyID, newvehicleID, session, VersionNo);
                        Guid delSessionID = Guid.Parse(SessionID);
                        int? deliverCount = DALMethods.GetDeliveryCount(delSessionID, session, VersionNo);
                        string IsDeliverd = "N";
                        if (deliverCount != null && deliverCount > 0)
                        {
                            IsDeliverd = "Y";
                        }
                        for (int i = 0; i < lstVehicleCompartmentDetails.Count; i++)
                        {
                            VehicleCompartment ve = new VehicleCompartment();
                            ve.BolCompartment = DALMethods.GetBolCompartment(UpdatedBy, lstVehicleCompartmentDetails[i].CompartmentID, SessionID, session, VersionNo);
                            lstVehicleCompartmentDetails[i].BolCompartment = new List<BOLCompartments>();
                            for (int j = 0; j < ve.BolCompartment.Count; j++)
                            {
                                BOLCompartments be = new BOLCompartments();
                                be.BOLHdrID = ve.BolCompartment[j].BOLHdrID;
                                be.BOLItemID = ve.BolCompartment[j].BOLItemID;
                                be.BOLDatetime = ve.BolCompartment[j].BOLDatetime;
                                be.BOLNo = ve.BolCompartment[j].BOLNo;
                                be.CompartmentID = ve.BolCompartment[j].CompartmentID;
                                be.SupplierCode = ve.BolCompartment[j].SupplierCode;
                                be.SupplyPointCode = ve.BolCompartment[j].SupplyPointCode;
                                be.ProdCode = ve.BolCompartment[j].ProdCode;
                                be.GrossQty = ve.BolCompartment[j].GrossQty;
                                be.OrderedQty = ve.BolCompartment[j].OrderedQty;
                                be.NetQty = ve.BolCompartment[j].NetQty;
                                be.SystrxNo = ve.BolCompartment[j].SystrxNo;
                                be.SystrxLine = ve.BolCompartment[j].SystrxLine;
                                if (!string.IsNullOrEmpty(ve.BolCompartment[j].Notes))
                                    be.Notes = ve.BolCompartment[j].Notes;
                                else
                                    be.Notes = "";
                                be.AvailbleQty = ve.BolCompartment[j].AvailbleQty;
                                lstVehicleCompartmentDetails[i].BolCompartment.Add(be);
                            }
                            lstVehicleCompartmentDetails[i].IsAnyDelivered = IsDeliverd;

                        }

                    }
                }
                CloseSession(session);

            }
            catch (ApplicationException ex)
            {
                if (session != null)
                {
                    CloseSession(session);
                }
                // 2013.07.22 FSWW, Ramesh M Added For Add More Details about calling function in Error log file.
                Logging.LogError(ex, "GetVehicleCompartment : CustomerID-" + companyID + "\n");
                throw ex;
            }
            catch (Exception ex)
            {
                if (session != null)
                {
                    CloseSession(session);
                }
                // 2013.06.24 FSWW, Ramesh M Added For CR#58976 To Add More Details about calling function in Error log file.
                Logging.LogError(ex, "GetVehicleCompartment : CustomerID-" + companyID + "\n");
                throw ex;
            }
            finally
            {
                if (session != null)
                {
                    CloseSession(session);
                }
            }
            return lstVehicleCompartmentDetails;

        }


        // 06-26-2014  MadhuVenkat k - Added for CR 64058  - For Add orderDispatchHistory 
        /// <summary>
        /// AddOrderDipatchHistory
        /// </summary>
        /// <param name="SysTrxNo">SysTrxNo</param>
        /// <param name="companyID">companyID</param>
        /// <param name="password">password</param>
        /// <param name="DefDriverID">DefDriverID</param>
        /// <param name="DefVehicleID">DefVehicleID</param>
        /// <param name="OldDriverID">OldDriverID</param>
        /// <param name="OldVehicleID">OldVehicleID</param>
        /// <returns>True = Inserted successfully, False = Faile</returns>
        public Boolean AddBOLHdrWagon(String UserName, String password, String companyID, String vehicleID, String BOLNo, DateTime BOLDatetime, String SupplierCode, String SupplyPointCode, Int32 UpdatedBy, String VersionNo = "")
        {
            Boolean status = false;
            ISession session = null;
            try
            {
                session = GetSession();
                string IsEnabledTW = DALMethods.IsEnabledTankwagon(companyID, session, VersionNo);
                if (IsEnabledTW.ToUpper().Trim() == "Y")
                {
                    //2013.08.01 FSWW, Ramesh M Added For Add if condition for Error log ON/OFF switch control
                    if (LoggingStatus == "on")
                    {
                    }
                    //session = GetSession();
                    if (ValidateUserLogin(UserName, password, companyID, vehicleID, VersionNo))
                    {
                        Guid id = Guid.NewGuid();
                        //DALMethods.AddBOLHdrWagon(id,BOLNo, BOLDatetime, SupplierCode, SupplyPointCode, UpdatedBy, session, VersionNo = "");

                        status = true;
                    }
                }
                CloseSession(session);

            }
            catch (ApplicationException ex)
            {
                if (session != null)
                {
                    CloseSession(session);
                }
                // 2013.07.22 FSWW, Ramesh M Added For Add More Details about calling function in Error log file.
                Logging.LogError(ex, "AddBOLHdrWagon : CustomerID-" + companyID + ", VehicleID-" + BOLNo + "\n");
                throw ex;
            }
            catch (Exception ex)
            {
                if (session != null)
                {
                    CloseSession(session);
                }
                // 2013.06.24 FSWW, Ramesh M Added For CR#58976 To Add More Details about calling function in Error log file.
                Logging.LogError(ex, "AddBOLHdrWagon : CustomerID-" + companyID + ", VehicleID-" + BOLNo + "\n");
                throw ex;
            }
            finally
            {
                if (session != null)
                {
                    CloseSession(session);
                }
            }

            return status;
        }



        // 06-26-2014  MadhuVenkat k - Added for CR 64058  - For Add orderDispatchHistory 
        /// <summary>
        /// AddBOLHdrWagon
        /// </summary>
        /// <param name="SysTrxNo">SysTrxNo</param>
        /// <param name="companyID">companyID</param>
        /// <param name="password">password</param>
        /// <param name="DefDriverID">DefDriverID</param>
        /// <param name="DefVehicleID">DefVehicleID</param>
        /// <param name="OldDriverID">OldDriverID</param>
        /// <param name="OldVehicleID">OldVehicleID</param>
        /// <returns>True = Inserted successfully, False = Faile</returns>
        public Boolean AddBOLItemWagon(String UserName, String password, String companyID, String vehicleID, Guid BOLHdrID, Decimal SystrxNo, Int32 SystrxLine, Int32 CompartmentID, String ProdCode, Decimal GrossQty, Decimal NetQty, Decimal OrderedQty, String Notes, String VersionNo = "")
        {
            Boolean status = false;
            ISession session = null;
            try
            {
                session = GetSession();
                string IsEnabledTW = DALMethods.IsEnabledTankwagon(companyID, session, VersionNo);
                if (IsEnabledTW.ToUpper().Trim() == "Y")
                {
                    //2013.08.01 FSWW, Ramesh M Added For Add if condition for Error log ON/OFF switch control
                    if (LoggingStatus == "on")
                    {
                    }
                    //session = GetSession();
                    int newvehicleID;
                    newvehicleID = DALMethods.GetVehicleID(vehicleID, companyID, session, "");
                    if (ValidateUserLogin(UserName, password, companyID, vehicleID, VersionNo))
                    {
                        // AddBOLItemWagon(Guid BOLHdrID, Decimal SystrxNo, Int32 SystrxLine, Int32 CompartmentID, String ProdCode,Decimal GrossQty,Decimal NetQty,Decimal OrderedQty, String Notes, ISession session, String VersionNo = "")
                        DALMethods.AddBOLItemWagon(BOLHdrID, SystrxNo, SystrxLine, CompartmentID, ProdCode, GrossQty, NetQty, OrderedQty, Notes, newvehicleID, session, VersionNo = "");

                        status = true;
                    }
                }
                CloseSession(session);

            }
            catch (ApplicationException ex)
            {
                if (session != null)
                {
                    CloseSession(session);
                }
                // 2013.07.22 FSWW, Ramesh M Added For Add More Details about calling function in Error log file.
                Logging.LogError(ex, "AddBOLItemWagon : CustomerID-" + companyID + ", BOLHdrID-" + BOLHdrID + "\n");
                throw ex;
            }
            catch (Exception ex)
            {
                if (session != null)
                {
                    CloseSession(session);
                }
                // 2013.06.24 FSWW, Ramesh M Added For CR#58976 To Add More Details about calling function in Error log file.
                Logging.LogError(ex, "AddBOLItemWagon : CustomerID-" + companyID + ", BOLHdrID-" + BOLHdrID + "\n");
                throw ex;
            }
            finally
            {
                if (session != null)
                {
                    CloseSession(session);
                }
            }

            return status;
        }



        /// <summary>
        /// GetBolitems
        /// Function to get records from BOL item table
        /// </summary>
        /// <param name="UserName">User name</param>
        /// <param name="password">Password</param>
        /// <param name="vehicleID">Vehicle ID</param>
        /// <param name="companyID">Company ID</param>
        /// <param name="bolItemID">BOL Item ID</param>
        /// <param name="bolHdrID">BOL header ID</param>
        /// <param name="SysTrxNo">System transaction number</param>
        /// <param name="sysTrxLine">System transaction line</param>
        /// <param name="componentNo">Component number</param>
        /// <returns>List of BOL item</returns>
        public List<BolitemWagon> GetBolitemWagons(String UserName, String password, String vehicleID, String companyID, Guid bolItemID, Guid bolHdrID, String VersionNo = "")
        {
            List<BolitemWagon> lstBolitems = new List<BolitemWagon>();
            ISession session = null;
            try
            {
                session = GetSession();
                string IsEnabledTW = DALMethods.IsEnabledTankwagon(companyID, session, VersionNo);
                if (IsEnabledTW.ToUpper().Trim() == "Y")
                {
                    //2013.08.01 FSWW, Ramesh M Added For Add if condition for Error log ON/OFF switch control
                    if (LoggingStatus == "on")
                    {
                    }
                    //session = GetSession();
                    if (ValidateUserLogin(UserName, password, companyID, vehicleID, VersionNo))
                    {
                        lstBolitems = DALMethods.GetBolitemWagon(bolItemID, bolHdrID, session, VersionNo);
                    }
                }
                CloseSession(session);

            }
            catch (ApplicationException ex)
            {
                if (session != null)
                {
                    CloseSession(session);
                }
                // 2013.07.22 FSWW, Ramesh M Added For Add More Details about calling function in Error log file.
                Logging.LogError(ex, "GetBolitemWagons : CustomerID-" + companyID + "\n");
                throw ex;
            }
            catch (Exception ex)
            {
                {
                    CloseSession(session);
                }
                // 2013.06.24 FSWW, Ramesh M Added For CR#58976 To Add More Details about calling function in Error log file.
                Logging.LogError(ex, "GetBolitemWagons : CustomerID-" + companyID + "\n");
                throw ex;
            }
            finally
            {
                if (session != null)
                {
                    CloseSession(session);
                }
            }

            return lstBolitems;
        }



        /// <summary>
        /// GetBolitems
        /// Function to get records from BOL item table
        /// </summary>
        /// <param name="UserName">User name</param>
        /// <param name="password">Password</param>
        /// <param name="vehicleID">Vehicle ID</param>
        /// <param name="companyID">Company ID</param>
        /// <param name="bolItemID">BOL Item ID</param>
        /// <param name="bolHdrID">BOL header ID</param>
        /// <param name="SysTrxNo">System transaction number</param>
        /// <param name="sysTrxLine">System transaction line</param>
        /// <param name="componentNo">Component number</param>
        /// <returns>List of BOL item</returns>
        public List<BOLCompartments> GetBolCompartment(String UserName, String password, String vehicleID, String companyID, Int32 UpdatedBy, String SessionID, int CompartmentID, String VersionNo = "")
        {
            List<BOLCompartments> lstBolitems = new List<BOLCompartments>();
            ISession session = null;
            try
            {
                session = GetSession();
                string IsEnabledTW = DALMethods.IsEnabledTankwagon(companyID, session, VersionNo);
                if (IsEnabledTW.ToUpper().Trim() == "Y")
                {
                    //2013.08.01 FSWW, Ramesh M Added For Add if condition for Error log ON/OFF switch control
                    if (LoggingStatus == "on")
                    {
                    }
                    //session = GetSession();
                    if (ValidateUserLogin(UserName, password, companyID, vehicleID, VersionNo))
                    {
                        lstBolitems = DALMethods.GetBolCompartment(UpdatedBy, CompartmentID, SessionID, session, VersionNo);
                    }
                }
                CloseSession(session);

            }
            catch (ApplicationException ex)
            {
                if (session != null)
                {
                    CloseSession(session);
                }
                // 2013.07.22 FSWW, Ramesh M Added For Add More Details about calling function in Error log file.
                Logging.LogError(ex, "GetBolCompartment : CustomerID-" + companyID + "\n");
                throw ex;
            }
            catch (Exception ex)
            {
                {
                    CloseSession(session);
                }
                // 2013.06.24 FSWW, Ramesh M Added For CR#58976 To Add More Details about calling function in Error log file.
                Logging.LogError(ex, "GetBolCompartment : CustomerID-" + companyID + "\n");
                throw ex;
            }
            finally
            {
                if (session != null)
                {
                    CloseSession(session);
                }
            }

            return lstBolitems;
        }

        // 06-26-2014  MadhuVenkat k - Added for CR 64058  - For Add orderDispatchHistory 
        /// <summary>
        /// AddSuppliers
        /// </summary>
        /// <param name="SysTrxNo">SysTrxNo</param>
        /// <param name="companyID">companyID</param>
        /// <param name="password">password</param>
        /// <param name="DefDriverID">DefDriverID</param>
        /// <param name="DefVehicleID">DefVehicleID</param>
        /// <param name="OldDriverID">OldDriverID</param>
        /// <param name="OldVehicleID">OldVehicleID</param>
        /// <returns>True = Inserted successfully, False = Faile</returns>
        public Boolean AddSuppliers(String companyID, String password, Int32 SupplierID, String Codes, String Descr, DateTime? LastModifiedDtTm, String VersionNo = "")
        {
            Boolean status = false;
            ISession session = null;
            Boolean NeedUpdate = true;
            try
            {
                session = GetSession();
                string IsEnabledTW = DALMethods.IsEnabledTankwagon(companyID, session, VersionNo);
                if (IsEnabledTW.ToUpper().Trim() == "Y")
                {
                    //2013.08.01 FSWW, Ramesh M Added For Add if condition for Error log ON/OFF switch control
                    if (LoggingStatus == "on")
                    {
                    }
                    //session = GetSession();
                    if (ValidateCustomerLogin(companyID, password, VersionNo))
                    {
                        DALMethods.AddSuppliers(SupplierID, Codes, Descr, LastModifiedDtTm, companyID, session, VersionNo = "");
                        status = true;
                    }
                }
                CloseSession(session);

            }
            catch (ApplicationException ex)
            {
                if (session != null)
                {
                    CloseSession(session);
                }
                // 2013.07.22 FSWW, Ramesh M Added For Add More Details about calling function in Error log file.
                Logging.LogError(ex, "AddSuppliers : CustomerID-" + companyID + ", SupplierID-" + SupplierID + "\n");
                throw ex;
            }
            catch (Exception ex)
            {
                if (session != null)
                {
                    CloseSession(session);
                }
                // 2013.06.24 FSWW, Ramesh M Added For CR#58976 To Add More Details about calling function in Error log file.
                Logging.LogError(ex, "AddSuppliers : CustomerID-" + companyID + ", SupplierID-" + SupplierID + "\n");
                throw ex;
            }
            finally
            {
                if (session != null)
                {
                    CloseSession(session);
                }
            }

            return status;
        }


        // 06-26-2014  MadhuVenkat k - Added for CR 64058  - For Add orderDispatchHistory 
        /// <summary>
        /// AddSuppliers
        /// </summary>
        /// <param name="SysTrxNo">SysTrxNo</param>
        /// <param name="companyID">companyID</param>
        /// <param name="password">password</param>
        /// <param name="DefDriverID">DefDriverID</param>
        /// <param name="DefVehicleID">DefVehicleID</param>
        /// <param name="OldDriverID">OldDriverID</param>
        /// <param name="OldVehicleID">OldVehicleID</param>
        /// <returns>True = Inserted successfully, False = Faile</returns>
        public Boolean AddSupplierSupplyPt(String companyID, String password, Int32 SupplierSupplyPtID, Int32 SupplierID, DateTime? LastModifiedDtTm, String SupplierSupplyPtCode, String SupplierSupplyPtDescr, String VersionNo = "")
        {
            Boolean status = false;
            ISession session = null;
            Boolean NeedUpdate = true;
            try
            {
                session = GetSession();
                string IsEnabledTW = DALMethods.IsEnabledTankwagon(companyID, session, VersionNo);
                if (IsEnabledTW.ToUpper().Trim() == "Y")
                {
                    //2013.08.01 FSWW, Ramesh M Added For Add if condition for Error log ON/OFF switch control
                    if (LoggingStatus == "on")
                    {
                    }
                    //session = GetSession();
                    if (ValidateCustomerLogin(companyID, password, VersionNo))
                    {
                        DALMethods.AddSupplierSupplyPt(SupplierSupplyPtID, SupplierID, LastModifiedDtTm, SupplierSupplyPtCode, SupplierSupplyPtDescr, companyID, session, VersionNo = "");
                        status = true;
                    }
                }
                CloseSession(session);

            }
            catch (ApplicationException ex)
            {
                if (session != null)
                {
                    CloseSession(session);
                }
                // 2013.07.22 FSWW, Ramesh M Added For Add More Details about calling function in Error log file.
                Logging.LogError(ex, "AddSupplierSupplyPt : CustomerID-" + companyID + ", SupplierID-" + SupplierID + "\n");
                throw ex;
            }
            catch (Exception ex)
            {
                if (session != null)
                {
                    CloseSession(session);
                }
                // 2013.06.24 FSWW, Ramesh M Added For CR#58976 To Add More Details about calling function in Error log file.
                Logging.LogError(ex, "AddSupplierSupplyPt : CustomerID-" + companyID + ", SupplierID-" + SupplierID + "\n");
                throw ex;
            }
            finally
            {
                if (session != null)
                {
                    CloseSession(session);
                }
            }

            return status;
        }




        // 06-26-2014  MadhuVenkat k - Added for CR 64058  - For Add orderDispatchHistory 
        /// <summary>
        /// AddSuppliers
        /// </summary>
        /// <param name="SysTrxNo">SysTrxNo</param>
        /// <param name="companyID">companyID</param>
        /// <param name="password">password</param>
        /// <param name="DefDriverID">DefDriverID</param>
        /// <param name="DefVehicleID">DefVehicleID</param>
        /// <param name="OldDriverID">OldDriverID</param>
        /// <param name="OldVehicleID">OldVehicleID</param>
        /// <returns>True = Inserted successfully, False = Faile</returns>
        public Boolean AddProducts(String companyID, String password, Int32 PurchRackID, Int32 SupplierSupplyPtID, Int32 SupplierID, Int32 SupplierPtID, DateTime? LastModifiedDtTm, String ProductCode, String ProductDescr, String VersionNo = "")
        {
            Boolean status = false;
            ISession session = null;
            Boolean NeedUpdate = true;
            try
            {
                session = GetSession();
                string IsEnabledTW = DALMethods.IsEnabledTankwagon(companyID, session, VersionNo);
                if (IsEnabledTW.ToUpper().Trim() == "Y")
                {
                    //2013.08.01 FSWW, Ramesh M Added For Add if condition for Error log ON/OFF switch control
                    if (LoggingStatus == "on")
                    {
                    }
                    //session = GetSession();
                    if (ValidateCustomerLogin(companyID, password, VersionNo))
                    {

                        DALMethods.AddProducts(PurchRackID, SupplierSupplyPtID, SupplierID, SupplierPtID, LastModifiedDtTm, ProductCode, ProductDescr, companyID, session, VersionNo = "");
                        status = true;
                    }
                }
                CloseSession(session);

            }
            catch (ApplicationException ex)
            {
                if (session != null)
                {
                    CloseSession(session);
                }
                // 2013.07.22 FSWW, Ramesh M Added For Add More Details about calling function in Error log file.
                Logging.LogError(ex, "AddProducts : CustomerID-" + companyID + ", SupplierID-" + SupplierID + "\n");
                throw ex;
            }
            catch (Exception ex)
            {
                if (session != null)
                {
                    CloseSession(session);
                }
                // 2013.06.24 FSWW, Ramesh M Added For CR#58976 To Add More Details about calling function in Error log file.
                Logging.LogError(ex, "AddProducts : CustomerID-" + companyID + ", SupplierID-" + SupplierID + "\n");
                throw ex;
            }
            finally
            {
                if (session != null)
                {
                    CloseSession(session);
                }
            }

            return status;
        }




        // 2013.08.27 FSWW, Ramesh M Added For CR#?.. To Get Inspection ElemetsID
        // 09-09-2014  CR#64208, Madhu, Add Modified date to GetInspectionElementsData
        /// <summary>
        /// GetVehicleCompartment
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="password"></param>
        /// <param name="vehicleID"></param>
        /// <param name="companyID"></param>
        /// <returns></returns>

        public List<Supplier> GetSupplierAndSupplierSupplyPt(String UserName, String password, String companyID, String VersionNo = "")
        {
            List<Supplier> lstSupplierSupplyPtDetails = new List<Supplier>();
            //Vehicle veh = new Vehicle();
            //veh.VehicleCode = "test";
            //ve.BolCompartment.Add(veh);
            //lstVehicleCompartmentDetails.Add(ve);

            ISession session = null;
            try
            {
                session = GetSession();
                string IsEnabledTW = DALMethods.IsEnabledTankwagon(companyID, session, VersionNo);
                if (IsEnabledTW.ToUpper().Trim() == "Y")
                {
                    //2013.08.01 FSWW, Ramesh M Added For Add if condition for Error log ON/OFF switch control
                    if (LoggingStatus == "on")
                    {
                    }
                    //session = GetSession();
                    //if (ValidateUserLogin(UserName, password, companyID, vehicleID, VersionNo))
                    //{

                    lstSupplierSupplyPtDetails = DALMethods.GetSuppliers(companyID, session, VersionNo);

                    for (int i = 0; i < lstSupplierSupplyPtDetails.Count; i++)
                    {
                        Supplier ve = new Supplier();
                        ve.SupplierSupplyPt = DALMethods.GetSupplierSupplyPt(companyID, lstSupplierSupplyPtDetails[i].SupplierID, session, VersionNo);

                        lstSupplierSupplyPtDetails[i].SupplierSupplyPt = new List<SupplierSupplyPt>();

                        for (int j = 0; j < ve.SupplierSupplyPt.Count; j++)
                        {
                            SupplierSupplyPt be = new SupplierSupplyPt();
                            be.SupplierSupplyPtID = ve.SupplierSupplyPt[j].SupplierSupplyPtID;
                            be.SupplierID = ve.SupplierSupplyPt[j].SupplierID;
                            be.SupplierSupplyPtCode = ve.SupplierSupplyPt[j].SupplierSupplyPtCode;
                            be.SupplierSupplyPtDescr = ve.SupplierSupplyPt[j].SupplierSupplyPtDescr;
                            be.LastModifiedDtTm = ve.SupplierSupplyPt[j].LastModifiedDtTm;
                            be.CompanyID = ve.SupplierSupplyPt[j].CompanyID;
                            lstSupplierSupplyPtDetails[i].SupplierSupplyPt.Add(be);
                        }

                    }

                    //}
                }
                CloseSession(session);

            }
            catch (ApplicationException ex)
            {
                if (session != null)
                {
                    CloseSession(session);
                }
                // 2013.07.22 FSWW, Ramesh M Added For Add More Details about calling function in Error log file.
                Logging.LogError(ex, "GetSupplierAndSupplierSupplyPt : CustomerID-" + companyID + "\n");
                throw ex;
            }
            catch (Exception ex)
            {
                if (session != null)
                {
                    CloseSession(session);
                }
                // 2013.06.24 FSWW, Ramesh M Added For CR#58976 To Add More Details about calling function in Error log file.
                Logging.LogError(ex, "GetSupplierAndSupplierSupplyPt : CustomerID-" + companyID + "\n");
                throw ex;
            }
            finally
            {
                if (session != null)
                {
                    CloseSession(session);
                }
            }
            return lstSupplierSupplyPtDetails;

        }

        // 2015.04.06 FSWW, Dinesh Created the Method to Return List of Products

        //public List<Supplier> GetSupplierAndSupplierSupplyPt(String UserName, String password,  String companyID, String VersionNo = "")
        //{
        //    List<Supplier> lstSupplierSupplyPtDetails = new List<Supplier>();
        //    //Vehicle veh = new Vehicle();
        //    //veh.VehicleCode = "test";
        //    //ve.BolCompartment.Add(veh);
        //    //lstVehicleCompartmentDetails.Add(ve);

        //    ISession session = null;
        //    try
        //    {
        //        //2013.08.01 FSWW, Ramesh M Added For Add if condition for Error log ON/OFF switch control
        //        if (LoggingStatus == "on")
        //        {
        //            //2013.07.22 FSWW, Ramesh M Added For Add More Details about calling function in Error log file
        //            Logging.LogInfoAboutCallingFunction("Function Called:- GetSupplierAndSupplierSupplyPt ; " + "CustomerID-" + companyID);
        //        }
        //        session = GetSession();
        //        //if (ValidateUserLogin(UserName, password, companyID, vehicleID, VersionNo))
        //        //{

        //        lstSupplierSupplyPtDetails = DALMethods.GetSuppliers(companyID, session, VersionNo);

        //        for (int i = 0; i < lstSupplierSupplyPtDetails.Count; i++)
        //        {
        //            Supplier ve = new Supplier();
        //            ve.SupplierSupplyPt = DALMethods.GetSupplierSupplyPt(companyID, lstSupplierSupplyPtDetails[i].SupplierID, session, VersionNo);

        //            lstSupplierSupplyPtDetails[i].SupplierSupplyPt = new List<SupplierSupplyPt>();

        //            for (int j = 0; j < ve.SupplierSupplyPt.Count; j++)
        //            {
        //               // SupplierSupplyPt be = new SupplierSupplyPt();
        //                ve.SupplierSupplyPtID = ve.SupplierSupplyPt[j].SupplierSupplyPtID;
        //                ve.SupplierID = ve.SupplierSupplyPt[j].SupplierID;
        //                ve.SupplierSupplyPtCode = ve.SupplierSupplyPt[j].SupplierSupplyPtCode;
        //                ve.SupplierSupplyPtDescr = ve.SupplierSupplyPt[j].SupplierSupplyPtDescr;
        //                ve.LastModifiedDtTm = ve.SupplierSupplyPt[j].LastModifiedDtTm;
        //                ve.CompanyID = ve.SupplierSupplyPt[j].CompanyID;
        //                lstSupplierSupplyPtDetails[i].Add(ve);
        //            }

        //        }

        //        //}
        //        CloseSession(session);

        //    }
        //    catch (ApplicationException ex)
        //    {
        //        if (session != null)
        //        {
        //            CloseSession(session);
        //        }
        //        // 2013.07.22 FSWW, Ramesh M Added For Add More Details about calling function in Error log file.
        //        Logging.LogError(ex, "CustomerID-" + companyID + "\n");
        //        throw ex;
        //    }
        //    catch (Exception ex)
        //    {
        //        if (session != null)
        //        {
        //            CloseSession(session);
        //        }
        //        // 2013.06.24 FSWW, Ramesh M Added For CR#58976 To Add More Details about calling function in Error log file.
        //        Logging.LogError(ex, "CustomerID-" + companyID + "\n");
        //        throw ex;
        //    }
        //    finally
        //    {
        //        if (session != null)
        //        {
        //            CloseSession(session);
        //        }
        //    }
        //    return lstSupplierSupplyPtDetails;

        //}

        // 2015.04.06 FSWW, Dinesh Created the Method to Return List of Products

        /// <summary>
        /// GetSupplierSupplyPtProducts
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="password"></param>
        /// <param name="vehicleID"></param>
        /// <param name="companyID"></param>
        /// <returns></returns>

        public List<Products> GetSupplierSupplyPtProducts(String UserName, String password, String companyID, Int32 SupplierID, Int32 SupplierPtID, String VersionNo = "")
        {
            List<Products> lstSupplierSupplyPtProducts = new List<Products>();
            //Vehicle veh = new Vehicle();
            //veh.VehicleCode = "test";
            //ve.BolCompartment.Add(veh);
            //lstVehicleCompartmentDetails.Add(ve);

            ISession session = null;
            try
            {
                session = GetSession();
                string IsEnabledTW = DALMethods.IsEnabledTankwagon(companyID, session, VersionNo);
                if (IsEnabledTW.ToUpper().Trim() == "Y")
                {
                    //2013.08.01 FSWW, Ramesh M Added For Add if condition for Error log ON/OFF switch control
                    if (LoggingStatus == "on")
                    {
                    }
                    //session = GetSession();
                    //if (ValidateUserLogin(UserName, password, companyID, vehicleID, VersionNo))
                    //{

                    lstSupplierSupplyPtProducts = DALMethods.GetSupplierSupplyPtProducts(companyID, SupplierID, SupplierPtID, session, VersionNo);


                    //}
                }
                CloseSession(session);

            }
            catch (ApplicationException ex)
            {
                if (session != null)
                {
                    CloseSession(session);
                }
                // 2013.07.22 FSWW, Ramesh M Added For Add More Details about calling function in Error log file.
                Logging.LogError(ex, "GetSupplierSupplyPtProducts : CustomerID-" + companyID + "\n");
                throw ex;
            }
            catch (Exception ex)
            {
                if (session != null)
                {
                    CloseSession(session);
                }
                // 2013.06.24 FSWW, Ramesh M Added For CR#58976 To Add More Details about calling function in Error log file.
                Logging.LogError(ex, "GetSupplierSupplyPtProducts : CustomerID-" + companyID + "\n");
                throw ex;
            }
            finally
            {
                if (session != null)
                {
                    CloseSession(session);
                }
            }
            return lstSupplierSupplyPtProducts;

        }

        /// <summary>
        /// GetSupplierSupplyPtProducts
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="password"></param>
        /// <param name="vehicleID"></param>
        /// <param name="companyID"></param>
        /// <returns></returns>

        public List<BOLCompartments> GetProductCompartment(String UserName, String password, String companyID, Int32 Updatedby, String ProductCode, String SessionID, Guid OrderId, Guid OrderItemId, String VersionNo = "")
        {
            List<BOLCompartments> lstProductCompartment = new List<BOLCompartments>();
            //Vehicle veh = new Vehicle();
            //veh.VehicleCode = "test";
            //ve.BolCompartment.Add(veh);
            //lstVehicleCompartmentDetails.Add(ve); 
            ISession session = null;
            try
            {
                session = GetSession();
                string IsEnabledTW = DALMethods.IsEnabledTankwagon(companyID, session, VersionNo);
                if (IsEnabledTW.ToUpper().Trim() == "Y")
                {
                    //2013.08.01 FSWW, Ramesh M Added For Add if condition for Error log ON/OFF switch control
                    if (LoggingStatus == "on")
                    {
                    }
                    //session = GetSession();
                    //if (ValidateUserLogin(UserName, password, companyID, vehicleID, VersionNo))
                    //{
                    //Int32 Updatedby=0;
                    lstProductCompartment = DALMethods.GetProductCompartment(Updatedby, ProductCode, companyID, SessionID, OrderId, OrderItemId, session, VersionNo);


                    //}
                }
                CloseSession(session);

            }
            catch (ApplicationException ex)
            {
                if (session != null)
                {
                    CloseSession(session);
                }
                // 2013.07.22 FSWW, Ramesh M Added For Add More Details about calling function in Error log file.
                Logging.LogError(ex, "GetProductCompartment : CustomerID-" + companyID + "\n");
                throw ex;
            }
            catch (Exception ex)
            {
                if (session != null)
                {
                    CloseSession(session);
                }
                // 2013.06.24 FSWW, Ramesh M Added For CR#58976 To Add More Details about calling function in Error log file.
                Logging.LogError(ex, "GetProductCompartment : CustomerID-" + companyID + "\n");
                throw ex;
            }
            finally
            {
                if (session != null)
                {
                    CloseSession(session);
                }
            }
            return lstProductCompartment;

        }


        //2013.08.12 FSWW, Ramesh M Added For CR#?... Added AssignedDriverLoginID in input details.
        //2013.08.22 FSWW, Ramesh M Added For CR#?... Added AssignedVehicleID in input details.
        //2013.08.22 FSWW, Ramesh M Added For CR#61432 Added LoadType
        //2014.01.28 Ramesh M Added For Support Multi BOL ites added ExtSysTrxLine For CR#62038
        //2014.03.18 Ramesh M Added For CR#62719 added  TrailerCode in input parameters
        //09-23-2014 MadhuVenkat k - Added for CR#65002  added SupplierCode and SupplyPointCode.
        /// <summary>
        /// AddShipmentDetails
        /// Function to add shipment details
        /// </summary>
        /// <param name="UserName">User name</param>
        /// <param name="password">Password</param>
        /// <param name="vehicleID">Vehicle ID</param>
        /// <param name="companyID">Company ID</param>
        /// <param name="loadID">Load ID</param>
        /// <param name="bolNo">BOL number</param>
        /// <param name="bolDateTime">BOL date time</param>
        /// <param name="sysTrxNo">System transaction number</param>
        /// <param name="sysTrxLine">System transaction line</param>
        /// <param name="componentNo">Component number</param>
        /// <param name="grossQty">Gross quantity</param>
        /// <param name="netQty">Net quantity</param>
        /// <param name="images">Images</param>
        /// <param name="deviceID">deviceID</param>
        /// <param name="deviceTime">DeviceTime</param>
        /// <param name="BOLWaitTime">BOLWaitTime</param>
        /// <param name="BOLWaitTime_Comment">BOLWaitTime_Comment</param>
        /// <param name="BOLWaitTime_Start">BOLWaitTime_Start</param>
        /// <param name="BOLWaitTime_End">BOLWaitTime_End</param>
        /// <param name="BOLQtyVarianceReason">BOL Qty Variance Reason </param>
        /// <param name="AssignedDriverLoginID">AssignedDriverLoginID</param>
        /// <param name="AssignedVehicleID">AssignedVehicleID</param>
        /// <param name="LoadType">LoadType</param>
        /// <returns>True = Inserted successfully, False = Faile</returns>
        public Boolean AddBOLItemHdrWagon(String UserName, String password, String companyID, String vehicleID, String BOLNo, String BOLDatetime, String SupplierCode, String SupplyPointCode, Int32 UpdatedBy, Decimal SystrxNo, Int32 SystrxLine, Int32 CompartmentID, String ProdCode, Decimal GrossQty, Decimal NetQty, Decimal OrderedQty, String Notes, String Image, String VersionNo = "")
        {
            Boolean updateStatus = false;
            ISession session = null;
            //2013.08.22 FSWW, Ramesh M Added For CR#61432
            Boolean ValidSession = false;
            try
            {
                session = GetSession();
                string IsEnabledTW = DALMethods.IsEnabledTankwagon(companyID, session, VersionNo);
                if (IsEnabledTW.ToUpper().Trim() == "Y")
                {
                    //2013.08.01 FSWW, Ramesh M Added For Add if condition for Error log ON/OFF switch control
                    if (LoggingStatus == "on")
                    {
                    }
                    //session = GetSession();
                    //2013.08.22 FSWW, Ramesh M Added For CR#61432
                    int newvehicleID;
                    newvehicleID = DALMethods.GetVehicleID(vehicleID, companyID, session, "");
                    if (ValidateUserLogin(UserName, password, companyID, vehicleID, VersionNo))
                    {
                        ValidSession = true;
                    }
                    Guid sessionid = Guid.NewGuid();
                    //2013.08.22 FSWW, Ramesh M Added For CR#61432
                    if (ValidSession == true)
                    {
                        Int32 loginID = DALMethods.GetUserID(UserName, companyID, session, VersionNo);
                        //DALMethods.UpdateUndispatched(0, loadID, session, VersionNo);
                        Guid bolHdrID = Guid.Empty;
                        List<BolHdrWagon> lstBolHdr = DALMethods.GetDatabyBOLno(BOLNo, session, VersionNo);
                        //int? Count = DALMethods.GetSupplierSupplyPtProducts(BOLNo, session, VersionNo);
                        if (lstBolHdr.Count > 0)
                        {
                            bolHdrID = lstBolHdr[0].ID;
                        }
                        else
                        {
                            bolHdrID = Guid.NewGuid();
                            byte[] image1 = null;
                            try
                            {
                                if (!String.IsNullOrWhiteSpace(Image))
                                {
                                    image1 = System.Convert.FromBase64String(Image);
                                }
                            }
                            catch
                            {
                                image1 = null;
                            }
                            //2014.03.18 Ramesh M, Added For CR#62719 added  TrailerCode in input parameters 
                            //09-23-2014  MadhuVenkat k - Added for CR#65002  added SupplierCode and SupplyPointCode.
                            DALMethods.AddBOLHdrWagon(bolHdrID, sessionid, BOLNo, Convert.ToDateTime(BOLDatetime), SupplierCode, SupplyPointCode, UpdatedBy, image1, companyID, session, VersionNo = "");
                            //DALMethods.AddBolHdr(bolHdrID, loadID, bolNo, image, bolDateTime, loginID, BOLWaitTime, BOLWaitTime_Comment, BOLWaitTime_Start, BOLWaitTime_End, session, TrailerCode, SupplierCode, SupplyPointCode, VersionNo);
                        }
                        //2014.01.28  Ramesh M Added For Support Multi BOL ites added ExtSysTrxLine For CR#62038
                        //DALMethods.AddBolItem(bolHdrID, sysTrxNo, sysTrxLine, componentNo, grossQty, netQty, loginID, deviceID, deviceTime, BOLQtyVarianceReason, AssignedDriverLoginID, AssignedVehicleID, session, ExtSysTrxLine, VersionNo);
                        DALMethods.AddBOLItemWagon(bolHdrID, SystrxNo, SystrxLine, CompartmentID, ProdCode, GrossQty, NetQty, OrderedQty, Notes, newvehicleID, session, VersionNo = "");

                        updateStatus = true;
                    }
                }
                CloseSession(session);
            }
            catch (ApplicationException ex)
            {
                if (session != null)
                {
                    CloseSession(session);
                }
                // 2013.07.22 FSWW, Ramesh M Added For Add More Details about calling function in Error log file.               
                Logging.LogInfoAboutCallingFunction("AddShipmentDetails - Errors: CustomerID - " + companyID + "bolNo : " + BOLNo + " VersionNo : " + VersionNo + "Exception :" + ex);
                throw ex;
            }
            catch (Exception ex)
            {
                if (session != null)
                {
                    CloseSession(session);
                }
                // 2013.06.24 FSWW, Ramesh M Added For CR#58976 To Add More Details about calling function in Error log file.               
                Logging.LogInfoAboutCallingFunction("AddShipmentDetails - Errors: CustomerID - " + companyID + "bolNo : " + BOLNo + " VersionNo : " + VersionNo + "Exception :" + ex);
                throw ex;
            }
            finally
            {
                if (session != null)
                {
                    CloseSession(session);
                }
            }

            return updateStatus;
        }

        //2013.08.12 FSWW, Ramesh M Added For CR#?... Added AssignedDriverLoginID in input details.
        //2013.08.22 FSWW, Ramesh M Added For CR#?... Added AssignedVehicleID in input details.
        //2013.08.22 FSWW, Ramesh M Added For CR#61432 Added LoadType
        //2014.01.28 Ramesh M Added For Support Multi BOL ites added ExtSysTrxLine For CR#62038
        //2014.03.18 Ramesh M Added For CR#62719 added  TrailerCode in input parameters
        //09-23-2014 MadhuVenkat k - Added for CR#65002  added SupplierCode and SupplyPointCode.
        /// <summary>
        /// AddShipmentDetails
        /// Function to add shipment details
        /// </summary>
        /// <param name="UserName">User name</param>
        /// <param name="password">Password</param>
        /// <param name="vehicleID">Vehicle ID</param>
        /// <param name="companyID">Company ID</param>
        /// <param name="loadID">Load ID</param>
        /// <param name="bolNo">BOL number</param>
        /// <param name="bolDateTime">BOL date time</param>
        /// <param name="sysTrxNo">System transaction number</param>
        /// <param name="sysTrxLine">System transaction line</param>
        /// <param name="componentNo">Component number</param>
        /// <param name="grossQty">Gross quantity</param>
        /// <param name="netQty">Net quantity</param>
        /// <param name="images">Images</param>
        /// <param name="deviceID">deviceID</param>
        /// <param name="deviceTime">DeviceTime</param>E:\Tank Wagon\DeliveryStream\DeliveryStreamCloudWCF\DeliveryStreamCloudWCF.Service\CloudService.cs
        /// <param name="BOLWaitTime">BOLWaitTime</param>
        /// <param name="BOLWaitTime_Comment">BOLWaitTime_Comment</param>
        /// <param name="BOLWaitTime_Start">BOLWaitTime_Start</param>
        /// <param name="BOLWaitTime_End">BOLWaitTime_End</param>
        /// <param name="BOLQtyVarianceReason">BOL Qty Variance Reason </param>
        /// <param name="AssignedDriverLoginID">AssignedDriverLoginID</param>
        /// <param name="AssignedVehicleID">AssignedVehicleID</param>
        /// <param name="LoadType">LoadType</param>
        /// <returns>True = Inserted successfully, False = Faile</returns>
        public List<Status> AddBOLItemHdrWagon1(String UserName, String password, String companyID, String vehicleID, Guid sessionID, String BOLNo, String BOLDatetime, String SupplierCode, String SupplyPointCode, String Image, List<BolitemWagon> BOLItemDetails, String VersionNo = "")
        {
            Status stts = new Status();
            List<Status> lststts = new List<Status>();
            ISession session = null;
            //2013.08.22 FSWW, Ramesh M Added For CR#61432
            Boolean ValidSession = false;
            try
            {
                session = GetSession();
                string IsEnabledTW = DALMethods.IsEnabledTankwagon(companyID, session, VersionNo);
                if (IsEnabledTW.ToUpper().Trim() == "Y")
                {
                    //2013.08.01 FSWW, Ramesh M Added For Add if condition for Error log ON/OFF switch control
                    if (LoggingStatus == "on")
                    {
                    }
                    //session = GetSession();
                    //2013.08.22 FSWW, Ramesh M Added For CR#61432

                    //if (ValidateUserLogin(UserName, password, companyID, vehicleID, VersionNo))
                    //{
                    //    ValidSession = true;
                    //}

                    //2013.08.22 FSWW, Ramesh M Added For CR#61432
                    //if (ValidSession == true)
                    //{
                    Int32 loginID = DALMethods.GetUserID(UserName, companyID, session, VersionNo);
                    int newvehicleID;
                    newvehicleID = DALMethods.GetVehicleID(vehicleID, companyID, session, "");
                    //DALMethods.UpdateUndispatched(0, loadID, session, VersionNo);
                    // List<BolitemWagon> LstBolitemWagon;

                    //  LstBOLDetailst.NeedUpdate = 0;
                    //BolitemWagon bolitemWagon = new BolitemWagon();
                    //LstBolitemWagon = LstBOLDetailst.BolitemWagon;
                    //for (int i = 0; i < LstBolitemWagon.Count; i++)
                    //{
                    //    //LstBolitemWagon[i].BOLHdrID = "";
                    //}
                    Guid bolHdrID = Guid.Empty;
                    bolHdrID = Guid.NewGuid();
                    byte[] image1 = null;
                    try
                    {
                        if (!String.IsNullOrWhiteSpace(Image))
                        {
                            image1 = System.Convert.FromBase64String(Image);
                        }
                    }
                    catch
                    {
                        image1 = null;
                    }
                    //2014.03.18 Ramesh M, Added For CR#62719 added  TrailerCode in input parameters 
                    //09-23-2014  MadhuVenkat k - Added for CR#65002  added SupplierCode and SupplyPointCode.
                    if (DALMethods.IsBOLNoExists(BOLNo, companyID, session, VersionNo) == "TRUE")
                    {
                        DALMethods.AddBOLHdrWagon(bolHdrID, sessionID, BOLNo, Convert.ToDateTime(BOLDatetime), SupplierCode, SupplyPointCode, loginID, image1, companyID, session, VersionNo = "");
                        //DALMethods.AddBolHdr(bolHdrID, loadID, bolNo, image, bolDateTime, loginID, BOLWaitTime, BOLWaitTime_Comment, BOLWaitTime_Start, BOLWaitTime_End, session, TrailerCode, SupplierCode, SupplyPointCode, VersionNo);
                        foreach (BolitemWagon lstBOLItemDetails in BOLItemDetails)
                        {
                            DALMethods.AddBOLItemWagon(bolHdrID, lstBOLItemDetails.SystrxNo, lstBOLItemDetails.SystrxLine, lstBOLItemDetails.CompartmentID, lstBOLItemDetails.ProdCode, lstBOLItemDetails.GrossQty, lstBOLItemDetails.NetQty, lstBOLItemDetails.OrderedQty, lstBOLItemDetails.Notes, newvehicleID, session, VersionNo = "");
                        }
                        //2014.01.28  Ramesh M Added For Support Multi BOL ites added ExtSysTrxLine For CR#62038
                        //DALMethods.AddBolItem(bolHdrID, sysTrxNo, sysTrxLine, componentNo, grossQty, netQty, loginID, deviceID, deviceTime, BOLQtyVarianceReason, AssignedDriverLoginID, AssignedVehicleID, session, ExtSysTrxLine, VersionNo);
                        stts.StatusNew = "Success";
                        stts.Reason = "BOL Details Added Successfully";
                        lststts.Add(stts);
                    }
                    else
                    {
                        stts.StatusNew = "Fail";
                        stts.Reason = "BOLNO already exists";
                        lststts.Add(stts);
                    }

                    //}
                }
                CloseSession(session);
            }
            catch (ApplicationException ex)
            {
                if (session != null)
                {
                    CloseSession(session);
                }
                // 2013.07.22 FSWW, Ramesh M Added For Add More Details about calling function in Error log file.
                Logging.LogError(ex, "AddBOLItemHdrWagon1 : CustomerID-" + companyID + "\n");
                //  Logging.LogInfoAboutCallingFunction("AddShipmentDetails - Errors: CustomerID - " + companyID + "bolNo : " + BOLNo + " VersionNo : " + VersionNo + "Exception :" + ex);
                stts.StatusNew = "Fail";
                stts.Reason = ex.Message;
                lststts.Add(stts);

                throw ex;
            }
            catch (Exception ex)
            {
                if (session != null)
                {
                    CloseSession(session);
                }
                // 2013.06.24 FSWW, Ramesh M Added For CR#58976 To Add More Details about calling function in Error log file.
                Logging.LogError(ex, "AddBOLItemHdrWagon1 : CustomerID-" + companyID + "\n");
                // Logging.LogInfoAboutCallingFunction("AddShipmentDetails - Errors: CustomerID - " + companyID + "bolNo : " + BOLNo + " VersionNo : " + VersionNo + "Exception :" + ex);
                stts.StatusNew = "Fail";
                stts.Reason = ex.Message;
                lststts.Add(stts);
                throw ex;
            }
            finally
            {
                if (session != null)
                {
                    CloseSession(session);
                }
            }

            return lststts;
        }


        public List<Status> AddBOLItemHdrWagonXML(List<BolHdrWagon> lsBolHdrWagon, String UserName, String password, String companyID, String vehicleID, String VersionNo = "")
        {
            Status stts = new Status();
            List<Status> lststts = new List<Status>();
            ISession session = null;
            //2013.08.22 FSWW, Ramesh M Added For CR#61432
            Boolean ValidSession = false;
            try
            {
                session = GetSession();
                string IsEnabledTW = DALMethods.IsEnabledTankwagon(companyID, session, VersionNo);
                if (IsEnabledTW.ToUpper().Trim() == "Y")
                {
                    if (LoggingStatus == "on")
                    {
                    }
                    //session = GetSession();

                    Int32 loginID = DALMethods.GetUserID(UserName, companyID, session, VersionNo);

                    Guid bolHdrID = Guid.Empty;
                    byte[] image1 = null;
                    int newvehicleID;
                    newvehicleID = DALMethods.GetVehicleID(vehicleID, companyID, session, "");
                    foreach (BolHdrWagon hdr in lsBolHdrWagon)
                    {
                        if (DALMethods.IsBOLNoExists(hdr.BOLNo, companyID, session, VersionNo) == "FALSE")
                        {
                            stts.StatusNew = "Fail";
                            stts.Reason = "BOLNO already exists - " + hdr.BOLNo;
                            lststts.Add(stts);
                            return lststts;
                        }
                        //Logging.LogInfoAboutCallingFunction("Function Called:- AddBOLItemHdrWagonXML; " + "BolHdrWagon BolitemWagon BOL NO-" + hdr.BOLNo);
                        foreach (BolitemWagon lstBOLItemDetails in hdr.ZsBolitemWagon)
                        {
                            //Logging.LogInfoAboutCallingFunction("Function Called:- AddBOLItemHdrWagonXML; " + "BolHdrWagon BolitemWagon Product Code-" + lstBOLItemDetails.ProdCode);
                            //Logging.LogInfoAboutCallingFunction("Function Called:- AddBOLItemHdrWagonXML; " + "BolHdrWagon BolitemWagon Product Code 1-" + hdr.SessionID+"_"+lstBOLItemDetails.ProdCode+"_"+ companyID+"_"+ lstBOLItemDetails.CompartmentID);
                            //Logging.LogInfoAboutCallingFunction("Function Called:- AddBOLItemHdrWagonXML; " + "BolHdrWagon BolitemWagon Product Code 2-" + DALMethods.IsProductDiffer(hdr.SessionID, lstBOLItemDetails.ProdCode, companyID, lstBOLItemDetails.CompartmentID, session, VersionNo));
                            if (DALMethods.IsProductDiffer(hdr.SessionID, lstBOLItemDetails.ProdCode, companyID, lstBOLItemDetails.CompartmentID, newvehicleID, 0, session, VersionNo) == "TRUE")
                            {
                                //Logging.LogInfoAboutCallingFunction("Function Called:- AddBOLItemHdrWagonXML; " + "BolHdrWagon BolitemWagon Product Code-" + lstBOLItemDetails.ProdCode +"_Fail");
                                stts.StatusNew = "Fail";
                                stts.Reason = "This Compartment has different product..!";
                                lststts.Add(stts);
                                return lststts;
                            }
                        }
                    }

                    foreach (BolHdrWagon hdr in lsBolHdrWagon)
                    {
                        bolHdrID = Guid.NewGuid();
                        try
                        {
                            if (!String.IsNullOrWhiteSpace(hdr.Img))
                            {
                                image1 = System.Convert.FromBase64String(hdr.Img);
                            }
                        }
                        catch
                        {
                            image1 = null;
                        }

                        DALMethods.AddBOLHdrWagon(bolHdrID, hdr.SessionID, hdr.BOLNo, Convert.ToDateTime(hdr.BOLDatetime), hdr.SupplierCode, hdr.SupplyPointCode, loginID, image1, companyID, session, VersionNo = "");

                        foreach (BolitemWagon lstBOLItemDetails in hdr.ZsBolitemWagon)
                        {

                            DALMethods.AddBOLItemWagon(bolHdrID, lstBOLItemDetails.SystrxNo, lstBOLItemDetails.SystrxLine, lstBOLItemDetails.CompartmentID, lstBOLItemDetails.ProdCode, lstBOLItemDetails.GrossQty, lstBOLItemDetails.NetQty, lstBOLItemDetails.OrderedQty, lstBOLItemDetails.Notes, newvehicleID, session, VersionNo = "");
                        }

                    }

                    stts.StatusNew = "Success";
                    stts.Reason = "BOL Details Added Successfully";
                    lststts.Add(stts);
                }
                CloseSession(session);
            }
            catch (ApplicationException ex)
            {
                if (session != null)
                {
                    CloseSession(session);
                }
                // 2013.07.22 FSWW, Ramesh M Added For Add More Details about calling function in Error log file.
                Logging.LogError(ex, "AddBOLItemHdrWagonXML : CustomerID-" + companyID + "\n");
                //  Logging.LogInfoAboutCallingFunction("AddShipmentDetails - Errors: CustomerID - " + companyID + "bolNo : " + BOLNo + " VersionNo : " + VersionNo + "Exception :" + ex);
                stts.StatusNew = "Fail";
                stts.Reason = ex.Message;
                lststts.Add(stts);
                throw ex;
            }
            catch (Exception ex)
            {
                if (session != null)
                {
                    CloseSession(session);
                }
                // 2013.06.24 FSWW, Ramesh M Added For CR#58976 To Add More Details about calling function in Error log file.
                Logging.LogError(ex, "AddBOLItemHdrWagonXML : CustomerID-" + companyID + "\n");
                // Logging.LogInfoAboutCallingFunction("AddShipmentDetails - Errors: CustomerID - " + companyID + "bolNo : " + BOLNo + " VersionNo : " + VersionNo + "Exception :" + ex);
                stts.StatusNew = "Fail";
                stts.Reason = ex.Message;
                lststts.Add(stts);
                throw ex;
            }
            finally
            {
                if (session != null)
                {
                    CloseSession(session);
                }
            }

            //foreach (BolHdrWagon hdr in lsBolHdrWagon)
            //{

            //    Logging.LogInfoAboutCallingFunction("Function Called:- AddBOLItemHdrWagonNew ; " + "BolHdrWagon BOLNo-" + hdr.BOLNo == null ? "Nil" : hdr.BOLNo.ToString());
            //    Logging.LogInfoAboutCallingFunction("Function Called:- AddBOLItemHdrWagonNew ; " + "BolHdrWagon BOLDatetime-" + hdr.BOLDatetime == null ? "Nil" : hdr.BOLDatetime.ToString());
            //    Logging.LogInfoAboutCallingFunction("Function Called:- AddBOLItemHdrWagonNew ; " + "BolHdrWagon UpdatedBy-" + hdr.Img == null ? "Nil" : hdr.Img.ToString());
            //    Logging.LogInfoAboutCallingFunction("Function Called:- AddBOLItemHdrWagonNew ; " + "BolHdrWagon SessionID-" + hdr.SessionID == null ? "Nil" : hdr.SessionID.ToString());
            //    Logging.LogInfoAboutCallingFunction("Function Called:- AddBOLItemHdrWagonNew ; " + "BolHdrWagon SupplierCode-" + hdr.SupplierCode == null ? "Nil" : hdr.SupplierCode.ToString());
            //    Logging.LogInfoAboutCallingFunction("Function Called:- AddBOLItemHdrWagonNew ; " + "BolHdrWagon SupplyPointCode-" + hdr.SupplyPointCode == null ? "Nil" : hdr.SupplyPointCode.ToString());
            //    Logging.LogInfoAboutCallingFunction("Function Called:- AddBOLItemHdrWagonNew ; " + "BolHdrWagon UpdatedBy-" + hdr.UpdatedBy == null ? "Nil" : hdr.UpdatedBy.ToString());

            //    foreach (BolitemWagon item in hdr.ZsBolitemWagon)
            //    {
            //        Logging.LogInfoAboutCallingFunction("Function Called:- AddBOLItemHdrWagonNew ; " + "BolHdrWagon BolitemWagon CompartmentID-" + item.CompartmentID == null ? "Nil" : item.CompartmentID.ToString());
            //        Logging.LogInfoAboutCallingFunction("Function Called:- AddBOLItemHdrWagonNew ; " + "BolHdrWagon BolitemWagon GrossQty-" + item.GrossQty == null ? "Nil" : item.GrossQty.ToString());
            //        Logging.LogInfoAboutCallingFunction("Function Called:- AddBOLItemHdrWagonNew ; " + "BolHdrWagon BolitemWagon NetQty-" + item.NetQty == null ? "Nil" : item.NetQty.ToString());
            //        Logging.LogInfoAboutCallingFunction("Function Called:- AddBOLItemHdrWagonNew ; " + "BolHdrWagon BolitemWagon Notes-" + item.Notes == null ? "Nil" : item.Notes.ToString());
            //        Logging.LogInfoAboutCallingFunction("Function Called:- AddBOLItemHdrWagonNew ; " + "BolHdrWagon BolitemWagon OrderedQty-" + item.OrderedQty == null ? "Nil" : item.OrderedQty.ToString());
            //        Logging.LogInfoAboutCallingFunction("Function Called:- AddBOLItemHdrWagonNew ; " + "BolHdrWagon BolitemWagon ProdCode-" + item.ProdCode == null ? "Nil" : item.ProdCode.ToString());
            //        Logging.LogInfoAboutCallingFunction("Function Called:- AddBOLItemHdrWagonNew ; " + "BolHdrWagon BolitemWagon VehicleID-" + item.VehicleID == null ? "Nil" : item.VehicleID.ToString());
            //    }
            //}
            return lststts;
        }

        /// <summary>
        /// GetDeliveryDetails
        /// Function to get records from delivery details table
        /// </summary>
        /// <param name="UserName">User name</param>
        /// <param name="password">Password</param>
        /// <param name="vehicleID">Vehicle ID</param>
        /// <param name="companyID">Company ID</param>
        /// <param name="orderItemID">Order item ID</param>
        /// <returns>List of delivery details</returns>
        public List<OrderItemDetails> GetTWDeliveryDetails(String UserName, String password, String vehicleID, String companyID, Guid OrderID, String VersionNo = "")
        {
            List<OrderItemDetails> lstDelitems = new List<OrderItemDetails>();
            ISession session = null;
            try
            {
                session = GetSession();
                string IsEnabledTW = DALMethods.IsEnabledTankwagon(companyID, session, VersionNo);
                if (IsEnabledTW.ToUpper().Trim() == "Y")
                {
                    //2013.08.01 FSWW, Ramesh M Added For Add if condition for Error log ON/OFF switch control
                    if (LoggingStatus == "on")
                    {
                    }
                    //session = GetSession();
                    //if (ValidateUserLogin(UserName, password, companyID, vehicleID, VersionNo))
                    //{
                    lstDelitems = DALMethods.GetOrderitemdetails(OrderID, session, VersionNo);
                    //}
                }
                CloseSession(session);

            }
            catch (ApplicationException ex)
            {
                if (session != null)
                {
                    CloseSession(session);
                }
                // 2013.07.22 FSWW, Ramesh M Added For Add More Details about calling function in Error log file.
                Logging.LogError(ex, "CustomerID-" + companyID + "\n");
                throw ex;
            }
            catch (Exception ex)
            {
                if (session != null)
                {
                    CloseSession(session);
                }
                // 2013.06.24 FSWW, Ramesh M Added For CR#58976 To Add More Details about calling function in Error log file.
                Logging.LogError(ex, "CustomerID-" + companyID + "\n");
                throw ex;
            }
            finally
            {
                if (session != null)
                {
                    CloseSession(session);
                }
            }

            return lstDelitems;
        }

        /// <summary>
        /// GetDeliveryDetails
        /// Function to get records from delivery details table
        /// </summary>
        /// <param name="UserName">User name</param>
        /// <param name="password">Password</param>
        /// <param name="vehicleID">Vehicle ID</param>
        /// <param name="companyID">Company ID</param>
        /// <param name="orderItemID">Order item ID</param>
        /// <returns>List of delivery details</returns>
        //public List<Status> AddTWDeliveryDetails(List<TWDeliveryDetails> DeliveryDetails, String VersionNo = "")
        public List<Status> AddTWDeliveryDetails(String UserName, String password, String vehicleID, String companyID, Guid SessionID, Guid OrderID, String ProdCode, Int32 CompartmentID, Decimal GrossQty, Decimal NetQty, Decimal DeliveryQty, DateTime DeliveryDateTime, Int32 LoginID, String DeviceID, DateTime DeviceDateTime, Decimal BeforeVolume, Decimal AfterVolume, String IsDelivered, String DeliveryQtyVarianceReason, String TrailerCode, String VersionNo = "")
        {
            List<Status> lstDelitems = new List<Status>();
            ISession session = null;
            Status stts = new Status();
            DataTable dt = new DataTable();
            try
            {
                session = GetSession();
                string IsEnabledTW = DALMethods.IsEnabledTankwagon(companyID, session, VersionNo);
                if (IsEnabledTW.ToUpper().Trim() == "Y")
                {
                    //2013.08.01 FSWW, Ramesh M Added For Add if condition for Error log ON/OFF switch control
                    if (LoggingStatus == "on")
                    {
                    }
                    //session = GetSession();
                    //if (ValidateUserLogin(UserName, password, companyID, vehicleID, VersionNo))
                    //{

                    dt = DALMethods.AddTWDeliveryDetails(companyID, SessionID, OrderID, ProdCode, CompartmentID, GrossQty, NetQty, DeliveryQty, DeliveryDateTime, LoginID, DeviceID, DeviceDateTime, BeforeVolume, AfterVolume, IsDelivered, DeliveryQtyVarianceReason, TrailerCode, session, VersionNo);

                    stts.StatusNew = dt.Rows[0]["StatusNew"].ToString();
                    stts.Reason = dt.Rows[0]["Reason"].ToString();
                    lstDelitems.Add(stts);

                    //} 
                }
                CloseSession(session);

            }
            catch (ApplicationException ex)
            {
                if (session != null)
                {
                    CloseSession(session);
                }
                // 2013.07.22 FSWW, Ramesh M Added For Add More Details about calling function in Error log file.
                Logging.LogError(ex, "AddTWDeliveryDetails : CustomerID-" + companyID + "\n");

                stts.StatusNew = "Fail";
                stts.Reason = ex.Message;
                lstDelitems.Add(stts);
                throw ex;
            }
            catch (Exception ex)
            {
                if (session != null)
                {
                    CloseSession(session);
                }
                // 2013.06.24 FSWW, Ramesh M Added For CR#58976 To Add More Details about calling function in Error log file.
                Logging.LogError(ex, "AddTWDeliveryDetails : CustomerID-" + companyID + "\n");

                stts.StatusNew = "Fail";
                stts.Reason = ex.Message;
                lstDelitems.Add(stts);
                throw ex;
            }
            finally
            {
                if (session != null)
                {
                    CloseSession(session);
                }
            }

            return lstDelitems;
        }
        //Add TankWagon Delivery Details New Added By Vinoth
        public List<Status> AddTWDeliveryDetailsXML(List<TWDeliveryDetails> lsTWDeliveryDetails, String Image, String UserName, String password, String VersionNo = "")
        {
            List<Status> lstDelitems = new List<Status>();
            ISession session = null;
            Status stts = new Status();
            DataTable dt = new DataTable();
            string companyID = "";
            try
            {
                if (lsTWDeliveryDetails.Count > 0)
                {
                    companyID = lsTWDeliveryDetails[0].ClientID.Trim().ToString();
                }
                session = GetSession();
                string IsEnabledTW = DALMethods.IsEnabledTankwagon(companyID, session, VersionNo);
                if (IsEnabledTW.ToUpper().Trim() == "Y")
                {
                    //2013.08.01 FSWW, Ramesh M Added For Add if condition for Error log ON/OFF switch control
                    if (LoggingStatus == "on")
                    {
                    }
                    //session = GetSession();
                    for (var i = 0; i < lsTWDeliveryDetails.Count; i++)
                    {
                        for (var j = i + 1; j < lsTWDeliveryDetails.Count; j++)
                        {
                            if ((lsTWDeliveryDetails[i].ProductCode == lsTWDeliveryDetails[j].ProductCode) && (lsTWDeliveryDetails[i].CompartmentID == lsTWDeliveryDetails[j].CompartmentID))
                            {
                                stts.StatusNew = "Fail";
                                stts.Reason = "The product and compartment combination already exist!...";
                                lstDelitems.Add(stts);
                                return lstDelitems;
                            }
                        }
                    }
                    //if (ValidateUserLogin(UserName, password, companyID, vehicleID, VersionNo))
                    //{
                    lstDelitems = DALMethods.AddTWDeliveryDetailsXML(lsTWDeliveryDetails, Image, session, VersionNo);

                    //} 
                }
                CloseSession(session);

            }
            catch (ApplicationException ex)
            {
                if (session != null)
                {
                    CloseSession(session);
                }
                // 2013.07.22 FSWW, Ramesh M Added For Add More Details about calling function in Error log file.
                Logging.LogError(ex, "AddTWDeliveryDetailsXML CustomerID-" + "" + "\n");

                stts.StatusNew = "Fail";
                stts.Reason = ex.Message;
                lstDelitems.Add(stts);
                throw ex;
            }
            catch (Exception ex)
            {
                if (session != null)
                {
                    CloseSession(session);
                }
                // 2013.06.24 FSWW, Ramesh M Added For CR#58976 To Add More Details about calling function in Error log file.
                Logging.LogError(ex, "AddTWDeliveryDetailsXML CustomerID-" + "" + "\n");

                stts.StatusNew = "Fail";
                stts.Reason = ex.Message;
                lstDelitems.Add(stts);
                throw ex;
            }
            finally
            {
                if (session != null)
                {
                    CloseSession(session);
                }
            }
            //foreach (TWDeliveryDetails item in lsTWDeliveryDetails)
            //{

            //    Logging.LogInfoAboutCallingFunction("Function Called:- AddTWDeliveryDetailsXML ; " + item.AfterVolume == null ? "Nil" : item.AfterVolume.ToString());
            //    Logging.LogInfoAboutCallingFunction("Function Called:- AddTWDeliveryDetailsXML ; " + item.BeforeVolume == null ? "Nil" : item.BeforeVolume.ToString());

            //    Logging.LogInfoAboutCallingFunction("Function Called:- AddTWDeliveryDetailsXML ; " + item.ClientID == null ? "Nil" : item.ClientID.ToString());
            //    Logging.LogInfoAboutCallingFunction("Function Called:- AddTWDeliveryDetailsXML ; " + item.CompartmentID == null ? "Nil" : item.CompartmentID.ToString());
            //    Logging.LogInfoAboutCallingFunction("Function Called:- AddTWDeliveryDetailsXML ; " + item.DeviceDateTime == null ? "Nil" : item.DeviceDateTime.ToString());
            //    Logging.LogInfoAboutCallingFunction("Function Called:- AddTWDeliveryDetailsXML ; " + item.DeviceID == null ? "Nil" : item.DeviceID.ToString());

            //    Logging.LogInfoAboutCallingFunction("Function Called:- AddTWDeliveryDetailsXML ; " + item.DeliveryDateTime == null ? "Nil" : item.DeliveryDateTime.ToString());
            //    Logging.LogInfoAboutCallingFunction("Function Called:- AddTWDeliveryDetailsXML ; " + item.DeliveryQty == null ? "Nil" : item.DeliveryQty.ToString());
            //    Logging.LogInfoAboutCallingFunction("Function Called:- AddTWDeliveryDetailsXML ; " + item.DeliveryQtyVarianceReason == null ? "Nil" : item.DeliveryQtyVarianceReason.ToString());
            //    Logging.LogInfoAboutCallingFunction("Function Called:- AddTWDeliveryDetailsXML ; " + item.GrossQty == null ? "Nil" : item.GrossQty.ToString());
            //    Logging.LogInfoAboutCallingFunction("Function Called:- AddTWDeliveryDetailsXML ; " + item.IsDelivered == null ? "Nil" : item.IsDelivered.ToString());
            //    Logging.LogInfoAboutCallingFunction("Function Called:- AddTWDeliveryDetailsXML ; " + item.LoginID == null ? "Nil" : item.LoginID.ToString());
            //    Logging.LogInfoAboutCallingFunction("Function Called:- AddTWDeliveryDetailsXML ; " + item.NetQty == null ? "Nil" : item.NetQty.ToString());
            //    Logging.LogInfoAboutCallingFunction("Function Called:- AddTWDeliveryDetailsXML ; " + item.OrderItemID == null ? "Nil" : item.OrderItemID.ToString());
            //    Logging.LogInfoAboutCallingFunction("Function Called:- AddTWDeliveryDetailsXML ; " + item.ProductCode == null ? "Nil" : item.ProductCode.ToString());
            //    Logging.LogInfoAboutCallingFunction("Function Called:- AddTWDeliveryDetailsXML ; " + item.SessionID == null ? "Nil" : item.SessionID.ToString());
            //    Logging.LogInfoAboutCallingFunction("Function Called:- AddTWDeliveryDetailsXML ; " + item.TrailerCode == null ? "Nil" : item.TrailerCode.ToString());
            //}

            //stts.StatusNew = "FAIL";
            //stts.Reason = "Order Delivery FAILED";
            //lstDelitems.Add(stts);

            return lstDelitems;
        }


        //Get EOD Details Added By Vinoth
        public List<VehicleCompartment> GetEODDetails(String UserName, String password, String vehicleID, Int32 UpdatedBy, String SessionID, String companyID, String VersionNo = "")
        {
            List<VehicleCompartment> lstVehicleCompartmentDetails = new List<VehicleCompartment>();
            //Vehicle veh = new Vehicle();
            //veh.VehicleCode = "test";
            //ve.BolCompartment.Add(veh);
            //lstVehicleCompartmentDetails.Add(ve);

            Guid sid = new Guid(SessionID);
            ISession session = null;
            try
            {
                session = GetSession();
                string IsEnabledTW = DALMethods.IsEnabledTankwagon(companyID, session, VersionNo);
                if (IsEnabledTW.ToUpper().Trim() == "Y")
                {
                    //2013.08.01 FSWW, Ramesh M Added For Add if condition for Error log ON/OFF switch control
                    if (LoggingStatus == "on")
                    {
                    }
                    if (ValidateUserLogin(UserName, password, companyID, vehicleID, VersionNo))
                    {
                        int newvehicleID = DALMethods.GetVehicleID(vehicleID, companyID, session, "");
                        lstVehicleCompartmentDetails = DALMethods.GetVehicleCompartment(companyID, newvehicleID, session, VersionNo);

                        for (int i = 0; i < lstVehicleCompartmentDetails.Count; i++)
                        {
                            VehicleCompartment ve = new VehicleCompartment();
                            ve.BolCompartment = DALMethods.GetEODDetails(UpdatedBy, lstVehicleCompartmentDetails[i].CompartmentID, SessionID, session, VersionNo);
                            lstVehicleCompartmentDetails[i].BolCompartment = new List<BOLCompartments>();
                            if (ve.BolCompartment.Count > 0)
                            {
                                for (int j = 0; j < ve.BolCompartment.Count; j++)
                                {
                                    BOLCompartments be = new BOLCompartments();
                                    be.BOLHdrID = ve.BolCompartment[j].BOLHdrID;
                                    be.BOLItemID = ve.BolCompartment[j].BOLItemID;
                                    be.BOLDatetime = ve.BolCompartment[j].BOLDatetime;
                                    be.BOLNo = ve.BolCompartment[j].BOLNo;
                                    be.CompartmentID = ve.BolCompartment[j].CompartmentID;
                                    be.SupplierCode = ve.BolCompartment[j].SupplierCode;
                                    be.SupplyPointCode = ve.BolCompartment[j].SupplyPointCode;
                                    be.ProdCode = ve.BolCompartment[j].ProdCode;
                                    be.GrossQty = ve.BolCompartment[j].GrossQty;
                                    be.OrderedQty = ve.BolCompartment[j].OrderedQty;
                                    be.NetQty = ve.BolCompartment[j].NetQty;
                                    be.SystrxNo = ve.BolCompartment[j].SystrxNo;
                                    be.SystrxLine = ve.BolCompartment[j].SystrxLine;
                                    if (!string.IsNullOrEmpty(ve.BolCompartment[j].Notes))
                                        be.Notes = ve.BolCompartment[j].Notes;
                                    else
                                        be.Notes = "";
                                    be.AvailbleQty = ve.BolCompartment[j].AvailbleQty;
                                    be.SalesQty = ve.BolCompartment[j].SalesQty;
                                    lstVehicleCompartmentDetails[i].BolCompartment.Add(be);
                                }
                            }
                            else
                            {
                                //BOLCompartments be = new BOLCompartments();
                                lstVehicleCompartmentDetails[i].BolCompartment.Add(null);

                            }
                            if (i == 0)
                            {
                                ve.VehicleMeterTotalizer = DALMethods.GetVehicleMetersTotalizer(companyID, newvehicleID, 1, sid, session, VersionNo);
                                if (ve.VehicleMeterTotalizer.Count > 0)
                                {
                                    lstVehicleCompartmentDetails[i].VehicleMeterTotalizer = new List<VehicleMetersTotalizer>();
                                    for (int j = 0; j < ve.VehicleMeterTotalizer.Count; j++)
                                    {
                                        VehicleMetersTotalizer vmt = new VehicleMetersTotalizer();
                                        vmt.MeterID = ve.VehicleMeterTotalizer[j].MeterID;
                                        vmt.MeterTotal = ve.VehicleMeterTotalizer[j].MeterTotal;
                                        vmt.ShiftTotal = ve.VehicleMeterTotalizer[j].ShiftTotal;
                                        vmt.Total = ve.VehicleMeterTotalizer[j].Total;
                                        vmt.Code = ve.VehicleMeterTotalizer[j].Code;
                                        lstVehicleCompartmentDetails[i].VehicleMeterTotalizer.Add(vmt);
                                    }
                                }
                                ve.VehicleINSiteID = DALMethods.GetVehicleSiteID(newvehicleID, companyID, session, VersionNo);
                                if (ve.VehicleINSiteID.Count > 0)
                                {
                                    lstVehicleCompartmentDetails[i].VehicleINSiteID = new List<Cloud_TW_GetVehicleSiteID>();
                                    for (int j = 0; j < ve.VehicleINSiteID.Count; j++)
                                    {
                                        Cloud_TW_GetVehicleSiteID vid = new Cloud_TW_GetVehicleSiteID();
                                        vid.Code = ve.VehicleINSiteID[j].Code;
                                        vid.CustomerID = ve.VehicleINSiteID[j].CustomerID;
                                        vid.SiteID = ve.VehicleINSiteID[j].SiteID;
                                        vid.LastModifiedDtTm = ve.VehicleINSiteID[j].LastModifiedDtTm;
                                        vid.LongDescr = ve.VehicleINSiteID[j].LongDescr;
                                        lstVehicleCompartmentDetails[i].VehicleINSiteID.Add(vid);
                                    }
                                }

                            }
                        }

                    }
                }
                CloseSession(session);

            }
            catch (ApplicationException ex)
            {
                if (session != null)
                {
                    CloseSession(session);
                }
                // 2013.07.22 FSWW, Ramesh M Added For Add More Details about calling function in Error log file.
                Logging.LogError(ex, "GetEODDetails : CustomerID-" + companyID + "\n");
                throw ex;
            }
            catch (Exception ex)
            {
                if (session != null)
                {
                    CloseSession(session);
                }
                // 2013.06.24 FSWW, Ramesh M Added For CR#58976 To Add More Details about calling function in Error log file.
                Logging.LogError(ex, "GetEODDetails : CustomerID-" + companyID + "\n");
                throw ex;
            }
            finally
            {
                if (session != null)
                {
                    CloseSession(session);
                }
            }
            return lstVehicleCompartmentDetails;

        }

        //Get EOD Details Added By Vinoth
        public List<VehicleCompartment> GetBODDetails(String UserName, String password, String vehicleID, Int32 UpdatedBy, String companyID, String VersionNo = "")
        {
            List<VehicleCompartment> lstVehicleCompartmentDetails = new List<VehicleCompartment>();
            //Vehicle veh = new Vehicle();
            //veh.VehicleCode = "test";
            //ve.BolCompartment.Add(veh);
            //lstVehicleCompartmentDetails.Add(ve);

            ISession session = null;
            try
            {
                session = GetSession();
                string IsEnabledTW = DALMethods.IsEnabledTankwagon(companyID, session, VersionNo);
                if (IsEnabledTW.ToUpper().Trim() == "Y")
                {
                    //2013.08.01 FSWW, Ramesh M Added For Add if condition for Error log ON/OFF switch control
                    if (LoggingStatus == "on")
                    {
                    }
                    //session = GetSession();
                    if (ValidateUserLogin(UserName, password, companyID, vehicleID, VersionNo))
                    {
                        int newvehicleID = DALMethods.GetVehicleID(vehicleID, companyID, session, "");
                        lstVehicleCompartmentDetails = DALMethods.GetVehicleCompartment(companyID, newvehicleID, session, VersionNo);

                        for (int i = 0; i < lstVehicleCompartmentDetails.Count; i++)
                        {
                            VehicleCompartment ve = new VehicleCompartment();
                            ve.BolCompartment = DALMethods.GetBODDetails(newvehicleID, companyID, "Y", lstVehicleCompartmentDetails[i].CompartmentID, session, VersionNo);
                            if (ve.BolCompartment.Count > 0)
                            {
                                lstVehicleCompartmentDetails[i].BolCompartment = new List<BOLCompartments>();

                            }
                            //lstVehicleCompartmentDetails[i].BolCompartment = new List<BOLCompartments>();

                            for (int j = 0; j < ve.BolCompartment.Count; j++)
                            {
                                BOLCompartments be = new BOLCompartments();
                                be.BOLHdrID = ve.BolCompartment[j].BOLHdrID;
                                be.BOLItemID = ve.BolCompartment[j].BOLItemID;
                                be.BOLDatetime = ve.BolCompartment[j].BOLDatetime;
                                be.BOLNo = ve.BolCompartment[j].BOLNo;
                                be.CompartmentID = ve.BolCompartment[j].CompartmentID;
                                be.SupplierCode = ve.BolCompartment[j].SupplierCode;
                                be.SupplyPointCode = ve.BolCompartment[j].SupplyPointCode;
                                be.ProdCode = ve.BolCompartment[j].ProdCode;
                                be.GrossQty = ve.BolCompartment[j].GrossQty;
                                be.OrderedQty = ve.BolCompartment[j].OrderedQty;
                                be.NetQty = ve.BolCompartment[j].NetQty;
                                be.SystrxNo = ve.BolCompartment[j].SystrxNo;
                                be.SystrxLine = ve.BolCompartment[j].SystrxLine;
                                if (!string.IsNullOrEmpty(ve.BolCompartment[j].Notes))
                                    be.Notes = ve.BolCompartment[j].Notes;
                                else
                                    be.Notes = "";
                                be.AvailbleQty = ve.BolCompartment[j].AvailbleQty;
                                be.SalesQty = ve.BolCompartment[j].SalesQty;
                                //be.SalesQty = Convert.ToDecimal(ve.BolCompartment[j].SalesQty.ToString("#.##"));
                                lstVehicleCompartmentDetails[i].BolCompartment.Add(be);
                            }
                            if (i == 0)
                            {
                                ve.VehicleMeter = DALMethods.GetVehicleMeters(companyID, newvehicleID, session, VersionNo);
                                if (ve.VehicleMeter.Count > 0)
                                {
                                    lstVehicleCompartmentDetails[i].VehicleMeter = new List<VehicleMeters>();
                                    for (int j = 0; j < ve.VehicleMeter.Count; j++)
                                    {
                                        VehicleMeters vm = new VehicleMeters();
                                        vm.MeterID = ve.VehicleMeter[j].MeterID;
                                        vm.VehicleID = ve.VehicleMeter[j].VehicleID;
                                        vm.CustomerID = ve.VehicleMeter[j].CustomerID;
                                        vm.Code = ve.VehicleMeter[j].Code;
                                        vm.NeedUpdate = ve.VehicleMeter[j].NeedUpdate;
                                        lstVehicleCompartmentDetails[i].VehicleMeter.Add(vm);
                                    }
                                }
                                ve.VehicleMeterTotalizer = DALMethods.GetVehicleMetersTotalizer(companyID, newvehicleID, 0, Guid.NewGuid(), session, VersionNo);
                                if (ve.VehicleMeterTotalizer.Count > 0)
                                {
                                    lstVehicleCompartmentDetails[i].VehicleMeterTotalizer = new List<VehicleMetersTotalizer>();
                                    for (int j = 0; j < ve.VehicleMeterTotalizer.Count; j++)
                                    {
                                        VehicleMetersTotalizer vmt = new VehicleMetersTotalizer();
                                        vmt.MeterID = ve.VehicleMeterTotalizer[j].MeterID;
                                        vmt.MeterTotal = ve.VehicleMeterTotalizer[j].MeterTotal;
                                        vmt.ShiftTotal = ve.VehicleMeterTotalizer[j].ShiftTotal;
                                        vmt.Total = ve.VehicleMeterTotalizer[j].Total;
                                        vmt.Code = ve.VehicleMeterTotalizer[j].Code;
                                        lstVehicleCompartmentDetails[i].VehicleMeterTotalizer.Add(vmt);
                                    }
                                }
                                ve.VehicleINSiteID = DALMethods.GetVehicleSiteID(newvehicleID, companyID, session, VersionNo);
                                if (ve.VehicleINSiteID.Count > 0)
                                {
                                    lstVehicleCompartmentDetails[i].VehicleINSiteID = new List<Cloud_TW_GetVehicleSiteID>();
                                    for (int j = 0; j < ve.VehicleINSiteID.Count; j++)
                                    {
                                        Cloud_TW_GetVehicleSiteID vid = new Cloud_TW_GetVehicleSiteID();
                                        vid.Code = ve.VehicleINSiteID[j].Code;
                                        vid.CustomerID = ve.VehicleINSiteID[j].CustomerID;
                                        vid.SiteID = ve.VehicleINSiteID[j].SiteID;
                                        vid.LastModifiedDtTm = ve.VehicleINSiteID[j].LastModifiedDtTm;
                                        vid.LongDescr = ve.VehicleINSiteID[j].LongDescr;
                                        lstVehicleCompartmentDetails[i].VehicleINSiteID.Add(vid);
                                    }
                                }
                            }
                        }
                    }
                }
                CloseSession(session);

            }
            catch (ApplicationException ex)
            {
                if (session != null)
                {
                    CloseSession(session);
                }
                // 2013.07.22 FSWW, Ramesh M Added For Add More Details about calling function in Error log file.
                Logging.LogError(ex, "GetBODDetails : CustomerID-" + companyID + "\n");
                throw ex;
            }
            catch (Exception ex)
            {
                if (session != null)
                {
                    CloseSession(session);
                }
                // 2013.06.24 FSWW, Ramesh M Added For CR#58976 To Add More Details about calling function in Error log file.
                Logging.LogError(ex, "GetBODDetails : CustomerID-" + companyID + "\n");
                throw ex;
            }
            finally
            {
                if (session != null)
                {
                    CloseSession(session);
                }
            }
            return lstVehicleCompartmentDetails;

        }
        //2013.07.04 FSWW, Ramesh M Added For CR#59047 
        /// <summary>
        /// UpdatedEmptyBODEODDetails
        /// </summary>
        /// <param name="Updatedby"></param>
        /// <param name="ClientID"></param>
        /// <param name="RetainedVehicleID"></param>
        /// <param name="SessionID"></param>
        /// <param name="DeviceTime"></param>
        /// <param name="ProcessType"></param>
        /// <returns></returns>
        /// 
        public Boolean UpdatedEmptyBODEODDetails(Int32 Updatedby, String ClientID, String RetainedVehicleID, Guid SessionID, DateTime DeviceTime, String ProcessType, String VersionNo = "")
        {
            Boolean InsertStatus = false;
            ISession session = null;
            try
            {
                session = GetSession();
                string IsEnabledTW = DALMethods.IsEnabledTankwagon(ClientID, session, VersionNo);
                if (IsEnabledTW.ToUpper().Trim() == "Y")
                {
                    //2013.08.01 FSWW, Ramesh M Added For Add if condition for Error log ON/OFF switch control
                    if (LoggingStatus == "on")
                    {
                    }
                    //session = GetSession();
                    int newvehicleID = DALMethods.GetVehicleID(RetainedVehicleID, ClientID, session, "");
                    DALMethods.UpdatedEmptyEODDetails(Updatedby, ClientID, newvehicleID, SessionID, DeviceTime, ProcessType, session, VersionNo);
                    InsertStatus = true;
                }
                CloseSession(session);
            }
            catch (ApplicationException ex)
            {
                if (session != null)
                {
                    CloseSession(session);
                }
                // 2013.07.22 FSWW, Ramesh M Added For  Add More Details about calling function in Error log file.
                Logging.LogError(ex, "UpdatedEmptyBODEODDetails : SessionID-" + SessionID + "\n");
                InsertStatus = false;
                throw ex;
            }
            catch (Exception ex)
            {
                if (session != null)
                {
                    CloseSession(session);
                }
                // 2013.06.24 FSWW, Ramesh M Added For CR#58976 To Add More Details about calling function in Error log file.
                Logging.LogError(ex, " UpdatedEmptyBODEODDetails : SessionID-" + SessionID + "\n");
                InsertStatus = false;
                throw ex;
            }
            finally
            {
                if (session != null)
                {
                    CloseSession(session);
                }
            }
            return InsertStatus;
        }


        /// <summary>
        /// UpdatedBODDetail
        /// </summary>
        /// <param name="SessionID"></param>
        /// <param name="BreakStartTime"></param>
        /// <param name="BreakEndTime"></param>
        /// <returns></returns>
        public Boolean UpdatedBODDetail(String BOLItemID, Int32 Updatedby, String ClientID, Guid NewSessionID, String VersionNo = "")
        {
            Boolean InsertStatus = false;
            ISession session = null;
            try
            {
                session = GetSession();
                string IsEnabledTW = DALMethods.IsEnabledTankwagon(ClientID, session, VersionNo);
                if (IsEnabledTW.ToUpper().Trim() == "Y")
                {
                    //2013.08.01 FSWW, Ramesh M Added For Add if condition for Error log ON/OFF switch control
                    if (LoggingStatus == "on")
                    {
                    }
                    //session = GetSession();
                    //int newvehicleID = DALMethods.GetVehicleID(RetainedVehicleID.ToString(), ClientID, session, "");
                    DALMethods.UpdatedBODDetails(BOLItemID, Updatedby, ClientID, NewSessionID, session, VersionNo);
                    InsertStatus = true;
                }
                CloseSession(session);
            }
            catch (ApplicationException ex)
            {
                if (session != null)
                {
                    CloseSession(session);
                }
                // 2013.07.22 FSWW, Ramesh M Added For  Add More Details about calling function in Error log file.
                Logging.LogError(ex, "UpdatedBODDetail : BOLItemID-" + BOLItemID + "\n");
                throw ex;
            }
            catch (Exception ex)
            {
                if (session != null)
                {
                    CloseSession(session);
                }
                // 2013.06.24 FSWW, Ramesh M Added For CR#58976 To Add More Details about calling function in Error log file.
                Logging.LogError(ex, "UpdatedBODDetail : BOLItemID-" + BOLItemID + "\n");
                throw ex;
            }
            finally
            {
                if (session != null)
                {
                    CloseSession(session);
                }
            }
            return InsertStatus;
        }

        public Boolean UpdatedBODDetailXML(List<BODDetails> lsBODDetails, List<VehicleMetersTotalizer> lsVehicleMetersTotalizer, String VersionNo = "")
        {
            Boolean InsertStatus = false;
            ISession session = null;
            try
            {
                string ClientID = "";
                if (lsBODDetails.Count > 0)
                {
                    ClientID = lsBODDetails[0].ClientID.Trim().ToString();
                }
                session = GetSession();
                string IsEnabledTW = DALMethods.IsEnabledTankwagon(ClientID, session, VersionNo);
                if (IsEnabledTW.ToUpper().Trim() == "Y")
                {
                    //2013.08.01 FSWW, Ramesh M Added For Add if condition for Error log ON/OFF switch control
                    if (LoggingStatus == "on")
                    {
                    }
                    //session = GetSession();
                    //int newvehicleID = DALMethods.GetVehicleID(RetainedVehicleID.ToString(), ClientID, session, "");
                    DALMethods.UpdatedBODDetailsXML(lsBODDetails, lsVehicleMetersTotalizer, session, VersionNo);
                    InsertStatus = true;
                }
                CloseSession(session);
            }
            catch (ApplicationException ex)
            {
                if (session != null)
                {
                    CloseSession(session);
                }
                // 2013.07.22 FSWW, Ramesh M Added For  Add More Details about calling function in Error log file.
                Logging.LogError(ex, "UpdatedBODDetailXML : BOLItemID-" + "" + "\n");
                throw ex;
            }
            catch (Exception ex)
            {
                if (session != null)
                {
                    CloseSession(session);
                }
                // 2013.06.24 FSWW, Ramesh M Added For CR#58976 To Add More Details about calling function in Error log file.
                Logging.LogError(ex, "UpdatedBODDetailXML : BOLItemID-" + "" + "\n");
                throw ex;
            }
            finally
            {
                if (session != null)
                {
                    CloseSession(session);
                }
            }
            //foreach (BODDetails item in lsBODDetails)
            //{

            //    Logging.LogInfoAboutCallingFunction("Function Called:- UpdatedBODDetail ; " + item.BOLItemID == null ? "Nil" : item.BOLItemID.ToString());
            //    Logging.LogInfoAboutCallingFunction("Function Called:- UpdatedBODDetail ; " + item.ClientID == null ? "Nil" : item.ClientID.ToString());
            //    Logging.LogInfoAboutCallingFunction("Function Called:- UpdatedBODDetail ; " + item.NewSessionID == null ? "Nil" : item.NewSessionID.ToString());
            //    Logging.LogInfoAboutCallingFunction("Function Called:- UpdatedBODDetail ; " + item.Updatedby == null ? "Nil" : item.Updatedby.ToString());
            //}
            return InsertStatus;
        }


        /// <summary>
        /// UpdatedEODDetail
        /// </summary>
        /// <param name="SessionID"></param>
        /// <param name="BreakStartTime"></param>
        /// <param name="BreakEndTime"></param>
        /// <returns></returns>
        public Boolean UpdatedEODDetail(String BOLItemID, Int32 Updatedby, String ClientID, String RetainedVehicleID, String IsRetained, String IsOverShort, Int32 ToSiteID, String VersionNo = "")
        {
            Boolean InsertStatus = false;
            ISession session = null;
            try
            {
                session = GetSession();
                string IsEnabledTW = DALMethods.IsEnabledTankwagon(ClientID, session, VersionNo);
                if (IsEnabledTW.ToUpper().Trim() == "Y")
                {
                    //2013.08.01 FSWW, Ramesh M Added For Add if condition for Error log ON/OFF switch control
                    if (LoggingStatus == "on")
                    {
                    }
                    //session = GetSession();
                    int newvehicleID = DALMethods.GetVehicleID(RetainedVehicleID.ToString(), ClientID, session, "");
                    DALMethods.UpdatedEODDetails(BOLItemID, Updatedby, ClientID, newvehicleID, IsRetained, IsOverShort, ToSiteID, session, VersionNo);
                    InsertStatus = true;
                }
                CloseSession(session);
            }
            catch (ApplicationException ex)
            {
                if (session != null)
                {
                    CloseSession(session);
                }
                // 2013.07.22 FSWW, Ramesh M Added For  Add More Details about calling function in Error log file.
                Logging.LogError(ex, "UpdatedEODDetail : BOLItemID-" + BOLItemID + "\n");
                throw ex;
            }
            catch (Exception ex)
            {
                if (session != null)
                {
                    CloseSession(session);
                }
                // 2013.06.24 FSWW, Ramesh M Added For CR#58976 To Add More Details about calling function in Error log file.
                Logging.LogError(ex, "UpdatedEODDetail : BOLItemID-" + BOLItemID + "\n");
                throw ex;
            }
            finally
            {
                if (session != null)
                {
                    CloseSession(session);
                }
            }

            return InsertStatus;
        }

        public Boolean UpdatedEODDetailXML(List<EODDetails> lsEODDetails, List<VehicleMetersTotalizer> lsVehicleMetersTotalizer, String VersionNo = "")
        {
            Boolean InsertStatus = false;
            ISession session = null;
            try
            {
                session = GetSession();
                string ClientID = "";
                if (lsEODDetails.Count > 0)
                {
                    ClientID = lsEODDetails[0].ClientID.Trim().ToString();
                }
                string IsEnabledTW = DALMethods.IsEnabledTankwagon(ClientID, session, VersionNo);
                if (IsEnabledTW.ToUpper().Trim() == "Y")
                {
                    //2013.08.01 FSWW, Ramesh M Added For Add if condition for Error log ON/OFF switch control
                    if (LoggingStatus == "on")
                    {
                    }
                    //session = GetSession();
                    DALMethods.UpdatedEODDetailsXML(lsEODDetails, lsVehicleMetersTotalizer, session, VersionNo);
                    InsertStatus = true;
                }
                CloseSession(session);
            }
            catch (ApplicationException ex)
            {
                if (session != null)
                {
                    CloseSession(session);
                }
                // 2013.07.22 FSWW, Ramesh M Added For  Add More Details about calling function in Error log file.
                Logging.LogError(ex, "UpdatedEODDetailXML : BOLItemID-" + "" + "\n");
                throw ex;
            }
            catch (Exception ex)
            {
                if (session != null)
                {
                    CloseSession(session);
                }
                // 2013.06.24 FSWW, Ramesh M Added For CR#58976 To Add More Details about calling function in Error log file.
                Logging.LogError(ex, "UpdatedEODDetailXML : BOLItemID-" + "" + "\n");
                throw ex;
            }
            finally
            {
                if (session != null)
                {
                    CloseSession(session);
                }
            }
            //foreach (EODDetails item in lsEODDetails)
            //{

            //    Logging.LogInfoAboutCallingFunction("Function Called:- UpdatedEODDetail ; "  + item.BOLItemID == null ? "Nil" : item.BOLItemID.ToString());
            //    Logging.LogInfoAboutCallingFunction("Function Called:- UpdatedEODDetail ; " + item.ClientID == null ? "Nil" : item.ClientID.ToString());
            //    Logging.LogInfoAboutCallingFunction("Function Called:- UpdatedEODDetail ; " + item.IsOverShort == null ? "Nil" : item.IsOverShort.ToString());
            //    Logging.LogInfoAboutCallingFunction("Function Called:- UpdatedEODDetail ; " +  item.IsRetained == null ? "Nil" : item.IsRetained.ToString());
            //    Logging.LogInfoAboutCallingFunction("Function Called:- UpdatedEODDetail ; " +  item.RetainedVehicleID == null ? "Nil" : item.RetainedVehicleID.ToString());
            //    Logging.LogInfoAboutCallingFunction("Function Called:- UpdatedEODDetail ; " + item.ToSiteID == null ? "Nil" : item.ToSiteID.ToString());
            //    Logging.LogInfoAboutCallingFunction("Function Called:- UpdatedEODDetail ; " + item.Updatedby == null ? "Nil" : item.Updatedby.ToString());
            //}
            return InsertStatus;
        }

        /// <summary>
        /// GetSupplierSupplyPtProducts
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="password"></param>
        /// <param name="vehicleID"></param>
        /// <param name="companyID"></param>
        /// <returns></returns>

        public List<INSite> GetINSite(String UserName, String password, String companyID, String VersionNo = "")
        {
            List<INSite> lstINSite = new List<INSite>();
            //Vehicle veh = new Vehicle();
            //veh.VehicleCode = "test";
            //ve.BolCompartment.Add(veh);
            //lstVehicleCompartmentDetails.Add(ve);

            ISession session = null;
            try
            {
                session = GetSession();
                string IsEnabledTW = DALMethods.IsEnabledTankwagon(companyID, session, VersionNo);
                if (IsEnabledTW.ToUpper().Trim() == "Y")
                {
                    //2013.08.01 FSWW, Ramesh M Added For Add if condition for Error log ON/OFF switch control
                    if (LoggingStatus == "on")
                    {
                    }
                    //session = GetSession();
                    //if (ValidateUserLogin(UserName, password, companyID, vehicleID, VersionNo))
                    //{

                    lstINSite = DALMethods.GetINSite(companyID, session, VersionNo);


                    //}
                }
                CloseSession(session);

            }
            catch (ApplicationException ex)
            {
                if (session != null)
                {
                    CloseSession(session);
                }
                // 2013.07.22 FSWW, Ramesh M Added For Add More Details about calling function in Error log file.
                Logging.LogError(ex, "GetINSite : CustomerID-" + companyID + "\n");
                throw ex;
            }
            catch (Exception ex)
            {
                if (session != null)
                {
                    CloseSession(session);
                }
                // 2013.06.24 FSWW, Ramesh M Added For CR#58976 To Add More Details about calling function in Error log file.
                Logging.LogError(ex, "GetINSite : CustomerID-" + companyID + "\n");
                throw ex;
            }
            finally
            {
                if (session != null)
                {
                    CloseSession(session);
                }
            }
            return lstINSite;

        }

        // 06-26-2014  MadhuVenkat k - Added for CR 64058  - For Add orderDispatchHistory 
        /// <summary>
        /// AddSuppliers
        /// </summary>
        /// <param name="SysTrxNo">SysTrxNo</param>
        /// <param name="companyID">companyID</param>
        /// <param name="password">password</param>
        /// <param name="DefDriverID">DefDriverID</param>
        /// <param name="DefVehicleID">DefVehicleID</param>
        /// <param name="OldDriverID">OldDriverID</param>
        /// <param name="OldVehicleID">OldVehicleID</param>
        /// <returns>True = Inserted successfully, False = Faile</returns>
        public Boolean AddINSite(String companyID, String password, Int32 SiteID, String Code, String LongDescr, DateTime? LastModifiedDtTm, String VersionNo = "")
        {
            Boolean status = false;
            ISession session = null;
            Boolean NeedUpdate = true;
            try
            {
                session = GetSession();
                string IsEnabledTW = DALMethods.IsEnabledTankwagon(companyID, session, VersionNo);
                if (IsEnabledTW.ToUpper().Trim() == "Y")
                {
                    //2013.08.01 FSWW, Ramesh M Added For Add if condition for Error log ON/OFF switch control
                    if (LoggingStatus == "on")
                    {
                    }
                    //session = GetSession();
                    if (ValidateCustomerLogin(companyID, password, VersionNo))
                    {

                        DALMethods.AddINSite(SiteID, Code, LongDescr, LastModifiedDtTm, companyID, session, VersionNo);
                        status = true;
                    }
                }
                CloseSession(session);

            }
            catch (ApplicationException ex)
            {
                if (session != null)
                {
                    CloseSession(session);
                }
                // 2013.07.22 FSWW, Ramesh M Added For Add More Details about calling function in Error log file.
                Logging.LogError(ex, "AddINSite : CustomerID-" + companyID + ", SiteID-" + SiteID + "\n");
                throw ex;
            }
            catch (Exception ex)
            {
                if (session != null)
                {
                    CloseSession(session);
                }
                // 2013.06.24 FSWW, Ramesh M Added For CR#58976 To Add More Details about calling function in Error log file.
                Logging.LogError(ex, "AddINSite : CustomerID-" + companyID + ", SiteID-" + SiteID + "\n");
                throw ex;
            }
            finally
            {
                if (session != null)
                {
                    CloseSession(session);
                }
            }

            return status;
        }

        /// <summary>
        /// GetTWLineFlushProducts
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="password"></param>
        /// <param name="SessionID"></param>
        /// <param name="companyID"></param>
        /// <param name="CompartmentID"></param>
        /// <returns></returns>

        public List<Products> GetTWLineFlushProducts(String UserName, String password, String companyID, Guid SessionID, Int32 CompartmentID, Int32 Type, String VersionNo = "")
        {
            List<Products> lstTWLineFlushProducts = new List<Products>();

            ISession session = null;
            try
            {
                session = GetSession();
                string IsEnabledTW = DALMethods.IsEnabledTankwagon(companyID, session, VersionNo);
                if (IsEnabledTW.ToUpper().Trim() == "Y")
                {
                    //2013.08.01 FSWW, Ramesh M Added For Add if condition for Error log ON/OFF switch control
                    if (LoggingStatus == "on")
                    {
                    }
                    //session = GetSession();
                    //if (ValidateUserLogin(UserName, password, companyID, vehicleID, VersionNo))
                    //{

                    lstTWLineFlushProducts = DALMethods.GetTWLineFlushProducts(companyID, SessionID, CompartmentID, Type, session, VersionNo);


                    //}
                }
                CloseSession(session);

            }
            catch (ApplicationException ex)
            {
                if (session != null)
                {
                    CloseSession(session);
                }
                // 2013.07.22 FSWW, Ramesh M Added For Add More Details about calling function in Error log file.
                Logging.LogError(ex, "GetTWLineFlushProducts : CustomerID-" + companyID + "\n");
                throw ex;
            }
            catch (Exception ex)
            {
                if (session != null)
                {
                    CloseSession(session);
                }
                // 2013.06.24 FSWW, Ramesh M Added For CR#58976 To Add More Details about calling function in Error log file.
                Logging.LogError(ex, "GetTWLineFlushProducts : CustomerID-" + companyID + "\n");
                throw ex;
            }
            finally
            {
                if (session != null)
                {
                    CloseSession(session);
                }
            }
            return lstTWLineFlushProducts;

        }

        /// <summary>
        /// UpdatedTWLineFlushDetails
        /// </summary>
        /// <param name="SessionID"></param>
        /// <param name="CompanyID"></param>
        /// <param name="BOLProdCode"></param>
        /// <param name="CompartmentID"></param>
        /// <param name="Updatedby"></param>
        /// <param name="AvailableQty"></param>
        /// <returns></returns>
        public List<Status> UpdatedTWLineFlushDetail(String CompanyID, Guid SessionID, String BOLProdCode, Int32 CompartmentID, Int32 Updatedby, Decimal AvailableQty, Int32 ToCompartmentID, String vehicleID, Int32 ToSiteID, String VersionNo = "")
        {
            List<Status> lstDelitems = new List<Status>();
            ISession session = null;
            Status stts = new Status();
            DataTable dt = new DataTable();
            try
            {
                session = GetSession();
                string IsEnabledTW = DALMethods.IsEnabledTankwagon(CompanyID, session, VersionNo);
                if (IsEnabledTW.ToUpper().Trim() == "Y")
                {
                    //2013.08.01 FSWW, Ramesh M Added For Add if condition for Error log ON/OFF switch control
                    if (LoggingStatus == "on")
                    {
                    }
                    //session = GetSession();
                    int newvehicleID;
                    newvehicleID = DALMethods.GetVehicleID(vehicleID, CompanyID, session, "");
                    if (DALMethods.IsProductDiffer(SessionID, BOLProdCode, CompanyID, ToCompartmentID, newvehicleID, 0, session, VersionNo) == "TRUE")
                    {
                        //Logging.LogInfoAboutCallingFunction("Function Called:- AddBOLItemHdrWagonXML; " + "BolHdrWagon BolitemWagon Product Code-" + lstBOLItemDetails.ProdCode +"_Fail");
                        stts.StatusNew = "Fail";
                        stts.Reason = "This Compartment has different product..!";
                        lstDelitems.Add(stts);
                        return lstDelitems;
                    }

                    dt = DALMethods.UpdatedTWLineFlushDetails(CompanyID, SessionID, BOLProdCode, CompartmentID, Updatedby, AvailableQty, ToCompartmentID, ToSiteID, newvehicleID, session, VersionNo);

                    stts.StatusNew = dt.Rows[0]["StatusNew"].ToString();
                    stts.Reason = dt.Rows[0]["Reason"].ToString();
                    lstDelitems.Add(stts);
                }
                CloseSession(session);
            }
            catch (ApplicationException ex)
            {
                if (session != null)
                {
                    CloseSession(session);
                }
                // 2013.07.22 FSWW, Ramesh M Added For  Add More Details about calling function in Error log file.
                Logging.LogError(ex, "CompanyID-" + CompanyID + "\n");
                stts.StatusNew = "Fail";
                stts.Reason = ex.Message;
                lstDelitems.Add(stts);
                throw ex;
            }
            catch (Exception ex)
            {
                if (session != null)
                {
                    CloseSession(session);
                }
                // 2013.06.24 FSWW, Ramesh M Added For CR#58976 To Add More Details about calling function in Error log file.
                Logging.LogError(ex, "CompanyID-" + CompanyID + "\n");
                stts.StatusNew = "Fail";
                stts.Reason = ex.Message;
                lstDelitems.Add(stts);
                throw ex;
            }
            finally
            {
                if (session != null)
                {
                    CloseSession(session);
                }
            }
            return lstDelitems;
        }

        // May-14-2015  Vinoth - For Add Add TankWagon VehicleType 
        /// <summary>
        /// AddTWVehicleType
        /// </summary>
        /// <param name="companyID">companyID</param>
        /// <param name="password">password</param>
        /// <param name="VehicleTypeID">VehicleTypeID</param>
        /// <param name="Descr">Descr</param>
        /// <param name="ClientID">ClientID</param>
        /// <param name="VersionNo">VersionNo</param>
        /// <returns>Return true when data add or updated successfully return false </returns>
        public Boolean AddTWVehicleType(String companyID, String password, Int32 VehicleTypeID, String Descr, Int32 ClientID, String VersionNo = "")
        {
            Boolean status = false;
            ISession session = null;
            Boolean NeedUpdate = true;
            try
            {
                session = GetSession();
                string IsEnabledTW = DALMethods.IsEnabledTankwagon(companyID, session, VersionNo);
                if (IsEnabledTW.ToUpper().Trim() == "Y")
                {
                    //2013.08.01 FSWW, Ramesh M Added For Add if condition for Error log ON/OFF switch control
                    if (LoggingStatus == "on")
                    {
                    }
                    //session = GetSession();
                    if (ValidateCustomerLogin(companyID, password, VersionNo))
                    {

                        DALMethods.UpdateTWVehicleType(VehicleTypeID, Descr, ClientID, session, VersionNo);
                        status = true;
                    }
                }
                CloseSession(session);

            }
            catch (ApplicationException ex)
            {
                if (session != null)
                {
                    CloseSession(session);
                }
                // 2013.07.22 FSWW, Ramesh M Added For Add More Details about calling function in Error log file.
                Logging.LogError(ex, "AddTWVehicleType : CustomerID-" + companyID + ", VehicleTypeID-" + VehicleTypeID + "\n");
                throw ex;
            }
            catch (Exception ex)
            {
                if (session != null)
                {
                    CloseSession(session);
                }
                // 2013.06.24 FSWW, Ramesh M Added For CR#58976 To Add More Details about calling function in Error log file.
                Logging.LogError(ex, "AddTWVehicleType : CustomerID-" + companyID + ", VehicleTypeID-" + VehicleTypeID + "\n");
                throw ex;
            }
            finally
            {
                if (session != null)
                {
                    CloseSession(session);
                }
            }

            return status;
        }
        // May-15-2015  Vinoth - For Add Add TankWagon Vehicle 
        /// <summary>
        /// GetTWVehicles
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="password"></param>
        /// <param name="companyID"></param>
        /// <returns></returns>
        public List<GetVehicleDetails> GetTWVehicles(String UserName, String password, String companyID, String VehicleID, String VersionNo = "")
        {
            List<GetVehicleDetails> lstVehicle = new List<GetVehicleDetails>();
            ISession session = null;
            try
            {
                session = GetSession();
                string IsEnabledTW = DALMethods.IsEnabledTankwagon(companyID, session, VersionNo);
                if (IsEnabledTW.ToUpper().Trim() == "Y")
                {
                    //2013.08.01 FSWW, Ramesh M Added For Add if condition for Error log ON/OFF switch control
                    if (LoggingStatus == "on")
                    {
                    }
                    //session = GetSession();
                    //if (ValidateUserLogin(UserName, password, companyID, vehicleID))
                    //if (ValidateUserLoginAndSiteID(UserName, password, companyID, vehicleID, VersionNo))
                    //{
                    //    lstVehicle = DALMethods.GettingVehicleDetails(companyID, session, VersionNo);
                    //}
                    int newvehicleID = DALMethods.GetVehicleID(VehicleID, companyID, session, "");
                    lstVehicle = DALMethods.GetTWVehicles(companyID, newvehicleID, session, VersionNo);

                    for (int i = 0; i < lstVehicle.Count; i++)
                    {
                        GetVehicleDetails ve = new GetVehicleDetails();
                        ve.VehicleTypeCompartment = DALMethods.GetTWVehicleTypeCompartment(companyID, lstVehicle[i].VehicleID, session, VersionNo);

                        lstVehicle[i].VehicleTypeCompartment = new List<GetVehicleTypeCompartment>();

                        for (int j = 0; j < ve.VehicleTypeCompartment.Count; j++)
                        {
                            GetVehicleTypeCompartment be = new GetVehicleTypeCompartment();
                            be.CompartmentCode = ve.VehicleTypeCompartment[j].CompartmentCode;
                            be.CompartmentID = ve.VehicleTypeCompartment[j].CompartmentID;
                            lstVehicle[i].VehicleTypeCompartment.Add(be);
                        }
                    }
                }
                CloseSession(session);

            }
            catch (ApplicationException ex)
            {
                if (session != null)
                {
                    CloseSession(session);
                }
                // 2013.07.22 FSWW, Ramesh M Added For Add More Details about calling function in Error log file.
                Logging.LogError(ex, "GetTWVehicles : CustomerID-" + companyID + "\n");
                throw ex;
            }
            catch (Exception ex)
            {
                if (session != null)
                {
                    CloseSession(session);
                }
                // 2013.06.24 FSWW, Ramesh M Added For CR#58976 To Add More Details about calling function in Error log file.
                Logging.LogError(ex, "GetTWVehicles : CustomerID-" + companyID + "\n");
                throw ex;
            }
            finally
            {
                if (session != null)
                {
                    CloseSession(session);
                }
            }
            return lstVehicle;

        }

        /// <summary>
        /// UpdatedTWTruckToTruckTransfer
        /// </summary>
        /// <param name="SessionID"></param>
        /// <param name="CompanyID"></param>
        /// <param name="FromVehicleID"></param>
        /// <param name="FromCompartmentID"></param>
        /// <param name="BOLProdCode"></param>
        /// <param name="LoginID"></param>
        /// <param name="ToVehicleID"></param>
        /// <param name="ToCompartmentID"></param>
        /// <param name="VersionNo"></param>
        /// <returns></returns>
        public List<Status> UpdatedTWTruckToTruckTransfer(Guid SessionID, String CompanyID, String FromVehicleID, Int32 FromCompartmentID, String BOLProdCode, Int32 LoginID, Decimal TransferQty, String ToVehicleID, Int32 ToCompartmentID, DateTime DeviceTime, Int32 Type, String VersionNo = "")
        {
            List<Status> lstDelitems = new List<Status>();
            ISession session = null;
            Status stts = new Status();
            DataTable dt = new DataTable();
            try
            {
                session = GetSession();
                string IsEnabledTW = DALMethods.IsEnabledTankwagon(CompanyID, session, VersionNo);
                if (IsEnabledTW.ToUpper().Trim() == "Y")
                {
                    //2013.08.01 FSWW, Ramesh M Added For Add if condition for Error log ON/OFF switch control
                    if (LoggingStatus == "on")
                    {
                    }
                    //session = GetSession();
                    int FrmVehicleID;
                    FrmVehicleID = DALMethods.GetVehicleID(FromVehicleID, CompanyID, session, VersionNo);
                    //int ToTransferVehicleID;
                    //ToTransferVehicleID = DALMethods.GetVehicleID(ToVehicleID, CompanyID, session, VersionNo);

                    if (DALMethods.IsProductDiffer(SessionID, BOLProdCode, CompanyID, ToCompartmentID, Convert.ToInt32(ToVehicleID), 1, session, VersionNo) == "TRUE")
                    {
                        stts.StatusNew = "Fail";
                        stts.Reason = "Destination compartment has different product..!";
                        lstDelitems.Add(stts);
                        return lstDelitems;
                    }

                    dt = DALMethods.UpdateTWTruckToTruckTransfer(SessionID, CompanyID, FrmVehicleID, FromCompartmentID, BOLProdCode, LoginID, TransferQty, Convert.ToInt32(ToVehicleID), ToCompartmentID, DeviceTime, Type, session, VersionNo);

                    stts.StatusNew = dt.Rows[0]["StatusNew"].ToString();
                    stts.Reason = dt.Rows[0]["Reason"].ToString();
                    lstDelitems.Add(stts);
                }
                CloseSession(session);
            }
            catch (ApplicationException ex)
            {
                if (session != null)
                {
                    CloseSession(session);
                }
                // 2013.07.22 FSWW, Ramesh M Added For  Add More Details about calling function in Error log file.
                Logging.LogError(ex, "CompanyID-" + CompanyID + "\n");
                stts.StatusNew = "Fail";
                stts.Reason = ex.Message;
                lstDelitems.Add(stts);
                throw ex;
            }
            catch (Exception ex)
            {
                if (session != null)
                {
                    CloseSession(session);
                }
                // 2013.06.24 FSWW, Ramesh M Added For CR#58976 To Add More Details about calling function in Error log file.
                Logging.LogError(ex, "CompanyID-" + CompanyID + "\n");
                stts.StatusNew = "Fail";
                stts.Reason = ex.Message;
                lstDelitems.Add(stts);
                throw ex;
            }
            finally
            {
                if (session != null)
                {
                    CloseSession(session);
                }
            }
            return lstDelitems;
        }

        /// <summary>
        /// GetDSHistory
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="password"></param>
        /// <param name="vehicleID"></param>
        /// <param name="SessionID"></param>
        /// <param name="companyID"></param>
        /// <param name="VersionNo"></param>
        public List<DSTWHistory> GetDSTWHistory(String UserName, String password, String vehicleID, Guid SessionID, String companyID, String VersionNo = "")
        {
            List<DSTWHistory> lstDSTWHistory = new List<DSTWHistory>();
            ISession session = null;
            try
            {
                session = GetSession();
                string IsEnabledTW = DALMethods.IsEnabledTankwagon(companyID, session, VersionNo);
                if (IsEnabledTW.ToUpper().Trim() == "Y")
                {
                    //2013.08.01 FSWW, Ramesh M Added For Add if condition for Error log ON/OFF switch control
                    if (LoggingStatus == "on")
                    {
                    }
                    //session = GetSession();
                    if (ValidateUserLogin(UserName, password, companyID, vehicleID, VersionNo))
                    {
                        int newvehicleID = DALMethods.GetVehicleID(vehicleID, companyID, session, "");
                        lstDSTWHistory[0] = new DSTWHistory();
                        DSTWHistory hs = new DSTWHistory();
                        hs.BODHistory = DALMethods.GetBODHistory(companyID, SessionID, session, VersionNo);
                        lstDSTWHistory[0].BODHistory = new List<BOLCompartments>();
                        if (hs.BODHistory.Count > 0)
                        {
                            for (int j = 0; j < hs.BODHistory.Count; j++)
                            {
                                BOLCompartments be = new BOLCompartments();
                                be.BOLHdrID = hs.BODHistory[j].BOLHdrID;
                                be.BOLItemID = hs.BODHistory[j].BOLItemID;
                                be.BOLDatetime = hs.BODHistory[j].BOLDatetime;
                                be.BOLNo = hs.BODHistory[j].BOLNo;
                                be.CompartmentID = hs.BODHistory[j].CompartmentID;
                                be.SupplierCode = hs.BODHistory[j].SupplierCode;
                                be.SupplyPointCode = hs.BODHistory[j].SupplyPointCode;
                                be.ProdCode = hs.BODHistory[j].ProdCode;
                                be.GrossQty = hs.BODHistory[j].GrossQty;
                                be.OrderedQty = hs.BODHistory[j].OrderedQty;
                                be.NetQty = hs.BODHistory[j].NetQty;
                                be.SystrxNo = hs.BODHistory[j].SystrxNo;
                                be.SystrxLine = hs.BODHistory[j].SystrxLine;
                                if (!string.IsNullOrEmpty(hs.BODHistory[j].Notes))
                                    be.Notes = hs.BODHistory[j].Notes;
                                else
                                    be.Notes = "";
                                be.AvailbleQty = hs.BODHistory[j].AvailbleQty;
                                be.SalesQty = hs.BODHistory[j].SalesQty;
                                lstDSTWHistory[0].BODHistory.Add(be);
                            }
                        }
                        hs.EODHistory = DALMethods.GetEODHistory(companyID, SessionID, session, VersionNo);
                        lstDSTWHistory[0].EODHistory = new List<BOLCompartments>();
                        if (hs.EODHistory.Count > 0)
                        {
                            for (int j = 0; j < hs.EODHistory.Count; j++)
                            {
                                BOLCompartments be = new BOLCompartments();
                                be.BOLHdrID = hs.EODHistory[j].BOLHdrID;
                                be.BOLItemID = hs.EODHistory[j].BOLItemID;
                                be.BOLDatetime = hs.EODHistory[j].BOLDatetime;
                                be.BOLNo = hs.EODHistory[j].BOLNo;
                                be.CompartmentID = hs.EODHistory[j].CompartmentID;
                                be.SupplierCode = hs.EODHistory[j].SupplierCode;
                                be.SupplyPointCode = hs.EODHistory[j].SupplyPointCode;
                                be.ProdCode = hs.EODHistory[j].ProdCode;
                                be.GrossQty = hs.EODHistory[j].GrossQty;
                                be.OrderedQty = hs.EODHistory[j].OrderedQty;
                                be.NetQty = hs.EODHistory[j].NetQty;
                                be.SystrxNo = hs.EODHistory[j].SystrxNo;
                                be.SystrxLine = hs.EODHistory[j].SystrxLine;
                                if (!string.IsNullOrEmpty(hs.EODHistory[j].Notes))
                                    be.Notes = hs.EODHistory[j].Notes;
                                else
                                    be.Notes = "";
                                be.AvailbleQty = hs.EODHistory[j].AvailbleQty;
                                be.SalesQty = hs.EODHistory[j].SalesQty;
                                lstDSTWHistory[0].EODHistory.Add(be);
                            }
                        }
                        hs.DeliveryHistory = DALMethods.GetDeliveryHistory(companyID, SessionID, session, VersionNo);
                        lstDSTWHistory[0].DeliveryHistory = new List<DeliveryDetails>();
                        if (hs.DeliveryHistory.Count > 0)
                        {
                            for (int j = 0; j < hs.DeliveryHistory.Count; j++)
                            {
                                DeliveryDetails dd = new DeliveryDetails();
                                dd.OrderItemID = hs.DeliveryHistory[j].OrderItemID;
                                dd.ID = hs.DeliveryHistory[j].ID;
                                dd.GrossQty = hs.DeliveryHistory[j].GrossQty;
                                dd.NetQtyQty = hs.DeliveryHistory[j].NetQtyQty;
                                dd.DeliveryDateTime = hs.DeliveryHistory[j].DeliveryDateTime;
                                dd.BeforeVolume = hs.DeliveryHistory[j].BeforeVolume;
                                dd.AfterVolume = hs.DeliveryHistory[j].AfterVolume;
                                dd.DeliveryQtyVarianceReason = hs.DeliveryHistory[j].DeliveryQtyVarianceReason;
                                dd.GrossQty = hs.EODHistory[j].GrossQty;
                                lstDSTWHistory[0].DeliveryHistory.Add(dd);
                            }
                        }
                        hs.BODVehicleMeterTotalizer = DALMethods.GetVehicleMetersTotalizer(companyID, newvehicleID, 2, SessionID, session, VersionNo);
                        if (hs.BODVehicleMeterTotalizer.Count > 0)
                        {
                            lstDSTWHistory[0].BODVehicleMeterTotalizer = new List<VehicleMetersTotalizer>();
                            for (int j = 0; j < hs.BODVehicleMeterTotalizer.Count; j++)
                            {
                                VehicleMetersTotalizer vmt = new VehicleMetersTotalizer();
                                vmt.MeterID = hs.BODVehicleMeterTotalizer[j].MeterID;
                                vmt.MeterTotal = hs.BODVehicleMeterTotalizer[j].MeterTotal;
                                vmt.ShiftTotal = hs.BODVehicleMeterTotalizer[j].ShiftTotal;
                                vmt.Total = hs.BODVehicleMeterTotalizer[j].Total;
                                vmt.Code = hs.BODVehicleMeterTotalizer[j].Code;
                                lstDSTWHistory[0].BODVehicleMeterTotalizer.Add(vmt);
                            }
                        }
                        hs.EODVehicleMeterTotalizer = DALMethods.GetVehicleMetersTotalizer(companyID, newvehicleID, 3, SessionID, session, VersionNo);
                        if (hs.EODVehicleMeterTotalizer.Count > 0)
                        {
                            lstDSTWHistory[0].EODVehicleMeterTotalizer = new List<VehicleMetersTotalizer>();
                            for (int j = 0; j < hs.EODVehicleMeterTotalizer.Count; j++)
                            {
                                VehicleMetersTotalizer vmt = new VehicleMetersTotalizer();
                                vmt.MeterID = hs.EODVehicleMeterTotalizer[j].MeterID;
                                vmt.MeterTotal = hs.EODVehicleMeterTotalizer[j].MeterTotal;
                                vmt.ShiftTotal = hs.EODVehicleMeterTotalizer[j].ShiftTotal;
                                vmt.Total = hs.EODVehicleMeterTotalizer[j].Total;
                                vmt.Code = hs.EODVehicleMeterTotalizer[j].Code;
                                lstDSTWHistory[0].EODVehicleMeterTotalizer.Add(vmt);
                            }
                        }
                    }
                }
                CloseSession(session);
            }
            catch (ApplicationException ex)
            {
                if (session != null)
                {
                    CloseSession(session);
                }
                // 2013.07.22 FSWW, Ramesh M Added For Add More Details about calling function in Error log file.
                Logging.LogError(ex, "GetDSTWHistory : CustomerID-" + companyID + "\n");
                throw ex;
            }
            catch (Exception ex)
            {
                if (session != null)
                {
                    CloseSession(session);
                }
                // 2013.06.24 FSWW, Ramesh M Added For CR#58976 To Add More Details about calling function in Error log file.
                Logging.LogError(ex, "GetDSTWHistory : CustomerID-" + companyID + "\n");
                throw ex;
            }
            finally
            {
                if (session != null)
                {
                    CloseSession(session);
                }
            }
            return lstDSTWHistory;
        }

        /// <summary>
        /// GetOEStatus
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="password"></param>
        /// <param name="vehicleID"></param>
        /// <param name="companyID"></param>
        /// <param name="VersionNo"></param>
        /// <returns></returns>
        public List<OEStatus> GetOEStatus(String UserName, String password, String vehicleID, String companyID, String VersionNo = "")
        {
            ISession session = null;
            List<OEStatus> lstOEStatus = new List<OEStatus>();
            try
            {
                session = GetSession();

                if (ValidateUserLogin(UserName, password, companyID, vehicleID, VersionNo))
                {
                    lstOEStatus = DALMethods.GetOEStatus(companyID, session, VersionNo);
                }
            }
            catch (Exception ex)
            {
                if (session != null)
                {
                    CloseSession(session);
                }
                Logging.LogError(ex, "GetDSTWHistory : CustomerID-" + companyID + "\n");
                throw ex;
            }
            return lstOEStatus;
        }

        public List<DispatchChangeLoad> GetDispatchChangeLoads(String UserName, String companyID, String VersionNo = "")
        {
            List<DispatchChangeLoad> lstLoads = new List<DispatchChangeLoad>();
            ISession session = null;
            try
            {
                session = GetSession();
                //Int32 loginID = DALMethods.GetUserID(UserName, companyID, session, VersionNo);

                Int32 driverID = DALMethods.GetDriverID(UserName, companyID, session, VersionNo);
                if (driverID == 0)
                {
                    //This exception will be rare if driver id set for current user is 0
                    throw new ApplicationException("Invalid driverID set for current user");
                }

                lstLoads = DALMethods.GetDispatchChangeLoad(companyID, driverID, session, VersionNo);

                CloseSession(session);

            }
            catch (ApplicationException ex)
            {
                if (session != null)
                {
                    CloseSession(session);
                }
                // 2013.07.22 FSWW, Ramesh M Added For Add More Details about calling function in Error log file.
                Logging.LogError(ex, "GetDispatchChangeLoads : CustomerID-" + companyID + ", UserName-" + UserName + "\n");
                throw ex;
            }
            catch (Exception ex)
            {
                if (session != null)
                {
                    CloseSession(session);
                }

                // 2013.07.22 FSWW, Ramesh M Added For Add More Details about calling function in Error log file.
                Logging.LogError(ex, "GetDispatchChangeLoads : CustomerID-" + companyID + ", UserName-" + UserName + "\n");
                //Logging.LogError(ex);
                throw ex;
            }
            finally
            {
                if (session != null)
                {
                    CloseSession(session);
                }
            }

            return lstLoads;
        }

        #endregion
        #endregion ICloudService Members
    }
}