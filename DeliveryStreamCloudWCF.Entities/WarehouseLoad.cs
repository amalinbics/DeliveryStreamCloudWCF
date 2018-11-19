//2013.11.15 FSWW, Ramesh M Added For CR#59831  to Get warehouse user loads

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace DeliveryStreamCloudWCF.Entities
{
    /// <summary>
    /// Load class
    /// </summary>
    [DataContract]
    public class WarehouseLoad
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public WarehouseLoad()
        {
            Orders = new List<Order>();
        }

        /// <summary>
        /// ID
        /// Properties for ID datamember
        /// </summary>
        [DataMember]
        public Guid ID
        {
            get;
            set;
        }

        /// <summary>
        /// LoadNo
        /// Properties for LoadNo datamember
        /// </summary>
        [DataMember]
        public String LoadNo
        {
            get;
            set;
        }

        /// <summary>
        /// CustomerID
        /// Properties for CustomerID datamember
        /// </summary>
        [DataMember]
        public String CustomerID
        {
            get;
            set;
        }

        /// <summary>
        /// VehicleID
        /// Properties for VehicleID datamember
        /// </summary>
        [DataMember]
        public Int32 VehicleID
        {
            get;
            set;
        }

        /// <summary>
        /// DriverID
        /// Properties for DriverID datamember
        /// </summary>
        [DataMember]
        public Int32 DriverID
        {
            get;
            set;
        }

        /// <summary>
        /// LoadStatusID
        /// Properties for LoadStatusID datamember
        /// </summary>
        [DataMember]
        public String LoadStatusID
        {
            get;
            set;
        }

        /// <summary>
        /// FSRule_BOLWaitTime
        /// Properties for FSRule_BOLWaitTime datamember
        /// </summary>
        [DataMember]
        public Boolean FSRule_BOLWaitTime
        {
            get;
            set;
        }

        /// <summary>
        /// FSRule_SiteWaitTime
        /// Properties for FSRule_SiteWaitTime datamember
        /// </summary>
        [DataMember]
        public Boolean FSRule_SiteWaitTime
        {
            get;
            set;
        }

        /// <summary>
        /// FSRule_SplitLoad
        /// Properties for FSRule_SplitLoad datamember
        /// </summary>
        [DataMember]
        public Boolean FSRule_SplitLoad
        {
            get;
            set;
        }

        /// <summary>
        /// FSRule_SplitDrop
        /// Properties for FSRule_SplitDrop datamember
        /// </summary>
        [DataMember]
        public Boolean FSRule_SplitDrop
        {
            get;
            set;
        }

        /// <summary>
        /// FSRule_PumpOut
        /// Properties for FSRule_PumpOut datamember
        /// </summary>
        [DataMember]
        public Boolean FSRule_PumpOut
        {
            get;
            set;
        }

        /// <summary>
        /// FSRule_Diversion
        /// Properties for FSRule_Diversion datamember
        /// </summary>
        [DataMember]
        public Boolean FSRule_Diversion
        {
            get;
            set;
        }

        /// <summary>
        /// FSRule_MinLoad
        /// Properties for FSRule_MinLoad datamember
        /// </summary>
        [DataMember]
        public Boolean FSRule_MinLoad
        {
            get;
            set;
        }

        /// <summary>
        /// FSRule_Other
        /// Properties for FSRule_Other datamember
        /// </summary>
        [DataMember]
        public Boolean FSRule_Other
        {
            get;
            set;
        }

        /// <summary>
        /// FSRule_BOLWaitTime
        /// Properties for FSRule_BOLWaitTime datamember
        /// </summary>
        [DataMember]
        public Boolean FSRule_BOLWaitTime_Reason
        {
            get;
            set;
        }

        /// <summary>
        /// FSRule_SiteWaitTime
        /// Properties for FSRule_SiteWaitTime datamember
        /// </summary>
        [DataMember]
        public Boolean FSRule_SiteWaitTime_Reason
        {
            get;
            set;
        }

        /// <summary>
        /// FSRule_SplitLoad
        /// Properties for FSRule_SplitLoad datamember
        /// </summary>
        [DataMember]
        public Boolean FSRule_SplitLoad_Reason
        {
            get;
            set;
        }

        /// <summary>
        /// FSRule_SplitDrop
        /// Properties for FSRule_SplitDrop datamember
        /// </summary>
        [DataMember]
        public Boolean FSRule_SplitDrop_Reason
        {
            get;
            set;
        }

        /// <summary>
        /// FSRule_PumpOut
        /// Properties for FSRule_PumpOut datamember
        /// </summary>
        [DataMember]
        public Boolean FSRule_PumpOut_Reason
        {
            get;
            set;
        }

        /// <summary>
        /// FSRule_Diversion
        /// Properties for FSRule_Diversion datamember
        /// </summary>
        [DataMember]
        public Boolean FSRule_Diversion_Reason
        {
            get;
            set;
        }

        /// <summary>
        /// FSRule_MinLoad
        /// Properties for FSRule_MinLoad datamember
        /// </summary>
        [DataMember]
        public Boolean FSRule_MinLoad_Reason
        {
            get;
            set;
        }

        /// <summary>
        /// FSRule_Other
        /// Properties for FSRule_Other datamember
        /// </summary>
        [DataMember]
        public Boolean FSRule_Other_Reason
        {
            get;
            set;
        }

        /// <summary>
        /// Percent Tolerance
        /// </summary>
        [DataMember]
        public decimal? PercentTolerance
        { get; set; }

        /// <summary>
        /// Qty Tolerance
        /// </summary>
        [DataMember]
        public decimal? QtyTolerance
        { get; set; }

        /// <summary>
        /// OrderLoadReviewEnabled
        /// </summary>
        [DataMember]
        public string OrderLoadReviewEnabled
        { get; set; }

        /// <summary>
        /// UndispatchRequest
        /// </summary>
        [DataMember]
        public int? UndispatchRequest
        { get; set; }

        /// <summary>
        /// Undispatched
        /// </summary>
        [DataMember]
        public int? Undispatched
        { get; set; }

        /// <summary>
        /// Orders
        /// Properties for Orders datamember
        /// </summary>
        [DataMember]
        public List<Order> Orders
        {
            get;
            set;
        }

        /// <summary>
        /// BolHdr
        /// Properties for BolHdr datamember
        /// </summary>
        [DataMember]
        public List<BolHdr> BolHdr
        {
            get;
            set;
        }
        /// <summary>
        /// LoadType
        /// Properties for LoadType datamember
        /// </summary>
        [DataMember]
        public string LoadType
        { get; 
          set;
        }
        /// <summary>
        /// AssignedDriverID
        /// Properties for AssignedDriverID datamember
        /// </summary>
        [DataMember]
        public Int32 AssignedDriverID
        {
            get;
            set;
        }
        /// <summary>
        /// AssignedDriverName
        /// Properties for AssignedDriverName datamember
        /// </summary>
        [DataMember]
        public String AssignedDriverName
        {
            get;
            set;
        }
      
        /// <summary>
        /// AssignedVehicleName
        /// Properties for AssignedVehicleName datamember
        /// </summary>
        [DataMember]
        public String AssignedVehicleCode
        {
            get;
            set;
        }

        
    }
}
