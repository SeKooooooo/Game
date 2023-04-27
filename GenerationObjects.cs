using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Project1.StateGame;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;

namespace Project1
{
    class GenerationObjects
    {
        public static Random Random = new Random(); 
        public static Vector2 GeneratePos(float height)
        {
            return new Vector2(Random.Next(1920,4000),Random.Next(215,875-(int)height));
        }
    }
}
