// 2014.01.17 Ramesh M Added For  CR#61759 to get from site list 
// 2014.01.23  Ramesh M Added For CR#61759 Added ShipToID
// 2014.02.20  Ramesh M Added For CR#62301 For Driver status Screen in Ipad
// 2014.02.20  Ramesh M Added For CR#62292 For driver summary log
// 2014.02.25  Ramesh M Added For CR#62292 For modified driver summary log
// 2014.02.24  Ramesh M Added For CR#62406 For DriverID,VechileID,UserLoginID on login itself
// 2014.03.17  Ramesh M Added For CR#62613 to get home terminal details
// 2014.03.20  Ramesh M Added For CR#62322 added  Version testing method
// 05-14-2014  MadhuVenkat K - Added for CR 63396 - Add Time Remaining Section to Driver Summary
// 05-20-2014  MadhuVenkat k - Added for CR 63346 - PO & Priority No to Load Information Screen 
// 06-26-2014  MadhuVenkat k - Added for CR 64058  - For Add orderDispatchHistory 
// 08-14-2014  MadhuVenkat K - Added for CR 64639 - Add CurrentDriverStatus to Driver Summary
// 08-14-2014  MadhuVenkat K - Added for CR 64639 - Add StatusUpdate to GpsHistory
// 08-25-2014  MadhuVenkat K - Added for CR 64760 - Add InspectionVersion to Driver Summary
using System;

namespace DeliveryStreamCloudWCF.DataAccess
{

    /// <summary>
    /// DAL
    /// Partial class for data access layer
    /// </summary>
    public partial class DAL
    {
        partial class DeliveryDetailsDataTable
        {
        }

        partial class DriverSummaryDataTable
        {
        }

        partial class DriversDataTable
        {
        }

        partial class OrderDispatchHistoryDataTable
        {
        }

        partial class CustomerDataTable
        {
        }

        partial class OrderDataTable
        {
        }
        /// <summary>
        /// LoginUserRow
        /// Partial Login user row class to get and set datamembers
        /// </summary>
        partial class LoginUserRow
        {
            /// <summary>
            /// ID_Ext
            /// Properties for ID datamember
            /// </summary>
            public Int32 ID_Ext
            {
                get
                {
                    return this.ID;
                }
                set
                {
                    this.ID = value;
                }
            }

            /// <summary>
            /// CustomerID_Ext
            /// Properties for CustomerID datamember
            /// </summary>
            public String CustomerID_Ext
            {
                get
                {
                    return this.CustomerID;
                }
                set
                {
                    this.CustomerID = value;
                }
            }

            /// <summary>
            /// Password_Ext
            /// Properties for Password datamember
            /// </summary>
            public String Password_Ext
            {
                get
                {
                    return this.Password;
                }
                set
                {
                    this.Password = value;
                }
            }

            /// <summary>
            /// UserName_Ext
            /// Properties for UserName datamember
            /// </summary>
            public String UserName_Ext
            {
                get
                {
                    return this.UserName;
                }
                set
                {
                    this.UserName = value;
                }
            }

            /// <summary>
            /// Email_Ext
            /// Properties for Email datamember
            /// </summary>
            public String Email_Ext
            {
                get
                {
                    if (this.IsEmailNull())
                    {
                        return null;
                    }
                    return this.Email;
                }
                set
                {
                    this.Email = value;
                }
            }

            /// <summary>
            /// DriverID_Ext
            /// Properties for DriverID datamember
            /// </summary>
            public Int32 DriverID_Ext
            {
                get
                {
                    if (this.IsDriverIDNull())
                    {
                        return 0;
                    }
                    return this.DriverID;
                }
                set
                {
                    this.DriverID = value;
                }
            }

            /// <summary>
            /// FirstName_Ext
            /// Properties for FirstName datamember
            /// </summary>
            public String FirstName_Ext
            {
                get
                {
                    if (this.IsFirstNameNull())
                    {
                        return null;
                    }
                    return this.FirstName;
                }
                set
                {
                    this.FirstName = value;
                }
            }

            /// <summary>
            /// MiddleName_Ext
            /// Properties for MiddleName datamember
            /// </summary>
            public String MiddleName_Ext
            {
                get
                {
                    if (this.IsMiddleNameNull())
                    {
                        return null;
                    }
                    return this.MiddleName;
                }
                set
                {
                    this.MiddleName = value;
                }
            }

            /// <summary>
            /// LastName_Ext
            /// Properties for LastName datamember
            /// </summary>
            public String LastName_Ext
            {
                get
                {
                    if (this.IsLastNameNull())
                    {
                        return null;
                    }
                    return this.LastName;
                }
                set
                {
                    this.LastName = value;
                }
            }

            /// <summary>
            /// UserType_Ext
            /// Properties for UserType datamember
            /// </summary>
            public String UserType_Ext
            {
                get
                {
                    return this.UserType;
                }
                set
                {
                    this.UserType = value;
                }
            }

            // 2014.02.24  Ramesh M Added For CR#62406 For DriverID,VechileID,UserLoginID on login itself
            /// <summary>
            /// 
            /// </summary>
            public Int32 SiteID_Ext
            {
                get
                {
                    if (this.IsSiteIDNull())
                    {
                        return 0;
                    }
                    return this.SiteID;
                }
                set
                {
                    this.SiteID = value;
                }
            }
        }

        /// <summary>
        /// LoginHistory
        /// Partial LoginHistory row class to get and set datamembers
        /// </summary>
        partial class LoginHistoryRow
        {
            /// <summary>
            /// LoginID_Ext
            /// Properties for LoginID datamember
            /// </summary>
            public Int32 LoginID_Ext
            {
                get
                {
                    return this.LoginID;
                }
                set
                {
                    this.LoginID = value;
                }
            }

            /// <summary>
            /// VehicleID_Ext
            /// Properties for VehicleID datamember
            /// </summary>
            public Int32 VehicleID_Ext
            {
                get
                {
                    return this.VehicleID;
                }
                set
                {
                    this.VehicleID = value;
                }
            }

            /// <summary>
            /// CustomerID_Ext
            /// Properties for CustomerID datamember
            /// </summary>
            public String CustomerID_Ext
            {
                get
                {
                    return this.CustomerID;
                }
                set
                {
                    this.CustomerID = value;
                }
            }


            /// <summary>
            /// DeviceID_Ext
            /// Properties for DeviceID datamember
            /// </summary>
            public string DeviceID_Ext
            {
                get
                {
                    if (this.IsDeviceIDNull())
                    {
                        return null;
                    }
                    return this.DeviceID;
                }
                set
                {
                    this.DeviceID = value;
                }
            }

            /// <summary>
            /// DeviceToken_Ext
            /// Properties for DeviceToken datamember
            /// </summary>
            public string DeviceToken_Ext
            {
                get
                {
                    if (this.IsDeviceTokenNull())
                    {
                        return null;
                    }
                    return this.DeviceToken;
                }
                set
                {
                    this.DeviceToken = value;
                }
            }

            /// <summary>
            /// DateTime_Ext
            /// Properties for DateTime datamember
            /// </summary>
            public DateTime DateTime_Ext
            {
                get
                {
                    return this.DateTime;
                }
                set
                {
                    this.DateTime = value;
                }
            }

            /// <summary>
            /// IsValidToken_Ext
            /// Properties for IsValidToken datamember
            /// </summary>
            public Boolean IsValidToken_Ext
            {
                get
                {
                    return this.IsValidToken;
                }
                set
                {
                    this.IsValidToken = value;
                }
            }

            /// <summary>
            /// DeviceTime_Ext
            /// Properties for DeviceTime datamember
            /// </summary>
            public DateTime? DeviceTime_Ext
            {
                get
                {
                    if (this.IsDeviceTimeNull())
                    {
                        return null;
                    }
                    return this.DeviceTime;
                }
                set
                {
                    if (value == null)
                    {
                        this.SetDeviceTimeNull();
                    }
                    else
                    {
                        this.DeviceTime = Convert.ToDateTime(value);
                    }
                }
            }

            public Guid SessionID_Ext
            {
                get
                {
                    return this.SessionID;
                }
                set
                {
                    this.SessionID = value;
                }
            }
            public DateTime? LogoffTime_Ext
            {
                get
                {
                    if (this.IsLogoffTimeNull())
                    {
                        return null;
                    }
                    return this.LogoffTime;
                }
                set
                {
                    if (value == null)
                    {
                        this.SetLogoffTimeNull();
                    }
                    else
                    {
                        this.LogoffTime = Convert.ToDateTime(value);
                    }
                }
            }

            public Decimal? OnDuty_Ext
            {
                get
                {
                    if (this.IsOnDutyNull())
                    {
                        return 0;
                    }
                    return this.OnDuty;
                }
                set
                {
                    if (value == null)
                    {
                        this.SetOnDutyNull();
                    }
                    else
                    {
                        this.OnDuty = Convert.ToDecimal(value);
                    }
                }
            }

            public Decimal? Driving_Ext
            {
                get
                {
                    if (this.IsDrivingNull())
                    {
                        return 0;
                    }
                    return this.Driving;
                }
                set
                {
                    if (value == null)
                    {
                        this.SetDrivingNull();
                    }
                    else
                    {
                        this.Driving = Convert.ToDecimal(value);
                    }
                }
            }

            public Decimal? Sleeper_Ext
            {
                get
                {
                    if (this.IsSleeperNull())
                    {
                        return 0;
                    }
                    return this.Sleeper;
                }
                set
                {
                    if (value == null)
                    {
                        this.SetSleeperNull();
                    }
                    else
                    {
                        this.Sleeper = Convert.ToDecimal(value);
                    }
                }
            }

            public Decimal? OffDuty_Ext
            {
                get
                {
                    if (this.IsOffDutyNull())
                    {
                        return 0;
                    }
                    return this.OffDuty;
                }
                set
                {
                    if (value == null)
                    {
                        this.SetOffDutyNull();
                    }
                    else
                    {
                        this.OffDuty = Convert.ToDecimal(value);
                    }
                }
            }
        }

        /// <summary>
        /// StatusRow
        /// Partial Status row class to get and set datamembers
        /// </summary>
        partial class StatusRow
        {
            /// <summary>
            /// Id_Ext
            /// Properties for Id datamember
            /// </summary>
            public String Id_Ext
            {
                get
                {
                    return this.Id;
                }
                set
                {
                    this.Id = value;
                }
            }

            /// <summary>
            /// Description_Ext
            /// Properties for Description datamember
            /// </summary>
            public String Description_Ext
            {
                get
                {
                    return this.Description;
                }
                set
                {
                    this.Description = value;
                }
            }

            /// <summary>
            /// Sequence_Ext
            /// Properties for Sequence datamember
            /// </summary>
            public Int32 Sequence_Ext
            {
                get
                {
                    if (this.IsSequenceNull())
                    {
                        return 0;
                    }
                    return this.Sequence;
                }
                set
                {
                    this.Sequence = value;
                }
            }
        }

        /// <summary>
        /// OrderItemRow
        /// Partial OrderItem row class to get and set datamembers
        /// </summary>
        partial class OrderItemRow
        {
            /// <summary>
            /// Id_Ext
            /// Properties for Id datamember
            /// </summary>
            public Guid Id_Ext
            {
                get
                {
                    return this.ID;
                }
                set
                {
                    this.ID = value;
                }
            }

            /// <summary>
            /// OrderID_Ext
            /// Properties for OrderID datamember
            /// </summary>
            public Guid OrderID_Ext
            {
                get
                {
                    return this.OrderID;
                }
                set
                {
                    this.OrderID = value;
                }
            }

            /// <summary>
            /// SysTrxLine_Ext
            /// Properties for SysTrxLine datamember
            /// </summary>
            public int SysTrxLine_Ext
            {
                get
                {
                    return this.SysTrxLine;
                }
                set
                {
                    this.SysTrxLine = value;
                }
            }

            /// <summary>
            /// Qty_Ext
            /// Properties for Qty datamember
            /// </summary>
            public Decimal Qty_Ext
            {
                get
                {
                    //return this.OrderedQty() ? 0.0M : this.OrderedQty;                    
                    return this.OrderedQty;
                }
                set
                {
                    this.OrderedQty = value;
                }
            }

            /// <summary>
            /// ProdCode_Ext
            /// Properties for ProdCode datamember
            /// </summary>
            public String ProdCode_Ext
            {
                get
                {
                    return this.IsProdCodeNull() ? null : this.ProdCode;
                }
                set
                {
                    this.ProdCode = value;
                }
            }

            /// <summary>
            /// ProdName_Ext
            /// Properties for ProdName datamember
            /// </summary>
            public String ProdName_Ext
            {
                get
                {
                    return this.IsProdNameNull() ? null : this.ProdName;
                }
                set
                {
                    this.ProdName = value;
                }
            }

            /// <summary>
            /// ProdUOM_Ext
            /// Properties for ProdUOM datamember
            /// </summary>
            public String ProdUOM_Ext
            {
                get
                {
                    return this.IsProdUOMNull() ? null : this.ProdUOM;
                }
                set
                {
                    this.ProdUOM = value;
                }
            }

            /// <summary>
            /// Blend_Ext
            /// Properties for Blend datamember
            /// </summary>
            public String Blend_Ext
            {
                get
                {
                    return this.IsBlendNull() ? "N" : this.Blend;
                }
                set
                {
                    this.Blend = value;
                }
            }

            /// <summary>
            /// SupplierName_Ext
            /// Properties for SupplierName datamember
            /// </summary>
            public String SupplierName_Ext
            {
                get
                {
                    return this.IsSupplierNameNull() ? null : this.SupplierName;
                }
                set
                {
                    this.SupplierName = value;
                }
            }

            /// <summary>
            /// SupplierCode_Ext
            /// Properties for SupplierCode datamember
            /// </summary>
            public String SupplierCode_Ext
            {
                get
                {
                    return this.IsSupplierCodeNull() ? null : this.SupplierCode;
                }
                set
                {
                    this.SupplierCode = value;
                }
            }

            /// <summary>
            /// SupplyPointName_Ext
            /// Properties for SupplyPointName datamember
            /// </summary>
            public String SupplyPointName_Ext
            {
                get
                {
                    return this.IsSupplyPointNameNull() ? null : this.SupplyPointName;
                }
                set
                {
                    this.SupplyPointName = value;
                }
            }

            /// <summary>
            /// SupplyPointCode_Ext
            /// Properties for SupplyPointCode datamember
            /// </summary>
            public String SupplyPointCode_Ext
            {
                get
                {
                    return this.IsSupplyPointCodeNull() ? null : this.SupplyPointCode;
                }
                set
                {
                    this.SupplyPointCode = value;
                }
            }

            /// <summary>
            /// SupplyPointAddress1_Ext
            /// Properties for SupplyPointAddress1 datamember
            /// </summary>
            public String SupplyPointAddress1_Ext
            {
                get
                {
                    return this.IsSupplyPointAddress1Null() ? null : this.SupplyPointAddress1;
                }
                set
                {
                    this.SupplyPointAddress1 = value;
                }
            }

            /// <summary>
            /// SupplyPointAddress2_Ext
            /// Properties for SupplyPointAddress2 datamember
            /// </summary>
            public String SupplyPointAddress2_Ext
            {
                get
                {
                    return this.IsSupplyPointAddress2Null() ? null : this.SupplyPointAddress2;
                }
                set
                {
                    this.SupplyPointAddress2 = value;
                }
            }

            /// <summary>
            /// City_Ext
            /// Properties for City datamember
            /// </summary>
            public String City_Ext
            {
                get
                {
                    return this.IsCityNull() ? null : this.City;
                }
                set
                {
                    this.City = value;
                }
            }

            /// <summary>
            /// State_Ext
            /// Properties for State datamember
            /// </summary>
            public String State_Ext
            {
                get
                {
                    return this.IsStateNull() ? null : this.State;
                }
                set
                {
                    this.State = value;
                }
            }

            /// <summary>
            /// Zip_Ext
            /// Properties for Zip datamember
            /// </summary>
            public String Zip_Ext
            {
                get
                {
                    return this.IsZipNull() ? null : this.Zip;
                }
                set
                {
                    this.Zip = value;
                }
            }

            /// <summary>
            /// Country_Ext
            /// Properties for Country datamember
            /// </summary>
            public String Country_Ext
            {
                get
                {
                    return this.IsCountryNull() ? null : this.Country;
                }
                set
                {
                    this.Country = value;
                }
            }

            /// <summary>
            /// Notes_Ext
            /// Property for Notes datamember
            /// </summary>
            public String Note_Ext
            {
                get
                {
                    return this.IsNoteNull() ? null : this.Note;
                }
                set
                {
                    this.Note = value;
                }

            }

            public int ARShipToTankID_Ext
            {
                get { return this.IsARShipToTankIDNull() ? 0 : this.ARShipToTankID; }
                set { this.ARShipToTankID = value; }

            }

            public String ARShipToTankCode_Ext
            {
                get { return this.IsARShipToTankCodeNull() ? null : this.ARShipToTankCode; }
                set { this.ARShipToTankCode = value; }
            }




        }

        // 06-26-2014  MadhuVenkat k - Added for CR 64058  - For Add orderDispatchHistory 
        partial class OrderDispatchHistoryRow
        {
            /// <summary>
            /// SysTrxNo_Ext
            /// Properties for SysTrxNo datamember
            /// </summary>
            public Decimal SysTrxNo_Ext
            {
                get
                {
                    return this.SysTrxNo;
                }
                set
                {
                    this.SysTrxNo = value;
                }
            }

            /// <summary>
            /// OrderNo_Ext
            /// Properties for OrderNo datamember
            /// </summary>
            public String CustomerID_Ext
            {
                get
                {

                    return this.CustomerID;
                }
                set
                {
                    this.CustomerID = value;
                }
            }

            /// <summary>
            /// DefDriverID_Ext
            /// Properties for NoteNo datamember
            /// </summary>
            public Int32 DefDriverID_Ext
            {
                get
                {
                    return this.DefDriverID;
                }
                set
                {
                    this.DefDriverID = value;
                }
            }
            /// <summary>
            /// DefVehicleID_Ext
            /// Properties for NoteTypeID datamember
            /// </summary>
            public Int32 DefVehicleID_Ext
            {
                get
                {
                    return this.DefVehicleID;

                }
                set
                {
                    this.DefVehicleID = value;
                }
            }

            /// <summary>
            /// OldDriverID_Ext
            /// Properties for Note datamember
            /// </summary>
            public Int32 OldDriverID_Ext
            {
                get
                {
                    return this.OldDriverID;
                }
                set
                {
                    this.OldDriverID = value;
                }
            }
            /// <summary>
            /// OldVehicleID_Ext
            /// Properties for PrintOn datamember
            /// </summary>
            public Int32 OldVehicleID_Ext
            {
                get
                {
                    return this.OldVehicleID;
                }
                set
                {
                    this.OldVehicleID = value;
                }
            }
        }

        /// <summary>
        /// OrderRow
        /// Partial Order row class to get and set datamembers
        /// </summary>
        partial class OrderRow
        {
            /// <summary>
            /// Id_Ext
            /// Properties for Id datamember
            /// </summary>
            public Guid Id_Ext
            {
                get
                {
                    return this.ID;
                }
                set
                {
                    this.ID = value;
                }
            }

            /// <summary>
            /// LoadID_Ext
            /// Properties for LoadID datamember
            /// </summary>
            public Guid LoadID_Ext
            {
                get
                {
                    return this.LoadID;
                }
                set
                {
                    this.LoadID = value;
                }
            }

            /// <summary>
            /// OrderNo_Ext
            /// Properties for OrderNo datamember
            /// </summary>
            public String OrderNo_Ext
            {
                get
                {
                    return this.OrderNo;
                }
                set
                {
                    this.OrderNo = value;
                }
            }

            /// <summary>
            /// SysTrxNo_Ext
            /// Properties for SysTrxNo datamember
            /// </summary>
            public Decimal SysTrxNo_Ext
            {
                get
                {
                    return this.SysTrxNo;
                }
                set
                {
                    this.SysTrxNo = value;
                }
            }

