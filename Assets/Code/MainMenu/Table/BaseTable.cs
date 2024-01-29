using System.Collections.Generic;
using UnityEngine;

namespace MainMenu.Table
{
	public abstract class BaseTable<TRow, TData> : MonoBehaviour 
		where TRow : BaseRow<TData>
	{
		[SerializeField] private TRow rowPrefab = null;
		[SerializeField] private Transform container = null;

		protected List<TRow> _rows = new();
		
		protected virtual void Awake() {}

		public void AddRow(TData rowData)
		{
			var newRow = InstantiateRow();

			_rows.Add(newRow);

			int index = _rows.IndexOf(newRow);
			
			newRow.Setup(index);
			newRow.SetData(rowData);
			newRow.SetStyle();
		}

		protected TRow InstantiateRow()
		{
			return Instantiate(rowPrefab, container);
		}
	}
}