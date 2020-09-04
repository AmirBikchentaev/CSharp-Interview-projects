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
    /// /**/
    /// </summary>
    /*[27.06 7:53] Бикчентаев Амир Ильясович
    Ну, от того что было с самого начала, что скидывал в первой версии +

1) чтобы при создании одной ноды или групп можно было конфигурировать их типы в сети
2) само собой нахождение каких нибудь строгих компонент связности// мостов/ точек сочленения (уязвимых нод у графа)
3) проработать алгоритмы поиска кратчайших путей
4) сделать динамическую(анимированную) проработку  работы алгоритмов(визуализацию) 
5) ну и по мелочи при наведение на ноду отображение информации по объекту
*/
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


        //drawing button by inserted elements
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow Form = Application.Current.Windows[0] as MainWindow;
            
            string color  = (ColorPickerForm.SelectedColorText);
            
            

            int nodesAmount = Int32.Parse(textboxfromnodes.Text);
            string Type = comboboxik.Text;
            Interraction inter = new Interraction();

            inter.drawThemALl(Interraction.randomizer(nodesAmount), Form.background,color, Type);
           

            


        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
        }

        private void loadled(object sender, RoutedEventArgs e)
        {
            foreach (var item in Enum.GetValues(typeof(point.TypeEnum)))
            {
                comboboxik.Items.Add(item);
            }
        }
    }
}
