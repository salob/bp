namespace BPCalculatorTest;
using BPCalculator;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.ComponentModel.DataAnnotations;
[TestClass]
public class BloodPressureTest
{
  [DataTestMethod]

  // Initial tests
  [DataRow(140, 90, BPCategory.High)]
  [DataRow(130, 55, BPCategory.PreHigh)]
  [DataRow(100, 79, BPCategory.Ideal)]
  [DataRow(89, 59, BPCategory.Low)]

  // Low Blood Pressure (Systolic < 90, Diastolic < 60)
  [DataRow(71, 40, BPCategory.Low)]
  [DataRow(80, 50, BPCategory.Low)]
  [DataRow(89, 59, BPCategory.Low)]

  // Ideal Blood Pressure (90 ≤ Systolic < 120, 60 ≤ Diastolic < 80)
  [DataRow(90, 60, BPCategory.Ideal)]
  [DataRow(95, 65, BPCategory.Ideal)]
  [DataRow(100, 70, BPCategory.Ideal)]
  [DataRow(110, 75, BPCategory.Ideal)]
  [DataRow(119, 79, BPCategory.Ideal)]

  // Pre-High Blood Pressure (120 ≤ Systolic < 140, 60 ≤ Diastolic < 90)
  [DataRow(120, 60, BPCategory.PreHigh)]
  [DataRow(130, 70, BPCategory.PreHigh)]
  [DataRow(135, 80, BPCategory.PreHigh)]
  [DataRow(139, 89, BPCategory.PreHigh)]

  // High Blood Pressure (Systolic ≥ 140, Diastolic ≥ 90)
  [DataRow(140, 90, BPCategory.High)]
  [DataRow(150, 95, BPCategory.High)]
  [DataRow(160, 100, BPCategory.High)]
  [DataRow(190, 100, BPCategory.High)]
 
  public void TestValidData(int sc, int ds, BPCategory cat)
  {
    BloodPressure bp = new BloodPressure() { Systolic = sc, Diastolic = ds };
    Assert.AreEqual(bp.Category, cat);
  }
  
  [DataTestMethod]
  [DataRow(70, 59, BPCategory.High)]
  [DataRow(150, 90, BPCategory.High)]
  [DataRow(120, 80, BPCategory.PreHigh)]
  [DataRow(119, 79, BPCategory.Ideal)]
  [DataRow(80, 40, BPCategory.Low)]

  public void TestValidTip(int sc, int ds, BPCategory cat)
  {
    BloodPressure bp = new BloodPressure() { Systolic = sc, Diastolic = ds };
    List<string> tipsForCategory = TipRepository.Tips[cat];
    string tip = bp.Tip;
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

