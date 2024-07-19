
namespace TelCo.ColorCoder
{
    public class ColorCode : ColorPairs
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

            // Construct the return val from the arrays
            ColorPair pair = new ColorPair() { majorColor = majorColorMapping[majorColorIndex], minorColor = majorColorMapping[minorColorIndex] };

            // return the value
            return pair;
        }

        public int GetPairNumberFromColor(ColorPair pair)
        {
            int majorColorIndex = -1;
            for (int i = 0; i < majorColorMapping.Length; i++)
            {
                if (majorColorMapping[i] == pair.majorColor)
                {
                    majorColorIndex = i;
                    break;
                }
            }

            int minorColorIndex = -1;
            for (int i = 0; i < minorColorMapping.Length; i++)
            {
                if (minorColorMapping[i] == pair.minorColor)
                {
                    minorColorIndex = i;
                    break;
                }
            }
            // If colors can not be found throw an exception
            if (majorColorIndex == -1 || minorColorIndex == -1)
            {
                throw new ArgumentException(
                    string.Format("Unknown Colors: {0}", pair.ToString()));
            }

            // (Note: +1 in compute is because pair number is 1 based, not zero)
            return (majorColorIndex * minorColorMapping.Length) + (minorColorIndex + 1);
        }
    }
}
