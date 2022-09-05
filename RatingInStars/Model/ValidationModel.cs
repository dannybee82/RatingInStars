using Microsoft.AspNetCore.Components;
using System.ComponentModel.DataAnnotations;

namespace RatingInStars.Model
{
    public class ValidationModel
    {

        [Required, RegularExpression(@"\d{1,3}\s{0,}\,\s{0,}\d{1,3}\s{0,}\,\s{0,}\d{1,3}\s{0,}"), ValidatorRgb()]
        public string PrimaryColorRgb { get; set; }

        [Required, RegularExpression(@"\d{1,3}\s{0,}\,\s{0,}\d{1,3}\s{0,}\,\s{0,}\d{1,3}\s{0,}"), ValidatorRgb()]
        public string SecondaryColorRgb { get; set; }

        [Required, RegularExpression(@"\d{1,3}\s{0,}\,\s{0,}\d{1,3}\s{0,}\,\s{0,}\d{1,3}\s{0,}"), ValidatorRgb()]
        public string BackgroundColorRgb { get; set; }

        [Required, Range(typeof(double), "0,0", "5,0", ErrorMessage = "Star Rating out of Range.")]
        public double CurrentStarRating { get; set; }

        [Required]
        public int StarSize { get; set; }

        [Required, Range(typeof(int), "0", "100", ErrorMessage = "Value below 0 or above 100.")]
        public int MarginLeft { get; set; } = 15;

        [Required, Range(typeof(int), "0", "100", ErrorMessage = "Value below 0 or above 100.")]
        public int MarginRight { get; set; } = 15;

        [Required]
        public bool AllowChanges { get; set; } = true;

        [Required, Range(typeof(int), "0", "2", ErrorMessage = "Type out of Range")]
        public int UseType { get; set; }
        //public int UseType
        //{
        //    get { return useTypeLastValue; }
        //    set
        //    {
        //        if (value != useTypeLastValue)
        //        {
        //            useTypeLastValue = value;

        //            if (useTypeLastValue == 0)
        //            {
        //                SecondaryColorRgb = "0, 0, 0";
        //            }

        //            if (useTypeLastValue == 1)
        //            {
        //                SecondaryColorRgb = "169, 169, 169";
        //            }
        //        }
        //    }
        //}

        //public int useTypeLastValue = -1;
    }  

}
