// 2014.01.10  Ramesh M Added For CR#61759 Added to full From Site business rule
// 2014.01.10  Ramesh M Added For CR#61759 Added to full From Site business rule
// 2014.01.10  Ramesh M Added For CR#61759 For supplierSupplyPt
// 2014.02.16  Ramesh M Added For CR#62166 For DOT OverRide
// 2014.02.20  Ramesh M Added For CR#62301 For Driver status Screen in Ipad
// 2014.02.25  Ramesh M Added For CR#62292 For modified driver summary log
// 2014.03.17  Ramesh M Added For CR#62668 to get home terminal details
// 2014.03.17  Ramesh M Added For CR#62613 to Auto logoff through Ipad
// 2014.03.18  Ramesh M Added For CR#62719 added  TrailerCode in input parameters
// 2014.03.20  Ramesh M Added For CR#62322 added  Version testing method
// 05-14-2014  MadhuVenkat K - Added for CR 63396 - Add Time Remaining Section to Driver Summary
// 05-20-2014  MadhuVenkat k - Added for CR 63346 - PO & Priority No to Load Information Screen 
// 06-26-2014  MadhuVenkat k - Added for CR 64058  - For Add orderDispatchHistory 
// 06-26-2014  MadhuVenkat k - Added for CR 64058  - For update status in orderDispatchHistory
// 06-26-2014  MadhuVenkat k - Added for CR 64058  - For Geting List of OrderDipatchHistory details 
// 07-09-2014  MadhuVenkat k - Modified for CR 64172 - Modified For unable to process loads in ipad when a Vehicle Code is alpha numeric value.
// 08-14-2014  MadhuVenkat K - Added for CR 64639 - Add StatusUpdate to GpsHistory
// 08-14-2014  MadhuVenkat K - Added for CR 64639 - Add CurrentDriverStatus to Driver Summary
// 09-09-2014  CR#64208, Madhu, Add Modified date to GetInspectionElementsData
// 09-23-2014  MadhuVenkat k - Added for CR#65002  added SupplierCode and SupplyPointCode
// 12-17-2014  MadhuVenkat K  Added for CR 65762 - In Multi BOL processing, the gross qty and Net qty not updating correct qty.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using DeliveryStreamCloudWCF.Entities;
using DeliveryStreamCloudWCF.Utils;


using DeliveryStreamCloudWCF.DataAccess;
using System.Xml;
using System.Security.Permissions;

namespace DeliveryStreamCloudWCF.Service
{
    /// <summary>
    /// Interface ICloudService
    /// </summary>
    [ServiceContract]
    public interface ICloudService
    {

        #region Login Details

        /// <summary>
        /// CheckUserLogin
        /// Function to validate user login
        /// </summary>
        /// <param name="UserName">User name</param>
        /// <param name="vehicleID">Vehicle ID</param>
        /// <param name="password">Password</param>
        /// <param name="companyID">Company ID</param>
        /// <param name="deviceToken">Device Token</param> 
        /// <param name="DeviceID">DeviceID</param>
        /// <param name="GMT">GMT</param>
        /// <returns>True = Valid customer, False = Failed</returns>
        [OperationContract]
        Boolean CheckUserLogin(String UserName, String vehicleID, String password, String companyID, String deviceToken, String DeviceID, DateTime GMT, String TrailerCode);

        /// <summary>
        /// CheckUserLogin
        /// Function to validate user login
        /// </summary>
        /// <param name="UserName">User name</param>
        /// <param name="vehicleID">Vehicle ID</param>
        /// <param name="password">Password</param>
        /// <param name="companyID">Company ID</param>
        /// <param name="deviceToken">Device Token</param> 
        /// <param name="deviceTime">Device Login Time</param>
        /// <param name="DeviceID">DeviceID</param>
        /// <param name="GMT">GMT</param>
        /// <returns>SessionID</returns>

        [OperationContract]
        Guid CheckUserLogin2(String UserName, String vehicleID, String password, String companyID, String deviceToken, DateTime deviceTime, String DeviceID, DateTime GMT, String TrailerCode);

        /// <summary>
        /// 2013.4.30, Suresh Madhesan, CR#?
        /// 2014.02.10 Ramesh M Added TrailerCode For CR#62211
        /// Function added to get the session ID and User type ID
        /// </summary>
        /// <param name="UserName">UserName</param>
        /// <param name="vehicleID">vehicleID</param>
        /// <param name="password">password</param>
        /// <param name="companyID">companyID</param>
        /// <param name="deviceToken">deviceToken</param>
        /// <param name="deviceTime">deviceTime</param>
        /// <param name="VersionNo">VersionNo</param>
        /// <param name="UserType">UserType</param>
        /// <param name="DeviceID">DeviceID</param>
        /// <param name="GMT">GMT</param>
        /// <returns></returns>

        [OperationContract]
        String CheckUserLogin3(String UserName, String vehicleID, String password, String companyID, String deviceToken, DateTime deviceTime, String VersionNo, String UserType, String DeviceID, DateTime GMT, String TrailerCode, String IOSVersion = "",String AppInstalledON = "");

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
        [OperationContract]
        String CheckUserLogin4(String UserName, String vehicleID, String password, String companyID, String deviceToken, DateTime deviceTime, String VersionNo, String UserType, String DeviceID, DateTime GMT, String TrailerCode, String IOSVersion = "", String AppInstalledON = "");
        /// <summary>
        /// CheckCustomerLogin
        /// Function to validate customer login
        /// </summary>
        /// <param name="companyID">Company ID</param>
        /// <param name="password">Password</param>
        /// <returns>True = Valid customer, False = Failed</returns>
        [OperationContract]
        Boolean CheckCustomerLogin(String companyID, String password, String VersionNo = "");

        // 2014.03.17  Ramesh M Added For CR#62668 to get home terminal details
        [OperationContract]
        List<LoginHomeTerminalDetails> GetLoginHomeTerminalDetails(String userID, String password, String companyID, String UserType, String VersionNo = "");

