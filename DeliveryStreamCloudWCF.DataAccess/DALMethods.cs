// 2013.10.03  Ramesh M Added For CR#60533 Pre Duty Inspection Called in login page itself
// 2013.10.09  Ramesh M Added For  CR#60620. load status synchronization
// 2013.10.22  Ramesh M,Added For CR#60386.Added PreviousLongtitude,PreviousLatitude
// 2013.12.23  Ramesh M Added For CR#60902 ware house load updation
// 2014.01.10  Ramesh M Added For CR#61759 Added to full From Site business rule
// 2014.01.17  Ramesh M Added For  CR#61759 to get from site list 
// 2014.01.20  Ramesh M Added For  CR#61783 Modified insert query for adverecondition,driverbreak,inspection,inspectiondetails,loginhistory,loginsession,sleeperrig,truckfuelingDetails table added DriverId,VehicleID and CustomerID
// 2014.01.23  Ramesh M Added For CR#61759 Added ShipToID
// 2014.01.28  Ramesh M Added For Support Multi BOL items added ExtSysTrxLine For CR#62038
// 2014.01.30  Ramesh M Added For CR#62039 For inspection Remarks
// 2014.02.06  Ramesh M Added For CR#62166 For DOT OverRide Details
// 2014.02.14  Ramesh M Added For blocking same vehicle code inserted for same company. CR#62289
// 2014.02.14  Ramesh M Added For getting vehicleid from  vehicle code and customerid for  CR#62289 and commented origional vehicleid
// 2014.02.17  Ramesh M Added UserType For Warehouse user duplication CR#62289
// 2014.02.20  Ramesh M Added For CR#62292 For driver summary log
// 2014.02.21  Ramesh M Modified SupplierID as input for GetDataByAllID function,earlier it was SupplyPtID, its bug so modified.
// 2014.02.24  Ramesh M Added For CR#62406 For DriverID,VechileID,UserLoginID on login itself
// 2014.03.04  Ramesh M Commented For CR#62032 Loading order item component for all the orders
// 2014.03.05  Ramesh M Added For CR#62301 For City added
// 2014.03.17  Ramesh M Added For CR#62668 to get home terminal details
// 2014.03.17  Ramesh M Added For CR#62613 to Auto logoff through Ipad
// 2014.03.18  Ramesh M Added For CR#62719 added  TrailerCode in input parameters
// 2014.03.20  Ramesh M Added For CR#62322 added  Version testing method
// 05-14-2014  MadhuVenkat K - Added for CR 63396 - Add Time Remaining Section to Driver Summary
// 05-20-2014  MadhuVenkat k - Added for CR 63346 - PO & Priority No to Load Information Screen 
// 06-26-2014  MadhuVenkat k - Added for CR 64058  - For Add orderDispatchHistory
// 06-26-2014  MadhuVenkat k - Added for CR 64058  - For Update status in OrderDipatchHistory 
// 06-26-2014  MadhuVenkat k - Added for CR 64058  - For Geting List of OrderDipatchHistory details
// 08-14-2014  MadhuVenkat K - Added for CR 64639 - Add StatusUpdate to GpsHistory
// 08-14-2014  MadhuVenkat K - Added for CR 64639 - Add CurrentDriverStatus to Driver Summary
// 09-09-2014  CR#64208, Madhu, Add Modified date to GetInspectionElementsData
// 10-07-2014  MadhuVenkat k - Added for CR 65183  - Added to check the VehicleID for record exist instead of Vehicle Code in Vehicle table
// 10-17-2014  MadhuVenkat k - Added for CR 65285  -  Order processing is stalling when ShipTo-> DestNotes exceeds 200 chars. 
// 2015.02.02  Madhu Added For CR#66160 For Add App Version No in the login session table for every login sessions
// 2015.02.05  Madhu Added For CR#66160 To Add App Version No in the login history table for every login
// 03-25-2015  MadhuVenkat k - Added for CR 66587  -  Application should deliver the Pre-Blend products and shown the Quantity details in Ship Doc.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DeliveryStreamCloudWCF.Utils;
using DeliveryStreamCloudWCF.Entities;
using DeliveryStreamCloudWCF.DataAccess.DALTableAdapters;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Xml.Serialization;
using System.Configuration;

namespace DeliveryStreamCloudWCF.DataAccess
{
    /// <summary>
    /// DALMethods
    /// DALMethods class
    /// </summary>
    public class DALMethods
    {
        private static readonly object tranLock = new object();

        #region Login Settings
        /// <summary>
        /// ValidateUserLogin
        /// Fuction to validate user credientials
        /// </summary>
        /// <param name="userID">Login user ID</param>
        /// <param name="password">Login user password</param>
        /// <param name="companyID">Login user customer ID</param>       
        /// <param name="session">Session object</param>
        /// <returns>True = Valid user credientials, False = Failed</returns>

        public static bool ValidateUserLogin(String userID, String password, String companyID, ISession session, String VersionNo = "")
        {
            //try
            //{
            LoginUserTableAdapter ta = new LoginUserTableAdapter();
            ta.CurrentConnection = session;
            //byte[] b1 = System.Text.Encoding.UTF8.GetBytes(userID);
            // byte[] b2 = System.Text.Encoding.ASCII.GetBytes(myString);
            List<DAL.LoginUserRow> lst = ta.GetDataByCredentials(userID, password, companyID).Select().Cast<DAL.LoginUserRow>().ToList();
            return lst.Count > 0;
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}

        }

        /// <summary>
        /// 2013.4.30, Suresh Madhesan, CR#?
        /// Function to validate user and get the usertype
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="password"></param>
        /// <param name="companyID"></param>
        /// <param name="session"></param>       
        /// <returns></returns>

        public static String ValidateUserAndGetType(String userID, String password, String companyID, String UserType, ISession session, String VersionNo = "")
        {
            LoginUserTableAdapter ta = new LoginUserTableAdapter();
            ta.CurrentConnection = session;
            //byte[] b1 = System.Text.Encoding.UTF8.GetBytes(userID);
            List<DAL.LoginUserRow> lst = ta.GetDataByCredentialsAndGetType(userID, password, companyID, UserType).Select().Cast<DAL.LoginUserRow>().ToList();

            // Check for valid user
            if (lst.Count == 1)
            {
                return lst[0].UserType_Ext;
            }
            else
            {
                return "F";
            }
        }

        //2013.5.6, Suresh Madhesan, 
        /// <summary>
        /// Function to get number of login count
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="companyID"></param>
        /// <param name="session"></param>
        /// <returns></returns>
        public static Int32 GetLoginCount(String userName, String companyID, ISession session, String VersionNo = "")
        {
            LoginUserTableAdapter ta = new LoginUserTableAdapter();
            ta.CurrentConnection = session;
            Int32 iCount = Convert.ToInt32(ta.GetLoginCount(userName, companyID));
            return iCount;
        }

        /// <summary>
        /// Get Vehicle ID
        /// </summary>
        /// <param name="vehicleCode">Vehicle Code</param>
        /// <param name="customerID">Customer ID</param>
        /// <param name="session">session object</param>
        /// <returns>vehicle id</returns>
        public static Int32 GetVehicleID(String vehicleCode, String customerID, ISession session, String VersionNo = "")
        {
            VehicleTableAdapter ta = new VehicleTableAdapter();
            ta.CurrentConnection = session;
            List<DAL.VehicleRow> lst = ta.GetByVehicleCode(vehicleCode, customerID).Select().Cast<DAL.VehicleRow>().ToList();
            if (lst.Count > 0)
            {
                return lst[0].ID_Ext;
            }
            return 0;
        }

        //2013.09.05 FSWW, Ramesh M Added For CR#59829... To validate site code if user type is "W" Warehouse user
        /// <summary>
        /// GetSiteID
        /// </summary>
        /// <param name="SiteCode"></param>
        /// <param name="customerID"></param>
        /// <param name="session"></param>
        /// <returns></returns>
        public static Int32 GetSiteID(String SiteCode, String customerID, ISession session, String VersionNo = "")
        {
            WarehouseTableAdapter ta = new WarehouseTableAdapter();
            ta.CurrentConnection = session;
            List<DAL.WarehouseRow> lst = ta.GetSiteIDByCustomerID(customerID, SiteCode).Select().Cast<DAL.WarehouseRow>().ToList();
            if (lst.Count > 0)
            {
                return lst[0].SiteID_Ext;
            }
            return 0;
        }

        /// <summary>
        /// ValidateCustomerLogin
        /// Function to validate customer login
        /// </summary>
        /// <param name="companyID">Company ID</param>
        /// <param name="password">Password</param>
        /// <param name="session">Session object</param>
        /// <returns>True = Valid customer credientials, False = Failed</returns>
        public static bool ValidateCustomerLogin(String companyID, String password, ISession session, String VersionNo = "")
        {
            CustomerTableAdapter ta = new CustomerTableAdapter();
            ta.CurrentConnection = session;
            List<DAL.CustomerRow> lst = ta.CheckLoginDetails(companyID, password).Select().Cast<DAL.CustomerRow>().ToList();
            return lst.Count > 0;
        }

        // 2013.06.21 Ramesh M for CR#?.. To Validate VersionNo in Database
        public static String GetVersionNo(String VersionNo, ISession session)
        {
            //string ResultVersionNo = null;
            //VersionTableAdapter ta = new VersionTableAdapter();
            //ta.CurrentConnection = session;
            //ResultVersionNo=ta.GetVersionNo(VersionNo);
            //return ResultVersionNo;

            String ResultVersionNo = null;
            VersionTableAdapter ta = new VersionTableAdapter();
            ta.CurrentConnection = session;
            ResultVersionNo = ta.GetVersionNo().ToString();

            return ResultVersionNo;
        }

        // 2014.03.17  Ramesh M Added For CR#62613 to get home terminal details
        public static List<LoginHomeTerminalDetails> GetHomeTerminalDetails(String userID, String password, String companyID, String UserType, ISession session, String VersionNo)
        {
            List<LoginHomeTerminalDetails> lstHomeTerminalDetails = new List<LoginHomeTerminalDetails>();
            String ePassword = Encryption.doEncrypt(password);
            LoginHomeTerminalDetailsTableAdapter ta = new LoginHomeTerminalDetailsTableAdapter();
            ta.CurrentConnection = session;
            lstHomeTerminalDetails = ta.GetLoginHomeTerminalDetails(userID, ePassword, companyID, UserType, VersionNo).Select().Cast<DAL.LoginHomeTerminalDetailsRow>().ToList().ToEntities();

            return lstHomeTerminalDetails;
        }


