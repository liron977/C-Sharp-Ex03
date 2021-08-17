using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public  class ValueOutOfRangeException : Exception
    {
        private float m_MaxValue;
        private float m_MinValue;

        public ValueOutOfRangeException(float i_CurrentValue, float i_MaxValue, float i_MinValue)
            : base(string.Format(@"
Invalid input! 
Please enter amount between {0} to {1}
", i_MinValue, (i_MaxValue - i_CurrentValue)))
        {
            m_MaxValue = i_MaxValue;
            m_MinValue = i_MinValue;
        }
        public ValueOutOfRangeException(int i_CurrentValue, int i_MaxValue, int i_MinValue)
          : base(string.Format(@"
Invalid input! 
Please enter number between {0} to {1}
", i_MinValue, (i_MaxValue)))
        {
            m_MaxValue = i_MaxValue;
            m_MinValue = i_MinValue;
        }
    
    }
}
