using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace DeliveryStreamCloudWCF.Entities
{
    /// <summary>
    /// DeliveryDetailsXML class
    /// </summary>
    [DataContract]
    public class DeliveryDetailsXML
    {

        /// <summary>
        /// afterVolume
        /// Properties for afterVolume datamember
        /// </summary>
        [DataMember]
        public Decimal? AfterVolume
        {
            get;
            set;
        }

        /// <summary>
        /// beforeVolume
        /// Properties for beforeVolume datamember
        /// </summary>
        [DataMember]
        public Decimal? BeforeVolume
        {
            get;
            set;
        }

        /// <summary>
        /// BOLNo
        /// Properties for BOLNo datamember
        /// </summary>
        [DataMember]
        public String BOLNo
        {
            get;
            set;
        }

        /// <summary>
        /// delivDtTm
        /// Properties for delivDtTm datamember
        /// </summary>
        [DataMember]
        public DateTime DelivDtTm
        {
            get;
            set;
        }

        /// <summary>
        /// delivered
        /// Properties for delivered datamember
        /// </summary>
        [DataMember]
        public String Delivered
        {
            get;
            set;
        }


        /// <summary>
        /// DeliveryQtyVarianceReason
        /// Properties for DeliveryQtyVarianceReason datamember
        /// </summary>
        [DataMember]
        public String DeliveryQtyVarianceReason
        {
            get;
            set;
        }

        /// <summary>
        /// deviceID
        /// Properties for deviceID datamember
        /// </summary>
        [DataMember]
        public String DeviceID
        {
            get;
            set;
        }
        /// <summary>
        /// deviceTime
        /// Properties for deviceTime datamember
        /// </summary>
        [DataMember]
        public DateTime DeviceTime
        {
            get;
            set;
        }


        /// <summary>
        /// grossQty
        /// Properties for grossQty datamember
        /// </summary>
        [DataMember]
        public Decimal GrossQty
        {
            get;
            set;
        }

        /// <summary>
        /// Image
        /// Properties for Image datamember
        /// </summary>
        [DataMember]
        public String Image
        {
            get;
            set;
        }

        /// <summary>
        /// netQty
        /// Properties for netQty datamember
        /// </summary>
        [DataMember]
        public Decimal NetQty
        {
            get;
            set;
        }


        /// <summary>
        /// Notes
        /// Properties for Notes datamember
        /// </summary>
        [DataMember]
        public String Notes
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


        /// <summary>
        /// PONo
        /// Properties for PONo datamember
        /// </summary>
        [DataMember]
        public String PONo
        {
            get;
            set;
        }
        /// <summary>
        /// PreOrderItemID
        /// Properties for PreOrderItemID datamember
        /// </summary>
        [DataMember]
        public Guid PreOrderItemID
        {
            get;
            set;
        }


    }
}