            /// <summary>
            /// PromisedDtTm_Ext
            /// Properties for PromisedDtTm datamember
            /// </summary>
            public DateTime PromisedDtTm_Ext
            {
                get
                {
                    return IsPromisedDtTmNull() ? System.DateTime.Now : this.PromisedDtTm;
                }
                set
                {
                    this.PromisedDtTm = value;
                }
            }

            /// <summary>
            /// DestAddress1_Ext
            /// Properties for DestAddress1 datamember
            /// </summary>
            public String DestAddress1_Ext
            {
                get
                {
                    return this.IsDestAddress1Null() ? null : this.DestAddress1;
                }
                set
                {
                    this.DestAddress1 = value;
                }
            }

            /// <summary>
            /// DestAddress2_Ext
            /// Properties for DestAddress2 datamember
            /// </summary>
            public String DestAddress2_Ext
            {
                get
                {
                    return this.IsDestAddress2Null() ? null : this.DestAddress2;
                }
                set
                {
                    this.DestAddress2 = value;
                }
            }

            /// <summary>
            /// City_Ext
            /// Properties for City datamember
            /// </summary>
            public String City_Ext
            {
                get
                {
                    return this.IsCityNull() ? null : this.City;
                }
                set
                {
                    this.City = value;
                }
            }

            /// <summary>
            /// State_Ext
            /// Properties for State datamember
            /// </summary>
            public String State_Ext
            {
                get
                {
                    return this.IsStateNull() ? null : this.State;
                }
                set
                {
                    this.State = value;
                }
            }

            /// <summary>
            /// Zip_Ext
            /// Properties for Zip datamember
            /// </summary>
            public String Zip_Ext
            {
                get
                {
                    return this.IsZipNull() ? null : this.Zip;
                }
                set
                {
                    this.Zip = value;
                }
            }

            /// <summary>
            /// DestNotes_Ext
            /// Properties for DestNotes datamember
            /// </summary>
            public String DestNotes_Ext
            {
                get
                {
                    return this.IsDestNotesNull() ? null : this.DestNotes;
                }
                set
                {
                    this.DestNotes = value;
                }
            }

            /// <summary>
            /// DestSite_Ext
            /// Properties for DestSite datamember
            /// </summary>
            public String DestSite_Ext
            {
                get
                {
                    return this.IsDestSiteNull() ? null : this.DestSite;
                }
                set
                {
                    this.DestSite = value;
                }
            }

            /// <summary>
            /// Country_Ext
            /// Properties for Country datamember
            /// </summary>
            public String Country_Ext
            {
                get
                {
                    return this.IsCountryNull() ? null : this.Country;
                }
                set
                {
                    this.Country = value;
                }
            }

            public String Notes_Ext
            {
                get
                {
                    return this.IsNotesNull() ? null : this.Notes;
                }
                set
                {
                    this.Notes = value;
                }
            }
            //05-20-2014  MadhuVenkat k - Added for CR 63346 - PO & Priority No to Load Information Screen 
            public String PONo_Ext
            {
                get
                {
                    return this.IsPONoNull() ? null : this.PONo;
                }
                set
                {
                    this.PONo = value;
                }
            }

            public String PriorityNo_Ext
            {
                get
                {
                    return this.IsPriorityNoNull() ? null : this.PriorityNo;
                }
                set
                {
                    this.PriorityNo = value;
                }
            }

            //2013.12.02  Fsww Ramesh M, Added for  RequestedDtTm CR#61274 
            /// <summary>
            /// RequestedDtTm_Ext
            /// Properties for RequestedDtTm datamember
            /// </summary>
            public DateTime? RequestedDtTm_Ext
            {
                get
                {
                    if (this.IsRequestedDtTmNull())
                    {
                        return null;
                    }
                    else
                    {
                        return this.RequestedDtTm;
                    }
                }
                set
                {
                    if (value != null)
                    {
                        this.RequestedDtTm = value.Value;
                    }
                    else
                    {
                        this.SetRequestedDtTmNull();
                    }
                }

                //get
                //{
                //    return IsRequestedDtTmNull() ? System.DateTime.Now  : this.RequestedDtTm;
                //}
                //set
                //{
                //    this.RequestedDtTm = value;
                //}
            }
        }

        partial class Cloud_TW_GetLoadDetailsToDeleteRow
        {
            public Guid LoadId_Ext
            {
                get
                {
                    return this.LoadID;
                }
                set
                {
                    this.LoadID = value;
                }
            }

            public string LoadNo_Ext
            {
                get
                {
                    return this.LoadNo;
                }
                set
                {
                    this.LoadNo = value;
                }
            }

            public string LoadStatusID_Ext
            {
                get
                {
                    return this.LoadStatusID;
                }
                set
                {
                    this.LoadStatusID = value;
                }
            }

            public DateTime LastUpdatedTime_Ext
            {
                get
                {
                    return this.LastUpdatedTime;
                }
                set
                {
                    this.LastUpdatedTime = value;
                }
            }
        }
        /// <summary>
        /// LoadRow
        /// Partial Load row class to get and set datamembers
        /// </summary>
        partial class LoadRow
        {
            /// <summary>
            /// Id_Ext
            /// Properties for Id datamember
            /// </summary>
            public Guid Id_Ext
            {
                get
                {
                    return this.ID;
                }
                set
                {
                    this.ID = value;
                }
            }

            /// <summary>
            /// LoadNo_Ext
            /// Properties for LoadNo datamember
            /// </summary>
            public string LoadNo_Ext
            {
                get
                {
                    return this.LoadNo;
                }
                set
                {
                    this.LoadNo = value;
                }
            }

            /// <summary>
            /// CustomerID_Ext
            /// Properties for CustomerID datamember
            /// </summary>
            public string CustomerID_Ext
            {
                get
                {
                    return this.CustomerID;
                }
                set
                {
                    this.CustomerID = value;
                }
            }

            /// <summary>
            /// VehicleID_Ext
            /// Properties for VehicleID datamember
            /// </summary>
            public int VehicleID_Ext
            {
                get
                {
                    if (this.IsVehicleIDNull())
                    {
                        return 0;
                    }
                    return this.VehicleID;
                }
                set
                {
                    this.VehicleID = value;
                }
            }

            /// <summary>
            /// DriverID_Ext
            /// Properties for DriverID datamember
            /// </summary>
            public int DriverID_Ext
            {
                get
                {
                    if (this.IsDriverIDNull())
                    {
                        return 0;
                    }
                    return this.DriverID;
                }
                set
                {
                    this.DriverID = value;
                }
            }

            /// <summary>
            /// DriverID_Ext
            /// Properties for DriverID datamember
            /// </summary>
            public DateTime LastUpdatedTime_Ext
            {
                get
                {
                    return this.LastUpdatedTime;
                }
                set
                {
                    this.LastUpdatedTime = value;
                }
            }

            /// <summary>
            /// FSRule_BOLWaitTime_Ext
            /// Properties for FSRule_BOLWaitTime datamember
            /// </summary>                
            public Boolean FSRule_BOLWaitTime_Ext
            {
                get
                {
                    return this.FSRule_BOLWaitTime;
                }
                set
                {
                    this.FSRule_BOLWaitTime = value;
                }
            }

            /// <summary>
            /// FSRule_SiteWaitTime_Ext
            /// Properties for FSRule_SiteWaitTime datamember
            /// </summary>
            public Boolean FSRule_SiteWaitTime_Ext
            {
                get
                {
                    return this.FSRule_SiteWaitTime;
                }
                set
                {
                    this.FSRule_SiteWaitTime = value;
                }
            }

            /// <summary>
            /// FSRule_SplitLoad_Ext
            /// Properties for FSRule_SplitLoad datamember
            /// </summary>                
            public Boolean FSRule_SplitLoad_Ext
            {
                get
                {
                    return this.FSRule_SplitLoad;
                }
                set
                {
                    this.FSRule_SplitLoad = value;
                }
            }

            /// <summary>
            /// FSRule_SplitDrop_Ext
            /// Properties for FSRule_SplitDrop datamember
            /// </summary>                
            public Boolean FSRule_SplitDrop_Ext
            {
                get
                {
                    return this.FSRule_SplitDrop;
                }
                set
                {
                    this.FSRule_SplitDrop = value;
                }
            }

            /// <summary>
            /// FSRule_PumpOut_Ext
            /// Properties for FSRule_PumpOut datamember
            /// </summary>                
            public Boolean FSRule_PumpOut_Ext
            {
                get
                {
                    return this.FSRule_PumpOut;
                }
                set
                {
                    this.FSRule_PumpOut = value;
                }
            }

            /// <summary>
            /// FSRule_Diversion_Ext
            /// Properties for FSRule_Diversion datamember
            /// </summary>                
            public Boolean FSRule_Diversion_Ext
            {
                get
                {
                    return this.FSRule_Diversion;
                }
                set
                {
                    this.FSRule_Diversion = value;
                }
            }

            /// <summary>
            /// FSRule_MinLoad_Ext
            /// Properties for FSRule_MinLoad datamember
            /// </summary>                
            public Boolean FSRule_MinLoad_Ext
            {
                get
                {
                    return this.FSRule_MinLoad;
                }
                set
                {
                    this.FSRule_MinLoad = value;
                }
            }

            /// <summary>
            /// FSRule_Other_Ext
            /// Properties for FSRule_Other datamember
            /// </summary>               
            public Boolean FSRule_Other_Ext
            {
                get
                {
                    return this.FSRule_Other;
                }
                set
                {
                    this.FSRule_Other = value;
                }
            }

            /// <summary>
            /// FSRule_BOLWaitTime_Reason_Ext
            /// Properties for FSRule_BOLWaitTime_Reason datamember
            /// </summary>                
            public Boolean FSRule_BOLWaitTime_Reason_Ext
            {
                get
                {
                    return this.FSRule_BOLWaitTime_Reason;
                }
                set
                {
                    this.FSRule_BOLWaitTime_Reason = value;
                }
            }

            /// <summary>
            /// FSRule_SiteWaitTime_Reason_Ext
            /// Properties for FSRule_SiteWaitTime_Reason datamember
            /// </summary>
            public Boolean FSRule_SiteWaitTime_Reason_Ext
            {
                get
                {
                    return this.FSRule_SiteWaitTime_Reason;
                }
                set
                {
                    this.FSRule_SiteWaitTime_Reason = value;
                }
            }

            /// <summary>
            /// FSRule_SplitLoad_Reason_Ext
            /// Properties for FSRule_SplitLoad_Reason datamember
            /// </summary>                
            public Boolean FSRule_SplitLoad_Reason_Ext
            {
                get
                {
                    return this.FSRule_SplitLoad_Reason;
                }
                set
                {
                    this.FSRule_SplitLoad_Reason = value;
                }
            }

            /// <summary>
            /// FSRule_SplitDrop_Reason_Ext
            /// Properties for FSRule_SplitDrop_Reason datamember
            /// </summary>                
            public Boolean FSRule_SplitDrop_Reason_Ext
            {
                get
                {
                    return this.FSRule_SplitDrop_Reason;
                }
                set
                {
                    this.FSRule_SplitDrop_Reason = value;
                }
            }

            /// <summary>
            /// FSRule_PumpOut_Reason_Ext
            /// Properties for FSRule_PumpOut_Reason datamember
            /// </summary>                
            public Boolean FSRule_PumpOut_Reason_Ext
            {
                get
                {
                    return this.FSRule_PumpOut_Reason;
                }
                set
                {
                    this.FSRule_PumpOut_Reason = value;
                }
            }

            /// <summary>
            /// FSRule_Diversion_Reason_Ext
            /// Properties for FSRule_Diversion_Reason datamember
            /// </summary>                
            public Boolean FSRule_Diversion_Reason_Ext
            {
                get
                {
                    return this.FSRule_Diversion_Reason;
                }
                set
                {
                    this.FSRule_Diversion_Reason = value;
                }
            }

            /// <summary>
            /// FSRule_MinLoad_Reason_Ext
            /// Properties for FSRule_MinLoad_Reason datamember
            /// </summary>                
            public Boolean FSRule_MinLoad_Reason_Ext
            {
                get
                {
                    return this.FSRule_MinLoad_Reason;
                }
                set
                {
                    this.FSRule_MinLoad_Reason = value;
                }
            }

            /// <summary>
            /// FSRule_Other_Reason_Ext
            /// Properties for FSRule_Other_Reason datamember
            /// </summary>               
            public Boolean FSRule_Other_Reason_Ext
            {
                get
                {
                    return this.FSRule_Other_Reason;
                }
                set
                {
                    this.FSRule_Other_Reason = value;
                }
            }

            /// <summary>
            /// QtyTolerance_Ext
            /// Properties for QtyTolerance datamember
            /// </summary>               
            public decimal? QtyTolerance_Ext
            {
                get
                {
                    return IsQtyToleranceNull() ? (decimal?)null : (decimal?)QtyTolerance;
                }
                set
                {
                    this.QtyTolerance = value.Value;
                }
            }

            /// <summary>
            /// PercentTolerance_Ext
            /// Properties for PercentTolerance datamember
            /// </summary>               
            public decimal? PercentTolerance_Ext
            {
                get
                {
                    return IsPercentToleranceNull() ? (decimal?)null : (decimal?)PercentTolerance;
                }
                set
                {
                    this.PercentTolerance = value.Value;
                }
            }

            /// <summary>
            /// OrderLoadReviewEnabled_Ext
            /// Properties for OrderLoadReviewEnabled datamember
            /// </summary>               
            public string OrderLoadReviewEnabled_Ext
            {
                get
                {
                    return OrderLoadReviewEnabled;
                }
                set
                {
                    this.OrderLoadReviewEnabled = value;
                }
            }

            /// <summary>
            /// UndispatchRequest_Ext
            /// Properties for UndispatchRequest datamember
            /// </summary>               
            public int? UndispatchRequest_Ext
            {
                get
                {
                    return IsUndispatchRequestNull() ? (int?)null : UndispatchRequest;
                }
                set
                {
                    this.UndispatchRequest = value.Value;
                }
            }

            /// <summary>
            /// Undispatched_Ext
            /// Properties for Undispatched datamember
            /// </summary>               
            public int? Undispatched_Ext
            {
                get
                {
                    return IsUndispatchedNull() ? (int?)null : Undispatched;
                }
                set
                {
                    this.Undispatched = value.Value;
                }
            }
            /// <summary>
            /// LoadType_Ext
            /// Properties for LoadType datamember
            /// </summary>               
            public string LoadType_Ext
            {
                get
                {
                    return LoadType;
                }
                set
                {
                    this.LoadType = value;
                }
            }

            public Boolean FromSiteBSRule_Ext
            {
                get
                {
                    return Convert.ToBoolean(FromSiteBSRule);
                }
                set
                {
                    this.FromSiteBSRule = value;
                }
            }
            // 2014.01.23  Ramesh M Added For CR#61759 Added ShipToID
            /// <summary>
            /// 
            /// </summary>
            public int? ShipToID_Ext
            {
                get
                {
                    return IsShipToIDNull() ? (int?)null : ShipToID;
                }
                set
                {
                    this.ShipToID = value.Value;
                }
            }
            // 2014.01.30  Ramesh M Added For CR#62038 Added AllowDriversToChangeMultiBOL
            public Boolean MultiBOLBSRule_Ext
            {
                get
                {
                    return Convert.ToBoolean(MultiBOLBSRule);
                }
                set
                {
                    this.MultiBOLBSRule = value;
                }
            }

            public DateTime? LastStatusUpdatedDateTime_Ext
            {
                get
                {
                    if (IsLastStatusUpdatedDateTimeNull())
                    {
                        return null;
                    }
                    else
                    {
                        return LastStatusUpdatedDateTime;
                    }
                }
                set
                {
                    this.LastStatusUpdatedDateTime = (DateTime)value;
                }
            }

            //public Boolean IsDeleted_Ext
            //{
            //    get
            //    {
            //        return this.IsDeleted;
            //    }
            //    set
            //    {
            //        this.IsDeleted = value;
            //    }
            //}
        }

        /// <summary>
        /// WarehouseLoadRow
        /// Partial WarehouseLoad row class to get and set datamembers
        /// </summary>
        partial class WarehouseLoadRow
        {
            /// <summary>
            /// Id_Ext
            /// Properties for Id datamember
            /// </summary>
            public Guid Id_Ext
            {
                get
                {
                    return this.ID;
                }
                set
                {
                    this.ID = value;
                }
            }

            /// <summary>
            /// LoadNo_Ext
            /// Properties for LoadNo datamember
            /// </summary>
            public string LoadNo_Ext
            {
                get
                {
                    return this.LoadNo;
                }
                set
                {
                    this.LoadNo = value;
                }
            }

            /// <summary>
            /// CustomerID_Ext
            /// Properties for CustomerID datamember
            /// </summary>
            public string CustomerID_Ext
            {
                get
                {
                    return this.CustomerID;
                }
                set
                {
                    this.CustomerID = value;
                }
            }

            /// <summary>
            /// VehicleID_Ext
            /// Properties for VehicleID datamember
            /// </summary>
            public int VehicleID_Ext
            {
                get
                {
                    if (this.IsVehicleIDNull())
                    {
                        return 0;
                    }
                    return this.VehicleID;
                }
                set
                {
                    this.VehicleID = value;
                }
            }

            /// <summary>
            /// DriverID_Ext
            /// Properties for DriverID datamember
            /// </summary>
            public int DriverID_Ext
            {
                get
                {
                    if (this.IsDriverIDNull())
                    {
                        return 0;
                    }
                    return this.DriverID;
                }
                set
                {
                    this.DriverID = value;
                }
            }



            /// <summary>
            /// FSRule_BOLWaitTime_Ext
            /// Properties for FSRule_BOLWaitTime datamember
            /// </summary>                
            public Boolean FSRule_BOLWaitTime_Ext
            {
                get
                {
                    return this.FSRule_BOLWaitTime;
                }
                set
                {
                    this.FSRule_BOLWaitTime = value;
                }
            }

            /// <summary>
            /// FSRule_SiteWaitTime_Ext
            /// Properties for FSRule_SiteWaitTime datamember
            /// </summary>
            public Boolean FSRule_SiteWaitTime_Ext
            {
                get
                {
                    return this.FSRule_SiteWaitTime;
                }
                set
                {
                    this.FSRule_SiteWaitTime = value;
                }
            }

            /// <summary>
            /// FSRule_SplitLoad_Ext
            /// Properties for FSRule_SplitLoad datamember
            /// </summary>                
            public Boolean FSRule_SplitLoad_Ext
            {
                get
                {
                    return this.FSRule_SplitLoad;
                }
                set
                {
                    this.FSRule_SplitLoad = value;
                }
            }

            /// <summary>
            /// FSRule_SplitDrop_Ext
            /// Properties for FSRule_SplitDrop datamember
            /// </summary>                
            public Boolean FSRule_SplitDrop_Ext
            {
                get
                {
                    return this.FSRule_SplitDrop;
                }
                set
                {
                    this.FSRule_SplitDrop = value;
                }
            }

            /// <summary>
            /// FSRule_PumpOut_Ext
            /// Properties for FSRule_PumpOut datamember
            /// </summary>                
            public Boolean FSRule_PumpOut_Ext
            {
                get
                {
                    return this.FSRule_PumpOut;
                }
                set
                {
                    this.FSRule_PumpOut = value;
                }
            }

            /// <summary>
            /// FSRule_Diversion_Ext
            /// Properties for FSRule_Diversion datamember
            /// </summary>                
            public Boolean FSRule_Diversion_Ext
            {
                get
                {
                    return this.FSRule_Diversion;
                }
                set
                {
                    this.FSRule_Diversion = value;
                }
            }

            /// <summary>
            /// FSRule_MinLoad_Ext
            /// Properties for FSRule_MinLoad datamember
            /// </summary>                
            public Boolean FSRule_MinLoad_Ext
            {
                get
                {
                    return this.FSRule_MinLoad;
                }
                set
                {
                    this.FSRule_MinLoad = value;
                }
            }

            /// <summary>
            /// FSRule_Other_Ext
            /// Properties for FSRule_Other datamember
            /// </summary>               
            public Boolean FSRule_Other_Ext
            {
                get
                {
                    return this.FSRule_Other;
                }
                set
                {
                    this.FSRule_Other = value;
                }
            }

