namespace RefactoringToPatterns.CreationMethods
{
    public class ProductPackage
    {
        private readonly string _internetLabel;
        private readonly int? _telephoneNumber;
        private readonly string[] _tvChannels;

        private ProductPackage(string internetLabel)
        {
            _internetLabel = internetLabel;
        }

        private ProductPackage(string internetLabel, int telephoneNumber)
        {
            _internetLabel = internetLabel;
            _telephoneNumber = telephoneNumber;
        }

        private ProductPackage(string internetLabel, string[] tvChannels)
        {
            _internetLabel = internetLabel;
            _tvChannels = tvChannels;
        }

        private ProductPackage(string internetLabel, int telephoneNumber, string[] tvChannels)
        {
            _internetLabel = internetLabel;
            _telephoneNumber = telephoneNumber;
            _tvChannels = tvChannels;
        }

        public static ProductPackage CreatePackageWith(string internetLabel)
        {
            return new ProductPackage(internetLabel);
        }

        public static ProductPackage CreatePackageWith(string internetLabel, int telephoneNumber)
        {
            return new ProductPackage(internetLabel, telephoneNumber);
        }

        public static ProductPackage CreatePackageWith(string internetLabel, string[] tvChannels)
        {
            return new ProductPackage(internetLabel, tvChannels);
        }

        public static ProductPackage CreatePackageWith(string internetLabel, int telephoneNumber, string[] tvChannels)
        {
            return new ProductPackage(internetLabel, telephoneNumber, tvChannels);
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
    }
}