        // 06-26-2014  MadhuVenkat k - Added for CR 64058  - For Geting List of OrderDipatchHistory details
        // 07-09-2014  MadhuVenkat k - Modified for CR 64172 - Modified For unable to process loads in ipad when a Vehicle Code is alpha numeric value.
        [OperationContract]
        List<OrderDispatchHistory> GetUnAssignedOrders(String UserName, String password, String companyID, String OldDriverID, String OldVehicleID, DateTime? deviceTime = null, String VersionNo = "");

        // 2014.03.17  Ramesh M Added For CR#62613 to Auto logoff through Ipad
        [OperationContract]
        Boolean EndPreviousLogin(String UserName, String vehicleID, String password, String companyID, String deviceToken, DateTime deviceTime, String VersionNo, String UserType, String DeviceID, DateTime GMT, String TrailerCode);

        // 06-26-2014  MadhuVenkat k - Added for CR 64058  - For Update status in orderDispatchHistory 
        [OperationContract]
        Boolean UpdateOrderDipatchHistory(String UserName, String password, Decimal SysTrxNo, String companyID, Int32 OldVehicleID, String VersionNo = "");

        // 06-26-2014  MadhuVenkat k - Added for CR 64058  - For Add orderDispatchHistory 
        [OperationContract]
        Boolean AddOrderDipatchHistory(Decimal SysTrxNo, String companyID, String password, Int32 DefDriverID, Int32 DefVehicleID, Int32 OldDriverID, Int32 OldVehicleID, String VersionNo = "");

        #endregion  Login Details

        #region Get Details

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
        [OperationContract]
        List<Load> GetLoads(String UserName, String password, String vehicleID, String companyID, Guid loadID, String loadNo, String loadStatusID, Boolean includeOrders, Boolean includeOrderItems, DateTime? deviceTime = null, String VersionNo = "");

        /// <summary>
        /// 
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="password"></param>
        /// <param name="vehicleID"></param>
        /// <param name="companyID"></param>
        /// <param name="loadID"></param>
        /// <param name="loadNo"></param>
        /// <param name="loadStatusID"></param>
        /// <param name="includeOrders"></param>
        /// <param name="includeOrderItems"></param>
        /// <returns></returns>
        [OperationContract]
        List<WarehouseLoad> GetWareHouseLoads(String UserName, String password, String vehicleID, String companyID, Guid loadID, String loadNo, String loadStatusID, Boolean includeOrders, Boolean includeOrderItems, String VersionNo = "");

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
        [OperationContract]
        Int32 GetOrderCountByStatus(String UserName, String password, String vehicleID, String companyID, Guid loadID, String orderStatusID, String VersionNo = "");

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
        [OperationContract]
        String GetLoadStatus(String UserName, String password, String vehicleID, String companyID, Guid loadID, String VersionNo = "");

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
        [OperationContract]
        String GetOrderStatus(String UserName, String password, String vehicleID, String companyID, Guid orderID, String VersionNo = "");

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
        [OperationContract]
        List<BolHdr> GetBolHdrs(String UserName, String password, String vehicleID, String companyID, Guid bolHdrID, Guid loadID, String bolNo, String VersionNo = "");

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
        [OperationContract]
        List<Bolitem> GetBolitems(String UserName, String password, String vehicleID, String companyID, Guid bolItemID, Guid bolHdrID, Decimal SysTrxNo, Int32 sysTrxLine, Int32 componentNo, String VersionNo = "");

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
        [OperationContract]
        List<DeliveryDetails> GetDeliveryDetails(String UserName, String password, String vehicleID, String companyID, Guid orderItemID, String VersionNo = "");

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
        [OperationContract]
        List<OrderFrt> GetOrderFrts(String UserName, String password, String vehicleID, String companyID, Guid orderID, String VersionNo = "");

        [OperationContract]
        SignatureImage GetSignatureImage(String companyID, String password, Decimal SysTrxNo, String VersionNo = "");

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
        [OperationContract]
        List<OrderItem> GetPickedOrderItemDetails(String UserName, String password, String vehicleID, String companyID, Guid orderID, Boolean includeOrderItems, String VersionNo = "");

        /// <summary>
        /// 
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="password"></param>
        /// <param name="vehicleID"></param>
        /// <param name="companyID"></param>
        /// <param name="UserType"></param>
        /// <returns></returns>
        [OperationContract]
        List<GetDriverDetails> GetDriverDetails(String UserName, String password, String vehicleID, String companyID, String UserType, String VersionNo = "");
        /// <summary>
        /// GetVehicleDetails
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="password"></param>
        /// <param name="vehicleID"></param>
        /// <param name="companyID"></param>
        /// <returns></returns>
        [OperationContract]
        List<GetVehicleDetails> GetVehicleDetails(String UserName, String password, String vehicleID, String companyID, String VersionNo = "");

        // 09-09-2014  CR#64208, Madhu, Add Modified date to GetInspectionElementsData
        [OperationContract]
        List<InspectionElements> GetInspectionElementsID(String UserName, String password, String vehicleID, String companyID, String Modified, String VersionNo = "");

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sessionID"></param>
        /// <returns></returns>
        [OperationContract]
        Boolean IsSessionIDExist(Guid sessionID, ISession session, String VersionNo = "");

        /// <summary>
        /// 
        /// </summary>
        /// <param name="CustomerID"></param>
        /// <returns></returns>

        [OperationContract]
        String ListOFLoadNosToMerge(String CustomerID, String VersionNo = "");

        /// <summary>
        /// 
        /// </summary>
        /// <param name="CustomerID"></param>
        /// <param name="OrderNo"></param>
        /// <param name="OrderStatus"></param>
        /// <returns></returns>
        [OperationContract]
        Boolean ListOFOrderNosToUpdate(String CustomerID, String OrderNo, String OrderStatus, String VersionNo = "");

        /// <summary>
        /// GetSupplierFromSiteList
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="password"></param>
        /// <param name="vehicleID"></param>
        /// <param name="companyID"></param>
        /// <param name="VersionNo"></param>
        /// <returns></returns>
        [OperationContract]
        List<SupplierSupplypointList> GetSupplierFromSiteList(String UserName, String password, String vehicleID, String companyID, String VersionNo = "");

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
        [OperationContract]
        List<SupplierSupplypointList> GetShipToBasedFromSiteList(String UserName, String password, String vehicleID, String companyID, String ShipToID, String VersionNo = "");
        #endregion Get Details

