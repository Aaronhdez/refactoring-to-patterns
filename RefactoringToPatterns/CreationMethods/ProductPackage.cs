namespace RefactoringToPatterns.CreationMethods
{
    public class ProductPackage
    {
        private readonly string _internetLabel;
        private readonly int? _telephoneNumber;
        private readonly int? _mobileNumber;
        private readonly string[] _tvChannels;

        private ProductPackage(string internetLabel, int? telephoneNumber, int? mobileNumber, string[] tvChannels)
        {
            _internetLabel = internetLabel;
            _telephoneNumber = telephoneNumber;
            _mobileNumber = mobileNumber;
            _tvChannels = tvChannels;
        }

        public static ProductPackage CreatePackageWith(string internetLabel,
            int? telephoneNumber = null,
            int? mobileNumber = null,
            string[] tvChannels = null)
        {
            return new ProductPackage(internetLabel, telephoneNumber, mobileNumber, tvChannels);
        }

        public bool HasInternet()
        {
            return _internetLabel != null;
        }


        public bool HasVOIP()
        {
            return _telephoneNumber != null;
        }

        public bool HasTv()
        {
            return _tvChannels != null;
        }

        public bool HasMobilePhone()
        {
            return _mobileNumber != null;
        }
    }
}