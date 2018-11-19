using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace DeliveryStreamCloudWCF.Entities
{
    [DataContract]
    public class TWDeliveryDetails
    {
        /// <summary>
        /// ClientID
        /// Properties for ClientID datamember
        /// </summary>
        [DataMember]
        public String ClientID
        {
            get;
            set;
        }
        
         /// <summary>
        /// ClientID
        /// Properties for ClientID datamember
        /// </summary>
        [DataMember]
        public String VehicleID
        {
            get;
            set;
        }

        /// <summary>
        /// ProductCode
        /// Properties for ProductCode datamember
        /// </summary>
        [DataMember]
        public String ProductCode
        {
            get;
            set;
        }

        /// <summary>
        /// SessionID
        /// Properties for SessionID datamember
        /// </summary>
        [DataMember]
        public Guid SessionID
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
        /// CompartmentID
        /// Properties for CompartmentID datamember
        /// </summary>
        [DataMember]
        public Int32 CompartmentID
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
        /// DeliveryQty
        /// Properties for DeliveryQty datamember
        /// </summary>
        [DataMember]
        public Decimal DeliveryQty
        {
            get;
            set;
        }


        /// <summary>
        /// DeliveryDateTime
        /// Properties for DeliveryDateTime datamember
        /// </summary>
        [DataMember]
        public DateTime DeliveryDateTime
        {
            get;
            set;
        }

        /// <summary>
        /// LoginID
        /// Properties for LoginID datamember
        /// </summary>
        [DataMember]
        public Int32 LoginID
        {
            get;
            set;
        }

        /// <summary>
        /// DeviceID
        /// Properties for DeviceID datamember
        /// </summary>
        [DataMember]
        public String DeviceID
        {
            get;
            set;
        }

        /// <summary>
        /// DeviceDateTime
        /// Properties for DeviceDateTime datamember
        /// </summary>
        [DataMember]
        public DateTime DeviceDateTime
        {
            get;
            set;
        }

        /// <summary>
        /// BeforeVolume
        /// Properties for BeforeVolume datamember
        /// </summary>
        [DataMember]
        public Decimal BeforeVolume
        {
            get;
            set;
        }

        /// <summary>
        /// AfterVolume
        /// Properties for AfterVolume datamember
        /// </summary>
        [DataMember]
        public Decimal AfterVolume
        {
            get;
            set;
        }

        /// <summary>
        /// IsDelivered
        /// Properties for IsDelivered datamember
        /// </summary>
        [DataMember]
        public String IsDelivered
        {
            get;
            set;
        }

         /// <summary>
        /// TrailerCode
        /// Properties for TrailerCode datamember
        /// </summary>
        [DataMember]
        public String TrailerCode
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
        /// VehicleMeterID
        /// Properties for VehicleMeterID datamember
        /// </summary>
        [DataMember]
        public Int32 VehicleMeterID
        {
            get;
            set;
        }

        //[DataMember]
        //public String Img
        //{
        //    get;
        //    set;
        //}

    }
}
