using UnityEngine;

namespace MainMenu
{
	public abstract class BaseRow<TData> : MonoBehaviour
	{
		public abstract void SetData(TData data);
		public abstract void SetAsHeader();
	}
}