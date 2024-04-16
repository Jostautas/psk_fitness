using System.ComponentModel;

namespace psk_fitness;

public enum CssColorMode {
    HSLA, RGBA
}

[TypeConverter(typeof(CssColorTypeConverter))]
public class CssColor {
    public CssColorMode ColorMode { get; private set; }
    private Tuple<int, int, int, int> _colorTuple;

    // Main constructor overloads use
    public CssColor(CssColorMode cssColorMode, Tuple<int, int, int, int> colorTuple) {
        if (cssColorMode == CssColorMode.HSLA) {
            ValidateHSLATuple(colorTuple);
        }
        else if (cssColorMode == CssColorMode.RGBA) {
            ValidateRGBATuple(colorTuple);
        }
        else {
            throw new Exception("Only HSLA and RGBA color modes implemented");
        }
        _colorTuple = colorTuple;
        ColorMode = cssColorMode;
    }

    public static CssColor FromString(string cssColorString) {
        var parts = cssColorString.Split('(', ',', ',', ',', ')');
        if (parts.Length != 6) {
            throw new Exception("Invalid string format.");
        }
        var mode = (CssColorMode)Enum.Parse(typeof(CssColorMode), parts[0].ToUpper());
        var colorTuple = (int.Parse(parts[1]), int.Parse(parts[2]), int.Parse(parts[3]), int.Parse(parts[4])).ToTuple();
        return new CssColor(mode, colorTuple);
    }

    public CssColor(CssColorMode cssColorMode, Tuple<int, int, int> colorTuple)
    : this(cssColorMode, new Tuple<int, int, int, int>(colorTuple.Item1, colorTuple.Item2, colorTuple.Item3, 1)) {}


    private void ValidateHSLATuple(Tuple<int, int, int, int> hslaTuple) {
        var (hue, saturation, lightness, alpha) = hslaTuple;
        if (!hue.Between(0, 360)) {
            throw new Exception("Hue must be between 0 and 360.");
        }
        if (!saturation.Between(0, 100)) {
            throw new Exception("Saturation must be between 0 and 100.");
        }
        if (!lightness.Between(0, 100)) {
            throw new Exception("Lightness must be between 0 and 100.");
        }
        if (!alpha.Between(0, 1)) {
            throw new Exception("Alpha must be between 0 and 1.");
        }
    }

    private void ValidateRGBATuple(Tuple<int, int, int, int> rgbaTuple) {
        var (red, green, blue, alpha) = rgbaTuple;
        if (!red.Between(0, 255)) {
            throw new Exception("Red must be between 0 and 255.");
        }
        if (!green.Between(0, 255)) {
            throw new Exception("Green must be between 0 and 255.");
        }
        if (!blue.Between(0, 255)) {
            throw new Exception("Blue must be between 0 and 255.");
        }
        if (!alpha.Between(0, 1)) {
            throw new Exception("Alpha must be between 0 and 1.");
        }
    }

    public override string ToString() {
        var (one, two, three, four) = _colorTuple;
        return $"{ColorMode.ToString().ToLower()}({one}, {two}, {three}, {four})";
    }
}