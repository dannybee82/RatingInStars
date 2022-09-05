using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace RatingInStars.ImageMethods
{
    public class ImageMethods
    {
        private HashSet<Color> keepColors = new();

        public byte[] ReplaceColor(string image, int[] originalColor, int[] replace)
        {
            Bitmap modifyThis = new Bitmap(image);

            Color backGroundColor = modifyThis.GetPixel(0, 0);

            //Pixel for pixel
            for (int i = 0; i < modifyThis.Width; i++)
            {
                for (int j = 0; j < modifyThis.Height; j++)
                {
                    Color c = modifyThis.GetPixel(i, j);

                    if (c != backGroundColor)
                    {
                        Color adapted = GetAdaptedColor(c, originalColor, replace);
                        modifyThis.SetPixel(i, j, adapted);
                    }
                }
            }

            byte[] data;

            using (var memoryStream = new MemoryStream())
            {
                modifyThis.Save(memoryStream, ImageFormat.Png);

                data = memoryStream.ToArray();
            }

            return data;
        }

        public byte[] ReplaceColor(string image, int xAxisMiddle, int[] originalBeforeMiddle, int[] replaceBeforeMiddle, int[] originalAfterMiddle, int[] replaceAfterMiddle)
        {
            Bitmap modifyThis = new Bitmap(image);

            Color backGroundColor = modifyThis.GetPixel(0, 0);
            //Color beforeMiddle = Color.FromArgb(255, replaceBeforeMiddle[0], replaceBeforeMiddle[1], replaceBeforeMiddle[2]);
            //Color afterMiddle = Color.FromArgb(255, replaceAfterMiddle[0], replaceAfterMiddle[1], replaceAfterMiddle[2]);

            //Pixel for pixel
            
            for (int i = 0; i < modifyThis.Width; i++)
            {
                for (int j = 0; j < modifyThis.Height; j++)
                {                                
                    Color c = modifyThis.GetPixel(i, j);

                    if (c != backGroundColor)
                    {
                        if(i <= xAxisMiddle)
                        {
                            Color adapted = GetAdaptedColor(c, originalBeforeMiddle, replaceBeforeMiddle);
                            modifyThis.SetPixel(i, j, adapted);
                        }
                        else
                        {
                            Color adapted = GetAdaptedColor(c, originalAfterMiddle, replaceAfterMiddle);
                            modifyThis.SetPixel(i, j, adapted);
                        }
                    }
                }
            }

            byte[] data;

            using (var memoryStream = new MemoryStream())
            {
                modifyThis.Save(memoryStream, ImageFormat.Png);

                data = memoryStream.ToArray();
            }

            return data;
        }


        public byte[] ChangeColor(string image, int[] arr1, int[] arr2)
        {
            Color c01 = Color.FromArgb(0, arr1[0], arr1[1], arr1[2]);
            Color c02 = Color.FromArgb(0, arr2[0], arr2[1], arr2[2]);

            Bitmap original = new Bitmap(image);

            //Pixel for pixel...
            Color backColor = original.GetPixel(0, 0);

            for (int i = 0; i < original.Width; i++)
            {
                for (int j = 0; j < original.Height; j++)
                {
                    Color c = original.GetPixel(i, j);

                    if(c != backColor)
                    {
                        Color adapted = GetAdaptedColor(c, arr1, arr2);
                        original.SetPixel(i, j, adapted);
                    }
                }
            }

            byte[] data;

            using (var memoryStream = new MemoryStream())
            {
                original.Save(memoryStream, ImageFormat.Png);

                data = memoryStream.ToArray();
            }

            return data;
        }

        public byte[] ChangeColor(string image, int[] arr1, int[] arr2, int keepColorFromXAxis)
        {
            Color c01 = Color.FromArgb(0, arr1[0], arr1[1], arr1[2]);
            Color c02 = Color.FromArgb(0, arr2[0], arr2[1], arr2[2]);
            
            Bitmap original = new Bitmap(image);

            //Pixel for pixel...
            Color backColor = original.GetPixel(0, 0);

            //Get colors to keep.
            for (int i = keepColorFromXAxis; i < original.Width; i++)
            {
                for (int j = 0; j < original.Height; j++)
                {
                    Color c = original.GetPixel(i, j);

                    if (c != backColor)
                    {
                        keepColors.Add(c);
                    }
                }
            }

            for (int i = 0; i < original.Width; i++)
            {
                for (int j = 0; j < original.Height; j++)
                {
                    Color c = original.GetPixel(i, j);

                    if (c != backColor && !keepColors.Contains(c))
                    {
                        Color adapted = GetAdaptedColor(c, arr1, arr2);
                        original.SetPixel(i, j, adapted);
                    }
                }
            }

            keepColors.Clear();

            byte[] data;

            using (var memoryStream = new MemoryStream())
            {
                original.Save(memoryStream, ImageFormat.Png);

                data = memoryStream.ToArray();
            }

            return data;
        }

        private Color GetAdaptedColor(Color c, int[] arr1, int[] arr2)
        {
            byte currentAlpha = c.A;
            byte currentRed = SubtractColors(c.R, arr1[0], arr2[0]);
            byte currentGreen = SubtractColors(c.G, arr1[1], arr2[1]);
            byte currentBlue = SubtractColors(c.B, arr1[2], arr2[2]);

            return Color.FromArgb(currentAlpha, currentRed, currentGreen, currentBlue);
        }

        private byte SubtractColors(int currentColor, int originalColor, int targetColor)
        {

            int difference = originalColor - currentColor;

                if (difference < 0)
                {
                    targetColor -= difference;
                }
                else
                {
                    targetColor += difference;
                }

                if (targetColor < 0)
                {
                    targetColor = 0;
                }

                if (targetColor > 255)
                {
                    targetColor = 255;
                }
            

            return (byte) targetColor;
        }
        
    }
}