        #region Get Summary

        /// <summary>
        /// GetLastLogOffTime
        /// Function to get last logofftime from LoginHistory table
        /// </summary>
        /// <param name="sessionID">SessionID</param>
        /// <returns>LastLogoffTime</returns>
        [OperationContract]
        DateTime? GetLastLogoffTime(Guid sessionID, String VersionNo = "");


        ///// <summary>
        ///// GetDriverSummary
        ///// </summary>
        ///// <param name="sessionID">sessionID</param>
        ///// <param name="startTime">startTime</param>
        ///// <param name="endTime">endTime</param>
        ///// <returns></returns>
        //[OperationContract]
        //List<DriverSummary> GetDriverSummary(Guid sessionID, DateTime startTime, DateTime endTime,String VersionNo="");

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sessionID"></param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        [OperationContract]
        List<DriverSummary> GetDriverSummary(Guid sessionID, DateTime startTime, DateTime endTime, DateTime? modifiedTime = null);

        // 05-14-2014 MadhuVenkat K - Added for CR 63396 - Add Time Remaining Section to Driver Summary
        [OperationContract]
        List<RemainingTimeSummary> GetRemainingTimeSummary(Guid sessionID, DateTime LoginDatetime, DateTime startTime, DateTime endTime);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sessionID"></param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        [OperationContract]
        List<CumulativeShiftSummaryResponse> CummulativeGetDriverSummary(Guid sessionID, DateTime startTime, DateTime endTime, String VersionNo = "");

        /// <summary>
        /// lstLoginHistory
        /// Function to get records from LoginHistory table
        /// </summary>
        /// <param name="sessionID">Session ID</param>
        /// <param name="currentTime">Current Time</param>
        /// <returns>SummaryLogResponse</returns>
        [OperationContract]
        SummaryLogResponse GetSummaryLogInformation(Guid sessionID, DateTime currentTime, String VersionNo = "");

        // 2014.02.20  Ramesh M Added For CR#62301 For Driver status Screen in Ipad
        [OperationContract]
        List<DriverLogStatus> GetDriverLogStatus(Guid sessionID, DateTime startTime, DateTime endTime, String VersionNo = "");

        #endregion

        #region Update details


        // /// </summary>
        ///// <param name="longitude">Longitude</param>
        ///// <param name="latitude">Latitude</param>
        ///// <param name="sessionID">SessionID</param>
        ///// <param name="deviceTime">DeviceTime</param>
        // /// <param name="GMT">GMT</param>
        // /// <param name="GpsStrength">GpsStrength</param>
        ///// <returns>True = Updated successfully, False = Failed</returns>
        //[OperationContract]
        //Boolean UpdateGPSHistory2(String longitude, String latitude, Guid sessionID, DateTime deviceTime, DateTime GMT, String sGpsStrength, String sStatus, String PreviousLongitude, String PreviousLatitude);

        /// <summary>
        /// UpdateGPSHistory
        /// Function to insert the records into GPS history table
        /// </summary>
        /// <param name="lstGPSHist">List of GPSHistory</param>
        /// <returns>True = Updated successfully, False = Failed</returns>
        [OperationContract]
        Boolean UpdateGPSHistoryList(List<GPSHistory> lstGPSHist, String VersionNo = "");

        /// <summary>
        /// 
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
        /// <returns></returns>
        [OperationContract]
        Boolean AcceptAndShippedWarehouseLoad(String UserName, String password, String SiteCode, String companyID, Guid loadID, String loadStatusID, String longitude, String latitude, String deviceID, DateTime deviceTime, Int32 driverID, Int32 vehicleID, String VersionNo = "");

        /// <summary>
        /// UpdateGPSHistory
        /// Function to insert the records into GPS history table
        /// </summary>
        /// <param name="UserName">User name</param>
        /// <param name="password">Password</param>
        /// <param name="vehicleID">Vehicle ID</param>
        /// <param name="companyID">Company ID</param>
        /// <param name="longitude">Longitude</param>
        /// <param name="latitude">Latitude</param>
        /// <param name="deviceID">DeviceID</param>
        /// <param name="deviceTime">DeviceTime</param>
        /// <returns>True = Updated successfully, False = Failed</returns>
        [OperationContract]
        Boolean UpdateGPSHistory(String UserName, String password, String vehicleID, String companyID, String longitude, String latitude, String deviceID, DateTime deviceTime, DateTime GMT, String VersionNo = "");

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
        [OperationContract]
        Boolean UpdateLoadStatus(String UserName, String password, String vehicleID, String companyID, Guid loadID, String loadStatusID, String longitude, String latitude, String city, String state, String deviceID, DateTime deviceTime, String VersionNo = "", String RejectedNotes = "");

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
        [OperationContract]
        Boolean UpdateOrderStatus(String UserName, String password, String vehicleID, String companyID, Guid loadID, Guid orderID, String orderStatusID, String longitude, String latitude, String deviceID, DateTime deviceTime, String VersionNo = "");

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
        /// <returns>True = Updated successfully, False = Failed</returns>
        [OperationContract]
        Boolean UpdateDriver(String companyID, String password, Int32 driverID, String UserName, String UserPassword, String Email, String FirstName, String MiddleName, String LastName, String UserType,
                                    String Co_Name, String Co_Addr1, String Co_City, String Co_State, String Co_Zip, String HT_Descr, String HT_Addr1, String HT_City, String HT_State, String HT_Zip, DateTime HazMatDate, String VersionNo = "");

        /// <summary>
        /// UpdateVehicle
        /// </summary>
        /// <param name="companyID">companyID</param>
        /// <param name="password">password</param>
        /// <param name="VehicleID">VehicleID</param>
        /// <param name="VehicleCode">VehicleCode</param>
        /// <returns>True = Inserted successfully, False = Faile</returns>
        [OperationContract]
        Boolean UpdateVehicle(String companyID, String password, Int32 VehicleID, String VehicleCode, Int32 VehicleType, Int32 OverShortSiteID, String VersionNo = "");

