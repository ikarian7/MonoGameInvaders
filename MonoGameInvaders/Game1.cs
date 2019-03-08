
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonoGameInvaders
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Game {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D background, scanlines;
		SpriteFont scoreFont;

        Player thePlayer;
        Bullet theBullet;
		EnemyShip theEnemyShip;

		int nInvaders = 5;
		List<Invader> invaders = new List<Invader>();

		int nShields = 4;
		List<Shield> shields = new List<Shield>();

		int gameScore = 0;
		Boolean canUpdateScore = false;

        public Game1() : base() {
            graphics = new GraphicsDeviceManager(this);            
            graphics.PreferredBackBufferHeight = 600;
            graphics.PreferredBackBufferWidth = 800;
            graphics.ApplyChanges();

            Content.RootDirectory = "Content";
			scoreFont = Content.Load<SpriteFont>("fonts/score");
		}

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize() {
            // Pass often referenced variables to Global
            Global.GraphicsDevice = GraphicsDevice;            
            Global.content = Content;

            // Create and Initialize game objects
            thePlayer = new Player();
            theBullet = new Bullet();
			theEnemyShip = new EnemyShip();
			for(int iInvader = 0; iInvader < nInvaders; iInvader++) {
				Invader newInvader = new RedInvader();
				invaders.Add(newInvader);

				newInvader = new YellowInvader();
				invaders.Add(newInvader);

				newInvader = new GreenInvader();
				invaders.Add(newInvader);

				newInvader = new BlueInvader();
				invaders.Add(newInvader);
			}
			for(int iShield = 0; iShield < nShields; iShield++) {
				Shield newShield = new Shield(iShield);
				shields.Add(newShield);
			}
			

            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Global.spriteBatch = spriteBatch;
            background = Content.Load<Texture2D>("sprites/spr_background");
            scanlines = Content.Load<Texture2D>("sprites/spr_scanlines");
            base.Initialize();
        }

		protected Boolean Overlaps(Vector2 positionA, Vector2 positionB, Texture2D textureA, Texture2D textureB) {
			if(positionA.X > positionB.X + textureB.Width
				|| positionA.X + textureA.Width < positionB.X
				|| positionA.Y > positionB.Y + textureB.Height
				|| positionA.Y + textureA.Height < positionB.Y) {
				return false;
			} else {
				return true;
			}
		}

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime) {
            // Pass keyboard state to Global so we can use it everywhere
            Global.keys = Keyboard.GetState();

			if(Global.keys.IsKeyDown(Keys.Space)) {
				theBullet.Fire(thePlayer.position);
			}

            // Update the game objects
            thePlayer.Update();
            theBullet.Update();
			theEnemyShip.Update();

			foreach(Shield aShield in shields) {
				if(Overlaps(aShield.position, theBullet.position, aShield.texture, theBullet.texture)) {
					theBullet.Init();
					aShield.Delete();
				}

				aShield.Update();
			}

			foreach(Invader anInvader in invaders) {
				if(Overlaps(anInvader.position, theBullet.position, anInvader.texture, theBullet.texture)) {
					theBullet.Init();
					anInvader.Init();
					gameScore += Global.Random(400, 600);
				}

				foreach(Shield aShield in shields) {
					if(Overlaps(aShield.position, anInvader.position, aShield.texture, anInvader.texture)) {
						anInvader.Init();
						aShield.position.X = -1000;
						gameScore -= 500;
					}
				}

				if(anInvader.position.Y > Global.height - 150) {
					gameScore -= 500;
				}

				anInvader.Update();
			}

			if(Overlaps(theEnemyShip.position, theBullet.position, theEnemyShip.texture, theBullet.texture)) {
				theEnemyShip.enemyShipLives--;
				if(theEnemyShip.enemyShipLives < 1) {
					theEnemyShip.position.X = -1000;
					gameScore += 5000;
				}
				theBullet.Init();
				theEnemyShip.Init();
			}

			if(canUpdateScore) {
				gameScore++;
				canUpdateScore = false;
			} else {
				canUpdateScore = true;
			}

            base.Update(gameTime);
		}

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime) {            
            spriteBatch.Begin();
            // Draw the background (and clear the screen)
            spriteBatch.Draw(background, Global.screenRect, Color.White);

            // Draw the game objects
            thePlayer.Draw();
            theBullet.Draw();
			theEnemyShip.Draw();
			foreach(Invader anInvader in invaders) {
				anInvader.Draw();
			}
			foreach(Shield aShield in shields) {
				aShield.Draw();
			}

			spriteBatch.Draw(scanlines, Global.screenRect, Color.White);
			spriteBatch.DrawString(scoreFont, gameScore.ToString(), new Vector2(Global.width - 100, 10), Color.White);

			spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}