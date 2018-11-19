// 2014.02.20  Ramesh M Added For CR#62301 For Driver status Screen in Ipad
// 2014.02.25  Ramesh M Added For CR#62292 For modified driver summary log
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
    public class DriverLogStatus
    {
       /// <summary>
       /// 
       /// </summary>
        [DataMember]
        public DateTime StartTime
        {
            get;
            set;
        }

      /// <summary>
      /// 
      /// </summary>
        [DataMember]
        public DateTime EndTime
        {
            get;
            set;
        }

     /// <summary>
     /// 
     /// </summary>
        [DataMember]
        public Int32 CurrentLoginID
        {
            get;
            set;
        }

       /// <summary>
       /// 
       /// </summary>
        [DataMember]
        public Guid SessionID
        {
            get;
            set;
        }

      /// <summary>
    /// 
    /// </summary>
        [DataMember]
        public String DriverState
        {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string Location
        {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string EventDetail
        {
            get;
            set;
        }

      
    }
}
