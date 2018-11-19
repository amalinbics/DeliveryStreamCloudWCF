using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DeliveryStreamCloudWCF.Utils
{
    /// <summary>
    /// ApplicationConstants class
    /// </summary>
    public static class ApplicationConstants
    {

        public const int TimeToRemoveRCLoads = 30;        

        public struct Encription
        {
            public const String siv = "A445ABDSADQW6A7DFDHAS3JH9HTA2DFJ";
            public const String EncryptionKey = "ASDFG5RFGN234LMVAO3049ADF34NAASDF0345234MLASDFNASDFN3KLN34NASDFN";
        }

        public struct Connection
        {
            public const String ConnectionString = "DeliveryStreamCloud";
        }

        public struct Errors
        {
            public const String FunctionError = "Error occured. Function : in {0}, Class : {1}, Error Message : {2} Stack Trace : {3}";
            public const String ConnectionString = "Could not find {0} connection string in config file";
            public const String InvalidUserCredentials = "Unable to validate credentials. Please check User Name, Password, Truck ID, Company ID and UserType and try again.";
            public const String InvalidCustomerCredentials = "Unable to validate credentials. Please check CustomerID and try again.";
            public const String UserNotFound = "Unable to find user for company : {0}, Driver : {1} and vehicle : {2}";
            public const String InvalidVehicleCode = "Unable to validate vehicle code. Please check vehicle code and try again.";
            public const String InvalidSessionID = "Invalid Session. Please check user Session";
            public const String PreDutyInspectionVoilationError = "Pre-Duty Inspection error. Pre-Duty Voilation is set";
            public const String PostDutyInspectionVoilationError = "Post-Duty Inspection error. Post-Duty Voilation is set";
            public const String PreDutyInspectionError = "Pre-Duty Inspection error.";
            public const String PostDutyInspectionError = "Post-Duty Inspection error.";
            public const String MultipleLoginError = "User session already exists, please close the existing session";
            public const String InvalidSiteCode = "Unable to validate site code. Please check site code and try again.";
            public const String InvalidTankWagonVehicle = "Unable to validate Tank Wagon vehicle. Please check vehicle and try again.";
        }

        public struct Logging
        {
            public const String Log = "DeliveryStream";
            public const String Source = "CloudWCF";
        }        
      
    }
}
