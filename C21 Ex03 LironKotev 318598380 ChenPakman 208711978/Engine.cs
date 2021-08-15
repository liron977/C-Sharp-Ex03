using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
   public abstract class Engine
    {
        protected float m_CurrentEnginePower;
        protected float m_MaxEnginePower;

        public Engine(float i_CurrentEnginePower,float i_MaxEnginePower)
        {
            m_MaxEnginePower = i_MaxEnginePower;
            if (i_CurrentEnginePower <= m_MaxEnginePower)
            { m_CurrentEnginePower = i_CurrentEnginePower; }
            else
            {
                throw new FormatException(string.Format("The current engine power is bigger than The maximun:{0}.", m_MaxEnginePower));
            }
            
        }

        public abstract string ToString();

        public float CurrentEnginePower
        {
            get
            {
                return m_CurrentEnginePower;
            }
            set
            {
                m_CurrentEnginePower = value;
            }
        }
        public float MaxEnginePower
        {
            get
            {
                return m_MaxEnginePower;
            }
            set
            {
                m_MaxEnginePower = value;
            }
        }
        public static void GetListOfDataMembers(ref List<string> io_DataMemberList)
        {
            io_DataMemberList.Add("Current engine power");
        }

    }
}
