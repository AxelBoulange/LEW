using LEW.Resources.Class.Visuals;
using Colors = Microsoft.Maui.Graphics.Colors;

namespace LEW
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            Main.Children.Add(Card.DifficultyChoiceGrid(Colors.Green, "EASY","Find the corresponding word between 3 words.", 0));
            Main.Children.Add(Card.DifficultyChoiceGrid(Colors.Orange, "MEDIUM","Find the corresponding word between 5 words.", 1));
            Main.Children.Add(Card.DifficultyChoiceGrid(Colors.Red, "HARD","Find the corresponding word between 8 words.", 2));
        }
    } 
}