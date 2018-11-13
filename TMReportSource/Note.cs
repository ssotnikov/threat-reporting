using System;

namespace TMReportSource
{
	public class Note
	{
		public int Id { get; set; }
		public string AddedBy { get; set; }
		public DateTime Date { get; set; }
		public string Message { get; set; }
	}
}