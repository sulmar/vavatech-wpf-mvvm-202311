using Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WpfClient.Services;

internal class FrameNavigationService : INavigationService
{
    private readonly IDictionary<string, Type> views;

    public FrameNavigationService()
    {
        views = new Dictionary<string, Type>();

     
    }


    public void RegisterRoute(string route, Type type)
    {
        views.Add(route, type);
    }



    public void NavigateTo(string route)
    {
        var frame = Get("ContentFrame");

        //  frame.Navigate(new Uri(url, UriKind.Relative));
        Type type = views[route];

        var view = App.Current.Services.GetService(type);

        frame.Navigate(view);
    }

    private Frame Get(string name)
    {
        if (Application.Current.MainWindow.FindName(name) is Frame frame)
            return frame;
        
        throw new KeyNotFoundException();
    }
}