        /// <summary>
        /// Update Signature Status
        /// </summary>
        /// <param name="companyID">companyID</param>
        /// <param name="password">password</param>
        /// <param name="SysTrxNo">SysTrxNo</param>
        /// <returns>Boolean</returns>
        [OperationContract]
        Boolean UpdateSignatureStatus(String companyID, String password, Decimal SysTrxNo, String VersionNo = "");

        /// <summary>
        /// Update UndispatchLoad
        /// </summary>
        /// <param name="companyID">companyID</param>
        /// <param name="password">password</param>
        /// <param name="loadNo">loadNo</param>
        /// <returns></returns>
        [OperationContract]
        Boolean UpdateUndispatchLoad(String companyID, String password, string loadNo, String VersionNo = "");

        /// <summary>
        /// Update Load Undispatched Status
        /// </summary>
        /// <param name="sessionID">sessionID</param>
        /// <param name="loadIDs">loadID</param>
        /// <param name="UndispatchedStatus">UndispatchedStatus (0 OR 1)</param>
        /// <param name="VersionNo">VersionNo</param>
        /// <returns></returns>
        [OperationContract]
        Boolean UpdateLoadUndispatchedStatus(Guid sessionID, List<Guid> loadIDs, int UndispatchedStatus, String VersionNo = "");

        /// <summary>
        /// 
        /// </summary>
        /// <param name="companyID"></param>
        /// <param name="password"></param>
        /// <param name="SiteID"></param>
        /// <param name="SiteCode"></param>
        /// <param name="UserName"></param>
        /// <param name="UserPassword"></param>
        /// <param name="UserType"></param>
        /// <returns></returns>
        [OperationContract]
        Boolean UpdateWareHouseUser(String companyID, String password, Int32 SiteID, String SiteCode, String UserName, String UserPassword, String UserType, String VersionNo = "");

        // 2014.01.10  Ramesh M Added For CR#61759 Added to full From Site business rule
        /// <summary>
        /// UpdateFromSiteBSRule
        /// </summary>
        /// <param name="companyID"></param>
        /// <param name="password"></param>
        /// <param name="FromSiteBSRule"></param>
        /// <param name="VersionNo"></param>
        /// <returns></returns>
        [OperationContract]
        Boolean UpdateFromSiteBSRule(String companyID, String password, Int32 FromSiteBSRule, Int32 MultiBOLBSRule, String VersionNo = "");

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
        [OperationContract]
        Boolean UpdateFromSite(String companyID, String password, Int32? ShiptoID, Int32 SuppliersupplyPtID, Int32 SupplierID, Int32 SupplyPtID, String SupplierDescr, String SupplyPtDescr, String Address1, String Address2, String SupplierCode, String SupplyPtCode, String VersionNo = "");

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

        // 2014.01.17 Ramesh M Added For  CR#61759 to get from site list 
        [OperationContract]
        Boolean UpdateOrderSuppliersupplyPt(String UserName, String password, String vehicleID, String companyID, Guid OrderID, Int32 SuppliersupplyPtID, String SupplierDescr, String SupplyPtDescr, String VersionNo = "");



        #endregion Update details

        #region Add Details

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
        /// <returns>True = Inserted successfully, False = Failed</returns>
        [OperationContract]
        Boolean AddLoad(String companyID, String password, Load load, String vehicleCode, Boolean SleeperRig, String UserName, String UserPassword, String Email, String FirstName, String MiddleName, String LastName, String LoadType, String VersionNo = "");
        /// <summary>
        /// 
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
        [OperationContract]
        Boolean DeleteLoad(String companyID, String password, Load load, String vehicleCode, Boolean SleeperRig, String UserName, String UserPassword, String Email, String FirstName, String MiddleName, String LastName, String VersionNo = "");

        // 2014.03.18  Ramesh M Added For CR#62719 added  TrailerCode in input parameters
        // 09-23-2014  MadhuVenkat k - Added for CR#65002  added SupplierCode and SupplyPointCode.
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
        /// <param name="BOLQtyVarianceReason">BOL QtyVarianceReason </param>
        /// <param name="AssignedDriverLoginID">AssignedDriverLoginID</param>
        /// <param name="AssignedVehicleID">AssignedVehicleID </param>
        /// <param name="LoadType">LoadType</param>
        /// <returns>True = Inserted successfully, False = Faile</returns>
        [OperationContract]
        Boolean AddShipmentDetails(String UserName, String password, String vehicleID, String companyID, Guid loadID, String bolNo, DateTime bolDateTime, DateTime? bolDateTimeEnd, Decimal sysTrxNo, Int32 sysTrxLine, Int32 componentNo, Decimal grossQty, Decimal netQty, String images, String deviceID, DateTime deviceTime, Boolean BOLWaitTime, String BOLWaitTime_Comment, DateTime? BOLWaitTime_Start, DateTime? BOLWaitTime_End, String BOLQtyVarianceReason, Int32 AssignedDriverLoginID, Int32 AssignedVehicleID, String LoadType, Int32 ExtSysTrxLine, String TrailerCode, String SupplierCode, String SupplyPointCode, String VersionNo, Guid OrderItemID = new Guid());

         //2016.03.28 Vinoth Added for support multi BOL Update.
        [OperationContract]
        Boolean AddShipmentDetailsXML(List<BolHdrXML> lsBolHdrXML, String UserName, String password, String vehicleID, String companyID, Guid loadID, String LoadType, String VersionNo);

        [OperationContract]
        List<ShipmentXMLResponse> AddShipmentXML(List<BolHdrXML> lsBolHdrXML, String UserName, String password, String vehicleID, String companyID, Guid loadID, String LoadType, String VersionNo);