            /// <summary>
            /// FSRule_BOLWaitTime_Reason_Ext
            /// Properties for FSRule_BOLWaitTime_Reason datamember
            /// </summary>                
            public Boolean FSRule_BOLWaitTime_Reason_Ext
            {
                get
                {
                    return this.FSRule_BOLWaitTime_Reason;
                }
                set
                {
                    this.FSRule_BOLWaitTime_Reason = value;
                }
            }

            /// <summary>
            /// FSRule_SiteWaitTime_Reason_Ext
            /// Properties for FSRule_SiteWaitTime_Reason datamember
            /// </summary>
            public Boolean FSRule_SiteWaitTime_Reason_Ext
            {
                get
                {
                    return this.FSRule_SiteWaitTime_Reason;
                }
                set
                {
                    this.FSRule_SiteWaitTime_Reason = value;
                }
            }

            /// <summary>
            /// FSRule_SplitLoad_Reason_Ext
            /// Properties for FSRule_SplitLoad_Reason datamember
            /// </summary>                
            public Boolean FSRule_SplitLoad_Reason_Ext
            {
                get
                {
                    return this.FSRule_SplitLoad_Reason;
                }
                set
                {
                    this.FSRule_SplitLoad_Reason = value;
                }
            }

            /// <summary>
            /// FSRule_SplitDrop_Reason_Ext
            /// Properties for FSRule_SplitDrop_Reason datamember
            /// </summary>                
            public Boolean FSRule_SplitDrop_Reason_Ext
            {
                get
                {
                    return this.FSRule_SplitDrop_Reason;
                }
                set
                {
                    this.FSRule_SplitDrop_Reason = value;
                }
            }

            /// <summary>
            /// FSRule_PumpOut_Reason_Ext
            /// Properties for FSRule_PumpOut_Reason datamember
            /// </summary>                
            public Boolean FSRule_PumpOut_Reason_Ext
            {
                get
                {
                    return this.FSRule_PumpOut_Reason;
                }
                set
                {
                    this.FSRule_PumpOut_Reason = value;
                }
            }

            /// <summary>
            /// FSRule_Diversion_Reason_Ext
            /// Properties for FSRule_Diversion_Reason datamember
            /// </summary>                
            public Boolean FSRule_Diversion_Reason_Ext
            {
                get
                {
                    return this.FSRule_Diversion_Reason;
                }
                set
                {
                    this.FSRule_Diversion_Reason = value;
                }
            }

            /// <summary>
            /// FSRule_MinLoad_Reason_Ext
            /// Properties for FSRule_MinLoad_Reason datamember
            /// </summary>                
            public Boolean FSRule_MinLoad_Reason_Ext
            {
                get
                {
                    return this.FSRule_MinLoad_Reason;
                }
                set
                {
                    this.FSRule_MinLoad_Reason = value;
                }
            }

            /// <summary>
            /// FSRule_Other_Reason_Ext
            /// Properties for FSRule_Other_Reason datamember
            /// </summary>               
            public Boolean FSRule_Other_Reason_Ext
            {
                get
                {
                    return this.FSRule_Other_Reason;
                }
                set
                {
                    this.FSRule_Other_Reason = value;
                }
            }

            /// <summary>
            /// QtyTolerance_Ext
            /// Properties for QtyTolerance datamember
            /// </summary>               
            public decimal? QtyTolerance_Ext
            {
                get
                {
                    return IsQtyToleranceNull() ? (decimal?)null : (decimal?)QtyTolerance;
                }
                set
                {
                    this.QtyTolerance = value.Value;
                }
            }

            /// <summary>
            /// PercentTolerance_Ext
            /// Properties for PercentTolerance datamember
            /// </summary>               
            public decimal? PercentTolerance_Ext
            {
                get
                {
                    return IsPercentToleranceNull() ? (decimal?)null : (decimal?)PercentTolerance;
                }
                set
                {
                    this.PercentTolerance = value.Value;
                }
            }

            /// <summary>
            /// OrderLoadReviewEnabled_Ext
            /// Properties for OrderLoadReviewEnabled datamember
            /// </summary>               
            public string OrderLoadReviewEnabled_Ext
            {
                get
                {
                    return OrderLoadReviewEnabled;
                }
                set
                {
                    this.OrderLoadReviewEnabled = value;
                }
            }

            /// <summary>
            /// UndispatchRequest_Ext
            /// Properties for UndispatchRequest datamember
            /// </summary>               
            public int? UndispatchRequest_Ext
            {
                get
                {
                    return IsUndispatchRequestNull() ? (int?)null : UndispatchRequest;
                }
                set
                {
                    this.UndispatchRequest = value.Value;
                }
            }

            /// <summary>
            /// Undispatched_Ext
            /// Properties for Undispatched datamember
            /// </summary>               
            public int? Undispatched_Ext
            {
                get
                {
                    return IsUndispatchedNull() ? (int?)null : Undispatched;
                }
                set
                {
                    this.Undispatched = value.Value;
                }
            }
            /// <summary>
            /// LoadType_Ext
            /// Properties for LoadType datamember
            /// </summary>
            public string LoadType_Ext
            {
                get
                {
                    return this.LoadType;
                }
                set
                {
                    this.LoadType = value;
                }
            }
            /// <summary>
            /// AssignedDriverID_Ext
            /// Properties for AssignedDriverID datamember
            /// </summary>               
            public int? AssignedDriverID_Ext
            {
                get
                {
                    return IsAssignedDriverIDNull() ? (int?)null : AssignedDriverID;
                }
                set
                {
                    this.AssignedDriverID = value.Value;
                }
            }
            /// <summary>
            /// AssignedDriverName_Ext
            /// Properties for AssignedDriverName datamember
            /// </summary>               
            public string AssignedDriverName_Ext
            {
                get
                {
                    return this.AssignedDriverName;
                }
                set
                {
                    this.AssignedDriverName = value;
                }
            }

            /// <summary>
            /// AssignedVehicleCode_Ext
            /// Properties for AssignedVehicleCode datamember
            /// </summary>               
            public string AssignedVehicleCode_Ext
            {
                get
                {
                    return this.AssignedVehicleCode;
                }
                set
                {
                    this.AssignedVehicleCode = value;
                }
            }


        }

        /// <summary>
        /// Cloud_GetLoadBasedBOLDetailsRow
        /// Partial Cloud_GetLoadBasedBOLDetailsRow row class to get and set datamembers
        /// </summary>
        partial class Cloud_GetLoadBasedBOLDetailsRow
        {
            /// <summary>
            /// Id_Ext
            /// Properties for Id datamember
            /// </summary>
            public Guid Id_Ext
            {
                get
                {
                    return this.ID;
                }
                set
                {
                    this.ID = value;
                }
            }

            /// <summary>
            /// LoadID_Ext
            /// Properties for LoadID datamember
            /// </summary>
            public Guid LoadID_Ext
            {
                get
                {
                    return this.LoadID;
                }
                set
                {
                    this.LoadID = value;
                }
            }

            /// <summary>
            /// BolNo_Ext
            /// Properties for BolNo datamember
            /// </summary>
            public String BolNo_Ext
            {
                get
                {
                    return this.BOLNo;
                }
                set
                {
                    this.BOLNo = value;
                }
            }

            /// <summary>
            /// Image_Ext
            /// Properties for Image datamember
            /// </summary>
            public Byte[] Image_Ext
            {
                get
                {
                    return IsImageNull() ? null : this.Image;
                }
                set
                {
                    this.Image = value;
                }
            }

            /// <summary>
            /// BOLDateTime_Ext
            /// Properties for BOLDateTime datamember
            /// </summary>
            public DateTime BOLDateTime_Ext
            {
                get
                {
                    return this.BOLDateTime;
                }
                set
                {
                    this.BOLDateTime = value;
                }
            }

            /// <summary>
            /// BOLWaitTime_Ext
            /// Properties for BOLWaitTime datamember
            /// </summary>
            public Boolean BOLWaitTime_Ext
            {
                get
                {
                    return this.BOLWaitTime;
                }
                set
                {
                    this.BOLWaitTime = value;
                }
            }

            /// <summary>
            /// BOLWaitTime_Comment_Ext
            /// Properties for BOLWaitTime_Comment datamember
            /// </summary>
            public String BOLWaitTime_Comment_Ext
            {
                get
                {
                    if (this.IsBOLWaitTime_CommentNull())
                    {
                        return null;
                    }
                    else
                    {
                        return this.BOLWaitTime_Comment;
                    }
                }
                set
                {
                    this.BOLWaitTime_Comment = value;
                }
            }

            /// <summary>
            /// BOLWaitTime_Start_Ext
            /// Properties for BOLWaitTime_Start datamember
            /// </summary>
            public DateTime? BOLWaitTime_Start_Ext
            {
                get
                {
                    if (this.IsBOLWaitTime_StartNull())
                    {
                        return null;
                    }
                    else
                    {
                        return this.BOLWaitTime_Start;
                    }
                }
                set
                {
                    if (value != null)
                    {
                        this.BOLWaitTime_Start = value.Value;
                    }
                    else
                    {
                        this.SetBOLWaitTime_StartNull();
                    }
                }
            }

            /// <summary>
            /// BOLWaitTime_End_Ext
            /// Properties for BOLWaitTime_End datamember
            /// </summary>
            public DateTime? BOLWaitTime_End_Ext
            {
                get
                {
                    if (this.IsBOLWaitTime_EndNull())
                    {
                        return null;
                    }
                    else
                    {
                        return this.BOLWaitTime_End;
                    }
                }
                set
                {
                    if (value != null)
                    {
                        this.BOLWaitTime_End = value.Value;
                    }
                    else
                    {
                        this.SetBOLWaitTime_EndNull();
                    }
                }
            }

            /// <summary>
            /// TrailerCode_Ext
            /// Properties for TrailerCode_Ext datamember
            /// </summary>
            public String TrailerCode_Ext
            {
                get
                {
                    if (this.IsTrailerCodeNull())
                    {
                        return null;
                    }
                    else
                    {
                        return this.TrailerCode;
                    }
                }
                set
                {
                    this.TrailerCode = value;
                }
            }

            /// <summary>
            /// TrailerCode_Ext
            /// Properties for TrailerCode_Ext datamember
            /// </summary>
            public String SupplierCode_Ext
            {
                get
                {
                    if (this.IsSupplierCodeNull())
                    {
                        return null;
                    }
                    else
                    {
                        return this.SupplierCode;
                    }
                }
                set
                {
                    this.SupplierCode = value;
                }
            }

            /// <summary>
            /// TrailerCode_Ext
            /// Properties for TrailerCode_Ext datamember
            /// </summary>
            public String SupplyPointCode_Ext
            {
                get
                {
                    if (this.IsSupplyPointCodeNull())
                    {
                        return null;
                    }
                    else
                    {
                        return this.SupplyPointCode;
                    }
                }
                set
                {
                    this.SupplyPointCode = value;
                }
            }

        }

        /// <summary>
        /// BOLHdrRow
        /// Partial BOL header row class to get and set datamembers
        /// </summary>
        partial class BOLHdrRow
        {
            /// <summary>
            /// Id_Ext
            /// Properties for Id datamember
            /// </summary>
            public Guid Id_Ext
            {
                get
                {
                    return this.ID;
                }
                set
                {
                    this.ID = value;
                }
            }

            /// <summary>
            /// LoadID_Ext
            /// Properties for LoadID datamember
            /// </summary>
            public Guid LoadID_Ext
            {
                get
                {
                    return this.LoadID;
                }
                set
                {
                    this.LoadID = value;
                }
            }

            /// <summary>
            /// BolNo_Ext
            /// Properties for BolNo datamember
            /// </summary>
            public String BolNo_Ext
            {
                get
                {
                    return this.BOLNo;
                }
                set
                {
                    this.BOLNo = value;
                }
            }

            /// <summary>
            /// Image_Ext
            /// Properties for Image datamember
            /// </summary>
            public Byte[] Image_Ext
            {
                get
                {
                    return IsImageNull() ? null : this.Image;
                }
                set
                {
                    this.Image = value;
                }
            }

            /// <summary>
            /// BOLDateTime_Ext
            /// Properties for BOLDateTime datamember
            /// </summary>
            public DateTime BOLDateTime_Ext
            {
                get
                {
                    return this.BOLDateTime;
                }
                set
                {
                    this.BOLDateTime = value;
                }
            }

            /// <summary>
            /// BOLWaitTime_Ext
            /// Properties for BOLWaitTime datamember
            /// </summary>
            public Boolean BOLWaitTime_Ext
            {
                get
                {
                    return this.BOLWaitTime;
                }
                set
                {
                    this.BOLWaitTime = value;
                }
            }

            /// <summary>
            /// BOLWaitTime_Comment_Ext
            /// Properties for BOLWaitTime_Comment datamember
            /// </summary>
            public String BOLWaitTime_Comment_Ext
            {
                get
                {
                    if (this.IsBOLWaitTime_CommentNull())
                    {
                        return null;
                    }
                    else
                    {
                        return this.BOLWaitTime_Comment;
                    }
                }
                set
                {
                    this.BOLWaitTime_Comment = value;
                }
            }

            /// <summary>
            /// BOLWaitTime_Start_Ext
            /// Properties for BOLWaitTime_Start datamember
            /// </summary>
            public DateTime? BOLWaitTime_Start_Ext
            {
                get
                {
                    if (this.IsBOLWaitTime_StartNull())
                    {
                        return null;
                    }
                    else
                    {
                        return this.BOLWaitTime_Start;
                    }
                }
                set
                {
                    if (value != null)
                    {
                        this.BOLWaitTime_Start = value.Value;
                    }
                    else
                    {
                        this.SetBOLWaitTime_StartNull();
                    }
                }
            }

            /// <summary>
            /// BOLWaitTime_End_Ext
            /// Properties for BOLWaitTime_End datamember
            /// </summary>
            public DateTime? BOLWaitTime_End_Ext
            {
                get
                {
                    if (this.IsBOLWaitTime_EndNull())
                    {
                        return null;
                    }
                    else
                    {
                        return this.BOLWaitTime_End;
                    }
                }
                set
                {
                    if (value != null)
                    {
                        this.BOLWaitTime_End = value.Value;
                    }
                    else
                    {
                        this.SetBOLWaitTime_EndNull();
                    }
                }
            }

            /// <summary>
            /// TrailerCode_Ext
            /// Properties for TrailerCode_Ext datamember
            /// </summary>
            public String TrailerCode_Ext
            {
                get
                {
                    if (this.IsTrailerCodeNull())
                    {
                        return null;
                    }
                    else
                    {
                        return this.TrailerCode;
                    }
                }
                set
                {
                    this.TrailerCode = value;
                }
            }

            /// <summary>
            /// TrailerCode_Ext
            /// Properties for TrailerCode_Ext datamember
            /// </summary>
            public String SupplierCode_Ext
            {
                get
                {
                    if (this.IsSupplierCodeNull())
                    {
                        return null;
                    }
                    else
                    {
                        return this.SupplierCode;
                    }
                }
                set
                {
                    this.SupplierCode = value;
                }
            }

            /// <summary>
            /// TrailerCode_Ext
            /// Properties for TrailerCode_Ext datamember
            /// </summary>
            public String SupplyPointCode_Ext
            {
                get
                {
                    if (this.IsSupplyPointCodeNull())
                    {
                        return null;
                    }
                    else
                    {
                        return this.SupplyPointCode;
                    }
                }
                set
                {
                    this.SupplyPointCode = value;
                }
            }

        }

        /// <summary>
        /// BOLItemRow
        /// Partial BOL item row class to get and set datamembers
        /// </summary>
        partial class BOLItemRow
        {
            /// <summary>
            /// Id_Ext
            /// Properties for Id datamember
            /// </summary>
            public Guid Id_Ext
            {
                get
                {
                    return this.ID;
                }
                set
                {
                    this.ID = value;
                }
            }

            /// <summary>
            /// BOLHdrID_Ext
            /// Properties for BOLHdrID datamember
            /// </summary>
            public Guid BOLHdrID_Ext
            {
                get
                {
                    return this.BOLHdrID;
                }
                set
                {
                    this.BOLHdrID = value;
                }
            }

            /// <summary>
            /// SysTrxNo_Ext
            /// Properties for SysTrxNo datamember
            /// </summary>
            public Decimal SysTrxNo_Ext
            {
                get
                {
                    return this.SysTrxNo;
                }
                set
                {
                    this.SysTrxNo = value;
                }
            }

            /// <summary>
            /// SysTrxLine_Ext
            /// Properties for SysTrxLine datamember
            /// </summary>
            public Int32 SysTrxLine_Ext
            {
                get
                {
                    return this.SysTrxLine;
                }
                set
                {
                    this.SysTrxLine = value;
                }
            }

            /// <summary>
            /// ComponentNo_Ext
            /// Properties for ComponentNo datamember
            /// </summary>
            public Int32 ComponentNo_Ext
            {
                get
                {
                    return this.ComponentNo;
                }
                set
                {
                    this.ComponentNo = value;
                }
            }

            /// <summary>
            /// GrossQty_Ext
            /// Properties for GrossQty datamember
            /// </summary>
            public Decimal GrossQty_Ext
            {
                get
                {
                    return this.GrossQty;
                }
                set
                {
                    this.GrossQty = value;
                }
            }

            /// <summary>
            /// NetQty_Ext
            /// Properties for NetQty datamember
            /// </summary>
            public Decimal NetQty_Ext
            {
                get
                {
                    return this.NetQty;
                }
                set
                {
                    this.NetQty = value;
                }
            }


            /// <summary>
            /// BOLQtyVarianceReason_Ext
            /// Properties for BOLQtyVarianceReason  datamember
            /// </summary>
            public String BOLQtyVarianceReason_Ext
            {
                get
                {
                    return IsBOLQtyVarianceReasonNull() ? null : this.BOLQtyVarianceReason;
                }
                set
                {
                    this.BOLQtyVarianceReason = value;
                }
            }
        }

        /// <summary>
        /// DeliveryDetailsRow
        /// Partial DeliveryDetails row class to get and set datamembers
        /// </summary>
        partial class DeliveryDetailsRow
        {
            /// <summary>
            /// OrderItemID_Ext
            /// Properties for OrderItemID datamember
            /// </summary>
            public Guid OrderItemID_Ext
            {
                get
                {
                    return this.OrderItemID;
                }
                set
                {
                    this.OrderItemID = value;
                }
            }

            /// <summary>
            /// ID_Ext
            /// Properties for ID datamember
            /// </summary>
            public Guid ID_Ext
            {
                get
                {
                    return this.ID;
                }
                set
                {
                    this.ID = value;
                }
            }

            /// <summary>
            /// GrossQty_Ext
            /// Properties for GrossQty datamember
            /// </summary>
            public Decimal GrossQty_Ext
            {
                get
                {
                    return this.GrossQty;
                }
                set
                {
                    this.GrossQty = value;
                }
            }

            /// <summary>
            /// NetQty_Ext
            /// Properties for NetQty datamember
            /// </summary>
            public Decimal NetQty_Ext
            {
                get
                {
                    return this.NetQty;
                }
                set
                {
                    this.NetQty = value;
                }
            }

            /// <summary>
            /// DeliveryDateTime_Ext
            /// Properties for DeliveryDateTime datamember
            /// </summary>
            public DateTime DeliveryDateTime_Ext
            {
                get
                {
                    return this.DeliveryDateTime;
                }
                set
                {
                    this.DeliveryDateTime = value;
                }
            }

            /// <summary>
            /// BeforeVolume_Ext
            /// Properties for BeforeVolume datamember
            /// </summary>
            public Decimal? BeforeVolume_Ext
            {
                get
                {
                    return IsBeforeVolumeNull() ? Convert.ToDecimal(null) : this.BeforeVolume;
                }
                set
                {
                    if (value == null)
                    {
                        this.SetBeforeVolumeNull();
                    }
                    else
                    {
                        this.BeforeVolume = Convert.ToDecimal(value);
                    }
                }
            }

