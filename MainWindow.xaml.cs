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
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            // Get the title and paragraph content
            string title = TitleTextBox.Text;
            TextRange paragraphTextRange = new TextRange(ParagraphRichTextBox.Document.ContentStart, ParagraphRichTextBox.Document.ContentEnd);

            // Get the font size
            double fontSize = 12;
            if (FontSizeComboBox.SelectedItem != null)
            {
                string selectedFontSize = (FontSizeComboBox.SelectedItem as ComboBoxItem).Content.ToString();
                fontSize = double.Parse(selectedFontSize);
            }

            // Get the text style
            FontWeight fontWeight = FontWeights.Normal;
            FontStyle fontStyle = FontStyles.Normal;
            TextDecorationCollection textDecorations = null;

            if (ItalicRadioButton.IsChecked == true)
            {
                fontStyle = FontStyles.Italic;
            }
            if (BoldRadioButton.IsChecked == true)
            {
                fontWeight = FontWeights.Bold;
            }
            if (UnderlineRadioButton.IsChecked == true)
            {
                textDecorations = TextDecorations.Underline;
            }

            // Create the formatted text block
            Paragraph formattedParagraph = new Paragraph();

            // Add title
            if (!string.IsNullOrEmpty(title))
            {
                Run titleRun = new Run(title)
                {
                    FontWeight = fontWeight,
                    FontSize = fontSize,
                    FontStyle = fontStyle,
                    TextDecorations = textDecorations
                };
                formattedParagraph.Inlines.Add(titleRun);
                formattedParagraph.Inlines.Add(new LineBreak());
            }

            // Add paragraph text
            Run paragraphRun = new Run(paragraphTextRange.Text)
            {
                FontWeight = fontWeight,
                FontSize = fontSize,
                FontStyle = fontStyle,
                TextDecorations = textDecorations
            };
            formattedParagraph.Inlines.Add(paragraphRun);

            // Add the formatted paragraph to the display RichTextBox
            FormattedRichTextBox.Document.Blocks.Add(formattedParagraph);
        }
    }
}