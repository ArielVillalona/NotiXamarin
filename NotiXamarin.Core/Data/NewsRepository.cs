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
using NotiXamarin.Core.Model;

namespace NotiXamarin.Core.Data
{
	public class NewsRepository
	{
		private List<News> _news;
		public NewsRepository()
		{
			_news = new List<News>()
			{
				new News()
				{
					Id=1,
					Title="MAP lanza convocatoria para autores interesados en publicar en la Revista de Administración Pública",
					ImageName="noticia1.png",
					Body="SANTO DOMINGO. Con el fin de contribuir a la investigación científico- profesional en los temas de su competencia, el Ministerio de Administración Pública (MAP) ha lanzado la convocatoria para los autores, investigadores, docentes, y especialistas de la administración pública a nivel local e internacional, interesados en enviar artículos a ser publicados en el segundo número de la Revista Administración Pública, que abordará en esta edición contenidos de innovación y modernización."
				},
				new News()
				{
					Id=2,
					Title="",
					ImageName="noticia.jpg",
					Body=""
				},
				new News()
				{
					Id=3,
					Title="",
					ImageName="noticia.jpg",
					Body=""
				},
			};
		}

		public List<News> GetNews()
		{
			return _news;
		}

		public News GetNewsById(int id)
		{
			return _news.FirstOrDefault(x => x.Id == id);
		}
	}
}