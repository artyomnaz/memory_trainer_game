using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Memory_Trainer.Find_a_pair
{
    public class Level
    {
        private readonly List<Card> _cards;
        private int _countPair;
        public Level(int countPair, Control control)
        {
            _cards = new List<Card>();
            _countPair = countPair;
            List<int> indexes = new List<int>();
            while (indexes.Count != countPair)
            {
                int index = new Random().Next(1, 5);
                bool flag = false;
                foreach (var index1 in indexes)
                {
                    if (index1 == index)
                    {
                        flag = true;
                        break;
                    }
                }

                if (!flag)
                {
                    indexes.Add(index);
                }
            }
            for (int i = 0; i < countPair; i++)
            {
                Bitmap faceImage = new Bitmap(Properties.Resources.Face);
                Bitmap innerImage = new Bitmap((Bitmap)Properties.Resources.ResourceManager.GetObject("_" + indexes[i]));
                Graphics g = Graphics.FromImage(faceImage);
                g.DrawImage(innerImage,new Point(22,62));
                _cards.Add(new Card(Properties.Resources.Back, faceImage, indexes[i], control));
                _cards.Add(new Card(Properties.Resources.Back, faceImage, indexes[i], control));
            }
        }

        public void Draw()
        {
            for (int i = 0; i < _cards.Count; i++)
            {
                _cards[i].Image.Location = new Point(i*(20 + _cards[i].Image.Width), 50);
            }
        }

        public void off()
        {
            foreach (var card in _cards)
            {
                card.IsOpen = false;
            }
        }
    }
}
