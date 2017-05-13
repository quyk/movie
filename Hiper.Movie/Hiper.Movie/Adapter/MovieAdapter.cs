using System.Collections.Generic;
using Android.App;
using Android.Graphics;
using Android.Views;
using Android.Widget;
using Hiper.Movie.Model;
using Hiper.Movie.Util;

namespace Hiper.Movie.Adapter
{
    public class MovieAdapter : BaseAdapter<Movies>
    {
        readonly Activity _context;
        private readonly IList<Movies> _list;

        public MovieAdapter(Activity context, IList<Movies> list)
        {
            _context = context;
            _list = list;
        }

        public override long GetItemId(int position) => position;

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView ?? _context.LayoutInflater.Inflate(Resource.Layout.MovieList, parent, false);

            var movie = this[position];
            var movieYear = movie.Year.Replace("–", "");

            var title = view.FindViewById<TextView>(Resource.Id.txvTitle);
            title.Text = movie.Title;

            var year = view.FindViewById<TextView>(Resource.Id.txvYear);
            year.Text = movieYear;
            if (("2017").Equals(movieYear))
            {
                year.SetTextColor(Color.Red);
                title.SetTextColor(Color.Red);
            }

            var poster = view.FindViewById<ImageView>(Resource.Id.imgPoster);
            if (!("N/A").Equals(movie.Poster))
            {
                var image = ImageUtil.GetBitmapFromUrl(movie.Poster);
                poster.SetImageBitmap(image);
            }
            return view;
        }

        public override int Count => _list.Count;

        public override Movies this[int position] => _list[position];
    }
}