        // 06-26-2014  MadhuVenkat k - Added for CR 64058  - For Get in List of OrderDipatchHistory details
        public static List<OrderDispatchHistory> GetOrderDispatchHistory(String companyID, Int32 OldDriverID, Int32 OldVehicleID, ISession session, String VersionNo)
        {
            List<OrderDispatchHistory> lstOrderDispatchHistoryDetails = new List<OrderDispatchHistory>();
            try
            {


                OrderDispatchHistoryTableAdapter ta = new OrderDispatchHistoryTableAdapter();
                ta.CurrentConnection = session;
                lstOrderDispatchHistoryDetails = ta.GetDataByOrderDispatchHistory(companyID, OldDriverID, OldVehicleID).Select().Cast<DAL.OrderDispatchHistoryRow>().ToList().ToEntities();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstOrderDispatchHistoryDetails;
        }

        // 2014.03.17  Ramesh M Added For CR#62613 to Auto logoff through Ipad
        public static Boolean EndPreviousLogin(String userID, String password, String companyID, String UserType, String vehicleID, String deviceToken, DateTime deviceTime, String DeviceID, DateTime GMT, String TrailerCode, ISession session, String VersionNo)
        {
            Boolean bEndPreviousSession = false;
            Cloud_EndPrevSessionTableAdapter ta = new Cloud_EndPrevSessionTableAdapter();
            ta.CurrentConnection = session;
            ta.EndPreviousSession(userID, vehicleID, Convert.ToInt32(companyID), deviceToken, deviceTime, VersionNo, UserType, DeviceID, GMT, TrailerCode);

            return bEndPreviousSession;
        }


        #endregion Login Settings

        #region Get Details

        /// <summary>
        /// Function to get last logofftime from login history
        /// </summary>
        /// <param name="sessionID">SessionID</param>
        /// <returns>DateTime</returns>

        public static DateTime? GetLastLogoffTime(Guid sessionID, ISession session, String VersionNo = "")
        {
            DateTime lastLogoffTime;
            LoginHistoryTableAdapter ta = new LoginHistoryTableAdapter();
            ta.CurrentConnection = session;
            lastLogoffTime = Convert.ToDateTime(ta.GetLastLogoffTime(sessionID));

            if (lastLogoffTime == DateTime.MinValue)
            {
                return null;
            }

            return lastLogoffTime;
        }

        /// <summary>
        /// ValidateUserSession
        /// Fuction to validate user session
        /// </summary>
        /// <param name="sessionID">Session ID</param>
        /// <param name="DeviceToken">Device Token</param>
        /// <returns>True = Valid user credientials, False = Failed</returns>
        public static bool ValidateUserSession(Guid sessionID, ISession session, String VersionNo = "")
        {
            LoginHistoryTableAdapter ta = new LoginHistoryTableAdapter();
            ta.CurrentConnection = session;
            List<DAL.LoginHistoryRow> lst = ta.GetDataBySession(sessionID).Select().Cast<DAL.LoginHistoryRow>().ToList();
            return lst.Count > 0;
        }

        public static string GetLoadtypeByLoadID(Guid LoadID, ISession session, String VersionNo = "")
        {
            string sLoadType = string.Empty;
            LoadTableAdapter ta = new LoadTableAdapter();
            ta.CurrentConnection = session;
            sLoadType = ta.GetLoadTypeByLoadID(LoadID).ToString();
            return sLoadType;
        }

        /// <summary>
        /// GetDriverID
        /// Function to get the driver Id of customer
        /// </summary>
        /// <param name="userName">Customer username</param>
        /// <param name="customerID">Customer ID</param>
        /// <param name="session">Session object</param>
        /// <returns>Driver ID</returns>
        public static Int32 GetDriverID(String userName, String customerID, ISession session, String VersionNo = "")
        {
            Int32 driverID = 0;
            LoginUserTableAdapter ta = new LoginUserTableAdapter();
            ta.CurrentConnection = session;
            List<DAL.LoginUserRow> lst = ta.GetDataByUserName(userName, customerID).Select().Cast<DAL.LoginUserRow>().ToList();
            if (lst.Count > 0)
            {
                DAL.LoginUserRow row = lst[0];
                driverID = row.DriverID_Ext;
            }

            return driverID;
        }
        // 2014.02.24  Ramesh M Added For CR#62406 For DriverID,VechileID,UserLoginID on login itself
        public static Int32 GetLoginuserSiteID(String userName, String customerID, ISession session, String VersionNo = "")
        {
            Int32 SiteID = 0;
            LoginUserTableAdapter ta = new LoginUserTableAdapter();
            ta.CurrentConnection = session;
            List<DAL.LoginUserRow> lst = ta.GetDataByUserName(userName, customerID).Select().Cast<DAL.LoginUserRow>().ToList();
            if (lst.Count > 0)
            {
                DAL.LoginUserRow row = lst[0];
                SiteID = row.SiteID_Ext;
            }

            return SiteID;
        }
        /// <summary>
        /// GetUserID
        /// Function to get the user Id
        /// </summary>
        /// <param name="userName">Username</param>
        /// <param name="customerID">Customer ID</param>
        /// <param name="session">Session object</param>
        /// <returns>User ID</returns>
        public static Int32 GetUserID(String userName, String customerID, ISession session, String VersionNo = "")
        {
            Int32 userID = 0;
            LoginUserTableAdapter ta = new LoginUserTableAdapter();
            ta.CurrentConnection = session;
            List<DAL.LoginUserRow> lst = ta.GetDataByUserName(userName, customerID).Select().Cast<DAL.LoginUserRow>().ToList();
            if (lst.Count > 0)
            {
                DAL.LoginUserRow row = lst[0];
                userID = row.ID_Ext;
            }

            return userID;
        }

        public static string GetClientID(String userName, String customerID, ISession session, String VersionNo = "")
        {
            String ClientID = string.Empty;
            LoginUserTableAdapter ta = new LoginUserTableAdapter();
            ta.CurrentConnection = session;
            List<DAL.LoginUserRow> lst = ta.GetDataByUserName(userName, customerID).Select().Cast<DAL.LoginUserRow>().ToList();
            if (lst.Count > 0)
            {
                DAL.LoginUserRow row = lst[0];
                ClientID = row.CustomerID_Ext;
            }
            return ClientID;
        }

        //2013.09.26 FSWW, Ramesh M Added For CR#59831 Getting USerLoginID by DriverID and CustomeRID
        public static Int32 GetUserIDByDriverID(Int32 driverID, String customerID, ISession session, String VersionNo = "")
        {
            Int32 userID = 0;
            LoginUserTableAdapter ta = new LoginUserTableAdapter();
            ta.CurrentConnection = session;
            List<DAL.LoginUserRow> lst = ta.GetDataByDriverID(driverID, customerID).Select().Cast<DAL.LoginUserRow>().ToList();
            if (lst.Count > 0)
            {
                DAL.LoginUserRow row = lst[0];
                userID = row.ID_Ext;
            }

            return userID;
        }
        //2013.10.29 FSWW, Ramesh M Added For CR#59831 Getting DriverID by using LoginID and CustomeRID
        public static Int32 GetDriverIDByUsingLoginId(Int32 LoginID, String customerID, ISession session, String VersionNo = "")
        {
            Int32 userID = 0;
            LoginUserTableAdapter ta = new LoginUserTableAdapter();
            ta.CurrentConnection = session;
            List<DAL.LoginUserRow> lst = ta.GetDataByLoginId(LoginID, customerID).Select().Cast<DAL.LoginUserRow>().ToList();
            if (lst.Count > 0)
            {
                DAL.LoginUserRow row = lst[0];
                userID = row.DriverID_Ext;
            }

            return userID;
        }


        public static Int32 GetUserIDOnSession(Guid loginSession, ISession session, String VersionNo = "")
        {
            Int32 userID = 0;
            LoginHistoryTableAdapter ta = new LoginHistoryTableAdapter();
            ta.CurrentConnection = session;
            List<DAL.LoginHistoryRow> lst = ta.GetDataBySession(loginSession).Select().Cast<DAL.LoginHistoryRow>().ToList();
            if (lst.Count > 0)
            {
                userID = lst[0].LoginID_Ext;
            }

            return userID;
        }

        /// <summary>
        /// GetUserID
        /// Function to get the user Id
        /// </summary>
        /// <param name="driverID">driverID</param>
        /// <param name="customerID">Customer ID</param>
        /// <param name="session">Session object</param>
        /// <returns>Login User</returns>
        public static LoginUser GetUser(Int32 driverID, String customerID, ISession session, String VersionNo = "")
        {
            LoginUserTableAdapter ta = new LoginUserTableAdapter();
            ta.CurrentConnection = session;
            List<LoginUser> lst = ta.GetDataByDriverID(driverID, customerID).Select().Cast<DAL.LoginUserRow>().ToList().ToEntities();
            if (lst.Count > 0)
            {
                return lst[0];
            }

            return null;
        }

        /// <summary>
        /// GetLatestLoginHistory
        /// </summary>
        /// <param name="driverID">driverID</param>
        /// <param name="vehicleID">vehicle ID</param>
        /// <param name="session">Session object</param>
        /// <returns>Login History</returns>
        public static LoginHistory GetLatestLoginHistory(Int32 driverID, Int32 vehicleID, ISession session, String VersionNo = "")
        {
            /*LoginHistoryTableAdapter ta = new LoginHistoryTableAdapter();
            ta.CurrentConnection = session;
            List<LoginHistory> lst = ta.GetLatestLoginDetails(driverID, vehicleID).Select().Cast<DAL.LoginHistoryRow>().ToList().ToEntities();
            if (lst.Count > 0)
            {
                return lst[0];
            }*/

            return null;
        }

        /// <summary>
        /// GetAllStatuses
        /// Function to return list of status
        /// </summary>
        /// <param name="session">Session object</param>
        /// <returns>List of status</returns>
        public static List<Status> GetAllStatuses(ISession session, String VersionNo = "")
        {
            StatusTableAdapter ta = new StatusTableAdapter();
            ta.CurrentConnection = session;
            return ta.GetData().Select().Cast<DAL.StatusRow>().ToList().ToEntities();
        }
        // 21-05-2013 Fsww Ramesh M added
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sessionID"></param>
        /// <param name="session"></param>
        /// <returns></returns>
        public static bool ValidateCurrentUserSession(Guid sessionID, ISession session, String VersionNo = "")
        {
            LoginSessionTableAdapter ta = new LoginSessionTableAdapter();
            ta.CurrentConnection = session;
            List<DAL.LoginSessionRow> lst = ta.GetDataBySession(sessionID).Select().Cast<DAL.LoginSessionRow>().ToList();
            return lst.Count > 0;
        }

        /// <summary>
        /// GetLoads
        /// Function to return list of load
        /// </summary>
        /// <param name="skipedDelivered">Should query skip the deliverd load</param>
        /// <param name="timeToSkip">time in munutes to skip deliverd loads</param>
        /// <param name="loginUserID">Login user ID</param>
        /// <param name="customerID">Customer ID</param>
        /// <param name="loadID">Load ID</param>
        /// <param name="loadNo">Load number</param>
        /// <param name="loadStatusID">Load status ID</param>
        /// <param name="vehicleID">Vehicle ID</param>
        /// <param name="driverID">Driver ID</param>
        /// <param name="includeOrders">Include orders</param>
        /// <param name="includeOrderItems">Include order items</param>
        /// <param name="session">Session object</param>
        /// <returns>List of load</returns>
        public static List<Load> GetLoads(bool skipedDelivered, int timeToSkip, Int32 loginUserID, String customerID, Guid loadID, String loadNo, String loadStatusID, Int32? vehicleID, Int32? driverID, Boolean includeOrders, Boolean includeOrderItems, DateTime? deviceTime, ISession session, String VersionNo = "")
        {
            try
            {
                LoadTableAdapter ta = new LoadTableAdapter();
                ta.CurrentConnection = session;
                //2013.09.06 FSWW, Ramesh M Added For CR#60100 To Get Only Drivers Load Added LoadType ="V" Hard Coded
                List<Load> lstLoads = ta.GetDataByDetails(skipedDelivered ? "1" : "0", Convert.ToDecimal(timeToSkip), "V", loadID, customerID, loadNo, vehicleID, driverID, loadStatusID, loginUserID, deviceTime).Select().Cast<DAL.LoadRow>().ToList().ToEntities();

                foreach (Load load in lstLoads)
                {
                    load.LoadStatusID = GetLoadStatus(loginUserID, load.ID, session);
                    if (includeOrders)
                    {
                        load.Orders = GetOrders(loginUserID, load.ID, includeOrderItems, customerID, session);
                    }

                    load.LastUpdatedTime = (from d in lstLoads select d.LastUpdatedTime).Max();
                    
                    //if(load.IsDeleted == true)
                    //{
                    //    Logging.LogInfoAboutCallingFunction("GetLoads: Deleted LoadNo - " + load.LoadNo);
                    //}
                    //if (deviceTime != Convert.ToDateTime("1/1/1753 12:00:00 AM") && cnt==0)
                    //{
                    //    load.CompletedLoad = GetCompletedLoads(customerID, deviceTime, session);
                    //    cnt = 1;
                    //}
                }

                return lstLoads;
            }
            catch (Exception Ex)
            {
                throw;
            }
        }

        public static List<CompletedLoads> GetCompletedLoads(String customerID, DateTime? deviceTime, ISession session, String VersionNo = "")
        {
            try
            {

                Cloud_TW_GetLoadDetailsToDeleteTableAdapter ta = new Cloud_TW_GetLoadDetailsToDeleteTableAdapter();
                ta.CurrentConnection = session;
                List<CompletedLoads> lstCompletedLoads = ta.GetDataCompletedLoads(customerID, deviceTime).Select().Cast<DAL.Cloud_TW_GetLoadDetailsToDeleteRow>().ToList().ToEntities();

                return lstCompletedLoads;
            }
            catch (Exception Ex)
            {
                throw;
            }
        }

        //2013.09.06 FSWW, Ramesh M Added For CR#60100  to Get warehouse user loads
        public static List<WarehouseLoad> GetWareHouseLoads(bool skipedDelivered, int timeToSkip, Int32 loginUserID, String customerID, Guid loadID, String loadNo, String loadStatusID, String SiteCode, Boolean includeOrders, Boolean includeOrderItems, ISession session, String VersionNo = "")
        {
            WarehouseLoadTableAdapter ta = new WarehouseLoadTableAdapter();
            ta.CurrentConnection = session;
            try
            {
                //2013.09.06 FSWW, Ramesh M Added For CR#60100 To Get Only Drivers Load Added LoadType ="W" Hard Coded  
                //2013.11.18 FSWW, Ramesh M Added For CR#60903 Get warehouseloads query
                List<WarehouseLoad> lstLoads = ta.GetWareHouseLoads(skipedDelivered ? "1" : "0", Convert.ToDecimal(timeToSkip), "W", loadID, customerID, loadNo, SiteCode, loadStatusID, loginUserID).Select().Cast<DAL.WarehouseLoadRow>().ToList().ToEntities();

                foreach (WarehouseLoad load in lstLoads)
                {
                    load.LoadStatusID = GetLoadStatusID(load.ID, session);
                    if (includeOrders)
                    {
                        load.Orders = GetOrders(loginUserID, load.ID, includeOrderItems, customerID, session);
                    }
                    //2013.11.15 FSWW, Ramesh M Added For CR#59831
                    if (load.DriverID != 0)
                    {
                        LoginUserTableAdapter oLoginUserTableAdapter = new LoginUserTableAdapter();
                        oLoginUserTableAdapter.CurrentConnection = session;
                        List<DAL.LoginUserRow> lst = oLoginUserTableAdapter.GetDataByDriverID(load.DriverID, load.CustomerID).Select().Cast<DAL.LoginUserRow>().ToList();
                        load.AssignedDriverID = Convert.ToInt32(lst[0]["ID"].ToString());
                        load.AssignedDriverName = lst[0]["FirstName"] + " " + lst[0]["LastName"];
                    }
                    if (load.VehicleID != 0)
                    {
                        VehicleTableAdapter oVehicleTableAdapter = new VehicleTableAdapter();
                        oVehicleTableAdapter.CurrentConnection = session;
                        List<DAL.VehicleRow> lst = oVehicleTableAdapter.GetDataByID(load.VehicleID, load.CustomerID).Select().Cast<DAL.VehicleRow>().ToList();
                        load.AssignedVehicleCode = lst[0]["VehicleCode"].ToString();
                    }
                }

                return lstLoads;
            }
            catch (Exception Ex)
            {
                String ErrMsg = Ex.ToString();
                throw Ex;
            }

        }


        //2013.09.06 FSWW, Ramesh M Added For CR#60100  to Get warehouse user loads
        //public static List<Load> GetWareHouseLoads(int timeToSkip, Int32 loginUserID, String customerID, Boolean includeOrders,Boolean includeOrderItems, ISession session)
        //{
        //    LoadTableAdapter ta = new LoadTableAdapter();
        //    ta.CurrentConnection = session;         
        //    List<Load> lstLoads = ta.GetWareHouseLoad(loginUserID, Convert.ToInt32(timeToSkip),customerID).Select().Cast<DAL.LoadRow>().ToList().ToEntities();

        //    foreach (Load load in lstLoads)
        //    {
        //        load.LoadStatusID = GetLoadStatus(loginUserID, load.ID, session);
        //        if (includeOrders)
        //        {
        //            load.Orders = GetOrders(loginUserID, load.ID, includeOrderItems, session);
        //        }
        //    }
        //    return lstLoads;
        //}

        /// <summary>
        /// This function is used to updated deleted loads
        /// </summary>
        /// <param name="loadID"></param>
        /// <param name="updatedDateTimes"></param>
        /// <param name="session"></param>
        /// <returns></returns>
        public static bool UpdatedDeletedLoads(Guid loadID, DateTime updatedDateTimes, ISession session, String VersionNo = "")
        {
            LoadTableAdapter ta = new LoadTableAdapter();
            ta.CurrentConnection = session;
            return ta.UpdateDeletedLoads(updatedDateTimes, loadID) > 0;
        }

        /// <summary>
        /// IsLoadExist
        /// Function to check load exist or not
        /// </summary>
        /// <param name="?"></param>
        /// <returns></returns>
        public static bool LoadNotExist(Guid loadID, ISession session, String VersionNo = "")
        {
            LoadTableAdapter ta = new LoadTableAdapter();
            ta.CurrentConnection = session;
            if (ta.CheckLoadExist(loadID).Count > 0)
            {
                return false;
            }
            else if (ta.CheckLoadDeleted(loadID).Count > 0)
            {
                return false;
            }
            //2013.06.24 FSWW, Ramesh M Added For CR#58976  To Add More Details about calling function in Error log file.
            Logging.LogError(new Exception("Load (" + loadID + ") is not exist."), "LoadID-" + loadID + "\n");
            return true;
        }

        /// <summary>
        /// DeleteLoad
        /// Function to delete load record from load table
        /// </summary>
        /// <param name="loadID">Load ID</param>
        /// <param name="session">Session object</param>
        public static void DeleteLoad(Guid loadID, ISession session, String VersionNo = "")
        {
            LoadTableAdapter ta = new LoadTableAdapter();
            ta.CurrentConnection = session;
            ta.DeleteQuery(loadID);
        }

        public static void UpdateIsDeleteLoadFlag(Guid LoadId, DateTime DeletedTime, ISession session, String VersionNo = "")
        {

            SqlConnection con = new SqlConnection(session.ConnectionString);
            try
            {
                SqlCommand cmd = (SqlCommand)session.CreateCommand();
                cmd.CommandText = "Cloud_UpdateIsDeleteLoadFlag";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@LOAD_ID", LoadId);
                cmd.Parameters.AddWithValue("@DELETEDTIME ", DeletedTime);
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Logging.LogError(ex, string.Format("Cloud_UpdateIsDeleteLoadFlag is failed - LoadId - {0}", LoadId));
            }
            finally
            {
                con.Close();
            }




        }

        /// <summary>
        /// GetLoadStatus
        /// Function to get the load status ID related to load id and login user id
        /// </summary>
        /// <param name="loginUserID">Login user ID</param>
        /// <param name="loadID">Load ID</param>
        /// <param name="session">Session object</param>
        /// <returns>Load status ID</returns>
        public static String GetLoadStatus(Int32 loginUserID, Guid loadID, ISession session, String VersionNo = "")
        {
            String status = "I";
            LoadStatusHistoryTableAdapter ta = new LoadStatusHistoryTableAdapter();
            ta.CurrentConnection = session;
            List<LoadStatusHistory> lstLoadStatus = ta.GetLoadStatusByLoadID(loadID, loginUserID).Select().Cast<DAL.LoadStatusHistoryRow>().ToList().ToEntities();
            if (lstLoadStatus.Count > 0)
            {
                status = lstLoadStatus[0].LoadStatusID;
            }
            return status;
        }

        //2013.11.08 FSWW, Ramesh M Added For CR#60905...
        public static String GetLoadStatusID(Guid loadID, ISession session, String VersionNo = "")
        {
            String status = "I";
            LoadStatusHistoryTableAdapter ta = new LoadStatusHistoryTableAdapter();
            ta.CurrentConnection = session;
            List<LoadStatusHistory> lstLoadStatus = ta.GetLoadStatusID(loadID).Select().Cast<DAL.LoadStatusHistoryRow>().ToList().ToEntities();
            if (lstLoadStatus.Count > 0)
            {
                status = lstLoadStatus[0].LoadStatusID;
            }
            return status;
        }

        /// <summary>
        /// GetLoadStatus
        /// Function to get the load status ID related to load number and customer id
        /// </summary>
        /// <param name="loadNo">Load number</param>
        /// <param name="customerID">Customer ID</param>
        /// <param name="session">Session object</param>
        /// <returns>Load status ID</returns>
        public static String GetLoadStatus(String loadNo, String customerID, ISession session, String VersionNo = "")
        {
            String status = "I";
            LoadStatusHistoryTableAdapter ta = new LoadStatusHistoryTableAdapter();
            ta.CurrentConnection = session;
            List<LoadStatusHistory> lstLoadStatus = ta.GetDataByLoadNo(loadNo, customerID).Select().Cast<DAL.LoadStatusHistoryRow>().ToList().ToEntities();
            if (lstLoadStatus.Count > 0)
            {
                status = lstLoadStatus[0].LoadStatusID;
            }
            return status;
        }

        /// <summary>
        /// IsLoadUndispatchRequest
        /// Function to check load has  the load UndispatchRequest
        /// </summary>
        /// <param name="loadNo">Load number</param>
        /// <param name="session">Session object</param>
        /// <returns>Boolean</returns>
        public static Boolean IsLoadUndispatchRequest(Guid loadID, ISession session, String VersionNo = "")
        {
            LoadTableAdapter ta = new LoadTableAdapter();
            ta.CurrentConnection = session;
            List<DAL.LoadRow> lstLoadStatus = ta.GetDataByUndispatchRequest(loadID).Select().Cast<DAL.LoadRow>().ToList();
            if (lstLoadStatus.Count > 0)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// GetOrders
        /// Function to return list of Order
        /// </summary>
        /// <param name="loadID">Load ID</param>
        /// <param name="includeOrderItems">Include order items</param>
        /// <param name="session">Session object</param>
        /// <returns>List of Order</returns>        
        public static List<Order> GetOrders(Int32 loginUserID, Guid loadID, Boolean includeOrderItems, String customerID, ISession session, String VersionNo = "")
        {
            try
            {
                OrderTableAdapter ta = new OrderTableAdapter();
                ta.CurrentConnection = session;
                List<Order> lstOrders = ta.GetDataByLoad(loadID).Select().Cast<DAL.OrderRow>().ToList().ToEntities();
                //DAL.OrderDataTable result = ta.GetDataByLoad(loadID);
                //List<Order> lstOrders = result.Select().Cast<DAL.OrderRow>().ToList().ToEntities();

                foreach (Order order in lstOrders)
                {
                    order.OrderStatusID = GetOrderStatus(loginUserID, order.ID, session);
                    if (includeOrderItems)
                    {
                        order.OrderItems = GetOrderItems(order.ID, includeOrderItems, session);
                    }
                    string DestSiteFormat = DALMethods.IsEnabledDestSiteFormat(customerID, session, VersionNo);
                    if (DestSiteFormat == "Y")
                    {
                        if (order.DestSite != null && order.DestSite.ToString() != "")
                        {
                            if (order.DestSite.Split('/').Length > 1)
                            {
                                order.DestSite = order.DestSite.Split('/')[1].ToString();
                            }
                        }
                    }
                }
                return lstOrders;
            }
            catch (Exception Ex)
            {
                throw;
            }
        }

        /// <summary>
        /// GetOrderCountByStatus
        /// Function to get count of order related to order status ID
        /// </summary>
        /// <param name="loadID">Load ID</param>
        /// <param name="orderStatusID">Order status ID</param>
        /// <param name="session">Session object</param>
        /// <returns>Count of order</returns>
        public static Int32 GetOrderCountByStatus(Guid loadID, String orderStatusID, ISession session, String VersionNo = "")
        {
            Int32 cnt = 0;
            OrderTableAdapter ta = new OrderTableAdapter();
            ta.CurrentConnection = session;
            cnt = Convert.ToInt32(ta.GetOrderCountByStatus(loadID, orderStatusID));
            return cnt;
        }

        /// <summary>
        /// GetOrderStatus
        /// Function to get the order status id related to login user id and order id
        /// </summary>
        /// <param name="loginUserID">Login user ID</param>
        /// <param name="orderID">Order ID</param>
        /// <param name="session">Session object</param>
        /// <returns>Order status ID</returns>
        public static String GetOrderStatus(Int32 loginUserID, Guid orderID, ISession session, String VersionNo = "")
        {
            String status = "I";
            OrderStatusHistoryTableAdapter ta = new OrderStatusHistoryTableAdapter();
            ta.CurrentConnection = session;
            List<OrderStatusHistory> lstOrderStatus = ta.GetOrderStatusByOrderID(orderID, loginUserID).Select().Cast<DAL.OrderStatusHistoryRow>().ToList().ToEntities();
            if (lstOrderStatus.Count > 0)
            {
                status = lstOrderStatus[0].OrderStatusID;
            }
            return status;
        }

        /// <summary>
        /// Update Signature Image
        /// </summary>
        /// <param name="orderID"></param>
        /// <param name="image"></param>
        /// <param name="signatureDateTime">signatureDateTime</param>
        /// <param name="session"></param>
        /// <returns></returns>
        public static Int32 UpdateSignatureImage(Guid orderID, byte[] image, DateTime signatureDateTime, int userid, string DeviceID, ISession session, String VersionNo = "")
        {
            OrderFrtTableAdapter ta = new OrderFrtTableAdapter();
            ta.CurrentConnection = session;
            SignatureImageTableAdapter taSignature = new SignatureImageTableAdapter();
            taSignature.CurrentConnection = session;

            List<OrderFrt> lstDeliv = ta.GetDataByOrderID(orderID).Select().Cast<DAL.OrderFrtRow>().ToList().ToEntities();
            if (lstDeliv.Count > 0)
            {
                return taSignature.UpdateSignatureImage(image, signatureDateTime, "1", orderID);

            }
            else
            {
                return taSignature.InsertSignatureImage(orderID, image, signatureDateTime, "1", userid, DeviceID == null ? "0" : DeviceID, signatureDateTime, DateTime.Now);
            }

        }

        /// <summary>
        /// UpdateSignatureStatusByOrderItemID
        /// </summary>
        /// <param name="orderID">orderID</param>
        /// <param name="session">session</param>
        /// <returns></returns>
        public static Int32 UpdateSignatureStatusByOrderItemID(Guid orderItemID, ISession session, String VersionNo = "")
        {
            SignatureImageTableAdapter ta = new SignatureImageTableAdapter();
            ta.CurrentConnection = session;
            return ta.UpdateSignatureStatusByOrderItemID(orderItemID);
        }

        /// <summary>
        /// UpdateSignatureStatusByOrderID
        /// </summary>
        /// <param name="orderID">orderID</param>
        /// <param name="session">session</param>
        /// <returns></returns>
        public static Int32 UpdateSignatureStatus(Decimal SysTrxNo, String companyID, ISession session, String VersionNo = "")
        {
            SignatureImageTableAdapter ta = new SignatureImageTableAdapter();
            ta.CurrentConnection = session;
            return ta.UpdateStatusBySysTrxNo(SysTrxNo, companyID);
        }

        /// <summary>
        /// GetSignatureImage
        /// </summary>
        /// <param name="SysTrxNo">SysTrxNo</param>
        /// <param name="session">session</param>
        /// <returns></returns>
        public static List<SignatureImage> GetSignatureImage(Decimal SysTrxNo, String companyID, ISession session, String VersionNo = "")
        {
            SignatureImageTableAdapter ta = new SignatureImageTableAdapter();
            ta.CurrentConnection = session;
            //return ta.GetData(SysTrxNo, companyID).Select().Cast<DAL.SignatureImageRow>().ToList().ToEntities();

            if (ta.GetData(SysTrxNo, companyID).Count > 0)
                return ta.GetData(SysTrxNo, companyID).Select().Cast<DAL.SignatureImageRow>().ToList().ToEntities();
            else
                return null;

        }

        /// <summary>
        /// GetOrderItems
        /// Function to return list of order item
        /// </summary>
        /// <param name="orderID">Order ID</param>
        /// <param name="includeOrderItems">Include order items</param>
        /// <param name="session">Session object</param>
        /// <returns>List of order item</returns>
        public static List<OrderItem> GetOrderItems(Guid orderID, Boolean includeOrderItems, ISession session, String VersionNo = "")
        {
            OrderItemTableAdapter ta = new OrderItemTableAdapter();
            ta.CurrentConnection = session;
         //   List<OrderItem> lstOrderitem = ta.GetDataByDetails(orderID).Select().Cast<DAL.OrderItemRow>().OrderBy(x => x.OrderID).ThenBy(x => x.SysTrxLine).ToList().ToEntities();
           
            List<OrderItem> lstOrderitem = ta.GetDataByDetails(orderID).Select().Cast<DAL.OrderItemRow>().OrderBy(x => x.OrderID).ThenBy(x => x.SysTrxLine).ToList().ToEntities();
            if (includeOrderItems)
            {
                foreach (OrderItem orderitem in lstOrderitem)
                {
                    // 2014.03.04  Ramesh M Commented For CR#62032 Loading order item component for all the orders
                    //if (orderitem.Blend != "N")
                    //{
                    orderitem.OrderItemComponent = GetOrderItemComponent(orderitem.ID, session);
                    Logging.LogInfoAboutCallingFunction("GetOrderItems: LoadingNo before orderID - " + orderID);
                    if (orderitem.Note != null)
                    {
                        Logging.LogInfoAboutCallingFunction("GetOrderItems: LoadingNo after orderID - " + orderID);
                        string Note = orderitem.Note;
                        if (Note.Contains("LoadingNo:"))
                        {
                            Logging.LogInfoAboutCallingFunction("GetOrderItems: LoadingNo Found orderID - " + orderID);
                            string LoadingNo = Note.Substring(Note.IndexOf("LoadingNo:")).Replace(" ", "").Replace("LoadingNo:", "");
                            orderitem.LoadingNo = LoadingNo;
                            Logging.LogInfoAboutCallingFunction("GetOrderItems: orderID - " + orderID + "LoadingNo:" + orderitem.LoadingNo);
                        }
                    }
                    //orderitem.LoadingNo = orderitem.Note
                    //}
                    orderitem.DeliveryDetails = GetDeliveryDetails(orderitem.ID, session);
                }
            }
            return lstOrderitem;
        }

        /// <summary>
        /// GetOrderItemComponent
        /// Function to return list of order item component
        /// </summary>
        /// <param name="orderItemID">Order item ID</param>
        /// <param name="session">Session object</param>
        /// <returns>List of order item component</returns>
        public static List<OrderItemComponent> GetOrderItemComponent(Guid orderItemID, ISession session, String VersionNo = "")
        {
            OrderItemComponentTableAdapter ta = new OrderItemComponentTableAdapter();
            ta.CurrentConnection = session;
            return ta.GetDataByDetails(orderItemID).Select().Cast<DAL.OrderItemComponentRow>().OrderBy(x => x.OrderItemID).ThenBy(x => x.ComponentNo).ToList().ToEntities();
        }

        /// <summary>
        /// GetBolhdr
        /// Function to return list of BOL header
        /// </summary>
        /// <param name="BolHrdID">BOL header ID</param>
        /// <param name="loadID">Load ID</param>
        /// <param name="BolNo">BOL number</param>
        /// <param name="includeItems">Include items</param>
        /// <param name="session">Session object</param>
        /// <returns>List of BOL header</returns>
        public static List<BolHdr> GetBolhdr(Guid BolHrdID, Guid loadID, String BolNo, Boolean includeItems, ISession session, String VersionNo = "")
        {
            BOLHdrTableAdapter ta = new BOLHdrTableAdapter();
            ta.CurrentConnection = session;
            List<BolHdr> lstBolhdr = ta.GetDataByBolHdrDetail(BolHrdID, loadID, BolNo).Select().Cast<DAL.BOLHdrRow>().ToList().ToEntities();
            if (lstBolhdr.Count > 0)
            {
                if (includeItems)
                {
                    foreach (BolHdr bolhdr in lstBolhdr)
                    {
                        bolhdr.BolItem = GetBolitem(Guid.Empty, bolhdr.ID, 0, 0, 0, session);
                    }
                }
            }
            return lstBolhdr;

        }

        /// <summary>
        /// GetBOLDetails
        /// Function to return list of BOL Details
        /// </summary>
        /// <param name="BolHrdID">BOL header ID</param>
        /// <param name="loadID">Load ID</param>
        /// <param name="BolNo">BOL number</param>
        /// <param name="includeItems">Include items</param>
        /// <param name="session">Session object</param>
        /// <returns>List of BOL header</returns>
        public static List<BolHdr> GetBOLDetails(String companyID, Guid loadID, ISession session, String VersionNo = "")
        {
            Cloud_GetLoadBasedBOLDetailsTableAdapter ta = new Cloud_GetLoadBasedBOLDetailsTableAdapter();
            ta.CurrentConnection = session;
            List<BolHdr> lstBolhdr = ta.GetData_Cloud_GetLoadBasedBOLDetails(companyID, loadID).Select().Cast<DAL.Cloud_GetLoadBasedBOLDetailsRow>().ToList().ToEntities();
            if (lstBolhdr.Count > 0)
            {
                foreach (BolHdr bolhdr in lstBolhdr)
                {
                    bolhdr.BolItem = GetBolitem(Guid.Empty, bolhdr.ID, 0, 0, 0, session);
                }
            }
            return lstBolhdr;

        }

        /// <summary>
        /// GetBolhdrDetails
        /// Function to return list of BOL header
        /// </summary>
        /// <param name="loadID">Load ID</param>
        /// <param name="session">Session object</param>
        /// <returns>List of BOL header</returns>
        public static List<BolHdr> GetBolhdrDetails(Guid loadID, ISession session, String VersionNo = "")
        {
            BOLHdrTableAdapter ta = new BOLHdrTableAdapter();
            ta.CurrentConnection = session;
            List<BolHdr> lstBolhdr = ta.GetBOLHdrDetails(loadID).Select().Cast<DAL.BOLHdrRow>().ToList().ToEntities();
            if (lstBolhdr.Count > 0)
            {

                foreach (BolHdr bolhdr in lstBolhdr)
                {
                    bolhdr.BolItem = GetBOLItemDetails(bolhdr.ID, session);
                }

            }
            return lstBolhdr;

        }

        /// <summary>
        /// GetBolitem
        /// Function to return list of BOL item
        /// </summary>
        /// <param name="BolitemID">Bol item ID</param>
        /// <param name="BolHrdID">BOL header</param>
        /// <param name="SysTrxNo">System transaction number</param>
        /// <param name="SysTrxLine">System transaction line</param>
        /// <param name="componentNo">Component number</param>
        /// <param name="session">Session object</param>
        /// <returns>List of BOL item</returns>
        public static List<Bolitem> GetBolitem(Guid BolitemID, Guid BolHrdID, Decimal SysTrxNo, Int32 SysTrxLine, Int32 componentNo, ISession session, String VersionNo = "")
        {
            BOLItemTableAdapter ta = new BOLItemTableAdapter();
            ta.CurrentConnection = session;
            return ta.GetDataByBolItemDetail(BolitemID, BolHrdID, SysTrxNo, SysTrxLine, componentNo).Select().Cast<DAL.BOLItemRow>().ToList().ToEntities();
        }

        /// <summary>
        /// GetBolitemDetails
        /// Function to return list of BOL item
        /// </summary>
        /// <param name="BolHrdID">BOL header</param>
        /// <param name="session">Session object</param>
        /// <returns>List of BOL item</returns>
        public static List<Bolitem> GetBOLItemDetails(Guid BolHrdID, ISession session, String VersionNo = "")
        {
            BOLItemTableAdapter ta = new BOLItemTableAdapter();
            ta.CurrentConnection = session;
            return ta.GetDataBOLItemDetails(BolHrdID).Select().Cast<DAL.BOLItemRow>().ToList().ToEntities();
        }

        /// <summary>
        /// GetDeliveryDetails
        /// Function to return list of delivery details
        /// </summary>
        /// <param name="orderItemID">Order item ID</param>
        /// <param name="session">Session object</param>
        /// <returns>List of delivery details</returns>
        public static List<DeliveryDetails> GetDeliveryDetails(Guid orderItemID, ISession session, String VersionNo = "")
        {
            DeliveryDetailsTableAdapter ta = new DeliveryDetailsTableAdapter();
            ta.CurrentConnection = session;
            return ta.GetDeliveryDetails(orderItemID).Select().Cast<DAL.DeliveryDetailsRow>().ToList().ToEntities();
        }

        /// <summary>
        /// GetDeliveryDetails
        /// Function to return list of delivery details
        /// </summary>
        /// <param name="orderItemID">Order item ID</param>
        /// <param name="session">Session object</param>
        /// <returns>List of delivery details</returns>
        public static List<DeliveryDetailsData> GetDeliveryData(Guid orderID, ISession session, String VersionNo = "")
        {
            Cloud_GetDeliveryDataTableAdapter ta = new Cloud_GetDeliveryDataTableAdapter();
            ta.CurrentConnection = session;
            return ta.GetDeliveryData(orderID).Select().Cast<DAL.Cloud_GetDeliveryDataRow>().ToList().ToEntities();
        }

        /// <summary>
        /// GetOrderFrts
        /// Function to return list of OrderFrt details
        /// </summary>
        /// <param name="orderID">Order ID</param>
        /// <param name="session">Session object</param>
        /// <returns>List of Order Frights</returns>
        public static List<OrderFrt> GetOrderFrts(Guid orderID, ISession session, String VersionNo = "")
        {
            OrderFrtTableAdapter ta = new OrderFrtTableAdapter();
            ta.CurrentConnection = session;
            return ta.GetDataByOrderID(orderID).Select().Cast<DAL.OrderFrtRow>().ToList().ToEntities();
        }

        /// <summary>
        /// GetForgotPassword
        /// Function to return list of login user records
        /// </summary>
        /// <param name="userID">User ID</param>
        /// <param name="companyID">Company ID</param>
        /// <param name="email">Email</param>
        /// <param name="session">Session object</param>
        /// <returns>List of login user</returns>
        public static List<LoginUser> GetForgotPassword(String userID, String companyID, String email, ISession session, String VersionNo = "")
        {
            LoginUserTableAdapter ta = new LoginUserTableAdapter();
            ta.CurrentConnection = session;
            return ta.GetByPasswordDetails(userID, companyID, email).Select().Cast<DAL.LoginUserRow>().ToList().ToEntities();
        }

        /// <summary>
        /// GetLoginHistory
        /// Function to return list of Login hsitory 
        /// </summary>
        /// <param name="session">Session object</param>
        /// <returns>List of login history</returns>

        /*public static List<LoginHistory> GetLoginHistory(int timeToSkip, Int32 loginID, String customerID, Int32 vehicleID, Guid sessionID, ISession session)
        {
            LoginHistoryTableAdapter ta = new LoginHistoryTableAdapter();
            ta.CurrentConnection = session;
            return ta.GetDataByDetails(customerID, loginID, vehicleID).Select().Cast<DAL.LoginHistoryRow>()
        }*/

        /// <summary>
        /// GetLogonTime
        /// Function to return logon time 
        /// </summary>
        /// <param name="LoginID">Login ID</param>
        /// <param name="CustomerID">Customer ID</param>
        /// <param name="VehicleID">Vehicle ID</param>
        /// <param name="SessionID">Session ID</param>
        /// <param name="session">session</param>
        /// <returns>DateTime</returns>
        public static DateTime GetLogonTime(Int32 loginID, String customerID, Int32 vehicleID, Guid sessionID, ISession session, String VersionNo = "")
        {
            LoginSessionTableAdapter ta = new LoginSessionTableAdapter();
            ta.CurrentConnection = session;
            DateTime time = (DateTime)ta.GetLogonTime(sessionID, true, loginID, vehicleID);
            return time;
        }

        /// <summary>
        /// GetCurrentShiftSummaryDetails
        /// Function to return  CurrentShiftSummaryDetails
        /// </summary>
        /// <param name="loginID">LoginID</param>
        /// <param name="customerID">CustomerID</param>
        /// <param name="vehicleID">VehicleID</param>
        /// <param name="sessionID">SessionID</param>
        /// <param name="session">session object</param>
        /// <returns>SummaryLogResponse</returns>
        public static CurrentShiftSummaryResponse GetCurrentShiftSummaryLog(Int32 loginID, String customerID, Int32 vehicleID, Guid sessionID, ISession session, String VersionNo = "")
        {
            CurrentShiftSummaryResponse summaryResponse = new CurrentShiftSummaryResponse();
            LoginHistoryTableAdapter ta = new LoginHistoryTableAdapter();
            ta.CurrentConnection = session;
            List<LoginHistory> lst = ta.GetDataByDetails(customerID, loginID, vehicleID, sessionID).Select().Cast<DAL.LoginHistoryRow>().ToList().ToEntities();

            if (lst.Count > 0)
            {
                summaryResponse.SessionID = lst[0].SessionID;
                summaryResponse.OnDuty = lst[0].OnDuty ?? 0;
                summaryResponse.SleeperRig = lst[0].Sleeper ?? 0;
                summaryResponse.Driving = lst[0].Driving ?? 0;
                summaryResponse.OffDuty = lst[0].OffDuty ?? 0;
            }

            return summaryResponse;
        }

        /// <summary>
        /// GetCumulativeShiftSummaryDetails
        /// Function to return  CumulativeShiftSummaryDetails
        /// </summary>
        /// <param name="days">Summary Days</param>
        /// <param name="loginID">LoginID</param>
        /// <param name="customerID">CustomerID</param>
        /// <param name="vehicleID">VehicleID</param>
        /// <param name="session">session object</param>
        /// <returns>SummaryLogResponse</returns>
        public static CumulativeShiftSummaryResponse GetCumulativeShiftSummaryLog(Int32 loginID, String customerID, Int32 vehicleID, Guid sessionID, Int32 restartLimit, Int32 dutyLimit, String VersionNo = "")
        {
            CumulativeShiftSummaryResponse summmaryLog = new CumulativeShiftSummaryResponse();
            /*CumulativeSummaryTableAdapter ta = new CumulativeSummaryTableAdapter();
            List<CumulativeShiftSummaryResponse> lst = ta.GetDataBy(sessionID, loginID, vehicleID, customerID, restartLimit, dutyLimit).Select().Cast<DAL.CumulativeSummaryRow>().ToList().ToEntities(); ;
            //List<CumulativeShiftSummaryResponse> lst = ta.GetCumulativeSummaryFor8Days(loginID, vehicleID, customerID).Select().Cast<DAL.CumulativeSummaryRow>().ToList().ToEntities(); 
            
            if (lst.Count > 0)
            {
                summmaryLog = lst[0]; 
            }*/

            return summmaryLog;
        }

        /// <summary>
        /// GetSessionDetail
        /// Function to get pre existing session detail
        /// </summary>
        /// <param name="userID">User ID</param>
        /// <param name="password">Password</param>
        /// <param name="companyID">Company ID</param>
        /// <param name="vehicleID">Vehicle ID</param>
        /// <param name="DeviceTime">DeviceTime</param>
        /// <param name="session">Session object</param>
        /// <returns>Count of order</returns>
        public static Guid GetSessionDetail(Int32 loginID, String password, String companyID, Int32 vehicleID, DateTime loginTime, ISession session, String VersionNo = "")
        {
            Guid sessionID = new Guid();
            LoginHistoryTableAdapter ta = new LoginHistoryTableAdapter();
            ta.CurrentConnection = session;
            List<LoginHistory> lst = ta.GetSessionDetail(loginID, vehicleID, companyID).Select().Cast<DAL.LoginHistoryRow>().ToList().ToEntities();

            if (lst.Count > 0)
            {
                sessionID = lst[0].SessionID;
            }

            return sessionID;
        }
        //2013.12.24 FSWW, Ramesh M Added Report Fine Tuning CR#60835
        public static DateTime GetDeviceLoginTime(Guid sessionID, ISession session, String VersionNo = "")
        {
            DateTime Devicetime = DateTime.MinValue;
            LoginHistoryTableAdapter ta = new LoginHistoryTableAdapter();
            ta.CurrentConnection = session;
            List<LoginHistory> lst = ta.GetDataBySession(sessionID).Select().Cast<DAL.LoginHistoryRow>().ToList().ToEntities();

            if (lst.Count > 0)
            {
                Devicetime = (DateTime)lst[0].DeviceTime;
            }
            return Devicetime;
        }

        /// <summary>
        /// IsPreDutyVoilationSet
        /// Function to Get a boolean condition if pre-duty voilation flag is set
        /// </summary>
        /// <param name="sessionID">SessionID</param>
        /// <returns>True = Pre-Duty Voilation flag set, False = Failed</returns>
        public static Boolean IsPreDutyVoilationSet(Guid sessionID, ISession session, String VersionNo = "")
        {
            InspectionTableAdapter ta = new InspectionTableAdapter();
            ta.CurrentConnection = session;
            List<Inspection> lst = ta.GetInspectionDetails(sessionID).Select().Cast<DAL.InspectionRow>().ToList().ToEntities();

            if (lst.Count > 0)
            {
                if (lst[0].PreDutyViolation == true)
                {
                    ////2013.10.03 FSWW, Ramesh M Added For CR#60533 Pre Duty Inspection Called in login page itself
                    if (lst[0].PreDuty_Inspection != false)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// IsPostDutyVoilationSet
        /// Function to Get a boolean condition if post-duty voilation flag is set
        /// </summary>
        /// <param name="sessionID">SessionID</param>
        /// <returns>True = Post-Duty Voilation flag set, False = Failed</returns>
        public static Boolean IsPostDutyVoilationSet(Guid sessionID, ISession session, String VersionNo = "")
        {
            InspectionTableAdapter ta = new InspectionTableAdapter();
            ta.CurrentConnection = session;
            List<Inspection> lst = ta.GetInspectionDetails(sessionID).Select().Cast<DAL.InspectionRow>().ToList().ToEntities();

            if (lst.Count > 0)
            {
                if (lst[0].PostDutyViolation == true)
                {
                    return true;
                }
            }
            return false;
        }

        // 05-09-2013 FSWW Ramesh M added following code
        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderID"></param>
        /// <param name="includeOrderItems"></param>
        /// <param name="session"></param>
        /// <returns></returns>
        public static List<OrderItem> GetPickedOrderItemDetails(Guid orderID, Boolean includeOrderItems, ISession session, String VersionNo = "")
        {
            OrderPickingDetailsTableAdapter ta = new OrderPickingDetailsTableAdapter();
            ta.CurrentConnection = session;
            List<OrderItem> lstOrderitem = ta.GetDataByOrderItemDetails(orderID.ToString()).Select().Cast<DAL.OrderItemRow>().ToList().ToEntities();
            if (includeOrderItems)
            {
                foreach (OrderItem orderitem in lstOrderitem)
                {
                    if (orderitem.Blend != "N")
                    {
                        orderitem.OrderItemComponent = GetOrderItemComponent(orderitem.ID, session);
                    }
                    orderitem.DeliveryDetails = GetDeliveryDetails(orderitem.ID, session);
                }
            }
            return lstOrderitem;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sessionID"></param>
        /// <param name="UserType"></param>
        /// <param name="session"></param>
        /// <returns></returns>
        public static List<GetDriverDetails> GetDriverDetails(String companyID, String UserType, ISession session, String VersionNo = "")
        {
            GetDriverDetailsTableAdapter ta = new GetDriverDetailsTableAdapter();
            ta.CurrentConnection = session;
            return ta.GetDrivers(companyID, UserType).Select().Cast<DAL.GetDriverDetailsRow>().ToList().ToEntities();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="companyID"></param>
        /// <param name="session"></param>
        /// <returns></returns>
        ///  // 2013.08.16 FSWW, Ramesh M Added For CR#59832 To Get Vehicle Details
        public static List<GetVehicleDetails> GettingVehicleDetails(String companyID, ISession session, String VersionNo = "")
        {
            GetVehicleDetailsTableAdapter ta = new GetVehicleDetailsTableAdapter();
            ta.CurrentConnection = session;
            return ta.GetVehicleDetails(companyID).Select().Cast<DAL.GetVehicleDetailsRow>().ToList().ToEntities();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="companyID"></param>
        /// <param name="session"></param>
        /// <returns></returns>
        // 2014.09.09, CR#64208, Madhu, Add Modified date to GetInspectionElementsData
        public static List<InspectionElements> GettingInspectionElementsDetails(String companyID, DateTime? lastModifiedDate, ISession session, String VersionNo = "")
        {
            InspectionElementsTableAdapter ta = new InspectionElementsTableAdapter();
            ta.CurrentConnection = session;
            return ta.GetElementsData(lastModifiedDate).Select().Cast<DAL.InspectionElementsRow>().ToList().ToEntities();
        }

        // 05-29-2013 FSWW Ramesh M added following code
        public static Int32 GetCurrentLoginIDCountByUserNameAndCustomerID(String UserName, String CustomerID, ISession session, String VersionNo = "")
        {
            LoginUserTableAdapter ta = new LoginUserTableAdapter();
            ta.CurrentConnection = session;
            //Fsww Ramesh M, Added For CR#58896 Added Conversion in sql select statement so Created Procedure GetCurrentLogiIDCountByUserNameAndCustomerId
            return Convert.ToInt32(ta.GetCurrentLogiIDCountByUserNameAndCustomerId(UserName, CustomerID));
        }

        //2014.01.17 Ramesh M Added For  CR#61759 to get from site list 
        public static List<SupplierSupplypointList> GettingFromSiteList(String companyID, ISession session, String VersionNo = "")
        {
            SupplierSupplypointListTableAdapter ta = new SupplierSupplypointListTableAdapter();
            ta.CurrentConnection = session;
            return ta.GetSuppliersupplyPtList(companyID, null).Select().Cast<DAL.SupplierSupplypointListRow>().ToList().ToEntities();
        }
        public static List<SupplierSupplypointList> GettingShipToFromSiteList(String companyID, String ShipToID, ISession session, String VersionNo = "")
        {
            SupplierSupplypointListTableAdapter ta = new SupplierSupplypointListTableAdapter();
            ta.CurrentConnection = session;
            return ta.GetSuppliersupplyPtList(companyID, ShipToID).Select().Cast<DAL.SupplierSupplypointListRow>().ToList().ToEntities();
        }

        #endregion

        #region Update details

        /*public static void UpdateLoginHistory(ISession session, Guid sessionID, Int32 loginID, Int32 vehicleID, String companyID)
        {
            SqlCommand cmd = (SqlCommand)session.CreateCommand();
            cmd.CommandText = "Cloud_UpdateLoginHistory";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@SessionID", sessionID);
            cmd.Parameters.AddWithValue("@LoginID", loginID);
            cmd.Parameters.AddWithValue("@VehicleID", vehicleID);
            cmd.Parameters.AddWithValue("@CustomerID ", companyID);
            cmd.ExecuteNonQuery();
        }*/

        /// <summary>
        /// UpdateLoadDetails
        /// Function to update the records into load details and return boolean
        /// </summary>
        /// <param name="loadID">Load ID</param>
        /// <param name="customerID">Customer ID</param>
        /// <param name="vehicleID">Vehicle ID</param>
        /// <param name="driverID">Driver ID</param>
        /// <param name="session">Session object</param>
        /// <returns>True = Updated successfully, False = Failed</returns>
        public static Boolean UpdateLoadDetails(Guid loadID, String customerID, Int32 vehicleID, Int32 driverID, String RejectedNotes, bool RejectNeedUpdate, ISession session, String VersionNo = "")
        {
            LoadTableAdapter ta = new LoadTableAdapter();
            ta.CurrentConnection = session;
            int stats = ta.UpdateLoadDetails(vehicleID, driverID, DateTime.Now, RejectedNotes, RejectNeedUpdate, loadID, customerID);
            return stats > 0;
        }
        // 2013.12.23 FSWW, Ramesh M Added For CR#60902
        public static Boolean UpdateLoadDetailsByWarehouse(Guid loadID, String customerID, Int32? vehicleID, Int32? driverID, ISession session, String VersionNo = "")
        {
            LoadTableAdapter ta = new LoadTableAdapter();
            ta.CurrentConnection = session;
            int stats = ta.UpdateLoadDetails(vehicleID, driverID, DateTime.Now, null, null, loadID, customerID);
            return stats > 0;
        }


        /// <summary>
        /// Function to update last updated time field
        /// </summary>
        /// <param name="loadID">load ID</param>
        /// <param name="session">session object</param>
        /// <returns>True = Updated successfully, False = Failed</returns>
        public static Boolean UpdateLoadTime(Guid loadID, DateTime deviceDateTime, ISession session, String VersionNo = "")
        {
            LoadTableAdapter ta = new LoadTableAdapter();
            ta.CurrentConnection = session;
            int stats = ta.UpdateTime(DateTime.Now,deviceDateTime, loadID);
            return stats > 0;
        }

        /// <summary>
        /// UpdateUndispatched
        /// </summary>
        /// <param name="loadID">loadID</param>
        /// <param name="session"></param>
        /// <returns></returns>
        //public static int UpdateUndispatched(int? Undispatched, Guid loadID, ISession session, String VersionNo = "")
        //{
        //    LoadTableAdapter ta = new LoadTableAdapter();
        //    ta.CurrentConnection = session;
        //    return ta.UpdateUndispatched(Undispatched, loadID);//
        //}

        public static int UpdateUndispatched(int? Undispatched, Guid loadID, ISession session, String VersionNo = "")
        {
            int isUpdated = 0;
            SqlConnection con = new SqlConnection(session.ConnectionString);
            try
            {
                SqlCommand cmd = (SqlCommand)session.CreateCommand();
                cmd.CommandText = "Cloud_UpdateUndispatchedAndDeletedLoad";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@LoadID", loadID);
                cmd.Parameters.AddWithValue("@Undispatched", Undispatched);

                con.Open();
                SqlDataAdapter sa = new SqlDataAdapter();
                sa.SelectCommand = cmd;
                DataTable dt = new DataTable();
                sa.Fill(dt);
                con.Close();

                if (dt != null && dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["StatusNew"].ToString().Trim().ToUpper() == "SUCCESS")
                    {
                        isUpdated = 1;
                    }
                }
                //isUpdated = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                string exception = ex.Message;
            }
            finally
            {
                con.Close();
            }
            return isUpdated;
        }

        /// <summary>
        /// Update Undispatch Status
        /// </summary>
        /// <param name="loadNo">loadNo</param>
        /// <param name="companyID">companyID</param>
        /// <param name="session">session</param>
        /// <returns>Status</returns>
        public static string UpdateUndispatchStatus(string loadNo, string companyID, ISession session, String VersionNo = "")
        {
            UpdateUndispatchStatusTableAdapter ta = new UpdateUndispatchStatusTableAdapter();
            ta.CurrentConnection = session;
            List<DAL.UpdateUndispatchStatusRow> lst = ta.GetData(loadNo, companyID).Select().Cast<DAL.UpdateUndispatchStatusRow>().ToList();
            return lst[0].Status;
        }

        // 2014.01.17 Ramesh M Added For  CR#61759 to get from site list 
        public static Boolean UpdateSuppliersupplyPt(String customerID, Guid OrderID, Int32 SuppliersupplyPtID, String SupplierDescr, String SupplyPtDescr, ISession session, String VersionNo = "")
        {
            OrderItemTableAdapter ta = new OrderItemTableAdapter();
            ta.CurrentConnection = session;
            return Convert.ToBoolean(ta.UpdateSupplierSupplyPt(customerID, OrderID, SuppliersupplyPtID, SupplierDescr, SupplyPtDescr));
        }

        public static Boolean UpdateFSDriverLogSched(String customerID, int DriverLogSched, ISession session, String VersionNo = "")
        {
            UpdateFSDriverLogSchedTableAdapter ta = new UpdateFSDriverLogSchedTableAdapter();
            ta.CurrentConnection = session;
            return Convert.ToBoolean(ta.Fill(customerID, DriverLogSched));
        }

        public static void UpdateFrtBreakdown(String customerID, char FrtBrkdown, ISession session, String VersionNo = "")
        {
            UpdateFrtBrkdownTableAdapter ta = new UpdateFrtBrkdownTableAdapter();
            ta.CurrentConnection = session;
            ta.UpdateFrtBrkdown(customerID, FrtBrkdown.ToString());
        }

        public static void UpdateDeliveryDateSort(String customerID, char DeliveryDateSort, ISession session, String VersionNo = "")
        {
            Cloud_UpdateDeliveryDateSortTableAdapter ta = new Cloud_UpdateDeliveryDateSortTableAdapter();
            ta.CurrentConnection = session;
            ta.UpdateDeliveryDateSortFlag(customerID, DeliveryDateSort.ToString());
        }

        public static void UpdateBOLImageVolumeStartEndBOLRule(String customerID, char RequireBOLImage, char RequireDeliveryImage, char DeliveryVolumeBSRule, char BOLStartEndDateBSRule, ISession session, String VersionNo = "")
        {
            Cloud_UpdateBOLImageVolumeStartEndBOLRuleTableAdapter ta = new Cloud_UpdateBOLImageVolumeStartEndBOLRuleTableAdapter();
            ta.CurrentConnection = session;
            ta.UpdateBOLImageVolumeStartEndBOLRule(customerID, RequireBOLImage.ToString(), RequireDeliveryImage.ToString(), DeliveryVolumeBSRule.ToString(), BOLStartEndDateBSRule.ToString());
        }

        public static void UpdateStuckLoads(String customerID, Guid LoadID, ISession session, String VersionNo = "")
        {
            Cloud_UpdateStuckLoadsTableAdapter ta = new Cloud_UpdateStuckLoadsTableAdapter();
            ta.CurrentConnection = session;
            ta.GetData_Cloud_UpdateStuckLoads(customerID, LoadID);
        }

        //GetData_Cloud_UpdateStuckLoads
        // 2015-Oct-23 Vinoth Added For Resubmit bol image
        public static Boolean UpdateBolImage(String bolHdrID, Guid loadID, String bolNo, String Image, ISession session, String VersionNo = "")
        {
            Boolean UpdateStatus = false;
            BOLHdrTableAdapter ta = new BOLHdrTableAdapter();
            ta.CurrentConnection = session;
            SqlConnection con = new SqlConnection(session.ConnectionString);
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
            con.Open();
            if (image1 != null)
            {
                //using (SqlCommand cmd = new SqlCommand("UPDATE bolhdr SET [Image] = @binaryVal WHERE  ID = '" + bolHdrID + "' AND LoadID = '" + loadID + "' AND BOLNo = '" + bolNo + "'", con))
                using (SqlCommand cmd = new SqlCommand("UPDATE bolhdr SET [Image] = @binaryVal, NeedBOLImageUpdate = 1 WHERE LoadID = '" + loadID + "' AND BOLNo = '" + bolNo + "'", con))
                {
                    cmd.Parameters.AddWithValue("@binaryVal", image1);
                    int cnt = cmd.ExecuteNonQuery();
                    if (cnt > 0)
                    {
                        UpdateStatus = true;
                        //SqlCommand UpdateNeedUpdateCmd = new SqlCommand("UPDATE BI SET BI.NeedUpdate = 1 , BI.RetryCount= 0 FROM BOLHdr AS BH INNER JOIN BOLItem AS BI ON BH.ID = BI.BOLHdrID WHERE BH.LoadID= '" + loadID + "' AND BH.BOLNo = '" + bolNo + "'", con);
                        //int cntNeedUpdate = UpdateNeedUpdateCmd.ExecuteNonQuery();
                        //if (cntNeedUpdate > 0)
                        //{
                        //    UpdateStatus = true;
                        //}
                    }
                }
            }
            con.Close();
            return UpdateStatus;
        }


        public static void UpdateRemoveLoadByDriverFlag(string customerId, string removeLoadFlag, ISession session, String VersionNo = "")
        {

            SqlConnection con = new SqlConnection(session.ConnectionString);
            try
            {
                SqlCommand cmd = (SqlCommand)session.CreateCommand();
                cmd.CommandText = "Cloud_UpdateEnableRemoveLoad";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CustomerID", customerId);
                cmd.Parameters.AddWithValue("@EnableRemoveLoad", removeLoadFlag);
                con.Open();
                int affectedRows = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Logging.LogError(ex, string.Format("UpdateRemoveLoadFlag is failed for customerId - {0} ", customerId));
            }
            finally
            {
                con.Close();
            }
        }







        #endregion

        #region Get Summary
        // 05-14-2014 MadhuVenkat K - Added for CR 63396 - Add Time Remaining Section to Driver Summary
        public static List<RemainingTimeSummary> GetRemainingTimeSummary(Guid sessionID, DateTime LoginDatetime, DateTime startTime, DateTime endTime, ISession session)
        {

            TimeRemainingDriverSummaryTableAdapter ta = new TimeRemainingDriverSummaryTableAdapter();
            ta.CurrentConnection = session;
            return ta.GetDataTimeRemainingDriverSummary(sessionID, LoginDatetime, startTime, endTime).Select().Cast<DAL.TimeRemainingDriverSummaryRow>().ToList().ToEntities();
        }


        // 2014.02.20  Ramesh M Added For CR#62292 For driver summary log
        public static List<DriverSummary> GetDriverSummary(Guid sessionID, DateTime startTime, DateTime endTime, ISession session, String VersionNo = "")
        {
            /*DriverSummaryTableAdapter ta = new DriverSummaryTableAdapter();
            ta.CurrentConnection = session;
            return ta.GetSummaryData(sessionID, startTime, endTime,1,Guid.Empty).Select().Cast<DAL.DriverSummaryRow>().ToList().ToEntities();
            */
            DriverSummaryTableAdapter ta = new DriverSummaryTableAdapter();
            ta.CurrentConnection = session;
            return ta.GetSumaryData(sessionID, startTime, endTime, 5, null).Select().Cast<DAL.DriverSummaryRow>().ToList().ToEntities();
        }

        // 2015.06.25  Added by vinoth for get latest updated driverlog details
        public static DataTable GetDriverLogDetails(Guid sessionID, DateTime startTime, DateTime endTime, DateTime? modifiedTime, ISession session, String VersionNo = "")
        {
            /*DriverSummaryTableAdapter ta = new DriverSummaryTableAdapter();
            ta.CurrentConnection = session;
            return ta.GetSummaryData(sessionID, startTime, endTime,1,Guid.Empty).Select().Cast<DAL.DriverSummaryRow>().ToList().ToEntities();
            */
            Cloud_DriverLogDetailsTableAdapter ta = new Cloud_DriverLogDetailsTableAdapter();
            ta.CurrentConnection = session;
            return ta.GetDriverLogDetails(sessionID, startTime, endTime, modifiedTime);
        }

        public static List<DriverLogs> GetDriverLog(Guid sessionID, DateTime endTime, DateTime currentTime, ISession session, String VersionNo = "")
        {
            GetDriverLogsTableAdapter ta = new GetDriverLogsTableAdapter();
            ta.CurrentConnection = session;
            return ta.GetDriverLogData(sessionID, endTime, currentTime).Select().Cast<DAL.GetDriverLogsRow>().ToList().ToEntities();
        }

        //2013.10.09 FSWW, Ramesh M Added For  CR#60620.
        public static String ListOFLoadNosToMerge(String CustomerID, String Connection, String VersionNo = "")
        {
            String LoadNos = null;
            GetLoadsTableAdapter ta = new GetLoadsTableAdapter();
            ta.Connection = new SqlConnection(Connection);
            DataTable Dt = new DataTable();
            Dt = ta.GetData(CustomerID);
            foreach (DataRow dr in Dt.Rows)
            {
                LoadNos += dr["LoadNo"].ToString() + ",";
            }
            return LoadNos;
        }
        //2013.10.09 FSWW, Ramesh M Added For  CR#60620.
        public static Boolean ListOFOrderNosToMerge(String CustomerID, String OrderNo, String OrderStatus, String Connection, String VersionNo = "")
        {
            if (OrderStatus.ToUpper() == "C")
            {
                OrderStatus = "U";
            }
            Guid LoadID = GelLoadIDByLoadNo(OrderNo, Connection);
            if (LoadID != Guid.Empty)
            {
                LoadStatusHistoryTableAdapter ta = new LoadStatusHistoryTableAdapter();
                ta.Connection = new SqlConnection(Connection);
                ta.AddLoadStatusHistory(LoadID, OrderStatus, 1, "00", "00", "", "", false, DateTime.Now, "00000000-0000-0000-0000-000000000000", DateTime.Now);
                return true;
            }
            else
            {
                return false;
            }

        }
        //2013.10.09 FSWW, Ramesh M Added For  CR#60620.
        public static Guid GelLoadIDByLoadNo(String LoadNo, String Connection, String VersionNo = "")
        {
            LoadTableAdapter ta = new LoadTableAdapter();
            ta.Connection = new SqlConnection(Connection);
            return ta.GetLoadIDByLoadNo(LoadNo) ?? Guid.Empty;
        }

        // 2014.02.20  Ramesh M Added For CR#62301 For Driver status Screen in Ipad
        public static List<DriverLogStatus> GettingDriverLogStatus(Guid sessionID, DateTime startTime, DateTime endTime, ISession session, String VersionNo = "")
        {
            DriverLogStatusTableAdapter ta = new DriverLogStatusTableAdapter();
            ta.CurrentConnection = session;
            return ta.GetData(sessionID, startTime, endTime, 5, null).Select().Cast<DAL.DriverLogStatusRow>().ToList().ToEntities();
        }


        #endregion

        #region Add Details
        // 2015.02.02 Madhu Added For CR#66160 For Add App Version No in the login session table for every login sessions 
        public static void AddLoginSession(LoginSession loginSession, ISession session, String VersionNo)
        {
            LoginSessionTableAdapter ta = new LoginSessionTableAdapter();
            ta.CurrentConnection = session;
            ta.InsertQuery(loginSession.SessionID, loginSession.LoginID.ToString(), loginSession.DeviceID, DateTime.Now.ToString(), loginSession.CurrentVehicle.ToString(), loginSession.Active.ToString(), loginSession.LogonTime.ToString(), loginSession.Version, loginSession.IOSVersion);

        }

        /// <summary>
        /// AddLoad
        /// Function to insert the records into load table
        /// </summary>
        /// <param name="customerID">Customer ID</param>
        /// <param name="load">Load object</param>
        /// <param name="insertOrders">Insert orders</param>
        /// <param name="insertOrderItems">Insert order items</param>
        /// <param name="insertBolHdr">Insert BOL header</param>
        /// <param name="session">Session object</param>
        public static void AddLoad(String customerID, Load load, Guid loadId, Boolean insertOrders, Boolean insertOrderItems, Boolean insertBolHdr, ISession session, String VersionNo = "")
        {
            LoadTableAdapter ta = new LoadTableAdapter();
            ta.CurrentConnection = session;

            //Guid loadId = Guid.NewGuid();
            int? vehicleID = null;
            int? driverId = null;
            Boolean acceptedorder = false;


            //2013.09.13 FSWW, Ramesh M Added For CR#?.. IF warehouse user means to send Null value For VehicleID and DriverID
            // if (load.LoadType.ToLower() != "w")
            //{
            if (load.VehicleID > 0)
            {
                //vehicleID = load.VehicleID;
                // 2014.02.14  Ramesh M Added For getting vehicleid from  vehicle code and customerid for  CR#62289 and commented origional vehicleid
                vehicleID = GetVehicleID(load.VehicleCode, customerID, session, VersionNo);
            }

            if (load.DriverID > 0)
            {
                driverId = load.DriverID;
            }
            //}

            //2014.06.24, Madhu Venkat for handling the dispatch change 
            double VersNo = Convert.ToDouble(VersionNo);
            if (VersNo > 1.40)
            {
                if (load.LoadType == "Z")
                {
                    load.LoadType = "V";
                }
            }
            //if (load.LoadType == "Z")
            //{
            //    load.LoadType = "V";
            //}
            // 2014.01.23  Ramesh M Added For CR#61759 Added ShipToID


            //ta.InsertQuery(loadId, load.LoadNo, customerID, vehicleID, driverId, load.FSRule_BOLWaitTime, load.FSRule_SiteWaitTime, load.FSRule_SplitLoad, load.FSRule_SplitDrop, load.FSRule_PumpOut, load.FSRule_Diversion, load.FSRule_MinLoad, load.FSRule_Other, load.FSRule_BOLWaitTime_Reason, load.FSRule_SiteWaitTime_Reason, load.FSRule_SplitLoad_Reason, load.FSRule_SplitDrop_Reason, load.FSRule_PumpOut_Reason, load.FSRule_Diversion_Reason, load.FSRule_MinLoad_Reason, load.FSRule_Other_Reason, load.PercentTolerance, load.QtyTolerance, load.OrderLoadReviewEnabled, load.LoadType, load.ShipToID, 1);
            //else
            ta.InsertQuery(loadId, load.LoadNo, customerID, vehicleID, driverId, load.FSRule_BOLWaitTime, load.FSRule_SiteWaitTime, load.FSRule_SplitLoad, load.FSRule_SplitDrop, load.FSRule_PumpOut, load.FSRule_Diversion, load.FSRule_MinLoad, load.FSRule_Other, load.FSRule_BOLWaitTime_Reason, load.FSRule_SiteWaitTime_Reason, load.FSRule_SplitLoad_Reason, load.FSRule_SplitDrop_Reason, load.FSRule_PumpOut_Reason, load.FSRule_Diversion_Reason, load.FSRule_MinLoad_Reason, load.FSRule_Other_Reason, load.PercentTolerance, load.QtyTolerance, load.OrderLoadReviewEnabled, load.LoadType, load.ShipToID);

            if (insertOrders)
            {
                AddOrder(loadId, customerID, load.Orders, insertOrderItems, session);

                //2013.09.17 FSWW, Ramesh M Added For CR#?.. Added New Entry in LoadStatusHistoryTable For Moving Load From Ascend To DeliveryStream                
                // AddLoadStatus(loadId, 225, "A", "0", "0", "00000000-0000-0000-0000-000000000000", DateTime.Now, session, VersionNo);

            }
        }

        /// <summary>
        /// AddLoadStatus
        /// Function to insert the records into load status history table
        /// </summary>
        /// <param name="loadID">Load ID</param>
        /// <param name="loginUserID">Login user ID</param>
        /// <param name="loadStatusID">Load status ID</param>
        /// <param name="longitude">Longitude</param>
        /// <param name="latitude">Latitude</param>
        /// <param name="deviceID">deviceID</param>
        /// <param name="deviceTime">deviceTime</param>
        /// <param name="session">Session object</param>
        public static void AddLoadStatus(Guid loadID, Int32 loginUserID, String loadStatusID, String longitude, String latitude, String city, String state, String deviceID, DateTime deviceTime, ISession session, String VersionNo = "")
        {
            LoadStatusHistoryTableAdapter ta = new LoadStatusHistoryTableAdapter();
            ta.CurrentConnection = session;
            if (ta.GetDataByDeviceID(loadID, loginUserID, deviceID, deviceTime).Count == 0)
            {
                ta.AddLoadStatus(loadID, loadStatusID, loginUserID, longitude, latitude, city, state, true, DateTime.Now, deviceID, deviceTime);
            }


        }
        //2013.09.26 FSWW, Ramesh M Added For CR#59831
        public static void UpdateLoadStatus(Guid loadID, Int32 loginUserID, ISession session, String VersionNo = "")
        {
            LoadStatusHistoryTableAdapter ta = new LoadStatusHistoryTableAdapter();
            ta.CurrentConnection = session;
            ta.UpdateLoadStatus(loginUserID, loadID);
        }

        // 10-17-2014  MadhuVenkat k - Added for CR 65285  -  Order processing is stalling when ShipTo-> DestNotes exceeds 200 chars. 
        /// <summary>
        /// AddOrder
        /// Function to insert the records into Order table
        /// </summary>
        /// <param name="loadID">Load ID</param>
        /// <param name="loginUserID">Login user ID</param>
        /// <param name="orders">Order object</param>
        /// <param name="insertOrderItems">Insert order items</param>
        /// <param name="session">Session object</param>
        private static void AddOrder(Guid loadID, String loginUserID, List<Order> orders, Boolean insertOrderItems, ISession session, String VersionNo = "")
        {
            OrderTableAdapter ta = new OrderTableAdapter();
            ta.CurrentConnection = session;
            foreach (Order order in orders)
            {
                Guid orderID = Guid.NewGuid();
                //2013.12.02  Fsww Ramesh M, Added for  RequestedDtTm CR#61274 
                //if (order.Notes != "" && order.Notes != null)
                //{ 
                //    Logging.LogInfoAboutCallingFunction("AddOrder: OrderNotes Total Length - " + order.Notes.Length.ToString() + " loadid:" + loadID);
                //    Logging.LogInfoAboutCallingFunction("AddOrder: OrderNotes Total Length - " + order.Notes + " loadid:" + loadID);
                //}

                ta.InsertQuery(orderID, order.OrderNo, order.SysTrxNo, loadID,
                    order.PromisedDtTm, order.DestAddress1, order.DestAddress2, order.City, order.State, order.Zip, order.DestNotes, order.DestSite, order.Country, order.RequestedDtTm, order.PONo, order.PriorityNo, order.Notes);
                //Logging.LogInfoAboutCallingFunction("Vinoth 3 ; " + "CustomerID-" + order.OrderItems.Count.ToString());
                if (order.OrderItems != null && order.OrderItems.Count > 0)
                {
                    //Logging.LogInfoAboutCallingFunction("Vinoth 3A ; " + "CustomerID-" + order.OrderItems[0].ID.ToString());
                    AddOrderItem(orderID, order.OrderItems, insertOrderItems, session);
                }
            }

        }
        // 03-25-2015  MadhuVenkat k - Added for CR 66587  -  Application should deliver the Pre-Blend products and shown the Quantity details in Ship Doc.
        /// <summary>
        /// AddOrderItem
        /// Function to insert the records into order item table
        /// </summary>
        /// <param name="orderID">Order ID</param>
        /// <param name="orderItems">Order items</param>
        /// <param name="insertOrderItems">Insert order items</param>
        /// <param name="session">Session object</param>
        private static void AddOrderItem(Guid orderID, List<OrderItem> orderItems, Boolean insertOrderItems, ISession session, String VersionNo = "")
        {
            OrderItemTableAdapter ta = new OrderItemTableAdapter();
            ta.CurrentConnection = session;
            //Logging.LogInfoAboutCallingFunction("Vinoth 4 ; " + "CustomerID-" + orderItems.Count.ToString());
            foreach (OrderItem orderItem in orderItems)
            {
                //Logging.LogInfoAboutCallingFunction("Vinoth 4A ; " + "CustomerID-" + orderID.ToString());
                //Logging.LogInfoAboutCallingFunction("Vinoth 4A1 ; " + "CustomerID-" + orderItem.ProdCode.ToString());
                //Logging.LogInfoAboutCallingFunction("Vinoth 4A2 ; " + "CustomerID-" + orderItem.ProdName.ToString());
                Guid orderitemID = Guid.NewGuid();

                //Logging.LogInfoAboutCallingFunction("Vinoth 4A2 ; " + orderitemID.ToString() + ", " + orderID.ToString() + ", " + orderItem.SysTrxLine.ToString() + ", " +
                //  orderItem.OrderedQty.ToString() + ", " + orderItem.ProdCode + ", " + orderItem.ProdName + ", " + orderItem.ProdUOM + ", " +
                //  orderItem.Blend + ", " + orderItem.SupplierName + ", " + orderItem.SupplierCode + ", " + orderItem.SupplyPointName + ", " + orderItem.SupplyPointCode + ", " +
                //  orderItem.SupplyPointAddress1 + ", " + orderItem.SupplyPointAddress2 + ", " + orderItem.City + orderItem.State + ", " +
                //    orderItem.Zip + ", " + orderItem.Country + ", " + orderItem.Note);

                ta.InsertOrderItems(orderitemID, orderID, orderItem.SysTrxLine,
                  orderItem.OrderedQty, orderItem.ProdCode, orderItem.ProdName, orderItem.ProdUOM,
                  orderItem.Blend, orderItem.SupplierName, orderItem.SupplierCode, orderItem.SupplyPointName, orderItem.SupplyPointCode,
                  orderItem.SupplyPointAddress1, orderItem.SupplyPointAddress2, orderItem.City, orderItem.State,
                  orderItem.Zip, orderItem.Country, orderItem.Note, orderItem.ARShipToTankID, orderItem.ARShipToTankCode);

                if (orderItem.OrderItemComponent != null)
                {
                    if (orderItem.OrderItemComponent.Count > 0)
                        AddOrderItemComponent(orderitemID, orderItem.OrderItemComponent, session);
                }
            }

        }

        /// <summary>
        /// AddOrderItemComponent
        /// Function to insert the records into order item component table
        /// </summary>
        /// <param name="orderItemID">Order item ID</param>
        /// <param name="orderItemscomps">OrderItemComponent object</param>
        /// <param name="session">Session object</param>
        private static void AddOrderItemComponent(Guid orderItemID, List<OrderItemComponent> orderItemscomps, ISession session, String VersionNo = "")
        {
            OrderItemComponentTableAdapter ta = new OrderItemComponentTableAdapter();
            ta.CurrentConnection = session;
            foreach (OrderItemComponent orderItemscomp in orderItemscomps)
            {

                ta.InsertComponentItem(Guid.NewGuid(), orderItemID, orderItemscomp.ComponentNo,
                 orderItemscomp.Qty, orderItemscomp.ProdCode, orderItemscomp.ProdName,
                 orderItemscomp.ProdUOM, orderItemscomp.SupplierName, orderItemscomp.SupplierCode, orderItemscomp.SupplyPointName, orderItemscomp.SupplyPointCode, orderItemscomp.SupplyPointAddress1, orderItemscomp.SupplyPointAddress2,
                 orderItemscomp.City, orderItemscomp.State, orderItemscomp.Zip, orderItemscomp.Country, orderItemscomp.FromCSTankID, orderItemscomp.ToCSTankID, orderItemscomp.FromCSTankCode, orderItemscomp.ToCSTankCode);
            }

        }

        /// <summary>
        /// AddOrderStatus
        /// Function to insert the records into order status history table
        /// </summary>
        /// <param name="OrderID">Order ID</param>
        /// <param name="loginUserID">Login User ID</param>
        /// <param name="orderStatusID">Order Status ID</param>
        /// <param name="longitude">Longitude</param>
        /// <param name="latitude">Latitude</param>
        /// <param name="deviceID">deviceID</param>
        /// <param name="deviceTime">deviceTime</param>
        /// <param name="session">Session object</param>
        public static void AddOrderStatus(Guid OrderID, Int32 loginUserID, String orderStatusID, String longitude, String latitude, String deviceID, DateTime deviceTime, ISession session, String VersionNo = "")
        {
            OrderStatusHistoryTableAdapter ta = new OrderStatusHistoryTableAdapter();
            ta.CurrentConnection = session;
            if (ta.GetDataByDeviceID(OrderID, loginUserID, deviceID, deviceTime).Count == 0)
            {
                ta.AddOrderStatus(OrderID, orderStatusID, loginUserID, longitude, latitude, true, DateTime.Now, deviceID, deviceTime);
            }
        }

        //05-24-2013 Fsww Ramesh M, Added GpsStrength column in Table GPSHistory so added parameter (String GpsStrength) here for updation
        // 2013.10.24 FSWW Ramesh M Added gpsHist.TruckSpeed For CR#61148, and removed gpsHist.PreviousLongitude,gpsHist.PreviousLatitude- parmeters
        // 2014.02.25  Ramesh M Added For CR#62406 For DriverID,VechileID,UserLoginID, IsNewSession
        // 2014.03.05  Ramesh M Added For CR#62301 For City added
        /// <summary>
        /// AddGPSHistory
        /// Function to insert the records into  GPS history table
        /// </summary>
        /// <param name="longitude">Longitude</param>
        /// <param name="latitude">Latitude</param>
        /// <param name="deviceTime">deviceTime</param>
        /// <param name="SessionID">SessionID</param>
        public static void AddGPSHistory(String longitude, String latitude, Guid sessionID, DateTime deviceTime, ISession session, DateTime GMT, String sGpsStrength, String sStatus, Int32 TruckSpeed, Int32 ConfiguredSpeedLimit, String State, Int32 DriverID, Int32 VechicleID, String CustomerID, Int32 LoginID, String IsNewSession, String City, String StatusUpdate, String VersionNo = "")
        {
            GPSHistoryTableAdapter ta = new GPSHistoryTableAdapter();
            ta.CurrentConnection = session;
            //Logging.WriteLog("Data:: longitude:" + longitude + " latitude:" + latitude + " sessionID:" + sessionID + " DeviceTime:" + deviceTime.ToString(), System.Diagnostics.EventLogEntryType.Error);
            if (ta.GetDataByDeviceTime(deviceTime, sessionID).Count == 0)
            {
                //Logging.WriteLog("Going To add Record", System.Diagnostics.EventLogEntryType.Error);

                //ta.InsertGPSHistory(longitude, latitude, Convert.ToString(DateTime.Now), Convert.ToString(deviceTime), sessionID, Convert.ToString(GMT), sGpsStrength, sStatus);

                //10-22-2013 Fsww Ramesh M,Added For CR#60386.Added PreviousLongtitude,PreviousLatitude
                // 2014.02.25  Ramesh M Added For CR#62406 For DriverID,VechileID,UserLoginID, IsNewSession
                // 2014.03.05  Ramesh M Added For CR#62301 For City added
                ta.ADDGPSHISTORY(longitude, latitude, DateTime.Now, deviceTime, sessionID, GMT, sGpsStrength, sStatus, TruckSpeed, ConfiguredSpeedLimit, State, DriverID, VechicleID, CustomerID, LoginID, IsNewSession, City, StatusUpdate);

                //Logging.WriteLog("Record add Record", System.Diagnostics.EventLogEntryType.Error);
            }
            //Logging.WriteLog("AddGPSHistory function end", System.Diagnostics.EventLogEntryType.Error);
        }

        /// <summary>
        /// AddGPSHistory
        /// Function to insert the records into  GPS history table by user
        /// </summary>
        /// <param name="loginID">LoginID</param>
        /// <param name="longitude">Longitude</param>
        /// <param name="latitude">Latitude</param>
        /// <param name="deviceTime">deviceTime</param>
        public static void AddGPSHistoryByUser(Int32 loginID, String longitude, String latitude, DateTime deviceTime, ISession session, DateTime GMT, String VersionNo = "")
        {
            GPSHistoryTableAdapter ta = new GPSHistoryTableAdapter();
            ta.CurrentConnection = session;
            ta.InsertGpsHistoryByUser(longitude, latitude, Convert.ToString(DateTime.Now), Convert.ToString(deviceTime), loginID, Convert.ToString(GMT));
        }
        //2014.03.18 Ramesh M, Added For CR#62719 added  TrailerCode in input parameters
        //09-23-2014  MadhuVenkat k - Added for CR#65002  added SupplierCode and SupplyPointCode.
        /// <summary>
        /// AddBolHdr
        /// Function to insert the records into BOL header table
        /// </summary>
        /// <param name="bolHdrID">BOL header ID</param>
        /// <param name="loadID">Load ID</param>
        /// <param name="bolNo">BOL number</param>
        /// <param name="image">Image</param>
        /// <param name="bolDateTime">BOL date</param>
        /// <param name="loginUserID">Login user ID</param>
        /// <param name="session">Session object</param>
        public static void AddBolHdr(Guid bolHdrID, Guid loadID, String bolNo, byte[] image, DateTime bolDateTime, DateTime? bolDatetTimeEnd, Int32 loginUserID, Boolean BOLWaitTime, String BOLWaitTime_Comment, DateTime? BOLWaitTime_Start, DateTime? BOLWaitTime_End, ISession session, String TrailerCode, String SupplierCode, String SupplyPointCode, String VersionNo = "")
        {
            BOLHdrTableAdapter ta = new BOLHdrTableAdapter();
            ta.CurrentConnection = session;
            ta.InsertQuery(bolHdrID, loadID, bolNo, image, bolDateTime, bolDatetTimeEnd, loginUserID, BOLWaitTime, BOLWaitTime_Comment, BOLWaitTime_Start, BOLWaitTime_End, TrailerCode, SupplierCode, SupplyPointCode);
        }

        public static void SaveBolHdr(Guid bolHdrID, Guid loadID, String bolNo, byte[] image, DateTime bolDateTime, DateTime? bolDatetTimeEnd, Int32 loginUserID, Boolean BOLWaitTime, String BOLWaitTime_Comment, DateTime? BOLWaitTime_Start, DateTime? BOLWaitTime_End, ISession session, String TrailerCode, String SupplierCode, String SupplyPointCode, String VersionNo = "", byte IsUserAcknowledgedZeroQty = 0)
        {
            SqlCommand cmd = (SqlCommand)session.CreateCommand();
            cmd.CommandText = "Cloud_AddBOLHdr";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID", bolHdrID);
            cmd.Parameters.AddWithValue("@LoadID", loadID);
            cmd.Parameters.AddWithValue("@BOLNo", bolNo);
            cmd.Parameters.AddWithValue("@Image", image);
            cmd.Parameters.AddWithValue("@Dttm", bolDateTime);
            cmd.Parameters.AddWithValue("@DttmEnd", bolDatetTimeEnd);
            cmd.Parameters.AddWithValue("@UpdatedBy", loginUserID);
            cmd.Parameters.AddWithValue("@BOLWaitTime", BOLWaitTime);
            cmd.Parameters.AddWithValue("@BOLWaitTime_Comment", BOLWaitTime_Comment);
            cmd.Parameters.AddWithValue("@BOLWaitTime_Start", BOLWaitTime_Start);
            cmd.Parameters.AddWithValue("@BOLWaitTime_End", BOLWaitTime_End);
            cmd.Parameters.AddWithValue("@TrailerCode", TrailerCode);
            cmd.Parameters.AddWithValue("@SupplierCode", SupplierCode);
            cmd.Parameters.AddWithValue("@SupplyPointCode", SupplyPointCode);
            cmd.Parameters.AddWithValue("@IsUserAcknowledgedZeroQty", IsUserAcknowledgedZeroQty);
            cmd.ExecuteNonQuery();
        }

        public static void AddBolDetailsTemp(Guid loadID, string componentsXML, ISession session, String VersionNo = "")
        {
            SqlCommand cmd = (SqlCommand)session.CreateCommand();
            cmd.CommandText = "Cloud_AddBolDetailsTemp";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@LoadID", loadID);
            cmd.Parameters.AddWithValue("@ComponentsXML", componentsXML);
            cmd.ExecuteNonQuery();
        }

        public static Guid GetOrderIDFromOrderItemID(Guid orderItemID, ISession session, String VersionNo = "")
        {
            Guid orderID = Guid.Empty;
            SqlConnection con = new SqlConnection(session.ConnectionString);
            try
            {
                SqlCommand cmd = (SqlCommand)session.CreateCommand();
                cmd.CommandText = "Cloud_GetOrderIDFromOrderItemID";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OrderItemID", orderItemID);

                con.Open();

                object result = cmd.ExecuteScalar();
                con.Close();
                if (result != null)
                {
                    orderID = (Guid)result;
                }

            }
            catch (Exception ex)
            {
                Logging.LogError(ex, string.Format("GetOrderIDFromOrderItemID - {0}", ex.Message));
            }
            finally
            {
                con.Close();
            }
            return orderID;
        }

        public static void AddLoadDispatchChangeHistory(Guid OldloadID, String OldLoadNo, String CustomerID, int OldVehicleID, int OldDriverID, Guid NewLoadID, ISession session, String VersionNo = "")
        {
            SqlCommand cmd = (SqlCommand)session.CreateCommand();
            cmd.CommandText = "Cloud_AddLoadDispatchChangeHistory";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@OldLoadID", OldloadID);
            cmd.Parameters.AddWithValue("@OldLoadNo", OldLoadNo);
            cmd.Parameters.AddWithValue("@CustomerID", CustomerID);
            cmd.Parameters.AddWithValue("@OldVehicleID", OldVehicleID);
            cmd.Parameters.AddWithValue("@OldDriverID", OldDriverID);
            cmd.Parameters.AddWithValue("@NewLoadID", NewLoadID);
            cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// AddBolItem
        /// Function to insert the records into BOL item table
        /// </summary>
        /// <param name="bolHdrID">BOL header</param>
        /// <param name="sysTrxNo">System transaction number</param>
        /// <param name="sysTrxLine">System transaction line</param>
        /// <param name="componentNo">Component number</param>
        /// <param name="grossQty">Gross quantity</param>
        /// <param name="netQty">Net quantity</param>
        /// <param name="loginUserID">Login user ID</param>
        /// <param name="deviceID">deviceID</param>
        /// <param name="deviceTime">deviceTime</param>
        /// <param name="session">Session object</param>
        /// //addd
        public static void AddBolItem(Guid bolHdrID, Decimal sysTrxNo, Int32 sysTrxLine, Int32 componentNo, Decimal grossQty, Decimal netQty, Int32 loginUserID, String deviceID, DateTime deviceTime, string BOLQtyVarianceReason, Int32 AssignedDriverLoginID, Int32 AssignedVehicleID, ISession session, Int32 ExtSysTrxLine, Guid OrderItemID, String VersionNo = "")
        {
            BOLItemTableAdapter ta = new BOLItemTableAdapter();
            ta.CurrentConnection = session;
            Guid id = Guid.NewGuid();


            List<Bolitem> lstBolItems = ta.GetDataByDeviceID(bolHdrID, sysTrxNo, sysTrxLine, componentNo, loginUserID, deviceID, deviceTime).Select().Cast<DAL.BOLItemRow>().ToList().ToEntities();
            if (lstBolItems.Count == 0)
            {
                lstBolItems = ta.GetDataByBolItemDetail(Guid.Empty, bolHdrID, sysTrxNo, sysTrxLine, componentNo).Select().Cast<DAL.BOLItemRow>().ToList().ToEntities();
                if (lstBolItems.Count > 0)
                {
                    ta.UpdateQuery(grossQty, netQty, true, loginUserID, deviceID, deviceTime, BOLQtyVarianceReason == "" ? null : BOLQtyVarianceReason, AssignedDriverLoginID, AssignedVehicleID, lstBolItems[0].ID);

                }
                else
                {
                    //2014.01.28  Ramesh M Added For Support Multi BOL ites added ExtSysTrxLine For CR#62038
                    ta.AddBOLItem(id, bolHdrID, sysTrxNo, sysTrxLine, componentNo, grossQty, netQty, loginUserID, deviceID, deviceTime, BOLQtyVarianceReason == "" ? null : BOLQtyVarianceReason, AssignedDriverLoginID, AssignedVehicleID, ExtSysTrxLine, OrderItemID);

                }
            }

        }
        // 12-17-2014  MadhuVenkat K  Added for CR 65762 - In Multi BOL processing, the gross qty and Net qty not updating correct qty.
        /// <summary>
        /// AddDeliveryDetails
        /// Function to insert the records into delivery details table
        /// </summary>
        /// <param name="orderItemID">Order item ID</param>
        /// <param name="grossQty">Gross quantity</param>
        /// <param name="netQty">Net quantity</param>
        /// <param name="delivQty">delivered quantity</param>
        /// <param name="loginUserID">Login user ID</param>
        /// <param name="deviceID">deviceID</param>
        /// <param name="deviceTime">deviceTime</param>
        /// <param name="session">Session object</param>
        /// 
        public static void AddDeliveryDetails(Guid orderItemID, Decimal grossQty, Decimal netQty, Decimal delivQty, DateTime delivDtTm, Int32 loginUserID, String deviceID, DateTime deviceTime, Decimal? beforeVolume, Decimal? afterVolume, ISession session, String IsDelivered, string DeliveryQtyVarianceReason, String BOLNo, String Image, String Notes, String PONo, Guid PreOrderItemID, String VersionNo = "")
        {
            DeliveryDetailsTableAdapter ta = new DeliveryDetailsTableAdapter();
            ta.CurrentConnection = session;
            deviceTime = DateTime.Now.AddMilliseconds(10);
            //   deviceTime = deviceTime.AddMinutes(5);
            List<DeliveryDetails> lstDeliv = ta.GetDataByDevice(orderItemID, loginUserID, deviceID, deviceTime).Select().Cast<DAL.DeliveryDetailsRow>().ToList().ToEntities();
            Logging.LogInfoAboutCallingFunction("AddDeliveryDetailsOldMethodCalled : orderItemID: " + orderItemID);
            SqlConnection con = new SqlConnection(session.ConnectionString);
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
            if (lstDeliv.Count == 0)
            {
                //Temporarly hidden
                // lstDeliv = ta.GetDeliveryDetails(orderItemID).Select().Cast<DAL.DeliveryDetailsRow>().ToList().ToEntities();
                Logging.LogInfoAboutCallingFunction("GrossQty :" + grossQty);
                Logging.LogInfoAboutCallingFunction("NetQty :" + netQty);
                Logging.LogInfoAboutCallingFunction("DelivQty :" + delivQty);

                List<DeliveryDetails> lstDelivcount;
                lstDelivcount = ta.GetDataByDeliveryCount(orderItemID, BOLNo).Select().Cast<DAL.DeliveryDetailsRow>().ToList().ToEntities();

                if (lstDelivcount.Count > 0)
                {
                    ta.UpdateQuery(grossQty, netQty, delivQty, delivDtTm, loginUserID, true, deviceID, deviceTime, beforeVolume, afterVolume, DeliveryQtyVarianceReason == "" ? null : DeliveryQtyVarianceReason, BOLNo, Notes, orderItemID, PreOrderItemID);
                    //ta.UpdateQuery(grossQty, netQty, delivQty, delivDtTm, loginUserID, true, deviceID, deviceTime, beforeVolume, afterVolume, DeliveryQtyVarianceReason == "" ? null : DeliveryQtyVarianceReason, orderItemID);

                }
                else
                {

                    ta.InsertQuery(orderItemID, grossQty, netQty, delivQty, delivDtTm, loginUserID, deviceID, deviceTime, beforeVolume, afterVolume, IsDelivered, DeliveryQtyVarianceReason == "" ? null : DeliveryQtyVarianceReason, BOLNo, Notes, PreOrderItemID);
                    // ta.InsertQuery(orderItemID, grossQty, netQty, delivQty, delivDtTm, loginUserID, deviceID, deviceTime, beforeVolume, afterVolume, DeliveryQtyVarianceReason == "" ? null : DeliveryQtyVarianceReason);
                    // Logging.LogInfoAboutCallingFunction("DALMethod - AddDeliveryDetails 3 : lstDelivCount" + lstDeliv.Count + ":" + orderItemID + ":" + loginUserID + ":" + deviceID + ":" + deviceTime);

                }
                //upto this

                con.Open();

                //using (SqlCommand cmd = new SqlCommand())
                //{
                //    cmd.CommandText = "Cloud_CreateDeliveryDetails";
                //    cmd.CommandType = CommandType.StoredProcedure;
                //    cmd.Connection = con;
                //    cmd.Parameters.AddWithValue("@OrderItemID", orderItemID);
                //    cmd.Parameters.AddWithValue("@GrossQty", grossQty);
                //    cmd.Parameters.AddWithValue("@NetQty", netQty);
                //    cmd.Parameters.AddWithValue("@DelivQty", delivQty);
                //    cmd.Parameters.AddWithValue("@DeliveryDateTime", delivDtTm);
                //    cmd.Parameters.AddWithValue("@UpdatedBy", loginUserID);
                //    cmd.Parameters.AddWithValue("@DeviceID", deviceID);
                //    cmd.Parameters.AddWithValue("@DeviceTime", deviceTime);
                //    cmd.Parameters.AddWithValue("@BeforeVolume", beforeVolume);
                //    cmd.Parameters.AddWithValue("@AfterVolume", afterVolume);
                //    cmd.Parameters.AddWithValue("@IsDelivered", IsDelivered);
                //    cmd.Parameters.AddWithValue("@DeliveryQtyVarianceReason", DeliveryQtyVarianceReason);
                //    cmd.Parameters.AddWithValue("@BOLNo", BOLNo);
                //    cmd.Parameters.AddWithValue("@Notes", Notes);
                //    cmd.Parameters.AddWithValue("@PreOrderItemID", PreOrderItemID);

                //    SqlDataAdapter sa = new SqlDataAdapter();
                //    sa.SelectCommand = cmd;
                //    DataTable dt = new DataTable();
                //    sa.Fill(dt);
                //    //con.Close();

                //    int isUpdated = 0;
                //    if (dt != null && dt.Rows.Count > 0)
                //    {
                //        if (dt.Rows[0]["StatusNew"].ToString().Trim().ToUpper() == "SUCCESS")
                //        {
                //            isUpdated = 1;
                //        }
                //        else
                //        {
                //            Logging.LogInfoAboutCallingFunction("Cloud_CreateDeliveryDetails: Failed to Insert - " + dt.Rows[0]["Reason"].ToString().Trim());
                //        }
                //    }
                //}
                if (image1 != null)
                {

                    using (SqlCommand cmd = new SqlCommand("UPDATE DeliveryDetails SET [Image] = @binaryVal WHERE  OrderItemID = '" + orderItemID + "'", con))
                    {
                        cmd.Parameters.AddWithValue("@binaryVal", image1);
                        cmd.ExecuteNonQuery();
                    }
                }
                Guid OrderID = GetOrderID(orderItemID, session, VersionNo);
                if (OrderID != null)
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "Cloud_UpdateOrderPONo";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = con;
                        cmd.Parameters.AddWithValue("@OrderID", OrderID);
                        if (PONo.Trim() == string.Empty)
                        {
                            cmd.Parameters.AddWithValue("@PONo", DBNull.Value);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@PONo", PONo);
                        }

                        int cnt = cmd.ExecuteNonQuery();
                        if (cnt <= 0)
                        {

                        }
                    }
                }

                con.Close();

            }

        }
        public static void AddDeliveryDetailsNew(Guid orderItemID, Decimal grossQty, Decimal netQty, Decimal delivQty, DateTime delivDtTm, Int32 loginUserID, String deviceID, DateTime deviceTime, Decimal? beforeVolume, Decimal? afterVolume, ISession session, String IsDelivered, string DeliveryQtyVarianceReason, String BOLNo, String Image, String Notes, String PONo, Guid PreOrderItemID, String companyID, String VersionNo = "")
        {
            DeliveryDetailsTableAdapter ta = new DeliveryDetailsTableAdapter();
            ta.CurrentConnection = session;
            deviceTime = DateTime.Now.AddMilliseconds(10);
            //   deviceTime = deviceTime.AddMinutes(5);
            //List<DeliveryDetails> lstDeliv = ta.GetDataByDevice(orderItemID, loginUserID, deviceID, deviceTime).Select().Cast<DAL.DeliveryDetailsRow>().ToList().ToEntities();
            Logging.LogInfoAboutCallingFunction("AddDeliveryDetailsNewMethodCalled :" + companyID.Trim() + " orderItemID: " + orderItemID);
            SqlConnection con = new SqlConnection(session.ConnectionString);
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
            //if (lstDeliv.Count == 0)
            //{
            ////Temporarly hidden
            //// lstDeliv = ta.GetDeliveryDetails(orderItemID).Select().Cast<DAL.DeliveryDetailsRow>().ToList().ToEntities();

            //List<DeliveryDetails> lstDelivcount;
            //lstDelivcount = ta.GetDataByDeliveryCount(orderItemID, BOLNo).Select().Cast<DAL.DeliveryDetailsRow>().ToList().ToEntities();

            //if (lstDelivcount.Count > 0)
            //{
            //    ta.UpdateQuery(grossQty, netQty, delivQty, delivDtTm, loginUserID, true, deviceID, deviceTime, beforeVolume, afterVolume, DeliveryQtyVarianceReason == "" ? null : DeliveryQtyVarianceReason, BOLNo, Notes, orderItemID, PreOrderItemID);
            //    //ta.UpdateQuery(grossQty, netQty, delivQty, delivDtTm, loginUserID, true, deviceID, deviceTime, beforeVolume, afterVolume, DeliveryQtyVarianceReason == "" ? null : DeliveryQtyVarianceReason, orderItemID);

            //}
            //else
            //{

            //    ta.InsertQuery(orderItemID, grossQty, netQty, delivQty, delivDtTm, loginUserID, deviceID, deviceTime, beforeVolume, afterVolume, IsDelivered, DeliveryQtyVarianceReason == "" ? null : DeliveryQtyVarianceReason, BOLNo, Notes, PreOrderItemID);
            //    // ta.InsertQuery(orderItemID, grossQty, netQty, delivQty, delivDtTm, loginUserID, deviceID, deviceTime, beforeVolume, afterVolume, DeliveryQtyVarianceReason == "" ? null : DeliveryQtyVarianceReason);
            //    // Logging.LogInfoAboutCallingFunction("DALMethod - AddDeliveryDetails 3 : lstDelivCount" + lstDeliv.Count + ":" + orderItemID + ":" + loginUserID + ":" + deviceID + ":" + deviceTime);

            //}
            ////upto this

            //Logging.LogInfoAboutCallingFunction("GrossQty :" + grossQty);
            //Logging.LogInfoAboutCallingFunction("NetQty :" + netQty);
            //Logging.LogInfoAboutCallingFunction("DelivQty :" + delivQty);

            con.Open();
            int isUpdated = 0;
            DataTable dtCheckDeliveryItem = new DataTable();

            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "select * from DeliveryDetails where OrderItemID = '" + orderItemID + "' and GrossQty = " + grossQty + " and BOLNo = '" + BOLNo + "'";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;

                SqlDataAdapter sa = new SqlDataAdapter();
                sa.SelectCommand = cmd;
                sa.Fill(dtCheckDeliveryItem);
            }

            if (dtCheckDeliveryItem != null && dtCheckDeliveryItem.Rows.Count > 0)
            {
                Logging.LogInfoAboutCallingFunction("DeliverItem exist :" + companyID.Trim() + " orderItemID: " + orderItemID);
            }
            else
            {
                lock (tranLock)
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "Cloud_CreateDeliveryDetails";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = con;
                        cmd.Parameters.AddWithValue("@OrderItemID", orderItemID);
                        cmd.Parameters.AddWithValue("@GrossQty", grossQty);
                        cmd.Parameters.AddWithValue("@NetQty", netQty);
                        cmd.Parameters.AddWithValue("@DelivQty", delivQty);
                        cmd.Parameters.AddWithValue("@DeliveryDateTime", delivDtTm);
                        cmd.Parameters.AddWithValue("@UpdatedBy", loginUserID);
                        cmd.Parameters.AddWithValue("@DeviceID", deviceID);
                        cmd.Parameters.AddWithValue("@DeviceTime", deviceTime);
                        cmd.Parameters.AddWithValue("@BeforeVolume", beforeVolume);
                        cmd.Parameters.AddWithValue("@AfterVolume", afterVolume);
                        cmd.Parameters.AddWithValue("@IsDelivered", IsDelivered);
                        cmd.Parameters.AddWithValue("@DeliveryQtyVarianceReason", DeliveryQtyVarianceReason);
                        cmd.Parameters.AddWithValue("@BOLNo", BOLNo);
                        cmd.Parameters.AddWithValue("@Notes", Notes);
                        cmd.Parameters.AddWithValue("@PreOrderItemID", PreOrderItemID);

                        SqlDataAdapter sa = new SqlDataAdapter();
                        sa.SelectCommand = cmd;
                        DataTable dt = new DataTable();
                        sa.Fill(dt);
                        //con.Close();


                        if (dt != null && dt.Rows.Count > 0)
                        {
                            if (dt.Rows[0]["StatusNew"].ToString().Trim().ToUpper() == "SUCCESS")
                            {
                                isUpdated = 1;
                            }
                            else
                            {
                                Logging.LogInfoAboutCallingFunction("Cloud_CreateDeliveryDetails: Failed to Insert - " + dt.Rows[0]["Reason"].ToString().Trim());
                            }
                        }
                    }
                }
            }
            if (image1 != null && isUpdated == 1)
            {

                using (SqlCommand cmd = new SqlCommand("UPDATE DeliveryDetails SET [Image] = @binaryVal WHERE  OrderItemID = '" + orderItemID + "'", con))
                {
                    cmd.Parameters.AddWithValue("@binaryVal", image1);
                    cmd.ExecuteNonQuery();
                }
            }
            Guid OrderID = GetOrderID(orderItemID, session, VersionNo);
            if (OrderID != null)
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "Cloud_UpdateOrderPONo";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = con;
                    cmd.Parameters.AddWithValue("@OrderID", OrderID);
                    if (PONo.Trim() == string.Empty)
                    {
                        cmd.Parameters.AddWithValue("@PONo", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@PONo", PONo);
                    }

                    int cnt = cmd.ExecuteNonQuery();
                    if (cnt <= 0)
                    {

                    }
                }
            }

            con.Close();

            //}

        }

        /// <summary>
        /// Add Order Frights
        /// </summary>
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
        /// <param name="session">session object</param>
        public static void AddOrderFrt(Guid OrderID, Boolean? SiteWaitTime, string SiteWaitTime_Comment, DateTime? SiteWaitTime_Start, DateTime? SiteWaitTime_End, Boolean? SplitLoad, string SplitLoad_Comment, Boolean? SplitDrop, string SplitDrop_Comment, Boolean? PumpOut, string PumpOut_Comment, Boolean? Diversion, string Diversion_Comment, Boolean? MinimumLoad, string MinimumLoad_Comment, Boolean? Other, string Other_Comment, int userid, string DeviceID, DateTime DeviceTime, ISession session, String VersionNo = "")
        {
            OrderFrtTableAdapter ta = new OrderFrtTableAdapter();
            ta.CurrentConnection = session;

            List<OrderFrt> lstDeliv = ta.GetDataByOrderID(OrderID).Select().Cast<DAL.OrderFrtRow>().ToList().ToEntities();
            if (lstDeliv.Count > 0)
            {
                ta.UpdateQuery(SiteWaitTime, SiteWaitTime_Comment, SiteWaitTime_Start, SiteWaitTime_End, SplitLoad, SplitLoad_Comment, SplitDrop, SplitDrop_Comment, PumpOut, PumpOut_Comment, Diversion, Diversion_Comment, MinimumLoad, MinimumLoad_Comment, Other, DeviceID, Other_Comment, OrderID);
            }
            else
            {
                ta.InsertQuery(OrderID, SiteWaitTime, SiteWaitTime_Comment, SiteWaitTime_Start, SiteWaitTime_End, SplitLoad, SplitLoad_Comment, SplitDrop, SplitDrop_Comment, PumpOut, PumpOut_Comment, Diversion, Diversion_Comment, MinimumLoad, MinimumLoad_Comment, Other, Other_Comment, userid, DeviceID == null ? "0" : DeviceID, DeviceTime, DateTime.Now);
            }

        }
        // 06-26-2014  MadhuVenkat k - Added for CR 64058  - For Add orderDispatchHistory
        /// <summary>
        /// AddOrderDipatchHistory
        /// Function to insert the records into OrderDipatchHistory table
        /// </summary>
        /// <param name="SysTrxNo">SysTrxNo</param>
        /// <param name="customerID">Customer ID</param>
        /// <param name="DefDriverID">DefDriverID</param>
        /// <param name="DefVehicleID">DefVehicleID</param>
        /// <param name="OldDriverID">OldDriverID</param>
        /// <param name="OldVehicleID">OldVehicleID</param>
        /// <param name="session">Session object</param>
        public static void AddOrderDipatchHistory(Decimal SysTrxNo, String companyID, Int32 DefDriverID, Int32 DefVehicleID, Int32 OldDriverID, Int32 OldVehicleID, Boolean NeedUpdate, ISession session, String VersionNo = "")
        {
            OrderDispatchHistoryTableAdapter ta = new OrderDispatchHistoryTableAdapter();
            ta.CurrentConnection = session;
            //2014.02.14  Ramesh M Added For blocking same vehicle code inserted for same company. CR#62289

            ta.InsertQueryOrderDispatch(SysTrxNo, DefDriverID, DefVehicleID, OldDriverID, OldVehicleID, companyID, NeedUpdate);

        }
        // 06-26-2014  MadhuVenkat k - Added for CR 64058  - For Update Status in OrderDipatchHistory
        /// <summary>
        /// UpdateOrderDipatchHistory
        /// Function to update the records into OrderDipatchHistory table
        /// </summary>
        /// <param name="SysTrxNo">SysTrxNo</param>
        /// <param name="customerID">Customer ID</param> 
        /// <param name="session">Session object</param>
        public static void UpdateOrderDipatchHistory(Decimal SysTrxNo, String companyID, ISession session, String VersionNo = "")
        {
            OrderDispatchHistoryTableAdapter ta = new OrderDispatchHistoryTableAdapter();
            ta.CurrentConnection = session;
            //2014.02.14  Ramesh M Added For blocking same vehicle code inserted for same company. CR#62289

            ta.Cloud_UpdateOrderDispatchHistory(companyID, SysTrxNo);

        }


        /// <summary>
        /// AddVehicle
        /// Function to insert the records into Vehicle table
        /// </summary>
        /// <param name="customerID">Customer ID</param>
        /// <param name="vehicleID">Vehicle ID</param>
        /// <param name="vehicleCode">Vehicle Code</param>
        /// <param name="session">Session object</param>
        public static void AddOrUpdateVehicle(String customerID, Int32 vehicleID, String vehicleCode, Boolean SleeperRig, Int32 VehicleType, Int32 OverShortSiteID, ISession session, String VersionNo = "")
        {
            VehicleTableAdapter ta = new VehicleTableAdapter();
            ta.CurrentConnection = session;
            //2014.02.14  Ramesh M Added For blocking same vehicle code inserted for same company. CR#62289
            //10-07-2014  MadhuVenkat k - Added for CR 65183  - Added to check the VehicleID for record exist instead of Vehicle Code in Vehicle table
            List<DAL.VehicleRow> lst = ta.GetDataByVechicleID(vehicleID, customerID).Select().Cast<DAL.VehicleRow>().ToList();

            if (VehicleType == 0)
            {
                VehicleType = GetVehicleType(vehicleID, customerID, session, VersionNo);
            }
            if (OverShortSiteID == 0)
            {
                OverShortSiteID = GetVehicleOverShortID(vehicleID, customerID, session, VersionNo);
                if (OverShortSiteID == 0)
                {

                }
            }
            if (lst.Count > 0)
            {
                ta.UpdateQuery(vehicleCode, SleeperRig, VehicleType, vehicleID, customerID, OverShortSiteID);
            }
            else
            {
                ta.InsertVehicles(vehicleID, customerID, vehicleCode, SleeperRig, VehicleType, OverShortSiteID);
            }
        }

        /// <summary>
        /// Get Vehicle Type
        /// </summary>
        /// <param name="vehicleID">Vehicle ID</param>
        /// <param name="customerID">Customer ID</param>
        /// <param name="session">session object</param>
        /// <returns>vehicle type</returns>
        public static Int32 GetVehicleType(Int32 vehicleID, String customerID, ISession session, String VersionNo = "")
        {
            VehicleTableAdapter ta = new VehicleTableAdapter();
            ta.CurrentConnection = session;
            List<DAL.VehicleRow> lst = ta.GetDataByVehicleType(vehicleID, customerID).Select().Cast<DAL.VehicleRow>().ToList();
            if (lst.Count > 0)
            {
                return lst[0].VehicleTypeID;
            }
            return 0;
        }

        // 2014.01.10  Ramesh M Added For CR#61759
        /// <summary>
        /// 
        /// </summary>
        /// <param name="customerID"></param>
        /// <param name="FromSiteBSRule"></param>
        /// <param name="session"></param>
        /// <param name="VersionNo"></param>       
        public static void UpdateFromSiteBSRule(String customerID, Int32 FromSiteBSRule, Int32 MultiBOLBSRule, ISession session, String VersionNo = "")
        {
            CustomerTableAdapter ta = new CustomerTableAdapter();
            ta.CurrentConnection = session;
            List<DAL.CustomerRow> lst = ta.GetDataByCustomerID(customerID).Select().Cast<DAL.CustomerRow>().ToList();
            if (lst.Count > 0)
            {
                ta.UpdateFromSiteBSRule(Convert.ToBoolean(FromSiteBSRule), Convert.ToBoolean(MultiBOLBSRule), customerID);
            }
        }

        // 2014.01.13  Ramesh M Added For CR#61759
        /// <summary>
        /// 
        /// </summary>
        /// <param name="customerID"></param>
        /// <param name="ShiptoID"></param>
        /// <param name="SupplierCode"></param>
        /// <param name="SupplierDescription"></param>
        /// <param name="SupplyPtCode"></param>
        /// <param name="SupplyPtDescription"></param>
        /// <param name="Address"></param>
        /// <param name="session"></param>
        /// <param name="VersionNo"></param>
        public static void AddOrUpdateFromSite(String customerID, Int32? ShiptoID, Int32 SuppliersupplyPtID, Int32 SupplierID, Int32 SupplyPtID, String SupplierDescr, String SupplyPtDescr, String Address1, String Address2, String SupplierCode, String SupplyPtCode, ISession session, String VersionNo = "")
        {
            ARShipTo_FromSitesTableAdapter ta = new ARShipTo_FromSitesTableAdapter();
            ta.CurrentConnection = session;
            // 2014.02.21  Ramesh M Modified SupplierID as input for GetDataByAllID function,earlier it was SupplyPtID, its bug so modified.
            List<DAL.ARShipTo_FromSitesRow> lst = ta.GetDataByAllID(ShiptoID, SuppliersupplyPtID, SupplierID, SupplyPtID, customerID).Select().Cast<DAL.ARShipTo_FromSitesRow>().ToList();
            if (lst.Count > 0)
            {
                ta.UpdateQuery(SupplierDescr, SupplyPtDescr, Address1, Address2, SupplierCode, SupplyPtCode, ShiptoID, SuppliersupplyPtID, SupplierID, SupplyPtID, customerID);
            }
            else
            {
                ta.InsertQuery(ShiptoID, SuppliersupplyPtID, SupplierID, SupplyPtID, SupplierDescr, SupplyPtDescr, Address1, Address2, customerID, SupplierCode, SupplyPtCode);
            }
        }


        // 2014.01.13  Ramesh M Added For CR#61759
        /// <summary>
        /// 
        /// </summary>
        /// <param name="customerID"></param>
        /// <param name="ShiptoID"></param>
        /// <param name="SupplierCode"></param>
        /// <param name="SupplierDescription"></param>
        /// <param name="SupplyPtCode"></param>
        /// <param name="SupplyPtDescription"></param>
        /// <param name="Address"></param>
        /// <param name="session"></param>
        /// <param name="VersionNo"></param>
        public static void DeleteFromSite(String companyID, Int32 OEDefID, Int32 SupplierID, Int32 SupplyPtID, ISession session, String VersionNo = "")
        {
            ARShipTo_FromSitesTableAdapter ta = new ARShipTo_FromSitesTableAdapter();
            ta.CurrentConnection = session;
            ta.Cloud_DeleteFromSite(companyID, OEDefID, SupplierID, SupplyPtID);
        }


        /// <summary>
        /// AddDrivers
        /// Function to insert the records into Drivers table
        /// </summary>
        /// <param name="customerID">Customer ID</param>
        /// <param name="driverID">Driver ID</param>
        /// <param name="session">Session object</param>
        public static void AddDrivers(String customerID, Int32 driverID, ISession session, String VersionNo = "")
        {
            DriversTableAdapter ta = new DriversTableAdapter();
            ta.CurrentConnection = session;
            ta.InsertDrivers(driverID, customerID);
        }

        // 2014.02.17  Ramesh M Added UserType For Warehouse user duplication CR#62289
        /// <summary>
        /// UpdateLoginDetails
        /// Function to update the records into login user table 
        /// </summary>
        /// <param name="loginUser">LoginUser object</param>
        /// <param name="session">Session object</param>
        public static void AddOrUpdateLoginDetails(LoginUser loginUser, String UserType, ISession session, String VersionNo = "")
        {
            LoginUserTableAdapter ta = new LoginUserTableAdapter();
            ta.CurrentConnection = session;
            List<DAL.LoginUserRow> lst = new List<DAL.LoginUserRow>();
            if (UserType.ToUpper() == "W")
            {
                lst = ta.GetDataBySiteID(loginUser.DriverID, loginUser.CustomerID).Select().Cast<DAL.LoginUserRow>().ToList();
            }
            else
            {

                lst = ta.GetDataByDriverID(loginUser.DriverID, loginUser.CustomerID).Select().Cast<DAL.LoginUserRow>().ToList();
            }

            if (lst.Count > 0)
            {
                foreach (DAL.LoginUserRow row in lst)
                {
                    // 2014.03.17  Ramesh M Added For CR#62668 to get home terminal details
                    ta.UpdateQuery(loginUser.UserName, loginUser.Password, loginUser.Email, loginUser.FirstName, loginUser.MiddleName, loginUser.LastName,
                                   row.UserType_Ext, loginUser.Co_Name, loginUser.Co_Addr1, loginUser.Co_City, loginUser.Co_State, loginUser.Co_Zip,
                                  loginUser.HT_Descr, loginUser.Co_Addr1, loginUser.HT_City, loginUser.HT_State, loginUser.HT_Zip, loginUser.HazMatDate, row.ID_Ext);
                }
            }
            else
            {
                // 2013.11.29 FSWW, Ramesh M Added For CR#61273 Modified Insert statement into ADDLoginuser Proc
                // 2014.03.17  Ramesh M Added For CR#62668 to get home terminal details
                //ta.InsertQuery(loginUser.CustomerID, loginUser.UserName, loginUser.DriverID, loginUser.Password, loginUser.Email, loginUser.FirstName, loginUser.MiddleName, loginUser.LastName, loginUser.UserType);
                ta.ADDLoginUser(loginUser.CustomerID, loginUser.UserName, loginUser.DriverID, loginUser.Password, loginUser.Email, loginUser.FirstName, loginUser.MiddleName,
                                loginUser.LastName, loginUser.UserType, loginUser.Co_Name, loginUser.Co_Addr1, loginUser.Co_City, loginUser.Co_State, loginUser.Co_Zip,
                                  loginUser.HT_Descr, loginUser.Co_Addr1, loginUser.HT_City, loginUser.HT_State, loginUser.HT_Zip, loginUser.HazMatDate);
            }
        }

        /// <summary>
        /// CheckDriver
        /// Function to check the Drivers records related to customer ID and driver ID
        /// </summary>
        /// <param name="customerID">Customer ID</param>
        /// <param name="driverID">Driver ID</param>
        /// <param name="session">Session object</param>
        /// <returns>True = Driver exist, False = Failed</returns>
        public static Boolean CheckDriver(String customerID, Int32 driverID, ISession session, String VersionNo = "")
        {
            DriversTableAdapter ta = new DriversTableAdapter();
            ta.CurrentConnection = session;
            List<DAL.DriversRow> lstDrivers = ta.GetDrivers(driverID, customerID).Select().Cast<DAL.DriversRow>().ToList();
            if (lstDrivers.Count > 0)
            {
                return true;
            }
            else
                return false;
        }


        //2013.08.29 FSWW, Ramesh M Added For CR#?.. To Update WareHouse Users in deliverystream from Ascend
        /// <summary>
        /// CheckSiteID
        /// </summary>
        /// <param name="customerID"></param>
        /// <param name="SiteID"></param>
        /// <param name="SiteCode"></param>
        /// <param name="session"></param>
        /// <returns></returns>
        public static Boolean CheckSiteID(String customerID, Int32 SiteID, String SiteCode, ISession session, String VersionNo = "")
        {

            WarehouseTableAdapter ta = new WarehouseTableAdapter();
            ta.CurrentConnection = session;
            //List<DAL.WarehouseRow> lstSiteID = ta.GetSiteID(customerID,SiteID).Select().Cast<DAL.WarehouseRow>().ToList();
            //if (lstSiteID.Count > 0)

            if (ta.GetSiteIDCount(customerID, SiteID) > 0)
            {
                return true;
            }
            else
                return false;
        }
        //2013.08.29 FSWW, Ramesh M Added For CR#?.. To Update WareHouse Users in deliverystream from Ascend
        /// <summary>
        /// AddSiteID
        /// </summary>
        /// <param name="customerID"></param>
        /// <param name="SiteID"></param>
        /// <param name="SiteCode"></param>
        /// <param name="session"></param>
        public static void AddSiteID(String customerID, Int32 SiteID, String SiteCode, ISession session, String VersionNo = "")
        {
            WarehouseTableAdapter ta = new WarehouseTableAdapter();
            ta.CurrentConnection = session;
            ta.InsertSiteID(customerID, SiteID, SiteCode, null);
        }

        ///// <summary>
        ///// AddNotification
        ///// </summary>
        ///// <param name="userID">user ID</param>
        ///// <param name="newLoadCount">new Load Count</param>
        ///// <param name="session">session object</param>
        //public static void AddNotification(Int32 userID, Int32 newLoadCount, ISession session)
        //{
        //    PushNotificationTableAdapter ta = new PushNotificationTableAdapter();
        //    ta.CurrentConnection = session;
        //    ta.InsertNotification(userID, newLoadCount, false);
        //}


        //2015.02.05 Madhu Added For CR#66160 To Add App Version No in the login history table for every login
        /// <summary>
        /// AddLoginHistory
        /// </summary>
        /// <param name="history">Login History object</param>
        /// <param name="session">session object</param>
        public static void AddLoginHistory(LoginHistory history, ISession session, String VersionNo)
        {
            InvalidateDeviceToken(history.DeviceToken, session);
            LoginHistoryTableAdapter ta = new LoginHistoryTableAdapter();
            ta.CurrentConnection = session;
            // 2013.12.04 FSWW, Ramesh M Added For CR#61305 Added GMT in parameter
            // 2014.02.10 Ramesh M Added TrailerCode For CR#62211
            ta.InsertQuery(history.LoginID, history.VehicleID, history.CustomerID, history.DeviceID, history.DeviceToken, history.DateTime, history.IsValidToken, history.DeviceTime, history.SessionID, history.GMT, history.TrailerCode, VersionNo, history.IOSVersion);
        }

        /// <summary>
        /// InvalidateDeviceToken
        /// </summary>
        /// <param name="deviceToken">device Token</param>
        /// <param name="session">session object</param>
        public static void InvalidateDeviceToken(String deviceToken, ISession session, String VersionNo = "")
        {
            if (!String.IsNullOrWhiteSpace(deviceToken))
            {
                LoginHistoryTableAdapter ta = new LoginHistoryTableAdapter();
                ta.CurrentConnection = session;
                // ta.InvalidateDeviceToken(deviceToken);
            }
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
        /// <param name="session">session object</param>

        //2013.08.01 FSWW, Ramesh M Added For CR#?... PredutyFaults and BeginingOdometer
        public static void AddPreDutyInspectionDetails(Guid sessionID, Boolean PreDuty_Inspection, DateTime? PreDuty_InspectionDateTime, Boolean PreDutyViolation, Int32 PreDutyFaults, Decimal BeginningOdometer, ISession session, String VersionNo = "")
        {
            // 2013.08.30 FSWW, Ramesh M Added For For unable to calling from ipad so following code Added
            Decimal? dBeginningOdometer;
            if (BeginningOdometer == -1)
            {
                dBeginningOdometer = null;
            }
            else
            {
                dBeginningOdometer = BeginningOdometer;
            }

            InspectionTableAdapter ta = new InspectionTableAdapter();
            ta.CurrentConnection = session;
            Int32 cnt = ta.GetCountOnSessionID(sessionID).GetValueOrDefault();
            if (cnt > 0)
            {
                if (PreDuty_Inspection == false && PreDutyViolation == false)
                {
                    ta.UpdatePreDutyInspectionDetails(PreDuty_Inspection, PreDuty_InspectionDateTime, true, sessionID);
                }
                else
                {
                    ta.UpdatePreDutyInspectionDetails(PreDuty_Inspection, PreDuty_InspectionDateTime, PreDutyViolation, sessionID);
                }
            }
            else
            {
                if (PreDuty_Inspection == false && PreDutyViolation == false)
                {
                    ta.InsertPreDutyInspectionDetails(sessionID, PreDuty_Inspection, PreDuty_InspectionDateTime, true, PreDutyFaults, dBeginningOdometer);
                }
                else
                {
                    ta.InsertPreDutyInspectionDetails(sessionID, PreDuty_Inspection, PreDuty_InspectionDateTime, PreDutyViolation, PreDutyFaults, dBeginningOdometer);
                }
            }
        }

        /// <summary>
        /// AddPostDutyInspectionDetails
        /// Function to insert the record into Inspection table
        /// </summary>
        /// <param name="sessionID">SessionID</param>
        /// <param name="PostDuty_Inspection">PostDuty_Inspection</param>
        /// <param name="PostDuty_InspectionDateTime">PostDuty_InspectionDateTime</param>
        /// <param name="PostDutyViolation">PostDutyViolation</param>
        /// <<param name="PostDutyFaults">PostDutyFaults </param>
        /// <param name="BeginningOdometer">BeginningOdometer</param>
        /// <param name="EndingOdometer">EndingOdometer</param>
        /// <param name="NextLubrication">NextLubrication</param>
        /// <param name="image">image</param>
        /// <param name="session"> session object</param>
        //2013.08.01 FSWW, Ramesh M Added For CR#?... PostdutyFaults,BeginingOdometer,EndingOdometer,NextLubrication,Signature
        public static void AddPostDutyInspectionDetails(Guid sessionID, Boolean PostDuty_Inspection, DateTime? PostDuty_InspectionDateTime, Boolean PostDutyViolation, Int32 PostDutyFaults, Decimal BeginningOdometer, Decimal EndingOdometer, Decimal NextLubrication, byte[] image, ISession session, String VersionNo = "")
        {
            InspectionTableAdapter ta = new InspectionTableAdapter();
            ta.CurrentConnection = session;
            Int32 cnt = ta.GetCountOnSessionID(sessionID).GetValueOrDefault();
            if (cnt > 0)
            {
                if (PostDuty_Inspection == false && PostDutyViolation == false)
                {
                    ta.UpdatePostDutyInspectionDetails(PostDuty_Inspection, PostDuty_InspectionDateTime, true, PostDutyFaults, BeginningOdometer, EndingOdometer, NextLubrication, image, sessionID);
                }
                else
                {
                    ta.UpdatePostDutyInspectionDetails(PostDuty_Inspection, PostDuty_InspectionDateTime, PostDutyViolation, PostDutyFaults, BeginningOdometer, EndingOdometer, NextLubrication, image, sessionID);
                }
            }
            else
            {
                if (PostDuty_Inspection == false && PostDutyViolation == false)
                {
                    ta.InsertPostDutyInspectionDetails(sessionID, PostDuty_Inspection, PostDuty_InspectionDateTime, true, PostDutyFaults, BeginningOdometer, EndingOdometer, NextLubrication, image);
                }
                else
                {
                    ta.InsertPostDutyInspectionDetails(sessionID, PostDuty_Inspection, PostDuty_InspectionDateTime, PostDutyViolation, PostDutyFaults, BeginningOdometer, EndingOdometer, NextLubrication, image);
                }
            }
        }

        /// <summary>
        /// AddAdverseConditionDetails
        /// Function to insert the record into AdverseCondition table
        /// </summary>
        /// <param name="sessionID">SessionID</param>
        /// <param name="Adverse_Condition">Adverse_Condition</param>
        /// <param name="AdverseConditionReason">AdverseConditionReason</param>
        /// <param name="AdverseConditionDateTime">AdverseConditionDateTime</param>
        ///<param name="session">session</param>
        public static void AddAdverseConditionDetails(Guid sessionID, Boolean Adverse_Condition, String AdverseConditionReason, DateTime AdverseConditionDateTime, ISession session, String VersionNo = "")
        {
            AdverseConditionTableAdapter ta = new AdverseConditionTableAdapter();
            ta.CurrentConnection = session;
            List<AdverseCondition> lstCondition = ta.GetAdverseCondition(sessionID).Select().Cast<DAL.AdverseConditionRow>().ToList().ToEntities();

            if (lstCondition.Count > 0)
            {
                ta.UpdateQuery(Adverse_Condition, AdverseConditionReason, AdverseConditionDateTime, sessionID);
            }
            else
            {
                ta.InsertQuery(sessionID, Adverse_Condition, AdverseConditionReason, AdverseConditionDateTime);
            }
        }

        /// <summary>
        /// AddSleeperRigTimeDetails
        /// Function to insert the record into SleeperRig table
        /// </summary>
        /// <param name="sessionID">SessionID</param>
        /// <param name="SleeperRigID">SleeperRigID</param>
        /// <param name="StartTime">StartTime</param>
        /// <param name="EndTime">EndTime</param>

        public static void AddSleeperRigTimeDetails(Guid sessionID, Guid sleeperRigID, DateTime startTime, DateTime endTime, Int32 loginID, ISession session, String VersionNo = "")
        {
            SleeperRigTableAdapter ta = new SleeperRigTableAdapter();
            ta.CurrentConnection = session;
            List<SleeperRig> lstCondition = ta.GetDataByTime(sessionID, startTime, endTime).Select().Cast<DAL.SleeperRigRow>().ToList().ToEntities();

            if (lstCondition.Count == 0)
            {
                ta.InsertQuery(sessionID, sleeperRigID, startTime, endTime, loginID);
            }
        }
        ////2013.10.18 FSWW, Ramesh M Added For C#R60839.. To update SleeperRig in gps History Table 
        public static void UpdateSleeperRigTimeToGpsHistory(Guid sessionID, DateTime startTime, DateTime endTime, Int32 loginID, ISession session, String VersionNo = "")
        {
            GPSHistoryTableAdapter ta = new GPSHistoryTableAdapter();
            ta.CurrentConnection = session;
            ta.UpdateSleeperRig(sessionID, loginID, startTime, endTime);
        }

        /// <summary>
        /// Add truck fueling 
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
        /// <param name="session"></param>
        public static void AddTruckFuelingDetails(String userName, String password, Guid sessionID, String companyID, String vehicleID, String driverID, String deviceDateTime, Decimal odometer, Decimal qty, String fuelType, String latitude, String longitude, String state, Boolean fuelTaxPaid, String fuelingLocation, Decimal MPG, ISession session, String VersionNo = "")
        {
            //2013.11.25 FSWW, Ramesh M Added For CR#60186 Renamed  tblTruckFuelingDetailsTableAdapter to TruckFuelingDetailsTableAdapter
            TruckFuelingDetailsTableAdapter ta = new TruckFuelingDetailsTableAdapter();
            ta.CurrentConnection = session;
            // added to get the vehicle ID from vehicle code and Driver ID from user name respectively
            Int32 _vehicleID = Convert.ToInt32(ta.GetVehicleIDByCode(companyID, vehicleID));
            Int32 _driverID = Convert.ToInt32(ta.GetDriverIDByUserName(companyID, userName));

            ta.InsertQuery(sessionID, companyID, _vehicleID, _driverID, Convert.ToDateTime(deviceDateTime), DateTime.UtcNow, odometer, qty, Convert.ToInt32(fuelType), Convert.ToDecimal(latitude), Convert.ToDecimal(longitude), state, fuelTaxPaid, fuelingLocation, MPG);
        }

        // 05-06-2013 FSWW Ramesh M added following code
        /// <summary>
        /// Add Order picking  Details 
        /// </summary>
        /// <param name="OrderNo"></param>
        /// <param name="LoadNo"></param>
        /// <param name="OrderItemId"></param>
        /// <param name="PickedBy"></param>
        /// <param name="CustomerId"></param>
        /// <param name="Status"></param>
        /// <param name="session"></param>   
        public static void AddOrUpdateOrderPickingDetails(String OrderNo, String LoadNo, String OrderItemId, Int32 PickedBy, String CustomerId, String Status, ISession session, String VersionNo = "")
        {
            Int32 OrderPickedCount = 0;
            OrderPickingDetailsTableAdapter ta = new OrderPickingDetailsTableAdapter();
            ta.CurrentConnection = session;
            OrderPickedCount = Convert.ToInt32(ta.IsPickedOrderChecking(OrderNo, LoadNo, OrderItemId, PickedBy, CustomerId));
            if (OrderPickedCount > 0)
            {
                ta.InsertQuery(OrderNo, LoadNo, OrderItemId, PickedBy, CustomerId, Status);
            }
            else
            {
                ta.UpdateQuery(Status, OrderNo, LoadNo, OrderItemId, PickedBy, CustomerId);
            }
        }
        /// <summary>
        /// Add Order picking  Details 
        /// </summary>
        /// <param name="OrderNo"></param>
        /// <param name="LoadNo"></param>
        /// <param name="OrderItemId"></param>
        /// <param name="PickedBy"></param>
        /// <param name="CustomerId"></param>
        /// <param name="Status"></param>
        /// <param name="session"></param>   
        public static void DeleteOrderPickingDetails(String OrderNo, String LoadNo, String OrderItemId, Int32 PickedBy, String CustomerId, String Status, ISession session, String VersionNo = "")
        {
            OrderPickingDetailsTableAdapter ta = new OrderPickingDetailsTableAdapter();
            //OrderItemTableAdapter ta = new OrderItemTableAdapter();
            ta.CurrentConnection = session;
            ta.UpdateQuery(Status, OrderNo, LoadNo, OrderItemId, PickedBy, CustomerId);
        }
        // 05-06-2013 FSWW Ramesh M added for CR#59047
        public static void AddBreakDetails(Guid SessionID, DateTime BreakStartTime, DateTime? BreakEndTime, String TimeViolation, String MovingViolation, String NoBreakViolation, ISession session, String VersionNo = "")
        {
            //2013.11.25 FSWW, Ramesh M Added For CR#60188 Renamed Break Table To DriverBreak
            DriverBreakTableAdapter ta = new DriverBreakTableAdapter();
            ta.CurrentConnection = session;
            ta.InsertQuery(SessionID, BreakStartTime, BreakEndTime, TimeViolation, MovingViolation, NoBreakViolation);
        }
        // 05-06-2013 FSWW Ramesh M added CR#59047
        public static void UpdateBreakDetails(Guid SessionID, DateTime BreakStartTime, DateTime BreakEndTime, ISession session, String VersionNo = "")
        {
            //2013.11.25 FSWW, Ramesh M Added For CR#60188 Renamed Break Table To DriverBreak
            DriverBreakTableAdapter ta = new DriverBreakTableAdapter();
            ta.CurrentConnection = session;
            ta.UpdateBreakEndTime(BreakEndTime, SessionID, BreakStartTime);
        }

        // 2013.08.12 FSWW, Ramesh M Added For CR#...? For Package Lube shippment Details
        //public static void AddPackageShippmentDetail(String vehicleID,Int32 loginID, String companyID, Guid loadID, Decimal OrderedQty, String deviceID, DateTime deviceTime, String DriverName, ISession session)
        //{
        //    PackageLubeShippmentDetailsTableAdapter ta = new PackageLubeShippmentDetailsTableAdapter();
        //    ta.CurrentConnection = session;
        //    ta.InsertQuery(loadID, companyID, loginID, vehicleID, deviceID, deviceTime, DriverName, OrderedQty);
        //}

        ///2013.08.27 FSWW, Ramesh M Added For CR#...? For Package Lube InspectionDetails
        public static void AddInspectionDetails(Guid sessionID, Int32 InspectionTypeID, String InspectionElementsID, ISession session, String VersionNo = "")
        {
            //InspectionTypeID=1->preduty::InspectionTypeID=2->postduty

            InspectionDetailsTableAdapter ta = new InspectionDetailsTableAdapter();
            ta.CurrentConnection = session;

            String[] InsPectionElements = InspectionElementsID.Split(',');
            foreach (string ID in InsPectionElements)
            {
                //2014.01.30 Ramesh M Added For CR#62039 For inspection Remarks
                ta.AddInspectionDetails(sessionID, InspectionTypeID, Convert.ToInt32(ID.Split('*')[0].ToString()), ID.Split('*')[1].ToString());
            }

        }
        //  2014.02.06  Ramesh M Added For CR#62166 For DOT OverRide Details
        //  2014.02.10  Ramesh M Added For CR#62210 For DOT OverRideReason Details
        public static void AddDOTOverRide(Guid sessionID, DateTime StartDate, DateTime EndDate, String OverRideType, String OverRideReason, ISession session, String VersionNo = "")
        {
            DOTOverRideTableAdapter ta = new DOTOverRideTableAdapter();
            ta.CurrentConnection = session;
            ta.ADDDOTOverRide(sessionID, StartDate, EndDate, OverRideType, OverRideReason, VersionNo);
        }

        // 2014.02.16  Ramesh M Added For CR#62166 For DOT OverRide
        public static void DriverTimeExceptions(Guid sessionID, DateTime StartDate, DateTime? EndDate, String TimeViolation, String MovingViolation, String NoBreakViolation, String ExceptionType, String ExceptionReason, ISession session, String VersionNo = "")
        {
            DriverTimeExceptionsTableAdapter ta = new DriverTimeExceptionsTableAdapter();
            ta.CurrentConnection = session;
            ta.ADDDriverTimeException(sessionID, StartDate, EndDate, TimeViolation, MovingViolation, NoBreakViolation, ExceptionType, ExceptionReason, VersionNo);
        }
        #endregion

        #region Logout Details

        /// <summary>
        /// Function to update login history logout time
        /// </summary>
        /// <param name="sessionID">SessionID</param>
        /// <param name="DeviceToken">Device Token</param>
        /// <param name="LogoffTime"></param>
        /// <returns>True = Updated successfully, False = Failed</returns>
        public static void UpdateLoginHistory(Guid sessionID, DateTime logoffTime, ISession session, String VersionNo = "")
        {
            LoginHistoryTableAdapter ta = new LoginHistoryTableAdapter();
            ta.CurrentConnection = session;
            ta.UpdateLoginHistory(sessionID, logoffTime);
        }

        /// <summary>
        /// Function to expire login session after logout
        /// </summary>
        /// <param name="sessionID">SessionID</param>
        /// <param name="DeviceToken">Device Token</param>
        /// <returns>True = Deleted successfully, False = Failed</returns>
        public static Boolean removeLoginSession(Guid sessionID, ISession session, String VersionNo = "")
        {
            LoginSessionTableAdapter ta = new LoginSessionTableAdapter();
            ta.CurrentConnection = session;
            int status = ta.DeleteLoginSession(sessionID);
            return status > 0;
        }

        #endregion Logout Details

        # region TestingPurpose
        // 2014.03.20  Ramesh M Added For CR#62322 added  Version testing method
        public static List<VersionTest> VersionTestSampleData(Guid sessionID, ISession session, String VersionNo = "", DateTime? startTime = null, DateTime? endTime = null)
        {
            List<VersionTest> lstVersionTest = new List<VersionTest>();
            VersionTestTableAdapter ta = new VersionTestTableAdapter();
            ta.CurrentConnection = session;
            if (VersionNo == "1.28")
            {
                lstVersionTest = ta.GetDataVersion128().Select().Cast<DAL.VersionTestRow>().ToList().ToEntities(VersionNo);
            }
            if (VersionNo == "1.29")
            {
                lstVersionTest = ta.GetDataVersion129(startTime, endTime).Select().Cast<DAL.VersionTestRow>().ToList().ToEntities(VersionNo);
            }
            return lstVersionTest;
        }

        #endregion

        #region RejectedNotes

        public static int InsertRejectedLoad(ISession session, string loadNumber, string rejectedNote, string customerId)
        {
            int isUpdated = -1;
            SqlConnection con = new SqlConnection(session.ConnectionString);
            try
            {
                SqlCommand cmd = (SqlCommand)session.CreateCommand();
                cmd.CommandText = "UpdateRejectedNotes";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@LoadNo", loadNumber);
                cmd.Parameters.AddWithValue("@RejectedNote", rejectedNote);
                cmd.Parameters.AddWithValue("@ClientId", customerId);
                con.Open();
                isUpdated = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                string exception = ex.Message;
            }
            finally
            {
                con.Close();
            }
            return isUpdated;

        }
        #endregion

        #region Tank Wagon
        // 06-26-2014  MadhuVenkat k - Added for CR 64058  - For Add VehicleCompartment
        /// <summary>
        /// AddVehicleCompartment
        /// Function to insert the records into VehicleCompartment table
        /// </summary>
        /// <param name="SysTrxNo">SysTrxNo</param>
        /// <param name="customerID">Customer ID</param>
        /// <param name="DefDriverID">DefDriverID</param>
        /// <param name="DefVehicleID">DefVehicleID</param>
        /// <param name="OldDriverID">OldDriverID</param>
        /// <param name="OldVehicleID">OldVehicleID</param>
        /// <param name="session">Session object</param>
        public static void AddVehicleCompartment(Int32 VehicleID, String CustomerID, Int32 CompartmentID, String Code, Int32 Capacity, ISession session, String VersionNo = "")
        {
            VehicleCompartmentTableAdapter ta = new VehicleCompartmentTableAdapter();
            ta.CurrentConnection = session;
            //2014.02.14  Ramesh M Added For blocking same vehicle code inserted for same company. CR#62289

            ta.InsertQuery(VehicleID, CustomerID, CompartmentID, Code, Capacity);

        }

        /// <summary>
        /// GetSignatureImage
        /// </summary>
        /// <param name="SysTrxNo">SysTrxNo</param>
        /// <param name="session">session</param>
        /// <returns></returns>
        public static List<VehicleCompartment> GetVehicleCompartment(String customerID, Int32 vehicleID, ISession session, String VersionNo = "")
        {
            VehicleCompartmentTableAdapter ta = new VehicleCompartmentTableAdapter();
            ta.CurrentConnection = session;
            return ta.GetDataByVehicleCompartment(vehicleID, customerID).Cast<DAL.VehicleCompartmentRow>().ToList().ToEntities();
        }





        // 06-26-2014  MadhuVenkat k - Added for CR 64058  - For Add VehicleCompartment
        /// <summary>
        /// AddVehicleCompartment
        /// Function to insert the records into VehicleCompartment table
        /// </summary>
        /// <param name="SysTrxNo">SysTrxNo</param>
        /// <param name="customerID">Customer ID</param>
        /// <param name="DefDriverID">DefDriverID</param>
        /// <param name="DefVehicleID">DefVehicleID</param>
        /// <param name="OldDriverID">OldDriverID</param>
        /// <param name="OldVehicleID">OldVehicleID</param>
        /// <param name="session">Session object</param>
        public static void AddBOLHdrWagon(Guid ID, Guid SessionID, String BOLNo, DateTime BOLDatetime, String SupplierCode, String SupplyPointCode, Int32 UpdatedBy, byte[] image, String Clientid, ISession session, String VersionNo = "")
        {
            BOLHdr_WagonTableAdapter ta = new BOLHdr_WagonTableAdapter();
            ta.CurrentConnection = session;
            //2014.02.14  Ramesh M Added For blocking same vehicle code inserted for same company. CR#62289
            //Guid SessionID = Guid.NewGuid();
            //Guid ID = Guid.NewGuid(); 
            ta.InsertQuery(SessionID, ID, BOLNo, BOLDatetime, SupplierCode, SupplyPointCode, UpdatedBy, image, Clientid);

        }



        // 06-26-2014  MadhuVenkat k - Added for CR 64058  - For Add VehicleCompartment
        /// <summary>
        /// AddVehicleCompartment
        /// Function to insert the records into VehicleCompartment table
        /// </summary>
        /// <param name="SysTrxNo">SysTrxNo</param>
        /// <param name="customerID">Customer ID</param>
        /// <param name="DefDriverID">DefDriverID</param>
        /// <param name="DefVehicleID">DefVehicleID</param>
        /// <param name="OldDriverID">OldDriverID</param>
        /// <param name="OldVehicleID">OldVehicleID</param>
        /// <param name="session">Session object</param>
        public static void AddBOLItemWagon(Guid BOLHdrID, Decimal SystrxNo, Int32 SystrxLine, Int32 CompartmentID, String ProdCode, Decimal GrossQty, Decimal NetQty, Decimal OrderedQty, String Notes, Int32 VehicleID, ISession session, String VersionNo = "")
        {
            BOLItem_WagonTableAdapter ta = new BOLItem_WagonTableAdapter();
            ta.CurrentConnection = session;
            //2014.02.14  Ramesh M Added For blocking same vehicle code inserted for same company. CR#62289

            Guid ID = Guid.NewGuid();
            ta.InsertQuery(ID, BOLHdrID, SystrxNo, SystrxLine, CompartmentID, ProdCode, GrossQty, NetQty, OrderedQty, Notes, VehicleID);

        }



        /// <summary>
        /// GetBolitem
        /// Function to return list of BOL item
        /// </summary>
        /// <param name="BolitemID">Bol item ID</param>
        /// <param name="BolHrdID">BOL header</param>
        /// <param name="SysTrxNo">System transaction number</param>
        /// <param name="SysTrxLine">System transaction line</param>
        /// <param name="componentNo">Component number</param>
        /// <param name="session">Session object</param>
        /// <returns>List of BOL item</returns>
        public static List<BolitemWagon> GetBolitemWagon(Guid BolitemID, Guid BolHrdID, ISession session, String VersionNo = "")
        {
            BOLItem_WagonTableAdapter ta = new BOLItem_WagonTableAdapter();
            ta.CurrentConnection = session;
            return ta.GetDataByBOLItemWagonDetails(BolitemID, BolHrdID).Select().Cast<DAL.BOLItem_WagonRow>().ToList().ToEntities();
        }


        /// <summary>
        /// GetBolitem
        /// Function to return list of BOL item
        /// </summary>
        /// <param name="BolitemID">Bol item ID</param>
        /// <param name="BolHrdID">BOL header</param>
        /// <param name="SysTrxNo">System transaction number</param>
        /// <param name="SysTrxLine">System transaction line</param>
        /// <param name="componentNo">Component number</param>
        /// <param name="session">Session object</param>
        /// <returns>List of BOL item</returns>
        public static List<BOLCompartments> GetBolCompartment(Int32 Updatedby, int CompartmentID, String SessionID, ISession session, String VersionNo = "")
        {
            Cloud_GetBOLCompartmentDetailsTableAdapter ta = new Cloud_GetBOLCompartmentDetailsTableAdapter();
            ta.CurrentConnection = session;
            return ta.GetDataBOLCompartmentDetails(Updatedby, CompartmentID, SessionID).Select().Cast<DAL.Cloud_GetBOLCompartmentDetailsRow>().ToList().ToEntities();
        }

        /// <summary>
        /// GetBolitem
        /// Function to return list of BOL item
        /// </summary>
        /// <param name="BolitemID">Bol item ID</param>
        /// <param name="BolHrdID">BOL header</param>
        /// <param name="SysTrxNo">System transaction number</param>
        /// <param name="SysTrxLine">System transaction line</param>
        /// <param name="componentNo">Component number</param>
        /// <param name="session">Session object</param>
        /// <returns>List of BOL item</returns>
        public static List<BOLCompartments> GetProductCompartment(Int32 Updatedby, String ProductCode, String CustomerID, String SessionID, Guid OrderId, Guid OrderItemId, ISession session, String VersionNo = "")
        {
            Cloud_TW_GetProductCompartmentTableAdapter ta = new Cloud_TW_GetProductCompartmentTableAdapter();
            ta.CurrentConnection = session;
            return ta.GetDataGetProductCompartment(CustomerID, ProductCode, Updatedby, SessionID, OrderId, OrderItemId).Select().Cast<DAL.Cloud_TW_GetProductCompartmentRow>().ToList().ToEntities();
        }


        /// <summary>
        /// AddSuppliers
        /// Function to insert the records into VehicleCompartment table
        /// </summary>
        /// <param name="SysTrxNo">SysTrxNo</param>
        /// <param name="customerID">Customer ID</param>
        /// <param name="DefDriverID">DefDriverID</param>
        /// <param name="DefVehicleID">DefVehicleID</param>
        /// <param name="OldDriverID">OldDriverID</param>
        /// <param name="OldVehicleID">OldVehicleID</param>
        /// <param name="session">Session object</param>
        public static void AddSuppliers(Int32 SupplierID, String Code, String Descr, DateTime? LastModifiedDtTm, String CustomerID, ISession session, String VersionNo = "")
        {
            TW_GetSuppliersTableAdapter ta = new TW_GetSuppliersTableAdapter();
            ta.CurrentConnection = session;
            //2014.02.14  Ramesh M Added For blocking same vehicle code inserted for same company. CR#62289

            ta.InsertQuery(SupplierID, Code, Descr, LastModifiedDtTm, CustomerID);

        }

        /// <summary>
        /// GetBolitem
        /// Function to return list of BOL item
        /// </summary>
        /// <param name="BolitemID">Bol item ID</param>
        /// <param name="BolHrdID">BOL header</param>
        /// <param name="SysTrxNo">System transaction number</param>
        /// <param name="SysTrxLine">System transaction line</param>
        /// <param name="componentNo">Component number</param>
        /// <param name="session">Session object</param>
        /// <returns>List of BOL item</returns>
        public static List<Supplier> GetSuppliers(String CompanyID, ISession session, String VersionNo = "")
        {
            TW_GetSuppliersTableAdapter ta = new TW_GetSuppliersTableAdapter();
            ta.CurrentConnection = session;
            return ta.GetDataSupplier(CompanyID).Cast<DAL.TW_GetSuppliersRow>().ToList().ToEntities();
        }

        /// <summary>
        /// GetBolitem
        /// Function to return list of BOL item
        /// </summary>
        /// <param name="BolitemID">Bol item ID</param>
        /// <param name="BolHrdID">BOL header</param>
        /// <param name="SysTrxNo">System transaction number</param>
        /// <param name="SysTrxLine">System transaction line</param>
        /// <param name="componentNo">Component number</param>
        /// <param name="session">Session object</param>
        /// <returns>List of BOL item</returns>
        public static List<SupplierSupplyPt> GetSupplierSupplyPt(String CustomerID, Int32 SupplierID, ISession session, String VersionNo = "")
        {
            TW_GetSupplierSupplyPtTableAdapter ta = new TW_GetSupplierSupplyPtTableAdapter();
            ta.CurrentConnection = session;
            return ta.GetDataSupplierSupplyPt(CustomerID, SupplierID).Cast<DAL.TW_GetSupplierSupplyPtRow>().ToList().ToEntities();
        }

        /// <summary>
        /// AddSupplierSupplyPt
        /// Function to insert the records into VehicleCompartment table
        /// </summary>
        /// <param name="SysTrxNo">SysTrxNo</param>
        /// <param name="customerID">Customer ID</param>
        /// <param name="DefDriverID">DefDriverID</param>
        /// <param name="DefVehicleID">DefVehicleID</param>
        /// <param name="OldDriverID">OldDriverID</param>
        /// <param name="OldVehicleID">OldVehicleID</param>
        /// <param name="session">Session object</param>
        public static void AddSupplierSupplyPt(Int32 SupplierSupplyPtID, Int32 SupplierID, DateTime? LastModifiedDtTm, String SupplierSupplyPtCode, String SupplierSupplyPtDescr, String CustomerID, ISession session, String VersionNo = "")
        {
            TW_GetSupplierSupplyPtTableAdapter ta = new TW_GetSupplierSupplyPtTableAdapter();
            ta.CurrentConnection = session;
            //2014.02.14  Ramesh M Added For blocking same vehicle code inserted for same company. CR#62289 
            ta.InsertQuery(SupplierSupplyPtID, SupplierID, LastModifiedDtTm, SupplierSupplyPtCode, SupplierSupplyPtDescr, CustomerID);

        }

        /// <summary>
        /// GetProducts
        /// Function to return list of Products
        /// </summary>

        public static List<Products> GetSupplierSupplyPtProducts(String CompanyID, Int32 SupplierID, Int32 SupplierPtID, ISession session, String VersionNo = "")
        {
            TW_GetSupplierSupplyPtProductsTableAdapter ta = new TW_GetSupplierSupplyPtProductsTableAdapter();
            ta.CurrentConnection = session;
            return ta.GetDataSupplierSupplyPtProducts(CompanyID, SupplierID, SupplierPtID).Cast<DAL.TW_GetSupplierSupplyPtProductsRow>().ToList().ToEntities();
        }


        /// <summary>
        /// GetProducts
        /// Function to return list of Products
        /// </summary>

        public static List<BolHdrWagon> GetDatabyBOLno(String BOLno, ISession session, String VersionNo = "")
        {
            BOLHdr_WagonTableAdapter ta = new BOLHdr_WagonTableAdapter();
            ta.CurrentConnection = session;
            return ta.GetDataByBOLNo(BOLno).Select().Cast<DAL.BOLHdr_WagonRow>().ToList().ToEntities();
        }

        /// <summary>
        /// AddProducts
        /// Function to insert the records into VehicleCompartment table
        /// </summary>
        /// <param name="SysTrxNo">SysTrxNo</param>
        /// <param name="customerID">Customer ID</param>
        /// <param name="DefDriverID">DefDriverID</param>
        /// <param name="DefVehicleID">DefVehicleID</param>
        /// <param name="OldDriverID">OldDriverID</param>
        /// <param name="OldVehicleID">OldVehicleID</param>
        /// <param name="session">Session object</param>
        public static void AddProducts(Int32 PurchRackID, Int32 SupplierSupplyPtID, Int32 SupplierID, Int32 SupplierPtID, DateTime? LastModifiedDtTm, String ProductCode, String ProductDescr, String CustomerID, ISession session, String VersionNo = "")
        {
            TW_GetSupplierSupplyPtProductsTableAdapter ta = new TW_GetSupplierSupplyPtProductsTableAdapter();
            ta.CurrentConnection = session;
            //2014.02.14  Ramesh M Added For blocking same vehicle code inserted for same company. CR#62289
            ta.InsertQuery(PurchRackID, SupplierSupplyPtID, SupplierID, SupplierPtID, LastModifiedDtTm, ProductCode, ProductDescr, CustomerID);
        }


        /// <summary>
        /// GetProducts
        /// Function to return list of Products
        /// </summary>

        public static List<OrderItemDetails> GetOrderitemdetails(Guid OrderID, ISession session, String VersionNo = "")
        {
            OrderitemdetailsTableAdapter ta = new OrderitemdetailsTableAdapter();
            ta.CurrentConnection = session;
            return ta.GetDataOrderItemDetails(OrderID).Select().Cast<DAL.OrderitemdetailsRow>().ToList().ToEntities();
        }

        /// <summary>
        /// GetProducts
        /// Function to return list of Products
        /// </summary>

        public static DataTable AddTWDeliveryDetails(String CompanyID, Guid SessionID, Guid OrderItemID, String BOLProdCode, Int32 CompartmentID, Decimal GrossQty, Decimal NetQty, Decimal DeliveredQty, DateTime DeliveryDateTime, Int32 LoginID, String DeviceID, DateTime DeviceDateTime, Decimal BeforeVolume, Decimal AfterVolume, String IsDelivered, String DeliveryQtyVarianceReason, String TrailerCode, ISession session, String VersionNo = "")
        {
            cloud_TW_UpdateshipmentdetailsTableAdapter ta = new cloud_TW_UpdateshipmentdetailsTableAdapter();
            ta.CurrentConnection = session;
            return ta.GetDataTWDeliveryDetails(CompanyID, SessionID, OrderItemID, BOLProdCode, CompartmentID, GrossQty, NetQty, DeliveredQty, DeliveryDateTime, LoginID, DeviceID, DeviceDateTime, BeforeVolume, AfterVolume, IsDelivered, DeliveryQtyVarianceReason, TrailerCode, 0, null);
        }

        //Add TankWagon Delivery Details New Added By Vinoth
        public static List<Status> AddTWDeliveryDetailsXML(List<TWDeliveryDetails> lsTWDeliveryDetails, String Images, ISession session, String VersionNo = "")
        {
            DataTable dt = new DataTable();
            List<Status> lstDelitems = new List<Status>();
            Status stts = new Status();
            cloud_TW_UpdateshipmentdetailsTableAdapter ta = new cloud_TW_UpdateshipmentdetailsTableAdapter();
            ta.CurrentConnection = session;
            SqlConnection con = new SqlConnection(session.ConnectionString);
            byte[] image1 = null;
            try
            {
                if (!String.IsNullOrWhiteSpace(Images))
                {
                    image1 = System.Convert.FromBase64String(Images);
                }
            }
            catch
            {
                image1 = null;
            }
            foreach (TWDeliveryDetails lsDeliveryDetails in lsTWDeliveryDetails)
            {

                dt = ta.GetDataTWDeliveryDetails(lsDeliveryDetails.ClientID, lsDeliveryDetails.SessionID, lsDeliveryDetails.OrderItemID, lsDeliveryDetails.ProductCode, lsDeliveryDetails.CompartmentID, lsDeliveryDetails.GrossQty, lsDeliveryDetails.NetQty, lsDeliveryDetails.DeliveryQty, lsDeliveryDetails.DeliveryDateTime, lsDeliveryDetails.LoginID, lsDeliveryDetails.DeviceID, lsDeliveryDetails.DeviceDateTime, lsDeliveryDetails.BeforeVolume, lsDeliveryDetails.AfterVolume, lsDeliveryDetails.IsDelivered, lsDeliveryDetails.DeliveryQtyVarianceReason, lsDeliveryDetails.TrailerCode, lsDeliveryDetails.VehicleMeterID, image1);
                con.Open();
                if (image1 != null)
                {
                    using (SqlCommand cmd = new SqlCommand("UPDATE DeliveryDetails SET [Image] = @binaryVal WHERE  OrderItemID = '" + lsDeliveryDetails.OrderItemID + "'", con))
                    {
                        cmd.Parameters.AddWithValue("@binaryVal", image1);
                        cmd.ExecuteNonQuery();
                    }
                }
                con.Close();
            }
            stts.StatusNew = dt.Rows[0]["StatusNew"].ToString();
            stts.Reason = dt.Rows[0]["Reason"].ToString();
            lstDelitems.Add(stts);
            return lstDelitems;
        }

        //Get EOD Details Added By Vinoth
        public static List<BOLCompartments> GetEODDetails(Int32 Updatedby, int CompartmentID, String SessionID, ISession session, String VersionNo = "")
        {
            Cloud_GetEODDetailsTableAdapter ta = new Cloud_GetEODDetailsTableAdapter();
            ta.CurrentConnection = session;
            return ta.GetDataEODDetails(Updatedby, CompartmentID, SessionID).Select().Cast<DAL.Cloud_GetEODDetailsRow>().ToList().ToEntities();
        }

        //Get BOD Details Added By Vinoth
        public static List<BOLCompartments> GetBODDetails(Int32 RetainedVehicleID, String ClientID, String IsRetained, Int32 CompartmentID, ISession session, String VersionNo = "")
        {
            Cloud_GetBODDetailsTableAdapter ta = new Cloud_GetBODDetailsTableAdapter();
            ta.CurrentConnection = session;
            return ta.GetDataBODDetails(RetainedVehicleID, ClientID, IsRetained, CompartmentID).Select().Cast<DAL.Cloud_GetBODDetailsRow>().ToList().ToEntities();
        }

        //Get count of BOL Vehicle compartment Added By Vinoth
        public static List<VehicleCompartment> GetVehicleCompartmentCount(String customerID, Int32 vehicleID, String SessionID, ISession session, String VersionNo = "")
        {
            Cloud_GetCompartmentDetailsCountTableAdapter ta = new Cloud_GetCompartmentDetailsCountTableAdapter();
            ta.CurrentConnection = session;
            return ta.GetDataCompCount(vehicleID, customerID, SessionID).Select().Cast<DAL.Cloud_GetCompartmentDetailsCountRow>().ToList().ToEntities();
        }

        public static void UpdatedEODDetails(String BOLItemID, Int32 Updatedby, String ClientID, Int32 RetainedVehicleID, String IsRetained, String IsOverShort, Int32 ToSiteID, ISession session, String VersionNo = "")
        {
            Cloud_UpdateEODDetailsTableAdapter ta = new Cloud_UpdateEODDetailsTableAdapter();
            ta.CurrentConnection = session;
            ta.UpdatedByEODDetails(BOLItemID, Updatedby, ClientID, RetainedVehicleID, IsRetained, IsOverShort, ToSiteID, 0, 0);
        }

        public static void UpdatedEODDetailsXML(List<EODDetails> lsEODDetails, List<VehicleMetersTotalizer> lsVehicleMetersTotalizer, ISession session, String VersionNo = "")
        {
            int newvehicleID;
            Cloud_UpdateEODDetailsTableAdapter ta = new Cloud_UpdateEODDetailsTableAdapter();
            ta.CurrentConnection = session;
            foreach (EODDetails item in lsEODDetails)
            {
                newvehicleID = GetVehicleID(item.RetainedVehicleID, item.ClientID, session, "");
                ta.UpdatedByEODDetails(item.BOLItemID.ToString(), item.Updatedby, item.ClientID, newvehicleID, item.IsRetained, item.IsOverShort, item.ToSiteID, item.OvertSortQty, item.RetainedQty);
            }
            Cloud_TW_UpdateVehicleMeterTotalizerTableAdapter vmt = new Cloud_TW_UpdateVehicleMeterTotalizerTableAdapter();
            vmt.CurrentConnection = session;
            foreach (VehicleMetersTotalizer item in lsVehicleMetersTotalizer)
            {
                newvehicleID = GetVehicleID(item.VehicleID, item.ClientID.ToString(), session, "");
                vmt.UpdateVehicleMetersTotalizer(newvehicleID, item.ClientID, item.MeterID, item.MeterTotal, item.ShiftTotal, item.SessionID, item.Updatedby, 1);
            }
        }

        public static void UpdatedBODDetails(String BOLItemID, Int32 Updatedby, String ClientID, Guid NewSessionID, ISession session, String VersionNo = "")
        {
            Cloud_UpdateBODDetailsTableAdapter ta = new Cloud_UpdateBODDetailsTableAdapter();
            ta.CurrentConnection = session;
            //ta.UpdateBODDetails(BOLItemID, Updatedby, ClientID, NewSessionID);
        }

        public static void UpdatedBODDetailsXML(List<BODDetails> lsBODDetails, List<VehicleMetersTotalizer> lsVehicleMetersTotalizer, ISession session, String VersionNo = "")
        {
            Cloud_UpdateBODDetailsTableAdapter ta = new Cloud_UpdateBODDetailsTableAdapter();
            ta.CurrentConnection = session;
            foreach (BODDetails item in lsBODDetails)
            {
                ta.UpdateBODDetails(item.BOLItemID, item.Updatedby, item.ClientID, item.NewSessionID, item.AvailableQty, item.RetainedQty, item.OverShotQty, item.ToSiteID);
            }
            int newvehicleID;
            Cloud_TW_UpdateVehicleMeterTotalizerTableAdapter vmt = new Cloud_TW_UpdateVehicleMeterTotalizerTableAdapter();
            vmt.CurrentConnection = session;
            foreach (VehicleMetersTotalizer item in lsVehicleMetersTotalizer)
            {
                newvehicleID = GetVehicleID(item.VehicleID, item.ClientID.ToString(), session, "");
                vmt.UpdateVehicleMetersTotalizer(newvehicleID, item.ClientID, item.MeterID, item.MeterTotal, item.ShiftTotal, item.SessionID, item.Updatedby, 0);
            }
        }

        public static void UpdatedEmptyEODDetails(Int32 Updatedby, String ClientID, Int32 RetainedVehicleID, Guid SessionID, DateTime DeviceTime, String ProcessType, ISession session, String VersionNo = "")
        {
            Cloud_UpdateEODDetailsTableAdapter ta = new Cloud_UpdateEODDetailsTableAdapter();
            ta.CurrentConnection = session;
            ta.Cloud_UpdateEmptyEODDetails(Updatedby, ClientID, RetainedVehicleID, SessionID, DeviceTime, ProcessType);
        }

        /// <summary>
        /// AddProducts
        /// Function to insert the records into VehicleCompartment table
        /// </summary>
        /// <param name="SysTrxNo">SysTrxNo</param>
        /// <param name="customerID">Customer ID</param>
        /// <param name="DefDriverID">DefDriverID</param>
        /// <param name="DefVehicleID">DefVehicleID</param>
        /// <param name="OldDriverID">OldDriverID</param>
        /// <param name="OldVehicleID">OldVehicleID</param>
        /// <param name="session">Session object</param>
        public static void AddINSite(Int32 SiteID, String Code, String LongDescr, DateTime? LastModifiedDtTm, String CustomerID, ISession session, String VersionNo = "")
        {
            TW_GetINSiteTableAdapter ta = new TW_GetINSiteTableAdapter();
            ta.CurrentConnection = session;
            //2014.02.14  Ramesh M Added For blocking same vehicle code inserted for same company. CR#62289

            ta.InsertQuery(SiteID, Code, LongDescr, Convert.ToInt32(CustomerID), LastModifiedDtTm);
        }

        public static List<INSite> GetINSite(String CompanyID, ISession session, String VersionNo = "")
        {
            TW_GetINSiteTableAdapter ta = new TW_GetINSiteTableAdapter();
            ta.CurrentConnection = session;
            return ta.GetDataINSite(Convert.ToInt32(CompanyID)).Select().Cast<DAL.TW_GetINSiteRow>().ToList().ToEntities();
        }

        public static string IsBOLNoExists(string BOLNo, string CompanyID, ISession session, String VersionNo = "")
        {
            string sttus = "";
            BOLHdr_WagonTableAdapter ta = new BOLHdr_WagonTableAdapter();
            ta.CurrentConnection = session;
            sttus = ta.Cloud_TW_BOLHdrWagonExists(BOLNo, CompanyID).ToString();
            return sttus;
        }

        // Get TankWagon Line Flush product -- Added by vinoth
        public static List<Products> GetTWLineFlushProducts(String CompanyID, Guid SessionID, Int32 CompartmentID, Int32 Type, ISession session, String VersionNo = "")
        {
            Cloud_GetTWLineFlushProductsTableAdapter ta = new Cloud_GetTWLineFlushProductsTableAdapter();
            ta.CurrentConnection = session;
            return ta.GetTWFlushProducts(SessionID, CompanyID, CompartmentID, Type).Cast<DAL.Cloud_GetTWLineFlushProductsRow>().ToList().ToEntities();
        }

        //Update TankWagon line flush quantity 
        public static DataTable UpdatedTWLineFlushDetails(String CompanyID, Guid SessionID, String BOLProdCode, Int32 CompartmentID, Int32 Updatedby, Decimal AvailableQty, Int32 ToCompartmentID, Int32 ToSiteID, Int32 RetainedVehicleID, ISession session, String VersionNo = "")
        {
            Cloud_TW_UpdateLineFlushTableAdapter ta = new Cloud_TW_UpdateLineFlushTableAdapter();
            ta.CurrentConnection = session;
            return ta.UpdateTWLineFlush(CompanyID, SessionID, BOLProdCode, CompartmentID, Updatedby, AvailableQty, ToCompartmentID, ToSiteID, RetainedVehicleID);
        }

        //Get delivery count for enable line flush
        public static int? GetDeliveryCount(Guid SessionID, ISession session, String VersionNo = "")
        {
            DeliveryDetailsTableAdapter ta = new DeliveryDetailsTableAdapter();
            ta.CurrentConnection = session;
            return ta.DeliveryCount(SessionID);
        }
        //Update Vehicle Type -- Added by vinoth
        public static void UpdateTWVehicleType(Int32 VehicleTypeID, String Descr, Int32 ClientID, ISession session, String VersionNo = "")
        {
            Cloud_TW_UpdateVehicleTypeTableAdapter ta = new Cloud_TW_UpdateVehicleTypeTableAdapter();
            ta.CurrentConnection = session;
            //2014.02.14  Ramesh M Added For blocking same vehicle code inserted for same company. CR#62289

            ta.UpdateVehicleType(VehicleTypeID, Descr, ClientID);
        }
        //Get Vehicle Type Count for validate user -- Added by vinoth
        public static int GetVehicleTypeCount(Int32 vehicleTypeID, Int32 customerID, ISession session, String VersionNo = "")
        {
            Cloud_TW_GetVehicleTypeTableAdapter ta = new Cloud_TW_GetVehicleTypeTableAdapter();
            ta.CurrentConnection = session;
            DataTable dt = ta.GetTWVehicleTypeCount(vehicleTypeID, customerID);
            int cnt = 0;
            if (dt.Rows.Count > 0)
            {
                cnt = Convert.ToInt32(dt.Rows[0]["TypeCount"].ToString());
            }
            return cnt;
        }

        public static List<GetVehicleDetails> GetTWVehicles(String companyID, Int32 vehicleID, ISession session, String VersionNo = "")
        {
            Cloud_TW_GetVehicleTableAdapter ta = new Cloud_TW_GetVehicleTableAdapter();
            ta.CurrentConnection = session;
            return ta.GetTWVehicles(companyID, vehicleID).Cast<DAL.Cloud_TW_GetVehicleRow>().ToList().ToEntities();
        }

        public static List<GetVehicleTypeCompartment> GetTWVehicleTypeCompartment(String CustomerID, Int32 VehicleID, ISession session, String VersionNo = "")
        {
            Cloud_TW_GetVehicleTypeCompartmentTableAdapter ta = new Cloud_TW_GetVehicleTypeCompartmentTableAdapter();
            ta.CurrentConnection = session;
            return ta.GetVehicleTypeCompartments(VehicleID, CustomerID).Cast<DAL.Cloud_TW_GetVehicleTypeCompartmentRow>().ToList().ToEntities();
        }

        //Update TW Truck to Truck Transfer -- Added by vinoth
        public static DataTable UpdateTWTruckToTruckTransfer(Guid SessionID, String CompanyID, Int32 FromVehicleID, Int32 FromCompartmentID, String BOLProdCode, Int32 LoginID, Decimal TransferQty, Int32 ToVehicleID, Int32 ToCompartmentID, DateTime DeviceTime, Int32 Type, ISession session, String VersionNo = "")
        {
            Cloud_TW_TruckToTruckTransferTableAdapter ta = new Cloud_TW_TruckToTruckTransferTableAdapter();
            ta.CurrentConnection = session;
            return ta.TWTruckToTruckTransfer(SessionID, CompanyID, FromVehicleID, FromCompartmentID, BOLProdCode, LoginID, TransferQty, ToVehicleID, ToCompartmentID, DeviceTime, Type);
        }


        public static string IsProductDiffer(Guid SessionID, String ProdCode, String CompanyID, Int32 CompartmentID, Int32 VehicleID, Int32 Type, ISession session, String VersionNo = "")
        {
            string sttus = "";
            Cloud_TW_IsProductDifferToCompTableAdapter ta = new Cloud_TW_IsProductDifferToCompTableAdapter();
            ta.CurrentConnection = session;
            sttus = ta.CheckProdAlreadyExistToComp(SessionID, ProdCode, CompanyID, CompartmentID, VehicleID, Type).Rows[0][0].ToString();
            return sttus;
        }

        //public static Boolean UpdateFSDriverLogSched(String customerID, int DriverLogSched, ISession session, String VersionNo = "")
        //{
        //    UpdateFSDriverLogSchedTableAdapter ta = new UpdateFSDriverLogSchedTableAdapter();
        //    ta.CurrentConnection = session;
        //    return Convert.ToBoolean(ta.Fill(customerID, DriverLogSched));
        //}

        //
        public static List<VehicleMeters> GetVehicleMeters(String customerID, Int32 vehicleID, ISession session, String VersionNo = "")
        {
            Cloud_TW_GetVehicleMetersTableAdapter ta = new Cloud_TW_GetVehicleMetersTableAdapter();
            ta.CurrentConnection = session;
            return ta.GetVehicleMeters(vehicleID, customerID).Cast<DAL.Cloud_TW_GetVehicleMetersRow>().ToList().ToEntities();
        }

        public static List<VehicleMetersTotalizer> GetVehicleMetersTotalizer(String customerID, Int32 vehicleID, Int32 type, Guid SessionID, ISession session, String VersionNo = "")
        {
            Cloud_TW_GetVehicleMetersTotalizerTableAdapter ta = new Cloud_TW_GetVehicleMetersTotalizerTableAdapter();
            ta.CurrentConnection = session;
            return ta.GetVehicleMeterTotalizer(vehicleID, customerID, SessionID, type).Cast<DAL.Cloud_TW_GetVehicleMetersTotalizerRow>().ToList().ToEntities();
        }


        public static List<BOLCompartments> GetBODHistory(String ClientID, Guid SessionID, ISession session, String VersionNo = "")
        {
            Cloud_GetBODHistoryTableAdapter ta = new Cloud_GetBODHistoryTableAdapter();
            ta.CurrentConnection = session;
            return ta.GetBODHistory(ClientID, SessionID).Cast<DAL.Cloud_GetBODHistoryRow>().ToList().ToEntities();
        }

        public static List<BOLCompartments> GetEODHistory(String ClientID, Guid SessionID, ISession session, String VersionNo = "")
        {
            Cloud_GetEODHistoryTableAdapter ta = new Cloud_GetEODHistoryTableAdapter();
            ta.CurrentConnection = session;
            return ta.GetEODHistory(ClientID, SessionID).Cast<DAL.Cloud_GetEODHistoryRow>().ToList().ToEntities();
        }

        public static List<DeliveryDetails> GetDeliveryHistory(String ClientID, Guid SessionID, ISession session, String VersionNo = "")
        {
            Cloud_GetDeliveryHistoryTableAdapter ta = new Cloud_GetDeliveryHistoryTableAdapter();
            ta.CurrentConnection = session;
            return ta.GetDeliveryHistory(ClientID, SessionID).Cast<DAL.Cloud_GetDeliveryHistoryRow>().ToList().ToEntities();
        }

        public static List<Cloud_TW_GetVehicleSiteID> GetVehicleSiteID(Int32 vehicleID, String customerID, ISession session, String VersionNo = "")
        {
            Cloud_TW_GetVehicleSiteIDTableAdapter ta = new Cloud_TW_GetVehicleSiteIDTableAdapter();
            ta.CurrentConnection = session;
            return ta.GetVehicleSiteID(vehicleID, customerID).Select().Cast<DAL.Cloud_TW_GetVehicleSiteIDRow>().ToList().ToEntities();
        }

        /// <summary>
        /// Get Vehicle OverShortID
        /// </summary>
        /// <param name="vehicleID">Vehicle ID</param>
        /// <param name="customerID">Customer ID</param>
        /// <param name="session">session object</param>
        /// <returns>vehicle type</returns>
        public static Int32 GetVehicleOverShortID(Int32 vehicleID, String customerID, ISession session, String VersionNo = "")
        {
            Cloud_TW_GetVehicleOverShortSiteIDTableAdapter ta = new Cloud_TW_GetVehicleOverShortSiteIDTableAdapter();
            ta.CurrentConnection = session;
            List<DAL.Cloud_TW_GetVehicleOverShortSiteIDRow> lst = ta.GetVehicleOverShortSiteID(vehicleID, customerID).Select().Cast<DAL.Cloud_TW_GetVehicleOverShortSiteIDRow>().ToList();
            if (lst.Count > 0)
            {
                return lst[0].OverShortSiteID == null ? 0 : lst[0].OverShortSiteID;
            }
            return 0;
        }
        // 2015-Oct-23 Vinoth Added For Get GPSUpdate Flag for update GPS History
        public static string IsEnabledGPSUpdate(string CompanyID, ISession session, String VersionNo = "")
        {
            string GPSUpdate = "";
            SqlCommand cmd = (SqlCommand)session.CreateCommand();
            cmd.CommandText = "Cloud_IsEnabledGPSUpdate";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ClientID", CompanyID);
            SqlConnection con = new SqlConnection(session.ConnectionString);
            con.Open();
            SqlDataAdapter sa = new SqlDataAdapter();
            sa.SelectCommand = cmd;
            DataTable dt = new DataTable();
            sa.Fill(dt);
            con.Close();
            if (dt.Rows.Count > 0)
            {
                GPSUpdate = dt.Rows[0]["Result"].ToString();
            }
            return GPSUpdate;
        }

        public static string IsEnabledTankwagon(string CompanyID, ISession session, String VersionNo = "")
        {
            string IsEnabledTW = "";
            //Cloud_IsEnabledFrtLoadorUnloadBrkdownTableAdapter ta = new Cloud_IsEnabledFrtLoadorUnloadBrkdownTableAdapter();
            //ta.CurrentConnection = session;
            //DataTable dt = ta.GetDataIsEnabledFrtBrkdown(CompanyID);
            //if (dt.Rows.Count > 0)
            //{
            //    IsEnabledFrkBrk = dt.Rows[0]["Result"].ToString();
            //}
            SqlCommand cmd = (SqlCommand)session.CreateCommand();
            cmd.CommandText = "Cloud_IsEnabledTankwagon";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ClientID", CompanyID);
            SqlConnection con = new SqlConnection(session.ConnectionString);
            con.Open();
            SqlDataAdapter sa = new SqlDataAdapter();
            sa.SelectCommand = cmd;
            DataTable dt = new DataTable();
            sa.Fill(dt);
            con.Close();
            if (dt.Rows.Count > 0)
            {
                IsEnabledTW = dt.Rows[0]["Result"].ToString();
            }
            return IsEnabledTW;
        }

        public static string GetVersionByDriver(string CompanyID, string Username, string Password, ISession session, String VersionNo = "")
        {
            string VersionNoByDriver = "0.0";
            //Cloud_IsEnabledFrtLoadorUnloadBrkdownTableAdapter ta = new Cloud_IsEnabledFrtLoadorUnloadBrkdownTableAdapter();
            //ta.CurrentConnection = session;
            //DataTable dt = ta.GetDataIsEnabledFrtBrkdown(CompanyID);
            //if (dt.Rows.Count > 0)
            //{
            //    IsEnabledFrkBrk = dt.Rows[0]["Result"].ToString();
            //}
            SqlCommand cmd = (SqlCommand)session.CreateCommand();
            cmd.CommandText = "Cloud_GetVersionByDriver";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CustomerID", CompanyID);
            cmd.Parameters.AddWithValue("@UserName", Username);
            cmd.Parameters.AddWithValue("@Password", Password);
            SqlConnection con = new SqlConnection(session.ConnectionString);
            con.Open();
            SqlDataAdapter sa = new SqlDataAdapter();
            sa.SelectCommand = cmd;
            DataTable dt = new DataTable();
            sa.Fill(dt);
            con.Close();
            if (dt.Rows.Count > 0)
            {
                VersionNoByDriver = dt.Rows[0]["Version"].ToString();
            }
            return VersionNoByDriver;
        }

        // 2015-Dec-28 Vinoth Added For Get EnabledDeliveryDateSort Flag for sort loads based on earliest and latest delivery date
        public static string IsEnabledDeliveryDateSort(string CompanyID, ISession session, String VersionNo = "")
        {
            string EnabledDeliveryDateSort = "";
            SqlCommand cmd = (SqlCommand)session.CreateCommand();
            cmd.CommandText = "Cloud_IsEnabledDeliveryDateSort";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ClientID", CompanyID);
            SqlConnection con = new SqlConnection(session.ConnectionString);
            con.Open();
            SqlDataAdapter sa = new SqlDataAdapter();
            sa.SelectCommand = cmd;
            DataTable dt = new DataTable();
            sa.Fill(dt);
            con.Close();
            if (dt.Rows.Count > 0)
            {
                EnabledDeliveryDateSort = dt.Rows[0]["Result"].ToString();
            }
            return EnabledDeliveryDateSort;
        }

        // 2015-Dec-28 Vinoth Added For Get EnabledDeliveryDateSort Flag for sort loads based on earliest and latest delivery date
        public static Guid GetOrderID(Guid OrderItemID, ISession session, String VersionNo = "")
        {
            Guid OrderID = new Guid();
            SqlCommand cmd = (SqlCommand)session.CreateCommand();
            cmd.CommandText = "Cloud_GetOrderID";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@OrderItemID", OrderItemID);
            SqlConnection con = new SqlConnection(session.ConnectionString);
            con.Open();
            SqlDataAdapter sa = new SqlDataAdapter();
            sa.SelectCommand = cmd;
            DataTable dt = new DataTable();
            sa.Fill(dt);
            con.Close();
            if (dt.Rows.Count > 0)
            {
                OrderID = new Guid(dt.Rows[0]["OrderID"].ToString());
            }
            return OrderID;
        }

        // 2015-Dec-28 Vinoth Added For Get EnabledDestSiteFormat Flag for AR Ship To Sites Destination Format
        public static string IsEnabledDestSiteFormat(string CompanyID, ISession session, String VersionNo = "")
        {
            string EnabledDestSiteFormat = "";
            SqlCommand cmd = (SqlCommand)session.CreateCommand();
            cmd.CommandText = "Cloud_IsEnabledDestSiteFormat";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ClientID", CompanyID);
            SqlConnection con = new SqlConnection(session.ConnectionString);
            con.Open();
            SqlDataAdapter sa = new SqlDataAdapter();
            sa.SelectCommand = cmd;
            DataTable dt = new DataTable();
            sa.Fill(dt);
            con.Close();
            if (dt.Rows.Count > 0)
            {
                EnabledDestSiteFormat = dt.Rows[0]["Result"].ToString();
            }
            return EnabledDestSiteFormat;
        }

        // 2015-Dec-28 Vinoth Added For Get EnabledDeliveryDateSort Flag for sort loads based on earliest and latest delivery date
        public static string IsEnabledFreightChargeChanges(string CompanyID, ISession session, String VersionNo = "")
        {
            string FreightChargeChanges = "";
            SqlCommand cmd = (SqlCommand)session.CreateCommand();
            cmd.CommandText = "Cloud_IsEnabledFreightChargeChanges";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ClientID", CompanyID);
            SqlConnection con = new SqlConnection(session.ConnectionString);
            con.Open();
            SqlDataAdapter sa = new SqlDataAdapter();
            sa.SelectCommand = cmd;
            DataTable dt = new DataTable();
            sa.Fill(dt);
            con.Close();
            if (dt.Rows.Count > 0)
            {
                FreightChargeChanges = dt.Rows[0]["Result"].ToString();
            }
            return FreightChargeChanges;
        }

        // 2015-Dec-28 Vinoth Added For Get EnabledDeliveryDateSort Flag for sort loads based on earliest and latest delivery date
        public static string BOLDeliveryBSRule(string CompanyID, ref string DeliveryImageBSRule, ISession session, String VersionNo = "")
        {
            string BOLImageBSRule = "";
            string DeliveryVolumeBSRule = "";
            string BOLStartEndDateBSRule = "";
            SqlCommand cmd = (SqlCommand)session.CreateCommand();
            cmd.CommandText = "Cloud_BOLDeliveryBSRule";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ClientID", CompanyID);
            SqlConnection con = new SqlConnection(session.ConnectionString);
            con.Open();
            SqlDataAdapter sa = new SqlDataAdapter();
            sa.SelectCommand = cmd;
            DataTable dt = new DataTable();
            sa.Fill(dt);
            con.Close();
            if (dt.Rows.Count > 0)
            {
                BOLImageBSRule = dt.Rows[0]["BOLImageBSRule"].ToString();
                DeliveryImageBSRule = dt.Rows[0]["DeliveryImageBSRule"].ToString();
                DeliveryVolumeBSRule = dt.Rows[0]["DeliveryVolumeBSRule"].ToString();
                BOLStartEndDateBSRule = dt.Rows[0]["BOLStartEndDateBSRule"].ToString();
            }
            return BOLImageBSRule + "," + DeliveryVolumeBSRule + "," + BOLStartEndDateBSRule;
        }


        // 2016-Feb-25 Vinoth Added For Get Split Load
        public static Boolean IsSplitLoad(Guid LoadID, Guid OrderItemID, Int32 IsLoadID, ISession session)
        {
            string IsSlpit = "";
            SqlCommand cmd = (SqlCommand)session.CreateCommand();
            cmd.CommandText = "Cloud_IsSplitLoad";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@LoadID", LoadID);
            cmd.Parameters.AddWithValue("@OrderItemID", OrderItemID);
            cmd.Parameters.AddWithValue("@IsLoadID", IsLoadID);
            SqlConnection con = new SqlConnection(session.ConnectionString);
            con.Open();
            SqlDataAdapter sa = new SqlDataAdapter();
            sa.SelectCommand = cmd;
            DataTable dt = new DataTable();
            sa.Fill(dt);
            con.Close();
            if (dt.Rows.Count > 0)
            {
                IsSlpit = dt.Rows[0]["LoadNo"].ToString();
            }
            return IsSlpit.Contains('*');
        }

        /// <summary>
        /// UpdateBOLItemsAtDelivery
        /// </summary>
        /// <param name="orderID">orderID</param>
        /// <param name="orderID">BOLNo</param>
        /// <param name="session">session</param>
        /// <returns></returns>
        public static void UpdateBOLItemsAtDelivery(Guid orderItemID, String BOLNo, Guid PreOrderItemID, ISession session, String VersionNo = "")
        {
            Cloud_UpdateBOLItemsAtDeliveryTableAdapter ta = new Cloud_UpdateBOLItemsAtDeliveryTableAdapter();
            ta.CurrentConnection = session;
            ta.UpdateShipDocAtDelivery(orderItemID, BOLNo, PreOrderItemID);
        }


        public static string IsEnableRemoveLoad(string customerId, ISession session, string version)
        {
            string enableRemoveLoad = string.Empty;
            SqlConnection con = new SqlConnection(session.ConnectionString);
            try
            {
                SqlCommand cmd = (SqlCommand)session.CreateCommand();
                cmd.CommandText = "Cloud_IsEnableRemoveLoad";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ClientID", customerId);
                
                con.Open();

                object result = cmd.ExecuteScalar();
                con.Close();
                if (result != null)
                {
                    enableRemoveLoad = result.ToString();
                }
                Logging.WriteLog(string.Format("IsEnableRemoveLoad = {0}", enableRemoveLoad), System.Diagnostics.EventLogEntryType.Information);
            }
            catch (Exception ex)
            {
                Logging.LogError(ex, string.Format("IsEnableRemoveLoad - {0}", ex.Message));
            }
            finally
            {
                con.Close();
            }
            return enableRemoveLoad;
        }

        public static string GetCustomizeStatusViewFlag(string customerId, ISession session, string version)
        {
            string CustomizedStatusViewFlag = string.Empty;
            SqlConnection con = new SqlConnection(session.ConnectionString);

            try
            {
                SqlCommand cmd = (SqlCommand)session.CreateCommand();
                cmd.CommandText = "Cloud_GetCustomizedViewStatusFlag";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ClientID", customerId);

                DataTable dt = new DataTable();
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);

                if (dt != null && dt.Rows.Count > 0)
                {
                    CustomizedStatusViewFlag = dt.Rows[0]["EnableCustomizedStatusView"].ToString();
                }
               
                Logging.WriteLog(string.Format("CustomizedStatusViewFlag = {0}", CustomizedStatusViewFlag), System.Diagnostics.EventLogEntryType.Information);
            }
            catch (Exception ex)
            {
                Logging.LogError(ex, string.Format("CustomizedStatusViewFlag - {0}", ex.Message));
            }            
            return CustomizedStatusViewFlag;
        }

        public static List<OEStatus> GetOEStatus(string ClientID, ISession session, String VersionNo = "")
        {
            List<OEStatus> lstOEStatus = new List<OEStatus>();
            SqlConnection con = new SqlConnection(session.ConnectionString);
            try
            {

                DataTable dtOEStatus = new DataTable();               
                SqlCommand cmd = (SqlCommand)session.CreateCommand();

                cmd.CommandText = "Cloud_GetOEStatus";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ClientID", ClientID);

                SqlDataAdapter adp = new SqlDataAdapter();
                adp.SelectCommand = cmd;
                
                adp.Fill(dtOEStatus);
               

                if (dtOEStatus != null && dtOEStatus.Rows.Count > 0)
                {
                    foreach (DataRow dr in dtOEStatus.Rows)
                    {
                        OEStatus oeStatus = (OEStatus)dr.AssignValues(new OEStatus());
                        lstOEStatus.Add(oeStatus);
                    }
                }
            }
            catch (Exception ex)
            {
                Logging.LogError(ex, string.Format("GetOEStatus - {0}", ex.Message));
            }
            finally
            {
                con.Close();
            }
            return lstOEStatus;

        }



        #endregion


        public static int UpdateShipNeedUpdate(ISession session, Guid OrderItemID)
        {
            int isUpdated = 0;
            SqlConnection con = new SqlConnection(session.ConnectionString);
            try
            {
                SqlCommand cmd = (SqlCommand)session.CreateCommand();
                cmd.CommandText = "Cloud_UpdateShipNeedUpdate";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@orderItemID", OrderItemID);

                con.Open();
                SqlDataAdapter sa = new SqlDataAdapter();
                sa.SelectCommand = cmd;
                DataTable dt = new DataTable();
                sa.Fill(dt);
                con.Close();

                if (dt != null && dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["StatusNew"].ToString().Trim().ToUpper() == "SUCCESS")
                    {
                        isUpdated = 1;
                    }
                }
                //isUpdated = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                string exception = ex.Message;
            }
            finally
            {
                con.Close();
            }
            return isUpdated;

        }

        public static string GetDataToDeleteOldDataFromApp(string customerId, ISession session, string version)
        {
            string GetDataToDeleteOldDataFromAppInDays = string.Empty;
            SqlConnection con = new SqlConnection(session.ConnectionString);

            try
            {
                SqlCommand cmd = (SqlCommand)session.CreateCommand();
                cmd.CommandText = "Cloud_GetDataToDeleteOldDataFromApp";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ClientID", customerId);

                DataTable dt = new DataTable();
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);

                if (dt != null && dt.Rows.Count > 0)
                {
                    GetDataToDeleteOldDataFromAppInDays = dt.Rows[0]["DeleteOldDataFromAppInDays"].ToString() + "," + dt.Rows[0]["DeleteOldDataFromAppFreqInHrs"].ToString();
                }

                Logging.WriteLog(string.Format("GetDataToDeleteOldDataFromApp = {0}", GetDataToDeleteOldDataFromAppInDays), System.Diagnostics.EventLogEntryType.Information);
            }
            catch (Exception ex)
            {
                Logging.LogError(ex, string.Format("GetDataToDeleteOldDataFromApp - {0}", ex.Message));
            }
            return GetDataToDeleteOldDataFromAppInDays;
        }

