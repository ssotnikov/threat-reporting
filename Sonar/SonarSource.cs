using Sonar.Objects;
using Sonar.Objects.Common;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

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
