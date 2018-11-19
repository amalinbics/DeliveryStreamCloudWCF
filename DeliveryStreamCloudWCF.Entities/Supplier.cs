// 2014.01.17 Ramesh M Added For  CR#61759 to get from site list 
// 2014.02.07 Ramesh M Added For  CR#61759 to get from site list added ShipToID
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace DeliveryStreamCloudWCF.Entities
{
    [DataContract]
    public class Supplier
    {
        [DataMember]
        public Int32 SupplierID
        {
            get;
            set;
        }

        [DataMember]
        public List<SupplierSupplyPt> SupplierSupplyPt
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
        public String Descr
        {
            get;
            set;
        }
       
        [DataMember]
        public DateTime ? LastModifiedDtTm
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

         //[DataMember]
         //public Int32 SupplierSupplyPtID
         //{
         //    get;
         //    set;
         //}
         //[DataMember]
         //public String SupplierSupplyPtCode
         //{
         //    get;
         //    set;
         //}
         //[DataMember]
         //public String SupplierSupplyPtDescr
         //{
         //    get;
         //    set;
         //}
         //[DataMember]
         //public Int32 SupplierID
         //{
         //    get;
         //    set;
         //}
         //[DataMember]
         //public String CompanyID
         //{
         //    get;
         //    set;
         //}
         //[DataMember]
         //public DateTime? LastModifiedDtTm
         //{
         //    get;
         //    set;
         //}
        

    }
}
