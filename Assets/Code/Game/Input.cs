using Game.Data;
using Game.Enum;
using UnityEngine;

namespace Game
{
	public class Input : MonoBehaviour
	{
		public CmdData GetCmd()
		{
			var axisThreshold = 0.1f;
			var horizontalAxisValue = UnityEngine.Input.GetAxis("Horizontal");
			var sideMove = Side.None;
			
			if (horizontalAxisValue > axisThreshold)
				
				sideMove = Side.Right;
				
			else if (horizontalAxisValue < -axisThreshold)
				
				sideMove = Side.Left;

			var pressingJump = UnityEngine.Input.GetButton("Jump");
			
			return new CmdData
			{
				SideMove = sideMove,
				PressingJump = pressingJump
			};
		}
	}
}