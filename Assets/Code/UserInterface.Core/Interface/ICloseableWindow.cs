using MainMenu.Delegates;

namespace MainMenu
{
	public interface ICloseableWindow : IWindow
	{
		event WindowCloseDelegate OnWindowClose;

		void Close();
	}
}