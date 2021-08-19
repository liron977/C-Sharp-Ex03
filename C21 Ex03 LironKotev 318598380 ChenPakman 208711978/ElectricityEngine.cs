namespace Ex03.GarageLogic
{
    public class ElectricityEngine : Engine
    {
        public ElectricityEngine(float i_CurrentEnginePower, float i_MaxEnginePower)
            : base(i_CurrentEnginePower, i_MaxEnginePower)
        {
        }

        public void ChargingAction(float i_BatteryHoursToCharge)
        {
            float newBatteryHoursAmount = i_BatteryHoursToCharge + base.m_CurrentEnginePower;
            if(newBatteryHoursAmount > base.m_MaxEnginePower)
            {
                throw new ValueOutOfRangeException(base.m_CurrentEnginePower, base.m_MaxEnginePower, 0);
            }

            base.CurrentEnginePower = newBatteryHoursAmount;
        }

        public override string ToString()
        {
            string engineDetails = string.Format(
                $@"
The engine type is electricity type
The energy amount is : {m_CurrentEnginePower}
");
            return engineDetails;
        }
    }
}