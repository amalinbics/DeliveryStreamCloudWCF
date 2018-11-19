// 2014.01.30  Ramesh M Added For CR#62038 Added AllowDriversToChangeMultiBOL
// 2014.02.20  Ramesh M Added For CR#62301 For Driver status Screen in Ipad
// 2014.02.20  Ramesh M Added For CR#62292 For driver summary log
// 2014.02.25  Ramesh M Added For CR#62292 For modified driver summary log
// 2014.03.17  Ramesh M Added For CR#62613 to get home terminal details
// 2014.03.18  Ramesh M Added For CR#62322 added  Version testing method
// 05-14-2014  MadhuVenkat K - Added for CR 63396 - Add Time Remaining Section to Driver Summary
// 05-20-2014  MadhuVenkat k - Added for CR 63346 - PO & Priority No to Load Information Screen 
// 06-26-2014  MadhuVenkat k - Added for CR 64058  - For Add orderDispatchHistory 
// 08-25-2014  MadhuVenkat K - Added for CR 64760 - Add InspectionVersion to Driver Summary
// 09-09-2014  CR#64208, Madhu, Add Modified date to GetInspectionElementsData
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DeliveryStreamCloudWCF.Entities;
using System.Data;
using System.ComponentModel;
using DeliveryStreamCloudWCF.Utils;

namespace DeliveryStreamCloudWCF.DataAccess
{
    /// <summary>
    /// ExtensionMethods
    /// ExtensionMethods class
    /// </summary>
    public static class ExtensionMethods
    {
        /// <summary>
        /// Function to convert LoginSessionRow to LoginSession class object
        /// </summary>
        /// <param name="row">LoginSession row object</param>
        /// <returns>LoginSession class object</returns>
        public static LoginSession ToEntity(this DeliveryStreamCloudWCF.DataAccess.DAL.LoginSessionRow row)
        {
            LoginSession entity = new LoginSession();
            entity.Active = row.Active_Ext;
            entity.CurrentVehicle = row.CurrentVehicle_Ext;
            entity.DeviceID = row.DeviceID_Ext;
            entity.LoginID = row.LoginID_Ext;
            entity.LogoffTime = row.LogoffTime_Ext;
            entity.LogonTime = row.LogonTime_Ext;
            entity.SessionID = row.SessionID_Ext;
            return entity;
        }

        /// <summary>
        /// Function to convert list of StatusRow to list of Status class object
        /// </summary>
        /// <param name="rows">List of status row object</param>
        /// <returns>List of status class object</returns>
        public static List<LoginSession> ToEntities(this List<DAL.LoginSessionRow> rows)
        {
            List<LoginSession> entities = new List<LoginSession>();
            rows.ForEach(item => entities.Add(item.ToEntity()));
            return entities;
        }

        /// <summary>
        /// Function to convert StatusRow to Status class object
        /// </summary>
        /// <param name="row">Status row object</param>
        /// <returns>Status class object</returns>
        public static Status ToEntity(this DeliveryStreamCloudWCF.DataAccess.DAL.StatusRow row)
        {
            Status entity = new Status();
            entity.ID = row.Id_Ext;
            entity.Description = row.Description_Ext;
            entity.Sequence = row.Sequence_Ext;
            return entity;
        }

        /// <summary>
        /// Function to convert list of StatusRow to list of Status class object
        /// </summary>
        /// <param name="rows">List of status row object</param>
        /// <returns>List of status class object</returns>
        public static List<Status> ToEntities(this List<DAL.StatusRow> rows)
        {
            List<Status> entities = new List<Status>();
            rows.ForEach(item => entities.Add(item.ToEntity()));
            return entities;
        }


        /// <summary>
        /// Function to convert LoginHistoryRow to Status class object
        /// </summary>
        /// <param name="row">Login History Row object</param>
        /// <returns>Login History class object</returns>
        public static LoginHistory ToEntity(this DeliveryStreamCloudWCF.DataAccess.DAL.LoginHistoryRow row)
        {
            LoginHistory entity = new LoginHistory();
            entity.LoginID = row.LoginID_Ext;
            entity.VehicleID = row.VehicleID_Ext;
            entity.CustomerID = row.CustomerID_Ext;
            entity.DeviceID = row.DeviceID_Ext;
            entity.DeviceToken = row.DeviceToken_Ext;
            entity.DateTime = row.DateTime_Ext;
            entity.IsValidToken = row.IsValidToken_Ext;
            entity.DeviceTime = row.DeviceTime_Ext;
            entity.LogoffTime = row.LogoffTime_Ext;
            entity.OnDuty = row.OnDuty_Ext;
            entity.Driving = row.Driving_Ext;
            entity.Sleeper = row.Sleeper_Ext;
            entity.OffDuty = row.OffDuty_Ext;
            entity.SessionID = row.SessionID_Ext;
            return entity;
        }

        /// <summary>
        /// Function to convert list of LoginHistoryRow to list of LoginHistory class object
        /// </summary>
        /// <param name="rows">List of Login History Row object</param>
        /// <returns>List of Login History class object</returns>
        public static List<LoginHistory> ToEntities(this List<DAL.LoginHistoryRow> rows)
        {
            List<LoginHistory> entities = new List<LoginHistory>();
            rows.ForEach(item => entities.Add(item.ToEntity()));
            return entities;
        }



        /// <summary>
        /// Function to convert OrderItemRow to OrderItem class object
        /// </summary>
        /// <param name="row">OrderItem row object</param>
        /// <returns>OrderItem class object</returns>
        public static OrderItem ToEntity(this DeliveryStreamCloudWCF.DataAccess.DAL.OrderItemRow row)
        {
            OrderItem entity = new OrderItem();
            entity.ID = row.Id_Ext;
            entity.OrderID = row.OrderID_Ext;
            entity.SysTrxLine = row.SysTrxLine_Ext;
            entity.OrderedQty = row.OrderedQty;
            entity.ProdCode = row.ProdCode_Ext;
            entity.ProdName = row.ProdName_Ext;
            entity.ProdUOM = row.ProdUOM_Ext;
            entity.Blend = row.Blend_Ext;
            entity.SupplierName = row.SupplierName_Ext;
            entity.SupplierCode = row.SupplierCode_Ext;
            entity.SupplyPointName = row.SupplyPointName_Ext;
            entity.SupplyPointCode = row.SupplyPointCode_Ext;
            entity.SupplyPointAddress1 = row.SupplyPointAddress1_Ext;
            entity.SupplyPointAddress2 = row.SupplyPointAddress2_Ext;
            entity.City = row.City_Ext;
            entity.State = row.State_Ext;
            entity.Zip = row.Zip_Ext;
            entity.Country = row.Country_Ext;
            entity.Note = row.Note_Ext;
            entity.ARShipToTankID = row.ARShipToTankID_Ext;
            entity.ARShipToTankCode = row.ARShipToTankCode_Ext;
            return entity;
        }


        /// <summary>
        /// Function to convert list of OrderItemRow to list of OrderItem class object
        /// </summary>
        /// <param name="rows">List of order item row object</param>
        /// <returns>List of order item class object</returns>
        public static List<OrderItem> ToEntities(this List<DeliveryStreamCloudWCF.DataAccess.DAL.OrderItemRow> rows)
        {
            List<OrderItem> entities = new List<OrderItem>();
            rows.ForEach(item => entities.Add(item.ToEntity()));
            return entities;
        }

        /// <summary>
        /// Function to convert OrderRow to Order class object
        /// </summary>
        /// <param name="row">Order row object</param>
        /// <returns>Order class object</returns>
        public static Order ToEntity(this DeliveryStreamCloudWCF.DataAccess.DAL.OrderRow row)
        {
            Order entity = new Order();
            entity.ID = row.Id_Ext;
            entity.OrderNo = row.OrderNo_Ext;
            entity.SysTrxNo = row.SysTrxNo_Ext;
            entity.LoadID = row.LoadID_Ext;
            entity.PromisedDtTm = row.PromisedDtTm_Ext;
            entity.DestAddress1 = row.DestAddress1_Ext;
            entity.DestAddress2 = row.DestAddress2_Ext;
            entity.City = row.City_Ext;
            entity.State = row.State_Ext;
            entity.Zip = row.Zip_Ext;
            entity.DestNotes = row.DestNotes_Ext;
            entity.DestSite = row.DestSite_Ext;
            entity.Country = row.Country_Ext;
            entity.Notes = row.Notes_Ext;
            entity.RequestedDtTm = row.RequestedDtTm_Ext;
            entity.PONo = row.PONo_Ext;
            entity.PriorityNo = row.PriorityNo_Ext;
            return entity;
        }

        /// <summary>
        /// Function to convert list of OrderRow to list of Order class object
        /// </summary>
        /// <param name="rows">List of order row object</param>
        /// <returns>List of order class object</returns>
        public static List<Order> ToEntities(this List<DeliveryStreamCloudWCF.DataAccess.DAL.OrderRow> rows)
        {
            List<Order> entities = new List<Order>();
            rows.ForEach(item => entities.Add(item.ToEntity()));
            return entities;
        }

        /// <summary>
        /// Function to convert OrderItemComponentRow to OrderItemComponent class object
        /// </summary>
        /// <param name="row">Order item component row object</param>
        /// <returns>Order item component class object</returns>
        public static OrderItemComponent ToEntity(this DeliveryStreamCloudWCF.DataAccess.DAL.OrderItemComponentRow row)
        {
            OrderItemComponent entity = new OrderItemComponent();
            entity.ID = row.Id_Ext;
            entity.OrderItemID = row.OrderItemID_Ext;
            entity.ComponentNo = row.ComponentNo_Ext;
            entity.Qty = row.Qty_Ext;
            entity.ProdName = row.ProdName_Ext;
            entity.ProdCode = row.ProdCode_Ext;
            entity.ProdUOM = row.ProdUOM_Ext;
            entity.SupplierName = row.SupplierName_Ext;
            entity.SupplierCode = row.SupplierCode_Ext;
            entity.SupplyPointName = row.SupplyPointName_Ext;
            entity.SupplyPointCode = row.SupplyPointCode_Ext;
            entity.SupplyPointAddress1 = row.SupplyPointAddress1_Ext;
            entity.SupplyPointAddress2 = row.SupplyPointAddress2_Ext;
            entity.City = row.City_Ext;
            entity.State = row.State_Ext;
            entity.Zip = row.Zip_Ext;
            entity.Country = row.Country_Ext;
            entity.FromCSTankID = row.FromCSTankID_Ext;
            entity.ToCSTankID = row.ToCSTankID_Ext;
            entity.FromCSTankCode = row.FromCSTankCode_Ext;
            entity.ToCSTankCode = row.ToCSTankCode_Ext;
            return entity;
        }

        /// <summary>
        /// Function to convert list of OrderItemComponentRow to list of OrderItemComponent class object
        /// </summary>
        /// <param name="rows">List of order item component row object</param>
        /// <returns>List of order item component class object</returns>
        public static List<OrderItemComponent> ToEntities(this List<DeliveryStreamCloudWCF.DataAccess.DAL.OrderItemComponentRow> rows)
        {
            List<OrderItemComponent> entities = new List<OrderItemComponent>();
            rows.ForEach(item => entities.Add(item.ToEntity()));
            return entities;
        }

