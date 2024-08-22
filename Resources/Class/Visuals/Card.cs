using Colors = LEW.Resources.Class.Visuals.Colors;

namespace LEW.Resources.Class.Visuals;

public class Card
{
    public static Frame DifficultyChoiceGrid(Color difficultyColor, string difficultyText, string DescriptionText, int Row)
    {
        Frame card = new Frame() { BorderColor = Colors.Border, CornerRadius = 10,  BackgroundColor = Colors.Primary, HeightRequest = 100, Margin = new Thickness(20), HorizontalOptions = LayoutOptions.Fill, VerticalOptions = LayoutOptions.Fill, Padding = new Thickness(0)};
        
        Grid grid = new Grid() { HorizontalOptions = LayoutOptions.Fill, VerticalOptions = LayoutOptions.Fill};
        
        ColumnDefinition columnDefinition = new ColumnDefinition();
        columnDefinition.Width = new GridLength(2, GridUnitType.Star);
        grid.ColumnDefinitions.Add(columnDefinition);
        columnDefinition.Width = new GridLength(5, GridUnitType.Star);
        grid.ColumnDefinitions.Add(columnDefinition);
        columnDefinition.Width = new GridLength(1, GridUnitType.Star);
        grid.ColumnDefinitions.Add(columnDefinition);

        Label difficultyLabel = new Label()
        {
            HorizontalOptions = LayoutOptions.Center, HorizontalTextAlignment = TextAlignment.Center,
            VerticalOptions = LayoutOptions.Center, VerticalTextAlignment = TextAlignment.Center, FontSize = 20,
            TextColor = difficultyColor, FontAttributes = FontAttributes.Bold, Text = difficultyText
        };
        grid.Children.Add(difficultyLabel);
        Grid.SetColumn(difficultyLabel,0);    
        
        Label descriptionLabel = new Label()
        {
            HorizontalOptions = LayoutOptions.Center, HorizontalTextAlignment = TextAlignment.Center,
            VerticalOptions = LayoutOptions.Center, VerticalTextAlignment = TextAlignment.Center, FontSize = 15,
            TextColor = Colors.Text, Text = DescriptionText
        };
        grid.Children.Add(descriptionLabel);
        Grid.SetColumn(descriptionLabel,1);

        Image arrowIcon = new Image
        {
            HorizontalOptions = LayoutOptions.End, VerticalOptions = LayoutOptions.Center, HeightRequest = 40,
            Margin = new Thickness(0, 0, 20, 0)
        };
        arrowIcon.Source = ImageSource.FromFile("Resources/Images/Icons/arrow_right.svg");
        grid.Children.Add(arrowIcon);
        Grid.SetColumn(arrowIcon,2);
        
        card.Content = grid;
        Grid.SetRow(card,Row);

        return card;
    }
}