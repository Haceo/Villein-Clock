using System.Collections.Generic;

namespace Vilian_Clock
{
    class PointMatrix
    {
        public enum PointsEnum : int
        {
            One = 1,
            Two = 2,
            Three = 3,
            Four = 4,
            Eight = 8,
            Twelve = 12,
            SixTeen = 16,
            ThirtyTwo = 32,
            FortyEight = 48,
            SixtyFour = 64,
            OneTwentyEight = 128,
            OneNintyTwo = 192,
            TwoFiftySix = 256,
            FiveTwelve = 512,
            SevenSixtyEight = 768

        }
        public Dictionary<int, string> Points { get; set; }

        public PointMatrix()
        {
            Points = new Dictionary<int, string>()
            {
                {1, "85,85 65,65" },
                {2, "105,65 85,85 105,105" },
                {3, "65,105 105,65" },
                {4, "85,45 65,25" },
                {8, "105,65 85,45 105,25" },
                {12, "105,65 85,45 105,25" },
                {16, "105,65 125,85" },
                {32, "145,65 125,85 145,105" },
                {48, "145,65 105,105" },
                {64, "65,105 85,125" },
                {128, "105,105 85,125 105,145" },
                {192, "105,105 65,145" },
                {256, "45,85 25,65" },
                {512, "65,65 45,85 65,105" },
                {768, "65,65 25,105" },
            };
        }

    }
}
