using Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services;

public class FakeMessageService : IMessageService
{
    public void Send(Message message)
    {
        Console.WriteLine(message);
    }
}

public class RealMessageService : IMessageService
{
    public void Send(Message message)
    {
        throw new NotImplementedException();
    }
}
