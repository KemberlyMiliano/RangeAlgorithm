using NUnit.Framework;
using System;

namespace RangeProgram
{
    [TestFixture]
    class ProgramTests{
        [Test]
        //[2,6)
        public void GetAllPoints__2_6_Return__2_5__(){
            Range range = new Range("[2,6)");

            var result = range.GetAllPoints();
            int[] a = {2,3,4,5};

            Assert.AreEqual(a,result);
        }

         //(6,11)   [7,10]
         [Test]
        public void GetAllPoints_6_11_Return__7_10__(){
            Range range = new Range("(6,11)");

            var result = range.GetAllPoints();
            int[] a = {7,8,9,10};

            Assert.AreEqual(a,result);
        }

        [Test]
        public void GetAllPoints__9_15__Return_9_15(){
            Range range = new Range("[9,15]");
            var result = range.GetAllPoints();
            int[] a = {9,10,11,12,13,14,15};
            Assert.AreEqual(a, result);
        }

        [Test]
        public void GetAllPoints_0_4__Return_1_4(){
            Range range = new Range("(0,4]");
            var result = range.GetAllPoints();
            int[] a = {1,2,3,4};
            Assert.AreEqual(a, result);
        }

        Range r = new Range("[4,9)");

        [TestCase(5)]
        [TestCase(4)]
        public void Contains__4_9_Return_True(int number){
            var result = r.Contains(number);
            Assert.IsTrue(result);
        }

        [TestCase(9)]
        [TestCase(3)]
        public void Contains__4_9_Return_False(int number){
            var result = r.Contains(number);
            Assert.IsFalse(result);
        }

        [TestCase(9)]
        [TestCase(3)]
        public void NotContains__4_9_Return_True(int number){
            var result = r.NotContains(number);
            Assert.IsTrue(result);
        }

        [TestCase(5)]
        [TestCase(4)]
        public void NotContains__4_9_Return_False(int number){
            var result = r.NotContains(number);
            Assert.IsFalse(result);
        }

        [Test]
         public void _3_8_ContainsRange__2_6_(){
            Range baseRange = new Range("(3,8)");
            Range containedRange = new Range("[4,6)");
            var result = baseRange.ContainsRange(containedRange);

            Assert.IsTrue(result);
        }

         [Test]
         public void __2_9_ContainsRange_3_8__(){
            Range baseRange = new Range("[2,9)");
            Range containedRange = new Range("(3,8]");
            var result = baseRange.ContainsRange(containedRange);

            Assert.IsTrue(result);
        }

         [Test]
         public void __3_5_ContainsRange__3_5__(){
            Range baseRange = new Range("[3,5)");
            Range containedRange = new Range("[3,5]");
            var result = baseRange.ContainsRange(containedRange);

            Assert.IsFalse(result);
        }

         [Test]
         public void _3_10_ContainsRange__7_15__(){
            Range baseRange = new Range("(3,10)");
            Range containedRange = new Range("(7,15)");
            var result = baseRange.ContainsRange(containedRange);

            Assert.IsFalse(result);
        }

        [Test]
         public void _3_8_NotContainsRange__2_6_(){
            Range baseRange = new Range("(3,8)");
            Range containedRange = new Range("[4,6)");
            var result = baseRange.NotContainsRange(containedRange);

            Assert.IsFalse(result);
        }

         [Test]
         public void __2_9_NotContainsRange_3_8__(){
            Range baseRange = new Range("[2,9)");
            Range containedRange = new Range("(3,8]");
            var result = baseRange.NotContainsRange(containedRange);

            Assert.IsFalse(result);
        }

         [Test]
         public void __3_5_NotContainsRange__3_5__(){
            Range baseRange = new Range("[3,5)");
            Range containedRange = new Range("[3,5]");
            var result = baseRange.NotContainsRange(containedRange);

            Assert.IsTrue(result);
        }

         [Test]
         public void _3_10_NotContainsRange__7_15__(){
            Range baseRange = new Range("(3,10)");
            Range containedRange = new Range("(7,15)");
            var result = baseRange.NotContainsRange(containedRange);

            Assert.IsTrue(result);
        }

         [Test]
         public void _9_20_OverlapsRange__7_13_(){
            Range baseRange = new Range("(9,20)");
            Range overlapedRange = new Range("[7,13)");
            var result = baseRange.Overlaps(overlapedRange);

            Assert.IsTrue(result);
        }

         [Test]
         public void __3_6_OverlapsRange__2_5__(){
            Range baseRange = new Range("[3,26)");
            Range overlapedRange = new Range("[2,5]");
            var result = baseRange.Overlaps(overlapedRange);

            Assert.IsTrue(result);
        }

