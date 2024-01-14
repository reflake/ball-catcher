using MainMenu.Delegates;

namespace MainMenu
{
	public interface IWindow
	{
		event WindowCloseDelegate OnWindowClose;
		
		void Open();
	}
}