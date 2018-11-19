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
    public class Bolitem
    {
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
        /// BOLHdrID
        /// Properties for BOLHdrID datamember
        /// </summary>
        [DataMember]
        public Guid BOLHdrID
        {
            get;
            set;
        }

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
        /// NeedUpdate
        /// Properties for NeedUpdate datamember
        /// </summary>
        [DataMember]
        public Boolean NeedUpdate 
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
    }
}
