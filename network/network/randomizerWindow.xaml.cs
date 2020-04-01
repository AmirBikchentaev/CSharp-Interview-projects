using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace network
{
    /// <summary>
    /// Interaction logic for randomizerWindow.xaml
    /// </summary>
    public partial class randomizerWindow : Window
    {
        public randomizerWindow()
        {
            MainWindow Form = Application.Current.Windows[0] as MainWindow;
            

            InitializeComponent();
        }

     
        public void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.Text = string.Empty;
            tb.GotFocus -= TextBox_GotFocus;
        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow Form = Application.Current.Windows[0] as MainWindow;
            string color  = (ColorPickerForm.SelectedColorText);
            
            

            int nodesAmount = Int32.Parse(textboxfromnodes.Text);
            Interraction.drawThemALl(Interraction.randomizer(nodesAmount), Form.background,color);



        }
    }
}
