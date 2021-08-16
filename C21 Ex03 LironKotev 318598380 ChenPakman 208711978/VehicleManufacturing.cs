using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
   public abstract class VehicleManufacturing
    {
  
        public enum eVehicleType
        {

            Motorcycle = 1,
            Car,
            Truck

        }
        public enum eEngineType
        {
            Gas = 1,
            Electricity

        }
        public static bool IsEnergyOptionRelevant(eVehicleType vehicleType)
        {

            return vehicleType != eVehicleType.Truck;
        }
        public static VehicleDetails CreateVehicleWithFullInformation(Vehicle i_Vehicle, string i_OwnerName, string i_OwnerPhone)
        {
            return new VehicleDetails(i_Vehicle,i_OwnerName, i_OwnerPhone);
        }

        public static Engine CreateEnergySource(
            eVehicleType i_VehicleType,
            eEngineType i_EnergyType,
            float i_AmountOfPowerSource)
        {
            Engine powerSource = null;
            switch (i_VehicleType)
            {
                case eVehicleType.Car:
                    if (i_EnergyType == eEngineType.Gas)
                    {
                        powerSource = new FuelEngine(FuelEngine.eFuelType.Octan95, i_AmountOfPowerSource, 45);
                    }
                    else
                    {
                        powerSource = new ElecticityEngine(3.2f, i_AmountOfPowerSource);
                    }

                    break;
                case eVehicleType.Motorcycle:
                    if (i_EnergyType == eEngineType.Gas)
                    {
                        powerSource = new FuelEngine(FuelEngine.eFuelType.Octan98, i_AmountOfPowerSource, 6);
                    }
                    else
                    {
                        powerSource = new ElecticityEngine(1.8f, i_AmountOfPowerSource);
                    }

                    break;
                case eVehicleType.Truck:
                    powerSource = new FuelEngine(FuelEngine.eFuelType.Soler, i_AmountOfPowerSource, 120);
                    break;
            }

            return powerSource;
        }

        public static List<Wheel> CreateWheels(eVehicleType i_VehicleType, string i_Manufacturer, float i_CurrAirPressure)
        {
            List<Wheel> wheels = new List<Wheel>();
            int maxAirPressure;
            int amountOfWheels;

            if (i_VehicleType == eVehicleType.Car)
            {
                maxAirPressure = 32;
                amountOfWheels = 4;
            }
            else if (i_VehicleType == eVehicleType.Motorcycle)
            {
                maxAirPressure = 30;
                amountOfWheels = 2;
            }
            else
            {
                maxAirPressure = 26;
                amountOfWheels = 16;
            }

            for (int i = 0; i < amountOfWheels; i++)
            {
                
                wheels.Add(new Wheel(i_Manufacturer, i_CurrAirPressure, maxAirPressure));
            }

            return wheels;

        }

        public static void GetRequiredVehicleParameters(int i_VehicleType, Dictionary<string, Type> io_DynamicParams)
        {
            eVehicleType vehicleType = (eVehicleType)i_VehicleType;

            switch (vehicleType)
            {
                case eVehicleType.Car:
                    Car.GetDynamicParameter(io_DynamicParams);
                    break;
                case eVehicleType.Motorcycle:
                    Motorcycle.GetDynamicParameter(io_DynamicParams);
                    break;
                case eVehicleType.Truck:
                    Truck.GetDynamicParameter(io_DynamicParams);
                    break;
            }
        }

        public static Vehicle CreateVehicle(eVehicleType i_VehicleType, string i_Model, string i_LicenseNumber, Engine i_Power, List<Wheel> i_Wheels, Dictionary<string, object> i_DynamicParameters)

        {
            Vehicle vehicleOfOwner = null;
            float energyPercent = i_Power.CurrentEnginePower;
            switch (i_VehicleType)
            {
                case eVehicleType.Car:
                    vehicleOfOwner = new Car(i_Model, i_LicenseNumber, energyPercent,
                        i_Wheels,
                        i_Power,
                        (Car.eCarColor)Enum.GetValues(typeof(Car.eCarColor)).GetValue((int)i_DynamicParameters["Color"] - 1),
                        (Car.eNumberOfDoors)Enum.GetValues(typeof(Car.eNumberOfDoors)).GetValue((int)i_DynamicParameters["Number of doors"] - 1));
                    break;
                case eVehicleType.Motorcycle:
                    vehicleOfOwner = new Motorcycle(i_Model, i_LicenseNumber, energyPercent,
                        i_Wheels,
                        i_Power,
                        (Motorcycle.eLicenseType)Enum.GetValues(typeof(Motorcycle.eLicenseType)).GetValue((int)i_DynamicParameters["License type"] - 1),
                        (int)i_DynamicParameters["Engine volume"]);
                    break;
                case eVehicleType.Truck:
                    vehicleOfOwner = new Truck(i_Model,
                        i_LicenseNumber,
                        energyPercent,
                        i_Wheels,
                        i_Power,
                        (bool)i_DynamicParameters["Dangerous Materials"],
                        (float)i_DynamicParameters["Cargo Volume"]);
                    break;
            }

            return vehicleOfOwner;

        }
         /*public static void CreateNewVehicle(eVehicleType vehicleType, eEngineType energyType,float currentAmountOfEnergySource,string wheelsManufacturer,float currAirPressure, Dictionary<string, Type> dynamicParams,string modelOfVehicle,string i_LicenseNumber,Dictionary<string, object> dynamicObject)
        {
            
            Vehicle newVehicle;

            Engine power=CreateEnergySource(vehicleType, energyType,currentAmountOfEnergySource);
            List<Wheel> vehicleWheels=CreateWheels(vehicleType,wheelsManufacturer,currAirPressure);
           GetRequiredVehicleParameters((int)vehicleType, dynamicParams);
            //newVehicle = CreateVehicle((VehicleManufacturing.eVehicleType)vehicleType, modelOfVehicle, i_LicenseNumber, power, vehicleWheels, dynamicObject);
            return power;
           // return newVehicle;

        }*/
        /*public void CreateVehicle(float[] currentAirPressure, List<string> i_VehicleInformation, eVehicleType i_TypeOfVehicle, string i_LicenseNumber)
        {
            Vehicle vehicleToReturn;
            float energyPersantage;
            switch (i_TypeOfVehicle)
            {

                case eVehicleType.GasMototorcycle:
                    {
                        energyPersantage = float.Parse(i_VehicleInformation[1]);
                        vehicleToReturn = new Motorcycle((string)i_VehicleInformation[0], i_LicenseNumber, energyPersantage,,)
                            break;
                    }





            }
        }*/
        /* public static List<string> ConvertUserChoiceToTypeOfVehicle(eVehicleType i_UserChoiceForVehicle)
         {
             List<string> vehicleDataMembers = new List<string>();

             switch (i_UserChoiceForVehicle)
             {
                 case eVehicleType.GasMototorcycle: case eVehicleType.ElectricMotorcycle:
                     {
                         Motorcycle.GetListOfDataMembers(ref vehicleDataMembers);
                         break;
                     }

                 case eVehicleType.GasCar: case eVehicleType.ElectricCar:
                     {
                         Car.GetListOfDataMembers(ref vehicleDataMembers);
                         break;
                     }
                 case eVehicleType.Truck:
                     {
                         Truck.GetListOfDataMembers(ref vehicleDataMembers);
                         break;
                     }

             }
             Engine.GetListOfDataMembers(ref vehicleDataMembers);
             return vehicleDataMembers;
         }
 */

    }
}