        public static CompletedLoads ToEntity(this DeliveryStreamCloudWCF.DataAccess.DAL.Cloud_TW_GetLoadDetailsToDeleteRow row)
        {
            CompletedLoads entity = new CompletedLoads();
            entity.LoadID = row.LoadId_Ext;
            entity.LoadNo = row.LoadNo_Ext;
            entity.LoadStatusID = row.LoadStatusID_Ext;
            entity.LastUpdatedTime = row.LastUpdatedTime_Ext;

            return entity;
        }

        public static List<CompletedLoads> ToEntities(this List<DeliveryStreamCloudWCF.DataAccess.DAL.Cloud_TW_GetLoadDetailsToDeleteRow> rows)
        {
            List<CompletedLoads> entities = new List<CompletedLoads>();
            rows.ForEach(item => entities.Add(item.ToEntity()));
            return entities;
        }

        // 2014.01.30  Ramesh M Added For CR#62038 Added AllowDriversToChangeMultiBOL
        /// <summary>
        /// Function to convert LoadRow to Load class object
        /// </summary>
        /// <param name="row">Load row object</param>
        /// <returns>Load class object</returns>
        public static Load ToEntity(this DeliveryStreamCloudWCF.DataAccess.DAL.LoadRow row)
        {
            Load entity = new Load();
            entity.ID = row.Id_Ext;
            entity.LoadNo = row.LoadNo_Ext;
            entity.CustomerID = row.CustomerID_Ext;
            entity.VehicleID = row.VehicleID_Ext;
            entity.DriverID = row.DriverID_Ext;
            entity.LastUpdatedTime = row.LastUpdatedTime_Ext;
            entity.FSRule_BOLWaitTime = row.FSRule_BOLWaitTime_Ext;
            entity.FSRule_SiteWaitTime = row.FSRule_SiteWaitTime_Ext;
            entity.FSRule_SplitLoad = row.FSRule_SplitLoad_Ext;
            entity.FSRule_SplitDrop = row.FSRule_SplitDrop_Ext;
            entity.FSRule_PumpOut = row.FSRule_PumpOut_Ext;
            entity.FSRule_Diversion = row.FSRule_Diversion_Ext;
            entity.FSRule_MinLoad = row.FSRule_MinLoad_Ext;
            entity.FSRule_Other = row.FSRule_Other_Ext;
            entity.FSRule_BOLWaitTime_Reason = row.FSRule_BOLWaitTime_Reason_Ext;
            entity.FSRule_SiteWaitTime_Reason = row.FSRule_SiteWaitTime_Reason_Ext;
            entity.FSRule_SplitLoad_Reason = row.FSRule_SplitLoad_Reason_Ext;
            entity.FSRule_SplitDrop_Reason = row.FSRule_SplitDrop_Reason_Ext;
            entity.FSRule_PumpOut_Reason = row.FSRule_PumpOut_Reason_Ext;
            entity.FSRule_Diversion_Reason = row.FSRule_Diversion_Reason_Ext;
            entity.FSRule_MinLoad_Reason = row.FSRule_MinLoad_Reason_Ext;
            entity.FSRule_Other_Reason = row.FSRule_Other_Reason_Ext;
            entity.QtyTolerance = row.QtyTolerance_Ext;
            entity.PercentTolerance = row.PercentTolerance_Ext;
            entity.OrderLoadReviewEnabled = row.OrderLoadReviewEnabled_Ext;
            entity.UndispatchRequest = row.UndispatchRequest_Ext;
            entity.Undispatched = row.Undispatched_Ext;
            entity.LoadType = row.LoadType_Ext;
            entity.FromSiteBSRule = row.FromSiteBSRule_Ext;
            entity.ShipToID = row.ShipToID_Ext;
            entity.MultiBOLBSRule = row.MultiBOLBSRule_Ext;
            entity.LastStatusUpdatedDateTime = row.LastStatusUpdatedDateTime_Ext == null ? string.Empty : ((DateTime)row.LastStatusUpdatedDateTime_Ext).ToString("MM-dd-yyyy HH:ss tt");
            //entity.IsDeleted = row.IsDeleted_Ext;
            return entity;
        }

        /// <summary>
        /// Function to convert list of LoadRow to list of Load class object
        /// </summary>
        /// <param name="rows">List of load row object</param>
        /// <returns>List of load class object</returns>
        public static List<Load> ToEntities(this List<DeliveryStreamCloudWCF.DataAccess.DAL.LoadRow> rows)
        {
            List<Load> entities = new List<Load>();
            rows.ForEach(item => entities.Add(item.ToEntity()));
            return entities;
        }
        //2013.11.18 FSWW, Ramesh M Added For CR#60902... To Get warehouse loads with assigned driver id, assigned driver name and assigned vehicle code
        /// <summary>
        /// Function to convert WarehouseLoadRow to Load class object
        /// </summary>
        /// <param name="row">WarehouseLoad row object</param>
        /// <returns>WarehouseLoad class object</returns>
        public static WarehouseLoad ToEntity(this DeliveryStreamCloudWCF.DataAccess.DAL.WarehouseLoadRow row)
        {
            WarehouseLoad entity = new WarehouseLoad();
            entity.ID = row.Id_Ext;
            entity.LoadNo = row.LoadNo_Ext;
            entity.CustomerID = row.CustomerID_Ext;
            entity.VehicleID = row.VehicleID_Ext;
            entity.DriverID = row.DriverID_Ext;
            entity.FSRule_BOLWaitTime = row.FSRule_BOLWaitTime_Ext;
            entity.FSRule_SiteWaitTime = row.FSRule_SiteWaitTime_Ext;
            entity.FSRule_SplitLoad = row.FSRule_SplitLoad_Ext;
            entity.FSRule_SplitDrop = row.FSRule_SplitDrop_Ext;
            entity.FSRule_PumpOut = row.FSRule_PumpOut_Ext;
            entity.FSRule_Diversion = row.FSRule_Diversion_Ext;
            entity.FSRule_MinLoad = row.FSRule_MinLoad_Ext;
            entity.FSRule_Other = row.FSRule_Other_Ext;
            entity.FSRule_BOLWaitTime_Reason = row.FSRule_BOLWaitTime_Reason_Ext;
            entity.FSRule_SiteWaitTime_Reason = row.FSRule_SiteWaitTime_Reason_Ext;
            entity.FSRule_SplitLoad_Reason = row.FSRule_SplitLoad_Reason_Ext;
            entity.FSRule_SplitDrop_Reason = row.FSRule_SplitDrop_Reason_Ext;
            entity.FSRule_PumpOut_Reason = row.FSRule_PumpOut_Reason_Ext;
            entity.FSRule_Diversion_Reason = row.FSRule_Diversion_Reason_Ext;
            entity.FSRule_MinLoad_Reason = row.FSRule_MinLoad_Reason_Ext;
            entity.FSRule_Other_Reason = row.FSRule_Other_Reason_Ext;
            entity.QtyTolerance = row.QtyTolerance_Ext;
            entity.PercentTolerance = row.PercentTolerance_Ext;
            entity.OrderLoadReviewEnabled = row.OrderLoadReviewEnabled_Ext;
            entity.UndispatchRequest = row.UndispatchRequest_Ext;
            entity.Undispatched = row.Undispatched_Ext;
            entity.AssignedDriverID = string.IsNullOrEmpty(row.AssignedDriverID_Ext.ToString()) ? 0 : Convert.ToInt32(row.AssignedDriverID_Ext);
            entity.AssignedDriverName = row.AssignedDriverName_Ext;
            entity.AssignedVehicleCode = row.AssignedVehicleCode_Ext;

            return entity;
        }

        //2013.11.18 FSWW, Ramesh M Added For CR#60902... To Get warehouse loads
        /// <summary>
        /// Function to convert list of WarehouseLoadRow to list of Load class object
        /// </summary>
        /// <param name="rows">List of load row object</param>
        /// <returns>List of load class object</returns>
        public static List<WarehouseLoad> ToEntities(this List<DeliveryStreamCloudWCF.DataAccess.DAL.WarehouseLoadRow> rows)
        {
            List<WarehouseLoad> entities = new List<WarehouseLoad>();
            rows.ForEach(item => entities.Add(item.ToEntity()));
            return entities;
        }

        /// <summary>
        /// Function to convert BOL header row to BOL header class object
        /// </summary>
        /// <param name="row">BOL header row object</param>
        /// <returns>BOL header class object</returns>
        public static BolHdr ToEntity(this DeliveryStreamCloudWCF.DataAccess.DAL.Cloud_GetLoadBasedBOLDetailsRow row)
        {
            BolHdr entity = new BolHdr();
            entity.ID = row.Id_Ext;
            entity.LoadID = row.LoadID_Ext;
            entity.BOLNo = row.BolNo_Ext;
            entity.Image = row.Image_Ext;
            entity.datetime = row.BOLDateTime_Ext;
            entity.BOLWaitTime = row.BOLWaitTime_Ext;
            entity.BOLWaitTime_Comment = row.BOLWaitTime_Comment_Ext;
            entity.BOLWaitTime_Start = row.BOLWaitTime_Start_Ext;
            entity.BOLWaitTime_End = row.BOLWaitTime_End_Ext;
            entity.TrailerCode = row.TrailerCode_Ext;
            entity.SupplierCode = row.SupplierCode_Ext;
            entity.SupplyPointCode = row.SupplyPointCode_Ext;
            return entity;
        }

        /// <summary>
        /// Function to convert list of BOL header row to list of BOL header class object
        /// </summary>
        /// <param name="rows">List of BOL header row object</param>
        /// <returns>List of BOL header class object</returns>
        public static List<BolHdr> ToEntities(this List<DeliveryStreamCloudWCF.DataAccess.DAL.Cloud_GetLoadBasedBOLDetailsRow> rows)
        {
            List<BolHdr> entities = new List<BolHdr>();
            rows.ForEach(item => entities.Add(item.ToEntity()));
            return entities;
        }

        /// <summary>
        /// Function to convert BOL header row to BOL header class object
        /// </summary>
        /// <param name="row">BOL header row object</param>
        /// <returns>BOL header class object</returns>
        public static BolHdr ToEntity(this DeliveryStreamCloudWCF.DataAccess.DAL.BOLHdrRow row)
        {
            BolHdr entity = new BolHdr();
            entity.ID = row.Id_Ext;
            entity.LoadID = row.LoadID_Ext;
            entity.BOLNo = row.BolNo_Ext;
            entity.Image = row.Image_Ext;
            entity.datetime = row.BOLDateTime_Ext;
            entity.BOLWaitTime = row.BOLWaitTime_Ext;
            entity.BOLWaitTime_Comment = row.BOLWaitTime_Comment_Ext;
            entity.BOLWaitTime_Start = row.BOLWaitTime_Start_Ext;
            entity.BOLWaitTime_End = row.BOLWaitTime_End_Ext;
            entity.TrailerCode = row.TrailerCode_Ext;
            entity.SupplierCode = row.SupplierCode_Ext;
            entity.SupplyPointCode = row.SupplyPointCode_Ext;
            return entity;
        }

