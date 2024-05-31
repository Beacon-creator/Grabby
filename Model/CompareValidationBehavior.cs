using System;
using Microsoft.Maui.Controls;

namespace Grabby_Two.Model
{
    public class CompareValidationBehavior : Behavior<Entry>
    {
        public static readonly BindableProperty CompareToEntryProperty =
            BindableProperty.Create(nameof(CompareToEntry), typeof(Entry), typeof(CompareValidationBehavior), null);

        public Entry CompareToEntry
        {
            get => (Entry)GetValue(CompareToEntryProperty);
            set => SetValue(CompareToEntryProperty, value);
        }

        protected override void OnAttachedTo(Entry bindable)
        {
            base.OnAttachedTo(bindable);
            bindable.TextChanged += HandleTextChanged;
            if (CompareToEntry != null)
            {
                CompareToEntry.TextChanged += HandleTextChanged;
            }
        }

        protected override void OnDetachingFrom(Entry bindable)
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
            if (sender is Entry entry)
            {
                bool isValid = string.Equals(entry.Text, CompareToEntry?.Text);
                entry.TextColor = isValid ? Colors.Green : Colors.Red;
            }
        }
    }
}
