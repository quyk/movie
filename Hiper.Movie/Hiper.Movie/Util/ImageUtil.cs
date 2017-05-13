using System.Net;
using Android.Graphics;

namespace Hiper.Movie.Util
{
    public class ImageUtil
    {
        public static Bitmap GetBitmapFromUrl(string url)
        {
            using (var webClient = new WebClient())
            {
                var bytes = webClient.DownloadData(url);
                if (bytes != null && bytes.Length > 0)
                {
                    return BitmapFactory.DecodeByteArray(bytes, 0, bytes.Length);
                }
            }
            return null;
        }
    }
}