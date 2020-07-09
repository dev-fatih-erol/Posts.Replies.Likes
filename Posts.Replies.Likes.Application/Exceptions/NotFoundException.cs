using System;

namespace Posts.Replies.Likes.Application.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string entity)
            : base($"{entity} not found.")
        {
        }
    }
}