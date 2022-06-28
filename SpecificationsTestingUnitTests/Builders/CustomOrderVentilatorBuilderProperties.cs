using System;
using System.Collections.Generic;

namespace EntityFrameworkModel
{
    public class CustomOrderVentilatorBuilder
    {
        private int _iD;
        
        private int _customOrderID;
        
        private int _amount;
        
        private string _name;
        
        private int _customOrderMotorID;
        
        private Nullable<int> _ventilatorTypeID;
        
        private Nullable<int> _highAirVolume;
        
        private Nullable<int> _lowAirVolume;
        
        private Nullable<int> _highPressureTotal;
        
        private Nullable<int> _lowPressureTotal;
        
        private Nullable<int> _highPressureStatic;
        
        private Nullable<int> _lowPressureStatic;
        
        private Nullable<int> _highPressureDynamic;
        
        private Nullable<int> _lowPressureDynamic;
        
        private Nullable<int> _highRPM;
        
        private Nullable<int> _lowRPM;
        
        private Nullable<int> _efficiency;
        
        private Nullable<decimal> _highShaftPower;
        
        private Nullable<decimal> _lowShaftPower;
        
        private Nullable<int> _soundLevel;
        
        private Nullable<int> _soundLevelTypeID;
        
        private Nullable<int> _bladeAngle;
        
        private string _atex;
        
        private Nullable<int> _groupTypeID;
        
        private Nullable<int> _temperatureClassID;
        
        private Nullable<int> _catID;
        
        private Nullable<int> _catOutID;
        
        private CatType _catType;
        
        private CustomOrderMotor _customOrderMotor;
        
        private CustomOrder _customOrder;
        
        private SoundLevelType _soundLevelType;
        
        private GroupType _groupType;
        
        private TemperatureClass _temperatureClass;
        
        private VentilatorType _ventilatorType;
        
        private ICollection<CustomOrderVentilatorTest> _customOrderVentilatorTests;
        
        public CustomOrderVentilatorBuilder()
        {
            _iD = 1;
            _customOrderID = 1;
            _amount = 1;
            _name = "Name1";
            _customOrderMotorID = 1;
            _ventilatorTypeID = null;
            _highAirVolume = null;
            _lowAirVolume = null;
            _highPressureTotal = null;
            _lowPressureTotal = null;
            _highPressureStatic = null;
            _lowPressureStatic = null;
            _highPressureDynamic = null;
            _lowPressureDynamic = null;
            _highRPM = null;
            _lowRPM = null;
            _efficiency = null;
            _highShaftPower = null;
            _lowShaftPower = null;
            _soundLevel = null;
            _soundLevelTypeID = null;
            _bladeAngle = null;
            _atex = "Atex1";
            _groupTypeID = null;
            _temperatureClassID = null;
            _catID = null;
            _catOutID = null;
            _catType = null;
            _customOrderMotor = null;
            _customOrder = null;
            _soundLevelType = null;
            _groupType = null;
            _temperatureClass = null;
            _ventilatorType = null;
            _customOrderVentilatorTests = null;
        }
        
        public CustomOrderVentilatorBuilder WithID(int iD)
        {
            _iD = iD;
            return this;
        }
        
        public CustomOrderVentilatorBuilder WithCustomOrderID(int customOrderID)
        {
            _customOrderID = customOrderID;
            return this;
        }
        
        public CustomOrderVentilatorBuilder WithAmount(int amount)
        {
            _amount = amount;
            return this;
        }
        
        public CustomOrderVentilatorBuilder WithName(string name)
        {
            _name = name;
            return this;
        }
        
        public CustomOrderVentilatorBuilder WithCustomOrderMotorID(int customOrderMotorID)
        {
            _customOrderMotorID = customOrderMotorID;
            return this;
        }
        
        public CustomOrderVentilatorBuilder WithVentilatorTypeID(Nullable<int> ventilatorTypeID)
        {
            _ventilatorTypeID = ventilatorTypeID;
            return this;
        }
        
        public CustomOrderVentilatorBuilder WithHighAirVolume(Nullable<int> highAirVolume)
        {
            _highAirVolume = highAirVolume;
            return this;
        }
        
        public CustomOrderVentilatorBuilder WithLowAirVolume(Nullable<int> lowAirVolume)
        {
            _lowAirVolume = lowAirVolume;
            return this;
        }
        
        public CustomOrderVentilatorBuilder WithHighPressureTotal(Nullable<int> highPressureTotal)
        {
            _highPressureTotal = highPressureTotal;
            return this;
        }
        
        public CustomOrderVentilatorBuilder WithLowPressureTotal(Nullable<int> lowPressureTotal)
        {
            _lowPressureTotal = lowPressureTotal;
            return this;
        }
        
        public CustomOrderVentilatorBuilder WithHighPressureStatic(Nullable<int> highPressureStatic)
        {
            _highPressureStatic = highPressureStatic;
            return this;
        }
        
        public CustomOrderVentilatorBuilder WithLowPressureStatic(Nullable<int> lowPressureStatic)
        {
            _lowPressureStatic = lowPressureStatic;
            return this;
        }
        
        public CustomOrderVentilatorBuilder WithHighPressureDynamic(Nullable<int> highPressureDynamic)
        {
            _highPressureDynamic = highPressureDynamic;
            return this;
        }
        
