// 2014.02.25  Ramesh M Added For CR#62406 For DriverID,VechileID,UserLoginID, IsNewSession
// 2014.03.05  Ramesh M Added For CR#62301 For City added

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace DeliveryStreamCloudWCF.Entities
{
    /// <summary>
    /// GPSHistory class
    /// </summary>
    [DataContract]
    public class GPSHistory
    {
        /// <summary>
        /// Longitude
        /// Properties for Longitude datamember
        /// </summary>
        [DataMember]
        public String Longitude
        {
            get;
            set;
        }

        /// <summary>
        /// Latitude
        /// Properties for Latitude datamember
        /// </summary>
        [DataMember]
        public String Latitude
        {
            get;
            set;
        }

         /// <summary>
        /// Dttm
        /// Properties for Dttm datamember
        /// </summary>
        [DataMember]
        public DateTime Dttm
        {
            get;
            set;
        }

        /// <summary>
        /// SessionID
        /// Properties for SessionID datamember
        /// </summary>
        [DataMember]
        public Guid SessionID
        {
            get;
            set;
        }

        /// <summary>
        /// State
        /// Properties for State datamember
        /// </summary>
        [DataMember]
        public String State
        {
            get;
            set;
        }

        /// <summary>
        /// DeviceTime
        /// Properties for DeviceTime datamember
        /// </summary>
        [DataMember]
        public DateTime DeviceTime
        {
            get;
            set;
        }
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
        /// <summary>
        /// GpsStrength
        /// Properties for GpsStrength datamember
        /// </summary>
         [DataMember]
        public String GpsStrength
        {
            get;
            set;
        }
        /// <summary>
         /// Status
         /// Properties for Status datamember
        /// </summary>
         [DataMember]
         public String Status
         {
             get;
             set;
         }

       

        ///// <summary>
        // /// PreviousLongitude
        // /// Properties for PreviousLongitude datamember
        ///// </summary>
        // [DataMember]
        // public String PreviousLongitude
        // {
        //     get;
        //     set;
        // }

        // /// <summary>
        // /// PreviousLatitude
        // /// Properties for PreviousLatitude datamember
        // /// </summary>
        // [DataMember]
        // public String PreviousLatitude
        // {
        //     get;
        //     set;
        // }

         // 2013.11.19 FSWW, Ramesh M Added For CR#61148
         /// <summary>
         /// TruckSpeed
         /// Properties for TruckSpeed datamember
         /// </summary>
         [DataMember]
         public Int32 TruckSpeed
         {
             get;
             set;
         }
         // 2014.02.25  Ramesh M Added For CR#62406 For DriverID,VechileID,UserLoginID, IsNewSession
         [DataMember]
         public Int32 DriverID
         {
             get;
             set;
         }
         [DataMember]
         public Int32 VehicleID
         {
             get;
             set;
         }
         [DataMember]
         public String CustomerID
         {
             get;
             set;
         }

         [DataMember]
         public Int32 LoginID
         {
             get;
             set;
         }

         [DataMember]
         public String IsNewSession
         {
             get;
             set;
         }

         // 2014.03.05  Ramesh M Added For CR#62301 For City added
         [DataMember]
         public String City
         {
             get;
             set;
         }
         /// <summary>
         /// StatusUpdate
         /// Properties for StatusUpdate datamember
         /// </summary>
         [DataMember]
         public String StatusUpdate
         {
             get;
             set;
         }
     }
}
