using System;
using Hub.Domain.Primitives;

namespace Hub.Domain.Entities
{
	public class News : Entity
    {
        public News(Guid Id) : base(Id)
        {
        }
        public News(string title, string content)
        {
            Title = title;
            Content = content;
        }

        public string Title { get; set; }
        public string Content { get; set; }
    }
}

