using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abstractions;

public interface IMessageService : IDisposable
{
    void Send(Message message);
}

//public record Message 
//{
//    public string Content { get; set; }
//    public string Title { get; set; }
//    public string Recipient { get; set; }
//    public bool IsPriority { get; set; }

   
//}

public record Message(string Content, string Title, string Recipient, bool IsPriority);