        [OperationContract]
        Boolean UpdateStuckLoads(String UserName, String password, String vehicleID, String companyID, Guid loadID, String VersionNo);
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
        [OperationContract]
        Boolean AddDeliveryDetails(String UserName, String password, String vehicleID, String companyID, Guid orderItemID, Decimal grossQty, Decimal netQty, DateTime delivDtTm, String deviceID, DateTime deviceTime, Decimal? beforeVolume, Decimal? afterVolume, String delivered, String DeliveryQtyVarianceReason, String BOLNo, String VersionNo, String Image = "", String Notes = "", String PONo = "", Guid PreOrderItemID = new Guid());

        [OperationContract]
        List<DeliveryXMLResponse> AddDeliveryDetailsXML(List<DeliveryDetailsXML> lsDeliveryDetails, String UserName, String password, String vehicleID, String companyID, String VersionNo = "");
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
        /// <param name="signatureImage">signatureImage</param>
        /// <returns>True = Inserted successfully, False = Faile</returns>
        [OperationContract]
        Boolean AddOrderFrt(String UserName, String password, String vehicleID, String companyID, Guid OrderID, Boolean? SiteWaitTime, string SiteWaitTime_Comment, DateTime? SiteWaitTime_Start, DateTime? SiteWaitTime_End, Boolean? SplitLoad, string SplitLoad_Comment, Boolean? SplitDrop, string SplitDrop_Comment, Boolean? PumpOut, string PumpOut_Comment, Boolean? Diversion, string Diversion_Comment, Boolean? MinimumLoad, string MinimumLoad_Comment, Boolean? Other, string Other_Comment, string DeviceID, DateTime DeviceTime, string signatureImage, String VersionNo = "");

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
        /// <param name="UserName">UserName</param>
        /// <param name="VehicleID">VehicleCode</param>
        /// <returns>True = Inserted successfully, False = Failed</returns>

        [OperationContract]
        Boolean AddPreDutyInspectionDetails(Guid sessionID, Boolean PreDuty_Inspection, DateTime? PreDuty_InspectionDateTime, Boolean PreDutyViolation, Int32 PreDutyFaults, Decimal BeginningOdometer, String UserName, String VehicleCode, String VersionNo = "");

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

        [OperationContract]
        Boolean AddPostDutyInspectionDetails(Guid sessionID, Boolean PostDuty_Inspection, DateTime? PostDuty_InspectionDateTime, Boolean PostDutyViolation, Int32 PostDutyFaults, Decimal BeginningOdometer, Decimal EndingOdometer, Decimal NextLubrication, string DriverSignature, String VersionNo = "");

        /// <summary>
        /// AddAdverseConditionDetails
        /// Function to insert the record into AdverseCondition table
        /// </summary>
        /// <param name="sessionID">SessionID</param>
        /// <param name="AdverseCondition">AdvereseCondition</param>
        /// <param name="AdverseConditionReason">AdverseConditionReason</param>
        /// <param name="AdverseConditionDateTime">AdverseConditionDateTime</param>
        /// <returns>True = Inserted successfully, False = Failed</returns>

        [OperationContract]
        Boolean AddAdverseConditionDetails(Guid sessionID, Boolean AdverseCondition, String AdverseConditionReason, DateTime AdverseConditionDateTime, String VersionNo = "");

        /// <summary>
        /// AddSleeperRigTimeDetails
        /// Function to insert the record into SleeperRig table
        /// </summary>
        /// <param name="sessionID">SessionID</param>
        /// <param name="startTime">StartTime</param>
        /// <param name="endTime">EndTime</param>
        /// <returns>True = Inserted successfully, False = Failed</returns>
        [OperationContract]
        Boolean AddSleeperRigTimeDetails(Guid sessionID, DateTime startTime, DateTime endTime, String VersionNo = "");

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
        [OperationContract]
        Guid AddLoginSession(String UserName, String password, String vehicleID, String companyID, String deviceToken, DateTime loginTime, DateTime deviceTime, String DeviceID, DateTime GMT, String TrailerCode, String VersionNo, String IOSVersion = "");

        /// <summary>
        /// TruckFuelingDetails
        /// Function to insert recoed in tblTruckFuelingDetails
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
        [OperationContract]
        void AddTruckFuelingDetails(String userName, String password, Guid sessionID, String companyID, String vehicleID, String driverID, String deviceDateTime, Decimal odometer, Decimal qty, String fuelType, String latitude, String longitude, String state, Boolean fuelTaxPaid, String fuelingLocation, Decimal MPG, String VersionNo = "");

        /// <summary>
        /// AddSignatureImage
        /// Function to insert recoed in Add SignatureImage
        /// <param name="sessionID">session ID</param>
        /// <param name="orderID">orderID</param>
        /// <param name="signatureImage">signature Image</param>
        /// <param name="signatureDateTime">signatureDateTime</param>
        /// </summary>
        [OperationContract]
        Boolean ç(Guid sessionID, Guid orderID, string signatureImage, DateTime signatureDateTime);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sessionID"></param>
        /// <param name="orderID"></param>
        /// <param name="signatureImage"></param>
        /// <param name="signatureDateTime"></param>
        /// <returns></returns>
        [OperationContract]
        Boolean AddSignatureImage(Guid sessionID, Guid orderID, string signatureImage, DateTime signatureDateTime, String VersionNo = "");

        /// <summary>
        /// 
        /// </summary>
        /// <param name="OrderNo"></param>
        /// <param name="LoadNo"></param>
        /// <param name="OrderItemId"></param>
        /// <param name="PickedBy"></param>
        /// <param name="CustomerId"></param>
        /// <param name="Status"></param>
        [OperationContract]
        void AddOrUpdateOrderPickingDetails(String OrderNo, String LoadNo, String OrderItemId, Int32 PickedBy, String CustomerId, String Status, String VersionNo = "");

        /// <summary>
        /// 
        /// </summary>
        /// <param name="OrderNo"></param>
        /// <param name="LoadNo"></param>
        /// <param name="OrderItemId"></param>
        /// <param name="PickedBy"></param>
        /// <param name="CustomerId"></param>
        /// <param name="Status"></param>
        [OperationContract]
        void DeleteOrderPickingDetails(String OrderNo, String LoadNo, String OrderItemId, Int32 PickedBy, String CustomerId, String Status, String VersionNo = "");

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
        [OperationContract]
        Boolean AddBreakDetails(Guid SessionID, DateTime BreakStartTime, DateTime? BreakEndTime, String TimeViolation, String MovingViolation, String NoBreakViolation, String VersionNo = "");

