using System;
using System.Collections.Generic;
using System.Text;

namespace common
{
    public class Message
    {
        public int Id { get; set; }
        public string Content { get; set; }

        public Message()
        {
            this.Id = 0;
            Content = "default content";
        }

        public Message(int id, string content)
        {
            this.Id = id;
            this.Content = content;
        }
    }
}
