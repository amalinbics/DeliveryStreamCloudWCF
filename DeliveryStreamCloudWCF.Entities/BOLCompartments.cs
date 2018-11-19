using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace DeliveryStreamCloudWCF.Entities
{


    [DataContract]
    public class BOLCompartments
    {
        
        [DataMember]
        public Int32 CompartmentID
        {
            get;
            set;
        }
        
        [DataMember]
        public Decimal GrossQty
        {
            get;
            set;
        }
        
        [DataMember]
        public String ProdCode
        {
            get;
            set;
        }
        [DataMember]
        public String BOLNo
        {
            get;
            set;
        }


        [DataMember]
        public Guid BOLHdrID
        {
            get;
            set;
        }

        [DataMember]
        public Guid BOLItemID
        {
            get;
            set;
        }

        [DataMember]
        public DateTime BOLDatetime
        {
            get;
            set;
        }
        [DataMember]
        public String SupplierCode
        {
            get;
            set;
        }


        [DataMember]
        public String SupplyPointCode
        {
            get;
            set;
        }

        [DataMember]
        public Decimal SystrxNo
        {
            get;
            set;
        }

        [DataMember]
        public Int32 SystrxLine
        {
            get;
            set;
        }
        [DataMember]
        public Decimal NetQty
        {
            get;
            set;
        }


        [DataMember]
        public Decimal OrderedQty
        {
            get;
            set;
        }

        [DataMember]
        public Decimal AvailbleQty
        {
            get;
            set;
        }

        [DataMember]
        public Decimal SalesQty
        {
            get;
            set;
        }


        [DataMember]
        public String Notes
        {
            get;
            set;
        }

        [DataMember]
        public String CompartmentCode
        {
            get;
            set;
        }

        

     
    }
}
