using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace DeliveryStreamCloudWCF.Entities
{
    /// <summary>
    /// OrderItem class
    /// </summary>
    [DataContract]
    public class OrderItem
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public OrderItem()
        {
            OrderItemComponent = new List<OrderItemComponent>();
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
        /// OrderID
        /// Properties for OrderID datamember
        /// </summary>
        [DataMember]
        public Guid OrderID
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
        /// OrderedQty
        /// Properties for OrderedQty datamember
        /// </summary>
        [DataMember]
        public Decimal OrderedQty
        {
            get;
            set;
        }

        /// <summary>
        /// ProdCode
        /// Properties for ProdCode datamember
        /// </summary>
        [DataMember]
        public String ProdCode
        {
            get;
            set;
        }

        /// <summary>
        /// ProdName
        /// Properties for ProdName datamember
        /// </summary>
        [DataMember]
        public String ProdName
        {
            get;
            set;
        }

        /// <summary>
        /// ProdUOM
        /// Properties for ProdUOM datamember
        /// </summary>
        [DataMember]
        public String ProdUOM
        {
            get;
            set;
        }

        /// <summary>
        /// SupplyPointName
        /// Properties for SupplyPointName datamember
        /// </summary>
        [DataMember]
        public String SupplyPointName
        {
            get;
            set;
        }

        /// <summary>
        /// SupplyPointCode
        /// Properties for SupplyPointCode datamember
        /// </summary>
        [DataMember]
        public String SupplyPointCode
        {
            get;
            set;
        }

        /// <summary>
        /// SupplierCode
        /// Properties for SupplierCode datamember
        /// </summary>
        [DataMember]
        public String SupplierCode
        {
            get;
            set;
        }

        /// <summary>
        /// SupplierName
        /// Properties for SupplierName datamember
        /// </summary>
        [DataMember]
        public String SupplierName
        {
            get;
            set;
        }

        /// <summary>
        /// SupplyPointAddress1
        /// Properties for SupplyPointAddress1 datamember
        /// </summary>
        [DataMember]
        public String SupplyPointAddress1
        {
            get;
            set;
        }

        /// <summary>
        /// SupplyPointAddress2
        /// Properties for SupplyPointAddress2 datamember
        /// </summary>
        [DataMember]
        public String SupplyPointAddress2
        {
            get;
            set;
        }

        /// <summary>
        /// City
        /// Properties for City datamember
        /// </summary>
        [DataMember]
        public String City
        {
            get;
            set;
        }

        /// <summary>
        /// Country
        /// Properties for Country datamember
        /// </summary>
        [DataMember]
        public String Country
        {
            get;
            set;
        }

        /// <summary>
        /// State
        /// Properties for State datamember
        /// </summary>
        [DataMember]
        public String State
        {
            get;
            set;
        }

        /// <summary>
        /// Blend
        /// Properties for Blend datamember
        /// </summary>
        [DataMember]
        public String Blend
        {
            get;
            set;
        }

        /// <summary>
        /// Zip
        /// Properties for Zip datamember
        /// </summary>
        [DataMember]
        public String Zip
        {
            get;
            set;
        }

        /// <summary>
        /// OrderItemComponent
        /// Properties for OrderItemComponent datamember
        /// </summary>
        [DataMember]
        public List<OrderItemComponent> OrderItemComponent
        {
            get;
            set;
        }

        /// <summary>
        /// DeliveryDetails
        /// Properties for DeliveryDetails datamember
        /// </summary>
        [DataMember]
        public List<DeliveryDetails> DeliveryDetails
        {
            get;
            set;
        }

        /// <summary>
        /// Note
        /// Property for Order Item notes
        /// </summary>
        [DataMember]
        public String Note
        {
            get;
            set;
        }

        /// <summary>
        /// LoadingNo
        /// Property for Order Item LoadingNo
        /// </summary>
        [DataMember]
        public String LoadingNo
        {
            get;
            set;
        }

        [DataMember]
        public int? ARShipToTankID
        {
            get;
            set;
        }
        [DataMember]
        public String ARShipToTankCode
        {
            get;
            set;
        }
    }
}