        /// <summary>
        /// 
        /// </summary>
        /// <param name="SessionID"></param>
        /// <param name="BreakStartTime"></param>
        /// <param name="BreakEndTime"></param>
        /// <returns></returns>
        [OperationContract]
        Boolean UpdateBreakDetails(Guid SessionID, DateTime BreakStartTime, DateTime BreakEndTime, String VersionNo = "");

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sessionID"></param>
        /// <param name="InspectionTypeID"></param>
        /// <param name="InspectionElementsID"></param>
        /// <returns></returns>
        [OperationContract]
        Boolean AddInspectionDetails(Guid sessionID, Int32 InspectionTypeID, String InspectionElementsID, String VersionNo = "");

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
        /// <param name="OverRideReason"></param>
        /// <param name="VersionNo"></param>
        /// <returns></returns>
        [OperationContract]
        Boolean AddDOTOverRideDetails(String UserName, String password, String vehicleID, String companyID, Guid sessionID, DateTime StartDate, DateTime EndDate, String OverRideType, String OverRideReason, String VersionNo = "");

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
        [OperationContract]
        Boolean AddDriverTimeExceptions(String UserName, String password, String vehicleID, String companyID, Guid SessionID, DateTime StartTime,
                                              DateTime? EndTime, String TimeViolation, String MovingViolation, String NoBreakViolation, String ExceptionType, String ExceptionReason, String VersionNo = "");

        /// <summary>
        /// 
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
        //[OperationContract]
        //Boolean AddPackageLubeShipmentDetails(String UserName, String password, String vehicleID, String companyID, Guid loadID, Decimal OrderedQty, String deviceID, DateTime deviceTime, String DriverName);
        #endregion Add Details

        #region Logout Details

        /// <summary>
        /// Logout
        /// Function to logout user and end user login session
        /// </summary>
        /// <param name="sessionID">Session ID</param> 
        /// <param name="logoutTime">Logout Time</param>
        /// <param name="CalledBy">CalledBy</param>
        /// <returns>True = User logout successfull, False = User logout Failed</returns>
        [OperationContract]
        Boolean Logout(Guid sessionID, DateTime logoutTime, String CalledBy, String VersionNo = "");

        #endregion Logout Details

        #region App Exception Report

        /// <summary>
        /// To log App exception
        /// </summary>
        /// <param name="sessionID"></param>
        /// <param name="errorMessage"></param>
        [OperationContract]
        void AppExceptionReport(Guid sessionID, String errorMessage, String VersionNo = "");

        #endregion

        // 2014.03.20  Ramesh M Added For CR#62322 added  Version testing method
        [OperationContract]
        List<VersionTest> GetVersionTestingData(Guid sessionID, String VersionNo = "", DateTime? startTime = null, DateTime? endTime = null);

        [OperationContract]
        Boolean UpdateFSDriverLogSched(String companyID, String password, int DriverLogSched, String VersionNo = "");

        [OperationContract]
        List<DeliveryDetailsData> GetDeliveryData(String UserName, String password, String vehicleID, String companyID, Guid orderID, String VersionNo = "");

        [OperationContract]
        void UpdateFrtBreakdown(String companyID, String password, char FrtBrkdown, String VersionNo = "");

        [OperationContract]
        Boolean UpdateBolImage(String UserName, String password, String vehicleID, String companyID, String bolHdrID, Guid loadID, String bolNo, String Image, String VersionNo = "");

        [OperationContract]
        void UpdateDeliveryDateSort(String companyID, String password, char DeliveryDateSort, String VersionNo = "");

        [OperationContract]
        void UpdateBOLImageVolumeStartEndBOLRule(String companyID, String password, char RequireBOLImage, char RequireDeliveryImage, char DeliveryVolumeBSRule, char BOLStartEndDateBSRule, String VersionNo = "");

        [OperationContract]
        List<BolHdr> GetBOLHdrDetails(String UserName, String password, String vehicleID, String companyID, Guid loadID, String VersionNo = "");

        [OperationContract]
        Boolean DeleteFromSite(String companyID, String password, Int32 OEDefID, Int32 SupplierID, Int32 SupplyPtID, String VersionNo = "");

        [OperationContract]
        List<BolHdr> GetBOLDetails(String UserName, String password, String vehicleID, String companyID, Guid loadID, String VersionNo = "");

        [OperationContract]
        void UpdateRemoveLoadFlag(String customerId, String password, string removeLoadFlag, String VersionNo = "");
      

        #region TankWagon Details

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
        [OperationContract]
        Boolean AddVehicleCompartment(String companyID, String password, Int32 VehicleID, Int32 CompartmentID, String Code, Int32 Capacity, String VersionNo = "");

        /// <summary>
        /// GetVehicleCompartment
        /// </summary>
        /// <param name="SysTrxNo">SysTrxNo</param>
        /// <param name="companyID">companyID</param>
        /// <param name="password">password</param>
        /// <param name="DefDriverID">DefDriverID</param>
        /// <param name="DefVehicleID">DefVehicleID</param>
        /// <param name="OldDriverID">OldDriverID</param>
        /// <param name="OldVehicleID">OldVehicleID</param>
        /// <returns></returns>
        [OperationContract]
        List<VehicleCompartment> GetVehicleCompartment(String UserName, String password, String vehicleID, Int32 UpdatedBy, String SessionID, String companyID, String VersionNo = "");
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
        /// <returns></returns>
        [OperationContract]
        Boolean AddBOLHdrWagon(String UserName, String password, String companyID, String vehicleID, String BOLNo, DateTime BOLDatetime, String SupplierCode, String SupplyPointCode, Int32 UpdatedBy, String VersionNo = "");

