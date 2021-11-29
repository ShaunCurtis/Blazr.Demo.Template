/// ============================================================
/// Author: Shaun Curtis, Cold Elm Coders
/// License: Use And Donate
/// If you use it, donate something to a charity somewhere
/// ============================================================

namespace $safeprojectname$
{
    public class PagingData
    {
        public int Page { get; private set; }

        public int PageSize { get; private set; }

        public int RecordCount { get; private set; }

        public int LastPage
            => ((int)Math.Ceiling(Decimal.Divide(this.RecordCount, this.PageSize))) - 1;

        public int LastDisplayPage => this.LastPage + 1;

        public int ReadStartRecord => this.Page * this.PageSize;

        public event EventHandler? PagingChanged;

        public PagingData(int page, int pageSize, int recordCount)
        {
            this.Page = page;
            this.PageSize = pageSize;
            this.RecordCount = recordCount;
        }

        public void Set(int page, int recordCount)
        {
            var update = this.Page != page | this.RecordCount != recordCount;
            this.Page = page;
            this.RecordCount = recordCount;
            if (update)
                this.NotifyPagingChanged();
        }

        public void SetPage(int page)
        {
            var update = this.Page != page;
            this.Page = page;
            if (update)
                this.NotifyPagingChanged();
        }

        public void SetPageSize(int pageSize)
        {
            var update = this.PageSize != pageSize;
            this.PageSize = pageSize;
            if (update)
                this.NotifyPagingChanged();
        }

        public void SetRecordCount(int recordCount)
        {
            var update = this.RecordCount != recordCount;
            this.RecordCount = recordCount;
            if (update)
                this.NotifyPagingChanged();
        }

        public void SetRecordCountSilently(int recordCount)
            => this.RecordCount = recordCount;

        public void SetPageSizeSilently(int pageSize)
            => this.PageSize = pageSize;

        protected void NotifyPagingChanged()
            => PagingChanged?.Invoke(this, EventArgs.Empty);

        public static PagingData New(int page, int pageSize, int recordCount)
            => new(page, pageSize, recordCount);
    }
}
