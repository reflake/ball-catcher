using UnityEngine;

namespace MainMenu
{
	public abstract class BaseTable<TRow, TData> : MonoBehaviour 
		where TRow : BaseRow<TData>
	{
		[SerializeField] private TRow rowPrefab = null;
		[SerializeField] private Transform container = null;

		protected virtual void Awake() {}

		public void AddRow(TData rowData)
		{
			var newRow = InstantiateRow();

			newRow.SetData(rowData);
		}

		protected TRow InstantiateRow()
		{
			return Instantiate(rowPrefab, container);
		}
	}
}