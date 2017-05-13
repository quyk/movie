using System.Collections.Generic;
using System.Threading.Tasks;
using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;
using Hiper.Movie.Adapter;
using Hiper.Movie.Model;
using Hiper.Movie.Services;

namespace Hiper.Movie
{
    [Activity(Label = "Hiper Movie", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        private EditText _txtTitle;
        private ListView _lvwMovies;
        private IList<Movies> _listMovies = new List<Movies>();

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView (Resource.Layout.Main);

            _lvwMovies = FindViewById<ListView>(Resource.Id.lvwMovies);
            _txtTitle = FindViewById<EditText>(Resource.Id.txtTitle);
            _txtTitle.KeyPress += async (sender, e) =>
            {
                if (e.KeyCode == Keycode.Enter)
                {
                    await Search();
                }
                else
                {
                    e.Handled = false;
                }
            };

            var btnSearch = FindViewById<Button>(Resource.Id.btnSearch);
            btnSearch.Click += async (send, e) =>
            {
                await Search();
            };

            _lvwMovies.ItemClick += (sender, eventArgs) =>
            {
                var nemt = _listMovies[eventArgs.Position].Title;
                Toast.MakeText(this, nemt, ToastLength.Long).Show();
            };
        }

        private async Task Search()
        {
            _listMovies.Clear();
            var txvNone = FindViewById<TextView>(Resource.Id.txv_none);
            var lnlrogressBar = FindViewById<LinearLayout>(Resource.Id.ProgressBar);

            txvNone.Visibility = ViewStates.Gone;
            _lvwMovies.Visibility = ViewStates.Gone;

            if (IsValid())
            {
                lnlrogressBar.Visibility = ViewStates.Visible;
                var repository = new Repository();
                var movies = await repository.GetMovie(_txtTitle.Text);

                if (movies.Response)
                {
                    _listMovies = new List<Movies>(movies.Search);
                    _lvwMovies.Adapter = new MovieAdapter(this, _listMovies);
                    _lvwMovies.Visibility = ViewStates.Visible;
                }
                else
                {
                    txvNone.Visibility = ViewStates.Visible;
                }
            }
            lnlrogressBar.Visibility = ViewStates.Gone;
        }

        private bool IsValid()
        {
            if (string.IsNullOrEmpty(_txtTitle.Text) || string.IsNullOrWhiteSpace(_txtTitle.Text) || _txtTitle.Length() < 2 )
            {
                Toast.MakeText(this, Resource.String.SearchAlert, ToastLength.Long).Show();
                return false;
            }
            return true;
        }
    }
}

