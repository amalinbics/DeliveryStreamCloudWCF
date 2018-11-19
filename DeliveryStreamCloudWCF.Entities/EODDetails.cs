using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace DeliveryStreamCloudWCF.Entities
{

    [DataContract]
    public class EODDetails
    {
        [DataMember]
        public Guid BOLItemID
        {
            get;
            set;
        }
        [DataMember]
        public String ClientID
        {
            get;
            set;
        }
        [DataMember]
        public String IsOverShort
        {
            get;
            set;
        }
        [DataMember]
        public String IsRetained
        {
            get;
            set;
        }
        [DataMember]
        public String RetainedVehicleID
        {
            get;
            set;
        }
        [DataMember]
        public Int32 ToSiteID
        {
            get;
            set;
        }

        [DataMember]
        public Int32 Updatedby
        {
            get;
            set;
        }
        [DataMember]
        public Decimal OvertSortQty
        {
            get;
            set;
        }
        [DataMember]
        public Decimal RetainedQty
        {
            get;
            set;
        }

    }

    [DataContract]
    public class Cloud_TW_GetVehicleSiteID
    {
        [DataMember]
        public Int32 SiteID
        {
            get;
            set;
        }

        [DataMember]
        public String Code
        {
            get;
            set;
        }
        
        [DataMember]
        public String LongDescr
        {
            get;
            set;
        }
        
        [DataMember]
        public DateTime? LastModifiedDtTm
        {
            get;
            set;
        }
        
        [DataMember]
        public Int32 CustomerID
        {
            get;
            set;
        }
    }


}
