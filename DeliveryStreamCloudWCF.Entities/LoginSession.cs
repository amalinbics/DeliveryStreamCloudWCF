using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;


namespace DeliveryStreamCloudWCF.Entities
{
    [DataContract]
   public class LoginSession
    {
        [DataMember]
        public Guid SessionID
        {
            get;
            set;
        }

        [DataMember]
        public String DeviceID
        {
            get;
            set;
        }

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

        [DataMember]
        public DateTime LogoffTime
        {
            get;
            set;
        }
        [DataMember]
        public Int32 CurrentVehicle
        {
            get;
            set;
        }
       [DataMember]
        public Boolean Active
        {
            get;
            set;
        }
        [DataMember]
        public DateTime LogonTime
        {
            get;
            set;
        }

        [DataMember]
        public String Version
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
