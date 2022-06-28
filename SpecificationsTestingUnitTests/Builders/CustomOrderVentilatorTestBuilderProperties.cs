using System;

namespace EntityFrameworkModel
{
    public class CustomOrderVentilatorTestBuilder
    {
        private int _iD;
        
        private int _customOrderVentilatorID;
        
        private Nullable<int> _measuredVentilatorHighRPM;
        
        private Nullable<int> _measuredVentilatorLowRPM;
        
        private Nullable<int> _measuredMotorHighRPM;
        
        private Nullable<int> _measuredMotorLowRPM;
        
        private Nullable<int> _measuredBladeAngle;
        
        private Nullable<int> _cover;
        
        private string _motorNumber;
        
        private Nullable<int> _weight;
        
        private Nullable<System.DateTime> _date;
        
        private Nullable<int> _userID;
        
        private Nullable<decimal> _i1High;
        
        private Nullable<decimal> _i1Low;
        
        private Nullable<decimal> _i2High;
        
        private Nullable<decimal> _i2Low;
        
        private Nullable<decimal> _i3High;
        
        private Nullable<decimal> _i3Low;
        
        private Nullable<int> _buildSize;
        
        private CustomOrderVentilator _customOrderVentilator;
        
        private User _user;
        
        public CustomOrderVentilatorTestBuilder()
        {
            _iD = 1;
            _customOrderVentilatorID = 1;
            _measuredVentilatorHighRPM = null;
            _measuredVentilatorLowRPM = null;
            _measuredMotorHighRPM = null;
            _measuredMotorLowRPM = null;
            _measuredBladeAngle = null;
            _cover = null;
            _motorNumber = "MotorNumber1";
            _weight = null;
            _date = null;
            _userID = null;
            _i1High = null;
            _i1Low = null;
            _i2High = null;
            _i2Low = null;
            _i3High = null;
            _i3Low = null;
            _buildSize = null;
            _customOrderVentilator = null;
            _user = null;
        }
        
        public CustomOrderVentilatorTestBuilder WithID(int iD)
        {
            _iD = iD;
            return this;
        }
        
        public CustomOrderVentilatorTestBuilder WithCustomOrderVentilatorID(int customOrderVentilatorID)
        {
            _customOrderVentilatorID = customOrderVentilatorID;
            return this;
        }
        
        public CustomOrderVentilatorTestBuilder WithMeasuredVentilatorHighRPM(Nullable<int> measuredVentilatorHighRPM)
        {
            _measuredVentilatorHighRPM = measuredVentilatorHighRPM;
            return this;
        }
        
        public CustomOrderVentilatorTestBuilder WithMeasuredVentilatorLowRPM(Nullable<int> measuredVentilatorLowRPM)
        {
            _measuredVentilatorLowRPM = measuredVentilatorLowRPM;
            return this;
        }
        
        public CustomOrderVentilatorTestBuilder WithMeasuredMotorHighRPM(Nullable<int> measuredMotorHighRPM)
        {
            _measuredMotorHighRPM = measuredMotorHighRPM;
            return this;
        }
        
        public CustomOrderVentilatorTestBuilder WithMeasuredMotorLowRPM(Nullable<int> measuredMotorLowRPM)
        {
            _measuredMotorLowRPM = measuredMotorLowRPM;
            return this;
        }
        
        public CustomOrderVentilatorTestBuilder WithMeasuredBladeAngle(Nullable<int> measuredBladeAngle)
        {
            _measuredBladeAngle = measuredBladeAngle;
            return this;
        }
        
        public CustomOrderVentilatorTestBuilder WithCover(Nullable<int> cover)
        {
            _cover = cover;
            return this;
        }
        
        public CustomOrderVentilatorTestBuilder WithMotorNumber(string motorNumber)
        {
            _motorNumber = motorNumber;
            return this;
        }
        
        public CustomOrderVentilatorTestBuilder WithWeight(Nullable<int> weight)
        {
            _weight = weight;
            return this;
        }
        
        public CustomOrderVentilatorTestBuilder WithDate(Nullable<System.DateTime> date)
        {
            _date = date;
            return this;
        }
        
        public CustomOrderVentilatorTestBuilder WithUserID(Nullable<int> userID)
        {
            _userID = userID;
            return this;
        }
        
        public CustomOrderVentilatorTestBuilder WithI1High(Nullable<decimal> i1High)
        {
            _i1High = i1High;
            return this;
        }
        
        public CustomOrderVentilatorTestBuilder WithI1Low(Nullable<decimal> i1Low)
        {
            _i1Low = i1Low;
            return this;
        }
        
        public CustomOrderVentilatorTestBuilder WithI2High(Nullable<decimal> i2High)
        {
            _i2High = i2High;
            return this;
        }
        
        public CustomOrderVentilatorTestBuilder WithI2Low(Nullable<decimal> i2Low)
        {
            _i2Low = i2Low;
            return this;
        }
        
        public CustomOrderVentilatorTestBuilder WithI3High(Nullable<decimal> i3High)
        {
            _i3High = i3High;
            return this;
        }
        
        public CustomOrderVentilatorTestBuilder WithI3Low(Nullable<decimal> i3Low)
        {
            _i3Low = i3Low;
            return this;
        }
        
        public CustomOrderVentilatorTestBuilder WithBuildSize(Nullable<int> buildSize)
        {
            _buildSize = buildSize;
            return this;
        }
        
        public CustomOrderVentilatorTestBuilder WithCustomOrderVentilator(CustomOrderVentilator customOrderVentilator)
        {
            _customOrderVentilator = customOrderVentilator;
            return this;
        }
        
        public CustomOrderVentilatorTestBuilder WithUser(User user)
        {
            _user = user;
            return this;
        }
        
        public CustomOrderVentilatorTest Build()
        {
            return new CustomOrderVentilatorTest()
            {
                ID = _iD,
                CustomOrderVentilatorID = _customOrderVentilatorID,
                MeasuredVentilatorHighRPM = _measuredVentilatorHighRPM,
                MeasuredVentilatorLowRPM = _measuredVentilatorLowRPM,
                MeasuredMotorHighRPM = _measuredMotorHighRPM,
                MeasuredMotorLowRPM = _measuredMotorLowRPM,
                MeasuredBladeAngle = _measuredBladeAngle,
                Cover = _cover,
                MotorNumber = _motorNumber,
                Weight = _weight,
                Date = _date,
                UserID = _userID,
                I1High = _i1High,
                I1Low = _i1Low,
                I2High = _i2High,
                I2Low = _i2Low,
                I3High = _i3High,
                I3Low = _i3Low,
                BuildSize = _buildSize,
                CustomOrderVentilator = _customOrderVentilator,
                User = _user,
            };
        }
        
    }
}
