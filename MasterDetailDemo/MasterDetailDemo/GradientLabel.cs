﻿using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MasterDetailDemo
{
    public class GradientLabel : Label
    {
        public static readonly BindableProperty TextColor1Property = BindableProperty.Create(
        propertyName: nameof(TextColor1),
        returnType: typeof(Color),
        declaringType: typeof(Color),
        defaultValue: Color.Red);

        public Color TextColor1
        {
            get => (Color)GetValue(TextColor1Property);
            set => SetValue(TextColor1Property, value);
        }

        public static readonly BindableProperty TextColor2Property = BindableProperty.Create(
            propertyName: nameof(TextColor2),
            returnType: typeof(Color),
            declaringType: typeof(Color),
            defaultValue: Color.Green);

        public Color TextColor2
        {
            get => (Color)GetValue(TextColor2Property);
            set => SetValue(TextColor2Property, value);
        }
    }
}
