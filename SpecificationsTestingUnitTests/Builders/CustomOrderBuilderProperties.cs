using System;
using System.Collections.Generic;

namespace EntityFrameworkModel
{
    public class CustomOrderBuilder
    {
        private int _iD;
        
        private int _customOrderNumber;
        
        private string _debtor;
        
        private string _reference;
        
        private string _remarks;
        
        private Nullable<System.DateTime> _createDate;
        
        private ICollection<CustomOrderVentilator> _customOrderVentilators;
        
        public CustomOrderBuilder()
        {
            _iD = 1;
            _customOrderNumber = 1;
            _debtor = "Debtor1";
            _reference = "Reference1";
            _remarks = "Remarks1";
            _createDate = null;
            _customOrderVentilators = null;
        }
        
        public CustomOrderBuilder WithID(int iD)
        {
            _iD = iD;
            return this;
        }
        
        public CustomOrderBuilder WithCustomOrderNumber(int customOrderNumber)
        {
            _customOrderNumber = customOrderNumber;
            return this;
        }
        
        public CustomOrderBuilder WithDebtor(string debtor)
        {
            _debtor = debtor;
            return this;
        }
        
        public CustomOrderBuilder WithReference(string reference)
        {
            _reference = reference;
            return this;
        }
        
        public CustomOrderBuilder WithRemarks(string remarks)
        {
            _remarks = remarks;
            return this;
        }
        
        public CustomOrderBuilder WithCreateDate(Nullable<System.DateTime> createDate)
        {
            _createDate = createDate;
            return this;
        }
        
        public CustomOrderBuilder WithCustomOrderVentilators(ICollection<CustomOrderVentilator> customOrderVentilators)
        {
            _customOrderVentilators = customOrderVentilators;
            return this;
        }
        
        public CustomOrder Build()
        {
            return new CustomOrder()
            {
                ID = _iD,
                CustomOrderNumber = _customOrderNumber,
                Debtor = _debtor,
                Reference = _reference,
                Remarks = _remarks,
                CreateDate = _createDate,
                CustomOrderVentilators = _customOrderVentilators,
            };
        }
        
    }
}
