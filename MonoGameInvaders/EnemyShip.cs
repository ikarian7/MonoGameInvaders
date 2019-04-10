using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGameInvaders {
	class EnemyShip : GameObject {
		public EnemyShip() : base("sprites/enemies/spr_enemy_ship") {
			isEnemy = true;
		}

		public override void Init() {
			base.Init();
			position.X = Global.width/2;
			position.Y = 50;

			velocity.X = 4;
			velocity.Y = 0;

			lives = 2;
		}
	}
}