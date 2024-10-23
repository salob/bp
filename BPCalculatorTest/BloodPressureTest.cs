namespace BPCalculatorTest;
using BPCalculator;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.ComponentModel.DataAnnotations;
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
  
  [DataTestMethod]
  [DataRow("High")]
  [DataRow("PreHigh")]
  [DataRow("Ideal")]
  [DataRow("Low")]
  public void TestValidTip(string catString)
  {
    //just need this instance in order to call non static methods
    BloodPressure bp = new BloodPressure();
    List<string> tipsForCategory = bp.GetTips(catString);
    string tip = bp.GetRandomTip(catString);
    /** Debug print statements
    Console.WriteLine(tip);
    Console.Write(String.Join("\n",tipsForCategory));
    **/
    bool isCorrectTip = tipsForCategory.Contains(tip);
    Assert.AreEqual(isCorrectTip,true);
  }

  [TestMethod]
  [ExpectedException(typeof(ValidationException))]
  public void TestDiastolic_AboveMax()
  {
    BloodPressure bp = new BloodPressure();
    bp.Diastolic = 101; // invalid
    bp.Systolic = 120; // valid
    ValidateInstance(bp);
  }

  [TestMethod]
  [ExpectedException(typeof(ValidationException))]
  public void TestDiastolic_BelowMin()
  {
    BloodPressure bp = new BloodPressure();
    bp.Diastolic = 39; // invalid
    bp.Systolic = 120; // valid
    ValidateInstance(bp);
  }

  [TestMethod]
  [ExpectedException(typeof(ValidationException))]
  public void TestSystolic_AboveMax()
  {
    BloodPressure bp = new BloodPressure();
    bp.Diastolic = 80; // valid
    bp.Systolic = 191; // invalid
    ValidateInstance(bp);
  }

  [TestMethod]
  [ExpectedException(typeof(ValidationException))]
  public void TestSystolic_BelowMin()
  {
    BloodPressure bp = new BloodPressure();
    bp.Diastolic = 80; // valid
    bp.Systolic = 69; // invalid
    ValidateInstance(bp);
  }
  private void ValidateInstance(BloodPressure bloodPressure)
  {
    ValidationContext context = new ValidationContext(bloodPressure);
    Validator.ValidateObject(bloodPressure, context, true);
  }

}

