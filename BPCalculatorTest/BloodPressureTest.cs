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
  
  [TestMethod]
  [ExpectedException(typeof(ValidationException))]
  public void Diastolic_AboveMax()
  {
      var bp = new BloodPressure();
      bp.Diastolic = 101; // invalid
      bp.Systolic = 120; // valid
      ValidateInstance(bp);
  }

  [TestMethod]
  [ExpectedException(typeof(ValidationException))]
  public void Diastolic_BelowMin()
  {
      var bp = new BloodPressure();
      bp.Diastolic = 39; // invalid
      bp.Systolic = 120; // valid
      ValidateInstance(bp);
  }

  [TestMethod]
  [ExpectedException(typeof(ValidationException))]
  public void Systolic_AboveMax()
  {
      var bp = new BloodPressure();
      bp.Diastolic = 80; // valid
      bp.Systolic = 191; // invalid
      ValidateInstance(bp);
  }

  [TestMethod]
  [ExpectedException(typeof(ValidationException))]
  public void Systolic_BelowMin()
  {
      var bp = new BloodPressure();
      bp.Diastolic = 80; // valid
      bp.Systolic = 69; // invalid
      ValidateInstance(bp);
  }
  private void ValidateInstance(BloodPressure bloodPressure)
  {
      var context = new ValidationContext(bloodPressure);
      Validator.ValidateObject(bloodPressure, context, true);
  }

}

