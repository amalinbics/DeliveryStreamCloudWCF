using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace DeliveryStreamCloudWCF.Entities
{
    /// <summary>
    /// PreDutyInspectionReport
    /// </summary>
    [DataContract]
    public class PreDutyInspectionReport
    {
        [DataMember]        
        public Guid SessionID
        {
            get;
            set;
        }

       [DataMember]
       public Boolean BrakeLinestoTrailer
       {
           get;
           set;
       }
       [DataMember]
       public Boolean ElectricLinestoTrailer
       {
           get;
           set;
       }
       [DataMember]
       public Boolean DriveLine
       {
           get;
           set;
       }
       [DataMember]
       public Boolean CouplingDevices
       {
           get;
           set;
       }
       [DataMember]
       public Boolean TiresWheelsRims
       {
           get;
           set;
       }
       [DataMember]
       public Boolean SuspensionSystem
       {
           get;
           set;
       }
       [DataMember]
       public Boolean Body
       {
           get;
           set;
       }
       [DataMember]
       public Boolean Glass
       {
           get;
           set;
       }
       [DataMember]
       public Boolean Exhaust
       {
           get;
           set;
       }
       [DataMember]
       public Boolean FrameAndAssembly
       {
           get;
           set;
       }
       [DataMember]
       public Boolean FuelSystem
       {
           get;
           set;
       } 
       [DataMember]
       public Boolean CoolingSystem
       {
           get;
           set;
       }
       [DataMember]
       public Boolean Engine
       {
           get;
           set;
       }
       [DataMember]
       public Boolean Leaks
       {
           get;
           set;
       }
       [DataMember]
       public Boolean HeadLights
       {
           get;
           set;
       }
       [DataMember]
       public Boolean TailLights
       {
           get;
           set;
       }
       [DataMember]
       public Boolean StopAndTurnLights
       {
           get;
           set;
       }
       [DataMember]
       public Boolean ClearanceAndMakerLights
       {
           get;
           set;
       }
       [DataMember]
       public Boolean Reflectors
       {
           get;
           set;
       }
       [DataMember]
       public Boolean AirPressureWarningDevice
       {
           get;
           set;
       }
       [DataMember]
       public Boolean OilPressure
       {
           get;
           set;
       }
       [DataMember]
       public Boolean Ammeter
       {
           get;
           set;
       }
       [DataMember]
       public Boolean Horn
       {
           get;
           set;
       }
       [DataMember]
       public Boolean WindshieldWipers
       {
           get;
           set;
       }
       [DataMember]
       public Boolean ParkingBrakes
       {
           get;
           set;
       }
       [DataMember]
       public Boolean Clutch
       {
           get;
           set;
       }
       [DataMember]
       public Boolean Transmission
       {
           get;
           set;
       }
       [DataMember]
       public Boolean RearVisionMirror
       {
           get;
           set;
       }
       [DataMember]
       public Boolean Steering
       {
           get;
           set;
       }
       [DataMember]
       public Boolean ServiceBrakes
       {
           get;
           set;
       }  
       [DataMember]
       public Boolean Speedometer
       {
           get;
           set;
       } 
       [DataMember]
       public Boolean OtherItems
       {
           get;
           set;
       }
       [DataMember]
       public Boolean ReflectiveTriangles
       {
           get;
           set;
       } 
       [DataMember]
       public Boolean FireExtinguisher
       {
           get;
           set;
       }
       [DataMember]
       public Boolean FlagsFusesAndSparesBulbs
       {
           get;
           set;
       } 
       [DataMember]
       public Boolean TireChains
       {
           get;
           set;
       } 
       [DataMember]
       public Boolean Brakes
       {
           get;
           set;
       } 
       [DataMember]
       public Boolean BrakeConnections
       {
           get;
           set;
       } 
       [DataMember]
       public Boolean CouplingDevicesEmergency
       {
           get;
           set;
       } 
       [DataMember]
       public Boolean CouplingKingPin
       {
           get;
           set;
       } 
       [DataMember]
       public Boolean Doors
       {
           get;
           set;
       } 
       [DataMember]
       public Boolean Hitch
       {
           get;
           set;
       } 
       [DataMember]
       public Boolean LandingGear
       {
           get;
           set;
       } 
       [DataMember]
       public Boolean LightsALL
       {
           get;
           set;
       } 
       [DataMember]
       public Boolean Roof
       {
           get;
           set;
       } 
       [DataMember]
       public Boolean SuspensionSystemEmergency
       {
           get;
           set;
       } 
       [DataMember]
       public Boolean Tarpaulin
       {
           get;
           set;
       } 
       [DataMember]
       public Boolean Tires
       {
           get;
           set;
       } 
       [DataMember]
       public Boolean WheelsRims
       {
           get;
           set;
       } 
       [DataMember]
       public Boolean Other
       {
           get;
           set;
       }      

    }
}
