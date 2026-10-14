public class Fraction
{
    private int _top;
    private int _bottom;

    // Default constructor: 1/1
    public Fraction()
    {
        _top = 1;
        _bottom = 1;
    }

    // One parameter: wholeNumber/1
    public Fraction(int wholeNumber)
    {
        _top = wholeNumber;
        _bottom = 1;
    }

    // Two parameters: top/bottom
    public Fraction(int top, int bottom)
    {
        _top = top;
        _bottom = bottom;
    }

    public int GetTop()
    {
        return _top;
    }

    public void SetTop(int top)
    {
        _top = top;
    }

    public int GetBottom()
    {
        return _bottom;
    }

    public void SetBottom(int bottom)
    {
        _bottom = bottom;
    }

    public string GetFractionString()
    {
        return $"{_top}/{_bottom}";
    }

    public double GetDecimalValue()
    {
        // Cast to double so we don't get integer division (3/4 would be 0)
        return (double)_top / (double)_bottom;
    }
}