namespace Sonar.Helpers
{
	public static class ParamMapper
	{
		public static string Map(string prop)
		{
			if (prop == "projects")
			{
				return "componentKeys";
			}
			return prop;
		}
	}
}
