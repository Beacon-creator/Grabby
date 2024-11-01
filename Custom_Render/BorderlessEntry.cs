

namespace Grabby_Two.Custom_Render
    {
    public class BorderlessEntry : Entry
        {
        // Property to enable MM/YY formatting
        public bool EnableMMYYFormatting { get; set; } = false;

        public BorderlessEntry()
            {
            Initialize();
            }

        private void Initialize()
            {
            TextChanged += OnTextChanged;
            }

        private void OnTextChanged(object sender, TextChangedEventArgs e)
            {
            if (!EnableMMYYFormatting)
                return; // Exit if MM/YY formatting is not enabled

            if (string.IsNullOrWhiteSpace(e.NewTextValue))
                return;

            // Remove non-numeric characters
            var cleanedText = new string(e.NewTextValue.Where(c => char.IsDigit(c)).ToArray());

            // Handle MM/YY format
            if (cleanedText.Length > 4)
                cleanedText = cleanedText.Substring(0, 4);

            // Insert '/' between MM and YY if needed
            if (cleanedText.Length >= 3 && e.NewTextValue.Length > e.OldTextValue.Length)
                {
                cleanedText = cleanedText.Insert(2, "/");
                }

            // Update the entry text
            if (Text != cleanedText)
                {
                Text = cleanedText;
                }
            }
        }
    }
