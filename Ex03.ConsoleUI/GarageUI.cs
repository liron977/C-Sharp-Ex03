using System;
using System.Collections.Generic;
using System.Linq;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public class GarageUI
    {
        private enum eMenuChoice
        {
            InsertVehicleToTheGarage = 1,
            PresentVehicleLicenseNumber,
            ChangeVehicleStatus,
            PumpAirWheelsToMax,
            RefuelVehicle,
            ChargeVehicle,
            PresentInformationOfVehicle,
            ClearScreen,
            Exit
        }

        public static void StartMenu()
        {
            string userMenuChoice;
            int userMenuChoiceNumber;
            bool continueShowingMenu = true;
            Garage garage = new Garage();
            bool isParsingWorked;

            while(continueShowingMenu)
            {
                try
                {
                    printMenu();
                    userMenuChoice = Console.ReadLine();
                    checkStringEmpty(userMenuChoice);

                    isParsingWorked = int.TryParse(userMenuChoice, out userMenuChoiceNumber);
                    checkUserChoice(userMenuChoiceNumber, isParsingWorked);
                    if(userMenuChoiceNumber == (int)eMenuChoice.Exit)
                    {
                        printExit();
                        continueShowingMenu = false;
                    }

                    else
                    {
                        handleUserChoice(garage, userMenuChoiceNumber);
                    }
                }
                catch(ValueOutOfRangeException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch(ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch(FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private static void checkUserChoice(int i_UserChoice, bool i_IsValidChoice)
        {
            if(i_UserChoice < (int)eMenuChoice.InsertVehicleToTheGarage || i_UserChoice > (int)eMenuChoice.Exit
                                                                        || !i_IsValidChoice)
            {
                throw new ValueOutOfRangeException(
                    i_UserChoice,
                    (int)eMenuChoice.Exit,
                    (int)eMenuChoice.InsertVehicleToTheGarage);
            }
        }

        private static void printMenu()
        {
            Console.WriteLine(Environment.NewLine);
            string messageMenu = @"Hello, welcome to Liron and Chen garage! 
Please make a choice: 

1 - Insert vehicle to the garage.
2 - Present all license numbers of all vehicles in the garage.
3 - Change status of a vehicle in the garage.
4 - Inflate tires of vehicle in the garage.
5 - Refuel a vehicle.
6 - Charge a vehicle.
7 - Present all the details of a vehicle.
8 - Clear screen.
9 - Exit.

";
            Console.WriteLine(messageMenu);
        }

        private static void printExit()
        {
            Console.WriteLine(
                "Thank you! There is no warranty for the repair. Hope you have another malfunction in the vehicle and we will see you again!");
        }

        private static void handleUserChoice(Garage i_Garage, int i_UserChoice)
        {
            switch((eMenuChoice)i_UserChoice)
            {
                case eMenuChoice.InsertVehicleToTheGarage:
                    insertVehicleToGarage(i_Garage);

                    break;
                case eMenuChoice.PresentVehicleLicenseNumber:
                    showAllLicenseNumbers(i_Garage);

                    break;
                case eMenuChoice.ChangeVehicleStatus:
                    changeVehicleStatus(i_Garage);

                    break;
                case eMenuChoice.PumpAirWheelsToMax:
                    addAirToWheels(i_Garage);

                    break;
                case eMenuChoice.RefuelVehicle:
                    addFuelToVehicle(i_Garage);

                    break;
                case eMenuChoice.ChargeVehicle:
                    addElectricityToVehicle(i_Garage);

                    break;
                case eMenuChoice.PresentInformationOfVehicle:
                    printVehicleByLicenseNumber(i_Garage);

                    break;
                case eMenuChoice.ClearScreen:
                    Console.Clear();
                    break;
            }
        }

        private static void insertVehicleToGarage(Garage i_Garage)
        {
            bool isVehicleAdded = false;
            while(!isVehicleAdded)
            {
                try
                {
                    Console.WriteLine("Please enter the vehicle license number.");
                    string licenseNumber = Console.ReadLine();
                    checkStringEmpty(licenseNumber);

                    checkValidityLicenseNumber(licenseNumber);

                    if(i_Garage.IsVehicleExistByLicense(licenseNumber))
                    {
                        i_Garage.ChangeStatusOfVehicle(licenseNumber, VehicleDetails.eVehicleStatus.Repair);
                        Console.WriteLine("The vehicle already exists in the garage so it has been moved to repair.");
                    }
                    else
                    {
                        insertNewVehicleToGarage(i_Garage, licenseNumber);
                    }

                    isVehicleAdded = true;
                }
                catch(FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Please try again.");
                }
            }
        }

        private static void insertNewVehicleToGarage(Garage i_Garage, string i_LicenseNumber)
        {
            Vehicle vehicle = createNewVehicle(i_LicenseNumber);
            string vehicleOwnerName = getVehicleOwnerName();
            string vehicleOwnerPhone = getVehicleOwnerPhone();

            VehicleDetails newVehicleInGarage =
                VehicleManufacturing.CreateVehicleWithFullInformation(vehicle, vehicleOwnerName, vehicleOwnerPhone);
            i_Garage.AddVehicleToGarage(newVehicleInGarage);
        }

        private static string getVehicleOwnerPhone()
        {
            bool isValidPhoneNumberInput = false;
            string ownerPhone = null;

            while(!isValidPhoneNumberInput)
            {
                Console.WriteLine("Enter the vehicle owner's phone");
                ownerPhone = Console.ReadLine();
                checkStringEmpty(ownerPhone);

                isValidPhoneNumberInput = isValidOwnerPhone(ownerPhone);
                if(!isValidPhoneNumberInput)
                {
                    Console.WriteLine("Wrong format please try again.");
                }
            }

            return ownerPhone;
        }

        private static bool isValidOwnerPhone(string i_UserPhoneNumberInput)
        {
            long phoneInInt;
            bool isValidOwnerPhone = i_UserPhoneNumberInput.Length == 10
                                     && long.TryParse(i_UserPhoneNumberInput, out phoneInInt);

            return isValidOwnerPhone;
        }

        private static string getVehicleOwnerName()
        {
            bool isValidOwnerNameInput = false;
            string ownerName = String.Empty;

            while(!isValidOwnerNameInput)
            {
                Console.WriteLine("Enter vehicle owner's name");
                ownerName = Console.ReadLine();
                checkStringEmpty(ownerName);

                isValidOwnerNameInput = isValidOwnerName(ownerName);

                if(!isValidOwnerNameInput)
                {
                    Console.WriteLine(
                        "Invalid input! Please enter a name that contains only letters and its length is not less than 2.");
                }
            }

            return ownerName;
        }

        private static bool isValidOwnerName(string i_UserNameInput)
        {
            bool isValidOwnerName = true;
            if(i_UserNameInput.Length >= 2)
            {
                foreach(char character in i_UserNameInput)
                {
                    if(char.IsDigit(character))
                    {
                        isValidOwnerName = false;
                    }
                }
            }
            else
            {
                isValidOwnerName = false;
            }

            return isValidOwnerName;
        }

        private static Vehicle createNewVehicle(string i_LicenseNumber)
        {
            int energyType = 1;
            int vehicleType;
            string modelOfVehicle;
            float currentAmountOfEnergySource;
            float currAirPressure;
            string wheelsManufacturer;
            List<Wheel> vehicleWheels;
            Vehicle newVehicle;
            Dictionary<string, Type> dynamicParams = new Dictionary<string, Type>();
            Dictionary<string, object> dynamicObject = new Dictionary<string, object>();

            Console.WriteLine("Please enter the vehicle type");
            vehicleType = getUserEnumInput(typeof(VehicleManufacturing.eVehicleType));
            if(vehicleType == 1 || vehicleType == 2)
            {
                Console.WriteLine("Please enter the vehicle energy source:");
                energyType = getUserEnumInput(typeof(VehicleManufacturing.eEngineType));
            }

            currentAmountOfEnergySource = getCurrentAmountOfEnergySource(
                (VehicleManufacturing.eVehicleType)vehicleType,
                (VehicleManufacturing.eEngineType)energyType);

            Engine power = VehicleManufacturing.CreateEnergySource(
                (VehicleManufacturing.eVehicleType)vehicleType,
                (VehicleManufacturing.eEngineType)energyType,
                currentAmountOfEnergySource);

            currAirPressure = getAirPressure(
                (VehicleManufacturing.eVehicleType)vehicleType,
                (VehicleManufacturing.eEngineType)energyType);
            wheelsManufacturer = getWheelsManufacturer();
            vehicleWheels = VehicleManufacturing.CreateWheels(
                (VehicleManufacturing.eVehicleType)vehicleType,
                wheelsManufacturer,
                currAirPressure);
            modelOfVehicle = getVehicleModel();
            VehicleManufacturing.GetRequiredVehicleParameters(vehicleType, dynamicParams);
            getDynamicParametersDataFromUser(dynamicParams, dynamicObject);
            newVehicle = VehicleManufacturing.CreateVehicle(
                (VehicleManufacturing.eVehicleType)vehicleType,
                modelOfVehicle,
                i_LicenseNumber,
                power,
                vehicleWheels,
                dynamicObject);

            return newVehicle;
        }

        private static string getVehicleModel()
        {
            string vehicleModel = string.Empty;
            bool isValidVehicleModel = false;
            while(!isValidVehicleModel)
            {
                Console.WriteLine("Please enter the model of the vehicle");
                vehicleModel = Console.ReadLine();
                checkStringEmpty(vehicleModel);
                isValidVehicleModel = true;
            }

            return vehicleModel;
        }

        private static string getWheelsManufacturer()
        {
            string wheelsManufacturer = string.Empty;
            bool isValidWheelsManufacturer = false;

            while(!isValidWheelsManufacturer)
            {
                Console.WriteLine("Please enter the manufacturer of the wheels");
                wheelsManufacturer = Console.ReadLine();
                checkStringEmpty(wheelsManufacturer);
                isValidWheelsManufacturer = true;
            }

            return wheelsManufacturer;
        }

        private static float getCurrentAmountOfEnergySource(
            VehicleManufacturing.eVehicleType i_VehicleType,
            VehicleManufacturing.eEngineType i_EnergyType)
        {
            float inputInFloat = 0;
            bool isValidAmountOfEnergySource = false;

            while(!isValidAmountOfEnergySource)
            {
                Console.WriteLine("What is the current amount of energy in the vehicle?");
                string inputFromUser = Console.ReadLine();

                if(float.TryParse(inputFromUser, out inputInFloat))
                {
                    isValidAmountOfEnergySource = true;
                }
                else
                {
                    Console.WriteLine("Please enter only numbers");
                }
            }

            return inputInFloat;
        }

        private static float getAirPressure(
            VehicleManufacturing.eVehicleType i_VehicleType,
            VehicleManufacturing.eEngineType i_EnergyType)
        {
            bool isValidAirPressure = false;
            float inputInFloat = 0;

            while(!isValidAirPressure)
            {
                Console.WriteLine("Please enter current air pressure");
                string inputFromUser = Console.ReadLine();
                if(float.TryParse(inputFromUser, out inputInFloat))
                {
                    isValidAirPressure = true;
                }
                else
                {
                    Console.WriteLine("Please enter only numbers");
                }
            }

            return inputInFloat;
        }

        private static void changeVehicleStatus(Garage i_Garage)
        {
            bool isValidStatus = false;
            string newStatus;
            string licenseNumber;

            while(!isValidStatus)
            {
                try
                {
                    Console.WriteLine("Please enter license number");
                    licenseNumber = Console.ReadLine();
                    checkStringEmpty(licenseNumber);

                    checkValidityLicenseNumber(licenseNumber);
                    Console.WriteLine(
                        @"Please enter the new status of the vehicle:
1 - Repair
2 - Fixed
3 - Paid");
                    newStatus = Console.ReadLine();
                    checkValidityStatus(newStatus);
                    if(i_Garage.IsVehicleExistByLicense(licenseNumber))
                    {
                        i_Garage.ChangeStatusOfVehicle(
                            licenseNumber,
                            (VehicleDetails.eVehicleStatus)int.Parse(newStatus));
                        Console.WriteLine("The status has changed successfully");
                    }
                    else
                    {
                        printTheLicenseDoseNotExist();
                    }

                    isValidStatus = true;
                }
                catch(FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Please try again.");
                }
            }
        }

        private static void checkValidityLicenseNumber(string i_LicenseNumber)
        {
            if(!(i_LicenseNumber.All(char.IsNumber)))
            {
                throw new FormatException("Invalid format of license number");
            }
        }

        private static void checkValidityStatus(string i_NewStatus)
        {
            if(i_NewStatus != "1" && i_NewStatus != "2" && i_NewStatus != "3")
            {
                throw new FormatException("Invalid status of vehicle");
            }
        }

        private static void addAirToWheels(Garage i_Garage)
        {
            bool isValidInput = false;
            string licenseNumber;

            while(!isValidInput)
            {
                try
                {
                    Console.WriteLine("Please enter license number");
                    licenseNumber = Console.ReadLine();
                    checkValidityLicenseNumber(licenseNumber);
                    if(i_Garage.IsVehicleExistByLicense(licenseNumber))
                    {
                        i_Garage.InflationAirToMaximum(licenseNumber);
                        Console.WriteLine(
                            $"The wheels were inflated to the maximum: {i_Garage.VehiclesInGarage[licenseNumber].Vehicle.ListOfWheels[0].CurrentAirPressure}");
                    }
                    else
                    {
                        printTheLicenseDoseNotExist();
                    }

                    isValidInput = true;
                }
                catch(FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Please try again.");
                }
            }
        }

        private static void printTheLicenseDoseNotExist()
        {
            Console.WriteLine("Sorry, the license does not exist. You are redirected to the main menu");
        }

        private static void showAllLicenseNumbers(Garage i_Garage)
        {
            string isFilter;

            Console.WriteLine(
                @"Do you want to filter the license numbers by the status of condition?
1 - for yes
2 - for no");
            isFilter = Console.ReadLine();
            checkStringEmpty(isFilter);

            if(isFilter == "1")
            {
                showAllLicenseNumbersFilter(i_Garage);
            }
            else
            {
                showAllLicenseNumbersByRealOrder(i_Garage);
            }
        }

        private static void showAllLicenseNumbersFilter(Garage i_Garage)
        {
            int howManyVehiclesInGarage = 0;
            int filterType;

            Console.WriteLine("Please enter the filter for show license numbers:");
            filterType = getUserEnumInput(typeof(VehicleDetails.eVehicleStatus));
            Console.WriteLine();
            Console.WriteLine("The license numbers are:");
            foreach(KeyValuePair<string, VehicleDetails> entry in i_Garage.VehiclesInGarage)
            {
                if((VehicleDetails.eVehicleStatus)filterType == entry.Value.VehicleStatus)
                {
                    Console.WriteLine(entry.Key);
                    howManyVehiclesInGarage++;
                }
            }

            if(howManyVehiclesInGarage == 0)
            {
                Console.WriteLine("There are no vehicles by this filter in the garage");
            }
        }

        private static void showAllLicenseNumbersByRealOrder(Garage i_Garage)
        {
            if(i_Garage.VehiclesInGarage.Count == 0)
            {
                Console.WriteLine("There are no vehicles in the garage currently, please try later");
            }
            else
            {
                Console.WriteLine("The license numbers are:");
                foreach(KeyValuePair<string, VehicleDetails> entry in i_Garage.VehiclesInGarage)
                {
                    Console.WriteLine(entry.Key);
                }
            }
        }

        private static void printVehicleByLicenseNumber(Garage i_Garage)
        {
            bool isValidLicenseNumber = false;
            string licenseNumber;
            string informationOfVehicle;

            while (!isValidLicenseNumber)
            {
                try
                {
                    Console.WriteLine("Please enter license number");
                    licenseNumber = Console.ReadLine();
                    checkValidityLicenseNumber(licenseNumber);

                    if(i_Garage.IsVehicleExistByLicense(licenseNumber))
                    {
                        informationOfVehicle = i_Garage.PrintSpecificVehicle(licenseNumber);
                        Console.WriteLine(informationOfVehicle);
                    }
                    else
                    {
                        printTheLicenseDoseNotExist();
                    }

                    isValidLicenseNumber = true;
                }
                catch(FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Please try again.");
                }
            }
        }

        private static void addFuelToVehicle(Garage i_Garage)
        {
            bool isValidGasToAdd = false;
            string licenseNumber;
            string amountOfGas;
            int typeOfGas;

            while(!isValidGasToAdd)
            {
                try
                {
                    Console.WriteLine("Please enter license number");
                    licenseNumber = Console.ReadLine();
                    checkValidityLicenseNumber(licenseNumber);

                    if(i_Garage.IsVehicleExistByLicense(licenseNumber))
                    {
                        i_Garage.IsVehicleCanBeFueled(licenseNumber);
                        Console.WriteLine("Please enter the liter of fuel to add:");
                        amountOfGas = Console.ReadLine();
                        Console.WriteLine(@"Please enter the type of fuel to add:");
                        typeOfGas = getUserEnumInput(typeof(FuelEngine.eFuelType));

                        i_Garage.VehicleRefueling(
                            licenseNumber,
                            (FuelEngine.eFuelType)typeOfGas,
                            float.Parse(amountOfGas));
                        Console.WriteLine(
                            $@"The vehicle has been fueled till: {i_Garage.VehiclesInGarage[licenseNumber].Vehicle.EngineType.CurrentEnginePower}");
                    }
                    else
                    {
                        printTheLicenseDoseNotExist();
                    }

                    isValidGasToAdd = true;
                }

                catch(FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Please try again.");
                }
                catch(ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Please try again.");
                }
                catch(ValueOutOfRangeException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private static void addElectricityToVehicle(Garage i_Garage)
        {
            bool isValidElectricityToAdd = false;
            string licenseNumber;
            string amountOfElectricity;

            while(!isValidElectricityToAdd)
            {
                try
                {
                    Console.WriteLine("Please enter license number");
                    licenseNumber = Console.ReadLine();
                    checkValidityLicenseNumber(licenseNumber);

                    if(i_Garage.IsVehicleExistByLicense(licenseNumber))
                    {
                        i_Garage.IsVehicleCanBeCharged(licenseNumber);
                        Console.WriteLine("Please enter the amount of electricity to add:");
                        amountOfElectricity = Console.ReadLine();

                        i_Garage.VehicleCharging(licenseNumber, float.Parse(amountOfElectricity));
                        Console.WriteLine(
                            $@"The vehicle has been charged till: {i_Garage.VehiclesInGarage[licenseNumber].Vehicle.EngineType.CurrentEnginePower}");
                    }
                    else
                    {
                        printTheLicenseDoseNotExist();
                    }

                    isValidElectricityToAdd = true;
                }
                catch(FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Please try again.");
                }
                catch(ValueOutOfRangeException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch(ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Please try again.");
                }
            }
        }


        private static void getDynamicParametersDataFromUser(
            Dictionary<string, Type> i_VehicleDynamicTypes,
            Dictionary<string, object> o_VehicleDynamicObjects)
        {
            foreach(string currentParam in i_VehicleDynamicTypes.Keys)
            {
                if(i_VehicleDynamicTypes[currentParam] == typeof(bool))
                {
                    getBoolParameter(currentParam, o_VehicleDynamicObjects);
                }
                else if(i_VehicleDynamicTypes[currentParam] == typeof(int))
                {
                    getIntParameter(currentParam, o_VehicleDynamicObjects);
                }
                else if(i_VehicleDynamicTypes[currentParam] == typeof(float))
                {
                    getFloatParameter(currentParam, o_VehicleDynamicObjects);
                }
                else if(i_VehicleDynamicTypes[currentParam].IsEnum)
                {
                    getEnumParameter(currentParam, o_VehicleDynamicObjects, i_VehicleDynamicTypes[currentParam]);
                }
            }
        }


        private static void getIntParameter(string i_CurrentParam, Dictionary<string, object> i_DynamicOjects)
        {
            Console.WriteLine($@"Please enter {i_CurrentParam} as a positive number");
            i_DynamicOjects.Add(i_CurrentParam, getIntInput());
        }


        private static void getFloatParameter(string i_CurrentParam, Dictionary<string, object> io_DynamicObjects)
        {
            Console.WriteLine($@"Please enter {i_CurrentParam} as a positive number");
            io_DynamicObjects.Add(i_CurrentParam, getFloatInput());
        }

        private static int getUserEnumInput(Type i_Enum)
        {
            Array valuesOfEnum = Enum.GetValues(i_Enum);
            string indexOfEnum;
            int numberOfEnum = valuesOfEnum.Length;
            bool isParseNumber;
            bool isValidInput = false;
            int indexOfEnumValue = 0;
            int currentValueIndex = 1;

            while(!isValidInput)
            {
                currentValueIndex = 1;
                Console.WriteLine("Choose an option from the menu below: ");
                foreach(object enumValue in valuesOfEnum)
                {
                    Console.WriteLine(string.Format("({0})-{1}", currentValueIndex, enumValue));
                    currentValueIndex++;
                }

                indexOfEnum = Console.ReadLine();
                checkStringEmpty(indexOfEnum);

                isParseNumber = int.TryParse(indexOfEnum, out indexOfEnumValue);
                if(indexOfEnumValue <= numberOfEnum && isParseNumber && indexOfEnumValue >= 1)
                {
                    isValidInput = true;
                }
                else
                {
                    Console.WriteLine("Invalid Choice,please enter option that exist in the menu.");
                }
            }

            return indexOfEnumValue;
        }

        private static void getEnumParameter(
            string i_EnumParam,
            Dictionary<string, object> o_DynamicParams,
            Type i_EnumType)
        {
            Console.WriteLine($@"Please enter {i_EnumParam}.");
            o_DynamicParams.Add(i_EnumParam, getUserEnumInput(i_EnumType));
        }


        private static void getBoolParameter(string i_BoolParam, Dictionary<string, object> o_DynamicParams)
        {
            string userInput;
            int userInputAsInt;
            bool isValidBool = false;
            bool isParsingSucceeded;
            bool boolValue;

            Console.WriteLine($@"Choose {i_BoolParam}? Press 1 for 'True' ,press 2 for 'False'.");
            while(!isValidBool)
            {
                userInput = Console.ReadLine();
                checkStringEmpty(userInput);
                isParsingSucceeded = int.TryParse(userInput, out userInputAsInt);
                if(isParsingSucceeded && (userInputAsInt == 1 || userInputAsInt == 2))
                {
                    boolValue = (userInputAsInt == 1);
                    o_DynamicParams.Add(i_BoolParam, boolValue);
                    isValidBool = true;
                }
                else
                {
                    Console.WriteLine("Not a boolean option , please try again ");
                }
            }
        }

        private static float getFloatInput()
        {
            string inputOfuser;
            bool parsingWorked = false;
            float inputOfUserFloat = 0;

            while(!parsingWorked)
            {
                inputOfuser = Console.ReadLine();
                checkStringEmpty(inputOfuser);

                parsingWorked = float.TryParse(inputOfuser, out inputOfUserFloat);

                if(parsingWorked)
                {
                    if(inputOfUserFloat < 0)
                    {
                        Console.WriteLine("Please only enter positive numbers, try again");
                        parsingWorked = false;
                    }
                }
                else
                {
                    Console.WriteLine("Wrong format, please try again");
                }
            }

            return inputOfUserFloat;
        }

        private static int getIntInput()
        {
            string inputOfuser;
            bool parsingWorked = false;
            int inputOfUserInt = 0;

            while(!parsingWorked)
            {
                inputOfuser = Console.ReadLine();
                checkStringEmpty(inputOfuser);
                parsingWorked = int.TryParse(inputOfuser, out inputOfUserInt);

                if(parsingWorked)
                {
                    if(inputOfUserInt < 0)
                    {
                        Console.WriteLine("Please only enter positive numbers, try again");
                        parsingWorked = false;
                    }
                }
                else
                {
                    Console.WriteLine("Wrong format, please try again");
                }
            }

            return inputOfUserInt;
        }

        private static void checkStringEmpty(string i_StringToCheck)
        {
            bool stringIsEmpty = i_StringToCheck == string.Empty;

            if(stringIsEmpty)
            {
                throw new ArgumentException("The input is empty!,You are redirected to the main menu ");
            }
        }
    }
}