         [Test]
         public void __7_23_OverlapsRange__23_25__(){
            Range baseRange = new Range("[7,23)");
            Range overlapedRange = new Range("[23,25]");
            var result = baseRange.Overlaps(overlapedRange);

            Assert.IsFalse(result);
        }

        [Test]
         public void __8_12__OverlapsRange__2_6__(){
            Range baseRange = new Range("[8,12]");
            Range overlapedRange = new Range("[2,6]");
            var result = baseRange.Overlaps(overlapedRange);

            Assert.IsFalse(result);
        }

        [Test]
         public void _9_20_NotOverlapsRange__7_13_(){
            Range baseRange = new Range("(9,20)");
            Range overlapedRange = new Range("[7,13)");
            var result = baseRange.NotOverlaps(overlapedRange);

            Assert.IsFalse(result);
        }

         [Test]
         public void __3_6_NotOverlapsRange__2_5__(){
            Range baseRange = new Range("[3,26)");
            Range overlapedRange = new Range("[2,5]");
            var result = baseRange.NotOverlaps(overlapedRange);

            Assert.IsFalse(result);
        }

         [Test]
         public void __7_23_NotOverlapsRange__23_25__(){
            Range baseRange = new Range("[7,23)");
            Range overlapedRange = new Range("[23,25]");
            var result = baseRange.NotOverlaps(overlapedRange);

            Assert.IsTrue(result);
        }

        [Test]
         public void __8_12__NotOverlapsRange__2_6__(){
            Range baseRange = new Range("[8,12]");
            Range overlapedRange = new Range("[2,6]");
            var result = baseRange.NotOverlaps(overlapedRange);

            Assert.IsTrue(result);
        }

        [Test]
         public void _2_9_EndPoints__3_8__(){
            Range baseRange = new Range("(2,9)");
            var result = baseRange.EndPoints().ToArray();
            int[] a = {3,8};

            Assert.AreEqual(a,result);
        }

        [Test]
         public void __7_10__EndPoints__7_10__(){
            Range baseRange = new Range("[7,10]");
            var result = baseRange.EndPoints().ToArray();
            int[] a = {7,10};

            Assert.AreEqual(a,result);
        }

        [Test]
         public void _1_4__EndPoints__2_4__(){
            Range baseRange = new Range("(1,4]");
            var result = baseRange.EndPoints().ToArray();
            int[] a = {2,4};

            Assert.AreEqual(a,result);
        }

        [Test]
         public void __5_26_EndPoints__5_25__(){
            Range baseRange = new Range("[5,26");
            var result = baseRange.EndPoints().ToArray();
            int[] a = {5,25};

            Assert.AreEqual(a,result);
        }

        [Test]
         public void _2_6__Equals_2_7_(){
            Range baseRange = new Range("(2,6]");
            Range equalRange = new Range("(2,7)");
            var result = baseRange.Equals(equalRange);

            Assert.IsTrue(result);
        }

        [Test]
         public void __3_9_Equals_2_8__(){
            Range baseRange = new Range("[3,9)");
            Range equalRange = new Range("(2,8]");
            var result = baseRange.Equals(equalRange);

            Assert.IsTrue(result);
        }
        [Test]
         public void __5_7__Equals__5_7_(){
            Range baseRange = new Range("[5,7]");
            Range equalRange = new Range("[5,7)");
            var result = baseRange.Equals(equalRange);

            Assert.IsFalse(result);
        }

        [Test]
         public void _9_24_Equals__8_24__(){
            Range baseRange = new Range("(9,24)");
            Range equalRange = new Range("[8,24]");
            var result = baseRange.Equals(equalRange);

            Assert.IsFalse(result);
        }

         [Test]
         public void _2_6__NotEquals_2_7_(){
            Range baseRange = new Range("(2,6]");
            Range equalRange = new Range("(2,7)");
            var result = baseRange.NotEquals(equalRange);

            Assert.IsFalse(result);
        }

        [Test]
         public void __3_9_NotEquals_2_8__(){
            Range baseRange = new Range("[3,9)");
            Range equalRange = new Range("(2,8]");
            var result = baseRange.NotEquals(equalRange);

            Assert.IsFalse(result);
        }
        [Test]
         public void __5_7__NotEquals__5_7_(){
            Range baseRange = new Range("[5,7]");
            Range equalRange = new Range("[5,7)");
            var result = baseRange.NotEquals(equalRange);

            Assert.IsTrue(result);
        }

        [Test]
         public void _9_24_NotEquals__8_24__(){
            Range baseRange = new Range("(9,24)");
            Range equalRange = new Range("[8,24]");
            var result = baseRange.NotEquals(equalRange);

            Assert.IsTrue(result);
        }
        
    



    }



}