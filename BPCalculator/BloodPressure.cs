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
        public BPCategory Category
        {
            get
            {
                // Additional validation to Range for Tests

                if (Systolic < SystolicMin || Systolic > SystolicMax || 
                    Diastolic < DiastolicMin || Diastolic > DiastolicMax ||
                    Systolic <= Diastolic)
                {
                    throw new ValidationException("Invalid Blood Pressure Values");
                }

                BPCategory category;
                if(this.Systolic < 90 && this.Diastolic < 60){
                  category = BPCategory.Low;
                }
                else if(this.Systolic < 120 && this.Diastolic < 80){
                  category = BPCategory.Ideal;
                }
                else if(this.Systolic < 140 && this.Diastolic < 90){
                  category = BPCategory.PreHigh;
                }
                else{
                  category = BPCategory.High;
                }
                return category;
            }
        }      
        // Sian's feature: Method to pick random useful tip
        private string tip;
        public string Tip{
          get
          {
            Random random = new Random();
            int randomIndex = random.Next(TipRepository.Tips[this.Category].Count);
            tip = TipRepository.Tips[this.Category][randomIndex];
            return tip;
          }
        }
    }
}
