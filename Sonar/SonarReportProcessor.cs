namespace Sonar
{
	public class SonarReportProcessor
	{
		public SonarAPI SonarAPI;

		public ParamsBuilder ParamsBuilder;
		public SonarReportProcessor()
		{
			SonarAPI = new SonarAPI();
			ParamsBuilder = new ParamsBuilder();
		}

	}
}
