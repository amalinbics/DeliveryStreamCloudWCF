using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace DeliveryStreamCloudWCF.Entities
{
    /// <summary>
    /// OrderItemComponent class
    /// </summary>
    [DataContract]
    public class OrderItemComponent
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
        /// Qty
        /// Properties for Qty datamember
        /// </summary>
        [DataMember]
        public Decimal Qty
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
        /// FromCSTankID
        /// Properties for FromCSTankID datamember
        /// </summary>
        [DataMember]
        public int FromCSTankID
        {
            get;
            set;
        }

        /// <summary>
        /// ToCSTankID
        /// Properties for ToCSTankID datamember
        /// </summary>
        [DataMember]
        public int ToCSTankID
        {
            get;
            set;
        }

        /// <summary>
        /// FromCSTankCode
        /// Properties for FromCSTankCode datamember
        /// </summary>
        [DataMember]
        public String FromCSTankCode
        {
            get;
            set;
        }

        /// <summary>
        /// ToCSTankCode
        /// Properties for ToCSTankCode datamember
        /// </summary>
        [DataMember]
        public String ToCSTankCode
        {
            get;
            set;
        }
    }
}
