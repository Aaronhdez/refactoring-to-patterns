using Xunit;

namespace RefactoringToPatterns.CreationMethods.Tests
{
    public class ProductPackageShould
    {
        [Fact]
        public void CreateAProductPackageWithOnlyInternet()
        {
            var productPackage = ProductPackage.CreatePackage()
                .WithInternetLabel("100MB");

            Assert.True(productPackage.HasInternet());
            Assert.False(productPackage.HasVOIP());
            Assert.False(productPackage.HasTv());
        }

        [Fact]
        public void CreateWithInternetAndVoip()
        {
            var productPackage = ProductPackage.CreatePackage()
                .WithInternetLabel("100MB")
                .WithTelephoneNumber(91233788);

            Assert.True(productPackage.HasInternet());
            Assert.True(productPackage.HasVOIP());
            Assert.False(productPackage.HasTv());
        }

        [Fact]
        public void CreateWithInternetAndTv()
        {
            var productPackage = ProductPackage.CreatePackage()
                .WithInternetLabel("100MB")
                .WithTvChannels(new[] { "LaLiga", "Estrenos" });

            Assert.True(productPackage.HasInternet());
            Assert.False(productPackage.HasVOIP());
            Assert.True(productPackage.HasTv());
        }

        [Fact]
        public void CreateWithInternetVoipAndTv()
        {
            var productPackage = ProductPackage.CreatePackage()
                .WithInternetLabel("100MB")
                .WithTelephoneNumber(91233788)
                .WithTvChannels(new[] { "LaLiga", "Estrenos" });

            Assert.True(productPackage.HasInternet());
            Assert.True(productPackage.HasVOIP());
            Assert.True(productPackage.HasTv());
        }

        [Fact]
        public void CreateWithInternetAndMobilePhoneNumber()
        {
            var productPackage = ProductPackage.CreatePackage()
                .WithInternetLabel("100MB")
                .WithCellphoneNumber(654423538);

            Assert.True(productPackage.HasInternet());
            Assert.False(productPackage.HasVOIP());
            Assert.True(productPackage.HasMobilePhone());
            Assert.False(productPackage.HasTv());
        }


        [Fact]
        public void CreateWithInternetMobilePhoneNumberAndTv()
        {
            var productPackage = ProductPackage.CreatePackage()
                .WithInternetLabel("100MB")
                .WithCellphoneNumber(654234587)
                .WithTvChannels(new[] { "LaLiga", "Estrenos" });

            Assert.True(productPackage.HasInternet());
            Assert.False(productPackage.HasVOIP());
            Assert.True(productPackage.HasMobilePhone());
            Assert.True(productPackage.HasTv());
        }

        [Fact]
        public void CreateWithInternetVoipMobilePhoneNumberAndTv()
        {
            var productPackage = ProductPackage.CreatePackage()
                .WithInternetLabel("100MB")
                .WithTelephoneNumber(91233788)
                .WithCellphoneNumber(654234587)
                .WithTvChannels(new[] { "LaLiga", "Estrenos" });

            Assert.True(productPackage.HasInternet());
            Assert.True(productPackage.HasVOIP());
            Assert.True(productPackage.HasMobilePhone());
            Assert.True(productPackage.HasTv());
        }
    }
}