using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGameInvaders {
	class Shield {
		public Vector2 position;
		public Texture2D texture;

		public int shieldNumber;

		public Shield(int shieldNumber) {
			texture = Global.content.Load<Texture2D>("sprites/spr_shield");

			this.shieldNumber = shieldNumber;
			Init();
		}

		public void Init() {
			position.X = (Global.width / 4) * (this.shieldNumber) + Global.width/12;
			position.Y = Global.height - 150;
		}

		public void Update() {
		}

		public void Delete() {
			//deleteShield = null;
			position.X = -1000;
		}

		public void Draw() {
			Global.spriteBatch.Draw(texture, position, Color.White);
		}
	}


}
