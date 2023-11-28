using Logic.Business;

namespace SpecificationsTestingTests
{
    [TestFixture]
    public class MotorTemplateFieldValidation
    {
        [Test]
        public void ValidateNumber_ValidDecimal_ReturnsFalse()
        {
            bool result = CellValidation.ValidateNumber("123.45", typeof(decimal));
            Assert.IsFalse(result);
        }

        [Test]
        public void ValidateNumber_InvalidDecimal_ReturnsTrue()
        {
            bool result = CellValidation.ValidateNumber("abc", typeof(decimal));
            Assert.IsTrue(result);
        }

        [Test]
        public void ValidateNumber_ValidNonDecimal_ReturnsFalse()
        {
            bool result = CellValidation.ValidateNumber("123", typeof(int));
            Assert.IsFalse(result);
        }

        [Test]
        public void ValidateNumber_InvalidNonDecimal_ReturnsTrue()
        {
            bool result = CellValidation.ValidateNumber("abc", typeof(int));
            Assert.IsTrue(result);
        }

        [Test]
        public void CheckValue_NullableTypeWithNullValue_ReturnsTrue()
        {
            bool result = CellValidation.CheckValue(null, typeof(int?));
            Assert.IsFalse(result);
        }

        [Test]
        public void CheckValue_NullableTypeWithValue_ReturnsFalse()
        {
            bool result = CellValidation.CheckValue("123", typeof(int?));
            Assert.IsTrue(result);
        }

        [Test]
        public void CheckValue_NonNullableTypeWithNullValue_ReturnsFalse()
        {
            bool result = CellValidation.CheckValue(null, typeof(int));
            Assert.IsTrue(result);
        }

        [Test]
        public void CheckValue_NonNullableTypeWithValue_ReturnsTrue()
        {
            bool result = CellValidation.CheckValue("123", typeof(int));
            Assert.IsTrue(result);
        }

        [Test]
        public void IsNullable_ReferenceType_ReturnsTrue()
        {
            bool result = CellValidation.IsNullable(typeof(string));
            Assert.IsTrue(result);
        }

        [Test]
        public void IsNullable_ValueType_ReturnsFalse()
        {
            bool result = CellValidation.IsNullable(typeof(int));
            Assert.IsFalse(result);
        }

        [Test]
        public void IsNullable_NullableType_ReturnsTrue()
        {
            bool result = CellValidation.IsNullable(typeof(int?));
            Assert.IsTrue(result);
        }

        [Test]
        public void IsDecimalNumber_DecimalType_ReturnsTrue()
        {
            bool result = CellValidation.IsDecimalNumber(typeof(decimal));
            Assert.IsTrue(result);
        }

        [Test]
        public void IsDecimalNumber_NonDecimalType_ReturnsFalse()
        {
            bool result = CellValidation.IsDecimalNumber(typeof(int));
            Assert.IsFalse(result);
        }

        [Test]
        public void IsNumericType_NumericType_ReturnsTrue()
        {
            bool result = CellValidation.IsNumericType(typeof(int));
            Assert.IsTrue(result);
        }

        [Test]
        public void IsNumericType_NonNumericType_ReturnsFalse()
        {
            bool result = CellValidation.IsNumericType(typeof(string));
            Assert.IsFalse(result);
        }
    }
}