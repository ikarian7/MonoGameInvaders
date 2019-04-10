using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonoGameInvaders
{
    class Player : GameObject {
		public Player() : base("sprites/spr_ship") {
  
        }

        public override void Init() {
            position.X = Global.width / 2 - texture.Width/2; // horizontal center on screen
            position.Y = Global.height - texture.Height; // bottom of screen
        }

        public override void Update() {
            // Assume player is not moving
            velocity.X = 0;

			// Alter velocity when keys are pressed
			if(Global.keys.IsKeyDown(Keys.Left)) {
				velocity.X = -10.0f;
			}

			if(Global.keys.IsKeyDown(Keys.Right)) {
				velocity.X = 10.0f;
			}

            position += velocity;

            // "clamp" the x-position to make sure it never goes out of screen bounds           
            position.X = MathHelper.Clamp(position.X, 0, Global.width - texture.Width);
        }
    }
}