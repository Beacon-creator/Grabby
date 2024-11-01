

namespace Grabby_Two.Custom_Render
    {
    public class AutoFocusBehavior : Behavior<BorderlessEntry>
        {
        public BorderlessEntry? NextEntry { get; set; }
        public BorderlessEntry? PreviousEntry { get; set; }

        protected override void OnAttachedTo(BorderlessEntry bindable)
            {
            base.OnAttachedTo(bindable);
            bindable.TextChanged += OnTextChanged;
            bindable.Unfocused += OnUnfocused;
            }

        protected override void OnDetachingFrom(BorderlessEntry bindable)
            {
            base.OnDetachingFrom(bindable);
            bindable.TextChanged -= OnTextChanged;
            bindable.Unfocused -= OnUnfocused;
            }

        private void OnTextChanged(object sender, TextChangedEventArgs e)
            {
            var entry = sender as BorderlessEntry;
            if (entry?.Text != null && entry.Text.Length == 1 && NextEntry != null)
                {
                NextEntry.Focus();
                }
            }

        private void OnUnfocused(object sender, FocusEventArgs e)
            {
            var entry = sender as BorderlessEntry;
            if (entry?.Text != null && entry.Text.Length == 0 && PreviousEntry != null)
                {
                PreviousEntry.Focus();
                }
            }
        }
    }
