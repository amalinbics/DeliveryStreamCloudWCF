// 2014.02.10 Ramesh M Added TrailerCode For CR#62211
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace DeliveryStreamCloudWCF.Entities
{

    /// <summary>
    /// LoginHistory class
    /// </summary>
    [DataContract]
    public class LoginHistory
    {        

        /// <summary>
        /// LoginID
        /// Properties for LoginID datamember
        /// </summary>
        [DataMember]
        public Int32 LoginID
        {
            get;
            set;
        }

        /// <summary>
        /// VehicleID
        /// Properties for VehicleID datamember
        /// </summary>
        [DataMember]
        public Int32 VehicleID
        {
            get;
            set;
        }

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
        /// DeviceID
        /// Properties for DeviceID datamember
        /// </summary>
        [DataMember]
        public string DeviceID
        {
            get;
            set;
        }

        /// <summary>
        /// DeviceToken
        /// Properties for DeviceToken datamember
        /// </summary>
        [DataMember]
        public string DeviceToken
        {
            get;
            set;
        }

        /// <summary>
        /// DateTime
        /// Properties for DateTime datamember
        /// </summary>
        [DataMember]
        public DateTime DateTime
        {
            get;
            set;
        }

        /// <summary>
        /// IsValidToken
        /// Properties for IsValidToken datamember
        /// </summary>
        [DataMember]
        public Boolean IsValidToken
        {
            get;
            set;
        }

        /// <summary>
        /// DeviceTime
        /// Properties for DeviceTime datamember
        /// </summary>
        [DataMember]
        public DateTime? DeviceTime
        {
            get;
            set;
        }

        [DataMember]
        public Guid SessionID
        {
            get;
            set;
        }

        [DataMember]
        public DateTime? LogoffTime
        {
            get;
            set;
        }

        /// <summary>
        /// OnDuty
        /// Properties for OnDuty datamember
        /// </summary>
        [DataMember]
        public Decimal? OnDuty
        {
            get;
            set;
        }

        /// <summary>
        /// Driving
        /// Properties for Driving datamember
        /// </summary>
        [DataMember]
        public Decimal? Driving
        {
            get;
            set;
        }

        /// <summary>
        /// Sleeper
        /// Properties for Sleeper datamember
        /// </summary>
        [DataMember]
        public Decimal? Sleeper
        {
            get;
            set;
        }

        /// <summary>
        /// Driving
        /// Properties for OffDuty datamember
        /// </summary>
        [DataMember]
        public Decimal? OffDuty
        {
            get;
            set;
        }
        // 2013.12.04 FSWW, Ramesh M Added For CR#61305 Added GMT in parameter
        /// <summary>
        /// GMT
        /// Properties for GMT datamember
        /// </summary>
        [DataMember]
        public DateTime GMT
        {
            get;
            set;
        }
        // 2014.02.10 Ramesh M Added TrailerCode For CR#62211
        [DataMember]
        public String TrailerCode
        {
            get;
            set;
        }

        [DataMember]
        public String IOSVersion
        {
            get;
            set;
        }
    }
}
