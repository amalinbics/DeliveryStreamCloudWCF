// 06-26-2014  MadhuVenkat k - Added for CR 64058  - For Add orderDispatchHistory 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace DeliveryStreamCloudWCF.Entities
{
    [DataContract]
    public class OrderDispatchHistory
    {
        public OrderDispatchHistory()
        {
            Orders = new List<OrderDispatchHistory>();
            CompletedLoad = new List<CompletedLoads>();
        }
        [DataMember]
        public List<OrderDispatchHistory> Orders
        {
            get;
            set;
        }


        /// <summary>
        /// CompletedLoad
        /// Properties for CompletedLoad datamember
        /// </summary>
        [DataMember]
        public List<CompletedLoads> CompletedLoad
        {
            get;
            set;
        }

        [DataMember]
        public Decimal SysTrxNo
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
        public Int32 DefDriverID
        {
            get;
            set;
        }


        [DataMember]
        public Int32 DefVehicleID
        {
            get;
            set;
        }

        [DataMember]
        public Int32 OldDriverID
        {
            get;
            set;
        }

        [DataMember]
        public Int32 OldVehicleID
        {
            get;
            set;
        }

    }
}

