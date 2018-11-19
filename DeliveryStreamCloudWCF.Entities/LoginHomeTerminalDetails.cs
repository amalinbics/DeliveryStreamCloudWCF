// 2014.03.17  Ramesh M Added For CR#62613 to get home terminal details
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace DeliveryStreamCloudWCF.Entities
{
    [DataContract]
   public class LoginHomeTerminalDetails
    {
          
            [DataMember]
            public Int32 ID
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
            public String FirstName
            {
                get;
                set;
            }          

          
            [DataMember]
            public String LastName
            {
                get;
                set;
            }
          
            [DataMember]
            public String UserType
            {
                get;
                set;
            }
          
            [DataMember]
            public String Co_Name
            {
                get;
                set;
            }
            [DataMember]
            public String Co_Addr1
            {
                get;
                set;
            }
            [DataMember]
            public String Co_City
            {
                get;
                set;
            }
            [DataMember]
            public String Co_State
            {
                get;
                set;
            }
            [DataMember]
            public String Co_Zip
            {
                get;
                set;
            }
            [DataMember]
            public String HT_Descr
            {
                get;
                set;
            }
            [DataMember]
            public String HT_Addr1
            {
                get;
                set;
            }
            [DataMember]
            public String HT_City
            {
                get;
                set;
            }
            [DataMember]
            public String HT_State
            {
                get;
                set;
            }
            [DataMember]
            public String HT_Zip
            {
                get;
                set;
            }
            [DataMember]
            public DateTime? HazMatDate
            {
                get;
                set;
            }
   }
}

