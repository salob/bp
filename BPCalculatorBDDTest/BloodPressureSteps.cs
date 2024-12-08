using System;
using TechTalk.SpecFlow;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BPCalculator;
using System.ComponentModel.DataAnnotations;

[Binding]
public class BloodPressureSteps
{
    private int systolic;
    private int diastolic;
    private string category = "";

    [Given(@"I have entered (.*) as the systolic value")]
    public void GivenIHaveEnteredAsTheSystolicValue(int value)
    {
        systolic = value;
    }

    [Given(@"I have entered (.*) as the diastolic value")]
    public void GivenIHaveEnteredAsTheDiastolicValue(int value)
    {
        diastolic = value;
    }

    [When(@"I press Submit")]
    public void WhenIPressSubmit()
    {
        try
        {
            BloodPressure bp = new BloodPressure() { Systolic = systolic, Diastolic = diastolic };
            ValidateInstance(bp);
            category = bp.Category.ToString();
        }
        catch (ValidationException)
        {
            category = "Invalid";
        }
    }

    [Then(@"the result should be ""(.*)""")]
    public void ThenTheResultShouldBe(string expectedCategory)
    {
        Assert.AreEqual(expectedCategory, category);
    }

    
    private static void ValidateInstance(BloodPressure bloodPressure)
    {
        ValidationContext context = new ValidationContext(bloodPressure);
        Validator.ValidateObject(bloodPressure, context, true);
    }
}
