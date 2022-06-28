using System;

namespace EntityFrameworkModel
{
    public class TemplateVentilatorBuilder
    {
        private int _iD;
        
        private string _name;
        
        private Nullable<int> _ventilatorTypeID;
        
        private Nullable<int> _airVolume;
        
        private Nullable<int> _pressureTotal;
        
        private Nullable<int> _pressureStatic;
        
        private Nullable<int> _pressureDynamic;
        
        private Nullable<int> _rPM;
        
        private Nullable<int> _efficiency;
        
        private Nullable<int> _shaftPower;
        
        private Nullable<int> _soundLevel;
        
        private Nullable<int> _soundLevelTypeID;
        
        private Nullable<int> _bladeAngle;
        
        private SoundLevelType _soundLevelType;
        
        private VentilatorType _ventilatorType;
        
        public TemplateVentilatorBuilder()
        {
            _iD = 1;
            _name = "Name1";
            _ventilatorTypeID = null;
            _airVolume = null;
            _pressureTotal = null;
            _pressureStatic = null;
            _pressureDynamic = null;
            _rPM = null;
            _efficiency = null;
            _shaftPower = null;
            _soundLevel = null;
            _soundLevelTypeID = null;
            _bladeAngle = null;
            _soundLevelType = null;
            _ventilatorType = null;
        }
        
        public TemplateVentilatorBuilder WithID(int iD)
        {
            _iD = iD;
            return this;
        }
        
        public TemplateVentilatorBuilder WithName(string name)
        {
            _name = name;
            return this;
        }
        
        public TemplateVentilatorBuilder WithVentilatorTypeID(Nullable<int> ventilatorTypeID)
        {
            _ventilatorTypeID = ventilatorTypeID;
            return this;
        }
        
        public TemplateVentilatorBuilder WithAirVolume(Nullable<int> airVolume)
        {
            _airVolume = airVolume;
            return this;
        }
        
        public TemplateVentilatorBuilder WithPressureTotal(Nullable<int> pressureTotal)
        {
            _pressureTotal = pressureTotal;
            return this;
        }
        
        public TemplateVentilatorBuilder WithPressureStatic(Nullable<int> pressureStatic)
        {
            _pressureStatic = pressureStatic;
            return this;
        }
        
        public TemplateVentilatorBuilder WithPressureDynamic(Nullable<int> pressureDynamic)
        {
            _pressureDynamic = pressureDynamic;
            return this;
        }
        
        public TemplateVentilatorBuilder WithRPM(Nullable<int> rPM)
        {
            _rPM = rPM;
            return this;
        }
        
        public TemplateVentilatorBuilder WithEfficiency(Nullable<int> efficiency)
        {
            _efficiency = efficiency;
            return this;
        }
        
        public TemplateVentilatorBuilder WithShaftPower(Nullable<int> shaftPower)
        {
            _shaftPower = shaftPower;
            return this;
        }
        
        public TemplateVentilatorBuilder WithSoundLevel(Nullable<int> soundLevel)
        {
            _soundLevel = soundLevel;
            return this;
        }
        
        public TemplateVentilatorBuilder WithSoundLevelTypeID(Nullable<int> soundLevelTypeID)
        {
            _soundLevelTypeID = soundLevelTypeID;
            return this;
        }
        
        public TemplateVentilatorBuilder WithBladeAngle(Nullable<int> bladeAngle)
        {
            _bladeAngle = bladeAngle;
            return this;
        }
        
        public TemplateVentilatorBuilder WithSoundLevelType(SoundLevelType soundLevelType)
        {
            _soundLevelType = soundLevelType;
            return this;
        }
        
        public TemplateVentilatorBuilder WithVentilatorType(VentilatorType ventilatorType)
        {
            _ventilatorType = ventilatorType;
            return this;
        }
        
        public TemplateVentilator Build()
        {
            return new TemplateVentilator()
            {
                ID = _iD,
                Name = _name,
                VentilatorTypeID = _ventilatorTypeID,
                AirVolume = _airVolume,
                PressureTotal = _pressureTotal,
                PressureStatic = _pressureStatic,
                PressureDynamic = _pressureDynamic,
                RPM = _rPM,
                Efficiency = _efficiency,
                ShaftPower = _shaftPower,
                SoundLevel = _soundLevel,
                SoundLevelTypeID = _soundLevelTypeID,
                BladeAngle = _bladeAngle,
                SoundLevelType = _soundLevelType,
                VentilatorType = _ventilatorType,
            };
        }
        
    }
}
