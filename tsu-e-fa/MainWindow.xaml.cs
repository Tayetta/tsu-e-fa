using System.Security.Policy;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace tsu_e_fa
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //константы
        const string ROCK = "Камень";
        const string SCISSOR = "Ножницы";
        const string PAPER = "Бумага";
        //пояснение
       readonly string[]  explan = { "камень ломает ножницы", "ножницы режут бумагу", "бумага обёртывает камень"};
        //выбор игрока и опонента
        string userChoice = " ";
        string opponentChoice = " ";
        //результат
        int isResult = -2;

        public MainWindow()
        {
            InitializeComponent();
            ResultText.FontFamily = new FontFamily("Verbana");
            ResultText.FontSize = 30;
            ResultText.VerticalAlignment = VerticalAlignment.Center;         
        }
        //кнопка выбора камень
        private void Rock_Click(object sender, RoutedEventArgs e)
        {
           userChoice = ROCK;
            PlayGame(userChoice);        
        }
        //кнопка выбора ножницы
        private void Scissors_Click(object sender, RoutedEventArgs e) 
        {
            userChoice = SCISSOR;
            PlayGame(userChoice);            
        }
        //кнопка выбора бумага
        private void Paper_Click(object sender, RoutedEventArgs e)
        {
            userChoice = PAPER;      
            PlayGame(PAPER);           
        }
        //кнопка рандом-выбора игрока
        private void Rand_Click(object sender, RoutedEventArgs e)
        {
            userChoice = RandomSelection();
            PlayGame(userChoice);
        }
        
        //функция рандомного выбора
        private string RandomSelection()
        {
            string[] choies = { ROCK, SCISSOR, PAPER };
            Random random = new Random();
            string arbitrary = choies[random.Next(choies.Length)];
            return arbitrary;
        }
        //функция проверки выбора игроков
        private void PlayGame(string userChoice)
        {           
            //рандомный выбор оппонента           
            opponentChoice = RandomSelection();

            if(userChoice == opponentChoice)
            {
                isResult = 0;
            }
            else if(userChoice == ROCK && opponentChoice == SCISSOR || 
                    userChoice == SCISSOR && opponentChoice == PAPER ||
                    userChoice == PAPER && opponentChoice == ROCK)
            {
                isResult = 1;
            }
            else
            {
                isResult = -1;
            }
            DisplayResults(userChoice,opponentChoice,isResult);
        }
        //функция отображения результатов
        private void DisplayResults(string userChoice,string opponentChoice, int isResult)
        {  
            // выведем выбор оппонентов в поле информации          
            PlayerChoice.Text = userChoice;
            OpponentChoice.Text = opponentChoice;
            // выведем результат игры
            if (isResult == 1)
            {
                ResultText.Foreground = Brushes.Green;
                ResultText.Text = "Победа";
            }else 
            if (isResult == 0)
            {
                ResultText.Foreground = Brushes.Brown;
                ResultText.Text = "Ничья";  
            }            
            else            
            {
                ResultText.Foreground = Brushes.Red;
                ResultText.Text = "Поражение";
            }
            //выведем пояснение
            if ((ROCK == opponentChoice && SCISSOR == userChoice) || 
                (ROCK == userChoice && SCISSOR == opponentChoice) && isResult !=0)
            {
                info.Text = explan[0];
            }
            else
            if ((SCISSOR == opponentChoice && PAPER == userChoice) || 
                (SCISSOR == userChoice && PAPER == opponentChoice) && isResult !=0)
            {
                info.Text = explan[1];
            }
            else 
            if ((PAPER == opponentChoice && ROCK == userChoice) || 
                (PAPER == userChoice && ROCK == opponentChoice) && isResult != 0)
            {
                info.Text = explan[2];
            }
            else
            {
                info.Text = " ";
            }
            //отразим визуальный выбор игроков
            UpdateCompImage(opponentChoice);
            UpdateUserImage(userChoice);
        }
        //функция отображения выбора игрока
        private void UpdateUserImage(string userChoice)
        {
            imageUser.Visibility = Visibility.Visible;
            string patch = " ";
            switch (userChoice)
            {
                case ROCK:
                    patch = "Resourse/rock.jpg";
                    break;
                case SCISSOR:
                    patch = "Resourse/Scissor.jpg";
                    break;
                case PAPER:
                    patch = "Resourse/paper-art.jpg";
                    break;
                default:
                    patch = "Resourse/Oops.jpg";
                    break;
            }
            //отрисовка изображения
            imageUser.Source = new BitmapImage(new Uri(patch, UriKind.Relative));
            imageOpponent.Stretch = Stretch.Uniform;
        }
        //функция отображения выбора опонента
        private void UpdateCompImage(string opponentChoice)
        {            
            imageOpponent.Visibility = Visibility.Visible;
            string patch = " ";
            switch (opponentChoice)
            {
                case ROCK:
                   patch = "Resourse/rock.jpg";
                    break;
                case SCISSOR:
                    patch = "Resourse/Scissor.jpg";
                    break;
                case PAPER:
                    patch = "Resourse/paper-art.jpg";
                    break;
                default:
                    patch = "Resourse/Oops.jpg";
                    break;
            }
            //отрисовка изображения
            imageOpponent.Source = new BitmapImage(new Uri(patch, UriKind.Relative));
            imageOpponent.Stretch = Stretch.Uniform;
        }

    }
}