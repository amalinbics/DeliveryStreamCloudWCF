using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace DeliveryStreamCloudWCF.Entities
{
    /// <summary>
    /// Status class
    /// </summary>
    [DataContract]
    public class Status
    {
        /// <summary>
        /// ID
        /// Properties for ID datamember
        /// </summary>
        [DataMember]
        public String ID
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
        /// Sequence
        /// Properties for Sequence datamember
        /// </summary>
        [DataMember]
        public Int32 Sequence
        {
            get;
            set;
        }

        [DataMember]
        public String StatusNew
        {
            get;
            set;
        }

        [DataMember]
        public String Reason
        {
            get;
            set;
        }
    }
}
