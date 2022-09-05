namespace RatingInStars.Model
{
	public class LoadedImage
	{

		public string ImageFileName { get; set; } = string.Empty;

        public string ImageAsPngData { get; set; } = string.Empty;

        public string ErrorMessage { get; set; } = string.Empty;

        public bool IsLoaded { get; set; }

	}
}
