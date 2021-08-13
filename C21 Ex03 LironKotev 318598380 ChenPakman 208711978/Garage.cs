﻿using System;
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
            r_VehiclesInGarage[i_LicenseNumber].Vehicle.inflationWheelsAirToMaximum();
        }

    }
}