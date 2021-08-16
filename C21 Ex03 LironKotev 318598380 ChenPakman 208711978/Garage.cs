using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        private readonly Dictionary<string, VehicleDetails> r_VehiclesInGarage;

        public Garage()
        {
            r_VehiclesInGarage = new Dictionary<string, VehicleDetails> { };
        }
        public Dictionary<string, VehicleDetails> VehiclesInGarage
        {
            get
            {
                return r_VehiclesInGarage;
            }
        }
        public void AddVehicleToGarage(VehicleDetails i_VehicleDetailsToAdd)
        {

            r_VehiclesInGarage.Add(i_VehicleDetailsToAdd.Vehicle.LicenseNumber, i_VehicleDetailsToAdd);

        }
        public void UpdateVehicleStatus(string i_LicenseNumber, VehicleDetails.eVehicleStatus i_VehicleNewStatus)
        {
            r_VehiclesInGarage[i_LicenseNumber].VehicleStatus = i_VehicleNewStatus;
        }
        public StringBuilder GetAllLiceseNumbersInGarage()
        {
            StringBuilder allLiceseNumbers = new StringBuilder();
            foreach (string element in r_VehiclesInGarage.Keys)
            {
                allLiceseNumbers.Append(element);
                allLiceseNumbers.Append(Environment.NewLine);
            }
            return allLiceseNumbers;
        }
        public StringBuilder GetLiceseNumbersInGarageByFilter(VehicleDetails.eVehicleStatus i_StausToFilter)
        {
            StringBuilder LiceseNumbersByFilter = new StringBuilder();
            foreach (VehicleDetails element in r_VehiclesInGarage.Values)
            {
                if (element.VehicleStatus.Equals(i_StausToFilter))
                {
                    LiceseNumbersByFilter.Append(element);
                    LiceseNumbersByFilter.Append(Environment.NewLine);
                }
            }
            return LiceseNumbersByFilter;
        }
        public void inflationAirToMaximum(string i_LicenseNumber)
        {
            foreach (Wheel wheel in r_VehiclesInGarage[i_LicenseNumber].Vehicle.ListOfWheels)
            {
                float amountToMaxAir = wheel.MaxAirPressure - wheel.CurrentAirPressure;
                wheel.InflationAction(amountToMaxAir);
            }
        }
        public void IsVehicleCanBeFueled(string i_LicenseNumber)
        {
            FuelEngine typeEngine = r_VehiclesInGarage[i_LicenseNumber].Vehicle.EngineType as FuelEngine;
            if (typeEngine == null)
            {
                throw new ArgumentException("Invalid engine type,this vehicle can`t be fueled");
            }
        }
        public void VehicleRefueling(string i_LicenseNumber, FuelEngine.eFuelType i_FuelType, float i_AmountOfFuleToAdd)
        {
                FuelEngine toRefill = r_VehiclesInGarage[i_LicenseNumber].Vehicle.EngineType as FuelEngine;
                toRefill.RefuelingAction(i_FuelType, i_AmountOfFuleToAdd);
            r_VehiclesInGarage[i_LicenseNumber].Vehicle.UpdatePercent();


        }
        public void VehicleCharging(string i_LicenseNumber, float i_MinutesToCharge)
        {
            ElecticityEngine vehicleToCharge = r_VehiclesInGarage[i_LicenseNumber].Vehicle.EngineType as ElecticityEngine;
            vehicleToCharge.chargingAction(i_MinutesToCharge / 60);

        }
        /*public void AddPower(string i_LicenseNumber, FuelEngine.eFuelType i_FuelType, float i_AmountOfFuleToAdd)
        {
            FuelEngine toRefill = r_VehiclesInGarage[i_LicenseNumber].Vehicle.EngineType as FuelEngine;

            if (r_VehiclesInGarage[i_LicenseNumber].Vehicle.EngineType is FuelEngine)
            {
                VehicleRefueling(i_LicenseNumber);
            }
        }*/
        public void IsVehicleCanBeCharged(string i_LicenseNumber)
        {
            ElecticityEngine typeEngine = r_VehiclesInGarage[i_LicenseNumber].Vehicle.EngineType as ElecticityEngine;
            if (typeEngine == null)
            {
                throw new ArgumentException("Invalid engine type,this vehicle can`t be charged");
            }
        }
       public bool IsVehicleExistByLicense(string i_LicenseNumber)
        {
            return r_VehiclesInGarage.ContainsKey(i_LicenseNumber);

        }
       public void ChangeStatusOfVehicle(string i_LicenseNumber, VehicleDetails.eVehicleStatus i_NewStatus)
        {
            r_VehiclesInGarage[i_LicenseNumber].VehicleStatus = i_NewStatus;

        }
        public string PrintSpecificVehicle(string i_LicenseNumber)
        {
            StringBuilder messageFromTheGarage = new StringBuilder();
            messageFromTheGarage.Append(r_VehiclesInGarage[i_LicenseNumber].ToString());
            messageFromTheGarage.Append(Environment.NewLine);
            messageFromTheGarage.Append("===============================================");

            return messageFromTheGarage.ToString();
        }

    }
}
