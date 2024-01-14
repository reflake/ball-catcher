using MainMenu;

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