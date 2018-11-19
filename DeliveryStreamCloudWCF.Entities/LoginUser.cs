// 2014.03.17  Ramesh M Added For CR#62668 to get home terminal details
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace DeliveryStreamCloudWCF.Entities
{
    /// <summary>
    /// LoginUser class
    /// </summary>
    [DataContract]
    public class LoginUser
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
        /// ID
        /// Properties for ID datamember
        /// </summary>
        [DataMember]
        public Int32 ID
        {
            get;
            set;
        }

        /// <summary>
        /// UserName
        /// Properties for UserName datamember
        /// </summary>
        [DataMember]
        public String UserName
        {
            get;
            set;
        }

        /// <summary>
        /// Email
        /// Properties for Email datamember
        /// </summary>
        [DataMember]
        public String Email
        {
            get;
            set;
        }

        /// <summary>
        /// DriverID
        /// Properties for DriverID datamember
        /// </summary>
        [DataMember]
        public Int32 DriverID
        {
            get;
            set;
        }

        /// <summary>
        /// FirstName
        /// Properties for FirstName datamember
        /// </summary>
        [DataMember]
        public String FirstName
        {
            get;
            set;
        }

        /// <summary>
        /// MiddleName
        /// Properties for MiddleName datamember
        /// </summary>
        [DataMember]
        public String MiddleName
        {
            get;
            set;
        }

        /// <summary>
        /// LastName
        /// Properties for LastName datamember
        /// </summary>
        [DataMember]
        public String LastName
        {
            get;
            set;
        }


        /// <summary>
        /// UserType
        /// Properties for UserType datamember
        /// </summary>
        [DataMember]
        public String UserType
        {
            get;
            set;
        }
        /// <summary>
        /// SiteID
        /// Properties for SiteID datamember
        /// </summary>
        [DataMember]
        public Int32 SiteID
        {
            get;
            set;
        }
        // 2014.03.17  Ramesh M Added For CR#62668 to get home terminal details
        [DataMember]
        public String Co_Name
        {
            get;
            set;
        }
        [DataMember]
        public String Co_Addr1
        {
            get;
            set;
        }
        [DataMember]
        public String Co_City
        {
            get;
            set;
        }
        [DataMember]
        public String Co_State
        {
            get;
            set;
        }
        [DataMember]
        public String Co_Zip
        {
            get;
            set;
        }
        [DataMember]
        public String HT_Descr
        {
            get;
            set;
        }
        [DataMember]
        public String HT_Addr1
        {
            get;
            set;
        }
        [DataMember]
        public String HT_City
        {
            get;
            set;
        }
        [DataMember]
        public String HT_State
        {
            get;
            set;
        }
        [DataMember]
        public String HT_Zip
        {
            get;
            set;
        }
        [DataMember]
        public DateTime? HazMatDate
        {
            get;
            set;
        }  
    }
}
