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
    public class BolHdrXML
    {
       
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
        public String Image
        {
             get;
             set;
        }

        /// <summary>
        /// datetime
        /// Properties for datetime datamember
        /// </summary>
        [DataMember]
        public DateTime BOLDateTime
        {
            get;
            set;
        }

        /// <summary>
        /// datetime
        /// Properties for datetime datamember
        /// </summary>
        [DataMember]
        public DateTime? BOLDateTimeEnd
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
        public String BOLWaitTimeComment
        {
            get;
            set;
        }
      
        /// <summary>
        /// BOLWaitTime_Start
        /// Properties for BOLWaitTime_Start datamember
        /// </summary>
        [DataMember]
        public DateTime? BOLWaitTimeStart
        {
            get;
            set;
        }

        /// <summary>
        /// BOLWaitTime_End
        /// Properties for BOLWaitTime_End datamember
        /// </summary>
        [DataMember]
        public DateTime? BOLWaitTimeEnd
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
        /// TrailerCode
        /// Properties for TrailerCode datamember
        /// </summary>
        [DataMember]
        public String SupplierCode
        {
            get;
            set;
        }

        /// <summary>
        /// TrailerCode
        /// Properties for TrailerCode datamember
        /// </summary>
        [DataMember]
        public String SupplyPointCode
        {
            get;
            set;
        }

        /// <summary>
        /// ZBolitemXML
        /// Properties for ZBolitemXML datamember
        /// </summary>
        [DataMember]
        public List<BolitemXML> ZBolitemXML
        {
            get;
            set;
        }
        
        
    }
}
