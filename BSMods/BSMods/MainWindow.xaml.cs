using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace BSMods
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private BSModsMain _BSMods;
        private ModReleaseLinks _mods;

        public MainWindow()
        {
            InitializeComponent();

            _BSMods = new BSModsMain();

            _BSMods.SetLocationPath();
            bsLocationLabel.Content = _BSMods.beatSaberPath;

            LoginButton.Click += LoginButton_Click;
            InstallButton.Click += InstallButton_Click;


            _mods = new ModReleaseLinks();
            AddModpackToListBox();
            if (_BSMods.beatSaberPath.ToLower().Contains("steam"))
            {
                var itemSteam = ModListBox.Items[0] as CheckBox;
                var itemOculus = ModListBox.Items[1] as CheckBox;
                itemSteam.IsChecked = true;
                itemOculus.IsChecked = false;

            }
            else
            {
                var itemSteam = ModListBox.Items[0] as CheckBox;
                var itemOculus = ModListBox.Items[1] as CheckBox;
                itemSteam.IsChecked = false;
                itemOculus.IsChecked = true;
            }

        }

        private void AddModpackToListBox()
        {
            foreach (var mod in _mods.ImportantMods)
            {
                if (mod[0].Contains("[title]"))
                {
                    var title = new Label { Content = mod[0].Replace("[title]", ""), FontStyle = FontStyles.Italic, Background = new SolidColorBrush { Color = (Color)ColorConverter.ConvertFromString("#FF1A1F25") }, Foreground = new SolidColorBrush { Color = Colors.White } };
                    ModListBox.Items.Add(title);
                    continue;
                }

                var checkbox = new CheckBox()
                    {Content = mod[0], IsChecked = true, BorderThickness = new Thickness(2, 2, 2, 2)};
                var margin = checkbox.Margin;
                margin.Top = 5;
                checkbox.Margin = margin;
                var index = ModListBox.Items.Add(checkbox);

            }

            foreach (var mod in _mods.OtherMods)
            {
                if (mod[0].Contains("[title]"))
                {
                    var title = new Label { Content = mod[0].Replace("[title]", ""), FontStyle = FontStyles.Italic, Background = new SolidColorBrush { Color = (Color)ColorConverter.ConvertFromString("#FF1A1F25") }, Foreground = new SolidColorBrush { Color = Colors.White } };
                    ModListBox.Items.Add(title);
                    continue;
                }
                var checkbox = new CheckBox()
                    { Content = mod[0], IsChecked = false, BorderThickness = new Thickness(2, 2, 2, 2) };
                var margin = checkbox.Margin;
                margin.Top = 5;
                checkbox.Margin = margin;
                var index = ModListBox.Items.Add(checkbox);
            }

            foreach (var mod in _mods.gitHubModReleaseLinks)
            {
                if(mod[0].Contains("[title]"))
                {
                    var title = new Label{Content = mod[0].Replace("[title]",""), FontStyle = FontStyles.Italic, Background = new SolidColorBrush{Color = (Color)ColorConverter.ConvertFromString("#FF1A1F25") }, Foreground = new SolidColorBrush{Color = Colors.White }};
                    ModListBox.Items.Add(title);
                    continue;
                }else if (mod[0].Contains("[important]"))
                {
                    var checkbox1 = new CheckBox()
                        { Content = mod[0].Replace("[important]", ""), IsChecked = true, BorderThickness = new Thickness(2, 2, 2, 2) };
                    var margin1 = checkbox1.Margin;
                    margin1.Top = 5;
                    checkbox1.Margin = margin1;
                    var index1 = ModListBox.Items.Add(checkbox1);
                    continue;
                }
               
                var checkbox = new CheckBox()
                    { Content = mod[0], IsChecked = false, BorderThickness = new Thickness(2, 2, 2, 2) };
                var margin = checkbox.Margin;
                margin.Top = 5;
                checkbox.Margin = margin;
                var index = ModListBox.Items.Add(checkbox);
            }
        }



        private async void InstallButton_Click(object sender, RoutedEventArgs e)
        {
            InstallProgress.Content = "Installing...";
            await _BSMods.InstallMods(ModListBox);
            InstallProgress.Content = "Installation Completed";
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {

            _BSMods.Database.Login(UsernameInput.Text, PasswordInput.Text);
        }


        private void Expander_Collapsed(object sender, RoutedEventArgs e)
        {
            Main.Effect = null;
        }

        private void Expander_ContextMenuOpening(object sender, ContextMenuEventArgs e)
        {
         
        }

        private void Expander_ContextMenuClosing(object sender, ContextMenuEventArgs e)
        {
        
        }

        private void Expander_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {

        }

        private void Expander_Expanded(object sender, RoutedEventArgs e)
        {
            Main.Effect = new BlurEffect();
        }

        private void ChooseLocationButton_Click(object sender, RoutedEventArgs e)
        {
            var folderDialog = new CommonOpenFileDialog();
            folderDialog.IsFolderPicker = true;
            var result = folderDialog.ShowDialog();

            if (result == CommonFileDialogResult.Ok)
            {
                _BSMods.beatSaberPath = folderDialog.FileName;
                bsLocationLabel.Content = _BSMods.beatSaberPath;
            }
            

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Header_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);

            // Begin dragging the window
            this.DragMove();
        }

        private void ExitButton_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Close();
        }

        private void ExitButton_MouseEnter(object sender, MouseEventArgs e)
        {
            ExitButton.Foreground = new SolidColorBrush(Colors.Red);

        }

        private void ExitButton_MouseLeave(object sender, MouseEventArgs e)
        {
            ExitButton.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFA00606"));

        }

        private void UsernameInput_MouseDown(object sender, MouseButtonEventArgs e)
        {
   
        }

        private void UsernameInput_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (UsernameInput.Text == "Username")
            {
                UsernameInput.Text = "";
            }
        }

        private void PasswordInput_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (PasswordInput.Text == "Password")
            {
                PasswordInput.Text = "";
            }
        }
    }
}
