using System.Text;

namespace ttd.Render;

public class Screen
{
    private readonly ScreenBufferCell[,] _frontBuffer;
    private readonly ScreenBufferCell[,] _backBuffer;
    private readonly int _width;
    private readonly int _height;

    public Screen(int width, int height)
    {
        _width = width;
        _height = height;
        _frontBuffer = new ScreenBufferCell[width, height];
        _backBuffer = new ScreenBufferCell[width, height];

        InitializeBuffer(_frontBuffer);
        InitializeBuffer(_backBuffer);
    }

    private void InitializeBuffer(ScreenBufferCell[,] buffer)
    {
        for (int x = 0; x < _width; x++)
        {
            for (int y = 0; y < _height; y++)
            {
                buffer[x, y] = new ScreenBufferCell();
            }
        }
    }

    public void Draw(int x, int y, char character, Color foreground, Color background)
    {
        if (x < 0 || x >= _width || y < 0 || y >= _height) return;
        
        _backBuffer[x, y].SetCharacter(character);
        _backBuffer[x, y].SetColors(foreground, background);
    }

    public void Draw(int x, int y, string text, Color foreground, Color background)
    {
        if (x < 0 || x >= _width || y < 0 || y >= _height) return;
        
        for (int i = 0; i < text.Length && x + i < _width; i++)
        {
            _backBuffer[x + i, y].SetCharacter(text[i]);
            _backBuffer[x + i, y].SetColors(foreground, background);
        }
    }

    public void Render()
    {
        var output = new StringBuilder();
        var lastPosition = (x: -1, y: -1);

        for (int y = 0; y < _height; y++)
        {
            for (int x = 0; x < _width; x++)
            {
                if (!_frontBuffer[x, y].Equals(_backBuffer[x, y]))
                {
                    if (lastPosition.x != x - 1 || lastPosition.y != y)
                    {
                        MoveCursor(output, x, y);
                        lastPosition = (x, y);
                    }
                    
                    SetBackgroundColor(output, _backBuffer[x, y].Background);
                    SetForegroundColor(output, _backBuffer[x, y].Foreground);
                    output.Append(_backBuffer[x, y].Character);
                    

                    _frontBuffer[x, y].CopyFrom(_backBuffer[x, y]);
                }

                _backBuffer[x, y].Clear();
            }
        }

        ResetColors(output);

        Console.Write(output);
    }

    public void SetAlternateScreenBuffer() => Console.Write("\x1b[?1049h");
    public void ResetAlternateScreenBuffer() => Console.Write("\x1b[?1049l");

    public int Width => _width;
    public int Height => _height;

    private static void MoveCursor(StringBuilder output, int x, int y)
        => output.Append($"\x1b[{y + 1};{x + 1}H");

    private static void ResetColors(StringBuilder output)
        => output.Append("\x1b[0m");

    private static void SetForegroundColor(StringBuilder output, Color color)
        => output.Append($"\x1b[38;2;{color.R};{color.G};{color.B}m");

    private static void SetForegroundDefault(StringBuilder output)
        => output.Append("\x1b[39m");

    private static void SetBackgroundDefault(StringBuilder output)
        => output.Append("\x1b[49m");

    private static void SetBackgroundColor(StringBuilder output, Color color)
    {
        if (color.isDefault)
        {
            SetBackgroundDefault(output);
            return;
        }
        output.Append($"\x1b[48;2;{color.R};{color.G};{color.B}m");
    }
}