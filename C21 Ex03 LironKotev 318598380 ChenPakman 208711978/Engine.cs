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
            m_CurrentEnginePower = i_CurrentEnginePower;
            m_MaxEnginePower=i_MaxEnginePower;
        }

        public abstract void EnergyFillingAction(float i_AmountOfEnergyToFill);
    
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
