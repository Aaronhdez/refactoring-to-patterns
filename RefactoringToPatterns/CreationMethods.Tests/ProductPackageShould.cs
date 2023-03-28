using Xunit;

namespace RefactoringToPatterns.CreationMethods.Tests
{
    public class ProductPackageShould
    {
        [Fact]
        public void CreateAProductPackageWithOnlyInternet()
        {
            var productPackage = ProductPackage.CreatePackageWith("100MB");

            Assert.True(productPackage.HasInternet());
            Assert.False(productPackage.HasVOIP());
            Assert.False(productPackage.HasTv());
        }

        [Fact]
        public void CreateWithInternetAndVoip()
        {
            var productPackage = ProductPackage.CreatePackageWith("100MB", 91233788);

            Assert.True(productPackage.HasInternet());
            Assert.True(productPackage.HasVOIP());
            Assert.False(productPackage.HasTv());
        }

        [Fact]
        public void CreateWithInternetAndTv()
        {
            var productPackage = ProductPackage.CreatePackageWith("100MB", tvChannels: new[] {"LaLiga", "Estrenos"});

            Assert.True(productPackage.HasInternet());
            Assert.False(productPackage.HasVOIP());
            Assert.True(productPackage.HasTv());
        }

        [Fact]
        public void CreateWithInternetVoipAndTv()
        {
            var productPackage = ProductPackage.CreatePackageWith("100MB", 91233788, tvChannels: new string[] {"LaLiga", "Estrenos"});

            Assert.True(productPackage.HasInternet());
            Assert.True(productPackage.HasVOIP());
            Assert.True(productPackage.HasTv());
        }

        [Fact]
        public void CreateWithInternetAndMobilePhoneNumber()
        {
            var productPackage = ProductPackage.CreatePackageWith("100MB", mobileNumber: 654234587);

            Assert.True(productPackage.HasInternet());
            Assert.False(productPackage.HasVOIP());
            Assert.True(productPackage.HasMobilePhone());
            Assert.False(productPackage.HasTv());
        }        
    }
}