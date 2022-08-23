using NewsApp.Models;

namespace NewsApp.Pages;

public partial class NewsDetailPage : ContentPage
{
	private string uri;
	public NewsDetailPage(Article article)
	{
		InitializeComponent();
		ImgNews.Source =  article.Image;
		LblTitle.Text = article.Title;
		LblContent.Text = article.Content;
		uri = article.Url;
	}

	private async void TbShare_Clicked(object sender, EventArgs e)
	{
		await Share.RequestAsync(new ShareTextRequest
		{
			Uri = uri,
			Title = "Test Share"
		});
	}
}