using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGameInvaders {
	class GameObject {
		public Vector2 position; //Current position of the object
		public Vector2 velocity; //Travelspeed of the object
		public Texture2D texture; //The sprite of the object

		public int frameCounter;

		public int lives; //The lives of an object
		public int startingDirection; //Only used by the EnemyShip and Invader classes
		public Boolean isEnemy; //Specifies whether the object is an enemy

		public GameObject(String textureName) {
			//The texture of the object will be loaded using the location given by the child class
			texture = Global.content.Load<Texture2D>(textureName);
			Init();
		}

		public virtual void Init() {
			if(isEnemy) {
				//The startingDirection for the enemies will be randomized
				startingDirection = Global.Random(-1, 3);
				if(startingDirection == 0) {
					startingDirection = -1;
				} else if(startingDirection == 2) {
					startingDirection = 1;
				}
				velocity.X *= startingDirection;
			}
		}

		public virtual void Update() {
			if(isEnemy) {
				position.X += velocity.X;
				if(position.Y > Global.height) {
					Init();
				} else if((position.X > Global.width - texture.Width) || (position.X < 0)) {
					position.X -= velocity.X;
					velocity.X *= -1;
					position.Y += velocity.Y;
				}
			}
		}

		public virtual void Delete() {
			position.X = -1000;
			position.Y = -1000;
		}

		public virtual void Draw() {
			Global.spriteBatch.Draw(texture, position, Color.White);
		}
	}
}