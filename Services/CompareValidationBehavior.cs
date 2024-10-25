using System;
using Grabby_Two.Custom_Render;
using Microsoft.Maui.Controls;

namespace Grabby_Two.Model
{
    public class CompareValidationBehavior : Behavior<BorderlessEntry>
    {
        public static readonly BindableProperty CompareToEntryProperty =
            BindableProperty.Create(nameof(CompareToEntry), typeof(BorderlessEntry), typeof(CompareValidationBehavior), null);

        public Entry CompareToEntry
        {
            get => (Entry)GetValue(CompareToEntryProperty);
            set => SetValue(CompareToEntryProperty, value);
        }

        protected override void OnAttachedTo(BorderlessEntry bindable)
        {
            base.OnAttachedTo(bindable);
            bindable.TextChanged += HandleTextChanged;
            if (CompareToEntry != null)
            {
                CompareToEntry.TextChanged += HandleTextChanged;
            }
        }

        protected override void OnDetachingFrom(BorderlessEntry bindable)
        {
            base.OnDetachingFrom(bindable);
            bindable.TextChanged -= HandleTextChanged;
            if (CompareToEntry != null)
            {
                CompareToEntry.TextChanged -= HandleTextChanged;
            }
        }

        private void HandleTextChanged(object? sender, TextChangedEventArgs e)
        {
            if (sender is BorderlessEntry entry)
            {
                bool isValid = string.Equals(entry.Text, CompareToEntry?.Text);
                entry.TextColor = isValid ? Colors.Green : Colors.Red;
            }
        }
    }
}
