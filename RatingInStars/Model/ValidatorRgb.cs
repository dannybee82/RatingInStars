using System.ComponentModel.DataAnnotations;

namespace RatingInStars.Model
{
	public class ValidatorRgb : ValidationAttribute
	{
	
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
		{
			string s = value.ToString();

			if(!string.IsNullOrEmpty(s))
			{
				string[] tempSplitted = s.Split(",");

				int validNumbers = 0;

				for(int i = 0; i < tempSplitted.Length; i++)
				{
					int parsed = 0;
					bool isParsed = Int32.TryParse(tempSplitted[i], out parsed);

					if(isParsed)
					{
						if(parsed >= 0 && parsed <= 255)
						{
							validNumbers++;
                        }
					}
				}

				if(validNumbers < 3)
				{
                    return new ValidationResult("Invalid RGB", new[] { validationContext.MemberName });
                }
			}
			else
			{
                return new ValidationResult($"Invalid RGB", new[] { validationContext.MemberName });
            }

			return null;
		}

    }
}
