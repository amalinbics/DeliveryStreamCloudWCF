using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace DeliveryStreamCloudWCF.Entities
{


    [DataContract]
    public class BolitemWagon
    {
        
        [DataMember]
        public Int32 CompartmentID
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
        public Decimal GrossQty 
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
        public String Notes
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
        public Guid ID
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
        public String CustomerID
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

       
        
        
     
    }



    [DataContract]
    public class BolitemWagons
    {
        [DataMember]
        public String GrossQty
        {
            get;
            set;
        }

        [DataMember]
        public String NetQty
        {
            get;
            set;
        }
        [DataMember]
        public String CompartmentID
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
        public Decimal AvailableQty
        {
            get;
            set;
        }

        [DataMember]
        public String OrderedQty
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
        public String Nodes
        {
            get;
            set;
        }


        [DataMember]
        public String VehicleID
        {
            get;
            set;
        }

        [DataMember]
        public String SystrxNo
        {
            get;
            set;
        }

        [DataMember]
        public String SystrxLine
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
        public Guid BOLHdrID
        {
            get;
            set;
        }
        [DataMember]
        public String CustomerID
        {
            get;
            set;
        }

        [DataMember]
        public String NeedUpdate
        {
            get;
            set;
        }



    }

    

    [DataContract]
    public class BODDetails
    {
        [DataMember]
        public String BOLItemID
        {
            get;
            set;
        }
        [DataMember]
        public Int32 Updatedby
        {
            get;
            set;
        }
        [DataMember]
        public String ClientID
        {
            get;
            set;
        }
        [DataMember]
        public Guid NewSessionID
        {
            get;
            set;
        }

        [DataMember]
        public Decimal AvailableQty
        {
            get;
            set;
        }


        [DataMember]
        public Decimal RetainedQty
        {
            get;
            set;
        }


        [DataMember]
        public Decimal OverShotQty
        {
            get;
            set;
        }

        [DataMember]
        public Int32 ToSiteID
        {
            get;
            set;
        }


    }


}
