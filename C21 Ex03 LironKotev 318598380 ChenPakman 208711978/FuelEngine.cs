﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    class FuelEngine :Engine
    {
    
        public enum eFuelType
        {
            Octan98,
            Octan96,
            Octan95,
            Soler
        }
        private eFuelType m_FuelType;

        public FuelEngine(
      eFuelType i_FuelType,
     float i_CurrentEnginePower,
     float i_MaxEnginePower)
     : base(i_CurrentEnginePower, i_MaxEnginePower)
        {
            m_FuelType = i_FuelType;
        }
        public eFuelType FuelType
        {
            get
            {
                return m_FuelType;
            }
            set
            {
                m_FuelType = value;
            }
        }


    }
}