        public CustomOrderVentilatorBuilder WithLowPressureDynamic(Nullable<int> lowPressureDynamic)
        {
            _lowPressureDynamic = lowPressureDynamic;
            return this;
        }
        
        public CustomOrderVentilatorBuilder WithHighRPM(Nullable<int> highRPM)
        {
            _highRPM = highRPM;
            return this;
        }
        
        public CustomOrderVentilatorBuilder WithLowRPM(Nullable<int> lowRPM)
        {
            _lowRPM = lowRPM;
            return this;
        }
        
        public CustomOrderVentilatorBuilder WithEfficiency(Nullable<int> efficiency)
        {
            _efficiency = efficiency;
            return this;
        }
        
        public CustomOrderVentilatorBuilder WithHighShaftPower(Nullable<decimal> highShaftPower)
        {
            _highShaftPower = highShaftPower;
            return this;
        }
        
        public CustomOrderVentilatorBuilder WithLowShaftPower(Nullable<decimal> lowShaftPower)
        {
            _lowShaftPower = lowShaftPower;
            return this;
        }
        
        public CustomOrderVentilatorBuilder WithSoundLevel(Nullable<int> soundLevel)
        {
            _soundLevel = soundLevel;
            return this;
        }
        
        public CustomOrderVentilatorBuilder WithSoundLevelTypeID(Nullable<int> soundLevelTypeID)
        {
            _soundLevelTypeID = soundLevelTypeID;
            return this;
        }
        
        public CustomOrderVentilatorBuilder WithBladeAngle(Nullable<int> bladeAngle)
        {
            _bladeAngle = bladeAngle;
            return this;
        }
        
        public CustomOrderVentilatorBuilder WithAtex(string atex)
        {
            _atex = atex;
            return this;
        }
        
        public CustomOrderVentilatorBuilder WithGroupTypeID(Nullable<int> groupTypeID)
        {
            _groupTypeID = groupTypeID;
            return this;
        }
        
        public CustomOrderVentilatorBuilder WithTemperatureClassID(Nullable<int> temperatureClassID)
        {
            _temperatureClassID = temperatureClassID;
            return this;
        }
        
        public CustomOrderVentilatorBuilder WithCatID(Nullable<int> catID)
        {
            _catID = catID;
            return this;
        }
        
        public CustomOrderVentilatorBuilder WithCatOutID(Nullable<int> catOutID)
        {
            _catOutID = catOutID;
            return this;
        }
        
        public CustomOrderVentilatorBuilder WithCatType(CatType catType)
        {
            _catType = catType;
            return this;
        }
        
        public CustomOrderVentilatorBuilder WithCustomOrderMotor(CustomOrderMotor customOrderMotor)
        {
            _customOrderMotor = customOrderMotor;
            return this;
        }
        
        public CustomOrderVentilatorBuilder WithCustomOrder(CustomOrder customOrder)
        {
            _customOrder = customOrder;
            return this;
        }
        
        public CustomOrderVentilatorBuilder WithSoundLevelType(SoundLevelType soundLevelType)
        {
            _soundLevelType = soundLevelType;
            return this;
        }
        
        public CustomOrderVentilatorBuilder WithGroupType(GroupType groupType)
        {
            _groupType = groupType;
            return this;
        }
        
        public CustomOrderVentilatorBuilder WithTemperatureClass(TemperatureClass temperatureClass)
        {
            _temperatureClass = temperatureClass;
            return this;
        }
        
        public CustomOrderVentilatorBuilder WithVentilatorType(VentilatorType ventilatorType)
        {
            _ventilatorType = ventilatorType;
            return this;
        }
        
        public CustomOrderVentilatorBuilder WithCustomOrderVentilatorTests(ICollection<CustomOrderVentilatorTest> customOrderVentilatorTests)
        {
            _customOrderVentilatorTests = customOrderVentilatorTests;
            return this;
        }
        
        public CustomOrderVentilator Build()
        {
            return new CustomOrderVentilator()
            {
                ID = _iD,
                CustomOrderID = _customOrderID,
                Amount = _amount,
                Name = _name,
                CustomOrderMotorID = _customOrderMotorID,
                VentilatorTypeID = _ventilatorTypeID,
                HighAirVolume = _highAirVolume,
                LowAirVolume = _lowAirVolume,
                HighPressureTotal = _highPressureTotal,
                LowPressureTotal = _lowPressureTotal,
                HighPressureStatic = _highPressureStatic,
                LowPressureStatic = _lowPressureStatic,
                HighPressureDynamic = _highPressureDynamic,
                LowPressureDynamic = _lowPressureDynamic,
                HighRPM = _highRPM,
                LowRPM = _lowRPM,
                Efficiency = _efficiency,
                HighShaftPower = _highShaftPower,
                LowShaftPower = _lowShaftPower,
                SoundLevel = _soundLevel,
                SoundLevelTypeID = _soundLevelTypeID,
                BladeAngle = _bladeAngle,
                Atex = _atex,
                GroupTypeID = _groupTypeID,
                TemperatureClassID = _temperatureClassID,
                CatID = _catID,
                CatOutID = _catOutID,
                CatType = _catType,
                CustomOrderMotor = _customOrderMotor,
                CustomOrder = _customOrder,
                SoundLevelType = _soundLevelType,
                GroupType = _groupType,
                TemperatureClass = _temperatureClass,
                VentilatorType = _ventilatorType,
                CustomOrderVentilatorTests = _customOrderVentilatorTests,
            };
        }
        
    }
}
