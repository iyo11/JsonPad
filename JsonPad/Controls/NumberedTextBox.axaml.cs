using System;
using System.Linq;
using Avalonia;
using Avalonia.Controls;

namespace JsonPad.Controls;

public partial class NumberedTextBox : UserControl
{
    public static readonly StyledProperty<string> TextProperty =
        AvaloniaProperty.Register<NumberedTextBox, string>(nameof(Text));

    public NumberedTextBox()
    {
        InitializeComponent();
        TextPanel.Text = Text;
    }

    public string Text
    {
        get => GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }

    private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
    {
        var text = TextPanel.Text;
        if (text == null) return;
        var lineCount = text.Split(new[] { Environment.NewLine }, StringSplitOptions.None).Length;
        LineNumberBlock.Text = string.Join(Environment.NewLine, Enumerable.Range(1, lineCount));
    }

    protected override void OnPropertyChanged(AvaloniaPropertyChangedEventArgs change)
    {
        base.OnPropertyChanged(change);
        if (change.Property != TextProperty) return;
        TextPanel.Text = Text;
    }
}