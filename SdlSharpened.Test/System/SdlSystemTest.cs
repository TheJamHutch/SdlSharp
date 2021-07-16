using System;
using Xunit;
using SdlSharpened;
using NSubstitute;
using FluentAssertions;

namespace SdlSharpened.Test
{
    public class SdlSystemTest
    {
        // TODO: Need to mock DLL calls?

        [Fact (DisplayName = "Should init everything")]
        public void ShouldInitEverything()
        {
            bool init = SdlSystem.Init();

            init.Should().BeTrue();

            // TODO: Check all subsystems init
        }

        [Fact (DisplayName = "Should init subsystem")]
        public void ShouldInitSubsystem()
        {
            bool init = SdlSystem.InitSubSystem(InitFlags.Events);

            init.Should().BeTrue();

            // TODO: Check subsystem init
        }

        [Fact (DisplayName = "Should delay")]
        public void ShouldDelay()
        {
            SdlSystem.Init();

            uint interval = 1000;
            uint before, after, difference = 0;

            before = SdlSystem.Ticks();
            SdlSystem.Delay(interval);
            after = SdlSystem.Ticks();
            difference = after - before;

            after.Should().BeGreaterThan(before);
            difference.Should().Be(interval);

            SdlSystem.Quit();
        }

        [Fact (DisplayName = "Should get version")]
        public void ShouldGetVersion() 
        {
            string verStr = SdlSystem.Version();

            verStr.Should().NotBeNull();
            verStr.Should().NotBeEmpty();
            verStr.Should().Contain("SDL2: ");
            verStr.Should().Contain(".");
        }
    }
}
 