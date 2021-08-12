using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
   public class Engine
    {
        private float m_CurrentEnginePower;
        private float m_MaxEnginePower;

        public Engine(float i_CurrentEnginePower,float i_MaxEnginePower)
        {
            m_CurrentEnginePower = i_CurrentEnginePower;
            m_MaxEnginePower=i_MaxEnginePower;
        }

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
    }
}
