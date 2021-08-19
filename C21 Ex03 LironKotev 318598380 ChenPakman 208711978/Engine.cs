using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public abstract class Engine
    {
        protected float m_CurrentEnginePower;
        protected float m_MaxEnginePower;

        protected Engine(float i_MaxEnginePower, float i_CurrentEnginePower)
        {
            m_MaxEnginePower = i_MaxEnginePower;
            if(i_CurrentEnginePower <= m_MaxEnginePower)
            {
                m_CurrentEnginePower = i_CurrentEnginePower;
            }
            else
            {
                throw new FormatException(
                    string.Format("The current engine power is bigger than The maximum:{0}.", m_MaxEnginePower));
            }
        }

        public new abstract string ToString();

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