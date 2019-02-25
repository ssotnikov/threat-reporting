using Newtonsoft.Json;

namespace Sonar.Objects
{
	public class Paging
	{
		[JsonProperty("pageIndex")]
		public int PageIndex { get; set; }

		[JsonProperty("pageSize")]
		public int PageSize { get; set; }

		[JsonProperty("total")]
		public int Total { get; set; }
	}
}
