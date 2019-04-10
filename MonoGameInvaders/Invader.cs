using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGameInvaders {
	class Invader : GameObject {
		//public int frameCounter = 0;

		public Invader(String assetName) : base(assetName) {
			isEnemy = true;
		}

		public override void Init() {
			base.Init();
			lives = 1;
			position.X = Global.Random(100, Global.width - 100);
			position.Y = Global.Random(-100, -texture.Height - 1);
			//position.Y = Global.Random(75, Global.height - 400); // Om dingen met de invader direct te kunnen testen
		}

		public override void Update() {
			base.Update();
		}
	}
}