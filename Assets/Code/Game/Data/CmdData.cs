using System;
using Game.Enum;

namespace Game.Data
{
	[Serializable]
	public class CmdData
	{
		public Side SideMove { get; set; }
		public bool PressingJump { get; set; }
	}
}