using PruebasDeSoftware;

namespace Test
{
    public class ValidateISBNUnitTest
    {
        [Fact]
        public void CheckValidISBN()
        {
            // Arrange
            var validateISBN = new ValidateISBN();

            // Act
            bool result = validateISBN.CheckISBN("0140449116");

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void CheckInvalidISBN()
        {
            // Arrange
            var validateISBN = new ValidateISBN();

            // Act
            bool result = validateISBN.CheckISBN("0140441927");

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void CheckISBNLengthTenOrThirteen()
        {
            // Arrange
            var validateISBN = new ValidateISBN();

            // Act & Assert
            Assert.Throws<FormatException>(() => validateISBN.CheckISBN("012345678"));
        }

        [Fact]
        public void checkISBNNumeric()
        {
            // Arrange
            var validateISBN = new ValidateISBN();

            // Act & Assert
            Assert.Throws<FormatException>(() => validateISBN.CheckISBN("helloworld"));
        }

        [Fact]
        public void CheckContainsX()
        {
            // Arrange
            var validateISBN = new ValidateISBN();

            // Act
            bool result = validateISBN.CheckISBN("080442957X");

            // Assert
            Assert.True(result);
        }
        [Fact]
        public void CheckValidThirteenDigitISBN()
        {
            // Arrange
            var validateISBN = new ValidateISBN();

            // Act
            bool result = validateISBN.CheckISBN("9780306406157");

            // Assert
            Assert.True(result);
        }
    }
}