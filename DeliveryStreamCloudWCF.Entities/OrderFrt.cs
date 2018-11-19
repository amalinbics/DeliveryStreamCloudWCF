using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace DeliveryStreamCloudWCF.Entities
{
     /// <summary>
    /// OrderFrt class
    /// </summary>
    [DataContract]
    public class OrderFrt
    {
        /// <summary>
        /// OrderID
        /// Properties for OrderID datamember
        /// </summary>
        [DataMember]
        public Guid OrderID
        {
            get;
            set;
        }

        /// <summary>
        /// SiteWaitTime
        /// Properties for SiteWaitTime datamember
        /// </summary>
        [DataMember]
        public Boolean SiteWaitTime
        {
            get;
            set;
        }

        /// <summary>
        /// SiteWaitTime_Comment
        /// Properties for SiteWaitTime_Comment datamember
        /// </summary>
        [DataMember]
        public String SiteWaitTime_Comment
        {
            get;
            set;
        }

        /// <summary>
        /// SiteWaitTime_Start
        /// Properties for SiteWaitTime_Start datamember
        /// </summary>
        [DataMember]
        public DateTime? SiteWaitTime_Start
        {
            get;
            set;
        }

        /// <summary>
        /// SiteWaitTime_End
        /// Properties for SiteWaitTime_End datamember
        /// </summary>
        [DataMember]
        public DateTime? SiteWaitTime_End
        {
            get;
            set;
        }

        /// <summary>
        /// SplitLoad
        /// Properties for SplitLoad datamember
        /// </summary>
        [DataMember]
        public Boolean SplitLoad
        {
            get;
            set;
        }

        /// <summary>
        /// SplitLoad_Comment
        /// Properties for SplitLoad_Comment datamember
        /// </summary>
        [DataMember]
        public String SplitLoad_Comment
        {
            get;
            set;
        }

        /// <summary>
        /// SplitDrop
        /// Properties for SplitDrop datamember
        /// </summary>
        [DataMember]
        public Boolean SplitDrop
        {
            get;
            set;
        }

        /// <summary>
        /// SplitDrop_Comment
        /// Properties for SplitDrop_Comment datamember
        /// </summary>
        [DataMember]
        public String SplitDrop_Comment
        {
            get;
            set;
        }

        /// <summary>
        /// PumpOut
        /// Properties for PumpOut datamember
        /// </summary>
        [DataMember]
        public Boolean PumpOut
        {
            get;
            set;
        }

        /// <summary>
        /// PumpOut_Comment
        /// Properties for PumpOut_Comment datamember
        /// </summary>
        [DataMember]
        public String PumpOut_Comment
        {
            get;
            set;
        }

        /// <summary>
        /// Diversion
        /// Properties for Diversion datamember
        /// </summary>
        [DataMember]
        public Boolean Diversion
        {
            get;
            set;
        }

        /// <summary>
        /// Diversion_Comment
        /// Properties for Diversion_Comment datamember
        /// </summary>
        [DataMember]
        public String Diversion_Comment
        {
            get;
            set;
        }

        /// <summary>
        /// MinimumLoad
        /// Properties for MinimumLoad datamember
        /// </summary>
        [DataMember]
        public Boolean MinimumLoad
        {
            get;
            set;
        }

        /// <summary>
        /// MinimumLoad_Comment
        /// Properties for MinimumLoad_Comment datamember
        /// </summary>
        [DataMember]
        public String MinimumLoad_Comment
        {
            get;
            set;
        }

        /// <summary>
        /// SiteWaitTime
        /// Properties for SiteWaitTime datamember
        /// </summary>
        [DataMember]
        public Boolean Other
        {
            get;
            set;
        }

        /// <summary>
        /// Other_Comment
        /// Properties for Other_Comment datamember
        /// </summary>
        [DataMember]
        public String Other_Comment
        {
            get;
            set;
        }


    }
}
