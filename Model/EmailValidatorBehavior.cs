using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.Maui.Graphics;
using Microsoft.Maui.Controls;
using Microsoft.Maui;
using Grabby_Two.Custom_Render;
using Grabby_Two.ViewModel;

namespace Grabby_Two.Model
    {
    public class EmailValidatorBehavior : Behavior<BorderlessEntry>
        {
        public static readonly string EmailRegex = @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
            @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$";

        public static readonly BindableProperty IsValidProperty = BindableProperty.Create(
            nameof(IsValid),
            typeof(bool),
            typeof(EmailValidatorBehavior),
            false,
            BindingMode.OneWayToSource);

        public bool IsValid
            {
            get => (bool)GetValue(IsValidProperty);
            set => SetValue(IsValidProperty, value);
            }

        protected override void OnAttachedTo(BorderlessEntry bindable)
            {
            bindable.TextChanged += HandleTextChanged;
            base.OnAttachedTo(bindable);
            }

        void HandleTextChanged(object sender, TextChangedEventArgs e)
            {
            IsValid = Regex.IsMatch(e.NewTextValue, EmailRegex, RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            Console.WriteLine($"Email Valid: {IsValid}");
            ((BorderlessEntry)sender).TextColor = IsValid ? Colors.Black : Colors.Red;

        
            }

        protected override void OnDetachingFrom(BorderlessEntry bindable)
            {
            bindable.TextChanged -= HandleTextChanged;
            base.OnDetachingFrom(bindable);
            }
        }
    }
