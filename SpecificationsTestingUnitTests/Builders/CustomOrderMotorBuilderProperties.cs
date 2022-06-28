using System;
using System.Collections.Generic;

namespace EntityFrameworkModel
{
    public class CustomOrderMotorBuilder
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
        
        private ICollection<CustomOrderVentilator> _customOrderVentilators;
        
        public CustomOrderMotorBuilder()
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
            _customOrderVentilators = null;
        }
        
        public CustomOrderMotorBuilder WithID(int iD)
        {
            _iD = iD;
            return this;
        }
        
        public CustomOrderMotorBuilder WithName(string name)
        {
            _name = name;
            return this;
        }
        
        public CustomOrderMotorBuilder WithType(string type)
        {
            _type = type;
            return this;
        }
        
        public CustomOrderMotorBuilder WithVersion(string version)
        {
            _version = version;
            return this;
        }
        
        public CustomOrderMotorBuilder WithIEC(Nullable<int> iEC)
        {
            _iEC = iEC;
            return this;
        }
        
        public CustomOrderMotorBuilder WithIP(Nullable<int> iP)
        {
            _iP = iP;
            return this;
        }
        
        public CustomOrderMotorBuilder WithBuildingType(string buildingType)
        {
            _buildingType = buildingType;
            return this;
        }
        
        public CustomOrderMotorBuilder WithISO(string iSO)
        {
            _iSO = iSO;
            return this;
        }
        
        public CustomOrderMotorBuilder WithHighPower(Nullable<decimal> highPower)
        {
            _highPower = highPower;
            return this;
        }
        
        public CustomOrderMotorBuilder WithLowPower(Nullable<decimal> lowPower)
        {
            _lowPower = lowPower;
            return this;
        }
        
        public CustomOrderMotorBuilder WithHighRPM(Nullable<int> highRPM)
        {
            _highRPM = highRPM;
            return this;
        }
        
        public CustomOrderMotorBuilder WithLowRPM(Nullable<int> lowRPM)
        {
            _lowRPM = lowRPM;
            return this;
        }
        
        public CustomOrderMotorBuilder WithHighAmperage(Nullable<decimal> highAmperage)
        {
            _highAmperage = highAmperage;
            return this;
        }
        
        public CustomOrderMotorBuilder WithLowAmperage(Nullable<decimal> lowAmperage)
        {
            _lowAmperage = lowAmperage;
            return this;
        }
        
        public CustomOrderMotorBuilder WithStartupAmperage(Nullable<int> startupAmperage)
        {
            _startupAmperage = startupAmperage;
            return this;
        }
        
        public CustomOrderMotorBuilder WithVoltageTypeID(Nullable<int> voltageTypeID)
        {
            _voltageTypeID = voltageTypeID;
            return this;
        }
        
        public CustomOrderMotorBuilder WithFrequency(Nullable<int> frequency)
        {
            _frequency = frequency;
            return this;
        }
        
        public CustomOrderMotorBuilder WithPowerFactor(Nullable<int> powerFactor)
        {
            _powerFactor = powerFactor;
            return this;
        }
        
        public CustomOrderMotorBuilder WithVoltageType(VoltageType voltageType)
        {
            _voltageType = voltageType;
            return this;
        }
        
        public CustomOrderMotorBuilder WithCustomOrderVentilators(ICollection<CustomOrderVentilator> customOrderVentilators)
        {
            _customOrderVentilators = customOrderVentilators;
            return this;
        }
        
        public CustomOrderMotor Build()
        {
            return new CustomOrderMotor()
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
                CustomOrderVentilators = _customOrderVentilators,
            };
        }
        
    }
}
