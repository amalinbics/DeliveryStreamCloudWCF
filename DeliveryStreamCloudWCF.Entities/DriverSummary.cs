// 2014.02.20  Ramesh M Added For CR#62292 For driver summary log
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
    public class DriverSummary
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
        /// CurrentLoginID
        /// Properties for CurrentLoginID datamember
        /// </summary>
        [DataMember]
        public Int32 CurrentLoginID
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
        /// DriverState
        /// Properties for DriverState datamember
        /// </summary>
        [DataMember]
        public String DriverState
        {
            get;
            set;
        }

        /// <summary>
        /// ThirtyFourHourReset
        /// ThirtyFourHourReset for DriverState datamember
        /// </summary>
        //[DataMember]
        //public String ThirtyFourHourReset
        //{
        //    get;
        //    set;
        //}
        // 2014.02.20  Ramesh M Added For CR#62292 For driver summary log
        /// <summary>
        /// IsOverride
        /// Properties for IsOverride datamember
        /// </summary>
        [DataMember]
        public String IsOverride
        {
            get;
            set;
        }
        /// <summary>
        /// IsModified
        /// Properties for IsModified datamember
        /// </summary>
        [DataMember]
        public String IsModified
        {
            get;
            set;
        }

        /// <summary>
        /// ModifiedDate
        /// Properties for ModifiedDate datamember
        /// </summary>
        [DataMember]
        public DateTime ModifiedDate
        {
            get;
            set;
        }


       
    }
}
