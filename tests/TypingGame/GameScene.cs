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
using System.IO;
using System.Linq;

namespace TypingGame
{
    internal sealed class GameScene : Scene
    {
        #region Private Fields

        private const string DiagTextPattern = @"[TOTAL OBJECTS] {0}";
        private static readonly Random rnd = new Random(DateTime.Now.Millisecond);
        private readonly List<SoundEffect> bgmMusicEffects = new List<SoundEffect>();
        private readonly Dictionary<char, Texture2D> lettersTextureDict = new Dictionary<char, Texture2D>();
        private BackgroundMusic bgm;
        private Texture2D cloudTexture;
        private Text diagText;
        private SpriteFont diagTextFont;
        private bool disposed;
        private Sound explodeSound;
        private SoundEffect explodeSoundEffect;
        private AnimatedSpriteDefinition explosionDefinition;
        private Texture2D explosionTexture;
        private Texture2D grassTexture;
        private Texture2D laserTexture;
        private TimeSpan letterGenerationTimeSpan = TimeSpan.Zero;
        private TimeSpan letterGenerationTimeSpanThreshold = TimeSpan.FromMilliseconds(1000);
        private Texture2D sunTexture;
        private Texture2D treeTexture;

        #endregion Private Fields

        #region Public Constructors

        public GameScene(IOvowGame game) : base(game)
        {
            AutoRemoveInactiveComponents = true;

            Subscribe<ReachBoundaryMessage>((sender, message) =>
            {
                if (sender is LetterSprite letterSprite && 
                    message.ReachedBoundary == Boundary.Bottom)
                {
                    letterSprite.IsActive = false;
                }

                if (sender is LaserSprite laserSprite && 
                    message.ReachedBoundary == Boundary.Top)
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
                    var letterSpriteX = letterSprite.X;
                    var letterSpriteY = letterSprite.Y;
                    explodeSound.Play();
                    letterSprite.IsActive = false;
                    laserSprite.IsActive = false;

                    var explosionSprite = new AnimatedSprite(this,
                        explosionTexture,
                        new Vector2(letterSpriteX, letterSpriteY),
                        explosionDefinition,
                        "explosion", 400)
                    {
                        CollisionDetective = false
                    };

                    Add(explosionSprite);
                }
            });

            Subscribe<AnimationCompletedMessage>((sender, message) =>
            {
                message.Sprite.Stop();
                message.Sprite.IsActive = false;
            });
        }

        #endregion Public Constructors

        #region Private Properties

        private IEnumerable<LaserSprite> LaserSprites =>
            from p in this where p is LaserSprite select p as LaserSprite;

        private IEnumerable<LetterSprite> LetterSprites =>
            from p in this where p is LetterSprite select p as LetterSprite;

        #endregion Private Properties

        #region Public Methods

        public override void Load(ContentManager contentManager)
        {
            using (var fs = new FileStream("explosion.xml", FileMode.Open, FileAccess.Read))
            {
                explosionDefinition = AnimatedSpriteDefinition.Load(fs);
            }

            // Loads texture for background elements.
            sunTexture = contentManager.Load<Texture2D>("sun");
            cloudTexture = contentManager.Load<Texture2D>("cloud");
            treeTexture = contentManager.Load<Texture2D>("tree");
            grassTexture = contentManager.Load<Texture2D>("grass");

            var sunSprite = new DumbSprite(this, sunTexture, new Vector2(10, 10));
            Add(sunSprite);

            var cloudSprite = new DumbSprite(this, cloudTexture, new Vector2(ViewportWidth - cloudTexture.Width - 50, 50));
            Add(cloudSprite);

            var grassSprite = new DumbSprite(this, grassTexture, new Vector2(0, ViewportHeight - grassTexture.Height));
            Add(grassSprite);

            var treeSprite = new DumbSprite(this, treeTexture, new Vector2(ViewportWidth - treeTexture.Width - 30, ViewportHeight - treeTexture.Height - 100));
            Add(treeSprite);

            // Loads texture for letters.
            for (char i = 'A'; i <= 'Z'; i++)
            {
                lettersTextureDict.Add(i, contentManager.Load<Texture2D>($"{(i - 'A' + 1)}"));
            }

            // Loads texture for laser.
            laserTexture = contentManager.Load<Texture2D>("Laser");

            // Loads texture for explosion.
            explosionTexture = contentManager.Load<Texture2D>("explosion2");

            // Loads font textures.
            diagTextFont = contentManager.Load<SpriteFont>("diagText");
            diagText = new Text(string.Format(DiagTextPattern, this.Count), this, diagTextFont) { CollisionDetective = false };
            this.Add(diagText);

            // Loads the Hit Sound.
            explodeSoundEffect = contentManager.Load<SoundEffect>("explode");
            explodeSound = new Sound(explodeSoundEffect, 0.5F);
            this.Add(explodeSound);

            // Loads the BGM.
            for (var idx = 1; idx <= 2; idx++)
            {
                bgmMusicEffects.Add(contentManager.Load<SoundEffect>($"bgm{idx}"));
            }

            bgm = new BackgroundMusic(bgmMusicEffects, 0.2F);
            bgm.Play();
            Add(bgm);

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

        #endregion Public Methods

        #region Protected Methods

        protected override void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    foreach (var kvp in lettersTextureDict)
                    {
                        kvp.Value.Dispose();
                    }

                    laserTexture.Dispose();
                    treeTexture.Dispose();
                    cloudTexture.Dispose();
                    sunTexture.Dispose();
                    grassTexture.Dispose();
                    diagTextFont.Texture.Dispose();
                    explodeSound.Stop();
                    explodeSoundEffect.Dispose();
                    bgm.Stop();
                    foreach (var musicEffect in bgmMusicEffects)
                    {
                        if (!musicEffect.IsDisposed)
                        {
                            musicEffect.Dispose();
                        }
                    }
                }

                disposed = true;
            }

            base.Dispose(disposing);
        }

        #endregion Protected Methods
    }
}
