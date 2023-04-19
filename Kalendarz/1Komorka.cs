using System;
using System.Windows.Controls;

namespace Kalendarz


public class Komorka
{
    [System.Windows.Markup.ContentProperty(nameof(MyContent))]
    public Komorka : Control
	{
        public static readonly DependencyProperty MyContentProperty =
            DependencyProperty.Register(nameof(MyContent), typeof(object), typeof(Komorka), new PropertyMetadata(null));

    public object MyContent
    {
        get { return (object)GetValue(MyContentProperty); }
        set { SetValue(MyContentProperty, value); }
    }

    static Komorka()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(Komorka), new FrameworkPropertyMetadata(typeof(Komorka)));
    }
}
}
