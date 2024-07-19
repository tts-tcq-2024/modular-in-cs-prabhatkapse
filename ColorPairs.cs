using System.Drawing;

namespace TelCo.ColorCoder
{
    public class ColorPairs
    {
        public readonly Color[] majorColorMapping = new Color[] { Color.White, Color.Red, Color.Black, Color.Yellow, Color.Violet};
        public readonly Color[] minorColorMapping = new Color[] { Color.Blue, Color.Orange, Color.Green, Color.Brown, Color.SlateGray };

        public class ColorPair
        {
            public Color majorColor;
            public Color minorColor;
            public override string ToString()
            {
                return string.Format("MajorColor:{0}, MinorColor:{1}", majorColor.Name, minorColor.Name);
            }
        }

    }
}