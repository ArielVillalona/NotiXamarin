using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using NotiXamarin.Core.Service;
using Square.Picasso;

namespace NotiXamarin
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

			var newsService = new NewsService();
			var news = newsService.GetNewsById(1);

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
    }
}