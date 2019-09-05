using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using NotiXamarin.Adapters;
using NotiXamarin.Core.Service;

namespace NotiXamarin
{
	[Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher =true)]
	public class NewsListActivity : Activity
	{
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Create your application here
			SetContentView(Resource.Layout.NewsList);

			var newsListView = FindViewById<ListView>(Resource.Id.NewslistView);

			var newsService = new NewsService();
			var news = newsService.GetNews();
			newsListView.Adapter = new NewsListAdapter(this, news);

			newsListView.ItemClick += NewsListView_ItemClick;
		}

		private void NewsListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
		{
			var intent = new Intent(this, typeof(MainActivity));
			var id = (int)e.Id;
			intent.PutExtra(MainActivity.KEY_ID, id);
			StartActivity(intent);
		}
	}
}