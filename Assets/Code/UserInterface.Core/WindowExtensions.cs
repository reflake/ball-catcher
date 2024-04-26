using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace MainMenu
{
	public static class WindowExtensions
	{
		public static UniTask<TResult> OnClosedAsync<TWindow, TResult>(this TWindow window, TResult result, CancellationToken ct = default)
			where TWindow : MonoBehaviour, ICloseableWindow
		{
			var tcs = new UniTaskCompletionSource<TResult>();

			void Callback(IWindow _)
			{
				tcs.TrySetResult(result);

				window.OnWindowClose -= Callback;
			}

			window.OnWindowClose += Callback;

			return tcs.Task.AttachExternalCancellation(ct);
		}
	}
}