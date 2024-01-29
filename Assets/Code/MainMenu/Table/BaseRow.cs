using UnityEngine;

namespace MainMenu.Table
{
	public abstract class BaseRow<TData> : MonoBehaviour
	{
		public int Index { get; private set; }
		
		public void Setup(int index)
		{
			Index = index;
		}
		
		public virtual void SetStyle() {}
		
		public abstract void SetData(TData data);
		public abstract void SetAsHeader();
	}
}