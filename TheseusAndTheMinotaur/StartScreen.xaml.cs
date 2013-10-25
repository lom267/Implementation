using System;
using System.Collections.Generic;
using System.Linq;
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

namespace TheseusAndTheMinotaur
{
    /// <summary>
    /// Interaction logic for StartScreen.xaml
    /// </summary>
    public partial class StartScreen : Page
    {
        public StartScreen()
        {
            InitializeComponent();
        }

        private void btnGamePlayer_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnLevelDesigner_Click(object sender, RoutedEventArgs e)
        {
            LevelDesignerPage levelDesignerPage = new LevelDesignerPage();
            this.NavigationService.Navigate(levelDesignerPage);
        }
    }
}
