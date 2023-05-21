namespace CAD.Core.Shared.Models
{
    public class PaginationParams
    {
        public int PageSize { get; set; } = 4;

        private int _pageNumber;
        public int PageNumber
        {
            get { return Math.Max(_pageNumber, 1); }
            set { _pageNumber = value; }
        }
    }
}
