namespace RefactoringToPatterns.CreationMethods
{
    public class ProductPackage
    {
        private string _internetLabel;
        private int? _telephoneNumber;
        private string[] _tvChannels;
        private int? _cellphoneNumber;

        private ProductPackage()
        {
        }

        public static ProductPackage CreatePackage()
        {
            return new ProductPackage();
        }

        public ProductPackage WithInternetLabel(string internetLabel)
        {
            _internetLabel = internetLabel;
            return this;
        }
        
        public ProductPackage WithTelephoneNumber(int telephoneNumber)
        {
            _telephoneNumber = telephoneNumber;
            return this;
        }

        public ProductPackage WithCellphoneNumber(int cellphoneNumber)
        {
            _cellphoneNumber = cellphoneNumber;
            return this;
        }

        public ProductPackage WithTvChannels(string[] tvChannels)
        {
            _tvChannels = tvChannels;
            return this;
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
            return _cellphoneNumber != null;
        }
    }
}