// 05-14-2014  MadhuVenkat K - Added for CR 63396 - Add Time Remaining Section to Driver Summary
// 08-14-2014  MadhuVenkat K - Added for CR 64639 - Add StatusUpdate to GpsHistory
// 08-25-2014  MadhuVenkat K - Added for CR 64760 - Add InspectionVersion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace DeliveryStreamCloudWCF.Entities
{
    /// <summary>
    /// RemainingTimeSummary class
    /// </summary>
    [DataContract]
    public class RemainingTimeSummary 
    {
        /// <summary>
        /// StartTime
        /// Properties for StartTime datamember
        /// </summary>
        [DataMember]
        public DateTime StartTime
        {
            get;
            set;
        }

        /// <summary>
        /// EndTime
        /// Properties for EndTime datamember
        /// </summary>
        [DataMember]
        public DateTime EndTime
        {
            get;
            set;
        }


        /// <summary>
        /// LoginDatetime
        /// Properties for LoginDatetime datamember
        /// </summary>
        [DataMember]
        public DateTime LoginDatetime
        {
            get;
            set;
        }

        ///// <summary>
        ///// SessionID
        ///// Properties for SessionID datamember
        ///// </summary>
        [DataMember]
        public Guid SessionID
        {
            get;
            set;
        }
         [DataMember]
        public int ID
        {
            get;
            set;
        }
         [DataMember]
        public decimal CurrentOnDuty
        {
            get;
            set;
        }
         [DataMember]
        public decimal CurrentOffDuty
        {
            get;
            set;
        }
         [DataMember]
        public decimal CurrentDriving
        {
            get;
            set;
        }
         [DataMember]
        public decimal CurrentSleeper
        {
            get;
            set;
        }
         [DataMember]
        public decimal LastOnDuty
        {

            get;
            set;
             
        }
         [DataMember]
        public decimal LastOffDuty
        {
            get;
            set;
        }
         [DataMember]
        public decimal LastDriving
        {
            get;
            set;
        }
         [DataMember]
        public decimal LastSleeper
        {

            get;
            set;
        }
         [DataMember]
        public decimal RemainingOnDuty
        {
            get;
            set;
            
        }
         [DataMember]
        public decimal RemainingDrivingDuty
        {
            get;
            set;
        }
         [DataMember]
        public decimal RemainingBreak
        {
            get;
            set;
        }
         [DataMember]
        public decimal RemainingLastweek
        {

            get;
            set;
        }
         // 08-14-2014  MadhuVenkat K - Added for CR 64639 - Add StatusUpdate to GpsHistory
         [DataMember]
         public String CurrentDriverStatus
         {
             get;
             set;
         }

         [DataMember]
         public String IsSessionExists
         {
             get;
             set;
         }
         // 08-25-2014  MadhuVenkat K - Added for CR 64760 - Add InspectionVersion
         //[DataMember]
         //public String InspectionVersion
         //{
         //    get;
         //    set;
         //}
    }
}
