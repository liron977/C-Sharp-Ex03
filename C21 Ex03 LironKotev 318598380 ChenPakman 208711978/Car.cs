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
        public Car(
          string i_CarModel,
          string i_LicenseNumber,
          float i_EnergyPercentage,
          List<Wheel> i_Wheels,
          eNumberOfDoors i_NumberOfDoors)
         : base(i_CarModel, i_LicenseNumber, i_EnergyPercentage, i_Wheels)
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
        public static void GetListOfDataMembers(ref List<string> io_DataMemberList)
        {
            Vehicle.GetListOfDataMembers(ref io_DataMemberList);
            io_DataMemberList.Add("Car color : 1 = Red, 2 = Silver, 3 = White, 4 = Black");
            io_DataMemberList.Add("Number of doors between 2 to 5");
            io_DataMemberList.Add("Wheels manufacturer name");
            for (int i = 1; i <= (int)eNumOfWheels.Car; ++i)
            {
                io_DataMemberList.Add("Current air pressure of wheel" + i + ":");
            }
        }


    }
}
