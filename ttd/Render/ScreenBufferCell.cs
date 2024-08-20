namespace ttd.Render;

public class ScreenBufferCell
{
    public char Character { get; private set; }
    public Color Foreground { get; private set; }
    public Color Background { get; private set; }
    public bool IsDefaultForeground { get; private set; }
    public bool IsDefaultBackground { get; private set; }

    public bool IsEmpty => Character == ' ' && IsDefaultForeground && IsDefaultBackground;

    public ScreenBufferCell()
    {
        Clear();
    }

    public void SetCharacter(char character)
    {
        if (character == '\0')
            throw new ArgumentException("Character cannot be null", nameof(character));
        Character = character;
    }

    public void SetColors(Color foreground, Color background)
    {
        Foreground = foreground;
        Background = background;
        IsDefaultForeground = false;
        IsDefaultBackground = false;
    }

    public void SetForeground(Color foreground)
    {
        Foreground = foreground;
        IsDefaultForeground = false;
    }

    public void SetBackground(Color background)
    {
        Background = background;
        IsDefaultBackground = false;
    }

    public void Clear()
    {
        Character = ' ';
        Foreground = Color.Default;
        Background = Color.Default;
        IsDefaultForeground = true;
        IsDefaultBackground = true;
    }

    public void CopyFrom(ScreenBufferCell other)
    {
        Character = other.Character;
        Foreground = other.Foreground;
        Background = other.Background;
        IsDefaultForeground = other.IsDefaultForeground;
        IsDefaultBackground = other.IsDefaultBackground;
    }

    public bool Equals(ScreenBufferCell other)
    {
        return Character == other.Character &&
               Foreground.Equals(other.Foreground) &&
               Background.Equals(other.Background) &&
               IsDefaultForeground == other.IsDefaultForeground &&
               IsDefaultBackground == other.IsDefaultBackground;
    }

    public override bool Equals(object obj)
    {
        return obj is ScreenBufferCell cell && Equals(cell);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Character, Foreground, Background, IsDefaultForeground, IsDefaultBackground);
    }
}