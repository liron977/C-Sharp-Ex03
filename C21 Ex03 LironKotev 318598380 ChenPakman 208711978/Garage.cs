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
        public void UpdateVehicleStatus(string i_LicenseNumber,VehicleDetails.eVehicleStatus i_VehicleNewStatus)
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
                if(element.VehicleStatus.Equals(i_StausToFilter))
                {
                    LiceseNumbersByFilter.Append(element);
                    LiceseNumbersByFilter.Append(Environment.NewLine);
                }         
            }
            return LiceseNumbersByFilter;
        }
        public void inflationAirToMaximum(string i_LicenseNumber)
        {
            VehicleDetails vehicleToUpdate;

            if (!r_VehiclesInGarage.TryGetValue(i_LicenseNumber, out vehicleToUpdate))
            {
                throw new FormatException("Can't find vehicle. Please insert a valid license plate.");
            }
            else
            {
                vehicleToUpdate.Vehicle.inflationWheelsAirToMaximum();
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
        public void VehicleRefueling(string i_LicenseNumber, FuelEngine.eFuelType i_FuelType,float i_AmountOfFuleToAdd)
        {
            FuelEngine vehicleToRefuel = r_VehiclesInGarage[i_LicenseNumber].Vehicle.EngineType as FuelEngine;
            vehicleToRefuel.RefuelingAction(i_AmountOfFuleToAdd, i_FuelType);

        }
        public void VehicleCharging(string i_LicenseNumber, float i_MinutesToCharge)
        {
            ElecticityEngine vehicleToCharge = r_VehiclesInGarage[i_LicenseNumber].Vehicle.EngineType as ElecticityEngine;
            vehicleToCharge.chargingAction(i_MinutesToCharge/60);

        }

        public void IsVehicleCanBeCharged(string i_LicenseNumber)
        {
            ElecticityEngine typeEngine = r_VehiclesInGarage[i_LicenseNumber].Vehicle.EngineType as ElecticityEngine;
            if (typeEngine == null)
            {
                throw new ArgumentException("Invalid engine type,this vehicle can`t be charged");
            }
        }

    }
}
