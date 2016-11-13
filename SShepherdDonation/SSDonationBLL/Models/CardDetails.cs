/*
	Name:        CardDetails.cs
	Description: CardDetails class represents the cardDetails.
	Version:     1.0.0
	Author:      Ray Fu
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSDonationBLL.Models
{
    public class CardDetails
    {
        private string _Name;
        private string _Number;
        private int _ExpiryMonth;
        private int _ExpiryYear;
        private int _CVN;
        private int? _StartMonth;
        private int? _IssueNumber;
        private int? _StartYear;

        public int? StartMonth
        {
            get { return _StartMonth; }
            set { _StartMonth = value; }
        }

        public int? StartYear
        {
            get { return _StartYear; }
            set { _StartYear = value; }
        }

        public int? IssueNumber
        {
            get { return _IssueNumber; }
            set { _IssueNumber = value; }
        }

        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        public string Number
        {
            get { return _Number; }
            set { _Number = value; }
        }

        public int ExpiryMonth
        {
            get { return _ExpiryMonth; }
            set { _ExpiryMonth = value; }
        }

        public int ExpiryYear
        {
            get { return _ExpiryYear; }
            set { _ExpiryYear = value; }
        }

        public int CVN
        {
            get { return _CVN; }
            set { _CVN = value; }
        }
    }
}
