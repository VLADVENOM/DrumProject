using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DrumBuilder;

namespace DrumProjectTest
{
    [TestClass]
    public class DrumBuilderTest
    {
        [TestMethod]
        public void TestKadloDiameterProperty()
        {
            DrumDescription drumPropertie = new DrumDescription();
            double expected = 12;
            drumPropertie.KadloDiameter = expected;

            double actual = drumPropertie.KadloDiameter;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestKadloHeight()
        {
            DrumDescription drumPropertie = new DrumDescription();
            double expected = 15;
            drumPropertie.KadloHeight = expected;

            double actual = drumPropertie.KadloHeight;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestKadloThickness()
        {
            DrumDescription drumPropertie = new DrumDescription();
            double expected = 10;
            drumPropertie.KadloThickness = expected;

            double actual = drumPropertie.KadloThickness;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestRimWidth()
        {
            DrumDescription drumPropertie = new DrumDescription();
            double expected = 15;
            drumPropertie.RimWidth = expected;

            double actual = drumPropertie.RimWidth;

            Assert.AreEqual(expected, actual);
        }

            [TestMethod]
        public void TestRimHeight()
        {
            DrumDescription drumPropertie = new DrumDescription();
            double expected = 15;
            drumPropertie.RimHeight = expected;

            double actual = drumPropertie.RimHeight;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
            public void TestThicknessBottomDrumhead()
        {
            DrumDescription drumPropertie = new DrumDescription();
            double expected = 1;
            drumPropertie.ThicknessBottomDrumhead = expected;

            double actual = drumPropertie.ThicknessBottomDrumhead;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestThicknessTopDrumhead()
        {
            DrumDescription drumPropertie = new DrumDescription();
            double expected = 2;
            drumPropertie.ThicknessTopDrumhead = expected;

            double actual = drumPropertie.ThicknessTopDrumhead;

            Assert.AreEqual(expected, actual);
        }



        [TestMethod]
        public void TestNumberMounting()
        {
            DrumDescription drumPropertie = new DrumDescription();
            int expected = 10;
            drumPropertie.NumberMounting = expected;

            int actual = drumPropertie.NumberMounting;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestDiametrHole()
        {
            DrumDescription drumPropertie = new DrumDescription();
            double expected = 2.5;
            drumPropertie.DiametrHole = expected;

            double actual = drumPropertie.DiametrHole;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestSquareSide()
        {
            DrumDescription drumPropertie = new DrumDescription();
            double expected = 15;
            drumPropertie.SquareSide = expected;

            double actual = drumPropertie.SquareSide;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestStringSnare()
        {
            DrumDescription drumPropertie = new DrumDescription();
            int expected = 8;
            drumPropertie.StringSnare = expected;

            int actual = drumPropertie.StringSnare;

            Assert.AreEqual(expected, actual);
        }
    }
}