            /// <summary>
            /// AfterVolume
            /// Properties for AfterVolume datamember
            /// </summary>
            public Decimal? AfterVolume_Ext
            {
                get
                {
                    return IsAfterVolumeNull() ? Convert.ToDecimal(null) : this.AfterVolume;
                }
                set
                {
                    if (value == null)
                    {
                        this.SetAfterVolumeNull();
                    }
                    else
                    {
                        this.AfterVolume = Convert.ToDecimal(value);
                    }
                }
            }


            /// <summary>
            /// DeliveryQtyVarianceReason_Ext
            /// Properties for DeliveryQtyVarianceReason datamember
            /// </summary>
            public String DeliveryQtyVarianceReason_Ext
            {
                get
                {
                    return IsDeliveryQtyVarianceReasonNull() ? null : this.DeliveryQtyVarianceReason;
                }
                set
                {
                    this.DeliveryQtyVarianceReason = value;
                }
            }

            /// <summary>
            /// DeliveryQtyVarianceReason_Ext
            /// Properties for DeliveryQtyVarianceReason datamember
            /// </summary>
            public String BOLNo_Ext
            {
                get
                {
                    return IsBOLNoNull() ? null : this.BOLNo;
                }
                set
                {
                    this.BOLNo = value;
                }
            }



        }

        partial class Cloud_GetDeliveryHistoryRow
        {
            /// <summary>
            /// OrderItemID_Ext
            /// Properties for OrderItemID datamember
            /// </summary>
            public Guid OrderItemID_Ext
            {
                get
                {
                    return this.OrderItemID;
                }
                set
                {
                    this.OrderItemID = value;
                }
            }

            /// <summary>
            /// ID_Ext
            /// Properties for ID datamember
            /// </summary>
            public Guid ID_Ext
            {
                get
                {
                    return this.ID;
                }
                set
                {
                    this.ID = value;
                }
            }

            /// <summary>
            /// GrossQty_Ext
            /// Properties for GrossQty datamember
            /// </summary>
            public Decimal GrossQty_Ext
            {
                get
                {
                    return this.GrossQty;
                }
                set
                {
                    this.GrossQty = value;
                }
            }

            /// <summary>
            /// NetQty_Ext
            /// Properties for NetQty datamember
            /// </summary>
            public Decimal NetQty_Ext
            {
                get
                {
                    return this.NetQty;
                }
                set
                {
                    this.NetQty = value;
                }
            }

            /// <summary>
            /// DeliveryDateTime_Ext
            /// Properties for DeliveryDateTime datamember
            /// </summary>
            public DateTime DeliveryDateTime_Ext
            {
                get
                {
                    return this.DeliveryDateTime;
                }
                set
                {
                    this.DeliveryDateTime = value;
                }
            }

            /// <summary>
            /// BeforeVolume_Ext
            /// Properties for BeforeVolume datamember
            /// </summary>
            public Decimal? BeforeVolume_Ext
            {
                get
                {
                    return IsBeforeVolumeNull() ? Convert.ToDecimal(null) : this.BeforeVolume;
                }
                set
                {
                    if (value == null)
                    {
                        this.SetBeforeVolumeNull();
                    }
                    else
                    {
                        this.BeforeVolume = Convert.ToDecimal(value);
                    }
                }
            }

            /// <summary>
            /// AfterVolume
            /// Properties for AfterVolume datamember
            /// </summary>
            public Decimal? AfterVolume_Ext
            {
                get
                {
                    return IsAfterVolumeNull() ? Convert.ToDecimal(null) : this.AfterVolume;
                }
                set
                {
                    if (value == null)
                    {
                        this.SetAfterVolumeNull();
                    }
                    else
                    {
                        this.AfterVolume = Convert.ToDecimal(value);
                    }
                }
            }


            /// <summary>
            /// DeliveryQtyVarianceReason_Ext
            /// Properties for DeliveryQtyVarianceReason datamember
            /// </summary>
            public String DeliveryQtyVarianceReason_Ext
            {
                get
                {
                    return IsDeliveryQtyVarianceReasonNull() ? null : this.DeliveryQtyVarianceReason;
                }
                set
                {
                    this.DeliveryQtyVarianceReason = value;
                }
            }

            /// <summary>
            /// DeliveryQtyVarianceReason_Ext
            /// Properties for DeliveryQtyVarianceReason datamember
            /// </summary>
            public String BOLNo_Ext
            {
                get
                {
                    return this.BOLNo;
                }
                set
                {
                    this.BOLNo = value;
                }
            }
        }

        /// <summary>
        /// DeliveryDetailsRow
        /// Partial DeliveryDetails row class to get and set datamembers
        /// </summary>
        partial class Cloud_GetDeliveryDataRow
        {

            /// <summary>
            /// GrossQty_Ext
            /// Properties for GrossQty datamember
            /// </summary>
            public Decimal GrossQty_Ext
            {
                get
                {
                    return this.GrossQty;
                }
                set
                {
                    this.GrossQty = value;
                }
            }

            /// <summary>
            /// NetQty_Ext
            /// Properties for NetQty datamember
            /// </summary>
            public Decimal NetQty_Ext
            {
                get
                {
                    return this.NetQty;
                }
                set
                {
                    this.NetQty = value;
                }
            }


            /// <summary>
            /// BeforeVolume_Ext
            /// Properties for BeforeVolume datamember
            /// </summary>
            public String BeforeVolume_Ext
            {
                get
                {
                    return this.BeforeVolume;
                }
                set
                {
                    this.BeforeVolume = value;
                }
            }

            /// <summary>
            /// AfterVolume
            /// Properties for AfterVolume datamember
            /// </summary>
            public String AfterVolume_Ext
            {
                get
                {
                    return this.AfterVolume;
                }
                set
                {
                    this.AfterVolume = value;
                }
            }


            /// <summary>
            /// DeliveryQtyVarianceReason_Ext
            /// Properties for DeliveryQtyVarianceReason datamember
            /// </summary>
            public String DeliveryQtyVarianceReason_Ext
            {
                get
                {
                    return IsDeliveryQtyVarianceReasonNull() ? null : this.DeliveryQtyVarianceReason;
                }
                set
                {
                    this.DeliveryQtyVarianceReason = value;
                }
            }

            /// <summary>
            /// DeliveryQtyVarianceReason_Ext
            /// Properties for DeliveryQtyVarianceReason datamember
            /// </summary>
            public String BOLNo_Ext
            {
                get
                {
                    return this.BOLNo;
                }
                set
                {
                    this.BOLNo = value;
                }
            }
        }

        /// <summary>
        /// OrderItemComponentRow
        /// Partial OrderItemComponent row class to get and set datamembers
        /// </summary>
        partial class OrderItemComponentRow
        {
            /// <summary>
            /// Id_Ext
            /// Properties for Id datamember
            /// </summary>
            public Guid Id_Ext
            {
                get
                {
                    return this.ID;
                }
                set
                {
                    this.ID = value;
                }
            }

            /// <summary>
            /// OrderItemID_Ext
            /// Properties for OrderItemID datamember
            /// </summary>
            public Guid OrderItemID_Ext
            {
                get
                {
                    return this.OrderItemID;
                }
                set
                {
                    this.OrderItemID = value;
                }
            }

            /// <summary>
            /// ComponentNo_Ext
            /// Properties for ComponentNo datamember
            /// </summary>
            public int ComponentNo_Ext
            {
                get
                {
                    return this.ComponentNo;
                }
                set
                {
                    this.ComponentNo = value;
                }
            }

            /// <summary>
            /// Qty_Ext
            /// Properties for Qty datamember
            /// </summary>
            public Decimal Qty_Ext
            {
                get
                {
                    return this.IsQtyNull() ? 0.0M : this.Qty;
                }
                set
                {
                    this.Qty = value;
                }
            }

            /// <summary>
            /// ProdCode_Ext
            /// Properties for ProdCode datamember
            /// </summary>
            public String ProdCode_Ext
            {
                get
                {
                    return this.IsProdCodeNull() ? null : this.ProdCode;
                }
                set
                {
                    this.ProdCode = value;
                }
            }

            /// <summary>
            /// ProdName_Ext
            /// Properties for ProdName datamember
            /// </summary>
            public String ProdName_Ext
            {
                get
                {
                    return this.IsProdNameNull() ? null : this.ProdName;
                }
                set
                {
                    this.ProdName = value;
                }
            }

            /// <summary>
            /// ProdUOM_Ext
            /// Properties for ProdUOM datamember
            /// </summary>
            public String ProdUOM_Ext
            {
                get
                {
                    return this.IsProdUOMNull() ? null : this.ProdUOM;
                }
                set
                {
                    this.ProdUOM = value;
                }
            }

            /// <summary>
            /// SupplierName_Ext
            /// Properties for SupplierName datamember
            /// </summary>
            public String SupplierName_Ext
            {
                get
                {
                    return this.IsSupplierNameNull() ? null : this.SupplierName;
                }
                set
                {
                    this.SupplierName = value;
                }
            }

            /// <summary>
            /// SupplierCode_Ext
            /// Properties for SupplierCode datamember
            /// </summary>
            public String SupplierCode_Ext
            {
                get
                {
                    return this.IsSupplierCodeNull() ? null : this.SupplierCode;
                }
                set
                {
                    this.SupplierCode = value;
                }
            }

            /// <summary>
            /// SupplyPointName_Ext
            /// Properties for SupplyPointName datamember
            /// </summary>
            public String SupplyPointName_Ext
            {
                get
                {
                    return this.IsSupplyPointNameNull() ? null : this.SupplyPointName;
                }
                set
                {
                    this.SupplyPointName = value;
                }
            }

            /// <summary>
            /// SupplyPointCode_Ext
            /// Properties for SupplyPointCode datamember
            /// </summary>
            public String SupplyPointCode_Ext
            {
                get
                {
                    return this.IsSupplyPointCodeNull() ? null : this.SupplyPointCode;
                }
                set
                {
                    this.SupplyPointCode = value;
                }
            }

            /// <summary>
            /// SupplyPointAddress1_Ext
            /// Properties for SupplyPointAddress1 datamember
            /// </summary>
            public String SupplyPointAddress1_Ext
            {
                get
                {
                    return this.IsSupplyPointAddress1Null() ? null : this.SupplyPointAddress1;
                }
                set
                {
                    this.SupplyPointAddress1 = value;
                }
            }

            /// <summary>
            /// SupplyPointAddress2_Ext
            /// Properties for SupplyPointAddress2 datamember
            /// </summary>
            public String SupplyPointAddress2_Ext
            {
                get
                {
                    return this.IsSupplyPointAddress2Null() ? null : this.SupplyPointAddress2;
                }
                set
                {
                    this.SupplyPointAddress2 = value;
                }
            }

            /// <summary>
            /// City_Ext
            /// Properties for City datamember
            /// </summary>
            public String City_Ext
            {
                get
                {
                    return this.IsCityNull() ? null : this.City;
                }
                set
                {
                    this.City = value;
                }
            }

            /// <summary>
            /// State_Ext
            /// Properties for State datamember
            /// </summary>
            public String State_Ext
            {
                get
                {
                    return this.IsStateNull() ? null : this.State;
                }
                set
                {
                    this.State = value;
                }
            }

            /// <summary>
            /// Zip_Ext
            /// Properties for Zip datamember
            /// </summary>
            public String Zip_Ext
            {
                get
                {
                    return this.IsZipNull() ? null : this.Zip;
                }
                set
                {
                    this.Zip = value;
                }
            }

            /// <summary>
            /// Country_Ext
            /// Properties for Country datamember
            /// </summary>
            public String Country_Ext
            {
                get
                {
                    return this.IsCountryNull() ? null : this.Country;
                }
                set
                {
                    this.Country = value;
                }
            }

            /// <summary>
            /// FromCSTankID_Ext
            /// Properties for Country datamember
            /// </summary>
            public int FromCSTankID_Ext
            {
                get
                {
                    return this.IsFromCSTankIDNull() ? 0 : this.FromCSTankID;
                }
                set
                {
                    this.FromCSTankID = value;
                }
            }

            /// <summary>
            /// ToCSTankID_Ext
            /// Properties for Country datamember
            /// </summary>
            public int ToCSTankID_Ext
            {
                get
                {
                    return this.IsToCSTankIDNull() ? 0 : this.ToCSTankID;
                }
                set
                {
                    this.ToCSTankID = value;
                }
            }

            /// <summary>
            /// FromCSTankCode_Ext
            /// Properties for Country datamember
            /// </summary>
            public String FromCSTankCode_Ext
            {
                get
                {
                    return this.IsFromCSTankCodeNull() ? "" : this.FromCSTankCode;
                }
                set
                {
                    this.FromCSTankCode = value;
                }
            }

            /// <summary>
            /// ToCSTankCode_Ext
            /// Properties for Country datamember
            /// </summary>
            public String ToCSTankCode_Ext
            {
                get
                {
                    return this.IsToCSTankCodeNull() ? "" : this.ToCSTankCode;
                }
                set
                {
                    this.ToCSTankCode = value;
                }
            }
        }

        /// <summary>
        /// LoadStatusHistoryRow
        /// Partial LoadStatusHistory row class to get and set datamembers
        /// </summary>
        partial class LoadStatusHistoryRow
        {
            /// <summary>
            /// LoadID_Ext
            /// Properties for LoadID datamember
            /// </summary>
            public Guid LoadID_Ext
            {
                get
                {
                    return this.LoadID;
                }
                set
                {
                    this.LoadID = value;
                }
            }

            /// <summary>
            /// LoadStatusID_Ext
            /// Properties for LoadStatusID datamember
            /// </summary>
            public string LoadStatusID_Ext
            {
                get
                {
                    return this.LoadStatusID;
                }
                set
                {
                    this.LoadStatusID = value;
                }
            }

            /// <summary>
            /// Latitude_Ext
            /// Properties for Latitude datamember
            /// </summary>
            public string Latitude_Ext
            {
                get
                {
                    return this.Latitude;
                }
                set
                {
                    this.Latitude = value;
                }
            }



            /// <summary>
            /// Longitude_Ext
            /// Properties for Longitude datamember
            /// </summary>
            public string Longitude_Ext
            {
                get
                {
                    return this.Longitude;
                }
                set
                {
                    this.Longitude = value;
                }
            }

            /// <summary>
            /// City_Ext
            /// Properties for City datamember
            /// </summary>
            public string City_Ext
            {
                get
                {
                    return this.City;
                }
                set
                {
                    this.City = value;
                }
            }

            /// <summary>
            /// State_Ext
            /// Properties for City datamember
            /// </summary>
            public string State_Ext
            {
                get
                {
                    return this.State;
                }
                set
                {
                    this.State = value;
                }
            }

            /// <summary>
            /// NeedUpdate_Ext
            /// Properties for NeedUpdate datamember
            /// </summary>
            public Boolean NeedUpdate_Ext
            {
                get
                {
                    return this.NeedUpdate;
                }
                set
                {
                    this.NeedUpdate = value;
                }
            }

            /// <summary>
            /// UpdatedBy_Ext
            /// Properties for UpdatedBy datamember
            /// </summary>
            public Int32 UpdatedBy_Ext
            {
                get
                {
                    return this.UpdatedBy;
                }
                set
                {
                    this.UpdatedBy = value;
                }
            }

            /// <summary>
            /// DateTime_Ext
            /// Properties for DateTime datamember
            /// </summary>
            public DateTime DateTime_Ext
            {
                get
                {
                    return this.DateTime;
                }
                set
                {
                    this.DateTime = value;
                }
            }
        }

        /// <summary>
        /// OrderStatusHistoryRow
        /// Partial OrderStatusHistory row class to get and set datamembers
        /// </summary>
        partial class OrderStatusHistoryRow
        {
            /// <summary>
            /// OrderID_Ext
            /// Properties for OrderID datamember
            /// </summary>
            public Guid OrderID_Ext
            {
                get
                {
                    return this.OrderID;
                }
                set
                {
                    this.OrderID = value;
                }
            }

            /// <summary>
            /// OrderStatusID_Ext
            /// Properties for OrderStatusID datamember
            /// </summary>
            public string OrderStatusID_Ext
            {
                get
                {
                    return this.OrderStatusID;
                }
                set
                {
                    this.OrderStatusID = value;
                }
            }

            /// <summary>
            /// Latitude_Ext
            /// Properties for Latitude datamember
            /// </summary>
            public string Latitude_Ext
            {
                get
                {
                    return this.Latitude;
                }
                set
                {
                    this.Latitude = value;
                }
            }

            /// <summary>
            /// Longitude_Ext
            /// Properties for Longitude datamember
            /// </summary>
            public string Longitude_Ext
            {
                get
                {
                    return this.Longitude;
                }
                set
                {
                    this.Longitude = value;
                }
            }

            /// <summary>
            /// NeedUpdate_Ext
            /// Properties for NeedUpdate datamember
            /// </summary>
            public Boolean NeedUpdate_Ext
            {
                get
                {
                    return this.NeedUpdate;
                }
                set
                {
                    this.NeedUpdate = value;
                }
            }

            /// <summary>
            /// UpdatedBy_Ext
            /// Properties for UpdatedBy datamember
            /// </summary>
            public Int32 UpdatedBy_Ext
            {
                get
                {
                    return this.UpdatedBy;
                }
                set
                {
                    this.UpdatedBy = value;
                }
            }

            /// <summary>
            /// DateTime_Ext
            /// Properties for DateTime datamember
            /// </summary>
            public DateTime DateTime_Ext
            {
                get
                {
                    return this.DateTime;
                }
                set
                {
                    this.DateTime = value;
                }
            }
        }

        /// <summary>
        /// VehicleRow
        /// Partial Vehicle row class to get and set datamembers
        /// </summary>
        partial class VehicleRow
        {
            /// <summary>
            /// ID_Ext
            /// Properties for ID datamember
            /// </summary>
            public Int32 ID_Ext
            {
                get
                {
                    return this.ID;
                }
                set
                {
                    this.ID = value;
                }
            }

            /// <summary>
            /// CustomerID_Ext
            /// Properties for CustomerID datamember
            /// </summary>
            public String CustomerID_Ext
            {
                get
                {
                    return this.CustomerID;
                }
                set
                {
                    this.CustomerID = value;
                }
            }

            /// <summary>
            /// VehicleCode_Ext
            /// Properties for VehicleCode datamember
            /// </summary>
            public String VehicleCode_Ext
            {
                get
                {
                    return this.VehicleCode;
                }
                set
                {
                    this.VehicleCode = value;
                }
            }

            /// <summary>
            /// SleeperRig_Ext
            /// Properties for SleeperRig datamember
            /// </summary>
            public Boolean SleeperRig_Ext
            {
                get
                {
                    return this.SleeperRig;
                }
                set
                {
                    this.SleeperRig = value;
                }
            }

            /// <summary>
            /// VehicleType_Ext
            /// Properties for VehicleType datamember
            /// </summary>
            public Int32 VehicleTypeID_Ext
            {
                get
                {
                    return this.VehicleTypeID;
                }
                set
                {
                    this.VehicleTypeID = value;
                }
            }
        }


        /// <summary>
        /// DriversRow
        /// Partial Drivers row class to get and set datamembers
        /// </summary>
        partial class DriversRow
        {
            /// <summary>
            /// ID_Ext
            /// Properties for ID datamember
            /// </summary>
            public Int32 ID_Ext
            {
                get
                {
                    return this.ID;
                }
                set
                {
                    this.ID = value;
                }
            }

            /// <summary>
            /// CustomerID_Ext
            /// Properties for CustomerID datamember
            /// </summary>
            public String CustomerID_Ext
            {
                get
                {
                    return this.CustomerID;
                }
                set
                {
                    this.CustomerID = value;
                }
            }
        }

        /// <summary>
        /// CustomerRow
        /// Partial Customer row class to get and set datamembers
        /// </summary>
        partial class CustomerRow
        {
            /// <summary>
            /// CustomerID_Ext
            /// Properties for CustomerID datamember
            /// </summary>
            public String CustomerID_Ext
            {
                get
                {
                    return this.CustomerID;
                }
                set
                {
                    this.CustomerID = value;
                }
            }

            /// <summary>
            /// Password_Ext
            /// Properties for Password datamember
            /// </summary>
            public String Password_Ext
            {
                get
                {
                    return this.Password;
                }
                set
                {
                    this.Password = value;
                }
            }

