using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace MonoGameExperiences.DialogBoxes
{
    public class DialogueBox
    {
        private string[] sentences;
        private SpriteFont font;
        private Texture2D TextureBox;

        public DialogueBox(SpriteFont font, Texture2D TextureBox, string[] sentences)
        {
            this.font = font;
            this.TextureBox = TextureBox;
            this.sentences = sentences;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            spriteBatch.Draw(TextureBox, position, Color.White);
            // texto com margem
            position += new Vector2(15, 50);
            foreach (var sentence in sentences)
            {
                spriteBatch.DrawString(font, sentence, position, Color.Black);
                // distância de uma frase para outra
                position += new Vector2(0, 40);
            }
        }
    }
}
