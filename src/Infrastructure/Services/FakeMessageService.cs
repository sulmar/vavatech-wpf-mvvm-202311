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

    private void Release()
    {
        Console.WriteLine("Usun plik tymczasowy");
    }

    public void Dispose()
    {
        Release();
    }
}

public class RealMessageService : IMessageService
{
    public void Dispose()
    {
        TearDown();
    }

    private void TearDown()
    {
        throw new NotImplementedException();
    }

    public void Send(Message message)
    {
        throw new NotImplementedException();
    }
}