        /// <summary>
        /// Function to convert list of BOL header row to list of BOL header class object
        /// </summary>
        /// <param name="rows">List of BOL header row object</param>
        /// <returns>List of BOL header class object</returns>
        public static List<BolHdr> ToEntities(this List<DeliveryStreamCloudWCF.DataAccess.DAL.BOLHdrRow> rows)
        {
            List<BolHdr> entities = new List<BolHdr>();
            rows.ForEach(item => entities.Add(item.ToEntity()));
            return entities;
        }

        /// <summary>
        /// Function to convert BOL item row to BOL item class object
        /// </summary>
        /// <param name="row">BOL item row object</param>
        /// <returns>BOL item class object</returns>
        public static Bolitem ToEntity(this DeliveryStreamCloudWCF.DataAccess.DAL.BOLItemRow row)
        {
            Bolitem entity = new Bolitem();
            entity.ID = row.Id_Ext;
            entity.BOLHdrID = row.BOLHdrID_Ext;
            entity.SysTrxNo = row.SysTrxNo_Ext;
            entity.SysTrxLine = row.SysTrxLine_Ext;
            entity.ComponentNo = row.ComponentNo_Ext;
            entity.GrossQty = row.GrossQty_Ext;
            entity.NetQty = row.NetQty_Ext;
            //entity.BOLQtyVarianceReason = row.BOLQtyVarianceReason_Ext;
            return entity;
        }

        /// <summary>
        /// Function to convert list of BOL item row to list of BOL item class object
        /// </summary>
        /// <param name="rows">List of BOL item row object</param>
        /// <returns>List of BOL item class object</returns>
        public static List<Bolitem> ToEntities(this List<DeliveryStreamCloudWCF.DataAccess.DAL.BOLItemRow> rows)
        {
            List<Bolitem> entities = new List<Bolitem>();
            rows.ForEach(item => entities.Add(item.ToEntity()));
            return entities;
        }

        //
        public static SignatureImage ToEntity(this DeliveryStreamCloudWCF.DataAccess.DAL.SignatureImageRow row)
        {
            SignatureImage entity = new SignatureImage();
            entity.Status = row.SignatureStatus;
            entity.Image = row.SignatureImage;
            entity.DateTime = row.SignatureDateTime;
            return entity;
        }


        public static List<SignatureImage> ToEntities(this List<DeliveryStreamCloudWCF.DataAccess.DAL.SignatureImageRow> rows)
        {
            List<SignatureImage> entities = new List<SignatureImage>();
            rows.ForEach(item => entities.Add(item.ToEntity()));
            return entities;
        }

        //


        /// <summary>
        /// Function to convert DeliveryDetailsRow to DeliveryDetails class object
        /// </summary>
        /// <param name="row">Delivery details row object</param>
        /// <returns>Delivery details class object</returns>
        public static DeliveryDetails ToEntity(this DeliveryStreamCloudWCF.DataAccess.DAL.DeliveryDetailsRow row)
        {
            DeliveryDetails entity = new DeliveryDetails();
            entity.OrderItemID = row.OrderItemID_Ext;
            entity.GrossQty = row.GrossQty_Ext;
            entity.NetQtyQty = row.NetQty_Ext;
            entity.DeliveryDateTime = row.DeliveryDateTime_Ext;
            entity.BeforeVolume = row.BeforeVolume_Ext;
            entity.AfterVolume = row.AfterVolume_Ext;
            entity.BOLNo = row.BOLNo_Ext;
            entity.ID = row.ID_Ext;

            // entity.DeliveryQtyVarianceReason = row.DeliveryQtyVarianceReason_Ext;
            return entity;
        }

        /// <summary>
        /// Function to convert list of DeliveryDetailsRow to list of DeliveryDetails class object
        /// </summary>
        /// <param name="rows">List of delivery details row object</param>
        /// <returns>List of delivery details class object</returns>
        public static List<DeliveryDetails> ToEntities(this List<DeliveryStreamCloudWCF.DataAccess.DAL.DeliveryDetailsRow> rows)
        {
            List<DeliveryDetails> entities = new List<DeliveryDetails>();
            rows.ForEach(item => entities.Add(item.ToEntity()));
            return entities;
        }

        /// <summary>
        /// Function to convert DeliveryDetailsRow to DeliveryDetails class object
        /// </summary>
        /// <param name="row">Delivery details row object</param>
        /// <returns>Delivery details class object</returns>
        public static DeliveryDetails ToEntity(this DeliveryStreamCloudWCF.DataAccess.DAL.Cloud_GetDeliveryHistoryRow row)
        {
            DeliveryDetails entity = new DeliveryDetails();
            entity.OrderItemID = row.OrderItemID_Ext;
            entity.GrossQty = row.GrossQty_Ext;
            entity.NetQtyQty = row.NetQty_Ext;
            entity.DeliveryDateTime = row.DeliveryDateTime_Ext;
            entity.BeforeVolume = row.BeforeVolume_Ext;
            entity.AfterVolume = row.AfterVolume_Ext;
            entity.BOLNo = row.BOLNo_Ext;
            entity.ID = row.ID_Ext;

            // entity.DeliveryQtyVarianceReason = row.DeliveryQtyVarianceReason_Ext;
            return entity;
        }

        /// <summary>
        /// Function to convert list of DeliveryDetailsRow to list of DeliveryDetails class object
        /// </summary>
        /// <param name="rows">List of delivery details row object</param>
        /// <returns>List of delivery details class object</returns>
        public static List<DeliveryDetails> ToEntities(this List<DeliveryStreamCloudWCF.DataAccess.DAL.Cloud_GetDeliveryHistoryRow> rows)
        {
            List<DeliveryDetails> entities = new List<DeliveryDetails>();
            rows.ForEach(item => entities.Add(item.ToEntity()));
            return entities;
        }

        /// <summary>
        /// Function to convert DeliveryDetailsRow to DeliveryDetails class object
        /// </summary>
        /// <param name="row">Delivery details row object</param>
        /// <returns>Delivery details class object</returns>
        public static DeliveryDetailsData ToEntity(this DeliveryStreamCloudWCF.DataAccess.DAL.Cloud_GetDeliveryDataRow row)
        {
            DeliveryDetailsData entity = new DeliveryDetailsData();
            entity.GrossQty = row.GrossQty_Ext;
            entity.NetQtyQty = row.NetQty_Ext;
            entity.BeforeVolume = row.BeforeVolume_Ext;
            entity.AfterVolume = row.AfterVolume_Ext;
            entity.BOLNo = row.BOLNo_Ext;

            // entity.DeliveryQtyVarianceReason = row.DeliveryQtyVarianceReason_Ext;
            return entity;
        }

        /// <summary>
        /// Function to convert list of DeliveryDetailsRow to list of DeliveryDetails class object
        /// </summary>
        /// <param name="rows">List of delivery details row object</param>
        /// <returns>List of delivery details class object</returns>
        public static List<DeliveryDetailsData> ToEntities(this List<DeliveryStreamCloudWCF.DataAccess.DAL.Cloud_GetDeliveryDataRow> rows)
        {
            List<DeliveryDetailsData> entities = new List<DeliveryDetailsData>();
            rows.ForEach(item => entities.Add(item.ToEntity()));
            return entities;
        }



        public static OrderFrt ToEntity(this DeliveryStreamCloudWCF.DataAccess.DAL.OrderFrtRow row)
        {
            OrderFrt entity = new OrderFrt();
            entity.OrderID = row.OrderID_Ext;
            entity.SiteWaitTime = row.SiteWaitTime_Ext;
            entity.SiteWaitTime_Comment = row.SiteWaitTime_Comment_Ext;
            entity.SiteWaitTime_Start = row.SiteWaitTime_Start_Ext;
            entity.SiteWaitTime_End = row.SiteWaitTime_End_Ext;
            entity.SplitLoad = row.SplitLoad_Ext;
            entity.SplitLoad_Comment = row.SplitLoad_Comment_Ext;
            entity.SplitDrop = row.SplitDrop_Ext;
            entity.SplitDrop_Comment = row.SplitDrop_Comment_Ext;
            entity.PumpOut = row.PumpOut_Ext;
            entity.PumpOut_Comment = row.PumpOut_Comment_Ext;
            entity.Diversion = row.Diversion_Ext;
            entity.Diversion_Comment = row.Diversion_Comment_Ext;
            entity.MinimumLoad = row.MinimumLoad_Ext;
            entity.MinimumLoad_Comment = row.MinimumLoad_Comment_Ext;
            entity.Other = row.Other_Ext;
            entity.Other_Comment = row.Other_Comment_Ext;

            return entity;
        }

        public static List<OrderFrt> ToEntities(this List<DeliveryStreamCloudWCF.DataAccess.DAL.OrderFrtRow> rows)
        {
            List<OrderFrt> entities = new List<OrderFrt>();
            rows.ForEach(item => entities.Add(item.ToEntity()));
            return entities;
        }



        /// <summary>
        /// Function to convert LoadStatusHistoryRow to LoadStatusHistory class object
        /// </summary>
        /// <param name="row">Load status history row object</param>
        /// <returns>Load status history class object</returns>
        public static LoadStatusHistory ToEntity(this DeliveryStreamCloudWCF.DataAccess.DAL.LoadStatusHistoryRow row)
        {
            LoadStatusHistory entity = new LoadStatusHistory();
            entity.LoadID = row.LoadID_Ext;
            entity.LoadStatusID = row.LoadStatusID_Ext;
            entity.UpdatedBy = row.UpdatedBy_Ext;
            entity.Longitude = row.Longitude_Ext;
            entity.Latitude = row.Latitude_Ext;
            entity.City = row.IsCityNull() ? string.Empty : row.City_Ext;
            entity.State = row.IsstateNull() ? string.Empty : row.State_Ext;
            entity.NeedUpdate = row.NeedUpdate_Ext;
            entity.DateTime = row.DateTime_Ext;
            return entity;
        }

        /// <summary>
        /// Function to convert list of LoadStatusHistoryRow to list of LoadStatusHistory class object
        /// </summary>
        /// <param name="rows">List of load status history row object</param>
        /// <returns>List of load status history class object</returns>
        public static List<LoadStatusHistory> ToEntities(this List<DeliveryStreamCloudWCF.DataAccess.DAL.LoadStatusHistoryRow> rows)
        {
            List<LoadStatusHistory> entities = new List<LoadStatusHistory>();
            rows.ForEach(item => entities.Add(item.ToEntity()));
            return entities;
        }

