using System;
using System.Collections.Generic;
using System.Text;

namespace SdlSharpened.App
{
    public class EntitiesConfig
    {
        // Player config
        public Point PlayerSpriteSize { get; } = new Point(32, 32);
        public string PlayerSheetPath { get; } = "..\\..\\..\\Game\\img\\player.bmp";
        public MoveSpeed PlayerMoveSpeed { get; } = MoveSpeed.Medium;

        // Camera config
        public MoveSpeed CameraMoveSpeed { get; } = MoveSpeed.Medium;
    }
}
