using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGameInvaders {
	class BlueInvader : Invader {
		public BlueInvader() : base("sprites/enemies/spr_blue_invader") {

		}

		public override void Init() {
			velocity.X = 2.2f;
			velocity.Y = 2.2f;
			base.Init();
		}

		public override void Update() {
			base.Update();
			frameCounter++;
			if(frameCounter > -1 && frameCounter < 41) {
				position.Y += velocity.Y;
			} else if(frameCounter > 40 && frameCounter < 81) {
				position.Y -= velocity.Y;
				if(frameCounter == 80) {
					frameCounter = 0;
				}
			}
		}
	}
}
