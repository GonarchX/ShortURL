using System;

namespace ShortURL.Models
{
    public class Pager
    {
        /// <summary>
        /// Count of all items in collection to show
        /// </summary>
        public int TotalItems { get; private set; }

        /// <summary>
        /// Count of items to show by one page
        /// </summary>
        public int PageSize { get; private set; }

        /// <summary>
        /// Total count of pages
        /// </summary>
        public int TotalPages { get; private set; }

        /// <summary>
        /// The current page in the pager
        /// </summary>
        public int CurrentPage { get; private set; }

        /// <summary>
        /// The first page in the pager
        /// </summary>
        public int StartPage { get; private set; }

        /// <summary>
        /// The last page in the pager
        /// </summary>
        public int LastPage { get; private set; }

        /// <summary>
        /// The number of pages that can be selected in the paginator
        /// </summary>
        public int CountShowPage { get; private set; }

        public Pager(int totalItems, int pageSize = 20, int currentPage = 1, int countShowPage = 5)
        {
            //Constraints
            if (totalItems < 0) throw new ArgumentOutOfRangeException("Count of total items should be positive");
            if (pageSize < 0) throw new ArgumentOutOfRangeException("Count of items on page should be positive");
            if (countShowPage < 1) throw new ArgumentOutOfRangeException("Count of pages to show should be more than 0");

            //Properties initializing
            TotalItems = totalItems;
            PageSize = pageSize;
            TotalPages = (int)Math.Ceiling((double)totalItems / pageSize);

            if (currentPage < 1) CurrentPage = 1;
            else if (currentPage > TotalPages) CurrentPage = TotalPages;
            else CurrentPage = currentPage;

            CountShowPage = countShowPage;

            if (CountShowPage > TotalPages)
                CountShowPage = TotalPages;

            GetBounds();
        }

        /// <summary>
        /// Calculate start and last pages
        /// </summary>
        private void GetBounds()
        {
            // Getting the first and last page based on the given bounds
            LastPage = CurrentPage + (int)Math.Floor((double)CountShowPage / 2);

            if (LastPage > TotalPages)
                LastPage = TotalPages;

            StartPage = CurrentPage + (LastPage - CurrentPage + 1 - CountShowPage);

            if (StartPage < 1)
                StartPage = 1;

            //Adding the rest pages if there are not enough pages on one side
            if ((LastPage - StartPage + 1) < CountShowPage)
                LastPage += CountShowPage - (LastPage - StartPage + 1);
        }
    }
}