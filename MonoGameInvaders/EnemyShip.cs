using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGameInvaders {
	class EnemyShip {

		public Vector2 position;
		public Vector2 velocity;
		public Texture2D texture;

		public int enemyShipLives;

		public EnemyShip() {
			texture = Global.content.Load<Texture2D>("sprites/enemies/spr_enemy_ship");
			Init();
		}

		public void Init() {
			position.X = Global.width/2;
			position.Y = 50;

			velocity.X = 4;
			enemyShipLives = 2;
		}

		public void Update() {
			position.X += velocity.X;

			if((position.X > Global.width - texture.Width) || (position.X < 0)) {
				position.X -= velocity.X;
				velocity.X *= -1;
			}
		}

		public void Draw() {
			Global.spriteBatch.Draw(texture, position, Color.White);
		}
	}
}