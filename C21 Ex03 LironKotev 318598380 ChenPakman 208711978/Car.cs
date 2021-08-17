using System;
using System.Collections.Generic;


namespace Ex03.GarageLogic
{
    public class Car : Vehicle
    {
        public enum eCarColor
        {
            Red,
            Silver,
            White,
            Black
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
            Engine i_EngineType,
            eCarColor i_CarColor,
            eNumberOfDoors i_NumberOfDoors)
            : base(i_CarModel, i_LicenseNumber, i_EnergyPercentage, i_Wheels, i_EngineType)
        {
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

        public override string ToString()
        {
            string carDetails = string.Format(
                $@"{base.ToString()}
The car information: 
The color of the car is: {m_CarColor}
The number of the doors is {m_NumberOfDoors}
");
            return carDetails;
        }

        public static void GetDynamicParameter(Dictionary<string, Type> o_DynamicParams)
        {
            o_DynamicParams.Add("Color", typeof(eCarColor));
            o_DynamicParams.Add("Number of doors", typeof(eNumberOfDoors));
        }
    }
}