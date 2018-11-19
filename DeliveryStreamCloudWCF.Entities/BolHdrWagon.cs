using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace DeliveryStreamCloudWCF.Entities
{

    [DataContract]
    public class BolHdrWagon
    {

        [DataMember]
        public String BOLNo
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
        public String Img
        {
            get;
            set;
        }

        [DataMember]
        public Guid SessionID
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
        public Int32 UpdatedBy
        {
            get;
            set;
        }

        [DataMember]
        public byte[] imag
        {
            get;
            set;
        }

       

        [DataMember]
        public Guid ID
        {
            get;
            set;
        }
        
        [DataMember]
        public Boolean NeedUpdate
        {
            get;
            set;
        }

        [DataMember]
        public List<BolitemWagon> ZsBolitemWagon
        {
            get;
            set;
        }
     
    }
}
