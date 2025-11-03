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
        FontDialog fontDialog = new FontDialog();
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
            mainWindow.Height = int.Parse(resolution.Split(separator, StringSplitOptions.None)[1]);
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

        private void SelectColorText(object sender, RoutedEventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                System.Drawing.Color ChangeColor = colorDialog.Color;
                gr_text.Background = new SolidColorBrush(System.Windows.Media.Color.FromArgb(ChangeColor.A, ChangeColor.R, ChangeColor.G, ChangeColor.R));
                var textBrush = new SolidColorBrush(System.Windows.Media.Color.FromArgb(ChangeColor.A, ChangeColor.R, ChangeColor.G, ChangeColor.B));
                header.Foreground = textBrush;
                lb_database.Foreground = textBrush;
                button_database.Foreground = textBrush;
                lb_res.Foreground = textBrush;
                lb_color.Foreground = textBrush;
                application_color.Foreground = textBrush;
                app_color_button.Foreground = textBrush;
                color_text.Foreground = textBrush;
                color_text_button.Foreground = textBrush;
                fonts.Foreground = textBrush;
                font_label.Foreground = textBrush;
                font_button.Foreground = textBrush;
                save_config.Foreground = textBrush;
                Load_config.Foreground = textBrush;
            }
        }

        private void SelectFonts(object sender, RoutedEventArgs e)
        {
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                header.FontFamily = new System.Windows.Media.FontFamily(fontDialog.Font.Name);
                lb_database.FontFamily = new System.Windows.Media.FontFamily(fontDialog.Font.Name);
                button_database.FontFamily = new System.Windows.Media.FontFamily(fontDialog.Font.Name);
                lb_res.FontFamily = new System.Windows.Media.FontFamily(fontDialog.Font.Name);
                lb_color.FontFamily = new System.Windows.Media.FontFamily(fontDialog.Font.Name);
                application_color.FontFamily = new System.Windows.Media.FontFamily(fontDialog.Font.Name);
                app_color_button.FontFamily = new System.Windows.Media.FontFamily(fontDialog.Font.Name);
                color_text.FontFamily = new System.Windows.Media.FontFamily(fontDialog.Font.Name);
                color_text_button.FontFamily = new System.Windows.Media.FontFamily(fontDialog.Font.Name);
                fonts.FontFamily = new System.Windows.Media.FontFamily(fontDialog.Font.Name);
                font_label.FontFamily = new System.Windows.Media.FontFamily(fontDialog.Font.Name);
                font_label.Content = fontDialog.Font.Name;
                font_button.FontFamily = new System.Windows.Media.FontFamily(fontDialog.Font.Name);
                save_config.FontFamily = new System.Windows.Media.FontFamily(fontDialog.Font.Name);
                Load_config.FontFamily = new System.Windows.Media.FontFamily(fontDialog.Font.Name);
            }
        }

        private void SaveConfig(object sender, RoutedEventArgs e)
        {
            if(openFileDiaolog.ShowDialog() == DialogResult.OK)
            {
                string resolution = "";
                StreamWriter streamWriter = new StreamWriter(openFileDiaolog.FileName);
                streamWriter.WriteLine("Настройки");
                streamWriter.WriteLine($"База данных: {tb_database.Text}");
                if (ResolutionCB.SelectedItem is TextBlock item)
                   resolution = item.Text.ToString();
                streamWriter.WriteLine($"Разрешение: {resolution}");
                streamWriter.WriteLine($"Цвет приложения: {gr_application.Background.ToString()}");
                streamWriter.WriteLine($"Цвет текста: {gr_text.Background.ToString()}");
                streamWriter.WriteLine($"Шрифт: {font_label.Content}");
                streamWriter.Close();
                System.Windows.MessageBox.Show($"Данные успешно сохранены в {openFileDiaolog.FileName}");
            }
        }

        private void LoadConfig(object sender, RoutedEventArgs e)
        {

        }
    }
}
