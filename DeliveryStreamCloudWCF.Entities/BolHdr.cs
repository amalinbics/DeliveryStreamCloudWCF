using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace DeliveryStreamCloudWCF.Entities
{
    /// <summary>
    /// BOL Header class
    /// </summary>
    [DataContract]
    public class BolHdr
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public BolHdr()
        {
            BolItem = new List<Bolitem>();
        }
        
        /// <summary>
        /// ID
        /// Properties for ID datamember
        /// </summary>
        [DataMember]
        public Guid ID
        {
            get ;
            set;
        }

        /// <summary>
        /// LoadID
        /// Properties for LoadID datamember
        /// </summary>
        [DataMember]
        public Guid LoadID
        {
            get ;
            set;
        }

        /// <summary>
        /// BOLNo
        /// Properties for BOLNo datamember
        /// </summary>
        [DataMember]
        public String BOLNo
        {
            get ;
            set;
        }

        /// <summary>
        /// Image
        /// Properties for Image datamember
        /// </summary>
        [DataMember]
        public Byte[] Image
        {
             get;
             set;
        }

        /// <summary>
        /// datetime
        /// Properties for datetime datamember
        /// </summary>
        [DataMember]
        public DateTime datetime
        {
            get;
            set;
        }

       /// <summary>
        /// BOLWaitTime
        /// Properties for BOLWaitTime datamember
        /// </summary>
        [DataMember]
        public Boolean BOLWaitTime
        {
            get;
            set;
        }
      
        /// <summary>
        /// BOLWaitTime_Comment
        /// Properties for BOLWaitTime_Comment datamember
        /// </summary>
        [DataMember]
        public String BOLWaitTime_Comment
        {
            get;
            set;
        }
      
        /// <summary>
        /// BOLWaitTime_Start
        /// Properties for BOLWaitTime_Start datamember
        /// </summary>
        [DataMember]
        public DateTime? BOLWaitTime_Start
        {
            get;
            set;
        }

        /// <summary>
        /// BOLWaitTime_End
        /// Properties for BOLWaitTime_End datamember
        /// </summary>
        [DataMember]
        public DateTime? BOLWaitTime_End
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
        /// SupplierPointCode
        /// Properties for SupplierPointCode datamember
        /// </summary>
        [DataMember]
        public String SupplierCode
        {
            get;
            set;
        }

        /// <summary>
        /// SupplierPointCode
        /// Properties for SupplierPointCode datamember
        /// </summary>
        [DataMember]
        public String SupplyPointCode
        {
            get;
            set;
        }

        /// <summary>
        /// NeedUpdate
        /// Properties for NeedUpdate datamember
        /// </summary>
        [DataMember]
        public Boolean NeedUpdate
        {
             get;
             set;
        }

        /// <summary>
        /// BolItem
        /// Properties for BolItem datamember
        /// </summary>
        [DataMember]
        public List<Bolitem> BolItem
        {
              get;
              set;
        } 
    }
}
