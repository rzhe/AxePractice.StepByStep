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
        readonly Stack<object> items = new Stack<object>();
        public void AddItemsToDispose(object item)
        {
           items.Push(item);
        }

        protected override void Dispose(bool disposing)
        {
            while (items.Count > 0)
            {
                var item = items.Pop();
                var disposableItem = item as IDisposable;
                disposableItem?.Dispose();
            }
        }

        #endregion
    }
}