        public static int InsertDispatchChangeLoad(ISession session, Guid LoadID, string LoadNo, string CustomerID, int DriverID)
        {
            int isUpdated = 0;
            SqlConnection con = new SqlConnection(session.ConnectionString);
            try
            {
                SqlCommand cmd = (SqlCommand)session.CreateCommand();
                cmd.CommandText = "Cloud_CreateDispatchChangeLoad";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@LoadID", LoadID);
                cmd.Parameters.AddWithValue("@LoadNo", LoadNo);
                cmd.Parameters.AddWithValue("@CustomerID", CustomerID);
                cmd.Parameters.AddWithValue("@DriverID", DriverID);

                con.Open();
                SqlDataAdapter sa = new SqlDataAdapter();
                sa.SelectCommand = cmd;
                DataTable dt = new DataTable();
                sa.Fill(dt);
                con.Close();

                if (dt != null && dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["StatusNew"].ToString().Trim().ToUpper() == "SUCCESS")
                    {
                        isUpdated = 1;
                    }
                }
                //isUpdated = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                string exception = ex.Message;
            }
            finally
            {
                con.Close();
            }
            return isUpdated;

        }

        public static List<DispatchChangeLoad> GetDispatchChangeLoad(String customerID, Int32? driverID, ISession session, String VersionNo = "")
        {
            List<DispatchChangeLoad> lstLoads = new List<DispatchChangeLoad>();
            try
            {
                SqlConnection con = new SqlConnection(session.ConnectionString);
                SqlCommand cmd = (SqlCommand)session.CreateCommand();
                cmd.CommandText = "Cloud_GetDisptachChangeLoad";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CustomerID", customerID);
                cmd.Parameters.AddWithValue("@DriverID", driverID);

                con.Open();
                SqlDataAdapter sa = new SqlDataAdapter();
                sa.SelectCommand = cmd;
                DataTable dtLoads = new DataTable();
                sa.Fill(dtLoads);
                con.Close();

                if (dtLoads != null && dtLoads.Rows.Count > 0)
                {
                    lstLoads = (from DataRow row in dtLoads.Rows
                                select new DispatchChangeLoad
                                {
                                    LoadID = Guid.Parse(row["LoadID"].ToString()),
                                    LoadNo = row["LoadNo"].ToString(),
                                    CustomerID = row["CustomerID"].ToString(),
                                    DriverID = ToNullableInt(row["DriverID"].ToString())
                                }).ToList();
                }

                return lstLoads;
            }
            catch (Exception Ex)
            {
                throw;
            }
        }

        public static int? ToNullableInt(object val)
        {
            if (val is DBNull ||
                val == null)
            {
                return null;
            }
            if (val is string &&
                ((string)val).Length == 0)
            {
                return null;
            }
            return Convert.ToInt32(val);
        }
    }
}