        /// <summary>
        /// Function to convert OrderStatusHistoryRow to OrderStatusHistory class object
        /// </summary>
        /// <param name="row">Order status history row object</param>
        /// <returns>Order status history class object</returns>
        public static OrderStatusHistory ToEntity(this DeliveryStreamCloudWCF.DataAccess.DAL.OrderStatusHistoryRow row)
        {
            OrderStatusHistory entity = new OrderStatusHistory();
            entity.OrderID = row.OrderID_Ext;
            entity.OrderStatusID = row.OrderStatusID_Ext;
            entity.UpdatedBy = row.UpdatedBy_Ext;
            entity.Longitude = row.Longitude_Ext;
            entity.Latitude = row.Latitude_Ext;
            entity.NeedUpdate = row.NeedUpdate_Ext;
            entity.DateTime = row.DateTime_Ext;
            return entity;
        }

        /// <summary>
        /// Function to convert list of OrderStatusHistoryRow to list of OrderStatusHistory class object
        /// </summary>
        /// <param name="rows">List of order status history row object</param>
        /// <returns>List of order status history class object</returns>
        public static List<OrderStatusHistory> ToEntities(this List<DeliveryStreamCloudWCF.DataAccess.DAL.OrderStatusHistoryRow> rows)
        {
            List<OrderStatusHistory> entities = new List<OrderStatusHistory>();
            rows.ForEach(item => entities.Add(item.ToEntity()));
            return entities;
        }

        /// <summary>
        /// Function to convert CustomerRow to Customer class object
        /// </summary>
        /// <param name="row">Customer row object</param>
        /// <returns>Customer class object</returns>
        public static Customer ToEntity(this DeliveryStreamCloudWCF.DataAccess.DAL.CustomerRow row)
        {
            Customer entity = new Customer();
            entity.CustomerID = row.CustomerID_Ext;
            entity.Name = row.Name_Ext;
            entity.Description = row.Description_Ext;
            entity.Password = row.Password_Ext;
            entity.WCFUrl = row.WCFURL_Ext;
            return entity;
        }

        /// <summary>
        /// Function to convert list of CustomerRow to list of Customer class object
        /// </summary>
        /// <param name="rows">List of customer row object</param>
        /// <returns>List of customer class object</returns>
        public static List<Customer> ToEntities(this List<DeliveryStreamCloudWCF.DataAccess.DAL.CustomerRow> rows)
        {
            List<Customer> entities = new List<Customer>();
            rows.ForEach(item => entities.Add(item.ToEntity()));
            return entities;
        }

        /// <summary>
        /// Function to convert GPSHistoryRow to GPSHistory class object
        /// </summary>
        /// <param name="row">GPS history row object</param>
        /// <returns>GPS history class object</returns>
        public static GPSHistory ToEntity(this DeliveryStreamCloudWCF.DataAccess.DAL.GPSHistoryRow row)
        {
            GPSHistory entity = new GPSHistory();
            entity.Longitude = row.Longitude_Ext;
            entity.Latitude = row.Latitude_Ext;
            entity.Dttm = row.Dttm_Ext;
            entity.DeviceTime = row.DeviceTime_Ext;
            entity.SessionID = row.SessionID_Ext;
            entity.State = row.State_Ext;
            entity.GMT = row.GMT_Ext;
            entity.GpsStrength = row.GpsStrength_Ext;
            entity.Status = row.Status_Ext;

            return entity;
        }

        /// <summary>
        /// Function to convert list of GPSHistoryRow to list of GPSHistory class object
        /// </summary>
        /// <param name="rows">List of GPS history row object</param>
        /// <returns>List of GPS history class object</returns>
        public static List<GPSHistory> ToEntities(this List<DeliveryStreamCloudWCF.DataAccess.DAL.GPSHistoryRow> rows)
        {
            List<GPSHistory> entities = new List<GPSHistory>();
            rows.ForEach(item => entities.Add(item.ToEntity()));
            return entities;
        }

        /// <summary>
        /// Function to convert LoginUserRow to LoginUser class object
        /// </summary>
        /// <param name="row">Login user row object</param>
        /// <returns>Login user class object</returns>
        public static LoginUser ToEntity(this DeliveryStreamCloudWCF.DataAccess.DAL.LoginUserRow row)
        {
            LoginUser entity = new LoginUser();
            entity.ID = row.ID_Ext;
            entity.UserName = row.UserName_Ext;
            entity.CustomerID = row.CustomerID_Ext;
            entity.DriverID = row.DriverID_Ext;
            entity.FirstName = row.FirstName_Ext;
            entity.MiddleName = row.MiddleName_Ext;
            entity.LastName = row.LastName_Ext;
            entity.Email = row.Email_Ext;
            entity.Password = row.Password_Ext;
            entity.UserType = row.UserType_Ext;
            return entity;
        }

        /// <summary>
        /// Function to convert list of LoginUserRow to list of LoginUser class object
        /// </summary>
        /// <param name="rows">List of login user row object</param>
        /// <returns>List of login user class object</returns>
        public static List<LoginUser> ToEntities(this List<DeliveryStreamCloudWCF.DataAccess.DAL.LoginUserRow> rows)
        {
            List<LoginUser> entities = new List<LoginUser>();
            rows.ForEach(item => entities.Add(item.ToEntity()));
            return entities;
        }



        // 2014.03.17  Ramesh M Added For CR#62613 to get home terminal details
        public static LoginHomeTerminalDetails ToEntity(this DeliveryStreamCloudWCF.DataAccess.DAL.LoginHomeTerminalDetailsRow row)
        {
            LoginHomeTerminalDetails entity = new LoginHomeTerminalDetails();
            entity.ID = row.ID_Ext;
            entity.CustomerID = row.CustomerID_Ext;
            entity.FirstName = row.FirstName_Ext;
            entity.LastName = row.LastName_Ext;
            entity.UserType = row.UserType_Ext;
            entity.Co_Name = row.Co_Name_Ext;
            entity.Co_Addr1 = row.Co_Addr1_Ext;
            entity.Co_City = row.Co_City_Ext;
            entity.Co_State = row.Co_State_Ext;
            entity.Co_Zip = row.Co_Zip_Ext;
            entity.HT_Descr = row.HT_Descr_Ext;
            entity.HT_Addr1 = row.HT_Addr1_Ext;
            entity.HT_City = row.HT_City_Ext;
            entity.HT_State = row.HT_State_Ext;
            entity.HT_Zip = row.HT_Zip_Ext;
            entity.HazMatDate = row.HazMatDate_Ext;
            return entity;
        }

        public static List<LoginHomeTerminalDetails> ToEntities(this List<DeliveryStreamCloudWCF.DataAccess.DAL.LoginHomeTerminalDetailsRow> rows)
        {
            List<LoginHomeTerminalDetails> entities = new List<LoginHomeTerminalDetails>();
            rows.ForEach(item => entities.Add(item.ToEntity()));
            return entities;
        }

        // 06-26-2014  MadhuVenkat k - Added for CR 64058  - For Add orderDispatchHistory 
        /// <summary>
        /// Function to convert OrderDispatchHistoryRow to OrderDispatchHistory class object
        /// </summary>
        /// <param name="row">OrderDispatchHistory row object</param>
        /// <returns>OrderDispatchHistory class object</returns>
        public static OrderDispatchHistory ToEntity(this DeliveryStreamCloudWCF.DataAccess.DAL.OrderDispatchHistoryRow row)
        {
            OrderDispatchHistory entity = new OrderDispatchHistory();

            entity.CustomerID = row.CustomerID_Ext;
            entity.SysTrxNo = row.SysTrxNo_Ext;
            entity.DefDriverID = row.DefDriverID_Ext;
            entity.DefVehicleID = row.DefVehicleID_Ext;
            entity.OldDriverID = row.OldDriverID_Ext;
            entity.OldVehicleID = row.OldVehicleID_Ext;

            return entity;
        }
        // 06-26-2014  MadhuVenkat k - Added for CR 64058  - For Add orderDispatchHistory 
        public static List<OrderDispatchHistory> ToEntities(this List<DeliveryStreamCloudWCF.DataAccess.DAL.OrderDispatchHistoryRow> rows)
        {
            List<OrderDispatchHistory> entities = new List<OrderDispatchHistory>();
            rows.ForEach(item => entities.Add(item.ToEntity()));
            return entities;
        }
        /// <summary>
        /// Function to convert InspectionRow to Inspection class object
        /// </summary>
        /// <param name="row">Inspection row object</param>
        /// <returns>Inspection class object</returns>
        public static Inspection ToEntity(this DeliveryStreamCloudWCF.DataAccess.DAL.InspectionRow row)
        {
            Inspection entity = new Inspection();
            entity.SessionID = row.SessionID_Ext;
            entity.PreDuty_Inspection = row.PreDuty_Inspection_Ext;
            entity.PreDuty_InspectionDateTime = row.PreDuty_InspectionDateTime_Ext;
            entity.PreDutyViolation = row.PreDutyViolation_Ext;
            entity.PostDuty_Inspection = row.PostDuty_Inspection_Ext;
            entity.PostDuty_InspectionDateTime = row.PostDuty_InspectionDateTime_Ext;
            entity.PostDutyViolation = row.PostDutyViolation_Ext;

            return entity;
        }

        /// <summary>
        /// Function to convert list of InspectionRow to list of Inspection class object
        /// </summary>
        /// <param name="rows">List of Inspection row object</param>
        /// <returns>List of Inspection class object</returns>
        public static List<Inspection> ToEntities(this List<DeliveryStreamCloudWCF.DataAccess.DAL.InspectionRow> rows)
        {
            List<Inspection> entities = new List<Inspection>();
            rows.ForEach(item => entities.Add(item.ToEntity()));
            return entities;
        }

        /// <summary>
        /// Function to convert AdverseConditionRow to AdverseCondition class object
        /// </summary>
        /// <param name="row">AdverseCondition row object</param>
        /// <returns>AdverseCondition class object</returns>
        public static AdverseCondition ToEntity(this DeliveryStreamCloudWCF.DataAccess.DAL.AdverseConditionRow row)
        {
            AdverseCondition entity = new AdverseCondition();
            entity.SessionID = row.SessionID_Ext;
            entity.Adverse_Condition = row.Adverse_Condition_Ext;
            entity.AdverseConditionDateTime = row.AdverseConditionDateTime_Ext;
            entity.AdverseConditionReason = row.AdverseConditionReason_Ext;
            return entity;
        }

        /// <summary>
        /// Function to convert list of AdverseConditionRow to list of AdverseCondition class object
        /// </summary>
        /// <param name="rows">List of AdverseCondition row object</param>
        /// <returns>List of AdverseCondition class object</returns>
        public static List<AdverseCondition> ToEntities(this List<DeliveryStreamCloudWCF.DataAccess.DAL.AdverseConditionRow> rows)
        {
            List<AdverseCondition> entities = new List<AdverseCondition>();
            rows.ForEach(item => entities.Add(item.ToEntity()));
            return entities;
        }

