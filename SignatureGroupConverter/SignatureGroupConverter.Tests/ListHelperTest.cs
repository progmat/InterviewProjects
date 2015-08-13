using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using SignatureGroupConverter.Core;

namespace Migrate.Tests
{
    [TestFixture]
    public class ListHelperTest
    {

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
        public void ListIntersect_SingleOtherExists()
        {
            var toCheck = new List<string> { "1" };
            var allLists = new List<List<string>>
            {
                toCheck,
                new List<string> { "1","2"}
            };
            var expectedResult = new List<List<string>>
            {
                new List<string> { "1"}
            };
            var result = ListHelper.ListIntersectAll(allLists);
            AssertResult(expectedResult, result);
        }
        /*
        [Test]
        public void ListIntersect_Single_Noother()
        {
            var toCheck = new List<string> { "1" };
            var allLists = new List<List<string>>
            {
                toCheck,
                new List<string> { "2","3"}
            };
            var expectedResult = new List<List<string>>
            {
                new List<string> { "1"}
            };

            var result = ListHelper.ListIntersectAll(toCheck, allLists);
            AssertResult(expectedResult, result);
        }

        [Test]
        public void ListIntersect_Single_PossibleMultiple()
        {
            var toCheck = new List<string> { "1", "2", "3", "4" };
            var allLists = new List<List<string>>
            {
                toCheck,
                new List<string> { "3","4","5"},
                new List<string> { "1","4"}
            };
            var expectedResult = new List<List<string>>
            {
                new List<string> { "4" },
                new List<string> { "1" },
                new List<string> { "3" },
                new List<string> { "2" }

            };
            var result = ListHelper.ListIntersectAll(toCheck, allLists);
            AssertResult(expectedResult, result);
        }

        [Test]
        public void ListIntersect_Single_PossibleMultiple2()
        {
            var toCheck = new List<string> { "1", "2", "3" };
            var allLists = new List<List<string>>
            {
                toCheck,
                new List<string> { "2","3"},
                new List<string> { "2","3","4"}
            };
            var expectedResult = new List<List<string>>
            {
                new List<string> { "1" },
                new List<string> { "2","3" }
            };
            var result = ListHelper.ListIntersectAll(toCheck, allLists);
            AssertResult(expectedResult, result);
        }

        [Test]
        public void ListIntersect_Single_PossibleMultiple3()
        {
            var toCheck = new List<string> { "1", "2", "3" };
            var allLists = new List<List<string>>
            {
                toCheck,
                new List<string> { "2","3"},
            };
            var expectedResult = new List<List<string>>
            {
                new List<string> { "1" },
                new List<string> { "2","3" }
            };
            var result = ListHelper.ListIntersectAll(toCheck, allLists);
            AssertResult(expectedResult, result);
        }
        [Test]
        public void ListIntersect_Single_PossibleMultiple4()
        {
            var toCheck = new List<string> { "1", "2", "3" };
            var allLists = new List<List<string>>
            {
                toCheck,
                new List<string> { "4","5"},
            };
            var expectedResult = new List<List<string>>
            {
                new List<string> { "1","2","3" }
            };
            var result = ListHelper.ListIntersectAll(toCheck, allLists);
            AssertResult(expectedResult, result);
        }*/
    }
}
