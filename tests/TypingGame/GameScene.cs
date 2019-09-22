using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Ovow.Framework;
using Ovow.Framework.Messaging.GeneralMessages;
using Ovow.Framework.Scenes;
using Ovow.Framework.Services;
using Ovow.Framework.Sounds;
using Ovow.Framework.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TypingGame
{
    internal sealed class GameScene : Scene
    {
        private const string DiagTextPattern = @"[TOTAL OBJECTS] {0}";
        private static readonly Random rnd = new Random(DateTime.Now.Millisecond);
        private TimeSpan letterGenerationTimeSpan = TimeSpan.Zero;
        private TimeSpan letterGenerationTimeSpanThreshold = TimeSpan.FromMilliseconds(1000);
        private readonly Dictionary<char, Texture2D> lettersTextureDict = new Dictionary<char, Texture2D>();
        private Texture2D laserTexture;
        private SpriteFont diagTextFont;
        private SoundEffect hitSoundEffect;
        private Sound hitSound;
        private Text diagText;

        public GameScene(IOvowGame game) : base(game, Color.Black)
        {
            AutoRemoveInactiveComponents = true;

            Subscribe<ReachBoundaryMessage>((sender, message) =>
            {
                if (sender is LetterSprite letterSprite && message.ReachedBoundary == Boundary.Bottom)
                {
                    letterSprite.IsActive = false;
                }

                if (sender is LaserSprite laserSprite && message.ReachedBoundary == Boundary.Top)
                {
                    laserSprite.IsActive = false;
                }
            });

            Subscribe<CollisionDetectedMessage>((sender, message) =>
            {
                if (message.A is LetterSprite letterSprite &&
                    message.B is LaserSprite laserSprite &&
                    letterSprite.Letter == laserSprite.Letter &&
                    letterSprite.IsActive && laserSprite.IsActive)
                {
                    hitSound.Play();
                    letterSprite.IsActive = false;
                    laserSprite.IsActive = false;
                }
            });
        }

        public override void Load(ContentManager contentManager)
        {
            // Loads texture for letters.
            for (char i = 'A'; i <= 'Z'; i++)
            {
                lettersTextureDict.Add(i, contentManager.Load<Texture2D>($"{(i - 'A' + 1)}"));
            }

            // Loads texture for laser.
            laserTexture = contentManager.Load<Texture2D>("Laser");

            // Loads font textures.
            diagTextFont = contentManager.Load<SpriteFont>("diagText");
            diagText = new Text(string.Format(DiagTextPattern, this.Count), this, diagTextFont);
            this.Add(diagText);

            // Loads the Hit Sound.
            hitSoundEffect = contentManager.Load<SoundEffect>("typing");
            hitSound = new Sound(hitSoundEffect);
            this.Add(hitSound);

            // Add game services.
            this.Add(new CollisionDetectionService(this));
        }

        public override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                End();
            }

            this.letterGenerationTimeSpan += gameTime.ElapsedGameTime;
            if (this.letterGenerationTimeSpan >= letterGenerationTimeSpanThreshold)
            {
                var letterIndex = rnd.Next(0, 26);
                var letter = (char)('A' + letterIndex);

                // Make sure that there is no same letter in the current screen.
                while (true)
                {
                    if (LetterSprites.Any(l => l.Letter == letter))
                    {
                        letterIndex = rnd.Next(0, 26);
                        letter = (char)('A' + letterIndex);
                        continue;
                    }

                    break;
                }

                var letterTexture = lettersTextureDict[letter];
                var initialXPos = rnd.Next(2, ViewportWidth - letterTexture.Width);
                var speed = rnd.Next(1, 3);
                var letterSprite = new LetterSprite(this,
                    letterTexture,
                    new Vector2(initialXPos, 0F),
                    letter, speed);

                Add(letterSprite);
                this.letterGenerationTimeSpan = TimeSpan.Zero;
            }

            // Checks key press
            var pressedKeys = Keyboard.GetState().GetPressedKeys();
            LetterSprite hitLetter = null;
            foreach (var ls in LetterSprites)
            {
                if (pressedKeys.Any(pk => (int)pk == ls.Letter))
                {
                    hitLetter = ls;
                    break;
                }
            }

            if (hitLetter != null &&
                !LaserSprites.Any(l => l.Letter == hitLetter.Letter))
            {
                var laserInitialX = hitLetter.X + 18;
                var laserInitialY = ViewportHeight - laserTexture.Height;
                var laserSprite = new LaserSprite(this,
                    laserTexture,
                    new Vector2(laserInitialX, laserInitialY),
                    hitLetter.Letter);
                Add(laserSprite);
            }

            // Updates the diagnostic information text.
            diagText.Value = string.Format(DiagTextPattern, this.Count);
            base.Update(gameTime);
        }

        private bool disposed;

        protected override void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    foreach(var kvp in lettersTextureDict)
                    {
                        kvp.Value.Dispose();
                    }

                    laserTexture.Dispose();
                    diagTextFont.Texture.Dispose();
                    hitSound.Stop();
                    hitSoundEffect.Dispose();
                }

                disposed = true;
            }

            base.Dispose(disposing);
        }

        private IEnumerable<LetterSprite> LetterSprites =>
            from p in this where p is LetterSprite select p as LetterSprite;

        private IEnumerable<LaserSprite> LaserSprites =>
            from p in this where p is LaserSprite select p as LaserSprite;
    }
}