        /// <summary>
        /// Function to convert SleeperRigRow to SleeperRig class object
        /// </summary>
        /// <param name="row">SleeperRig row object</param>
        /// <returns>SleeperRig class object</returns>
        public static SleeperRig ToEntity(this DeliveryStreamCloudWCF.DataAccess.DAL.SleeperRigRow row)
        {
            SleeperRig entity = new SleeperRig();
            entity.SessionID = row.SessionID_Ext;
            entity.SleeperRigID = row.SleeperRigID_Ext;
            entity.StartTime = row.StartTime_Ext;
            entity.EndTime = row.EndTime_Ext;
            return entity;
        }

        /// <summary>
        /// Function to convert list of SleeperRigRow to list of SleeperRig class object
        /// </summary>
        /// <param name="rows">List of SleeperRig row object</param>
        /// <returns>List of SleeperRig class object</returns>
        public static List<SleeperRig> ToEntities(this List<DeliveryStreamCloudWCF.DataAccess.DAL.SleeperRigRow> rows)
        {
            List<SleeperRig> entities = new List<SleeperRig>();
            rows.ForEach(item => entities.Add(item.ToEntity()));
            return entities;
        }

        /// <summary>
        /// Function to convert list of Cloud_DriverSummaryRow to list of DriverSummary class object
        /// </summary>
        /// <param name="rows">List of Cloud_DriverSummary row object</param>
        /// <returns>List of DriverSummary class object</returns>
        public static List<DriverSummary> ToEntities(this List<DeliveryStreamCloudWCF.DataAccess.DAL.DriverSummaryRow> rows)
        {
            List<DriverSummary> entities = new List<DriverSummary>();
            rows.ForEach(item => entities.Add(item.ToEntity()));
            return entities;
        }


        // 05-14-2014 MadhuVenkat K - Added for CR 63396 - Add Time Remaining Section to Driver Summary
        // 08-25-2014 MadhuVenkat K - Added for CR 64760 - Add InspectionVersion to Driver Summary
        /// <summary>
        /// Function to convert list of TimeRemainingDriverSummaryRow to list of DriverSummary class object
        /// </summary>
        /// <param name="rows">List of TimeRemainingDriverSummaryRow row object</param>
        /// <returns>List of RemainingTimeSummary class object</returns>
        public static List<RemainingTimeSummary> ToEntities(this List<DeliveryStreamCloudWCF.DataAccess.DAL.TimeRemainingDriverSummaryRow> rows)
        {
            List<RemainingTimeSummary> entities = new List<RemainingTimeSummary>();
            rows.ForEach(item => entities.Add(item.ToEntity()));

            return entities;
        }
        /// <summary>
        /// Function to convert TimeRemainingDriverSummaryRow to DriverSummary class object
        /// </summary>
        /// <param name="row">TimeRemainingDriverSummaryRow   object</param>
        /// <returns>RemainingTimeSummary class object</returns>
        public static RemainingTimeSummary ToEntity(this DeliveryStreamCloudWCF.DataAccess.DAL.TimeRemainingDriverSummaryRow row)
        {
            RemainingTimeSummary entity = new RemainingTimeSummary();
            if (row != null)
            {
                entity.ID = row.ID_Ext;
                entity.LastOffDuty = row.LastOffDuty_Ext;
                entity.LastDriving = row.LastDriving_Ext;
                entity.LastOnDuty = row.LastOnDuty_Ext;
                entity.LastSleeper = row.LastSleeper_Ext;
                entity.RemainingBreak = row.RemainingBreak_Ext;
                entity.RemainingDrivingDuty = row.RemainingDrivingDuty_Ext;
                entity.RemainingLastweek = row.RemainingLastweek_Ext;
                entity.RemainingOnDuty = row.RemainingOnDuty_Ext;
                entity.CurrentDriving = row.CurrentDriving_Ext;
                entity.CurrentOffDuty = row.CurrentOffDuty_Ext;
                entity.CurrentOnDuty = row.CurrentOnDuty_Ext;
                entity.CurrentSleeper = row.CurrentSleeper_Ext;
                entity.LastOnDuty = row.LastOnDuty_Ext;
                entity.CurrentDriverStatus = row.CurrentDriverStatus_Ext;
                entity.IsSessionExists = row.IsSessionExists_Ext;
                // entity.InspectionVersion = row.InspectionVersion_Ext;

            }
            return entity;
        }


        /// <summary>
        /// Function to convert Cloud_DriverSummaryRow to DriverSummary class object
        /// </summary>
        /// <param name="row">DriverSummary row object</param>
        /// <returns>DriverSummary class object</returns>
        public static DriverSummary ToEntity(this DeliveryStreamCloudWCF.DataAccess.DAL.DriverSummaryRow row)
        {
            DriverSummary entity = new DriverSummary();
            if (row != null)
            {
                entity.SessionID = row.SessionID_Ext;
                entity.StartTime = row.StartTime_Ext;
                entity.EndTime = row.EndTime_Ext;
                entity.CurrentLoginID = row.CurrentLoginID_Ext;
                entity.DriverState = row.DriverState_Ext;
                // 2014.02.20  Ramesh M Added For CR#62292 For driver summary log
                entity.IsOverride = row.IsOverride_Ext;
                //entity.ThirtyFourHourReset = row.ThirtyFourHourReset_Ext;
            }
            return entity;
        }

        /// <summary>
        /// Function to convert list of Cloud_DriverSummaryRow to list of DriverSummary class object
        /// </summary>
        /// <param name="rows">List of Cloud_DriverSummary row object</param>
        /// <returns>List of DriverSummary class object</returns>
        public static List<DriverLogs> ToEntities(this List<DeliveryStreamCloudWCF.DataAccess.DAL.GetDriverLogsRow> rows)
        {
            List<DriverLogs> entities = new List<DriverLogs>();
            rows.ForEach(item => entities.Add(item.ToEntity()));
            return entities;
        }

        /// <summary>
        /// Function to convert Cloud_DriverSummaryRow to DriverSummary class object
        /// </summary>
        /// <param name="row">DriverSummary row object</param>
        /// <returns>DriverSummary class object</returns>
        public static DriverLogs ToEntity(this DeliveryStreamCloudWCF.DataAccess.DAL.GetDriverLogsRow row)
        {
            DriverLogs entity = new DriverLogs();
            if (row != null)
            {
                entity.CurrentOnDuty = row.CurrentOnDuty_Ext;
                entity.CurrentOffDuty = row.CurrentOffDuty_Ext;
                entity.CurrentDriving = row.CurrentDriving_Ext;
                entity.CurrentSleeping = row.CurrentSleeping_Ext;
                entity.LastOnDuty = row.LastOnDuty_Ext;
                entity.LastOffDuty = row.LastOffDuty_Ext;
                entity.LastDriving = row.LastDriving_Ext;
                entity.LastSleeping = row.LastSleeping_Ext;
            }
            return entity;
        }
        /// <summary>
        /// Function to convert Cloud_OrderPickingDetailsRow to OrderPickingDetails class object
        /// </summary>
        /// <param name="rows"></param>
        /// <returns></returns>
        public static List<OrderPickingDetails> ToEntities(this List<DeliveryStreamCloudWCF.DataAccess.DAL.OrderPickingDetailsRow> rows)
        {
            List<OrderPickingDetails> entities = new List<OrderPickingDetails>();
            rows.ForEach(item => entities.Add(item.ToEntity()));
            return entities;
        }
        /// <summary>
        ///  Function to convert Cloud_OrderPickingDetailsRow to OrderPickingDetails class object
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public static OrderPickingDetails ToEntity(this DeliveryStreamCloudWCF.DataAccess.DAL.OrderPickingDetailsRow row)
        {
            OrderPickingDetails entity = new OrderPickingDetails();
            if (row != null)
            {
                entity.OrderNo = row.OrderNo_Ext;
                entity.LoadNo = row.LoadNo_Ext;
                entity.OrderItemID = row.OrderItemID_Ext;
                entity.PickedBy = row.PickedBy_Ext;
                entity.CustomerID = row.CustomerID_Ext;
                entity.Status = row.Status_Ext;
            }
            return entity;
        }

        public static List<GetDriverDetails> ToEntities(this List<DeliveryStreamCloudWCF.DataAccess.DAL.GetDriverDetailsRow> rows)
        {
            List<GetDriverDetails> entities = new List<GetDriverDetails>();
            rows.ForEach(item => entities.Add(item.ToEntity()));
            return entities;
        }

        public static GetDriverDetails ToEntity(this DeliveryStreamCloudWCF.DataAccess.DAL.GetDriverDetailsRow row)
        {
            GetDriverDetails entity = new GetDriverDetails();
            if (row != null)
            {
                entity.LoginID = row.LoginID_Ext;
                entity.FullName = row.FullName_Ext;

            }
            return entity;
        }
        // 2014.02.20  Ramesh M Added For CR#62301 For Driver status Screen in Ipad
        // 2014.02.25  Ramesh M Added For CR#62292 For modified driver summary log
        public static DriverLogStatus ToEntity(this DeliveryStreamCloudWCF.DataAccess.DAL.DriverLogStatusRow row)
        {
            DriverLogStatus entity = new DriverLogStatus();
            entity.StartTime = row.StartTime_Ext;
            entity.EndTime = row.EndTime_Ext;
            entity.CurrentLoginID = row.CurrentLoginID_Ext;
            entity.SessionID = row.SessionID_Ext;
            entity.DriverState = row.DriverState_Ext;
            entity.Location = row.Location_Ext;
            entity.EventDetail = row.EventDetail_Ext;

            return entity;
        }
        public static List<DriverLogStatus> ToEntities(this List<DeliveryStreamCloudWCF.DataAccess.DAL.DriverLogStatusRow> rows)
        {
            List<DriverLogStatus> entities = new List<DriverLogStatus>();
            rows.ForEach(item => entities.Add(item.ToEntity()));
            return entities;
        }

        public static List<GetVehicleDetails> ToEntities(this List<DeliveryStreamCloudWCF.DataAccess.DAL.GetVehicleDetailsRow> rows)
        {
            List<GetVehicleDetails> entities = new List<GetVehicleDetails>();
            rows.ForEach(item => entities.Add(item.ToEntity()));
            return entities;
        }
        public static GetVehicleDetails ToEntity(this DeliveryStreamCloudWCF.DataAccess.DAL.GetVehicleDetailsRow row)
        {
            GetVehicleDetails entity = new GetVehicleDetails();
            if (row != null)
            {
                entity.VehicleID = row.VehicleID_Ext;
                entity.VehicleCode = row.VehicleCode_Ext;

            }
            return entity;
        }

        public static List<InspectionElements> ToEntities(this List<DeliveryStreamCloudWCF.DataAccess.DAL.InspectionElementsRow> rows)
        {
            List<InspectionElements> entities = new List<InspectionElements>();
            rows.ForEach(item => entities.Add(item.ToEntity()));
            return entities;
        }
        // 09-09-2014  CR#64208, Madhu, Add Modified date to GetInspectionElementsData
        public static InspectionElements ToEntity(this DeliveryStreamCloudWCF.DataAccess.DAL.InspectionElementsRow row)
        {
            InspectionElements entity = new InspectionElements();
            if (row != null)
            {
                entity.SequenceID = row.SequenceID_Ext;
                entity.Description = row.Description_Ext;
                entity.Modifieddate = row.Modifieddate_Ext;

            }
            return entity;
        }

