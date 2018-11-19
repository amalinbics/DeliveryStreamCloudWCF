using System;
using System.Collections.Generic;
using System.Linq;
// 2014.03.20  Ramesh M Added For CR#62322 added  Version testing method 
using System.Text;
using System.Runtime.Serialization;

namespace DeliveryStreamCloudWCF.Entities
{
     [DataContract]
    public class VersionTest
    {
        /// <summary>
        /// ID
        /// Properties for ID datamember
        /// </summary>
        [DataMember]
         public Int32 LoginID
        {
            get;
            set;
        }

        /// <summary>
        /// Description
        /// Properties for Description datamember
        /// </summary>
        [DataMember]
        public Guid SessionID
        {
            get;
            set;
        }

        /// <summary>
        /// Sequence
        /// Properties for Sequence datamember
        /// </summary>
        [DataMember]
        public DateTime? LogoffTime
        {
            get;
            set;
        }
    }
}