            /// <summary>
            /// Description_Ext
            /// Properties for Description datamember
            /// </summary>
            public String Description_Ext
            {
                get
                {
                    return this.IsDescriptionNull() ? null : Description;

                }
                set
                {
                    this.Description = value;
                }
            }

            /// <summary>
            /// WCFURL_Ext
            /// Properties for WCFURL datamember
            /// </summary>
            public String WCFURL_Ext
            {
                get
                {
                    return this.IsWCFURLNull() ? null : WCFURL;
                }
                set
                {
                    this.WCFURL = value;
                }
            }

            /// <summary>
            /// Name_Ext
            /// Properties for Name datamember
            /// </summary>
            public String Name_Ext
            {
                get
                {
                    return this.Name;
                }
                set
                {
                    this.Name = value;
                }
            }
            /// <summary>
            /// SiteWaitTime_Ext
            /// Properties for SiteWaitTime datamember
            /// </summary>
            public Boolean FromSiteBSRule_Ext
            {
                get
                {
                    if (this.IsFromSiteBSRuleNull())
                    {
                        return false;
                    }
                    return this.FromSiteBSRule;
                }
                set
                {
                    this.FromSiteBSRule = value;
                }
            }
        }

        /// <summary>
        /// OrderFrtRow
        /// Partial OrderFrt row class to get and set datamembers
        /// </summary>
        partial class OrderFrtRow
        {
            /// <summary>
            /// OrderID_Ext
            /// Properties for OrderID datamember
            /// </summary>
            public Guid OrderID_Ext
            {
                get
                {
                    return this.OrderID;
                }
                set
                {
                    this.OrderID = value;
                }
            }

            /// <summary>
            /// SiteWaitTime_Ext
            /// Properties for SiteWaitTime datamember
            /// </summary>
            public Boolean SiteWaitTime_Ext
            {
                get
                {
                    if (this.IsSiteWaitTimeNull())
                    {
                        return false;
                    }
                    return this.SiteWaitTime;
                }
                set
                {
                    this.SiteWaitTime = value;
                }
            }

            /// <summary>
            /// SiteWaitTime_Comment_Ext
            /// Properties for SiteWaitTime_Comment datamember
            /// </summary>
            public String SiteWaitTime_Comment_Ext
            {
                get
                {
                    if (this.IsSiteWaitTime_CommentNull())
                    {
                        return null;
                    }
                    return this.SiteWaitTime_Comment;
                }
                set
                {
                    this.SiteWaitTime_Comment = value;
                }
            }

            /// <summary>
            /// SiteWaitTime_Start_Ext
            /// Properties for SiteWaitTime_Start datamember
            /// </summary>
            public DateTime? SiteWaitTime_Start_Ext
            {
                get
                {
                    if (this.IsSiteWaitTime_StartNull())
                    {
                        return null;
                    }
                    return this.SiteWaitTime_Start;
                }
                set
                {
                    if (value != null)
                    {
                        this.SiteWaitTime_Start = value.Value;
                    }
                    else
                    {
                        this.SetSiteWaitTime_StartNull();
                    }

                }
            }

            /// <summary>
            /// SiteWaitTime_End_Ext
            /// Properties for SiteWaitTime_End datamember
            /// </summary>
            public DateTime? SiteWaitTime_End_Ext
            {
                get
                {
                    if (this.IsSiteWaitTime_EndNull())
                    {
                        return null;
                    }
                    return this.SiteWaitTime_End;
                }
                set
                {
                    if (value != null)
                    {
                        this.SiteWaitTime_End = value.Value;
                    }
                    else
                    {
                        this.SetSiteWaitTime_EndNull();
                    }
                }
            }

            /// <summary>
            /// SplitLoad_Ext
            /// Properties for SplitLoad datamember
            /// </summary>
            public Boolean SplitLoad_Ext
            {
                get
                {
                    if (this.IsSplitLoadNull())
                    {
                        return false;
                    }
                    return this.SplitLoad;
                }
                set
                {
                    this.SplitLoad = value;
                }
            }

            /// <summary>
            /// SplitLoad_Comment_Ext
            /// Properties for SplitLoad_Comment datamember
            /// </summary>
            public String SplitLoad_Comment_Ext
            {
                get
                {
                    if (this.IsSplitLoad_CommentNull())
                    {
                        return null;
                    }
                    return this.SplitLoad_Comment;
                }
                set
                {
                    this.SplitLoad_Comment = value;
                }
            }

            /// <summary>
            /// SplitDrop_Ext
            /// Properties for SplitDrop datamember
            /// </summary>
            public Boolean SplitDrop_Ext
            {
                get
                {
                    if (this.IsSplitDropNull())
                    {
                        return false;
                    }
                    return this.SplitDrop;
                }
                set
                {
                    this.SplitDrop = value;
                }
            }

            /// <summary>
            /// SplitDrop_Comment_Ext
            /// Properties for SplitDrop_Comment datamember
            /// </summary>
            public String SplitDrop_Comment_Ext
            {
                get
                {
                    if (this.IsSplitDrop_CommentNull())
                    {
                        return null;
                    }
                    return this.SplitDrop_Comment;
                }
                set
                {
                    this.SplitDrop_Comment = value;
                }
            }

            /// <summary>
            /// PumpOut_Ext
            /// Properties for PumpOut datamember
            /// </summary>
            public Boolean PumpOut_Ext
            {
                get
                {
                    if (this.IsPumpOutNull())
                    {
                        return false;
                    }
                    return this.PumpOut;
                }
                set
                {
                    this.PumpOut = value;
                }
            }

            /// <summary>
            /// PumpOut_Comment_Ext
            /// Properties for PumpOut_Comment datamember
            /// </summary>
            public String PumpOut_Comment_Ext
            {
                get
                {
                    if (this.IsPumpOut_CommentNull())
                    {
                        return null;
                    }
                    return this.PumpOut_Comment;
                }
                set
                {
                    this.PumpOut_Comment = value;
                }
            }

            /// <summary>
            /// Diversion_Ext
            /// Properties for Diversion datamember
            /// </summary>
            public Boolean Diversion_Ext
            {
                get
                {
                    if (this.IsDiversionNull())
                    {
                        return false;
                    }
                    return this.Diversion;
                }
                set
                {
                    this.Diversion = value;
                }
            }

            /// <summary>
            /// Diversion_Comment_Ext
            /// Properties for Diversion_Comment datamember
            /// </summary>
            public String Diversion_Comment_Ext
            {
                get
                {
                    if (this.IsDiversion_CommentNull())
                    {
                        return null;
                    }
                    return this.Diversion_Comment;
                }
                set
                {
                    this.Diversion_Comment = value;
                }
            }

            /// <summary>
            /// MinimumLoad_Ext
            /// Properties for MinimumLoad datamember
            /// </summary>
            public Boolean MinimumLoad_Ext
            {
                get
                {
                    if (this.IsMinimumLoadNull())
                    {
                        return false;
                    }
                    return this.MinimumLoad;
                }
                set
                {
                    this.MinimumLoad = value;
                }
            }

            /// <summary>
            /// MinimumLoad_Comment_Ext
            /// Properties for MinimumLoad_Comment datamember
            /// </summary>
            public String MinimumLoad_Comment_Ext
            {
                get
                {
                    if (this.IsMinimumLoad_CommentNull())
                    {
                        return null;
                    }
                    return this.MinimumLoad_Comment;
                }
                set
                {
                    this.MinimumLoad_Comment = value;
                }
            }

            /// <summary>
            /// SiteWaitTime_Ext
            /// Properties for SiteWaitTime datamember
            /// </summary>
            public Boolean Other_Ext
            {
                get
                {
                    if (this.IsOtherNull())
                    {
                        return false;
                    }
                    return this.Other;
                }
                set
                {
                    this.Other = value;
                }
            }

            /// <summary>
            /// Other_Comment_Ext
            /// Properties for Other_Comment datamember
            /// </summary>
            public String Other_Comment_Ext
            {
                get
                {
                    if (this.IsOther_CommentNull())
                    {
                        return null;
                    }
                    return this.Other_Comment;
                }
                set
                {
                    this.Other_Comment = value;
                }
            }

        }

        /// <summary>
        /// GPSHistoryRow
        /// Partial GPSHistory row class to get and set datamembers
        /// </summary>
        partial class GPSHistoryRow
        {
            /// <summary>
            /// Longitude_Ext
            /// Properties for Longitude datamember
            /// </summary>
            public String Longitude_Ext
            {
                get
                {
                    return this.Longitude;
                }
                set
                {
                    this.Longitude = value;
                }
            }

            /// <summary>
            /// Latitude_Ext
            /// Properties for Latitude datamember
            /// </summary>
            public String Latitude_Ext
            {
                get
                {
                    return this.Latitude;
                }
                set
                {
                    this.Latitude = value;
                }
            }

            /// <summary>
            /// Dttm_Ext
            /// Properties for Dttm datamember
            /// </summary>
            public DateTime Dttm_Ext
            {
                get
                {
                    return this.DateTime;
                }
                set
                {
                    this.DateTime = value;
                }
            }

            /// <summary>
            /// SessionID_Ext
            /// Properties for SessionID datamember
            /// </summary>
            public Guid SessionID_Ext
            {
                get
                {
                    return this.SESSIONID;
                }
                set
                {
                    this.SESSIONID = value;
                }
            }

            /// <summary>
            /// State_Ext
            /// Properties for State datamember
            /// </summary>
            public String State_Ext
            {
                get
                {
                    return this.state;
                }
                set
                {
                    this.state = value;
                }
            }

            /// <summary>
            /// DeviceTime_Ext
            /// Properties for DeviceTime datamember
            /// </summary>
            public DateTime DeviceTime_Ext
            {
                get
                {
                    return this.DeviceTime;
                }
                set
                {
                    this.DeviceTime = value;
                }
            }
            /// <summary>
            /// GMT_Ext
            /// Properties for GMT datamember
            /// </summary>
            public DateTime GMT_Ext
            {
                get
                {
                    return this.GMT;
                }
                set
                {
                    this.GMT = value;
                }
            }
            /// <summary>
            /// GpsStrength_Ext
            /// Properties for GpsStrength datamember
            /// </summary>
            public String GpsStrength_Ext
            {
                get
                {
                    return this.GPSStrength;
                }
                set
                {
                    this.GPSStrength = value;
                }
            }
            /// <summary>
            /// Status_Ext
            /// Properties for Status datamember
            /// </summary>
            public String Status_Ext
            {
                get
                {
                    return this.Status;
                }
                set
                {
                    this.Status = value;
                }
            }



        }

        partial class LoginSessionRow
        {
            public Guid SessionID_Ext
            {
                get
                {
                    return this.SessionID;
                }
                set
                {
                    this.SessionID = value;
                }
            }
            public Int32 LoginID_Ext
            {
                get
                {
                    return this.LoginID;
                }
                set
                {
                    this.LoginID = value;
                }
            }
            public String DeviceID_Ext
            {
                get
                {
                    return this.DeviceID;
                }
                set
                {
                    this.DeviceID = value;
                }
            }
            public DateTime LogoffTime_Ext
            {
                get
                {
                    return this.LogoffTime;
                }
                set
                {
                    this.LogoffTime = value;
                }

            }
            public Int32 CurrentVehicle_Ext
            {
                get
                {
                    return this.CurrentVehicle;
                }
                set
                {
                    this.CurrentVehicle = value;
                }
            }

            public Boolean Active_Ext
            {
                get
                {
                    return this.Active;
                }
                set
                {
                    this.Active = value;
                }
            }
            public DateTime LogonTime_Ext
            {
                get
                {
                    return this.LogonTime;
                }
                set
                {
                    this.LogonTime = value;
                }

            }
        }

        partial class InspectionRow
        {
            public Guid SessionID_Ext
            {
                get
                {
                    return this.SessionID;
                }
                set
                {
                    this.SessionID = value;
                }
            }

            public Boolean PreDuty_Inspection_Ext
            {
                get
                {
                    if (IsPreDuty_InspectionNull())
                    {
                        return false;
                    }
                    else
                    {
                        return this.PreDuty_Inspection;
                    }
                }
                set
                {
                    this.PreDuty_Inspection = value;
                }
            }
            public DateTime? PreDuty_InspectionDateTime_Ext
            {
                get
                {
                    if (this.IsPreDuty_InspectionDateTimeNull())
                    {
                        return null;
                    }
                    return this.PreDuty_InspectionDateTime;
                }
                set
                {
                    if (value == null)
                    {
                        this.SetPreDuty_InspectionDateTimeNull();
                    }
                    else
                    {
                        this.PreDuty_InspectionDateTime = Convert.ToDateTime(value);
                    }
                }

            }
            public Boolean PreDutyViolation_Ext
            {
                get
                {
                    if (IsPreDutyViolationNull())
                    {
                        return false;
                    }
                    return this.PreDutyViolation;
                }
                set
                {
                    this.PreDutyViolation = value;
                }
            }
            public Boolean PostDuty_Inspection_Ext
            {
                get
                {
                    if (this.IsPostDuty_InspectionNull())
                    {
                        return false;
                    }

                    return this.PostDuty_Inspection;
                }
                set
                {
                    this.PostDuty_Inspection = value;
                }
            }
            public DateTime? PostDuty_InspectionDateTime_Ext
            {
                get
                {
                    if (this.IsPostDuty_InspectionDateTimeNull())
                    {
                        return null;
                    }
                    return this.PostDuty_InspectionDateTime;
                }
                set
                {
                    if (value == null)
                    {
                        this.SetPostDuty_InspectionDateTimeNull();
                    }
                    else
                    {
                        this.PostDuty_InspectionDateTime = Convert.ToDateTime(value);
                    }
                }

            }
            public Boolean PostDutyViolation_Ext
            {
                get
                {
                    if (this.IsPostDutyViolationNull())
                    {
                        return false;
                    }

                    return this.PostDutyViolation;
                }
                set
                {
                    this.PostDutyViolation = value;
                }
            }

        }

        partial class AdverseConditionRow
        {
            public Guid SessionID_Ext
            {
                get
                {
                    return this.SessionID;
                }
                set
                {
                    this.SessionID = value;
                }
            }

            public Boolean Adverse_Condition_Ext
            {
                get
                {
                    return this.Adverse_Condition;
                }
                set
                {
                    this.Adverse_Condition = value;
                }
            }

            public String AdverseConditionReason_Ext
            {
                get
                {
                    return this.AdverseConditionReason;
                }
                set
                {
                    this.AdverseConditionReason = value;
                }
            }

            public DateTime AdverseConditionDateTime_Ext
            {
                get
                {
                    return this.AdverseConditionDateTime;
                }
                set
                {
                    this.AdverseConditionDateTime = value;
                }
            }

        }

        partial class SleeperRigRow
        {
            public Guid SessionID_Ext
            {
                get
                {
                    return this.SessionID;
                }
                set
                {
                    this.SessionID = value;
                }
            }

            public Guid SleeperRigID_Ext
            {
                get
                {
                    return this.SleeperRigID;
                }
                set
                {
                    this.SleeperRigID = value;
                }
            }
            public DateTime StartTime_Ext
            {
                get
                {
                    return this.StartTime;
                }
                set
                {
                    this.StartTime = value;
                }
            }

            public DateTime EndTime_Ext
            {
                get
                {
                    return this.EndTime;
                }
                set
                {
                    this.EndTime = value;
                }
            }
        }

        partial class DriverSummaryRow
        {
            public DateTime StartTime_Ext
            {
                get
                {
                    return this.StartTime;
                }
                set
                {
                    this.StartTime = value;
                }
            }


            public DateTime EndTime_Ext
            {
                get
                {
                    return this.EndTime;
                }
                set
                {
                    this.EndTime = value;
                }
            }

            public DateTime LoginDateTime
            {
                get
                {
                    return this.EndTime;
                }
                set
                {
                    this.EndTime = value;
                }
            }

            public Int32 CurrentLoginID_Ext
            {
                get
                {
                    return this.CurrentLoginID;
                }
                set
                {
                    this.CurrentLoginID = value;
                }
            }

            public Guid SessionID_Ext
            {
                get
                {
                    return this.SessionID;
                }
                set
                {
                    this.SessionID = value;
                }
            }

            public string DriverState_Ext
            {
                get
                {
                    return this.DriverState;
                }
                set
                {
                    this.DriverState = value;
                }
            }
            // 2014.02.20  Ramesh M Added For CR#62292 For driver summary log
            public string IsOverride_Ext
            {
                get
                {
                    return this.IsOverride;
                }
                set
                {
                    this.IsOverride = value;
                }
            }

            //public string ThirtyFourHourReset_Ext
            //{
            //    get
            //    {
            //        return this.ThirtyFourHourReset;
            //    }
            //    set
            //    {
            //        this.ThirtyFourHourReset = value;
            //    }
            //}
        }
        // 05-14-2014  MadhuVenkat K - Added for CR 63396 - Add Time Remaining Section to Driver Summary
        partial class TimeRemainingDriverSummaryRow
        {
            public int ID_Ext
            {
                get
                {
                    return this.ID;
                }
                set
                {
                    this.ID = value;
                }
            }
            public decimal CurrentOnDuty_Ext
            {
                get
                {
                    return this.CurrentOnDuty;
                }
                set
                {
                    this.CurrentOnDuty = value;
                }
            }

            public decimal CurrentOffDuty_Ext
            {
                get
                {
                    return this.CurrentOffDuty;
                }
                set
                {
                    this.CurrentOffDuty = value;
                }
            }

            public decimal CurrentDriving_Ext
            {
                get
                {
                    return this.CurrentDriving;
                }
                set
                {
                    this.CurrentDriving = value;
                }
            }
            public decimal CurrentSleeper_Ext
            {
                get
                {
                    return this.CurrentSleeper;
                }
                set
                {
                    this.CurrentSleeper = value;
                }
            }

            public decimal LastOnDuty_Ext
            {

                get
                {
                    return this.LastOnDuty;
                }
                set
                {
                    this.LastOnDuty = value;
                }
            }
            public decimal LastOffDuty_Ext
            {

                get
                {
                    return this.LastOffDuty;
                }
                set
                {
                    this.LastOffDuty = value;
                }
            }

            public decimal LastDriving_Ext
            {

                get
                {
                    return this.LastDriving;
                }
                set
                {
                    this.LastDriving = value;
                }
            }
            public decimal LastSleeper_Ext
            {

                get
                {
                    return this.LastSleeper;
                }
                set
                {
                    this.LastSleeper = value;
                }
            }

            public decimal RemainingOnDuty_Ext
            {

                get
                {
                    return this.RemainingOnDuty;
                }
                set
                {
                    this.RemainingOnDuty = value;
                }
            }
            public decimal RemainingDrivingDuty_Ext
            {

                get
                {
                    return this.RemainingDrivingDuty;
                }
                set
                {
                    this.RemainingDrivingDuty = value;
                }
            }
            public decimal RemainingBreak_Ext
            {

                get
                {
                    return this.RemainingBreak;
                }
                set
                {
                    this.RemainingBreak = value;
                }
            }
            public decimal RemainingLastweek_Ext
            {

                get
                {
                    return this.RemainingLastweek;
                }
                set
                {
                    this.RemainingLastweek = value;
                }
            }
            // 08-14-2014  MadhuVenkat K - Added for CR 64639 - Add CurrentDriverStatus to Driver Summary
            public String CurrentDriverStatus_Ext
            {

                get
                {
                    if (this.IsCurrentDriverStatusNull())
                    {
                        return string.Empty;
                    }
                    return this.CurrentDriverStatus;
                }
                set
                {
                    this.CurrentDriverStatus = value;
                }
            }

            public String IsSessionExists_Ext
            {

                get
                {
                    if (this.IsIsSessionExistsNull())
                    {
                        return string.Empty;
                    }
                    return this.IsSessionExists;
                }
                set
                {
                    this.IsSessionExists = value;
                }
            }

            // 08-25-2014  MadhuVenkat K - Added for CR 64760 - Add InspectionVersion to Driver Summary
            //public String InspectionVersion_Ext
            //{

