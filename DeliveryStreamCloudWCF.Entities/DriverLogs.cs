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
    public class DriverLogs
    {
        /// <summary>
        /// CurrentOnDuty
        /// Properties for CurrentOnDuty datamember
        /// </summary>
        [DataMember]
        public decimal CurrentOnDuty
        {
            get;
            set;
        }

        /// <summary>
        /// CurrentDriving
        /// Properties for CurrentDriving datamember
        /// </summary>
        [DataMember]
        public decimal CurrentDriving
        {
            get;
            set;
        }

        /// <summary>
        /// CurrentSleeping
        /// Properties for CurrentSleeping datamember
        /// </summary>
        [DataMember]
        public decimal CurrentSleeping
        {
            get;
            set;
        }

        /// <summary>
        /// CurrentOffDuty
        /// Properties for CurrentOffDuty datamember
        /// </summary>
        [DataMember]
        public decimal CurrentOffDuty
        {
            get;
            set;
        }

        /// <summary>
        /// LastOnDuty
        /// Properties for LastOnDuty datamember
        /// </summary>
        [DataMember]
        public decimal LastOnDuty
        {
            get;
            set;
        }

        /// <summary>
        /// LastDriving
        /// Properties for LastDriving datamember
        /// </summary>
        [DataMember]
        public decimal LastDriving
        {
            get;
            set;
        }

        /// <summary>
        /// LastSleeping
        /// Properties for LastSleeping datamember
        /// </summary>
        [DataMember]
        public decimal LastSleeping
        {
            get;
            set;
        }

        /// <summary>
        /// LastOffDuty
        /// Properties for LastOffDuty datamember
        /// </summary>
        [DataMember]
        public decimal LastOffDuty
        {
            get;
            set;
        }
    }
}
