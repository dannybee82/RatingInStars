
using Microsoft.AspNetCore.Components.Forms;
using RatingInStars.Model;

namespace RatingInStars.ApplicationMethods
{
    public class LoadImageFile
    {

        private HelperMethods helperMethods = new();

        public async Task<LoadedImage> GetImageAsDataString(InputFileChangeEventArgs e)
        {
            LoadedImage li = new();

            try
            {                
                foreach (var file in e.GetMultipleFiles(1))
                {
                    MemoryStream ms = new MemoryStream();
                    await file.OpenReadStream().CopyToAsync(ms);
                    byte[] buffer = ms.ToArray();

                    string firstBytes = helperMethods.ReadFirstBytes(buffer);

                    if (!firstBytes.Equals("PNG"))
                    {
                        li.IsLoaded = false;
                        li.ImageFileName = "";
                        li.ErrorMessage = "Invalid PNG File.";
                        li.ImageAsPngData = "";
                    }
                    else
                    {
                        li.IsLoaded = true;
                        li.ImageFileName = file.Name;
                        li.ErrorMessage = "";
                        li.ImageAsPngData = helperMethods.ConvertToPngDataString(buffer);
                    }
                }
            } catch {
                li.IsLoaded = false;
                li.ImageFileName = "";
                li.ErrorMessage = "Can\'t load png file.";
                li.ImageAsPngData = "";
            }

            return li;
        }

    }
}
