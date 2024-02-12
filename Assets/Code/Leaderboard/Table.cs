using Leaderboard.Entities;
using MainMenu.Table;

namespace Leaderboard
{
	public class Table : BaseTable<Row, Record>
	{
		protected override void Awake()
		{
			var headerRow = InstantiateRow();
		
			headerRow.SetAsHeader();
		}
	}
}