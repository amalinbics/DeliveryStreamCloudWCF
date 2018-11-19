using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace DeliveryStreamCloudWCF.Entities
{
    /// <summary>
    /// GetDriverDetails class
    /// </summary>
    [DataContract]
    public class GetDriverDetails
    {
        /// <summary>
        /// Properties for LoginID datamember
        /// </summary>
        [DataMember]
        public Int32 LoginID
        {
            get;
            set;
        }

        /// <summary>
        /// FullName
        /// Properties for FullName datamember
        /// </summary>
        [DataMember]
        public String FullName
        {
            get;
            set;
        }
    }
}
