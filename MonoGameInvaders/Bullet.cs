using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGameInvaders {
    class Bullet : GameObject {
        public Boolean isFired = false;

        public Bullet() : base("sprites/spr_bullet") {

        }

        public override void Init() {
			base.Init();

            isFired = false;

			position.X = -1000;
			position.Y = -1000;
			velocity.X = 0;
			velocity.Y = 0;
        }

        public override void Update() {
            if(isFired) {
                if(position.Y < 0) {
                    Init();
                }
                position += velocity;
            }
        }

        public void Fire(Vector2 startPosition) {
			if(!isFired) {
				isFired = true;
				this.position = startPosition;
				velocity.Y = -3;
			}
        }

    }
}
