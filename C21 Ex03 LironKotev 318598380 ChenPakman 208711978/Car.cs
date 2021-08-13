﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
   public class Car:Vehicle
    {
        public enum eCarColor
        {
            Red,
            Silver,
            White,
            black
        }
        public enum eNumberOfDoors
        {
            Two = 2,
            Three = 3,
            Four = 4,
            Five = 5
        }
        protected eCarColor m_CarColor;
        protected eNumberOfDoors m_NumberOfDoors;
        public Car(
          string i_CarModel,
          string i_LicenseNumber,
          float i_EnergyPercentage,
          List<Wheel> i_Wheels,
         eCarColor i_CarColor,
          eNumberOfDoors i_NumberOfDoors)
         : base(i_CarModel, i_LicenseNumber, i_EnergyPercentage, i_Wheels)
        {
            m_CarColor = i_CarColor;
            m_NumberOfDoors = i_NumberOfDoors;
        }
        public eCarColor CarColor
        {
            get
            {
                return m_CarColor;
            }
            set
            {
                m_CarColor = value;
            }
        }

        public eNumberOfDoors NumberOfDoors
        {
            get
            {
                return m_NumberOfDoors;
            }
            set
            {
                m_NumberOfDoors = value;
            }
        }

    }
}