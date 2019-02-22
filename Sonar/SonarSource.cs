namespace Sonar
{
	public class SonarSource
	{
		public SonarAPI SonarAPI;

		public ParamsBuilder ParamsBuilder;
		public SonarSource()
		{
			SonarAPI = new SonarAPI();
			ParamsBuilder = new ParamsBuilder();
		}

	}
}
