using System;
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

        public struct Constants
        {
            public const int k_NumOfWheels = 4;
            public const float k_CarMaxAirPressure = 32f;
            public const FuelEngine.eFuelType k_FuelType = FuelEngine.eFuelType.Octan96;
            public const float k_MaxBatreryTime = 2.1f;
            public const float k_MaxFuelCapacity = 60f;
        }
        public Car(
          string i_CarModel,
          string i_LicenseNumber,
          float i_EnergyPercentage,
          List<Wheel> i_Wheels,
          Engine i_EnginType,
          eCarColor i_carColor,
          eNumberOfDoors i_NumberOfDoors)
         : base(i_CarModel, i_LicenseNumber, i_EnergyPercentage, i_Wheels, i_EnginType)
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
            string CarDetails = string.Format($@"{base.ToString()}
The car information: 
The color of the car is: {m_CarColor}
The number of the doors is {m_NumberOfDoors}
");
            return CarDetails;
        }
        public static void GetDynamicParameter(Dictionary<string, Type> io_DynamicParams)
        {
            io_DynamicParams.Add("Color", typeof(eCarColor));
            io_DynamicParams.Add("Number of doors", typeof(eNumberOfDoors));
        }



    }
}
