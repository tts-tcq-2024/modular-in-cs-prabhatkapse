
using modular_in_csharp;

namespace TelCo.ColorCoder
{
    public class ColorCode : ColorMappings
    {
        public ColorPair GetColorFromPairNumber(int pairNumber)
        {
            int majorColorsCount = majorColorMapping.Length;
            int minorColorsCount = minorColorMapping.Length;

            if (pairNumber < 1 || pairNumber > minorColorsCount * majorColorsCount)
            {
                throw new ArgumentOutOfRangeException(
                    string.Format("Argument PairNumber:{0} is outside the allowed range", pairNumber));
            }

            int zeroBasedPairNumber = pairNumber - 1;
            int majorColorIndex = zeroBasedPairNumber / minorColorsCount;
            int minorColorIndex = zeroBasedPairNumber % minorColorsCount;

            ColorPair pair = new ColorPair() { majorColor = majorColorMapping[majorColorIndex], minorColor = majorColorMapping[minorColorIndex] };

            return pair;
        }

        public int GetPairNumberFromColor(ColorPair pair)
        {
            var GetColorIndex = new GetColorIndex();
            int majorColorIndex = GetColorIndex.Major(pair);
            int minorColorIndex = GetColorIndex.Minor(pair);

            if (majorColorIndex == -1 || minorColorIndex == -1)
            {
                throw new ArgumentException(
                    string.Format("Unknown Colors: {0}", pair.ToString()));
            }

            return (majorColorIndex * minorColorMapping.Length) + (minorColorIndex + 1);
        }
    }
}
