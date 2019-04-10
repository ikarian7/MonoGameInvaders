
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
		//SpriteFont scoreFont;

        Player thePlayer;
        Bullet theBullet;
		EnemyShip theEnemyShip;

		int nInvaders = 5;
		List<GameObject> gameObjects = new List<GameObject>();

		int nShields = 4;
		//List<Shield> shields = new List<Shield>();

		//int gameScore = 0;
		//Boolean canUpdateScore = false;

        public Game1() : base() {
            graphics = new GraphicsDeviceManager(this);            
            graphics.PreferredBackBufferHeight = 600;
            graphics.PreferredBackBufferWidth = 800;
            graphics.ApplyChanges();

            Content.RootDirectory = "Content";
			//scoreFont = Content.Load<SpriteFont>("fonts/score");
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
			gameObjects.Add(thePlayer);
			theBullet = new Bullet();
			gameObjects.Add(theBullet);
			theEnemyShip = new EnemyShip();
			gameObjects.Add(theEnemyShip);
			for(int iInvader = 0; iInvader < nInvaders; iInvader++) {
				Invader newInvader = new RedInvader();
				gameObjects.Add(newInvader);

				newInvader = new YellowInvader();
				gameObjects.Add(newInvader);

				newInvader = new GreenInvader();
				gameObjects.Add(newInvader);

				newInvader = new BlueInvader();
				gameObjects.Add(newInvader);
			}
			for(int iShield = 0; iShield < nShields; iShield++) {
				Shield newShield = new Shield(iShield);
				gameObjects.Add(newShield);
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

            //Update the game objects
			foreach(GameObject aGameObject in gameObjects) {
				aGameObject.Update();
				foreach(GameObject aCollidingGameObject in gameObjects) {
					if(Overlaps(aGameObject.position, aCollidingGameObject.position, aGameObject.texture, aCollidingGameObject.texture)) {
						if(aGameObject is Shield && (aCollidingGameObject is Invader || aCollidingGameObject is Bullet)) {
							aGameObject.Delete();
							aCollidingGameObject.Init();
						} else if(aGameObject is Bullet && (aCollidingGameObject is EnemyShip || aCollidingGameObject is Invader)) {
							aGameObject.Init();
							if(aCollidingGameObject is EnemyShip) {
								aCollidingGameObject.lives--;
								if(aCollidingGameObject.lives < 1) {
									aCollidingGameObject.Delete();
								}
							} else {
								aCollidingGameObject.Init();
							}
						}
					}
				}
				
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
			foreach(GameObject aGameObject in gameObjects) {
				aGameObject.Draw();
			}

			spriteBatch.Draw(scanlines, Global.screenRect, Color.White);
			//spriteBatch.DrawString(scoreFont, gameScore.ToString(), new Vector2(Global.width - 100, 10), Color.White);

			spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}