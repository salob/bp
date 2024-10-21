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
                  return (BPCategory.Low,"Tip: " + GetTip("Low"));
                }
                if(this.Systolic < 120 && this.Diastolic < 80){
                  return (BPCategory.Ideal,"Tip: " + GetTip("Ideal"));
                }
                 if(this.Systolic < 140 && this.Diastolic < 90){
                  return (BPCategory.PreHigh,"Tip: " + GetTip("PreHigh"));
                }
                return (BPCategory.High,"Tip: " + GetTip("High"));
            }
        }

        // Sian's feature to generate useful tip based on category

        static string GetTip(string category)
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

            // Create a Random object for selecting random tips
            Random random = new Random();

            // Check if the category exists in the dictionary
            if (bloodPressureTips.ContainsKey(category))
            {
                List<string> tipsForCategory = bloodPressureTips[category];
                int randomIndex = random.Next(tipsForCategory.Count);  // Pick a random index from the list
                return tipsForCategory[randomIndex];  // Return the randomly selected tip
            }
            else
            {
                return "No tips available for this category.";
            }
        }
    }
}