        /// <summary>
        /// AddBOLItemWagon
        /// </summary>
        /// <param name="SysTrxNo">SysTrxNo</param>
        /// <param name="companyID">companyID</param>
        /// <param name="password">password</param>
        /// <param name="DefDriverID">DefDriverID</param>
        /// <param name="DefVehicleID">DefVehicleID</param>
        /// <param name="OldDriverID">OldDriverID</param>
        /// <param name="OldVehicleID">OldVehicleID</param>
        /// <returns></returns>
        [OperationContract]
        Boolean AddBOLItemWagon(String UserName, String password, String companyID, String vehicleID, Guid BOLHdrID, Decimal SystrxNo, Int32 SystrxLine, Int32 CompartmentID, String ProdCode, Decimal GrossQty, Decimal NetQty, Decimal OrderedQty, String Notes, String VersionNo = "");

        /// <summary>
        /// GetBolitemWagons
        /// </summary>
        /// <param name="SysTrxNo">SysTrxNo</param>
        /// <param name="companyID">companyID</param>
        /// <param name="password">password</param>
        /// <param name="DefDriverID">DefDriverID</param>
        /// <param name="DefVehicleID">DefVehicleID</param>
        /// <param name="OldDriverID">OldDriverID</param>
        /// <param name="OldVehicleID">OldVehicleID</param>
        /// <returns></returns>
        [OperationContract]
        List<BolitemWagon> GetBolitemWagons(String UserName, String password, String vehicleID, String companyID, Guid bolItemID, Guid bolHdrID, String VersionNo = "");

        /// <summary>
        /// GetSupplierAndSupplierSupplyPt
        /// </summary>
        /// <param name="SysTrxNo">SysTrxNo</param>
        /// <param name="companyID">companyID</param>
        /// <param name="password">password</param>
        /// <param name="DefDriverID">DefDriverID</param>
        /// <param name="DefVehicleID">DefVehicleID</param>
        /// <param name="OldDriverID">OldDriverID</param>
        /// <param name="OldVehicleID">OldVehicleID</param>
        /// <returns></returns>
        [OperationContract]
        List<Supplier> GetSupplierAndSupplierSupplyPt(String UserName, String password, String companyID, String VersionNo = "");

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
        /// <returns></returns>
        [OperationContract]
        Boolean AddSuppliers(String companyID, String password, Int32 SupplierID, String Codes, String Descr, DateTime? LastModifiedDtTm, String VersionNo = "");


        /// <summary>
        /// AddSupplierSupplyPt
        /// </summary>
        /// <param name="SysTrxNo">SysTrxNo</param>
        /// <param name="companyID">companyID</param>
        /// <param name="password">password</param>
        /// <param name="DefDriverID">DefDriverID</param>
        /// <param name="DefVehicleID">DefVehicleID</param>
        /// <param name="OldDriverID">OldDriverID</param>
        /// <param name="OldVehicleID">OldVehicleID</param>
        /// <returns></returns>
        [OperationContract]
        Boolean AddSupplierSupplyPt(String companyID, String password, Int32 SupplierSupplyPtID, Int32 SupplierID, DateTime? LastModifiedDtTm, String SupplierSupplyPtCode, String SupplierSupplyPtDescr, String VersionNo = "");

        /// <summary>
        /// GetSupplierSupplyPtProducts
        /// </summary>
        /// <param name="SysTrxNo">SysTrxNo</param>
        /// <param name="companyID">companyID</param>
        /// <param name="password">password</param>
        /// <param name="DefDriverID">DefDriverID</param>
        /// <param name="DefVehicleID">DefVehicleID</param>
        /// <param name="OldDriverID">OldDriverID</param>
        /// <param name="OldVehicleID">OldVehicleID</param>
        /// <returns></returns>
        [OperationContract]
        List<Products> GetSupplierSupplyPtProducts(String UserName, String password, String companyID, Int32 SupplierID, Int32 SupplierPtID, String VersionNo = "");

        /// <summary>
        /// AddBOLItemHdrWagon
        /// </summary>
        /// <param name="SysTrxNo">SysTrxNo</param>
        /// <param name="companyID">companyID</param>
        /// <param name="password">password</param>
        /// <param name="DefDriverID">DefDriverID</param>
        /// <param name="DefVehicleID">DefVehicleID</param>
        /// <param name="OldDriverID">OldDriverID</param>
        /// <param name="OldVehicleID">OldVehicleID</param>
        /// <returns></returns>
        [OperationContract]
        Boolean AddBOLItemHdrWagon(String UserName, String password, String companyID, String vehicleID, String BOLNo, String BOLDatetime, String SupplierCode, String SupplyPointCode, Int32 UpdatedBy, Decimal SystrxNo, Int32 SystrxLine, Int32 CompartmentID, String ProdCode, Decimal GrossQty, Decimal NetQty, Decimal OrderedQty, String Notes, String Image, String VersionNo = "");
        /// <summary>
        /// AddProducts
        /// </summary>
        /// <param name="SysTrxNo">SysTrxNo</param>
        /// <param name="companyID">companyID</param>
        /// <param name="password">password</param>
        /// <param name="DefDriverID">DefDriverID</param>
        /// <param name="DefVehicleID">DefVehicleID</param>
        /// <param name="OldDriverID">OldDriverID</param>
        /// <param name="OldVehicleID">OldVehicleID</param>
        /// <returns></returns> 
        [OperationContract]
        Boolean AddProducts(String companyID, String password, Int32 PurchRackID, Int32 SupplierSupplyPtID, Int32 SupplierID, Int32 SupplierPtID, DateTime? LastModifiedDtTm, String ProductCode, String ProductDescr, String VersionNo = "");
        /// <summary>
        /// GetWagonLoads
        /// </summary>
        /// <param name="SysTrxNo">SysTrxNo</param>
        /// <param name="companyID">companyID</param>
        /// <param name="password">password</param>
        /// <param name="DefDriverID">DefDriverID</param>
        /// <param name="DefVehicleID">DefVehicleID</param>
        /// <param name="OldDriverID">OldDriverID</param>
        /// <param name="OldVehicleID">OldVehicleID</param>
        /// <returns></returns>  
        [OperationContract]
        List<Load> GetWagonLoads(String UserName, String password, String vehicleID, String companyID, Guid loadID, String loadNo, String loadStatusID, Boolean includeOrders, Boolean includeOrderItems, String VersionNo = "");

