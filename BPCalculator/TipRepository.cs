using System.Collections.Generic;
namespace BPCalculator
{
  public static class TipRepository
  {
      // Define the dictionary
    public static readonly Dictionary<BPCategory, List<string>> Tips = new()
    {
      { BPCategory.High, new List<string>()
        {
          "Reduce sodium intake to lower blood pressure.",
          "Exercise regularly to strengthen your heart.",
          "Avoid stress and practice relaxation techniques."
        }
      },
      { BPCategory.PreHigh, new List<string>()
        {
          "Monitor your blood pressure regularly.",
          "Maintain a healthy weight and stay active.",
          "Eat more potassium-rich foods to balance sodium."
        }
      },
      { BPCategory.Low, new List<string>()
        {
          "Stay hydrated to prevent low blood pressure.",
          "Avoid standing up too quickly to prevent dizziness.",
          "Eat smaller, more frequent meals to maintain blood pressure."
        }
      },
      { BPCategory.Ideal, new List<string>()
        {
          "Continue maintaining a healthy lifestyle.",
          "Exercise regularly to keep your blood pressure in check.",
          "Eat a balanced diet rich in fruits and vegetables."
        }
      }
    };
  }
}
