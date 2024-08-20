namespace ttd.Render;

public readonly struct Color(byte r, byte g, byte b, bool isDefault = false) : IEquatable<Color>
{
    public byte R { get; } = r;
    public byte G { get; } = g;
    public byte B { get; } = b;
    public bool IsDefault { get; } = isDefault;
    
    public Color() : this(0, 0, 0, false) { }
    public Color(bool isDefault) : this(0, 0, 0, isDefault) { }
    
    public bool Equals(Color other)
    {
        return R == other.R && G == other.G && B == other.B && IsDefault == other.IsDefault;
    }

    public override bool Equals(object? obj)
    {
        return obj is Color color && Equals(color);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(R, G, B, IsDefault);
    }

    public static bool operator ==(Color left, Color right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(Color left, Color right)
    {
        return !(left == right);
    }
}