        [OperationContract]
        //Boolean AddBOLItemHdrWagon1(String UserName, String password, String companyID, String vehicleID, Guid sessionID, String BOLNo, String BOLDatetime, String SupplierCode, String SupplyPointCode, String Image, List<BolitemWagon> BOLItemDetails, String VersionNo = "");
        List<Status> AddBOLItemHdrWagon1(String UserName, String password, String companyID, String vehicleID, Guid sessionID, String BOLNo, String BOLDatetime, String SupplierCode, String SupplyPointCode, String Image, List<BolitemWagon> BOLItemDetails, String VersionNo = "");

        [OperationContract]
        List<Status> AddBOLItemHdrWagonXML(List<BolHdrWagon> lsBolHdrWagon, String UserName, String password, String companyID, String vehicleID, String VersionNo = "");

        [OperationContract]
        List<BOLCompartments> GetProductCompartment(String UserName, String password, String companyID, Int32 Updatedby, String ProductCode, String SessionID, Guid OrderId, Guid OrderItemId, String VersionNo = "");

        [OperationContract]
        List<OrderItemDetails> GetTWDeliveryDetails(String UserName, String password, String vehicleID, String companyID, Guid OrderID, String VersionNo = "");

        [OperationContract]
        List<Status> AddTWDeliveryDetails(String UserName, String password, String vehicleID, String companyID, Guid SessionID, Guid OrderID, String ProdCode, Int32 CompartmentID, Decimal GrossQty, Decimal NetQty, Decimal DeliveryQty, DateTime DeliveryDateTime, Int32 LoginID, String DeviceID, DateTime DeviceDateTime, Decimal BeforeVolume, Decimal AfterVolume, String IsDelivered, String DeliveryQtyVarianceReason, String TrailerCode, String VersionNo = "");


        //Get EOD Details updated By Vinoth
        [OperationContract]
        List<VehicleCompartment> GetEODDetails(String UserName, String password, String vehicleID, Int32 UpdatedBy, String SessionID, String companyID, String VersionNo = "");

        //Update EOD Details updated By Vinoth
        [OperationContract]
        Boolean UpdatedEODDetail(String BOLItemID, Int32 Updatedby, String ClientID, String RetainedVehicleID, String IsRetained, String IsOverShort, Int32 ToSiteID, String VersionNo = "");

        [OperationContract]
        Boolean UpdatedBODDetail(String BOLItemID, Int32 Updatedby, String ClientID, Guid NewSessionID, String VersionNo = "");

        [OperationContract]
        Boolean UpdatedEmptyBODEODDetails(Int32 Updatedby, String ClientID, String RetainedVehicleID, Guid SessionID, DateTime DeviceTime, String ProcessType, String VersionNo = "");

        //Get BOD Details updated By Vinoth
        [OperationContract]
        List<VehicleCompartment> GetBODDetails(String UserName, String password, String vehicleID, Int32 UpdatedBy, String companyID, String VersionNo = "");

        [OperationContract]
        List<INSite> GetINSite(String UserName, String password, String companyID, String VersionNo = "");

        [OperationContract]
        Boolean AddINSite(String companyID, String password, Int32 SiteID, String Code, String LongDescr, DateTime? LastModifiedDtTm, String VersionNo = "");

        [OperationContract]
        List<Products> GetTWLineFlushProducts(String UserName, String password, String companyID, Guid SessionID, Int32 CompartmentID, Int32 Type, String VersionNo = "");

        [OperationContract]
        List<Status> UpdatedTWLineFlushDetail(String CompanyID, Guid SessionID, String BOLProdCode, Int32 CompartmentID, Int32 Updatedby, Decimal AvailableQty, Int32 ToCompartmentID, String vehicleID, Int32 ToSiteID, String VersionNo = "");

        [OperationContract]
        List<Status> AddTWDeliveryDetailsXML(List<TWDeliveryDetails> lsTWDeliveryDetails, String Image, String UserName, String password, String VersionNo = "");

        [OperationContract]
        Boolean UpdatedEODDetailXML(List<EODDetails> lsEODDetails, List<VehicleMetersTotalizer> lsVehicleMetersTotalizer, String VersionNo = "");

        [OperationContract]
        Boolean UpdatedBODDetailXML(List<BODDetails> lsBODDetails, List<VehicleMetersTotalizer> lsVehicleMetersTotalizer, String VersionNo = "");

        [OperationContract]
        Boolean AddTWVehicleType(String companyID, String password, Int32 VehicleTypeID, String Descr, Int32 ClientID, String VersionNo = "");

        [OperationContract]
        List<GetVehicleDetails> GetTWVehicles(String UserName, String password, String companyID, String VehicleID, String VersionNo = "");

        [OperationContract]
        List<Status> UpdatedTWTruckToTruckTransfer(Guid SessionID, String CompanyID, String FromVehicleID, Int32 FromCompartmentID, String BOLProdCode, Int32 LoginID, Decimal TransferQty, String ToVehicleID, Int32 ToCompartmentID, DateTime DeviceTime, Int32 Type, String VersionNo = "");

        [OperationContract]
        List<DSTWHistory> GetDSTWHistory(String UserName, String password, String vehicleID, Guid SessionID, String companyID, String VersionNo = "");


        #endregion

        [OperationContract]
        List<OEStatus> GetOEStatus(String UserName, String password, String vehicleID, String companyID, String VersionNo = "");

        [OperationContract]
        String GetDataToDeleteOldDataFromApp(String UserName, String password, String vehicleID, String companyID, String VersionNo = "");

        /// <summary>
        /// GetDispatchChangeLoads
        /// Function to get the load records from DispatchChangeLoads table
        /// </summary>
        /// <param name="UserName">User name</param>
        /// <param name="companyID">Company ID</param>
        /// <param name="VersionNo">VersionNo</param>
        /// <returns>List of load</returns>
        [OperationContract]
        List<DispatchChangeLoad> GetDispatchChangeLoads(String UserName, String companyID, String VersionNo = "");
    }
}
