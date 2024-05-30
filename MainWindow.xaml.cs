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

namespace Prog122_S24_L13_RTBAdv
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            FontSizeComboBox.SelectedIndex = 2;

        } // MainWindow()

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            // 1. Grab the text from the title text box and the paragraph rich text box.
            string title = TitleTextBox.Text;
            string paragraphText = runParagraphText.Text;

            // 2. Create an instance of run for each string
            Run runTitle = new Run(title);
            Run runParagraph = new Run(paragraphText);

            // 3. Create 2 paragraphs, because a paragraph will go to the next line
            Paragraph p1 = new Paragraph(runTitle);
            Paragraph p2 = new Paragraph(runParagraph);

            // 4. Create an instance of FlowDocument. Add our paragraphs to the .Blocks.Add()
            FlowDocument entirePage = new FlowDocument();
            entirePage.Blocks.Add(p1);
            entirePage.Blocks.Add(p2);

            // Grabbing the Text Style to apply
            if(BoldRadioButton.IsChecked.Value)
            {
                entirePage.FontWeight = FontWeights.Bold;
            }
            else if (ItalicRadioButton.IsChecked.Value)
            {
                entirePage.FontStyle = FontStyles.Italic;
            }
            else if (UnderlineRadioButton.IsChecked.Value)
            {
                foreach (Paragraph item in entirePage.Blocks)
                {
                    item.TextDecorations = TextDecorations.Underline;
                }
            }
            



            //MessageBox.Show(FontSizeComboBox.SelectedValue);
            //double fontSize = double.Parse(FontSizeComboBox.SelectedValue.ToString());

            entirePage.FontSize = GetFontSize();
            

            // 5. Add the FlowDocument to the RichTextBox
            FormattedRichTextBox.Document = entirePage;

        }

        public double GetFontSize()
        {
            ComboBoxItem cbi = FontSizeComboBox.SelectedItem as ComboBoxItem;
            string content = cbi.Content.ToString();
            double fontSize = double.Parse(content);
            return fontSize;
        }

    } // class

} // namespace