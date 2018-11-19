// 2014.01.10  Ramesh M Added For CR#61759 Added to full From Site business rule from ascend
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace DeliveryStreamCloudWCF.Entities
{
    [DataContract]
    public class FromSiteBusinessRule
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
        /// FromSiteBSRule
        /// Properties for FromSiteBSRule datamember
        /// </summary>
        [DataMember]
        public Int32 FromSiteBSRule
        {
            get;
            set;
        }
    }
}
