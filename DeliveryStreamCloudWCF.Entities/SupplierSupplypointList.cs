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
    public class SupplierSupplypointList
    {
        [DataMember]
        public Int32 SupplierSupplyPtID
        {
            get;
            set;
        }
        [DataMember]
        public String SupplierSupplyPt
        {
            get;
            set;
        }
        // 2014.02.07 Ramesh M Added For  CR#61759 to get from site list added ShipToID
        [DataMember]
        public Int32? ShipToID
        {
            get;
            set;
        }
    }
}
