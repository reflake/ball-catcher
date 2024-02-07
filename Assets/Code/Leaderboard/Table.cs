using Leaderboard.Local;
using MainMenu;
using MainMenu.Table;

namespace Leaderboard
{
	public class Table : BaseTable<Row, LocalEntry>
	{
		protected override void Awake()
		{
			var headerRow = InstantiateRow();
		
			headerRow.SetAsHeader();
		}
	}
}