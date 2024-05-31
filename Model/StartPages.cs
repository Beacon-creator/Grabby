using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Maui.Controls;
using Microsoft.Maui;

namespace Grabby_Two.Model
{ 
        public sealed class CarouselItem
        {
            public string? ImageUrl { get; set; }
            public string? Text { get; set; }
            public string? Text2 { get; set; }
            public Color? IndicatorColor { get; set; } // Add this property
        }
    
}