            //    get
            //    {
            //        if (this.IsInspectionVersionNull())
            //        {
            //            return string.Empty;
            //        }
            //        return this.InspectionVersion;
            //    }
            //    set
            //    {
            //        this.InspectionVersion = value;
            //    }
            //}


        }
        partial class GetDriverLogsRow
        {
            public decimal CurrentOnDuty_Ext
            {
                get
                {
                    if (IsCurrentOnDutyNull())
                    {
                        return 0;
                    }
                    else
                    {
                        return this.CurrentOnDuty;
                    }
                }
                set
                {
                    this.CurrentOnDuty = value;
                }
            }

            public decimal CurrentDriving_Ext
            {
                get
                {
                    if (IsCurrentDrivingNull())
                    {
                        return 0;
                    }
                    else
                    {
                        return this.CurrentDriving;
                    }
                }
                set
                {
                    this.CurrentDriving = value;
                }
            }

            public decimal CurrentSleeping_Ext
            {
                get
                {
                    if (IsCurrentSleepingNull())
                    {
                        return 0;
                    }
                    else
                    {
                        return this.CurrentSleeping;
                    }
                }
                set
                {
                    this.CurrentSleeping = value;
                }
            }

            public decimal CurrentOffDuty_Ext
            {
                get
                {
                    if (IsCurrentOffDutyNull())
                    {
                        return 0;
                    }
                    else
                    {
                        return this.CurrentOffDuty;
                    }
                }
                set
                {
                    this.CurrentOffDuty = value;
                }
            }

            public decimal LastOnDuty_Ext
            {
                get
                {
                    if (IsLastOnDutyNull())
                    {
                        return 0;
                    }
                    else
                    {
                        return this.LastOnDuty;
                    }
                }
                set
                {
                    this.LastOnDuty = value;
                }
            }

            public decimal LastDriving_Ext
            {
                get
                {
                    if (IsLastDrivingNull())
                    {
                        return 0;
                    }
                    else
                    {
                        return this.LastDriving;
                    }
                }
                set
                {
                    this.LastDriving = value;
                }
            }

            public decimal LastSleeping_Ext
            {
                get
                {
                    if (IsLastSleepingNull())
                    {
                        return 0;
                    }
                    else
                    {
                        return this.LastSleeping;
                    }
                }
                set
                {
                    this.LastSleeping = value;
                }
            }

