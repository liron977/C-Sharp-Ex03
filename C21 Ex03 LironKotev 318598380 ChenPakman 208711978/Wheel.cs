using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    class Wheel
    {
        private string m_Manufacturer;
        private float m_CurrentAirPressure;
        private readonly float  r_MaximumAirPressureSetByManufacturer;

        public Wheel(string i_Manufacturer, float i_CurrentAirPressure, float i_MaximumAirPressureSetByManufacturer)
        {
            m_Manufacturer = i_Manufacturer;
            m_CurrentAirPressure = i_CurrentAirPressure;
            r_MaximumAirPressureSetByManufacturer = i_MaximumAirPressureSetByManufacturer;
        }
        public void InflationAction(float i_AirPressureToAdd)
        {
            float newAirPressure = i_AirPressureToAdd + m_CurrentAirPressure;

            if(newAirPressure> r_MaximumAirPressureSetByManufacturer)
            {
                //throw 
            }
            else
            {
                m_CurrentAirPressure = newAirPressure;
            }
        }
        public string Manufacturer
        {
            get
            {
                return m_Manufacturer;
            }
            set
            {
                m_Manufacturer = value;
            }
        }

        public float CurrentAirPressure
        {
            get
            {
                return m_CurrentAirPressure;
            }
            set
            {
                m_CurrentAirPressure = value;
            }
        }

        public float MaxAirPressure
        {
            get
            {
                return r_MaximumAirPressureSetByManufacturer;
            }
        }




    }
}
