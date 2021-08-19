namespace Ex03.GarageLogic
{
    public class Wheel
    {
        protected string m_Manufacturer;
        protected float m_CurrentAirPressure;
        protected readonly float r_MaximumAirPressureSetByManufacturer;

        public Wheel(string i_Manufacturer, float i_CurrentAirPressure, float i_MaximumAirPressureSetByManufacturer)
        {
            m_Manufacturer = i_Manufacturer;
            r_MaximumAirPressureSetByManufacturer = i_MaximumAirPressureSetByManufacturer;
            if(i_CurrentAirPressure <= r_MaximumAirPressureSetByManufacturer)
            {
                m_CurrentAirPressure = i_CurrentAirPressure;
            }
            else
            {
                throw new ValueOutOfRangeException(m_CurrentAirPressure, i_MaximumAirPressureSetByManufacturer, 0);
            }
        }

        public void InflationAction(float i_AirPressureToAdd)
        {
            float newAirPressure = i_AirPressureToAdd + m_CurrentAirPressure;

            if(newAirPressure > r_MaximumAirPressureSetByManufacturer)
            {
                throw new ValueOutOfRangeException(m_CurrentAirPressure, r_MaximumAirPressureSetByManufacturer, 0);
            }

            m_CurrentAirPressure = newAirPressure;
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

        public override string ToString()
        {
            string wheelsDetails = string.Format(
                $@"
The information about the wheel: 
The manufacturer is: {m_Manufacturer}
The current air pressure is : {m_CurrentAirPressure}
The maximum air pressure is :{r_MaximumAirPressureSetByManufacturer}");

            return wheelsDetails;
        }
    }
}