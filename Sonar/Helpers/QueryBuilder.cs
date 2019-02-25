using Sonar.Objects;
using System.Collections.Generic;
using System.Text;

namespace Sonar.Helpers
{
	internal class QueryBuilder
	{

		internal static List<QueryParam> GetQueryParams(List<Facet> facets) {

			List<QueryParam> result = new List<QueryParam>();

			foreach (var facet in facets) {

				result.Add(new QueryParam
				{
					Property = facet.Property,

					Value = string.Join(", ", facet.Values)

				});

			}

			return result;
		}

		internal static string Build(List<Facet> facets) {

			var sb = new StringBuilder();

			if (facets.Count > 0)
			{

				sb.Append("?");

			}

			foreach (Facet facet in facets)
			{

				var property = facet.Property;

				if (property == "projects")
				{

					property = "componentKeys";

				}

				sb.AppendFormat("{0}={1}", property, string.Join(",", facet.Values));

				if (facets.IndexOf(facet) < facets.Count - 1)
				{

					sb.Append("&");

				}

			}

			return sb.ToString();

		}
	}
}
