Using RichTextBox in WPF involves several steps to set up, format, and manipulate text. Here's a comprehensive guide to help you get started:

### 1. Setting Up the Environment

1. **Create a WPF Project:**
   - Open Visual Studio.
   - Create a new WPF App (.NET Core) project.

2. **Add a RichTextBox to Your XAML:**
   - Open the MainWindow.xaml file.
   - Add a `RichTextBox` control to the window.

   ```xml
   <Window x:Class="YourNamespace.MainWindow"
           xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
           xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
           Title="RichTextBox Example" Height="350" Width="525">
       <Grid>
           <RichTextBox Name="richTextBox" VerticalAlignment="Stretch" HorizontalAlignment="Stretch"/>
       </Grid>
   </Window>
   ```

### 2. Basic Usage

1. **Setting Text:**
   - You can set text programmatically in the `RichTextBox` using its `Document` property.
   
   ```csharp
   using System.Windows;
   using System.Windows.Documents;

   namespace YourNamespace
   {
       public partial class MainWindow : Window
       {
           public MainWindow()
           {
               InitializeComponent();
               SetInitialText();
           }

           private void SetInitialText()
           {
               // Create a new FlowDocument
               FlowDocument flowDoc = new FlowDocument();

               // Add a paragraph with some text
               Paragraph para = new Paragraph(new Run("Hello, World!"));
               flowDoc.Blocks.Add(para);

               // Assign the FlowDocument to the RichTextBox
               richTextBox.Document = flowDoc;
           }
       }
   }
   ```

2. **Formatting Text:**
   - To format text, you can apply various properties like `FontWeight`, `FontStyle`, `FontSize`, and `Foreground`.

   ```csharp
   private void SetFormattedText()
   {
       // Create a new FlowDocument
       FlowDocument flowDoc = new FlowDocument();

       // Create a new paragraph
       Paragraph para = new Paragraph();

       // Add some text with different formatting
       para.Inlines.Add(new Run("This is bold text. ") { FontWeight = FontWeights.Bold });
       para.Inlines.Add(new Run("This is italic text. ") { FontStyle = FontStyles.Italic });
       para.Inlines.Add(new Run("This is colored text. ") { Foreground = Brushes.Blue });
       
       flowDoc.Blocks.Add(para);

       // Assign the FlowDocument to the RichTextBox
       richTextBox.Document = flowDoc;
   }
   ```

### 3. Handling User Input

1. **Retrieve Text:**
   - To retrieve text from the `RichTextBox`, you need to extract the `TextRange` of its `Document`.

   ```csharp
   private string GetTextFromRichTextBox()
   {
       TextRange textRange = new TextRange(
           richTextBox.Document.ContentStart,
           richTextBox.Document.ContentEnd
       );

       return textRange.Text;
   }
   ```

2. **Detect Text Changes:**
   - You can handle the `TextChanged` event to detect when the user modifies the content.

   ```csharp
   private void richTextBox_TextChanged(object sender, TextChangedEventArgs e)
   {
       // Handle the text change event
       string currentText = GetTextFromRichTextBox();
       MessageBox.Show("Text changed: " + currentText);
   }
   ```

   Make sure to add the event handler in XAML:

   ```xml
   <RichTextBox Name="richTextBox" VerticalAlignment="Stretch" HorizontalAlignment="Stretch"
                TextChanged="richTextBox_TextChanged"/>
   ```

### 4. Advanced Formatting

1. **Apply Different Text Formatting:**
   - You can create more complex text layouts using `Inline` elements like `Bold`, `Italic`, and `Underline`.

   ```csharp
   private void ApplyAdvancedFormatting()
   {
       FlowDocument flowDoc = new FlowDocument();
       Paragraph para = new Paragraph();

       para.Inlines.Add(new Bold(new Run("Bold text ")));
       para.Inlines.Add(new Italic(new Run("Italic text ")));
       para.Inlines.Add(new Underline(new Run("Underlined text ")));
       para.Inlines.Add(new Run("Normal text"));

       flowDoc.Blocks.Add(para);
       richTextBox.Document = flowDoc;
   }
   ```

2. **Handling Hyperlinks:**
   - You can add hyperlinks that users can click.

   ```csharp
   private void AddHyperlink()
   {
       FlowDocument flowDoc = new FlowDocument();
       Paragraph para = new Paragraph();

       Hyperlink link = new Hyperlink(new Run("Click here to visit Google"))
       {
           NavigateUri = new Uri("http://www.google.com")
       };
       link.RequestNavigate += (sender, e) =>
       {
           System.Diagnostics.Process.Start(e.Uri.ToString());
       };

       para.Inlines.Add(link);
       flowDoc.Blocks.Add(para);

       richTextBox.Document = flowDoc;
   }
   ```

### Summary

- **Setting Up:** Create a WPF project and add a `RichTextBox` control.
- **Basic Usage:** Set and format text programmatically using `FlowDocument` and `Paragraph`.
- **Handling User Input:** Retrieve text and handle text changes using events.
- **Advanced Formatting:** Apply advanced text formatting and handle hyperlinks.

With these steps, you should have a good foundation for using `RichTextBox` in your WPF applications.