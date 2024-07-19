
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
            int majorColorIndex = getMajorColorIndex(pair);
            int minorColorIndex = getMinorClorIndex(pair);

            if (majorColorIndex == -1 || minorColorIndex == -1)
            {
                throw new ArgumentException(
                    string.Format("Unknown Colors: {0}", pair.ToString()));
            }

            return (majorColorIndex * minorColorMapping.Length) + (minorColorIndex + 1);
        }

        private int getMajorColorIndex(ColorPair pair)
        {

            for (int i = 0; i < majorColorMapping.Length; i++)
            {
                int colorIndex = -1;
                if (majorColorMapping[i] == pair.majorColor)
                {
                    colorIndex = i;
                    break;
                }
            }
            return colorIndex;
        } 

        private int getMinorClorIndex(ColorPair pair)
        {
            int colorIndex = -1;
            for (int i = 0; i < minorColorMapping.Length; i++)
            {
                if (minorColorMapping[i] == pair.minorColor)
                {
                    colorIndex = i;
                    break;
                }
            }
            return colorIndex;
        }
    }
}
