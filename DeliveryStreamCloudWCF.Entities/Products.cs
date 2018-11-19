using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace DeliveryStreamCloudWCF.Entities
{
    [DataContract]
    public class Products
    {
        [DataMember]
        public Int32 SupplierSupplyPtID
        {
            get;
            set;
        }
        [DataMember]
        public Int32 SupplierID
        {
            get;
            set;
        }
        [DataMember]
        public Int32 SupplierPtID
        {
            get;
            set;
        }
        [DataMember]
        public String ProductCode
        {
            get;
            set;
        }
        [DataMember]
        public String ProductDescr
        {
            get;
            set;
        }
        
        [DataMember]
        public String CompanyID
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
    }
}
