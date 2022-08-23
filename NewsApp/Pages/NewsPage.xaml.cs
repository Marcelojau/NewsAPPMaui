using NewsApp.Models;
using NewsApp.Services;

namespace NewsApp.Pages;

public partial class NewsPage : ContentPage
{
	private bool IsNextPage = false;
	public List<Article> ArticleList { get; set; }
	public ApiService ApiService;

    public List<Category> CategoryList = new List<Category>()
	{
		new Category() {Name = "Breaking-News"},
		new Category() {Name = "World"},
		new Category() {Name = "Nation"},
		new Category() {Name = "Business"},
        new Category() {Name = "Technology"},
        new Category() {Name = "Entertainment"},
        new Category() {Name = "Sports"},
        new Category() {Name = "Science"},
        new Category() {Name = "Health"}
    };

	public NewsPage()
	{
		InitializeComponent();
		ArticleList = new List<Article>();
		CvCategories.ItemsSource = CategoryList;
        ApiService = new ApiService();

    }

	protected override async void OnAppearing()
	{
		base.OnAppearing();
		if (IsNextPage == false)
		{
			await PassCategory();
        }
		
		
	}

	public async Task PassCategory(string categoryName = null)
	{
		CvNews.ItemsSource = null;
		ArticleList.Clear();

        var newsResult = await ApiService.GetNews(categoryName);

        foreach (var item in newsResult.Articles)
        {
            ArticleList.Add(item);
        }
        CvNews.ItemsSource = ArticleList;
    }

	private async void CvCategories_SelectionChanged(object sender, SelectionChangedEventArgs e)
	{
		var selectedItem = e.CurrentSelection.FirstOrDefault() as Category;
		await PassCategory(selectedItem.Name);
		
	}

	private async void CvNews_SelectionChanged(object sender, SelectionChangedEventArgs e)
	{
		var selectedItem = e.CurrentSelection.FirstOrDefault() as Article;
		IsNextPage = true;
		await Navigation.PushAsync(new NewsDetailPage(selectedItem));
	}
}