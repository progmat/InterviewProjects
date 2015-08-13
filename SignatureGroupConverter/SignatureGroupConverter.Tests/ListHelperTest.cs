using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using SignatureGroupConverter.Core;

namespace Migrate.Tests
{
    [TestFixture]
    public class ListHelperTest
    {

        /// <summary>
        /// Helper method to check, that expected and actual result lists are the same
        /// </summary>
        /// <param name="expectedResults"></param>
        /// <param name="results"></param>
        private static void AssertResult(List<List<string>> expectedResults, List<List<string>> results)
        {
            for (var cnt = 0; cnt < expectedResults.Count; cnt++)
            {
                if (results.Count < cnt + 1)
                    Assert.Fail("Result too few elements");

                var result = results.ElementAt(cnt);
                var expectedResult = expectedResults.ElementAt(cnt);
                if (result.Intersect(expectedResult).Count() != expectedResult.Count)
                    Assert.Fail(
                        $"Expected: {expectedResult.Aggregate((i, j) => i + "," + j)}, actual result: {result.Aggregate((i, j) => i + "," + j)}");
            }
            if (results.Count > expectedResults.Count)
                Assert.Fail("Result too many elements");
        }

        [Test]
        public void ListIntersect_SingleSigGroup()
        {
            var allLists = new List<List<string>>
            {
                new List<string> { "A" }
            };
            var expectedResult = new List<List<string>>
            {
                new List<string> { "A"}
            };
            var result = ListHelper.TransformPartnerItemListToPartnerGroupList(allLists);
            AssertResult(expectedResult, result);
        }

        [Test]
        public void ListIntersect_TwoGroups_Distinct()
        {
            var allLists = new List<List<string>>
            {
                new List<string> { "A" },
                new List<string> { "B" }
            };
            var expectedResult = new List<List<string>>
            {
                new List<string> { "A"},
                new List<string> { "B"}
            };
            var result = ListHelper.TransformPartnerItemListToPartnerGroupList(allLists);
            AssertResult(expectedResult, result);
        }

        [Test]
        public void ListIntersect_TwoGroups_Intersect()
        {
            var allLists = new List<List<string>>
            {
                new List<string> { "A","B" },
                new List<string> { "A","B","C" }
            };
            var expectedResult = new List<List<string>>
            {
                new List<string> { "A","B"},
                new List<string> { "C"}
            };
            var result = ListHelper.TransformPartnerItemListToPartnerGroupList(allLists);
            AssertResult(expectedResult, result);
        }

        [Test]
        public void ListIntersect_ThreeGroups_Complex()
        {
            var allLists = new List<List<string>>
            {
                new List<string> { "A","B","C","D","E","F" },
                new List<string> { "A","E","G" },
                new List<string> { "F" }
            };
            var expectedResult = new List<List<string>>
            {
                new List<string> { "F" },
                new List<string> { "G"},
                new List<string> { "A","E"},
                new List<string> { "B","C","D"}
            };
            var result = ListHelper.TransformPartnerItemListToPartnerGroupList(allLists);
            AssertResult(expectedResult, result);
        }
    }
}