        public static List<SupplierSupplypointList> ToEntities(this List<DeliveryStreamCloudWCF.DataAccess.DAL.SupplierSupplypointListRow> rows)
        {
            List<SupplierSupplypointList> entities = new List<SupplierSupplypointList>();
            rows.ForEach(item => entities.Add(item.ToEntity()));
            return entities;
        }
        public static SupplierSupplypointList ToEntity(this DeliveryStreamCloudWCF.DataAccess.DAL.SupplierSupplypointListRow row)
        {
            SupplierSupplypointList entity = new SupplierSupplypointList();
            if (row != null)
            {
                entity.SupplierSupplyPtID = row.SupplierSupplyPtID_Ext;
                entity.SupplierSupplyPt = row.SupplierSupplyPt_Ext;
                entity.ShipToID = row.ShipToID_Ext;

            }
            return entity;
        }

        // 2014.03.18  Ramesh M Added For CR#62322 added  Version testing method
        public static VersionTest ToEntity(this DeliveryStreamCloudWCF.DataAccess.DAL.VersionTestRow row, String VersionNo = "")
        {
            VersionTest entity = new VersionTest();
            entity.LoginID = row.LoginID_Ext;
            entity.SessionID = row.SessionID_Ext;
            if (VersionNo == "1.29")
            {
                entity.LogoffTime = row.LogoffTime_Ext;
            }

            return entity;
        }
        public static List<VersionTest> ToEntities(this List<DeliveryStreamCloudWCF.DataAccess.DAL.VersionTestRow> rows, String VersionNo = "")
        {
            List<VersionTest> entities = new List<VersionTest>();
            rows.ForEach(item => entities.Add(item.ToEntity(VersionNo)));
            return entities;
        }


        #region TankWagon

        /// <summary>
        /// Function to convert InspectionRow to Inspection class object
        /// </summary>
        /// <param name="row">Inspection row object</param>
        /// <returns>Inspection class object</returns>
        public static VehicleCompartment ToEntity(this DeliveryStreamCloudWCF.DataAccess.DAL.VehicleCompartmentRow row)
        {
            VehicleCompartment entity = new VehicleCompartment();
            entity.CustomerID = row.CustomerID_Ext;
            entity.CompartmentID = row.CompartmentID_Ext;
            entity.VehicleID = row.VehicleID_Ext;
            entity.Code = row.Code_Ext;
            entity.Capacity = row.Capacity_Ext;
            entity.NeedUpdate = row.NeedUpdate_Ext;
            //int UpdatedBy = 317;
            //ve.BolCompartment = DALMethods.GetBolCompartment(UpdatedBy, session, VersionNo);
            //lstVehicleCompartmentDetails.Add(ve);
            return entity;
        }

        /// <summary>
        /// Function to convert list of InspectionRow to list of Inspection class object
        /// </summary>
        /// <param name="rows">List of Inspection row object</param>
        /// <returns>List of Inspection class object</returns>
        public static List<VehicleCompartment> ToEntities(this List<DeliveryStreamCloudWCF.DataAccess.DAL.VehicleCompartmentRow> rows)
        {
            List<VehicleCompartment> entities = new List<VehicleCompartment>();
            rows.ForEach(item => entities.Add(item.ToEntity()));

            return entities;
        }


        /// <summary>
        /// Function to convert InspectionRow to Inspection class object
        /// </summary>
        /// <param name="row">Inspection row object</param>
        /// <returns>Inspection class object</returns>
        public static VehicleCompartment ToEntity(this DeliveryStreamCloudWCF.DataAccess.DAL.Cloud_GetCompartmentDetailsCountRow row)
        {
            VehicleCompartment entity = new VehicleCompartment();
            entity.CustomerID = row.CustomerID_Ext;
            entity.CompartmentID = row.CompartmentID_Ext;
            entity.VehicleID = row.VehicleID_Ext;
            entity.Code = row.Code_Ext;
            entity.Capacity = row.Capacity_Ext;
            //int UpdatedBy = 317;
            //ve.BolCompartment = DALMethods.GetBolCompartment(UpdatedBy, session, VersionNo);
            //lstVehicleCompartmentDetails.Add(ve);
            return entity;
        }

        /// <summary>
        /// Function to convert list of InspectionRow to list of Inspection class object
        /// </summary>
        /// <param name="rows">List of Inspection row object</param>
        /// <returns>List of Inspection class object</returns>
        public static List<VehicleCompartment> ToEntities(this List<DeliveryStreamCloudWCF.DataAccess.DAL.Cloud_GetCompartmentDetailsCountRow> rows)
        {
            List<VehicleCompartment> entities = new List<VehicleCompartment>();
            rows.ForEach(item => entities.Add(item.ToEntity()));

            return entities;
        }


        /// <summary>
        /// Function to convert InspectionRow to Inspection class object
        /// </summary>
        /// <param name="row">Inspection row object</param>
        /// <returns>Inspection class object</returns>
        public static BolitemWagon ToEntity(this DeliveryStreamCloudWCF.DataAccess.DAL.BOLItem_WagonRow row)
        {
            BolitemWagon entity = new BolitemWagon();
            entity.ID = row.ID_Ext;
            entity.BOLHdrID = row.BOLHdrID_Ext;
            entity.SystrxNo = row.SystrxLine_Ext;
            entity.SystrxLine = row.SystrxLine_Ext;
            entity.CompartmentID = row.CompartmentID_Ext;
            entity.ProdCode = row.ProdCode_Ext;
            entity.GrossQty = Convert.ToInt32(row.GrossQty_Ext);
            entity.NetQty = Convert.ToInt32(row.NetQty_Ext);
            entity.OrderedQty = Convert.ToInt32(row.OrderedQty_Ext);
            entity.Notes = row.Notes_Ext;


            return entity;
        }

        /// <summary>
        /// Function to convert list of InspectionRow to list of Inspection class object
        /// </summary>
        /// <param name="rows">List of Inspection row object</param>
        /// <returns>List of Inspection class object</returns>
        public static List<BolitemWagon> ToEntities(this List<DeliveryStreamCloudWCF.DataAccess.DAL.BOLItem_WagonRow> rows)
        {
            List<BolitemWagon> entities = new List<BolitemWagon>();
            rows.ForEach(item => entities.Add(item.ToEntity()));
            return entities;
        }


        /// <summary>
        /// Function to convert InspectionRow to Inspection class object
        /// </summary>
        /// <param name="row">Inspection row object</param>
        /// <returns>Inspection class object</returns>
        public static BOLCompartments ToEntity(this DeliveryStreamCloudWCF.DataAccess.DAL.Cloud_GetBOLCompartmentDetailsRow row)
        {
            BOLCompartments entity = new BOLCompartments();
            entity.BOLNo = row.BOLNo_Ext;
            entity.GrossQty = row.GrossQty_Ext;
            entity.ProdCode = row.ProdCode_Ext;
            entity.CompartmentID = row.CompartmentID_Ext;
            entity.SystrxNo = row.SystrxNo_Ext;
            entity.SystrxLine = row.SystrxLine_Ext;
            entity.SupplierCode = row.SupplierCode_Ext;
            entity.SupplyPointCode = row.SupplyPointCode_Ext;
            entity.OrderedQty = row.OrderedQty_Ext;
            entity.NetQty = row.NetQty_Ext;
            entity.AvailbleQty = row.AvailableQty_Ext;
            entity.BOLHdrID = row.BOLHdrID_Ext;
            entity.BOLItemID = row.BOLItemID_Ext;
            entity.BOLDatetime = row.BOLDatetime_Ext;
            entity.Notes = row.Notes_Ext;

            return entity;
        }

        /// <summary>
        /// Function to convert list of InspectionRow to list of Inspection class object
        /// </summary>
        /// <param name="rows">List of Inspection row object</param>
        /// <returns>List of Inspection class object</returns>
        public static List<BOLCompartments> ToEntities(this List<DeliveryStreamCloudWCF.DataAccess.DAL.Cloud_GetBOLCompartmentDetailsRow> rows)
        {
            List<BOLCompartments> entities = new List<BOLCompartments>();
            rows.ForEach(item => entities.Add(item.ToEntity()));
            return entities;
        }



        /// <summary>
        /// Function to convert InspectionRow to Inspection class object
        /// </summary>
        /// <param name="row">Inspection row object</param>
        /// <returns>Inspection class object</returns>
        public static BOLCompartments ToEntity(this DeliveryStreamCloudWCF.DataAccess.DAL.Cloud_TW_GetProductCompartmentRow row)
        {
            BOLCompartments entity = new BOLCompartments();
            entity.CompartmentID = row.CompartmentID_Ext;
            entity.AvailbleQty = row.AvailbleQty_Ext;
            entity.ProdCode = row.ProdCode_Ext;
            entity.CompartmentCode = row.CompartmentCode_Ext;
            return entity;
        }

        /// <summary>
        /// Function to convert list of InspectionRow to list of Inspection class object
        /// </summary>
        /// <param name="rows">List of Inspection row object</param>
        /// <returns>List of Inspection class object</returns>
        public static List<BOLCompartments> ToEntities(this List<DeliveryStreamCloudWCF.DataAccess.DAL.Cloud_TW_GetProductCompartmentRow> rows)
        {
            List<BOLCompartments> entities = new List<BOLCompartments>();
            rows.ForEach(item => entities.Add(item.ToEntity()));
            return entities;
        }



        /// <summary>
        /// Function to convert InspectionRow to Inspection class object
        /// </summary>
        /// <param name="row">Inspection row object</param>
        /// <returns>Inspection class object</returns>
        public static Supplier ToEntity(this DeliveryStreamCloudWCF.DataAccess.DAL.TW_GetSuppliersRow row)
        {
            Supplier entity = new Supplier();
            entity.SupplierID = row.SupplierID_Ext;
            entity.Code = row.Code_Ext;
            entity.CompanyID = row.CompanyID_Ext;
            entity.Descr = row.Descr_Ext;
            entity.LastModifiedDtTm = row.LastModifiedDtTm_Ext;

            return entity;
        }

        /// <summary>
        /// Function to convert list of InspectionRow to list of Inspection class object
        /// </summary>
        /// <param name="rows">List of Inspection row object</param>
        /// <returns>List of Inspection class object</returns>
        public static List<Supplier> ToEntities(this List<DeliveryStreamCloudWCF.DataAccess.DAL.TW_GetSuppliersRow> rows)
        {
            List<Supplier> entities = new List<Supplier>();
            rows.ForEach(item => entities.Add(item.ToEntity()));
            return entities;
        }



