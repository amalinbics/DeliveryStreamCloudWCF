using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DeliveryStreamCloudWCF.Entities
{
    /// <summary>
    /// OrderNotes class
    /// </summary>
    public class OrderNotes
    {
        /// <summary>
        /// Property For OrderID
        /// </summary>
        public Guid OrderID
        {
            get;
            set;
        }
        /// <summary>
        /// Property for SysTrxNo
        /// </summary>
        public decimal SysTrxNo
        {
            get;
            set;
        }
        /// <summary>
        /// Property for Note number
        /// </summary>
        public Int32 NoteNo
        {
            get;set;
        }
        /// <summary>
        /// Property for note type
        /// </summary>
        public int NoteTypeID
        {
            get;set;
        }
        /// <summary>
        /// Property for note
        /// </summary>
        public string Note
        {
            get;set;
        }
        /// <summary>
        /// Property for print is on
        /// </summary>
        public string PrintON
        {
            get;
            set;
        }
    }
}
