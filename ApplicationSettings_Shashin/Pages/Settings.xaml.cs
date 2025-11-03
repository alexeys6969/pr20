using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Windows.Forms;
using System.Drawing;
namespace ApplicationSettings_Shashin.Pages
{
    /// <summary>
    /// Логика взаимодействия для Settings.xaml
    /// </summary>
    public partial class Settings : Page
    {
        private MainWindow mainWindow;
        OpenFileDialog openFileDiaolog = new OpenFileDialog();
        ColorDialog colorDialog = new ColorDialog();
        public Settings(MainWindow _mainWindow)
        {
            InitializeComponent();
            mainWindow = _mainWindow;
            openFileDiaolog.InitialDirectory = "c:\\";
            openFileDiaolog.Filter = "Access files (*.accdb)|*accdb|All files (*.*)|*.*";
            openFileDiaolog.FilterIndex = 2;
            openFileDiaolog.RestoreDirectory = true;

            colorDialog.AllowFullOpen = true;
            colorDialog.ShowHelp = false;
        }

        private void OpenDataBase(object sender, RoutedEventArgs e)
        {
            if (openFileDiaolog.ShowDialog() == DialogResult.OK) tb_database.Text = openFileDiaolog.FileName;
        }

        private void SelectScreenResolution(object sender, SelectionChangedEventArgs e)
        {
            System.Windows.Controls.ComboBox comboBox = sender as System.Windows.Controls.ComboBox;
            TextBlock textBlock = comboBox.SelectedValue as TextBlock;
            string resolution = textBlock.Text;
            string[] separator = new string[1] { " x " };
            mainWindow.Width = int.Parse(resolution.Split(separator, StringSplitOptions.None)[0]);
            mainWindow.Width = int.Parse(resolution.Split(separator, StringSplitOptions.None)[1]);
        }

        private void SelectColorApplication(object sender, RoutedEventArgs e)
        {
            if(colorDialog.ShowDialog() == DialogResult.OK)
            {
                System.Drawing.Color ChangeColor = colorDialog.Color;
                gr_header.Background = new SolidColorBrush(System.Windows.Media.Color.FromArgb(ChangeColor.A, ChangeColor.R, ChangeColor.G, ChangeColor.R));
                gr_application.Background = new SolidColorBrush(System.Windows.Media.Color.FromArgb(ChangeColor.A, ChangeColor.R, ChangeColor.G, ChangeColor.R));
            }
        }
    }
}
