using UglyToad.PdfPig.Core;

namespace f29Reader.Domain;

public class F29TextCoordinate
{
    public F29TextCoordinate(string text, PdfRectangle rectangle, string label)
    {
        Text = text;
        Bottom = rectangle.Bottom;
        Left = rectangle.Left;
        Right = rectangle.Right;
        Top = rectangle.Top;
        Label = label;
    }

    public string Label { get; set; }

    public double Top { get; set; }

    public double Right { get; set; }

    public double Left { get; set; }

    public double Bottom { get; set; }

    public string Text { get; set; }
}