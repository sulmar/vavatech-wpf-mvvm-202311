using Microsoft.Xaml.Behaviors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace WpfClient.Behaviors
{
    internal class ButtonBehavior : Behavior<Button>
    {
        public string Color
        {
            get { return (string)GetValue(ColorProperty); }
            set { SetValue(ColorProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Color.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ColorProperty =
            DependencyProperty.Register("Color", typeof(string), typeof(ButtonBehavior), new PropertyMetadata(string.Empty));



        // public string Color { get; set; }

        protected override void OnAttached()
        {
            this.AssociatedObject.MouseEnter += AssociatedObject_MouseEnter;
        }

        private void AssociatedObject_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (sender is Button button)
            {
                button.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(Color));
            }

            
        }
    }
}
