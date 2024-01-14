using System;

namespace MainMenu
{
	[AttributeUsage(AttributeTargets.Class)]
	public class WindowAttribute : Attribute
	{
		public string Path { get; set; }
	}
}