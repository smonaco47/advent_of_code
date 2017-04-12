
using AdventOfCodeLibrary.Path;
using NUnit.Framework;

namespace AdventOfCodeLibrary.Tests.Path
{
    class PathFollower_should
    {
        [Test]
        public void follow_directional_path()
        {
            string input = "R5, L5, R5, R3";
            var pathFollower = new PathFollower();
            pathFollower.FollowPath(input, false);
            Assert.AreEqual(12,pathFollower.DistanceFromStart());
        }


        [Test]
        public void follow_directional_path_without_repeat()
        {
            string input = "R8, R4, R4, R8";
            var pathFollower = new PathFollower();
            pathFollower.FollowPath(input, true);
            Assert.AreEqual(4, pathFollower.DistanceFromStart());
        }
    }
}
