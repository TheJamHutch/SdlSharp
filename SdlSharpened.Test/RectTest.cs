using System;
using Xunit;
using SdlSharpened;
using FluentAssertions;

namespace SdlSharpened.Test
{
    public class RectTest
    {
        [Fact (DisplayName = "Should construct default rect")]
        public void ShouldConstructRectWithDefaults()
        {
            Rect rect = new Rect();

            rect.X.Should().Be(0);
            rect.Y.Should().Be(0);
            rect.W.Should().Be(1); 
            rect.H.Should().Be(1);
        }

        [Fact (DisplayName = "Should construct rect with specified width and height")]
        public void ShouldConstructRectWithSpecifiedWidthAndHeight()
        {
            int w = 12;
            int h = 160;

            Rect rect = new Rect(w, h);

            rect.X.Should().Be(0);
            rect.Y.Should().Be(0);
            rect.W.Should().Be(w);
            rect.H.Should().Be(h);
        }

        [Fact (DisplayName = "Should construct specific rect")]
        public void ShouldConstructSpecificRect()
        {
            int x = 100;
            int y = 234;
            int w = 64;
            int h = 12;

            Rect rect = new Rect(x, y, w, h);

            rect.X.Should().Be(x);
            rect.Y.Should().Be(y);
            rect.W.Should().Be(w);
            rect.H.Should().Be(h);
        }
    }
}
