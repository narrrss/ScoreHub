using System;
using Hub.API.Filter;

namespace Hub.API.Services
{
	public interface IUriService
	{
        public Uri GetPageUri(PaginationFilter filter, string route);
    }
}

