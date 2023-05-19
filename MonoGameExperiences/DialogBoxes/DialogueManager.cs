using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace MonoGameExperiences.DialogBoxes
{
    public class DialogueManager
    {
        private Queue<DialogueBox> Boxes;
        private DialogueBox currentBox;
        private double displayTime = 7;
        private double transitionTime = 2;
        private double timer = 0;

        public DialogueManager(SpriteFont font, Texture2D TextureBox, Queue<DialogueBox> sentences)
        {
            Boxes = sentences;
        }

        private void EndDialogue()
        {
            currentBox = null;
        }

        public void DisplayNextDialogueBox()
        {
            if (Boxes.Count == 0)
            {
                EndDialogue();
                return;
            }

            currentBox = Boxes.Dequeue();
            timer = 0;
        }

        public void Update(GameTime gameTime)
        {
            timer += gameTime.ElapsedGameTime.TotalSeconds;

            if (timer >= displayTime + transitionTime)
            {
                DisplayNextDialogueBox();
            }
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            if (currentBox != null)
            {
                currentBox.Draw(spriteBatch, position);
            }
        }
    }
}


/*

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace YourGameNamespace
{
    public class DialogueManager
    {
        private SpriteFont font;
        private Texture2D dialogueBoxTexture;
        private Queue<string> sentences;
        private string currentSentence;
        private float displayTime = 10f;
        private float transitionTime = 2f;
        private float timer = 0f;

        public DialogueManager(SpriteFont font, Texture2D dialogueBoxTexture)
        {
            this.font = font;
            this.dialogueBoxTexture = dialogueBoxTexture;
            sentences = new Queue<string>();
        }

        public void StartDialogue(Dialogue dialogue)
        {
            sentences.Clear();

            foreach (string sentence in dialogue.sentences)
            {
                sentences.Enqueue(sentence);
            }

            DisplayNextSentence();
        }

        public void DisplayNextSentence()
        {
            if (sentences.Count == 0)
            {
                EndDialogue();
                return;
            }

            currentSentence = sentences.Dequeue();
            timer = 0f;
        }

        public void Update(GameTime gameTime)
        {
            timer += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (timer >= displayTime + transitionTime)
            {
                DisplayNextSentence();
            }
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            if (!string.IsNullOrEmpty(currentSentence))
            {
                spriteBatch.Draw(dialogueBoxTexture, position, Color.White);
                spriteBatch.DrawString(font, currentSentence, position + new Vector2(10, 10), Color.Black);
            }
        }

        private void EndDialogue()
        {
            currentSentence = null;
        }
    }
}


Para usar esta classe em seu jogo, você pode criar uma instância da classe `Dialogue` e fornecer um array de strings representando as falas do Guardião. Em seguida, você pode passar essa instância para o método `StartDialogue` da classe `DialogueManager` para iniciar o diálogo.

Aqui está um exemplo de como você pode fazer isso em seu jogo:

```csharp
// Cria uma instância da classe Dialogue com as falas do Guardião
Dialogue guardianDialogue = new Dialogue(new string[] {
    "Olá, aventureiro!",
    "Bem-vindo ao meu reino.",
    "Eu sou o Guardião deste lugar."
});

// Cria uma instância da classe DialogueManager
DialogueManager dialogueManager = new DialogueManager(font, dialogueBoxTexture);

// Inicia o diálogo com as falas do Guardião
dialogueManager.StartDialogue(guardianDialogue);
```

Espero que isso ajude! Se você tiver alguma dúvida ou precisar de mais ajuda, não hesite em perguntar.
*/