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
            List<int> tmpIndex = new List<int>();
            while ((indexes.Count + tmpIndex.Count) != countPair)
            {
                int index = new Random().Next(1, 5);
                bool flag = false;
                if(indexes.Count < 4)
                {
                    foreach (var index1 in indexes)
                    {
                        if (index1 != index) continue;
                        flag = true;
                        break;
                    }
                    if (!flag)
                    {
                        indexes.Add(index);
                    }
                }
                else
                {
                    foreach (var index1 in tmpIndex)
                    {
                        if (index1 != index) continue;
                        flag = true;
                        break;
                    }
                    if (!flag)
                    {
                        tmpIndex.Add(index);
                    }
                }
            }
            indexes.AddRange(tmpIndex);
            for (int i = 0; i < countPair; i++)
            {
                Bitmap faceImage = new Bitmap(Properties.Resources.Face);
                Bitmap innerImage = new Bitmap((Bitmap)Properties.Resources.ResourceManager.GetObject("_" + indexes[i]));
                Graphics g = Graphics.FromImage(faceImage);
                g.DrawImage(innerImage,new Point(22,62));
                _cards.Add(new Card(Properties.Resources.Back, faceImage, indexes[i], control));
                _cards.Add(new Card(Properties.Resources.Back, faceImage, indexes[i], control));
            }

            foreach (var card in _cards)
            {
                card.ScalingFactor = 0.6f;
            }
        }

        public void Draw()
        {
            if(_countPair > 6)
            {
                List<Point> positions = new List<Point>();
                int widthIndent = (1028 - (_cards[0].Image.Width + 20) * _countPair)/2;
                int heightIndent = (630 - (_cards[0].Image.Height + 20) * 2)/2 + 50;
                for (int i = 0; i < _countPair; i++)
                {
                    positions.Add(new Point(widthIndent + (_cards[0].Image.Width + 20) * i, heightIndent));
                    positions.Add(new Point(widthIndent + (_cards[0].Image.Width + 20) * i, heightIndent + (_cards[0].Image.Height + 20)));
                }

                int k = 0;
                while (k != _cards.Count)
                {
                    int index = new Random().Next(0, _cards.Count);
                    bool flag = false;
                    for (int i = 0; i < k; i++)
                    {
                        if (_cards[i].Image.Location == positions[index])
                        {
                            flag = true;
                            break;
                        }
                    }
                    if (!flag)
                    {
                        _cards[k].Image.Location = positions[index];
                        k++;
                    }
                }
            }
            if (_countPair > 6)
            {

            }
        }

        public void HideCards()
        {
            foreach (var card in _cards)
            {
                card.IsOpen = false;
            }
        }

        public void Dispose()
        {
            for (int i = 0; i < _cards.Count; i++)
            {
                _cards[i].Image.Dispose();
            }
        }
    }
}
