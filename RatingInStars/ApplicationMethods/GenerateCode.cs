using RatingInStars.Model;

namespace RatingInStars.ApplicationMethods
{
	public class GenerateCode
	{

        private HelperMethods helperMethods = new();

        public string GetStartTagRazorComponent()
        {
            return "<StarsRating";
        }

        public string GetAllowedChanges(bool allowChanges)
        {
            return " AllowChanges=" + allowChanges.ToString().ToLower();
        }

        public string GetCurrentRatingInStars(ValidationModel validationModel)
        {
            if (validationModel.AllowChanges)
            {
                return " CurrentRatingInStars=@currentRatingInStars";
            }
            else
            {
                return " CurrentRatingInStars=" + helperMethods.FormatDoubleValues(validationModel.CurrentStarRating);
            }
        }

        public string GetPropertyAndValue(string property, int value)
        {
            return " " + property + "=" + value;
        }

        public string GetBackgroundColor(string backgroundColor)
        {
            if (!backgroundColor.ToLower().Equals("#fff") && !backgroundColor.ToLower().Equals("#ffffff"))
            {
                return " BackgroundColor=" + backgroundColor;
            }

            return "";
        }

        public string GetCustomImagesToUse(bool isUsingModifiedImages) 
        {
            if (isUsingModifiedImages)
            {
                return " CustomStarImagesToUse=@pngImagesArray";
            }

            return "";
        }


        public string GetCallbackMethod(ValidationModel validationModel)
        {
            if (validationModel.AllowChanges)
            {
                return " CallBackMethod=@ShowSelectedStars";
            }

            return "";
        }

        public string GetEndTagRazorComponent()
        {
            return " />";
        }

        public string AddLineBreak()
        {
            return "\n";
        }

        public string GetStartCodeTag()
        {
            return "@code{\n";
        }

        public string GetCodeCurrentRatingInStars(ValidationModel validationModel)
        {
            if (validationModel.AllowChanges)
            {
               return "private double currentRatingInStars = " + helperMethods.FormatDoubleValues(validationModel.CurrentStarRating) + ";\n\n";
            }

            return "";
        }

        public string GetImagesPath(int starTypeToUse, bool isUsingModifiedImages, bool isUsingUploadedImages, string fileNameEmptyImage, string fileNameFilledImage, string fileNameHalfImage)
        {
            if (isUsingModifiedImages)
            {
                if (starTypeToUse == 2 && isUsingUploadedImages)
                {
                    if (!string.IsNullOrEmpty(fileNameEmptyImage) && !string.IsNullOrEmpty(fileNameFilledImage) && !string.IsNullOrEmpty(fileNameHalfImage))
                    {
                        return "string[] pngImagesArray = new string[]{" + "\"../images/" + fileNameEmptyImage + "\", "
                                                                                + "\"../images/" + fileNameFilledImage + "\", "
                                                                                + "\"../images/" + fileNameHalfImage + "\""
                                                                                + "};\n\n";
                    }
                    else
                    {
                        return "//IMAGES PATHS ARE PROBABLY INCOMPLETE.\n\n";
                    }                    
                }
                else
                {
                    return "string[] pngImagesArray = new string[]{" + "\"../images/custom_empty.png\","
                                                                                + "\"../images/custom_filled.png\","
                                                                                + "\"../images/custom_half.png\""
                                                                                + "};\n\n";
                }
            }

            return "//Using default png images with default colors.\n\n";
        }

        public string GetImagesAsBas64String(int starTypeToUse, bool isUsingModifiedImages, bool isUsingUploadedImages, string[] pngImages)
        {
            if (isUsingModifiedImages)
            {
                if (starTypeToUse == 2 && isUsingUploadedImages)
                {
                    //Use Base64-string.
                    if (helperMethods.HasAllContent(pngImages))
                    {
                        string connnected = helperMethods.PreparePngImagesAsString(pngImages);
                        return "string[] pngImagesArray = new string[]{" + connnected + "};\n\n";
                    }
                    else
                    {
                        return "//THE GENERATED IMAGES ARE INCOMPLETE!\n\n";
                    }
                }
                else
                {
                    string connnected = helperMethods.PreparePngImagesAsString(pngImages);
                    return "string[] pngImagesArray = new string[]{" + connnected + "};\n\n";
                }
            }

            return "//Using default png images with default colors.\n\n";
        }

        public bool DetermineToSavePngImages(int starTypeToUse,  bool isUsingModifiedImages,  bool isUsingUploadedImages, bool usePngImageForCode)
        {
            if (isUsingModifiedImages)
            {
                if (starTypeToUse == 2 && isUsingUploadedImages)
                {
                    return false;
                }
                else
                {
                    if(usePngImageForCode)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }

            return false;
        }

        public string GetCallBackMethod(ValidationModel validationModel)
        {
            if (validationModel.AllowChanges)
            {
                string s = "";
                s += "private void ShowSelectedStars(double selected)\n";
                s += "{\n";
                s += "//Do here whatever you want.\n";
                s += "currentRatingInStars = selected;\n";
                s += "}\n";

                return s;
            }

            return "";
        }

        public string GetEndCodeTag()
        {
            return "}";
        }

	}
}