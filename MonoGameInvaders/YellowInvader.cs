using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGameInvaders {
	class YellowInvader : Invader {
		public YellowInvader() : base("sprites/enemies/spr_yellow_invader") {

		}

		public override void Init() {
			velocity.X = 2.5f;
			velocity.Y = 15;
			base.Init();
		}

		public override void Update() {
			base.Update();
			frameCounter++;
			if(frameCounter == 10) {
				position.Y += velocity.Y;
			} else if(frameCounter == 20) {
				position.Y -= velocity.Y;
				frameCounter = 0;
			}
		}

	}
}
