using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abstractions;

public interface INavigationService
{
    void NavigateTo(string url);
    void RegisterRoute(string route, Type type);
}
