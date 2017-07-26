using System;
using System.Collections.Generic;

namespace Manualfac
{
    class Disposer : Disposable
    {
        #region Please implements the following methods

        /*
         * The disposer is used for disposing all disposable items added when it is disposed.
         */
        Stack<IDisposable> items = new Stack<IDisposable>();
        public void AddItemsToDispose(object item)
        {
            var disposable = item as IDisposable;
            if (disposable != null)
            {
                items.Push(disposable);
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                while (items.Count > 0)
                {
                    var item = items.Pop();
                    item.Dispose();
                }
                items = null;
            }

            base.Dispose(disposing);
        }

        #endregion
    }
}