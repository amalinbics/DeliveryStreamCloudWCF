using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace DeliveryStreamCloudWCF.Entities
{
    /// <summary>
    /// Order class
    /// </summary>
    [DataContract]
    public class Order
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public Order()
        {
            OrderItems = new List<OrderItem>();
        }

        /// <summary>
        /// ID
        /// Properties for ID datamember
        /// </summary>
        [DataMember]
        public Guid ID
        {
            get;
            set;
        }

        /// <summary>
        /// SysTrxNo
        /// Properties for SysTrxNo datamember
        /// </summary>
        [DataMember]
        public Decimal SysTrxNo
        {
            get;
            set;
        }

        /// <summary>
        /// OrderNo
        /// Properties for OrderNo datamember
        /// </summary>
        [DataMember]
        public String OrderNo
        {
            get;
            set;
        }

        /// <summary>
        /// OrderStatusID
        /// Properties for OrderStatusID datamember
        /// </summary>
        [DataMember]
        public String OrderStatusID
        {
            get;
            set;
        }

        /// <summary>
        /// LoadID
        /// Properties for LoadID datamember
        /// </summary>
        [DataMember]
        public Guid LoadID
        {
            get;
            set;
        }

        /// <summary>
        /// DestAddress1
        /// Properties for DestAddress1 datamember
        /// </summary>
        [DataMember]
        public String DestAddress1
        {
            get;
            set;
        }

        /// <summary>
        /// DestAddress2
        /// Properties for DestAddress2 datamember
        /// </summary>
        [DataMember]
        public String DestAddress2
        {
            get;
            set;
        }

        /// <summary>
        /// DestSite
        /// Properties for DestSite datamember
        /// </summary>
        [DataMember]
        public String DestSite
        {
            get;
            set;
        }

        /// <summary>
        /// DestNotes
        /// Properties for DestNotes datamember
        /// </summary>
        [DataMember]
        public String DestNotes
        {
            get;
            set;
        }

        /// <summary>
        /// PromisedDtTm
        /// Properties for PromisedDtTm datamember
        /// </summary>
        [DataMember]
        public DateTime PromisedDtTm
        {
            get;
            set;
        }

        /// <summary>
        /// City
        /// Properties for City datamember
        /// </summary>
        [DataMember]
        public String City
        {
            get;
            set;
        }

        /// <summary>
        /// Country
        /// Properties for Country datamember
        /// </summary>
        [DataMember]
        public String Country
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
        /// Zip
        /// Properties for Zip datamember
        /// </summary>
        [DataMember]
        public String Zip
        {
            get;
            set;
        }

        /// <summary>
        /// OrderItems
        /// Properties for OrderItems datamember
        /// </summary>
        [DataMember]
        public List<OrderItem> OrderItems
        {
            get;
            set;
        }

        /// <summary>
        /// Notes
        /// Proeprties for Notes
        /// </summary>
        [DataMember]
        public String Notes
        {
            get;
            set;
        }
        //2013.12.02  Fsww Ramesh M, Added for  RequestedDtTm CR#61274 
        /// <summary>
        /// RequestedDtTm
        /// Properties for RequestedDtTm datamember
        /// </summary>
        [DataMember]
        public DateTime? RequestedDtTm
        {
            get;
            set;
        }
        // 05-20-2014  MadhuVenkat k - Added for CR 63346 - PO & Priority No to Load Information Screen 
         [DataMember]
        public String PONo 
        {
            get;
            set;
        }
         [DataMember]
         public String PriorityNo 
        {
            get;
            set;
        }
     

    }
}
