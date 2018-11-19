using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace DeliveryStreamCloudWCF.Entities
{
    [DataContract]
    public class TruckFuelingDetails
    {
        [DataMember]
        public Guid SessionID
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
        public Int32 VehicleID
        {
            get;
            set;
        }

        [DataMember]
        public Int32 DriverID
        {
            get;
            set;
        }

        [DataMember]
        public DateTime DeviceDateTime
        {
            get;
            set;
        }

        [DataMember]
        public DateTime GMT
        {
            get;
            set;
        }

        [DataMember]
        public Decimal Odometer
        {
            get;
            set;
        }

        [DataMember]
        public Decimal Qty
        {
            get;
            set;
        }

        [DataMember]
        public Int32 FuelType
        {
            get;
            set;
        }

        [DataMember]
        public String Latitude
        {
            get;
            set;
        }

        [DataMember]
        public String Longitude
        {
            get;
            set;
        }

        [DataMember]
        public String State
        {
            get;
            set;
        }

        [DataMember]
        public Boolean FuelTaxPaid
        {
            get;
            set;
        }

        [DataMember]
        public String FuelingLocation
        {
            get;
            set;
        }

        [DataMember]
        public Decimal MPG
        {
            get;
            set;
        }
    }
}
