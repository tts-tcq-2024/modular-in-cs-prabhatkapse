using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelCo.ColorCoder;

namespace modular_in_csharp
{
    internal class GetColorIndex : ColorMappings
    {
        public int Major(ColorPair pair)
        {
            int colorIndex = -1;
            for (int i = 0; i < majorColorMapping.Length; i++)
            {
                if (majorColorMapping[i] == pair.majorColor)
                {
                    colorIndex = i;
                    break;
                }
            }
            return colorIndex;
        }

        public int Minor(ColorPair pair)
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
