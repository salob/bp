namespace BPCalculatorTest;
using BPCalculator;

[TestClass]
public class BloodPressureTest
{
  [DataTestMethod]
  [DataRow(140, 90, BPCategory.High)]
  [DataRow(130, 55, BPCategory.PreHigh)]
  [DataRow(100, 79, BPCategory.Ideal)]
  [DataRow(89, 59, BPCategory.Low)]
  public void TestValidData(int sc, int ds, BPCategory cat)
  {
    BloodPressure bp = new BloodPressure() { Systolic = sc, Diastolic = ds };
    Assert.AreEqual(bp.Category.Item1, cat);
  }
/** Work in Progress
  [TestMethod]
  public void TestExceptions()
  {
    BloodPressure bp = new BloodPressure();
    bp.Systolic = 59;
    bp.Diastolic = 55;
    Console.WriteLine(bp.Category.Item1);
    Assert.AreEqual(bp.Category.Item1,BPCategory.High);
  }
**/
}

