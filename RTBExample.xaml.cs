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
using System.Windows.Shapes;

namespace Prog122_S24_L13_RTBAdv
{
    /// <summary>
    /// Interaction logic for RTBExample.xaml
    /// </summary>
    public partial class RTBExample : Window
    {
        public RTBExample()
        {
            InitializeComponent();

            // FlowDocument - Full Page - Collection of Paragraphs 
            FlowDocument fd = new FlowDocument();
            rtbDisplay.Document = fd;

            // Paragraph - Collection of Sentences ( Run )
            Paragraph firstParagraph = new Paragraph();

            // Run - Single Sentence
            Run singleSentence = new Run("Single Sentence");
            singleSentence.FontStyle = FontStyles.Italic;

            Run secondSentence = new Run("Second Sentence");
            secondSentence.FontWeight = FontWeights.Bold;

            // Paragraph.Inlines is a collection you add a run to
            firstParagraph.Inlines.Add(singleSentence);
            firstParagraph.Inlines.Add(secondSentence);

            // FlowDocument.Blocks is a collection you add a Paragraph to
            fd.Blocks.Add(firstParagraph);
        }
    }
}
