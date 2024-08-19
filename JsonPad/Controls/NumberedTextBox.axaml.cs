using System;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Data;

namespace JsonPad.Controls;

public partial class NumberedTextBox : UserControl
{
    public static readonly StyledProperty<string> TextProperty =
        AvaloniaProperty.Register<NumberedTextBox, string>(nameof(Text));

    public string Text
    {
        get => GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }
    
    public NumberedTextBox()
    {
        InitializeComponent();
        Text = "";
        TextPanel.Text = Text;
    }

    private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
    {
        var text = TextPanel.Text;
        if (string.IsNullOrEmpty(text)) return;
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