        /// <summary>
        /// Function to convert InspectionRow to Inspection class object
        /// </summary>
        /// <param name="row">Inspection row object</param>
        /// <returns>Inspection class object</returns>
        public static SupplierSupplyPt ToEntity(this DeliveryStreamCloudWCF.DataAccess.DAL.TW_GetSupplierSupplyPtRow row)
        {
            SupplierSupplyPt entity = new SupplierSupplyPt();
            entity.SupplierID = row.SupplierID_Ext;
            entity.SupplierSupplyPtCode = row.SupplierSupplyPtCode_Ext;
            entity.SupplierSupplyPtDescr = row.SupplierSupplyPtDescr_Ext;
            entity.SupplierSupplyPtID = row.SupplierSupplyPtID_Ext;
            entity.LastModifiedDtTm = row.LastModifiedDtTm_Ext;
            entity.CompanyID = row.CompanyID_Ext;

            return entity;
        }

        /// <summary>
        /// Function to convert list of InspectionRow to list of Inspection class object
        /// </summary>
        /// <param name="rows">List of Inspection row object</param>
        /// <returns>List of Inspection class object</returns>
        public static List<SupplierSupplyPt> ToEntities(this List<DeliveryStreamCloudWCF.DataAccess.DAL.TW_GetSupplierSupplyPtRow> rows)
        {
            List<SupplierSupplyPt> entities = new List<SupplierSupplyPt>();
            rows.ForEach(item => entities.Add(item.ToEntity()));
            return entities;
        }


        /// <summary>
        /// Function to convert InspectionRow to Inspection class object
        /// </summary>
        /// <param name="row">Inspection row object</param>
        /// <returns>Inspection class object</returns>
        public static Products ToEntity(this DeliveryStreamCloudWCF.DataAccess.DAL.TW_GetSupplierSupplyPtProductsRow row)
        {
            Products entity = new Products();
            entity.SupplierID = row.SupplierID_Ext;
            entity.SupplierPtID = row.SupplierPtID_Ext;
            entity.ProductCode = row.ProductCode_Ext;
            entity.ProductDescr = row.ProductDescr_Ext;
            entity.SupplierSupplyPtID = row.SupplierSupplyPtID_Ext;
            entity.LastModifiedDtTm = row.LastModifiedDtTm_Ext;
            entity.CompanyID = row.CompanyID_Ext;

            return entity;
        }

        /// <summary>
        /// Function to convert list of InspectionRow to list of Inspection class object
        /// </summary>
        /// <param name="rows">List of Inspection row object</param>
        /// <returns>List of Inspection class object</returns>
        public static List<Products> ToEntities(this List<DeliveryStreamCloudWCF.DataAccess.DAL.TW_GetSupplierSupplyPtProductsRow> rows)
        {
            List<Products> entities = new List<Products>();
            rows.ForEach(item => entities.Add(item.ToEntity()));
            return entities;
        }



        /// <summary>
        /// Function to convert InspectionRow to Inspection class object
        /// </summary>
        /// <param name="row">Inspection row object</param>
        /// <returns>Inspection class object</returns>
        public static BolHdrWagon ToEntity(this DeliveryStreamCloudWCF.DataAccess.DAL.BOLHdr_WagonRow row)
        {
            BolHdrWagon entity = new BolHdrWagon();
            entity.ID = row.ID_Ext;

            return entity;
        }

        /// <summary>
        /// Function to convert list of InspectionRow to list of Inspection class object
        /// </summary>
        /// <param name="rows">List of Inspection row object</param>
        /// <returns>List of Inspection class object</returns>
        public static List<BolHdrWagon> ToEntities(this List<DeliveryStreamCloudWCF.DataAccess.DAL.BOLHdr_WagonRow> rows)
        {
            List<BolHdrWagon> entities = new List<BolHdrWagon>();
            rows.ForEach(item => entities.Add(item.ToEntity()));
            return entities;
        }



        /// <summary>
        /// Function to convert InspectionRow to Inspection class object
        /// </summary>
        /// <param name="row">Inspection row object</param>
        /// <returns>Inspection class object</returns>
        public static OrderItemDetails ToEntity(this DeliveryStreamCloudWCF.DataAccess.DAL.OrderitemdetailsRow row)
        {
            OrderItemDetails entity = new OrderItemDetails();
            entity.OrderID = row.OrderID_Ext;
            entity.OrderItemID = row.OrderItemID_Ext;
            entity.ProdCode = row.ProdCode_Ext;
            entity.OrderedQty = row.OrderedQty_Ext;
            entity.OrderNo = row.OrderNo_Ext;
            entity.Blend = row.Blend_Ext;
            entity.ProdName = row.ProdName_Ext;
            return entity;
        }

        /// <summary>
        /// Function to convert list of InspectionRow to list of Inspection class object
        /// </summary>
        /// <param name="rows">List of Inspection row object</param>
        /// <returns>List of Inspection class object</returns>
        public static List<OrderItemDetails> ToEntities(this List<DeliveryStreamCloudWCF.DataAccess.DAL.OrderitemdetailsRow> rows)
        {
            List<OrderItemDetails> entities = new List<OrderItemDetails>();
            rows.ForEach(item => entities.Add(item.ToEntity()));
            return entities;
        }



        /// <summary>
        /// Function to convert InspectionRow to Inspection class object
        /// </summary>
        /// <param name="row">Inspection row object</param>
        /// <returns>Inspection class object</returns>
        public static Status ToEntity(this DeliveryStreamCloudWCF.DataAccess.DAL.cloud_TW_UpdateshipmentdetailsRow row)
        {
            Status entity = new Status();
            entity.StatusNew = row.StatusNew_Ext;
            entity.Reason = row.Reason_Ext;
            return entity;
        }

        /// <summary>
        /// Function to convert list of InspectionRow to list of Inspection class object
        /// </summary>
        /// <param name="rows">List of Inspection row object</param>
        /// <returns>List of Inspection class object</returns>
        public static List<Status> ToEntities(this List<DeliveryStreamCloudWCF.DataAccess.DAL.cloud_TW_UpdateshipmentdetailsRow> rows)
        {
            List<Status> entities = new List<Status>();
            rows.ForEach(item => entities.Add(item.ToEntity()));
            return entities;
        }


        /// <summary>
        /// Function to convert EODDetails to BOLCompartments class object
        /// </summary>
        /// <param name="row">BOLCompartments row object</param>
        /// <returns>BOLCompartments class object</returns>
        public static BOLCompartments ToEntity(this DeliveryStreamCloudWCF.DataAccess.DAL.Cloud_GetEODDetailsRow row)
        {
            BOLCompartments entity = new BOLCompartments();
            entity.BOLNo = row.BOLNo_Ext;
            entity.GrossQty = row.GrossQty_Ext;
            entity.ProdCode = row.ProdCode_Ext;
            entity.CompartmentID = row.CompartmentID_Ext;
            entity.SystrxNo = row.SystrxNo_Ext;
            entity.SystrxLine = row.SystrxLine_Ext;
            entity.SupplierCode = row.SupplierCode_Ext;
            entity.SupplyPointCode = row.SupplyPointCode_Ext;
            entity.OrderedQty = row.OrderedQty_Ext;
            entity.NetQty = row.NetQty_Ext;
            entity.AvailbleQty = row.AvailableQty_Ext;
            entity.SalesQty = row.SalesQty_Ext;
            entity.BOLHdrID = row.BOLHdrID_Ext;
            entity.BOLItemID = row.BOLItemID_Ext;
            entity.BOLDatetime = row.BOLDatetime_Ext;
            entity.Notes = row.Notes_Ext;

            return entity;
        }

        /// <summary>
        /// Function to convert list of EODDetailsRow to list of BOLCompartments class object
        /// </summary>
        /// <param name="rows">List of BOLCompartments row object</param>
        /// <returns>List of BOLCompartments class object</returns>
        public static List<BOLCompartments> ToEntities(this List<DeliveryStreamCloudWCF.DataAccess.DAL.Cloud_GetEODDetailsRow> rows)
        {
            List<BOLCompartments> entities = new List<BOLCompartments>();
            rows.ForEach(item => entities.Add(item.ToEntity()));
            return entities;
        }

        /// <summary>
        /// Function to convert EODDetails to BOLCompartments class object
        /// </summary>
        /// <param name="row">BOLCompartments row object</param>
        /// <returns>BOLCompartments class object</returns>
        public static BOLCompartments ToEntity(this DeliveryStreamCloudWCF.DataAccess.DAL.Cloud_GetEODHistoryRow row)
        {
            BOLCompartments entity = new BOLCompartments();
            entity.BOLNo = row.BOLNo_Ext;
            entity.GrossQty = row.GrossQty_Ext;
            entity.ProdCode = row.ProdCode_Ext;
            entity.CompartmentID = row.CompartmentID_Ext;
            entity.SystrxNo = row.SystrxNo_Ext;
            entity.SystrxLine = row.SystrxLine_Ext;
            entity.SupplierCode = row.SupplierCode_Ext;
            entity.SupplyPointCode = row.SupplyPointCode_Ext;
            entity.OrderedQty = row.OrderedQty_Ext;
            entity.NetQty = row.NetQty_Ext;
            entity.AvailbleQty = row.AvailableQty_Ext;
            entity.SalesQty = row.SalesQty_Ext;
            entity.BOLHdrID = row.BOLHdrID_Ext;
            entity.BOLItemID = row.BOLItemID_Ext;
            entity.BOLDatetime = row.BOLDatetime_Ext;
            entity.Notes = row.Notes_Ext;

            return entity;
        }

        /// <summary>
        /// Function to convert list of EODDetailsRow to list of BOLCompartments class object
        /// </summary>
        /// <param name="rows">List of BOLCompartments row object</param>
        /// <returns>List of BOLCompartments class object</returns>
        public static List<BOLCompartments> ToEntities(this List<DeliveryStreamCloudWCF.DataAccess.DAL.Cloud_GetEODHistoryRow> rows)
        {
            List<BOLCompartments> entities = new List<BOLCompartments>();
            rows.ForEach(item => entities.Add(item.ToEntity()));
            return entities;
        }

        /// <summary>
        /// Function to convert BODDetails to BOLCompartments class object
        /// </summary>
        /// <param name="row">BOLCompartments row object</param>
        /// <returns>BOLCompartments class object</returns>
        public static BOLCompartments ToEntity(this DeliveryStreamCloudWCF.DataAccess.DAL.Cloud_GetBODDetailsRow row)
        {
            BOLCompartments entity = new BOLCompartments();
            entity.BOLNo = row.BOLNo_Ext;
            entity.ProdCode = row.ProdCode_Ext;
            entity.CompartmentID = row.CompartmentID_Ext;
            entity.AvailbleQty = row.AvailableQty_Ext;
            entity.BOLHdrID = row.BOLHdrID_Ext;
            entity.BOLItemID = row.BOLItemID_Ext;
            entity.BOLDatetime = row.BOLDatetime_Ext;

            return entity;
        }

        /// <summary>
        /// Function to convert list of BODDetailsRow to list of BOLCompartments class object
        /// </summary>
        /// <param name="rows">List of BOLCompartments row object</param>
        /// <returns>List of BOLCompartments class object</returns>
        public static List<BOLCompartments> ToEntities(this List<DeliveryStreamCloudWCF.DataAccess.DAL.Cloud_GetBODDetailsRow> rows)
        {
            List<BOLCompartments> entities = new List<BOLCompartments>();
            rows.ForEach(item => entities.Add(item.ToEntity()));
            return entities;
        }

