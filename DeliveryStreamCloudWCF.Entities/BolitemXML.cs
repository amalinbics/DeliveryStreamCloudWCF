using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace DeliveryStreamCloudWCF.Entities
{
    /// <summary>
    /// BOL Item class
    /// </summary>
    [DataContract]
    public class BolitemXML
    {
        /// <summary>
        /// SysTrxNo
        /// Properties for SysTrxNo datamember
        /// </summary>
        [DataMember]
        public Decimal SysTrxNo 
        {
            get;
            set;
        }

        /// <summary>
        /// SysTrxLine
        /// Properties for SysTrxLine datamember
        /// </summary>
        [DataMember]
        public Int32 SysTrxLine
        {
            get;
            set;
        }

        /// <summary>
        /// ComponentNo
        /// Properties for ComponentNo datamember
        /// </summary>
        [DataMember]
        public Int32 ComponentNo 
        {
            get;
            set;
        }

        /// <summary>
        /// GrossQty
        /// Properties for GrossQty datamember
        /// </summary>
        [DataMember]
        public Decimal GrossQty 
        {
            get;
            set;
        }

        /// <summary>
        /// NetQty
        /// Properties for NetQty datamember
        /// </summary>
        [DataMember]
        public Decimal NetQty 
        {
            get;
            set;
        }

        /// <summary>
        /// BOLQtyVarianceReason 
        /// Properties for BOLQtyVarianceReason  datamember
        /// </summary>
        [DataMember]
        public string BOLQtyVarianceReason 
        {
            get;
            set;
        }

        /// <summary>
        /// DeviceID 
        /// Properties for DeviceID  datamember
        /// </summary>
        [DataMember]
        public String DeviceID
        {
            get;
            set;
        }

        /// <summary>
        /// DeviceTime 
        /// Properties for DeviceTime  datamember
        /// </summary>
        [DataMember]
        public DateTime DeviceTime
        {
            get;
            set;
        }

        /// <summary>
        /// AssignedDriverLoginID
        /// Properties for AssignedDriverLoginID datamember
        /// </summary>
        [DataMember]
        public Int32 AssignedDriverLoginID
        {
            get;
            set;
        }

        /// <summary>
        /// AssignedVehicleID
        /// Properties for AssignedVehicleID datamember
        /// </summary>
        [DataMember]
        public String AssignedVehicleID
        {
            get;
            set;
        }

        /// <summary>
        /// ExtSysTrxLine
        /// Properties for ExtSysTrxLine datamember
        /// </summary>
        [DataMember]
        public Int32 ExtSysTrxLine
        {
            get;
            set;
        }
        /// <summary>
        /// OrderItemID
        /// Properties for OrderItemID datamember
        /// </summary>
        [DataMember]
        public Guid OrderItemID
        {
            get;
            set;
        }
    }
}
