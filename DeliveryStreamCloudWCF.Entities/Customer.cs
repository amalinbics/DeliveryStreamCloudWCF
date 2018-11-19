using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace DeliveryStreamCloudWCF.Entities
{
    /// <summary>
    /// Customer class
    /// </summary>
    [DataContract]
    public class Customer
    {
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

        /// <summary>
        /// Name
        /// Properties for Name datamember
        /// </summary>
        [DataMember]
        public String Name
        {
            get;
            set;
        }

        /// <summary>
        /// Description
        /// Properties for Description datamember
        /// </summary>
        [DataMember]
        public String Description
        {
            get;
            set;
        }

        /// <summary>
        /// Password
        /// Properties for Password datamember
        /// </summary>
        [DataMember]
        public String Password
        {
            get;
            set;
        }

        /// <summary>
        /// WCFUrl
        /// Properties for WCFUrl datamember
        /// </summary>
        [DataMember]
        public String WCFUrl
        {
            get;
            set;
        }
    }
}