        /// <summary>
        /// Function to convert BODDetails to BOLCompartments class object
        /// </summary>
        /// <param name="row">BOLCompartments row object</param>
        /// <returns>BOLCompartments class object</returns>
        public static BOLCompartments ToEntity(this DeliveryStreamCloudWCF.DataAccess.DAL.Cloud_GetBODHistoryRow row)
        {
            BOLCompartments entity = new BOLCompartments();
            entity.BOLNo = row.BOLNo_Ext;
            entity.ProdCode = row.ProdCode_Ext;
            entity.CompartmentID = row.CompartmentID_Ext;
            entity.AvailbleQty = row.AvailableQty_Ext;
            entity.BOLHdrID = row.BOLHdrID_Ext;
            entity.BOLItemID = row.BOLItemID_Ext;
            entity.BOLDatetime = row.BOLDatetime_Ext;

            return entity;
        }

        /// <summary>
        /// Function to convert list of BODDetailsRow to list of BOLCompartments class object
        /// </summary>
        /// <param name="rows">List of BOLCompartments row object</param>
        /// <returns>List of BOLCompartments class object</returns>
        public static List<BOLCompartments> ToEntities(this List<DeliveryStreamCloudWCF.DataAccess.DAL.Cloud_GetBODHistoryRow> rows)
        {
            List<BOLCompartments> entities = new List<BOLCompartments>();
            rows.ForEach(item => entities.Add(item.ToEntity()));
            return entities;
        }


        /// <summary>
        /// Function to convert InspectionRow to Inspection class object
        /// </summary>
        /// <param name="row">Inspection row object</param>
        /// <returns>Inspection class object</returns>
        public static INSite ToEntity(this DeliveryStreamCloudWCF.DataAccess.DAL.TW_GetINSiteRow row)
        {
            INSite entity = new INSite();
            entity.CustomerID = row.CustomerID_Ext;
            entity.Code = row.Code_Ext;
            entity.LongDescr = row.LongDescr_Ext;
            entity.LastModifiedDtTm = row.LastModifiedDtTm_Ext;
            entity.SiteID = row.SiteID_Ext;
            return entity;
        }

        /// <summary>
        /// Function to convert list of InspectionRow to list of Inspection class object
        /// </summary>
        /// <param name="rows">List of Inspection row object</param>
        /// <returns>List of Inspection class object</returns>
        public static List<INSite> ToEntities(this List<DeliveryStreamCloudWCF.DataAccess.DAL.TW_GetINSiteRow> rows)
        {
            List<INSite> entities = new List<INSite>();
            rows.ForEach(item => entities.Add(item.ToEntity()));
            return entities;
        }


        /// <summary>
        /// Function to convert InspectionRow to Inspection class object
        /// </summary>
        /// <param name="row">Inspection row object</param>
        /// <returns>Inspection class object</returns>
        public static Products ToEntity(this DeliveryStreamCloudWCF.DataAccess.DAL.Cloud_GetTWLineFlushProductsRow row)
        {
            Products entity = new Products();
            entity.ProductCode = row.ProductCode_Ext;
            return entity;
        }

        /// <summary>
        /// Function to convert list of InspectionRow to list of Inspection class object
        /// </summary>
        /// <param name="rows">List of Inspection row object</param>
        /// <returns>List of Inspection class object</returns>
        public static List<Products> ToEntities(this List<DeliveryStreamCloudWCF.DataAccess.DAL.Cloud_GetTWLineFlushProductsRow> rows)
        {
            List<Products> entities = new List<Products>();
            rows.ForEach(item => entities.Add(item.ToEntity()));
            return entities;
        }


        public static List<GetVehicleDetails> ToEntities(this List<DeliveryStreamCloudWCF.DataAccess.DAL.Cloud_TW_GetVehicleRow> rows)
        {
            List<GetVehicleDetails> entities = new List<GetVehicleDetails>();
            rows.ForEach(item => entities.Add(item.ToEntity()));
            return entities;
        }
        public static GetVehicleDetails ToEntity(this DeliveryStreamCloudWCF.DataAccess.DAL.Cloud_TW_GetVehicleRow row)
        {
            GetVehicleDetails entity = new GetVehicleDetails();
            if (row != null)
            {
                entity.VehicleID = row.VehicleID_Ext;
                entity.VehicleCode = row.VehicleCode_Ext;
            }
            return entity;
        }

        /// <summary>
        /// Function to convert InspectionRow to Inspection class object
        /// </summary>
        /// <param name="row">Inspection row object</param>
        /// <returns>Inspection class object</returns>
        public static GetVehicleTypeCompartment ToEntity(this DeliveryStreamCloudWCF.DataAccess.DAL.Cloud_TW_GetVehicleTypeCompartmentRow row)
        {
            GetVehicleTypeCompartment entity = new GetVehicleTypeCompartment();
            entity.CompartmentCode = row.CompartmentCode_Ext;
            entity.CompartmentID = row.CompartmentID_Ext;
            return entity;
        }

        /// <summary>
        /// Function to convert list of InspectionRow to list of Inspection class object
        /// </summary>
        /// <param name="rows">List of Inspection row object</param>
        /// <returns>List of Inspection class object</returns>
        public static List<GetVehicleTypeCompartment> ToEntities(this List<DeliveryStreamCloudWCF.DataAccess.DAL.Cloud_TW_GetVehicleTypeCompartmentRow> rows)
        {
            List<GetVehicleTypeCompartment> entities = new List<GetVehicleTypeCompartment>();
            rows.ForEach(item => entities.Add(item.ToEntity()));
            return entities;
        }


        /// <summary>
        /// Function to convert Cloud_TW_GetVehicleMetersRow to VehicleMeters class object
        /// </summary>
        /// <param name="row">VehicleMeters row object</param>
        /// <returns>VehicleMeters class object</returns>
        public static VehicleMeters ToEntity(this DeliveryStreamCloudWCF.DataAccess.DAL.Cloud_TW_GetVehicleMetersRow row)
        {
            VehicleMeters entity = new VehicleMeters();
            entity.CustomerID = row.CustomerID_Ext;
            entity.MeterID = row.MeterID_Ext;
            entity.VehicleID = row.VehicleID_Ext;
            entity.Code = row.Code_Ext;
            entity.NeedUpdate = row.NeedUpdate_Ext;
            return entity;
        }

        /// <summary>
        /// Function to convert list of Cloud_TW_GetVehicleMetersRow to list of VehicleMeters class object
        /// </summary>
        /// <param name="rows">List of VehicleMeters row object</param>
        /// <returns>List of VehicleMeters class object</returns>
        public static List<VehicleMeters> ToEntities(this List<DeliveryStreamCloudWCF.DataAccess.DAL.Cloud_TW_GetVehicleMetersRow> rows)
        {
            List<VehicleMeters> entities = new List<VehicleMeters>();
            rows.ForEach(item => entities.Add(item.ToEntity()));

            return entities;
        }

        /// <summary>
        /// Function to convert Cloud_TW_GetVehicleMetersRow to VehicleMeters class object
        /// </summary>
        /// <param name="row">VehicleMeters row object</param>
        /// <returns>VehicleMeters class object</returns>
        public static VehicleMetersTotalizer ToEntity(this DeliveryStreamCloudWCF.DataAccess.DAL.Cloud_TW_GetVehicleMetersTotalizerRow row)
        {
            VehicleMetersTotalizer entity = new VehicleMetersTotalizer();
            entity.MeterID = row.MeterID_Ext;
            entity.MeterTotal = row.MeterTotal_Ext;
            entity.ShiftTotal = row.ShiftTotal_Ext;
            entity.Total = row.Total_Ext;
            entity.Code = row.Code_Ext;
            return entity;
        }

        /// <summary>
        /// Function to convert list of Cloud_TW_GetVehicleMetersRow to list of VehicleMeters class object
        /// </summary>
        /// <param name="rows">List of VehicleMeters row object</param>
        /// <returns>List of VehicleMeters class object</returns>
        public static List<VehicleMetersTotalizer> ToEntities(this List<DeliveryStreamCloudWCF.DataAccess.DAL.Cloud_TW_GetVehicleMetersTotalizerRow> rows)
        {
            List<VehicleMetersTotalizer> entities = new List<VehicleMetersTotalizer>();
            rows.ForEach(item => entities.Add(item.ToEntity()));

            return entities;
        }


        public static Cloud_TW_GetVehicleSiteID ToEntity(this DeliveryStreamCloudWCF.DataAccess.DAL.Cloud_TW_GetVehicleSiteIDRow row)
        {
            Cloud_TW_GetVehicleSiteID entity = new Cloud_TW_GetVehicleSiteID();
            entity.CustomerID = row.CustomerID_Ext;
            entity.Code = row.Code_Ext;
            entity.LongDescr = row.LongDescr_Ext;
            entity.LastModifiedDtTm = row.LastModifiedDtTm_Ext;
            entity.SiteID = row.SiteID_Ext;
            return entity;
        }

        public static List<Cloud_TW_GetVehicleSiteID> ToEntities(this List<DeliveryStreamCloudWCF.DataAccess.DAL.Cloud_TW_GetVehicleSiteIDRow> rows)
        {
            List<Cloud_TW_GetVehicleSiteID> entities = new List<Cloud_TW_GetVehicleSiteID>();
            rows.ForEach(item => entities.Add(item.ToEntity()));
            return entities;
        }

        public static object AssignValues(this DataRow dr, object obj)
        {
            try
            {
                string name = string.Empty;
                obj = Activator.CreateInstance(obj.GetType());
                foreach (var item in obj.GetType().GetProperties())
                {
                    name = item.Name;
                    object propValue = null;
                    if (dr[name].GetType().FullName == "System.Byte[]")
                    {
                        propValue = System.Text.Encoding.UTF8.GetString((byte[])dr[name]);
                    }
                    else
                    {
                        TypeConverter typeConverter = TypeDescriptor.GetConverter(item.PropertyType);
                        propValue = typeConverter.ConvertFromString(dr[name].ToString().Trim());
                    }
                    if (propValue == null)
                    {
                        if (item.PropertyType.FullName.Contains("System.Int32"))
                        {
                            propValue = 0;
                        }
                        else if (item.PropertyType.FullName.Contains("System.System.Double"))
                        {
                            propValue = double.Parse("0");
                        }
                        else if (item.PropertyType.FullName.Contains("System.Decimal"))
                        {
                            propValue = decimal.Parse("0");
                        }
                        else if (item.PropertyType.FullName.Contains("System.Single"))
                        {
                            propValue = Single.Parse("0");
                        }
                    }


                    item.SetValue(obj, propValue, null);
                }

            }
            catch (Exception ex)
            {
                Logging.LogError(ex, "AssignValues");
            }
            return obj;
        }

        #endregion
    }
}
