﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Flappy_Fraud
{
    public class Bird : Game
    {
        public Texture2D texture { get; set; }
        public Vector2 position { get; set; }
        public int animationFrame { get; set; }
        public int currentFrame { get; set; }
        public int speed { get; set; }
        public int X, Y;

        public Rectangle[] spriteAnimation =
        {
            new Rectangle(0,0,34,24),
            new Rectangle(34,0,34,24),
            new Rectangle(68,0,34,24),
        };
    }
}
