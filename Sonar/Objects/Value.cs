namespace Sonar.Objects
{
	public class Value
	{
		public string val { get; set; }
		public int count { get; set; }
		public override string ToString()
		{
			return val;
		}
	}
}
