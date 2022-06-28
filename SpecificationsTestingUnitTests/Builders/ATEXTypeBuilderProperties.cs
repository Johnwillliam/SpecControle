namespace EntityFrameworkModel
{
    public class ATEXTypeBuilder
    {
        private int _iD;
        
        private string _description;
        
        public ATEXTypeBuilder()
        {
            _iD = 1;
            _description = "Description1";
        }
        
        public ATEXTypeBuilder WithID(int iD)
        {
            _iD = iD;
            return this;
        }
        
        public ATEXTypeBuilder WithDescription(string description)
        {
            _description = description;
            return this;
        }
        
        public ATEXType Build()
        {
            return new ATEXType()
            {
                ID = _iD,
                Description = _description,
            };
        }
        
    }
}
