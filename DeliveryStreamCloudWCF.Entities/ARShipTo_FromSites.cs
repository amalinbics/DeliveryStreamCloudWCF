// 2014.01.13  Ramesh M Added For CR#61759
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace DeliveryStreamCloudWCF.Entities
{
    [DataContract]
    public class ARShipTo_FromSites
    {
       
        /// <summary>
        /// ShipToID
        /// Properties for ShipToID datamember
        /// </summary>
        [DataMember]
        public Int32 ShipToID
        {
            get;
            set;
        }
        /// <summary>
        /// SuppliersupplyPtID
        /// Properties for SuppliersupplyPtID datamember
        /// </summary>
        [DataMember]
        public Int32 SuppliersupplyPtID
        {
            get;
            set;
        }
     
        /// <summary>
        /// SupplierDescr
        /// Properties for SupplierDescr datamember
        /// </summary>
        [DataMember]
        public String SupplierDescr
        {
            get;
            set;
        }   
        /// <summary>
        /// SupplyPtDescr
        /// Properties for SupplyPtDescr datamember
        /// </summary>
        [DataMember]
        public String SupplyPtDescr
        {
            get;
            set;
        }
        /// <summary>
        /// Address1
        /// Properties for Address1 datamember
        /// </summary>
        [DataMember]
        public String Address1
        {
            get;
            set;
        }

        /// <summary>
        /// Address2
        /// Properties for Address2 datamember
        /// </summary>
        [DataMember]
        public String Address2
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
    }
}
