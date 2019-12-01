using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;

namespace Memory_Trainer.Find_a_pair
{
    public class Level : IGameInterface
    {
        private readonly List<Card> _cards;
        private readonly int _countPair;
        private readonly Timer _timer;
        private readonly Timer _timerOpenCard;
        private int _time;
        private int _timeOpenCard;
        private readonly Label _timeLbl;
        private PrivateFontCollection _font;
        private List<int> _openCard;
        private int _openPair;
        private LevelManager _parent;
        private Control _control;
        public Level(int countPair, Control control, PrivateFontCollection font, LevelManager parent)
        {
            _control = control;
            _parent = parent;
            _openCard = new List<int> { -1, -1 };
            _font = font;
            _cards = new List<Card>();
            _countPair = countPair;
            var indexes = new List<int>();
            var tmpIndex = new List<int>();
            while (indexes.Count != countPair)
            {
                int index = new Random().Next(1, 21);
                bool flag = false;
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
            indexes.AddRange(tmpIndex);
            for (int i = 0; i < countPair; i++)
            {
                Bitmap faceImage = new Bitmap(Properties.Resources.Face);
                Bitmap innerImage = new Bitmap((Bitmap)Properties.Resources.ResourceManager.GetObject("_" + indexes[i]));
                Graphics g = Graphics.FromImage(faceImage);
                g.DrawImage(innerImage, new Point(22, 62));

                _cards.Add(new Card(Properties.Resources.Back, faceImage, indexes[i], control.Parent));
                _cards.Add(new Card(Properties.Resources.Back, faceImage, indexes[i], control.Parent));
            }
            _timer = new Timer
            {
                Interval = 1000,
                Enabled = true
            };
            _timerOpenCard = new Timer
            {
                Interval = 300,
                Enabled = false
            };
            _time = 0;
            _timeOpenCard = 0;
            _timer.Tick += TimerOnTick;
            _timerOpenCard.Tick += TimerOpenCardOnTick;
            _timeLbl = new Label
            {
                Visible = true,
                Location = new Point(30, 10),
                Font = new Font(_font.Families[0], 20),
                Parent = control.Parent,
                AutoSize = true,
                BackColor = Color.Transparent,
                TextAlign = ContentAlignment.MiddleCenter,
                Text = @"Время: 00:00"
            };
            foreach (var card in _cards)
            {
                card.MouseClick += MouseClick;
            }
        }

        private void TimerOpenCardOnTick(object sender, EventArgs e)
        {

            _timeOpenCard++;
            if (_timeOpenCard != 2)
                return;
            if (_cards[_openCard[0]].ImageType == _cards[_openCard[1]].ImageType)
            {
                _cards[_openCard[0]].Image.Dispose();
                _cards[_openCard[1]].Image.Dispose();
                _openPair++;
                if (IsFinish())
                {
                    _control.Visible = true;
                    Dispose();
                }

            }
            else
            {
                _cards[_openCard[0]].IsOpen = false;
                _cards[_openCard[1]].IsOpen = false;
            }
            _openCard[0] = -1;
            _openCard[1] = -1;
            _timeOpenCard = 0;
            _timerOpenCard.Enabled = false;
        }

        private void TimerOnTick(object sender, EventArgs e)
        {
            _timeLbl.Text = @"Время: " + CreateTimeString(++_time);
        }

        private static string CreateTimeString(int time)
        {
            int sec = time % 60;
            int min = time / 60;
            int hour = 0;
            if (min == 60)
            {
                hour++;
                if (hour == 24)
                    hour = 0;
                time = 0;
                min = 0;
            }
            return (hour != 0 ? hour.ToString().Length == 2 ? hour + ":" : "0" + hour + ":" : "") +
                   (min.ToString().Length == 2 ? min.ToString() : "0" + min) + ":" +
                   (sec.ToString().Length == 2 ? sec.ToString() : "0" + sec);
        }
        public void Draw()
        {
            List<Point> positions = new List<Point>();
            int widthIndent;
            int heightIndent;
            if (_countPair <= 5)
            {
                widthIndent = (1028 - (_cards[0].Image.Width + 20) * _countPair) / 2;
                heightIndent = (630 - (_cards[0].Image.Height + 20) * 2) / 2 + 50;
                for (int i = 0; i < _countPair; i++)
                {
                    positions.Add(new Point(widthIndent + (_cards[0].Image.Width + 20) * i, heightIndent));
                    positions.Add(new Point(widthIndent + (_cards[0].Image.Width + 20) * i, heightIndent + (_cards[0].Image.Height + 20)));
                }
            }
            else
            if (_countPair > 5 && _countPair % 3 == 0 && _countPair < 18)
            {
                foreach (var card in _cards)
                {
                    card.ScalingFactor = 0.8f;
                }
                widthIndent = 514 - (_cards[0].Image.Width + 20) * _countPair / 3;
                heightIndent = (630 - (_cards[0].Image.Height + 20) * 3) / 2 + 50;
                for (int i = 0; i < _countPair; i++)
                {
                    positions.Add(new Point(widthIndent + (_cards[0].Image.Width + 20) * i, heightIndent));
                    positions.Add(new Point(widthIndent + (_cards[0].Image.Width + 20) * i, heightIndent + (_cards[0].Image.Height + 20)));
                    positions.Add(new Point(widthIndent + (_cards[0].Image.Width + 20) * i, heightIndent + (_cards[0].Image.Height + 20) * 2));
                }
            }
            else
            {
                foreach (var card in _cards)
                {
                    card.ScalingFactor = 0.6f;
                }
                widthIndent = (1028 - (_cards[0].Image.Width + 20) * _countPair / 2) / 2;
                heightIndent = (630 - (_cards[0].Image.Height + 20) * 4) / 2 + 50;
                for (int i = 0; i < _countPair; i++)
                {
                    positions.Add(new Point(widthIndent + (_cards[0].Image.Width + 20) * i, heightIndent));
                    positions.Add(new Point(widthIndent + (_cards[0].Image.Width + 20) * i, heightIndent + _cards[0].Image.Height + 20));
                    positions.Add(new Point(widthIndent + (_cards[0].Image.Width + 20) * i, heightIndent + (_cards[0].Image.Height + 20) * 2));
                    positions.Add(new Point(widthIndent + (_cards[0].Image.Width + 20) * i, heightIndent + (_cards[0].Image.Height + 20) * 3));
                }
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

        public void Dispose()
        {
            foreach (var t in _cards)
            {
                t.Image.Dispose();
            }
            _timeLbl.Dispose();
        }
        private void MouseClick(object sender, EventArgs e)
        {
            if (_openCard[0] != -1 && _openCard[1] != -1)
                return;
            Card card = ((Card)sender);
            if (_openCard[0] == -1)
            {
                card.IsOpen = true;
                for (int i = 0; i < _cards.Count; i++)
                {
                    if (_cards[i] == card)
                    {
                        _openCard[0] = i;
                    }
                }
            }
            else
            {
                if (_cards[_openCard[0]] == card)
                    return;
                for (int i = 0; i < _cards.Count; i++)
                {
                    if (_cards[i] == card)
                    {
                        _openCard[1] = i;
                    }
                }
                card.IsOpen = true;
                _timerOpenCard.Enabled = true;
            }
        }
        public void SaveGame()
        {
            throw new NotImplementedException();
        }

        public void OpenGame()
        {
            throw new NotImplementedException();
        }

        public void ShowRules()
        {
            throw new NotImplementedException();
        }

        public void ShowInfo()
        {
            throw new NotImplementedException();
        }

        public void DrawField()
        {
            throw new NotImplementedException();
        }

        public bool IsFinish()
        {
            return _countPair == _openPair;
        }
    }
}
