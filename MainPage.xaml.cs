using LEW.Pages;
using LEW.Resources.Class.Visuals;
using Colors = Microsoft.Maui.Graphics.Colors;

namespace LEW
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            Main.Children.Add(Cards.DifficultyChoiceGrid(Colors.Green, "EASY","Find the corresponding word between 3 words.", 0,
                (sender, args) => { Navigation.PushAsync(new Game(3));} ));
            Main.Children.Add(Cards.DifficultyChoiceGrid(Colors.Orange, "MEDIUM","Find the corresponding word between 5 words.", 1,
                (sender, args) => { Navigation.PushAsync(new Game(5));} ));
            Main.Children.Add(Cards.DifficultyChoiceGrid(Colors.Red, "HARD","Find the corresponding word between 8 words.", 2,
                (sender, args) => { Navigation.PushAsync(new Game(8));} ));
        }
    } 
}