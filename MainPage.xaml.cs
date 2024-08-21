using System.Net.NetworkInformation;
using LEW.Class.API.Words.Random;
using LEW.Class.API.Words.Translate;
using LEW.Class.DataBase;

namespace LEW
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
            test();
        }

        private async void test()
        {
            var test = await Translate.EnglishToFrench("dick");
            var test2 = await RandomWord.RandomEnglish(5);
        }
    } 
}