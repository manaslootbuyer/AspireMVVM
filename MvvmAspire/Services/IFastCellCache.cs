using System;
using Xamarin.Forms;

namespace MvvmAspire.Controls
{
	public interface IFastCellCache
	{
		/// <summary>
		/// Flushs all caches.
		/// </summary>
		void FlushAllCaches ();
	}
}

