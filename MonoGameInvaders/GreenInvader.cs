using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGameInvaders {
	class GreenInvader : Invader {
		public GreenInvader() : base("sprites/enemies/spr_green_invader") {

		}

		public override void Init() {
			base.Init();
			velocity.X = 2;
			velocity.Y = 0.3f;
		}

		public override void Update() {
			position.X += velocity.X;
			position.Y += velocity.Y;

			if(position.Y > Global.height) {
				Init();
			} else if((position.X > Global.width - texture.Width) || (position.X < 0)) {
				position.X -= velocity.X;
				velocity.X *= -1;
				//position.Y -= velocity.Y;
				//velocity.Y *= -1;
			}
		}
	}
}
