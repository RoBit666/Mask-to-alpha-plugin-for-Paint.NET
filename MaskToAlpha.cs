#region UICode
CheckboxControl _subtractWhite = false; // Subtract White
#endregion

void Render(Surface dst, Surface src, Rectangle rect)
{
    Rectangle bounds = EnvironmentParameters.GetSelectionAsPdnRegion().GetBoundsInt();
    ColorBgra primaryColor = EnvironmentParameters.PrimaryColor;

    for(int y = bounds.Top; y < bounds.Bottom; y++)
    {
        for(int x = bounds.Left; x < bounds.Right; x++)
        {
            byte brightness = GetBrightness(src[x, y]);
            brightness = _subtractWhite == true ? (byte)(255 - brightness) : brightness;

            primaryColor.A = brightness;
            dst[x, y] = primaryColor;
        }
    }
}

private byte GetBrightness(ColorBgra color)
{
    float r = color.R / 255f;
    float g = color.G / 255f;
    float b = color.B / 255f;

    float brightness = 0.2126f * r + 0.7152f * g + 0.0722f * b;

    return (byte)(brightness * 255);
}
