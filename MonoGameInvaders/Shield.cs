using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGameInvaders {
	class Shield : GameObject {
		public int shieldNumber;

		public Shield(int shieldNumber) : base("sprites/spr_shield") {
			this.shieldNumber = shieldNumber;
			lives = 1;
			Init();
		}

		public override void Init() {
			position.X = (Global.width / 4) * (this.shieldNumber) + Global.width/12;
			position.Y = Global.height - 150;
		}
	}
}