using LEW.Resources.Class.API.Words.Random;
using LEW.Resources.Class.API.Words.Translate;
using LEW.Resources.Class.Visuals;

namespace LEW.Pages
{
    public partial class Game : ContentPage
    {
        private List<string>[] _listsEnglishWords = new List<string>[10];
        private string[] _listsFrenchWords = new string[10];
        private int _listsWordsCurrentPlace = 0;
        private int _nbWords;
        
        public Game(int nbWords)
        {
            _nbWords = nbWords;
            InitializeComponent();
            _ = LoadMoreAsync();
        }

        private async Task LoadMoreAsync()
        {
            await Loading();
            SetMainBackground();
            ShowWords();
            LoadMore();
        }

        private async Task Loading()
        {
            try
            {
                List<string> loadingWords = await RandomWords.RandomEnglish(_nbWords * 2);
                _listsEnglishWords[0] = loadingWords.GetRange(0, _nbWords);
                _listsEnglishWords[1] = loadingWords.GetRange(_nbWords, _nbWords);

                var translationTasks = new[]
                {
                    Translate.EnglishToFrench(_listsEnglishWords[0][0]),
                    Translate.EnglishToFrench(_listsEnglishWords[1][0])
                };

                var translatedWords = await Task.WhenAll(translationTasks);
                _listsFrenchWords[0] = translatedWords[0];
                _listsFrenchWords[1] = translatedWords[1];
            }
            catch
            {
                await DisplayAlert("ERROR", "Something went wrong in loading.", "Leave");
                await Navigation.PopAsync();
            }
        }
        
        private async void LoadMore()
        {
            int place = 2;
            while (place <= 9)
            {
                try
                {
                    _listsEnglishWords[place] = await RandomWords.RandomEnglish(_nbWords);
                    _listsFrenchWords[place] = await Translate.EnglishToFrench(_listsEnglishWords[place][0]);
                }
                catch
                {
                    await DisplayAlert("ERROR", "Something went wrong in pre-loading.", "Leave");
                    await Navigation.PopAsync();
                }
                place++;
            }
        }

        private async void LoaOneMore()
        {
            int placeWhereLoad = _listsWordsCurrentPlace == 0 ? 9 : _listsWordsCurrentPlace - 1;
            try
            {
                _listsEnglishWords[placeWhereLoad] = await RandomWords.RandomEnglish(_nbWords);
                _listsFrenchWords[placeWhereLoad] = await Translate.EnglishToFrench(_listsEnglishWords[placeWhereLoad][0]);
            }
            catch
            {
                await DisplayAlert("ERROR", "Something went wrong in \"LoadOneMore\".", "Leave");
                await Navigation.PopAsync();
            }
        }
        
        private void ShowWords()
        {
            Cards c = new Cards();
            c.NextStep += GameNextStep;
            Main.Children.Add(c.FrenchWord(_listsFrenchWords[_listsWordsCurrentPlace]));
            Main.Children.Add(c.EnglishWords(_listsEnglishWords[_listsWordsCurrentPlace],_nbWords));
            LoaOneMore();
            if (_listsWordsCurrentPlace == 9)
            {
                _listsWordsCurrentPlace = 0;
            }
            else
            {
                _listsWordsCurrentPlace++;
            }
        }

        private void GameNextStep(object o, EventArgs e)
        {
            Main.Clear();
            SetMainBackground();
        }

        private void SetMainBackground()
        {
            Image background = new Image
            {
                VerticalOptions = LayoutOptions.Fill,
                HorizontalOptions = LayoutOptions.Fill,
                Aspect = Aspect.AspectFill,
                Source = "Resources/Images/Backgrounds/stars_16_9.jpg"
            };
            Grid.SetRowSpan(background,4);
            Main.Add(background);
        }
        
    } 
}