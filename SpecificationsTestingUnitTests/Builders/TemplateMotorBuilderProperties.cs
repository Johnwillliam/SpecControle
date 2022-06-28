using System;

namespace EntityFrameworkModel
{
    public class TemplateMotorBuilder
    {
        private int _iD;
        
        private string _name;
        
        private string _type;
        
        private string _version;
        
        private Nullable<int> _iEC;
        
        private Nullable<int> _iP;
        
        private string _buildingType;
        
        private string _iSO;
        
        private Nullable<decimal> _highPower;
        
        private Nullable<decimal> _lowPower;
        
        private Nullable<int> _highRPM;
        
        private Nullable<int> _lowRPM;
        
        private Nullable<decimal> _highAmperage;
        
        private Nullable<decimal> _lowAmperage;
        
        private Nullable<int> _startupAmperage;
        
        private Nullable<int> _voltageTypeID;
        
        private Nullable<int> _frequency;
        
        private Nullable<int> _powerFactor;
        
        private VoltageType _voltageType;
        
        public TemplateMotorBuilder()
        {
            _iD = 1;
            _name = "Name1";
            _type = "Type1";
            _version = "Version1";
            _iEC = null;
            _iP = null;
            _buildingType = "BuildingType1";
            _iSO = "ISO1";
            _highPower = null;
            _lowPower = null;
            _highRPM = null;
            _lowRPM = null;
            _highAmperage = null;
            _lowAmperage = null;
            _startupAmperage = null;
            _voltageTypeID = null;
            _frequency = null;
            _powerFactor = null;
            _voltageType = null;
        }
        
        public TemplateMotorBuilder WithID(int iD)
        {
            _iD = iD;
            return this;
        }
        
        public TemplateMotorBuilder WithName(string name)
        {
            _name = name;
            return this;
        }
        
        public TemplateMotorBuilder WithType(string type)
        {
            _type = type;
            return this;
        }
        
        public TemplateMotorBuilder WithVersion(string version)
        {
            _version = version;
            return this;
        }
        
        public TemplateMotorBuilder WithIEC(Nullable<int> iEC)
        {
            _iEC = iEC;
            return this;
        }
        
        public TemplateMotorBuilder WithIP(Nullable<int> iP)
        {
            _iP = iP;
            return this;
        }
        
        public TemplateMotorBuilder WithBuildingType(string buildingType)
        {
            _buildingType = buildingType;
            return this;
        }
        
        public TemplateMotorBuilder WithISO(string iSO)
        {
            _iSO = iSO;
            return this;
        }
        
        public TemplateMotorBuilder WithHighPower(Nullable<decimal> highPower)
        {
            _highPower = highPower;
            return this;
        }
        
        public TemplateMotorBuilder WithLowPower(Nullable<decimal> lowPower)
        {
            _lowPower = lowPower;
            return this;
        }
        
        public TemplateMotorBuilder WithHighRPM(Nullable<int> highRPM)
        {
            _highRPM = highRPM;
            return this;
        }
        
        public TemplateMotorBuilder WithLowRPM(Nullable<int> lowRPM)
        {
            _lowRPM = lowRPM;
            return this;
        }
        
        public TemplateMotorBuilder WithHighAmperage(Nullable<decimal> highAmperage)
        {
            _highAmperage = highAmperage;
            return this;
        }
        
        public TemplateMotorBuilder WithLowAmperage(Nullable<decimal> lowAmperage)
        {
            _lowAmperage = lowAmperage;
            return this;
        }
        
        public TemplateMotorBuilder WithStartupAmperage(Nullable<int> startupAmperage)
        {
            _startupAmperage = startupAmperage;
            return this;
        }
        
        public TemplateMotorBuilder WithVoltageTypeID(Nullable<int> voltageTypeID)
        {
            _voltageTypeID = voltageTypeID;
            return this;
        }
        
        public TemplateMotorBuilder WithFrequency(Nullable<int> frequency)
        {
            _frequency = frequency;
            return this;
        }
        
        public TemplateMotorBuilder WithPowerFactor(Nullable<int> powerFactor)
        {
            _powerFactor = powerFactor;
            return this;
        }
        
        public TemplateMotorBuilder WithVoltageType(VoltageType voltageType)
        {
            _voltageType = voltageType;
            return this;
        }
        
        public TemplateMotor Build()
        {
            return new TemplateMotor()
            {
                ID = _iD,
                Name = _name,
                Type = _type,
                Version = _version,
                IEC = _iEC,
                IP = _iP,
                BuildingType = _buildingType,
                ISO = _iSO,
                HighPower = _highPower,
                LowPower = _lowPower,
                HighRPM = _highRPM,
                LowRPM = _lowRPM,
                HighAmperage = _highAmperage,
                LowAmperage = _lowAmperage,
                StartupAmperage = _startupAmperage,
                VoltageTypeID = _voltageTypeID,
                Frequency = _frequency,
                PowerFactor = _powerFactor,
                VoltageType = _voltageType,
            };
        }
        
    }
}
