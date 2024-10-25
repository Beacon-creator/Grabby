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
    public class PasswordValidationBehavior : Behavior<BorderlessEntry>
        {
        public const string PasswordRegex = @"^(?=.*[A-Za-z])(?=.*\d)(?=.*[$@$!%*#?&])[A-Za-z\d$@$!/.%*#?&]{6,}$";

        public static readonly BindableProperty IsValidProperty = BindableProperty.Create(
            nameof(IsValid),
            typeof(bool),
            typeof(PasswordValidationBehavior),
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
            IsValid = Regex.IsMatch(e.NewTextValue, PasswordRegex);
            Console.WriteLine($"Password Valid: {IsValid}");
            ((BorderlessEntry)sender).TextColor = IsValid ? Colors.Black : Colors.Red;

          
            }

        protected override void OnDetachingFrom(BorderlessEntry bindable)
            {
            bindable.TextChanged -= HandleTextChanged;
            base.OnDetachingFrom(bindable);
            }
        }
    }