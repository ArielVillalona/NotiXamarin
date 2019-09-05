using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using NotiXamarin.Core.Service;
using Square.Picasso;
using System;
using Android.Views;

namespace NotiXamarin
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", ParentActivity = typeof(NewsListActivity))]
    public class MainActivity : AppCompatActivity
    {
		internal static string KEY_ID = "KEY_ID";

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			// Set our view from the "main" layout resource
			SetContentView(Resource.Layout.activity_main);

			/*Android.App.ActionBar actionBar = this.ActionBar;
			actionBar.SetDisplayHomeAsUpEnabled(true);*/

			var id = Intent.Extras.GetInt(KEY_ID);
			var newsService = new NewsService();
			var news = newsService.GetNewsById(id);

			var newsTitle = FindViewById<TextView>(Resource.Id.newsTitle);
			var newsImage = FindViewById<ImageView>(Resource.Id.newsImage);
			var newsBody = FindViewById<TextView>(Resource.Id.newsBody);

			var display = WindowManager.DefaultDisplay;
			Android.Graphics.Point point = new Android.Graphics.Point();
			display.GetSize(point);

			var imageURL = string.Concat(ValuesService.ImagesBaseURL,
				news.ImageName);

			Picasso.With(ApplicationContext)
				.Load(imageURL)
				.Resize(point.X, 0)
				.Into(newsImage);

			newsTitle.Text = news.Title;
			newsBody.Text = news.Body;
		}

		public override bool OnCreateOptionsMenu(IMenu menu)
		{
			MenuInflater.Inflate(Resource.Menu.newsActionMenus, menu);
			return base.OnCreateOptionsMenu(menu);
		}

		public override bool OnOptionsItemSelected(IMenuItem item)
		{
			switch (item.ItemId)
			{
				case Resource.Id.action_read_later:
					HandleReadLater();
					return true;
				default:
					return base.OnOptionsItemSelected(item);
			}
		}
		private void HandleReadLater()
		{
			try
			{
			//	var newsLocalService = new NewsLocalService();
			//	newsLocalService.Save(_news);
			//	Toast.MakeText(this, "Saved", ToastLength.Short).Show();
			}
			catch (Exception ex)
			{
				Toast.MakeText(this, "error: " + ex.Message, ToastLength.Long).Show();
			}
		}
	}
}