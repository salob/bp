using System;
using System.ComponentModel.DataAnnotations;
//using System.Diagnostics;
using System.Collections.Generic;

namespace BPCalculator
{
    // BP categories
    public enum BPCategory
    {
        [Display(Name="Low Blood Pressure")] Low,
        [Display(Name="Ideal Blood Pressure")]  Ideal,
        [Display(Name="Pre-High Blood Pressure")] PreHigh,
        [Display(Name ="High Blood Pressure")]  High
    };
    public class BloodPressure
    {
        public const int SystolicMin = 70;
        public const int SystolicMax = 190;
        public const int DiastolicMin = 40;
        public const int DiastolicMax = 100;

        [Range(SystolicMin, SystolicMax, ErrorMessage = "Invalid Systolic Value")]
        public int Systolic { get; set; }                       // mmHG

        [Range(DiastolicMin, DiastolicMax, ErrorMessage = "Invalid Diastolic Value")]
        public int Diastolic { get; set; }                      // mmHG

        // calculate BP category
        public (BPCategory,string) Category
        {
            get
            {
                if(this.Systolic < 90 && this.Diastolic < 60){
                  return (BPCategory.Low,"Tip: " + GetRandomTip("Low"));
                }
                if(this.Systolic < 120 && this.Diastolic < 80){
                  return (BPCategory.Ideal,"Tip: " + GetRandomTip("Ideal"));
                }
                 if(this.Systolic < 140 && this.Diastolic < 90){
                  return (BPCategory.PreHigh,"Tip: " + GetRandomTip("PreHigh"));
                }
                return (BPCategory.High,"Tip: " + GetRandomTip("High"));
            }
        }

        // Sian's feature: Method to pick random useful tip, calls GetTips
        public string GetRandomTip(string category)
        {
          Random random = new Random();
          List<string> tipsForCategory = GetTips(category);
          int randomIndex = random.Next(tipsForCategory.Count); 
          return tipsForCategory[randomIndex];
        }
        // Sian's feature: Method to return list of tips for given category
        public List<string> GetTips(string category)
        {
            // Define the dictionary for blood pressure tips
          Dictionary<string, List<string>> bloodPressureTips = new Dictionary<string, List<string>>()
          {
            { "High", new List<string>()
              {
                "Reduce sodium intake to lower blood pressure.",
                "Exercise regularly to strengthen your heart.",
                "Avoid stress and practice relaxation techniques."
              }
            },
            { "PreHigh", new List<string>()
              {
                "Monitor your blood pressure regularly.",
                "Maintain a healthy weight and stay active.",
                "Eat more potassium-rich foods to balance sodium."
              }
            },
            { "Low", new List<string>()
              {
                "Stay hydrated to prevent low blood pressure.",
                "Avoid standing up too quickly to prevent dizziness.",
                "Eat smaller, more frequent meals to maintain blood pressure."
              }
            },
            { "Ideal", new List<string>()
              {
                "Continue maintaining a healthy lifestyle.",
                "Exercise regularly to keep your blood pressure in check.",
                "Eat a balanced diet rich in fruits and vegetables."
              }
            }
          };
          return bloodPressureTips[category];
      }
    }
}
