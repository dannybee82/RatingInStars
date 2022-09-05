namespace RatingInStars.ApplicationMethods
{
	public class HelperMethods
	{
        public int[] GetSizes(int start, int end)
        {
            List<int> sizes = new();

            for (int i = start; i <= end; i++)
            {
                sizes.Add(i);
            }

            return sizes.ToArray();
        }


        public string CreateLabel(int value)
        {
            return value + " px";
        }

        public int[] stringToIntArray(string s)
        {
            string[] tempSplitted = s.Split(",");

            int[] arr = new int[tempSplitted.Length];

            for (int i = 0; i < tempSplitted.Length; i++)
            {
                arr[i] = Convert.ToInt32(tempSplitted[i]);
            }

            return arr;
        }

        public bool AreIntArraysEqual(int[] arr1, int[] arr2)
        {
            if (arr1.Length != arr2.Length)
            {
                return false;
            }

            for (int i = 0; i < arr1.Length; i++)
            {
                if (arr1[i] != arr2[i])
                {
                    return false;
                }
            }

            return true;
        }

        public string ConvertToPngDataString(byte[] arr)
        {
            return $"data:image/png;base64,{Convert.ToBase64String(arr)}";
        }

        public bool AreValuesValid(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return false;
            }

            string[] tempSplitted = s.Split(",");

            if (tempSplitted.Length == 3)
            {
                int validNumbers = 0;

                for (int i = 0; i < tempSplitted.Length; i++)
                {
                    int parsed = 0;
                    bool isParsed = Int32.TryParse(tempSplitted[i], out parsed);

                    if (isParsed)
                    {
                        if (parsed >= 0 && parsed <= 255)
                        {
                            validNumbers++;
                        }
                    }
                }

                if (validNumbers == 3)
                {
                    return true;
                }
            }

            return false;
        }

        public string getHexString(string s)
        {
            string hex = "#";

            string[] tempSplitted = s.Split(",");

            for (int i = 0; i < tempSplitted.Length; i++)
            {
                int parsed = Convert.ToInt32(tempSplitted[i]);
                string currentHex = parsed.ToString("X");

                if (currentHex.Length == 1)
                {
                    hex += "0" + currentHex;
                }
                else
                {
                    hex += currentHex;
                }


            }

            return hex;
        }
        
        public string ConvertHexToIntegers(string hex)
        {
            string rgb = "";

            for (int i = 1; i < hex.Length; i += 2)
            {
                int value = Convert.ToInt32("0x" + hex[i] + hex[i + 1], 16);
                rgb += value;

                if (i < hex.Length - 2)
                {
                    rgb += ",";
                }
            }

            return rgb;
        }

        public string ReadFirstBytes(byte[] arr)
        {
            string s = "";

            for (int i = 1; i < 4; i++)
            {
                s += (char) arr[i];
            }

            return s;
        }

        public bool HasAllOrNoneContent(string[] arr)
        {
            int content = 0;
            int noContent = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                if (string.IsNullOrEmpty(arr[i]))
                {
                    noContent++;
                }
                else
                {
                    content++;
                }
            }

            if(content == arr.Length && noContent == 0)
            {
                return true;
            }

            if(noContent == arr.Length && content == 0)
            {
                return true;
            }

            return false;
        }

        public bool HasAllContent(string[] arr)
        {
            for (int i = 0; i < arr.Length; i++) 
            {
                if (string.IsNullOrEmpty(arr[i]))
                {
                    return false;
                }
            }

            return true;
        }
        public string JoinStrings(string s, string[] arr)
        {
            return string.Join(s, arr);
        }

        public string PreparePngImagesAsString(string[] arr)
        {
            string connnected = "";

            for (int i = 0; i < arr.Length; i++)
            {
                connnected += "\"" + arr[i] + "\"";

                if (i < arr.Length - 1)
                {
                    connnected += ",";
                    connnected += "\n";
                }
            }

            return connnected;
        }

        public string FormatDoubleValues(double d)
        {
            string s = d + "";

            if(s.IndexOf(",") == -1)
            {
                return s + ".0";
            }

            return s.Replace(",", ".");
        }

    }
}
