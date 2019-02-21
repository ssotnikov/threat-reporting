using Sonar.Objects;
using System.Collections.Generic;
using System.Text;

namespace Sonar
{
	internal class QueryBuilder
	{
		internal static string Build(List<Facet> facets) {

			var sb = new StringBuilder();

			if (facets.Count > 0)
			{

				sb.Append("?");

			}

			foreach (Facet facet in facets)
			{

				var property = facet.property;

				if (property == "projects")
				{

					property = "componentKeys";

				}

				sb.AppendFormat("{0}={1}", property, string.Join(",", facet.values));

				if (facets.IndexOf(facet) < facets.Count - 1)
				{

					sb.Append("&");

				}

			}

			return sb.ToString();

		}
	}
}
