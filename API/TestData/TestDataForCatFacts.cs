using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatedAPITests.TestData
{
    public static class TestDataForCatFacts
    {
        public static string type = "cat";
        public static string firstName = "Kasimir";
        public static string lastName = "Schulz";

        public static class FirstIdDetails
        {
            public static string id = "58e008800aac31001185ed07";
            public static string user = "58e007480aac31001185ecef";
            public static string fact = "Wikipedia has a recording of a cat meowing, because why not?";            
        }

        public class SecondIdDetails
        {
            public static string id = "58e008630aac31001185ed01";
            public static string user = "58e007480aac31001185ecef";
            public static string fact = "When cats grimace, they are usually \"taste-scenting.\" They have an extra organ that, with some breathing control, allows the cats to taste-sense the air.";
        }

        public class ThirdIdDetails
        {
            public static string id = "58e00a090aac31001185ed16";
            public static string user = "58e007480aac31001185ecef";
            public static string fact = "Cats make more than 100 different sounds whereas dogs make around 10.";
        }

        public class FourthIdDetails
        {
            public static string id = "58e009a90aac31001185ed23";
            public static string user = "58e007480aac31001185ecef";
            public static string fact = "Cats can distinguish different flavors in water.";
        }

        public class FifthIdDetails
        {
            public static string id = "58e009390aac31001185ed10";
            public static string user = "58e007480aac31001185ecef";
            public static string fact = "Most cats are lactose intolerant, and milk can cause painful stomach cramps and diarrhea. It's best to forego the milk and just give your cat the standard: clean, cool drinking water.";
        }

        public class SixthIdDetails
        {
            public static string id = "58e008780aac31001185ed05";
            public static string user = "58e007480aac31001185ecef";
            public static string fact = "Owning a cat can reduce the risk of stroke and heart attack by a third.";
        }
    }
}