            public decimal LastOffDuty_Ext
            {
                get
                {
                    if (IsLastOffDutyNull())
                    {
                        return 0;
                    }
                    else
                    {
                        return this.LastOffDuty;
                    }
                }
                set
                {
                    this.LastOffDuty = value;
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>

        partial class OrderPickingDetailsRow
        {
            public Int64 ID_Ext
            {
                get
                {
                    return this.ID;
                }
                set
                {
                    this.ID = value;
                }
            }
            public string OrderNo_Ext
            {
                get
                {
                    return this.OrderNo;
                }
                set
                {
                    this.OrderNo = value;
                }
            }
            public string LoadNo_Ext
            {
                get
                {
                    return this.LoadNo;
                }
                set
                {
                    this.LoadNo = value;
                }
            }
            public String OrderItemID_Ext
            {
                get
                {
                    return this.OrderItemID;
                }
                set
                {
                    this.OrderItemID = value;
                }
            }
            public Int32 PickedBy_Ext
            {
                get
                {
                    return this.PickedBy;
                }
                set
                {
                    this.PickedBy = value;
                }
            }
            public string CustomerID_Ext
            {
                get
                {
                    return this.CustomerID;
                }
                set
                {
                    this.CustomerID = value;
                }
            }
            public string Status_Ext
            {
                get
                {
                    return this.Status;
                }
                set
                {
                    this.Status = value;
                }
            }
        }

        partial class GetDriverDetailsRow
        {
            public Int32 LoginID_Ext
            {
                get
                {
                    return this.LoginID;
                }
                set
                {
                    this.LoginID = value;
                }
            }
            public String FullName_Ext
            {
                get
                {
                    return this.FullName;
                }
                set
                {
                    this.FullName = value;
                }
            }
        }

        partial class GetVehicleDetailsRow
        {
            public Int32 VehicleID_Ext
            {
                get
                {
                    return this.VehicleID;
                }
                set
                {
                    this.VehicleID = value;
                }
            }
            public String VehicleCode_Ext
            {
                get
                {
                    return this.VehicleCode;
                }
                set
                {
                    this.VehicleCode = value;
                }
            }
        }

        partial class Cloud_TW_GetVehicleRow
        {
            public Int32 VehicleID_Ext
            {
                get
                {
                    return this.VehicleID;
                }
                set
                {
                    this.VehicleID = value;
                }
            }
            public String VehicleCode_Ext
            {
                get
                {
                    return this.VehicleCode;
                }
                set
                {
                    this.VehicleCode = value;
                }
            }
        }

        partial class InspectionElementsRow
        {
            public Int32 SequenceID_Ext
            {
                get
                {
                    return this.SequenceID;
                }
                set
                {
                    this.SequenceID = value;
                }
            }
            public String Description_Ext
            {
                get
                {
                    return this.Description;
                }
                set
                {
                    this.Description = value;
                }
            }


            public DateTime? Modifieddate_Ext
            {
                get
                {
                    if (this.IsModifieddateNull())
                    {
                        return null;
                    }
                    return this.Modifieddate;
                }
                set
                {
                    if (value == null)
                    {
                        this.SetModifieddateNull();
                    }
                    else
                    {
                        this.Modifieddate = Convert.ToDateTime(value);
                    }
                }

            }
        }

        partial class WarehouseRow
        {
            public Int32 ID_Ext
            {
                get
                {
                    return this.ID;
                }
                set
                {
                    this.ID = value;
                }
            }
            public String CustomerID_Ext
            {
                get
                {
                    return this.CustomerID;
                }
                set
                {
                    this.CustomerID = value;
                }
            }
            public Int32 SiteID_Ext
            {
                get
                {
                    return this.SiteID;
                }
                set
                {
                    this.SiteID = value;
                }
            }
            public String SiteCode_Ext
            {
                get
                {
                    return this.SiteCode;
                }
                set
                {
                    this.SiteCode = value;
                }
            }
            public String NeedUpdate_Ext
            {
                get
                {
                    if (this.IsNeedUpdateNull())
                    {
                        return null;
                    }
                    return this.NeedUpdate;
                }
                set
                {
                    this.NeedUpdate = value;
                }
            }
        }

        partial class ARShipTo_FromSitesRow
        {
            public Int32 ShipToID_Ext
            {
                get
                {
                    return this.ShipToID;
                }
                set
                {
                    this.ShipToID = value;
                }
            }
            public Int32 SuppliersupplyPtID_Ext
            {
                get
                {
                    return this.SuppliersupplyPtID;
                }
                set
                {
                    this.SuppliersupplyPtID = value;
                }
            }
            public Int32 SupplieID_Ext
            {
                get
                {
                    return this.SupplierID;
                }
                set
                {
                    this.SupplierID = value;
                }
            }
            public Int32 SupplyPtID_Ext
            {
                get
                {
                    return this.SupplyPtID;
                }
                set
                {
                    this.SupplyPtID = value;
                }
            }

            public String SupplierDescr_Ext
            {
                get
                {
                    return this.SupplierDescr;
                }
                set
                {
                    this.SupplierDescr = value;
                }
            }

            public String SupplyPtDescr_Ext
            {
                get
                {
                    return this.SupplyPtDescr;
                }
                set
                {
                    this.SupplyPtDescr = value;
                }
            }
            public String Address1_Ext
            {
                get
                {
                    return this.Address1;
                }
                set
                {
                    this.Address1 = value;
                }
            }
            public String Address2_Ext
            {
                get
                {
                    return this.Address2;
                }
                set
                {
                    this.Address2 = value;
                }
            }
            public String CustomerID_Ext
            {
                get
                {
                    return this.CustomerID;
                }
                set
                {
                    this.CustomerID = value;
                }
            }

        }

        // 2014.01.17 Ramesh M Added For  CR#61759 to get from site list 
        partial class SupplierSupplypointListRow
        {
            public Int32 SupplierSupplyPtID_Ext
            {
                get
                {
                    return this.SupplierSupplyPtID;
                }
                set
                {
                    this.SupplierSupplyPtID = value;
                }
            }
            public String SupplierSupplyPt_Ext
            {
                get
                {
                    return this.SupplierSupplyPt;
                }
                set
                {
                    this.SupplierSupplyPt = value;
                }
            }
            public Int32? ShipToID_Ext
            {
                get
                {
                    return this.IsShipToIDNull() ? null : ShipToID;
                }
                set
                {
                    this.ShipToID = value;
                }
            }
        }

        // 2014.02.20  Ramesh M Added For CR#62301 For Driver status Screen in Ipad
        partial class DriverLogStatusRow
        {
            public DateTime StartTime_Ext
            {
                get
                {
                    return this.StartTime;
                }
                set
                {
                    this.StartTime = value;
                }
            }
            public DateTime EndTime_Ext
            {
                get
                {
                    return this.EndTime;
                }
                set
                {
                    this.EndTime = value;
                }
            }
            public Int32 CurrentLoginID_Ext
            {
                get
                {
                    return this.CurrentLoginID;
                }
                set
                {
                    this.CurrentLoginID = value;
                }
            }
            public Guid SessionID_Ext
            {
                get
                {
                    return this.SessionID;
                }
                set
                {
                    this.SessionID = value;
                }
            }
            public String DriverState_Ext
            {
                get
                {
                    return this.DriverState;
                }
                set
                {
                    this.DriverState = value;
                }
            }
            // 2014.02.25  Ramesh M Added For CR#62292 For modified driver summary log
            public string Location_Ext
            {
                get
                {
                    if (this.IsLocationNull())
                    {
                        return string.Empty;
                    }
                    return this.Location;
                }
                set
                {
                    this.Location = value;
                }
            }
            public string EventDetail_Ext
            {
                get
                {
                    if (this.IsEventDetailNull())
                    {
                        return string.Empty;
                    }
                    return this.EventDetail;
                }
                set
                {
                    this.EventDetail = value;
                }
            }
        }
        // 2014.03.17  Ramesh M Added For CR#62613 to get home terminal details

        partial class LoginHomeTerminalDetailsRow
        {
            public Int32 ID_Ext
            {
                get
                {
                    return this.ID;
                }
                set
                {
                    this.ID = value;
                }
            }
            public String CustomerID_Ext
            {
                get
                {
                    return this.CustomerID;
                }
                set
                {
                    this.CustomerID = value;
                }
            }
            public String FirstName_Ext
            {
                get
                {
                    if (this.IsFirstNameNull())
                    {
                        return null;
                    }
                    return this.FirstName;
                }
                set
                {
                    this.FirstName = value;
                }
            }
            public String LastName_Ext
            {
                get
                {
                    if (this.IsLastNameNull())
                    {
                        return null;
                    }
                    return this.LastName;
                }
                set
                {
                    this.LastName = value;
                }
            }

            public String UserType_Ext
            {
                get
                {
                    return this.UserType;
                }
                set
                {
                    this.UserType = value;
                }
            }
            public String Co_Name_Ext
            {
                get
                {
                    if (this.IsCo_NameNull())
                    {
                        return null;
                    }
                    return this.Co_Name;
                }
                set
                {
                    this.Co_Name = value;
                }
            }
            public String Co_Addr1_Ext
            {
                get
                {
                    if (this.IsCo_Addr1Null())
                    {
                        return null;
                    }
                    return this.Co_Addr1;
                }
                set
                {
                    this.Co_Addr1 = value;
                }
            }
            public String Co_City_Ext
            {
                get
                {
                    if (this.IsCo_CityNull())
                    {
                        return null;
                    }
                    return this.Co_City;
                }
                set
                {
                    this.Co_City = value;
                }
            }
            public String Co_State_Ext
            {
                get
                {
                    if (this.IsCo_StateNull())
                    {
                        return null;
                    }
                    return this.Co_State;
                }
                set
                {
                    this.Co_State = value;
                }
            }
            public String Co_Zip_Ext
            {
                get
                {
                    if (this.IsCo_ZipNull())
                    {
                        return null;
                    }
                    return this.Co_Zip;
                }
                set
                {
                    this.Co_Zip = value;
                }
            }
            public String HT_Descr_Ext
            {
                get
                {
                    if (this.IsHT_DescrNull())
                    {
                        return null;
                    }
                    return this.HT_Descr;
                }
                set
                {
                    this.HT_Descr = value;
                }
            }
            public String HT_Addr1_Ext
            {
                get
                {
                    if (this.IsHT_Addr1Null())
                    {
                        return null;
                    }
                    return this.HT_Addr1;
                }
                set
                {
                    this.HT_Addr1 = value;
                }
            }
            public String HT_City_Ext
            {
                get
                {
                    if (this.IsHT_CityNull())
                    {
                        return null;
                    }
                    return this.HT_City;
                }
                set
                {
                    this.HT_City = value;
                }
            }
            public String HT_State_Ext
            {
                get
                {
                    if (this.IsHT_StateNull())
                    {
                        return null;
                    }
                    return this.HT_State;
                }
                set
                {
                    this.HT_State = value;
                }
            }
            public String HT_Zip_Ext
            {
                get
                {
                    if (this.IsHT_ZipNull())
                    {
                        return null;
                    }
                    return this.HT_Zip;
                }
                set
                {
                    this.HT_Zip = value;
                }
            }
            public DateTime? HazMatDate_Ext
            {
                get
                {
                    if (this.IsHazMatDateNull())
                    {
                        return null;
                    }
                    return this.HazMatDate;
                }
                set
                {
                    if (value == null)
                    {
                        this.SetHazMatDateNull();
                    }
                    else
                    {
                        this.HazMatDate = Convert.ToDateTime(value);
                    }
                }

            }
        }
        // 2014.03.20  Ramesh M Added For CR#62322 added  Version testing method
        partial class VersionTestRow
        {
            public Int32 LoginID_Ext
            {
                get
                {
                    return this.LoginID;
                }
                set
                {
                    this.LoginID = value;
                }
            }
            public Guid SessionID_Ext
            {
                get
                {
                    return this.SessionID;
                }
                set
                {
                    this.SessionID = value;
                }
            }
            public DateTime? LogoffTime_Ext
            {
                get
                {
                    if (this.IsLogoffTimeNull())
                    {
                        return null;
                    }
                    return this.LogoffTime;
                }
                set
                {
                    if (value == null)
                    {
                        this.SetLogoffTimeNull();
                    }
                    else
                    {
                        this.LogoffTime = Convert.ToDateTime(value);
                    }
                }

            }


        }



        //TankWagon Details

        // 2014.03.20  Ramesh M Added For CR#62322 added  Version testing method
        partial class VehicleCompartmentRow
        {
            /// <summary>
            /// CompartmentID_Ext
            /// Properties for CompartmentID datamember
            /// </summary>
            public Int32 CompartmentID_Ext
            {
                get
                {
                    return this.CompartmentID;
                }
                set
                {
                    this.CompartmentID = value;
                }
            }

            /// <summary>
            /// VehicleID_Ext
            /// Properties for VehicleID datamember
            /// </summary>
            public Int32 VehicleID_Ext
            {
                get
                {
                    return this.VehicleID;
                }
                set
                {
                    this.VehicleID = value;
                }
            }

            /// <summary>
            /// Capacity_Ext
            /// Properties for Capacity datamember
            /// </summary>
            public Int32 Capacity_Ext
            {
                get
                {
                    return this.Capacity;
                }
                set
                {
                    this.Capacity = value;
                }
            }


            /// <summary>
            /// ClientID_Ext
            /// Properties for ClientID datamember
            /// </summary>
            public String CustomerID_Ext
            {
                get
                {
                    return this.CustomerID;
                }
                set
                {
                    this.CustomerID = value;
                }
            }


            /// <summary>
            /// Code_Ext
            /// Properties for Code datamember
            /// </summary>
            public String Code_Ext
            {
                get
                {
                    return this.Code;
                }
                set
                {
                    this.Code = value;
                }
            }

            /// <summary>
            /// Code_Ext
            /// Properties for Code datamember
            /// </summary>
            public Boolean NeedUpdate_Ext
            {
                get
                {
                    if (this.IsNeedUpdateNull())
                    {
                        return false;
                    }
                    return this.NeedUpdate;
                }
                set
                {
                    this.NeedUpdate = value;
                }
            }

        }

        //BOL Compartment Count added By Vinoth
        partial class Cloud_GetCompartmentDetailsCountRow
        {

            /// <summary>
            /// CompartmentID_Ext
            /// Properties for CompartmentID datamember
            /// </summary>
            public Int32 CompartmentID_Ext
            {
                get
                {
                    return this.CompartmentID;
                }
                set
                {
                    this.CompartmentID = value;
                }
            }

            /// <summary>
            /// VehicleID_Ext
            /// Properties for VehicleID datamember
            /// </summary>
            public Int32 VehicleID_Ext
            {
                get
                {
                    return this.VehicleID;
                }
                set
                {
                    this.VehicleID = value;
                }
            }

            /// <summary>
            /// Capacity_Ext
            /// Properties for Capacity datamember
            /// </summary>
            public Int32 Capacity_Ext
            {
                get
                {
                    return this.Capacity;
                }
                set
                {
                    this.Capacity = value;
                }
            }


            /// <summary>
            /// ClientID_Ext
            /// Properties for ClientID datamember
            /// </summary>
            public String CustomerID_Ext
            {
                get
                {
                    return this.CustomerID;
                }
                set
                {
                    this.CustomerID = value;
                }
            }


            /// <summary>
            /// Code_Ext
            /// Properties for Code datamember
            /// </summary>
            public String Code_Ext
            {
                get
                {
                    return this.Code;
                }
                set
                {
                    this.Code = value;
                }
            }


        }

        // 2014.03.20  Ramesh M Added For CR#62322 added  Version testing method
        partial class BOLItem_WagonRow
        {
            /// <summary>
            /// CompartmentID_Ext
            /// Properties for CompartmentID datamember
            /// </summary>
            public Int32 CompartmentID_Ext
            {
                get
                {
                    return this.CompartmentID;
                }
                set
                {
                    this.CompartmentID = value;
                }
            }

            /// <summary>
            /// SystrxNo_Ext
            /// Properties for SystrxNo datamember
            /// </summary>
            public decimal SystrxNo_Ext
            {
                get
                {
                    return this.SystrxNo;
                }
                set
                {
                    this.SystrxNo = value;
                }
            }

            /// <summary>
            /// Capacity_Ext
            /// Properties for Capacity datamember
            /// </summary>
            public Int32 SystrxLine_Ext
            {
                get
                {
                    return this.SystrxLine;
                }
                set
                {
                    this.SystrxLine = value;
                }
            }


            /// <summary>
            /// ClientID_Ext
            /// Properties for ClientID datamember
            /// </summary>
            public String ProdCode_Ext
            {
                get
                {
                    return this.ProdCode;
                }
                set
                {
                    this.ProdCode = value;
                }
            }


            /// <summary>
            /// ClientID_Ext
            /// Properties for ClientID datamember
            /// </summary>
            public decimal GrossQty_Ext
            {
                get
                {
                    return this.GrossQty;
                }
                set
                {
                    this.GrossQty = value;
                }
            }

            /// <summary>
            /// ClientID_Ext
            /// Properties for ClientID datamember
            /// </summary>
            public decimal NetQty_Ext
            {
                get
                {
                    return this.NetQty;
                }
                set
                {
                    this.NetQty = value;
                }
            }

            /// <summary>
            /// ClientID_Ext
            /// Properties for ClientID datamember
            /// </summary>
            public decimal OrderedQty_Ext
            {
                get
                {
                    return this.OrderedQty;
                }
                set
                {
                    this.OrderedQty = value;
                }
            }


            /// <summary>
            /// Code_Ext
            /// Properties for Code datamember
            /// </summary>
            public String Notes_Ext
            {
                get
                {
                    return this.Notes;
                }
                set
                {
                    this.Notes = value;
                }
            }



            /// <summary>
            /// Code_Ext
            /// Properties for Code datamember
            /// </summary>
            public Guid ID_Ext
            {
                get
                {
                    return this.ID;
                }
                set
                {
                    this.ID = value;
                }
            }

            /// <summary>
            /// Code_Ext
            /// Properties for Code datamember
            /// </summary>
            public Guid BOLHdrID_Ext
            {
                get
                {
                    return this.BOLHdrID;
                }
                set
                {
                    this.BOLHdrID = value;
                }
            }





        }

        // 2014.03.20  Ramesh M Added For CR#62322 added  Version testing method
        partial class Cloud_GetBOLCompartmentDetailsRow
        {
            /// <summary>
            /// CompartmentID_Ext
            /// Properties for CompartmentID datamember
            /// </summary>
            public Int32 CompartmentID_Ext
            {
                get
                {
                    return this.CompartmentID;
                }
                set
                {
                    this.CompartmentID = value;
                }
            }

            /// <summary>
            /// SystrxNo_Ext
            /// Properties for SystrxNo datamember
            /// </summary>
            public decimal GrossQty_Ext
            {
                get
                {
                    return this.GrossQty;
                }
                set
                {
                    this.GrossQty = value;
                }
            }

            /// <summary>
            /// Capacity_Ext
            /// Properties for Capacity datamember
            /// </summary>
            public String ProdCode_Ext
            {
                get
                {
                    return this.ProdCode;
                }
                set
                {
                    this.ProdCode = value;
                }
            }


            /// <summary>
            /// ClientID_Ext
            /// Properties for ClientID datamember
            /// </summary>
            public String BOLNo_Ext
            {
                get
                {
                    return this.BOLNo;
                }
                set
                {
                    this.BOLNo = value;
                }
            }

            /// <summary>
            /// ClientID_Ext
            /// Properties for ClientID datamember
            /// </summary>
            public Guid BOLHdrID_Ext
            {
                get
                {
                    return this.BOLHdrID;
                }
                set
                {
                    this.BOLHdrID = value;
                }
            }

            /// <summary>
            /// CompartmentID_Ext
            /// Properties for CompartmentID datamember
            /// </summary>
            public Guid BOLItemID_Ext
            {
                get
                {
                    return this.BOLItemID;
                }
                set
                {
                    this.BOLItemID = value;
                }
            }

            /// <summary>
            /// SystrxNo_Ext
            /// Properties for SystrxNo datamember
            /// </summary>
            public DateTime BOLDatetime_Ext
            {
                get
                {
                    return this.BOLDatetime;
                }
                set
                {
                    this.BOLDatetime = value;
                }
            }

            /// <summary>
            /// Capacity_Ext
            /// Properties for Capacity datamember
            /// </summary>
            public String SupplierCode_Ext
            {
                get
                {
                    return this.SupplierCode;
                }
                set
                {
                    this.SupplierCode = value;
                }
            }


            /// <summary>
            /// ClientID_Ext
            /// Properties for ClientID datamember
            /// </summary>
            public String SupplyPointCode_Ext
            {
                get
                {
                    return this.SupplyPointCode;
                }
                set
                {
                    this.SupplyPointCode = value;
                }
            }

            /// <summary>
            /// ClientID_Ext
            /// Properties for ClientID datamember
            /// </summary>
            public Decimal SystrxNo_Ext
            {
                get
                {
                    return this.SystrxNo;
                }
                set
                {
                    this.SystrxNo = value;
                }
            }


            /// <summary>
            /// ClientID_Ext
            /// Properties for ClientID datamember
            /// </summary>
            public Int32 SystrxLine_Ext
            {
                get
                {
                    return this.SystrxLine;
                }
                set
                {
                    this.SystrxLine = value;
                }
            }

            /// <summary>
            /// ClientID_Ext
            /// Properties for ClientID datamember
            /// </summary>
            public Decimal NetQty_Ext
            {
                get
                {
                    return this.NetQty;
                }
                set
                {
                    this.NetQty = value;
                }
            }

            /// <summary>
            /// ClientID_Ext
            /// Properties for ClientID datamember
            /// </summary>
            public Decimal OrderedQty_Ext
            {
                get
                {
                    return this.OrderedQty;
                }
                set
                {
                    this.OrderedQty = value;
                }
            }

            /// <summary>
            /// ClientID_Ext
            /// Properties for ClientID datamember
            /// </summary>
            public Decimal AvailableQty_Ext
            {
                get
                {
                    return this.AvailableQty;
                }
                set
                {
                    this.AvailableQty = value;
                }
            }

            /// <summary>
            /// ClientID_Ext
            /// Properties for ClientID datamember
            /// </summary>
            public String Notes_Ext
            {
                get
                {
                    return this.Notes;
                }
                set
                {
                    this.Notes = value;
                }
            }

        }


        // 2014.03.20  Ramesh M Added For CR#62322 added  Version testing method
        partial class Cloud_TW_GetProductCompartmentRow
        {


            /// <summary>
            /// Capacity_Ext
            /// Properties for Capacity datamember
            /// </summary>
            public String ProdCode_Ext
            {
                get
                {
                    return this.ProdCode;
                }
                set
                {
                    this.ProdCode = value;
                }
            }




            /// <summary>
            /// ClientID_Ext
            /// Properties for ClientID datamember
            /// </summary>
            public Decimal AvailbleQty_Ext
            {
                get
                {
                    return this.AvailbleQty;
                }
                set
                {
                    this.AvailbleQty = value;
                }
            }

            /// <summary>
            /// ClientID_Ext
            /// Properties for ClientID datamember
            /// </summary>
            public Int32 CompartmentID_Ext
            {
                get
                {
                    return this.CompartmentID;
                }
                set
                {
                    this.CompartmentID = value;
                }
            }

            /// <summary>
            /// Capacity_Ext
            /// Properties for Capacity datamember
            /// </summary>
            public String CompartmentCode_Ext
            {
                get
                {
                    return this.CompartmentCode;
                }
                set
                {
                    this.CompartmentCode = value;
                }
            }


        }

        // 2014.03.20  Ramesh M Added For CR#62322 added  Version testing method
        partial class Cloud_GetBOLDetailsRow
        {
            /// <summary>
            /// CompartmentID_Ext
            /// Properties for CompartmentID datamember
            /// </summary>
            public Int32 CompartmentID_Ext
            {
                get
                {
                    return this.CompartmentID;
                }
                set
                {
                    this.CompartmentID = value;
                }
            }

            /// <summary>
            /// SystrxNo_Ext
            /// Properties for SystrxNo datamember
            /// </summary>
            public decimal GrossQty_Ext
            {
                get
                {
                    return this.GrossQty;
                }
                set
                {
                    this.GrossQty = value;
                }
            }

            /// <summary>
            /// Capacity_Ext
            /// Properties for Capacity datamember
            /// </summary>
            public String ProdCode_Ext
            {
                get
                {
                    return this.ProdCode;
                }
                set
                {
                    this.ProdCode = value;
                }
            }


            /// <summary>
            /// ClientID_Ext
            /// Properties for ClientID datamember
            /// </summary>
            public String BOLNo_Ext
            {
                get
                {
                    return this.BOLNo;
                }
                set
                {
                    this.BOLNo = value;
                }
            }

            /// <summary>
            /// ClientID_Ext
            /// Properties for ClientID datamember
            /// </summary>
            public Guid BOLHdrID_Ext
            {
                get
                {
                    return this.BOLHdrID;
                }
                set
                {
                    this.BOLHdrID = value;
                }
            }

            /// <summary>
            /// CompartmentID_Ext
            /// Properties for CompartmentID datamember
            /// </summary>
            public Guid BOLItemID_Ext
            {
                get
                {
                    return this.BOLItemID;
                }
                set
                {
                    this.BOLItemID = value;
                }
            }

            /// <summary>
            /// SystrxNo_Ext
            /// Properties for SystrxNo datamember
            /// </summary>
            public DateTime BOLDatetime_Ext
            {
                get
                {
                    return this.BOLDatetime;
                }
                set
                {
                    this.BOLDatetime = value;
                }
            }

            /// <summary>
            /// Capacity_Ext
            /// Properties for Capacity datamember
            /// </summary>
            public String SupplierCode_Ext
            {
                get
                {
                    return this.SupplierCode;
                }
                set
                {
                    this.SupplierCode = value;
                }
            }


            /// <summary>
            /// ClientID_Ext
            /// Properties for ClientID datamember
            /// </summary>
            public String SupplyPointCode_Ext
            {
                get
                {
                    return this.SupplyPointCode;
                }
                set
                {
                    this.SupplyPointCode = value;
                }
            }

            /// <summary>
            /// ClientID_Ext
            /// Properties for ClientID datamember
            /// </summary>
            public Decimal SystrxNo_Ext
            {
                get
                {
                    return this.SystrxNo;
                }
                set
                {
                    this.SystrxNo = value;
                }
            }


            /// <summary>
            /// ClientID_Ext
            /// Properties for ClientID datamember
            /// </summary>
            public Int32 SystrxLine_Ext
            {
                get
                {
                    return this.SystrxLine;
                }
                set
                {
                    this.SystrxLine = value;
                }
            }

            /// <summary>
            /// ClientID_Ext
            /// Properties for ClientID datamember
            /// </summary>
            public Decimal NetQty_Ext
            {
                get
                {
                    return this.NetQty;
                }
                set
                {
                    this.NetQty = value;
                }
            }

            /// <summary>
            /// ClientID_Ext
            /// Properties for ClientID datamember
            /// </summary>
            public Decimal OrderedQty_Ext
            {
                get
                {
                    return this.OrderedQty;
                }
                set
                {
                    this.OrderedQty = value;
                }
            }

            /// <summary>
            /// ClientID_Ext
            /// Properties for ClientID datamember
            /// </summary>
            public String Notes_Ext
            {
                get
                {
                    return this.Notes;
                }
                set
                {
                    this.Notes = value;
                }
            }




        }


        partial class TW_GetSuppliersRow
        {
            /// <summary>
            /// CompartmentID_Ext
            /// Properties for CompartmentID datamember
            /// </summary>
            public Int32 SupplierID_Ext
            {
                get
                {
                    return this.SupplierID;
                }
                set
                {
                    this.SupplierID = value;
                }
            }

            /// <summary>
            /// SystrxNo_Ext
            /// Properties for SystrxNo datamember
            /// </summary>
            public String Code_Ext
            {
                get
                {
                    return this.Code;
                }
                set
                {
                    this.Code = value;
                }
            }

            /// <summary>
            /// Capacity_Ext
            /// Properties for Capacity datamember
            /// </summary>
            public String Descr_Ext
            {
                get
                {
                    return this.Descr;
                }
                set
                {
                    this.Descr = value;
                }
            }


            /// <summary>
            /// ClientID_Ext
            /// Properties for ClientID datamember
            /// </summary>
            public DateTime? LastModifiedDtTm_Ext
            {
                get
                {
                    if (this.IsLastModifiedDtTmNull())
                    {
                        return null;
                    }
                    return this.LastModifiedDtTm;
                }
                set
                {
                    if (value == null)
                    {
                        this.IsLastModifiedDtTmNull();
                    }
                    else
                    {
                        this.LastModifiedDtTm = Convert.ToDateTime(value);
                    }
                }
            }

            /// <summary>
            /// ClientID_Ext
            /// Properties for ClientID datamember
            /// </summary>
            public String CompanyID_Ext
            {
                get
                {
                    return this.CompanyID;
                }
                set
                {
                    this.CompanyID = value;
                }
            }



        }

        partial class Cloud_TW_GetVehicleTypeCompartmentRow
        {
            public Int32 CompartmentID_Ext
            {
                get
                {
                    return this.CompartmentID;
                }
                set
                {
                    this.CompartmentID = value;
                }
            }

            public String CompartmentCode_Ext
            {
                get
                {
                    return this.CompartmentCode;
                }
                set
                {
                    this.CompartmentCode = value;
                }
            }

        }

        partial class TW_GetSupplierSupplyPtRow
        {
            /// <summary>
            /// CompartmentID_Ext
            /// Properties for CompartmentID datamember
            /// </summary>
            public Int32 SupplierSupplyPtID_Ext
            {
                get
                {
                    return this.SupplierSupplyPtID;
                }
                set
                {
                    this.SupplierSupplyPtID = value;
                }
            }

            /// <summary>
            /// SystrxNo_Ext
            /// Properties for SystrxNo datamember
            /// </summary>
            public Int32 SupplierID_Ext
            {
                get
                {
                    return this.SupplierID;
                }
                set
                {
                    this.SupplierID = value;
                }
            }

            /// <summary>
            /// Capacity_Ext
            /// Properties for Capacity datamember
            /// </summary>
            public String SupplierSupplyPtCode_Ext
            {
                get
                {
                    return this.SupplierSupplyPtCode;
                }
                set
                {
                    this.SupplierSupplyPtCode = value;
                }
            }

            /// <summary>
            /// Capacity_Ext
            /// Properties for Capacity datamember
            /// </summary>
            public String SupplierSupplyPtDescr_Ext
            {
                get
                {
                    return this.SupplierSupplyPtDescr;
                }
                set
                {
                    this.SupplierSupplyPtDescr = value;
                }
            }


            /// <summary>
            /// ClientID_Ext
            /// Properties for ClientID datamember
            /// </summary>
            public DateTime? LastModifiedDtTm_Ext
            {
                //get
                //{
                //    return this.LastModifiedDtTm;
                //}
                //set
                //{
                //    this.LastModifiedDtTm = value;
                //}

                get
                {
                    if (this.IsLastModifiedDtTmNull())
                    {
                        return null;
                    }
                    return this.LastModifiedDtTm;
                }
                set
                {
                    if (value == null)
                    {
                        this.IsLastModifiedDtTmNull();
                    }
                    else
                    {
                        this.LastModifiedDtTm = Convert.ToDateTime(value);
                    }
                }

            }

            /// <summary>
            /// ClientID_Ext
            /// Properties for ClientID datamember
            /// </summary>
            public String CompanyID_Ext
            {
                get
                {
                    return this.CompanyID;
                }
                set
                {
                    this.CompanyID = value;
                }
            }



        }

        partial class TW_GetSupplierSupplyPtProductsRow
        {
            /// <summary>
            /// CompartmentID_Ext
            /// Properties for CompartmentID datamember
            /// </summary>
            public Int32 SupplierSupplyPtID_Ext
            {
                get
                {
                    return this.SupplierSupplyPtID;
                }
                set
                {
                    this.SupplierSupplyPtID = value;
                }
            }

            /// <summary>
            /// SystrxNo_Ext
            /// Properties for SystrxNo datamember
            /// </summary>
            public Int32 SupplierID_Ext
            {
                get
                {
                    return this.SupplierID;
                }
                set
                {
                    this.SupplierID = value;
                }
            }

            public Int32 SupplierPtID_Ext
            {
                get
                {
                    return this.SupplierPtID;
                }
                set
                {
                    this.SupplierPtID = value;
                }
            }

            /// <summary>
            /// Capacity_Ext
            /// Properties for Capacity datamember
            /// </summary>
            public String ProductCode_Ext
            {
                get
                {
                    return this.ProductCode;
                }
                set
                {
                    this.ProductCode = value;
                }
            }

            /// <summary>
            /// Capacity_Ext
            /// Properties for Capacity datamember
            /// </summary>
            public String ProductDescr_Ext
            {
                get
                {
                    return this.ProductDescr;
                }
                set
                {
                    this.ProductDescr = value;
                }
            }


            /// <summary>
            /// ClientID_Ext
            /// Properties for ClientID datamember
            /// </summary>
            public DateTime? LastModifiedDtTm_Ext
            {
                //get
                //{
                //    return this.LastModifiedDtTm;
                //}
                //set
                //{
                //    this.LastModifiedDtTm = value;
                //}

                get
                {
                    if (this.IsLastModifiedDtTmNull())
                    {
                        return null;
                    }
                    return this.LastModifiedDtTm;
                }
                set
                {
                    if (value == null)
                    {
                        this.IsLastModifiedDtTmNull();
                    }
                    else
                    {
                        this.LastModifiedDtTm = Convert.ToDateTime(value);
                    }
                }

            }

            /// <summary>
            /// ClientID_Ext
            /// Properties for ClientID datamember
            /// </summary>
            public String CompanyID_Ext
            {
                get
                {
                    return this.CompanyID;
                }
                set
                {
                    this.CompanyID = value;
                }
            }



        }


        partial class BOLHdr_WagonRow
        {
            /// <summary>
            /// CompartmentID_Ext
            /// Properties for CompartmentID datamember
            /// </summary>
            public Guid SessionID_Ext
            {
                get
                {
                    return this.SessionID;
                }
                set
                {
                    this.SessionID = value;
                }
            }

            /// <summary>
            /// SystrxNo_Ext
            /// Properties for SystrxNo datamember
            /// </summary>
            public Guid ID_Ext
            {
                get
                {
                    return this.ID;
                }
                set
                {
                    this.ID = value;
                }
            }

            public String BOLNo_Ext
            {
                get
                {
                    return this.BOLNo;
                }
                set
                {
                    this.BOLNo = value;
                }
            }


            public DateTime BOLDatetime_Ext
            {
                get
                {
                    return this.BOLDatetime;
                }
                set
                {
                    this.BOLDatetime = value;
                }
            }

            public Boolean NeedUpdate_Ext
            {
                get
                {
                    return this.NeedUpdate;
                }
                set
                {
                    this.NeedUpdate = value;
                }
            }






        }


        partial class OrderitemdetailsRow
        {
            /// <summary>
            /// CompartmentID_Ext
            /// Properties for CompartmentID datamember
            /// </summary>
            public Guid OrderID_Ext
            {
                get
                {
                    return this.OrderID;
                }
                set
                {
                    this.OrderID = value;
                }
            }

            /// <summary>
            /// SystrxNo_Ext
            /// Properties for SystrxNo datamember
            /// </summary>
            public Guid OrderItemID_Ext
            {
                get
                {
                    return this.OrderItemID;
                }
                set
                {
                    this.OrderItemID = value;
                }
            }

            public String ProdCode_Ext
            {
                get
                {
                    return this.ProdCode;
                }
                set
                {
                    this.ProdCode = value;
                }
            }


            public Decimal OrderedQty_Ext
            {
                get
                {
                    return this.OrderedQty1;
                }
                set
                {
                    this.OrderedQty1 = value;
                }
            }


            public String OrderNo_Ext
            {
                get
                {
                    return this.OrderNo;
                }
                set
                {
                    this.OrderNo = value;
                }
            }

            public String ProdName_Ext
            {
                get
                {
                    return this.ProdName;
                }
                set
                {
                    this.ProdName = value;
                }
            }

            public String Blend_Ext
            {
                get
                {
                    return this.Blend;
                }
                set
                {
                    this.Blend = value;
                }
            }


        }


        partial class cloud_TW_UpdateshipmentdetailsRow
        {
            /// <summary>
            /// CompartmentID_Ext
            /// Properties for CompartmentID datamember
            /// </summary>
            //public String Status_Ext
            //{
            //    get
            //    {
            //        return this.Status1;
            //    }
            //    set
            //    {
            //        this.Status1 = value;
            //    }
            //}

            public String StatusNew_Ext
            {
                get
                {
                    if (this.IsStatusNewNull())
                    {
                        return null;
                    }
                    return this.StatusNew;
                }
                set
                {
                    this.StatusNew = value;
                }
            }

            //public String Reason_Ext
            //{
            //    get
            //    {
            //        return this.Reason;
            //    }
            //    set
            //    {
            //        this.Reason = value;
            //    }
            //}

            public String Reason_Ext
            {
                get
                {
                    if (this.IsReasonNull())
                    {
                        return null;
                    }
                    return this.Reason;
                }
                set
                {
                    this.Reason = value;
                }
            }


        }

        //Get EOD List added by Vinoth
        partial class Cloud_GetEODDetailsRow
        {
            /// <summary>
            /// CompartmentID_Ext
            /// Properties for CompartmentID datamember
            /// </summary>
            public Int32 CompartmentID_Ext
            {
                get
                {
                    return this.CompartmentID;
                }
                set
                {
                    this.CompartmentID = value;
                }
            }

            /// <summary>
            /// SystrxNo_Ext
            /// Properties for SystrxNo datamember
            /// </summary>
            public decimal GrossQty_Ext
            {
                get
                {
                    return this.GrossQty;
                }
                set
                {
                    this.GrossQty = value;
                }
            }

            /// <summary>
            /// Capacity_Ext
            /// Properties for Capacity datamember
            /// </summary>
            public String ProdCode_Ext
            {
                get
                {
                    return this.ProdCode;
                }
                set
                {
                    this.ProdCode = value;
                }
            }


            /// <summary>
            /// ClientID_Ext
            /// Properties for ClientID datamember
            /// </summary>
            public String BOLNo_Ext
            {
                get
                {
                    return this.BOLNo;
                }
                set
                {
                    this.BOLNo = value;
                }
            }

            /// <summary>
            /// ClientID_Ext
            /// Properties for ClientID datamember
            /// </summary>
            public Guid BOLHdrID_Ext
            {
                get
                {
                    return this.BOLHdrID;
                }
                set
                {
                    this.BOLHdrID = value;
                }
            }

            /// <summary>
            /// CompartmentID_Ext
            /// Properties for CompartmentID datamember
            /// </summary>
            public Guid BOLItemID_Ext
            {
                get
                {
                    return this.BOLItemID;
                }
                set
                {
                    this.BOLItemID = value;
                }
            }

            /// <summary>
            /// SystrxNo_Ext
            /// Properties for SystrxNo datamember
            /// </summary>
            public DateTime BOLDatetime_Ext
            {
                get
                {
                    return this.BOLDatetime;
                }
                set
                {
                    this.BOLDatetime = value;
                }
            }

            /// <summary>
            /// Capacity_Ext
            /// Properties for Capacity datamember
            /// </summary>
            public String SupplierCode_Ext
            {
                get
                {
                    return this.SupplierCode;
                }
                set
                {
                    this.SupplierCode = value;
                }
            }


            /// <summary>
            /// ClientID_Ext
            /// Properties for ClientID datamember
            /// </summary>
            public String SupplyPointCode_Ext
            {
                get
                {
                    return this.SupplyPointCode;
                }
                set
                {
                    this.SupplyPointCode = value;
                }
            }

            /// <summary>
            /// ClientID_Ext
            /// Properties for ClientID datamember
            /// </summary>
            public Decimal SystrxNo_Ext
            {
                get
                {
                    return this.SystrxNo;
                }
                set
                {
                    this.SystrxNo = value;
                }
            }


            /// <summary>
            /// ClientID_Ext
            /// Properties for ClientID datamember
            /// </summary>
            public Int32 SystrxLine_Ext
            {
                get
                {
                    return this.SystrxLine;
                }
                set
                {
                    this.SystrxLine = value;
                }
            }

            /// <summary>
            /// ClientID_Ext
            /// Properties for ClientID datamember
            /// </summary>
            public Decimal NetQty_Ext
            {
                get
                {
                    return this.NetQty;
                }
                set
                {
                    this.NetQty = value;
                }
            }

            /// <summary>
            /// ClientID_Ext
            /// Properties for ClientID datamember
            /// </summary>
            public Decimal OrderedQty_Ext
            {
                get
                {
                    return this.OrderedQty;
                }
                set
                {
                    this.OrderedQty = value;
                }
            }

            /// <summary>
            /// ClientID_Ext
            /// Properties for ClientID datamember
            /// </summary>
            public Decimal AvailableQty_Ext
            {
                get
                {
                    return this.AvailableQty;
                }
                set
                {
                    this.AvailableQty = value;
                }
            }

            /// <summary>
            /// ClientID_Ext
            /// Properties for ClientID datamember
            /// </summary>
            public Decimal SalesQty_Ext
            {
                get
                {
                    return this.SalesQty;
                }
                set
                {
                    this.SalesQty = value;
                }
            }

            /// <summary>
            /// ClientID_Ext
            /// Properties for ClientID datamember
            /// </summary>
            public String Notes_Ext
            {
                get
                {
                    if (this.IsNotesNull())
                    {
                        return "";
                    }
                    return this.Notes;
                }
                set
                {
                    this.Notes = value;
                }
            }





        }

        //Get BOD List added by Vinoth
        partial class Cloud_GetBODDetailsRow
        {
            /// <summary>
            /// CompartmentID_Ext
            /// Properties for CompartmentID datamember
            /// </summary>
            public Int32 CompartmentID_Ext
            {
                get
                {
                    return this.CompartmentID;
                }
                set
                {
                    this.CompartmentID = value;
                }
            }


            /// <summary>
            /// Capacity_Ext
            /// Properties for Capacity datamember
            /// </summary>
            public String ProdCode_Ext
            {
                get
                {
                    return this.ProdCode;
                }
                set
                {
                    this.ProdCode = value;
                }
            }


            /// <summary>
            /// ClientID_Ext
            /// Properties for ClientID datamember
            /// </summary>
            public String BOLNo_Ext
            {
                get
                {
                    return this.BOLNo;
                }
                set
                {
                    this.BOLNo = value;
                }
            }

            /// <summary>
            /// ClientID_Ext
            /// Properties for ClientID datamember
            /// </summary>
            public Guid BOLHdrID_Ext
            {
                get
                {
                    return this.BOLHdrID;
                }
                set
                {
                    this.BOLHdrID = value;
                }
            }

            /// <summary>
            /// CompartmentID_Ext
            /// Properties for CompartmentID datamember
            /// </summary>
            public Guid BOLItemID_Ext
            {
                get
                {
                    return this.BOLItemID;
                }
                set
                {
                    this.BOLItemID = value;
                }
            }

            /// <summary>
            /// SystrxNo_Ext
            /// Properties for SystrxNo datamember
            /// </summary>
            public DateTime BOLDatetime_Ext
            {
                get
                {
                    return this.BOLDatetime;
                }
                set
                {
                    this.BOLDatetime = value;
                }
            }



            /// <summary>
            /// ClientID_Ext
            /// Properties for ClientID datamember
            /// </summary>
            public Decimal AvailableQty_Ext
            {
                get
                {
                    return this.AvailableQty;
                }
                set
                {
                    this.AvailableQty = value;
                }
            }

        }

        partial class Cloud_GetBODHistoryRow
        {
            /// <summary>
            /// CompartmentID_Ext
            /// Properties for CompartmentID datamember
            /// </summary>
            public Int32 CompartmentID_Ext
            {
                get
                {
                    return this.CompartmentID;
                }
                set
                {
                    this.CompartmentID = value;
                }
            }


            /// <summary>
            /// Capacity_Ext
            /// Properties for Capacity datamember
            /// </summary>
            public String ProdCode_Ext
            {
                get
                {
                    return this.ProdCode;
                }
                set
                {
                    this.ProdCode = value;
                }
            }


            /// <summary>
            /// ClientID_Ext
            /// Properties for ClientID datamember
            /// </summary>
            public String BOLNo_Ext
            {
                get
                {
                    return this.BOLNo;
                }
                set
                {
                    this.BOLNo = value;
                }
            }

            /// <summary>
            /// ClientID_Ext
            /// Properties for ClientID datamember
            /// </summary>
            public Guid BOLHdrID_Ext
            {
                get
                {
                    return this.BOLHdrID;
                }
                set
                {
                    this.BOLHdrID = value;
                }
            }

            /// <summary>
            /// CompartmentID_Ext
            /// Properties for CompartmentID datamember
            /// </summary>
            public Guid BOLItemID_Ext
            {
                get
                {
                    return this.BOLItemID;
                }
                set
                {
                    this.BOLItemID = value;
                }
            }

            /// <summary>
            /// SystrxNo_Ext
            /// Properties for SystrxNo datamember
            /// </summary>
            public DateTime BOLDatetime_Ext
            {
                get
                {
                    return this.BOLDatetime;
                }
                set
                {
                    this.BOLDatetime = value;
                }
            }



            /// <summary>
            /// ClientID_Ext
            /// Properties for ClientID datamember
            /// </summary>
            public Decimal AvailableQty_Ext
            {
                get
                {
                    return this.AvailableQty;
                }
                set
                {
                    this.AvailableQty = value;
                }
            }

        }

        partial class Cloud_GetEODHistoryRow
        {
            /// <summary>
            /// CompartmentID_Ext
            /// Properties for CompartmentID datamember
            /// </summary>
            public Int32 CompartmentID_Ext
            {
                get
                {
                    return this.CompartmentID;
                }
                set
                {
                    this.CompartmentID = value;
                }
            }

            /// <summary>
            /// SystrxNo_Ext
            /// Properties for SystrxNo datamember
            /// </summary>
            public decimal GrossQty_Ext
            {
                get
                {
                    return this.GrossQty;
                }
                set
                {
                    this.GrossQty = value;
                }
            }

            /// <summary>
            /// Capacity_Ext
            /// Properties for Capacity datamember
            /// </summary>
            public String ProdCode_Ext
            {
                get
                {
                    return this.ProdCode;
                }
                set
                {
                    this.ProdCode = value;
                }
            }


            /// <summary>
            /// ClientID_Ext
            /// Properties for ClientID datamember
            /// </summary>
            public String BOLNo_Ext
            {
                get
                {
                    return this.BOLNo;
                }
                set
                {
                    this.BOLNo = value;
                }
            }

            /// <summary>
            /// ClientID_Ext
            /// Properties for ClientID datamember
            /// </summary>
            public Guid BOLHdrID_Ext
            {
                get
                {
                    return this.BOLHdrID;
                }
                set
                {
                    this.BOLHdrID = value;
                }
            }

            /// <summary>
            /// CompartmentID_Ext
            /// Properties for CompartmentID datamember
            /// </summary>
            public Guid BOLItemID_Ext
            {
                get
                {
                    return this.BOLItemID;
                }
                set
                {
                    this.BOLItemID = value;
                }
            }

            /// <summary>
            /// SystrxNo_Ext
            /// Properties for SystrxNo datamember
            /// </summary>
            public DateTime BOLDatetime_Ext
            {
                get
                {
                    return this.BOLDatetime;
                }
                set
                {
                    this.BOLDatetime = value;
                }
            }

            /// <summary>
            /// Capacity_Ext
            /// Properties for Capacity datamember
            /// </summary>
            public String SupplierCode_Ext
            {
                get
                {
                    return this.SupplierCode;
                }
                set
                {
                    this.SupplierCode = value;
                }
            }


            /// <summary>
            /// ClientID_Ext
            /// Properties for ClientID datamember
            /// </summary>
            public String SupplyPointCode_Ext
            {
                get
                {
                    return this.SupplyPointCode;
                }
                set
                {
                    this.SupplyPointCode = value;
                }
            }

            /// <summary>
            /// ClientID_Ext
            /// Properties for ClientID datamember
            /// </summary>
            public Decimal SystrxNo_Ext
            {
                get
                {
                    return this.SystrxNo;
                }
                set
                {
                    this.SystrxNo = value;
                }
            }


            /// <summary>
            /// ClientID_Ext
            /// Properties for ClientID datamember
            /// </summary>
            public Int32 SystrxLine_Ext
            {
                get
                {
                    return this.SystrxLine;
                }
                set
                {
                    this.SystrxLine = value;
                }
            }

            /// <summary>
            /// ClientID_Ext
            /// Properties for ClientID datamember
            /// </summary>
            public Decimal NetQty_Ext
            {
                get
                {
                    return this.NetQty;
                }
                set
                {
                    this.NetQty = value;
                }
            }

            /// <summary>
            /// ClientID_Ext
            /// Properties for ClientID datamember
            /// </summary>
            public Decimal OrderedQty_Ext
            {
                get
                {
                    return this.OrderedQty;
                }
                set
                {
                    this.OrderedQty = value;
                }
            }

            /// <summary>
            /// ClientID_Ext
            /// Properties for ClientID datamember
            /// </summary>
            public Decimal AvailableQty_Ext
            {
                get
                {
                    return this.AvailableQty;
                }
                set
                {
                    this.AvailableQty = value;
                }
            }

            /// <summary>
            /// ClientID_Ext
            /// Properties for ClientID datamember
            /// </summary>
            public Decimal SalesQty_Ext
            {
                get
                {
                    return this.SalesQty;
                }
                set
                {
                    this.SalesQty = value;
                }
            }

            /// <summary>
            /// ClientID_Ext
            /// Properties for ClientID datamember
            /// </summary>
            public String Notes_Ext
            {
                get
                {
                    if (this.IsNotesNull())
                    {
                        return "";
                    }
                    return this.Notes;
                }
                set
                {
                    this.Notes = value;
                }
            }





        }

        partial class TW_GetINSiteRow
        {
            /// <summary>
            /// CompartmentID_Ext
            /// Properties for CompartmentID datamember
            /// </summary>
            public Int32 SiteID_Ext
            {
                get
                {
                    return this.SiteID;
                }
                set
                {
                    this.SiteID = value;
                }
            }


            /// <summary>
            /// Capacity_Ext
            /// Properties for Capacity datamember
            /// </summary>
            public String Code_Ext
            {
                get
                {
                    return this.Code;
                }
                set
                {
                    this.Code = value;
                }
            }


            /// <summary>
            /// ClientID_Ext
            /// Properties for ClientID datamember
            /// </summary>
            public String LongDescr_Ext
            {
                get
                {
                    return this.LongDescr;
                }
                set
                {
                    this.LongDescr = value;
                }
            }

            /// <summary>
            /// ClientID_Ext
            /// Properties for ClientID datamember
            /// </summary>
            public DateTime? LastModifiedDtTm_Ext
            {
                get
                {
                    if (this.IsLastModifiedDtTmNull())
                    {
                        return null;
                    }
                    return this.LastModifiedDtTm;
                }
                set
                {
                    if (value == null)
                    {
                        this.IsLastModifiedDtTmNull();
                    }
                    else
                    {
                        this.LastModifiedDtTm = Convert.ToDateTime(value);
                    }
                }
            }

            /// <summary>
            /// CompartmentID_Ext
            /// Properties for CompartmentID datamember
            /// </summary>
            public Int32 CustomerID_Ext
            {
                get
                {
                    return this.ClientID;
                }
                set
                {
                    this.ClientID = value;
                }
            }



        }

        partial class Cloud_GetTWLineFlushProductsRow
        {

            /// <summary>
            /// Capacity_Ext
            /// Properties for Capacity datamember
            /// </summary>
            public String ProductCode_Ext
            {
                get
                {
                    return this.ProdCode;
                }
                set
                {
                    this.ProdCode = value;
                }
            }

        }
        //Added by Vinoth-19-Aug-2015
        partial class Cloud_TW_GetVehicleMetersRow
        {
            /// <summary>
            /// MeterID_Ext
            /// Properties for CompartmentID datamember
            /// </summary>
            public Int32 MeterID_Ext
            {
                get
                {
                    return this.MeterID;
                }
                set
                {
                    this.MeterID = value;
                }
            }

            /// <summary>
            /// VehicleID_Ext
            /// Properties for VehicleID datamember
            /// </summary>
            public Int32 VehicleID_Ext
            {
                get
                {
                    return this.VehicleID;
                }
                set
                {
                    this.VehicleID = value;
                }
            }

            /// <summary>
            /// ClientID_Ext
            /// Properties for ClientID datamember
            /// </summary>
            public String CustomerID_Ext
            {
                get
                {
                    return this.CustomerID;
                }
                set
                {
                    this.CustomerID = value;
                }
            }


            /// <summary>
            /// Code_Ext
            /// Properties for Code datamember
            /// </summary>
            public String Code_Ext
            {
                get
                {
                    return this.Code;
                }
                set
                {
                    this.Code = value;
                }
            }

            /// <summary>
            /// Code_Ext
            /// Properties for Code datamember
            /// </summary>
            public Boolean NeedUpdate_Ext
            {
                get
                {
                    if (this.IsNeedUpdateNull())
                    {
                        return false;
                    }
                    return this.NeedUpdate;
                }
                set
                {
                    this.NeedUpdate = value;
                }
            }

        }

        //Added by Vinoth-20-Aug-2015
        partial class Cloud_TW_GetVehicleMetersTotalizerRow
        {
            /// <summary>
            /// MeterID_Ext
            /// Properties for CompartmentID datamember
            /// </summary>
            public Int32 MeterID_Ext
            {
                get
                {
                    return this.MeterID;
                }
                set
                {
                    this.MeterID = value;
                }
            }

            /// <summary>
            /// Code_Ext
            /// Properties for Cloud_TW_GetVehicleMetersTotalizerRow datamember
            /// </summary>
            public String Code_Ext
            {
                get
                {
                    return this.Code;
                }
                set
                {
                    this.Code = value;
                }
            }

            /// <summary>
            /// VehicleID_Ext
            /// Properties for VehicleID datamember
            /// </summary>
            public Decimal MeterTotal_Ext
            {
                get
                {
                    return this.MeterTotal;
                }
                set
                {
                    this.MeterTotal = value;
                }
            }

            /// <summary>
            /// ClientID_Ext
            /// Properties for ClientID datamember
            /// </summary>
            public Decimal ShiftTotal_Ext
            {
                get
                {
                    return this.ShiftTotal;
                }
                set
                {
                    this.ShiftTotal = value;
                }
            }


            /// <summary>
            /// Code_Ext
            /// Properties for Code datamember
            /// </summary>
            public Decimal Total_Ext
            {
                get
                {
                    return this.Total;
                }
                set
                {
                    this.Total = value;
                }
            }
        }

        /// <summary>
        /// Cloud_TW_GetVehicleSiteIDTableAdapter
        /// Partial Vehicle row class to get and set datamembers
        /// </summary>
        partial class Cloud_TW_GetVehicleSiteIDRow
        {
            /// <summary>
            /// CompartmentID_Ext
            /// Properties for CompartmentID datamember
            /// </summary>
            public Int32 SiteID_Ext
            {
                get
                {
                    return this.SiteID;
                }
                set
                {
                    this.SiteID = value;
                }
            }


            /// <summary>
            /// Capacity_Ext
            /// Properties for Capacity datamember
            /// </summary>
            public String Code_Ext
            {
                get
                {
                    return this.Code;
                }
                set
                {
                    this.Code = value;
                }
            }


            /// <summary>
            /// ClientID_Ext
            /// Properties for ClientID datamember
            /// </summary>
            public String LongDescr_Ext
            {
                get
                {
                    return this.LongDescr;
                }
                set
                {
                    this.LongDescr = value;
                }
            }

            /// <summary>
            /// ClientID_Ext
            /// Properties for ClientID datamember
            /// </summary>
            public DateTime? LastModifiedDtTm_Ext
            {
                get
                {
                    if (this.IsLastModifiedDtTmNull())
                    {
                        return null;
                    }
                    return this.LastModifiedDtTm;
                }
                set
                {
                    if (value == null)
                    {
                        this.IsLastModifiedDtTmNull();
                    }
                    else
                    {
                        this.LastModifiedDtTm = Convert.ToDateTime(value);
                    }
                }
            }

            /// <summary>
            /// CompartmentID_Ext
            /// Properties for CompartmentID datamember
            /// </summary>
            public Int32 CustomerID_Ext
            {
                get
                {
                    return this.ClientID;
                }
                set
                {
                    this.ClientID = value;
                }
            }

        }

    }

}



namespace DeliveryStreamCloudWCF.DataAccess.DALTableAdapters
{
    partial class OrderItemComponentTableAdapter
    {
    }

    partial class DeliveryDetailsTableAdapter
    {
    }

    partial class DriversTableAdapter
    {
    }

    partial class SignatureImageTableAdapter
    {
    }

    partial class VehicleTableAdapter
    {
    }

    partial class BOLHdrTableAdapter
    {
    }

    partial class LoginHistoryTableAdapter
    {
    }

    partial class LoadTableAdapter
    {
    }

    partial class LoadStatusHistoryTableAdapter
    {
    }

    partial class OrderDispatchHistoryTableAdapter
    {
    }

    partial class OrderTableAdapter
    {
    }

    partial class Cloud_TimeRemainingDriverSummaryTableAdapter
    {
    }

    partial class TimeRemainingDriverSummaryTableAdapter
    {
    }

    partial class LoginUserTableAdapter
    {
    }

    partial class WarehouseTableAdapter
    {
    }

    partial class OrderItemTableAdapter
    {
    }

    partial class GPSHistoryTableAdapter
    {
    }


    public partial class LoginSessionTableAdapter
    {
    }
}
