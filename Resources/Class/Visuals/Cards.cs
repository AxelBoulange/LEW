using LEW.Resources.Class.API.Words.Random;
using Colors = LEW.Resources.Class.Visuals.Colors;

namespace LEW.Resources.Class.Visuals;

public class Cards
{
    public event EventHandler NextStep;
    public static Frame DifficultyChoiceGrid(Color difficultyColor, string difficultyText, string DescriptionText, int Row, EventHandler<TappedEventArgs> clicked)
    {
        Frame card = new Frame{ BorderColor = Colors.Border, CornerRadius = 10,  BackgroundColor = Colors.Primary, HeightRequest = 100, Margin = new Thickness(20), HorizontalOptions = LayoutOptions.Fill, VerticalOptions = LayoutOptions.Fill, Padding = new Thickness(0)};
        Grid grid = new Grid{ HorizontalOptions = LayoutOptions.Fill, VerticalOptions = LayoutOptions.Fill};
        
        
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
        
        
        var tapGestureRecognizer = new TapGestureRecognizer();
        tapGestureRecognizer.Tapped += clicked;
        card.GestureRecognizers.Add(tapGestureRecognizer);
        
        
        card.Content = grid;
        Grid.SetRow(card,Row);
        return card;
    }
    
    public Frame FrenchWord(string word)
    {
        Frame card = new Frame{ BorderColor = Colors.Border, CornerRadius = 10,  BackgroundColor = Colors.Primary, HeightRequest = 50, Margin = new Thickness(20), HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Fill, Padding = new Thickness(10,0)};
        Grid grid = new Grid{ HorizontalOptions = LayoutOptions.Fill, VerticalOptions = LayoutOptions.Fill};
        
        
        ColumnDefinition columnDefinition = new ColumnDefinition();
        columnDefinition.Width = new GridLength(1, GridUnitType.Star);
        grid.ColumnDefinitions.Add(columnDefinition);
        grid.ColumnDefinitions.Add(columnDefinition);
        
        
        Image arrowIcon = new Image
        {
            HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center, HeightRequest = 40,
            Margin = new Thickness(0, 0, 20, 0)
        };
        arrowIcon.Source = ImageSource.FromFile("Resources/Images/Icons/arrow_right.svg");
        grid.Children.Add(arrowIcon);
        Grid.SetColumn(arrowIcon,0);
        
        Label wordLabel = new Label()
        {
            HorizontalOptions = LayoutOptions.Center, HorizontalTextAlignment = TextAlignment.Center,
            VerticalOptions = LayoutOptions.Center, VerticalTextAlignment = TextAlignment.Center, FontSize = 15,
            TextColor = Colors.Text, Text = word
        };
        grid.Children.Add(wordLabel);
        Grid.SetColumn(wordLabel,1);
        
        
        card.Content = grid;
        return card;
    }

    public VerticalStackLayout EnglishWords(List<string> listWords, int nbWords)
    {
        VerticalStackLayout wordsLayout = new VerticalStackLayout{HorizontalOptions = LayoutOptions.Fill, VerticalOptions = LayoutOptions.Start, Margin = new Thickness(0,40,0,0), Spacing = 20};
        List<Button> buttons = new List<Button>();
        
        
        bool first = true;
        foreach (var word in listWords)
        {
            EventHandler e;
            if (!first)
            {
                e = async (sender, args) =>
                {
                    await Application.Current.MainPage.DisplayAlert( "","False", "OK");
                    NextStep?.Invoke( sender, args);
                };
            }
            else
            {
                e =  async (sender, args) =>
                {
                    await Application.Current.MainPage.DisplayAlert( "","True", "OK");
                    NextStep?.Invoke( sender, args);
                };
                first = false;
            }

            buttons.Add(Buttons.EnglishWord(word, e));
        }

        var randomizedButtons = Shuffle.List(buttons);
        
        Grid grid = new Grid{ HorizontalOptions = LayoutOptions.Fill, VerticalOptions = LayoutOptions.Fill};
            
        ColumnDefinition columnDefinition = new ColumnDefinition();
        columnDefinition.Width = new GridLength(1, GridUnitType.Star);
        grid.ColumnDefinitions.Add(columnDefinition);
        grid.ColumnDefinitions.Add(columnDefinition);
        grid.ColumnDefinitions.Add(columnDefinition);
        
        int place = 0;
        if (nbWords == 3)
        {
            foreach (var btn in randomizedButtons)
            {
                Grid.SetColumn(btn, place);
                grid.Add(btn);
                place++;
            }
            wordsLayout.Add(grid);
        }
        else if (nbWords == 5)
        {
            Grid grid2 = new Grid{ HorizontalOptions = LayoutOptions.Fill, VerticalOptions = LayoutOptions.Fill, RowSpacing = 20};
            grid2.ColumnDefinitions.Add(columnDefinition);
            grid2.ColumnDefinitions.Add(columnDefinition);

            foreach (var btn in randomizedButtons)
            {
                if (place <= 2)
                {
                    Grid.SetColumn(btn, place);
                    grid.Add(btn);
                }
                else
                {
                    Grid.SetColumn(btn, place % 3);
                    grid2.Add(btn);
                }
                place++;
            }
            wordsLayout.Add(grid);
            wordsLayout.Add(grid2);

        }
        else if (nbWords == 8)
        {
            Grid grid2 = new Grid{ HorizontalOptions = LayoutOptions.Fill, VerticalOptions = LayoutOptions.Fill};
            grid2.ColumnDefinitions.Add(columnDefinition);
            grid2.ColumnDefinitions.Add(columnDefinition);
            grid2.ColumnDefinitions.Add(columnDefinition);
            
            Grid grid3 = new Grid{ HorizontalOptions = LayoutOptions.Fill, VerticalOptions = LayoutOptions.Fill};
            grid3.ColumnDefinitions.Add(columnDefinition);
            grid3.ColumnDefinitions.Add(columnDefinition);

            foreach (var btn in randomizedButtons)
            {
                if (place <= 2)
                {
                    Grid.SetColumn(btn, place);
                    grid.Add(btn);
                }
                else if (place <= 5)
                {
                    Grid.SetColumn(btn, place % 3);
                    grid2.Add(btn);
                }
                else
                {
                    Grid.SetColumn(btn, place % 3);
                    grid3.Add(btn);
                }
                place++;
            }
            
            wordsLayout.Add(grid);
            wordsLayout.Add(grid2);
            wordsLayout.Add(grid3);
        }

        
        Grid.SetRow(wordsLayout,1);
        return wordsLayout;
    }
}