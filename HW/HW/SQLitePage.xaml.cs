using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.ObjectModel;

namespace HW
{
    public class Recipe
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [MaxLength(255)]
        public string Name { get; set; }
    }

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SQLitePage : ContentPage
    {
        private SQLiteAsyncConnection _connection;
        private ObservableCollection<Recipe> _recipes;

        public SQLitePage()
        {
            InitializeComponent();

            _connection = DependencyService.Get<ISQLiteDb>().GetConnection();

        }

        protected override async void OnAppearing()
        {
            await _connection.CreateTableAsync<Recipe>();

            var recipes = await _connection.Table<Recipe>().ToListAsync();
            _recipes = new ObservableCollection<Recipe>(recipes);
            recipesListView.ItemsSource = _recipes;

            base.OnAppearing();          
        }

        void OnAdd(object sender, System.EventArgs e)
        {
            var recipe = new Recipe { Name = "Recipe" + DateTime.Now.Ticks };
            _connection.InsertAsync(recipe);
            _recipes.Add(recipe);
        }

        void OnUpdate(object sender, System.EventArgs e)
        {
            var recipe = _recipes[0];
            recipe.Name += "_UPDATED";

            _connection.UpdateAsync(recipe);
        }

        void OnDelete(object sender, System.EventArgs e)
        {
            var recipe = _recipes[0];

            _connection.DeleteAsync(recipe);
            _recipes.Remove(recipe);
        }
    }
}