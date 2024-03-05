namespace Ovow.Tools.Core
{
    public sealed class LengthyOperation : IDisposable
    {
        #region Private Fields

        private readonly Form parent;

        #endregion Private Fields

        #region Public Constructors

        public LengthyOperation(Form parent)
        {
            this.parent = parent;
            this.parent.Cursor = Cursors.WaitCursor;
        }

        #endregion Public Constructors

        #region Public Methods

        public void Dispose()
        {
            parent.Cursor = Cursors.Default;
        }

        #endregion Public Methods
    }
}
