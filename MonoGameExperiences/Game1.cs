using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using MonoGameExperiences.DialogBoxes;
using System.Collections.Generic;

namespace MonoGameExperiences
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private DialogueBox dialogueBox;
        private DialogueManager dialogueManager;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = false;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            var font = Content.Load<SpriteFont>("FontArial");
            var TextureBox = Content.Load<Texture2D>("ChatBallon");

            dialogueBox = new DialogueBox(font, TextureBox, new string[] {
                "Ola, aventureiro!",
                "Bem-vindo ao meu reino.",
                "Eu sou o Guardiao deste lugar."
            });

            var dialogueBox2 = new DialogueBox(font, TextureBox, new string[] {
                "Vou lhe dizer a sua missao",
                "Voce ira participar da aula",
                "ate o final. Se nao se comportar,",
                "terei de retira-lo."
            });

            /*
            dialogueManager = new DialogueManager(font, TextureBox, guardianDialogue);
            */

            var boxes = new Queue<DialogueBox>();
            boxes.Enqueue(dialogueBox);
            boxes.Enqueue(dialogueBox2);

            dialogueManager = new DialogueManager(font, TextureBox, boxes);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            dialogueManager.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            _spriteBatch.Begin();

            //dialogueBox.Draw(_spriteBatch, new Vector2(0, 0));
            dialogueManager.Draw(_spriteBatch, new Vector2(0, 0));

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}