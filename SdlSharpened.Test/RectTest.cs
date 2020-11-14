using System;
using Xunit;
using SdlSharpened;
using NSubstitute;
using FluentAssertions;

namespace SdlSharpened.Test
{
    public class RectTest
    {
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

        [Fact (DisplayName = "Should return true if rect is equal to another rect")]
        public void ShouldReturnTrueIfRectIsEqualToAnotherRect() 
        {
            Rect rect1 = new Rect(0, 1, 2, 3);
            Rect rect2 = new Rect(0, 1, 2, 3);

            var result = rect1.IsEqualTo(rect2);

            result.Should().BeTrue();
        }

        [Fact (DisplayName = "Should return false if rect is not equal to another rect")]
        public void ShouldReturnFalseIfRectIsNotEqualToAnotherRect()
        {
            Rect rect1 = new Rect(0, 1, 2, 3);
            Rect rect2 = new Rect(4, 5, 6, 7);

            var result = rect1.IsEqualTo(rect2);

            result.Should().BeFalse();
        }
    }
}
