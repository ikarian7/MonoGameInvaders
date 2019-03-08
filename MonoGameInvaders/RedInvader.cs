using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGameInvaders {
	class RedInvader : Invader {
		public RedInvader() : base("sprites/enemies/spr_red_invader") {
		}

		public override void Init() {
			base.Init();
			velocity.X = 3;
			velocity.Y = 10;
		}

		public override void Update() {
			base.Update();
		}
	}
}
