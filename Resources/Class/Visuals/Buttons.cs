namespace LEW.Resources.Class.Visuals;

public class Buttons
{
    public static Button EnglishWord(string word, EventHandler clicked)
    {
        Button englishWordButton = new Button
        {
            HeightRequest = 50, WidthRequest = 120, Text = word, TextColor = Colors.Text,
            BorderColor = Colors.Border, BorderWidth = 1, BackgroundColor = Colors.Background
        };
        englishWordButton.Clicked += clicked;
        return englishWordButton;
    }

}