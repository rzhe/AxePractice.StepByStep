using System;
using System.Collections.Generic;
using System.Linq;

namespace Manualfac
{
    class Disposer : Disposable
    {
        #region Please implements the following methods

        /*
         * The disposer is used for disposing all disposable items added when it is disposed.
         */
        readonly List<object> items = new List<object>();
        public void AddItemsToDispose(object item)
        {
           items.Add(item);
        }

        protected override void Dispose(bool disposing)
        {
            items.OfType<IDisposable>().ToList().ForEach(item => item.Dispose());
        }

        #endregion
    }
}