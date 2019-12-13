using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Windows.Forms;

namespace Memory_Trainer.Find_a_pair
{
    /// <summary>
    /// Параметры открытия игры
    /// </summary>
    public enum OpeningРarameter
    {
        New,
        Load
    }
    /// <summary>
    /// Класс, описывающий уровни игры +
    /// </summary>
    public class Level : IGameInterface
    {
        /// <summary>
        /// Список карт
        /// </summary>
        private List<Card> _cards;
        /// <summary>
        /// Хранит номер текущих открытых карт
        /// </summary>
        private List<int> _openCard;
        /// <summary>
        /// Таймер отвечающий за время игры
        /// </summary>
        private readonly Timer _timer;
        /// <summary>
        /// Таймер отвечающий за задержку перед закрытием или исчезновением карт
        /// </summary>
        private readonly Timer _timerOpenCard;
        /// <summary>
        /// Таймер отвечающий за задержку перед продолжением игры после сохранения
        /// </summary>
        private readonly Timer _timerSaveGame;
        /// <summary>
        /// Текущее время от начала игры
        /// </summary>
        private int _time;
        /// <summary>
        /// Время задержки после сохранения
        /// </summary>
        private int _timeSaveGame;
        /// <summary>
        /// Время задержки перед закрытием или удалением карт
        /// </summary>
        private int _timeOpenCard;
        /// <summary>
        /// Количество нажатий за игру
        /// </summary>
        private int _clicks;
        /// <summary>
        /// Количество открытых пар
        /// </summary>
        private int _openPair;
        /// <summary>
        /// Общее количество пар
        /// </summary>
        private int _countPair;
        /// <summary>
        /// Выводит текущее время
        /// </summary>
        private Label _timeLbl;
        /// <summary>
        /// Вывлдит текущий уровень
        /// </summary>
        private Label _levelLbl;
        /// <summary>
        /// Выводит количество нажатий за игру
        /// </summary>
        private readonly Label _clicksLbl;
        /// <summary>
        /// Выводит надпиь об окончании игры
        /// </summary>
        private readonly Label _endGameLbl;
        /// <summary>
        /// Выводит надпись о сохранении игры
        /// </summary>
        private readonly Label _saveGameLbl;
        /// <summary>
        /// Коллекция настраиваемых шрифтов
        /// </summary>
        private readonly PrivateFontCollection _font;
        /// <summary>
        /// Контрол на котором необходимо отрисовать уровень
        /// </summary>
        private readonly Control _control;
        /// <summary>
        /// Кнопка завершения игры
        /// </summary>
        private Button _endGameBtn;
        /// <summary>
        /// Кнопка выход в меню
        /// </summary>
        private Button _menuBtn;
        /// <summary>
        /// Кнопка сохранения игры
        /// </summary>
        private Button _saveBtn;
        /// <summary>
        /// Конструктор Level
        /// </summary>
        /// <param name="level">Текущий уровень</param>
        /// <param name="control">Контрол на котором необходимо отрисовать уровень</param>
        /// <param name="font">Коллекция настраиваемых шрифтов</param>
        /// <param name="op">Параметр открытия</param>
        public Level(int level, Control control, PrivateFontCollection font, OpeningРarameter op)
        {
            _control = control;
            _font = font;
            if (op == OpeningРarameter.New)
            {
                _openCard = new List<int> { -1, -1 };
                _countPair = GetCountPair(level);
                var indexes = new List<int>();
                while (indexes.Count != _countPair)
                {
                    int index = new Random().Next(1, 31);
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
                _cards = new List<Card>();
                for (int i = 0; i < _countPair; i++)
                {
                    Bitmap faceImage = new Bitmap(Properties.Resources.Face);
                    Bitmap innerImage = new Bitmap((Bitmap)Properties.Resources.ResourceManager.GetObject("_" + indexes[i]));
                    Graphics g = Graphics.FromImage(faceImage);
                    g.DrawImage(innerImage, new Point(22, 62));
                    if(Properties.Resources.Back != null)
                    {
                        _cards.Add(new Card(Properties.Resources.Back, faceImage, indexes[i], control.Parent));
                        _cards.Add(new Card(Properties.Resources.Back, faceImage, indexes[i], control.Parent));
                    }
                }
                _time = 0;
                _clicks = 0;
                _timeLbl = new Label
                {
                    Visible = true,
                    Location = new Point(30, 10),
                    Font = new Font(font.Families[0], 20),
                    Parent = control.Parent,
                    AutoSize = true,
                    BackColor = Color.Transparent,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Text = @"Время: 00:00"
                };
                _levelLbl = new Label
                {
                    Visible = true,
                    Location = new Point(75 + _timeLbl.Width, 10),
                    Font = new Font(font.Families[0], 20),
                    Parent = control.Parent,
                    AutoSize = true,
                    BackColor = Color.Transparent,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Text = @"Уровень: " + level
                };
            }
            else
                OpenGame();
            _timerSaveGame = new Timer
            {
                Enabled = false,
                Interval = 800
            };
            _timerSaveGame.Tick += TimerSaveGameTick;
            _timeSaveGame = 0;
            _timer = new Timer
            {
                Interval = 1000,
                Enabled = true
            };
            _timer.Tick += TimerOnTick;
            _timerOpenCard = new Timer
            {
                Interval = 300,
                Enabled = false
            };
            _timeOpenCard = 0;
            _timerOpenCard.Tick += TimerOpenCardOnTick;
            _saveGameLbl = new Label
            {
                Visible = false,
                Font = new Font(font.Families[0], 20),
                Parent = control.Parent,
                AutoSize = true,
                BackColor = Color.CornflowerBlue,
                TextAlign = ContentAlignment.MiddleCenter,
                Text = @"Игра сохранена"
            };
            _saveGameLbl.Location = new Point((1028 - _saveGameLbl.Width) / 2 , 635);
            _clicksLbl = new Label
            {
                Visible = false,
                Font = new Font(font.Families[0], 20),
                Parent = control.Parent,
                AutoSize = true,
                BackColor = Color.Transparent,
                TextAlign = ContentAlignment.MiddleCenter,
                Text = @"Нажатия: "
            };
            _endGameLbl = new Label
            {
                Visible = false,
                Font = new Font(font.Families[0], 40),
                Parent = control.Parent,
                AutoSize = true,
                BackColor = Color.Transparent,
                TextAlign = ContentAlignment.MiddleCenter,
                Text = @"Игра окончена!"
            };
            _endGameLbl.Location = new Point((1028 - _endGameLbl.Width) / 2, 100);
            foreach (var card in _cards)
            {
                card.MouseClick += MouseClick;
            }
            _endGameBtn = new Button
            {
                Visible = false,
                Font = new Font(font.Families[0], 20),
                AutoSize = true,
                Parent = _control.Parent,
                Text = @"Завершить",
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.White
            };
            _endGameBtn.Location = new Point((1028 - _endGameBtn.Width) / 2, 400);
            _endGameBtn.Click += EndGameBtnClick;
            _menuBtn = new Button
            {
                Visible = true,
                Font = new Font(font.Families[0], 15),
                AutoSize = true,
                Parent = _control.Parent,
                Text = @"Меню",
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.White
            };
            _menuBtn.Location = new Point(998 - _menuBtn.Width, 10);
            _menuBtn.Click += EndGameBtnClick;
            _saveBtn = new Button
            {
                Visible = true,
                Font = new Font(font.Families[0], 15),
                AutoSize = true,
                Parent = _control.Parent,
                Text = @"Сохранить",
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.White
            };
            _saveBtn.Location = new Point(968 - _menuBtn.Width - _saveBtn.Width, 10);
            _saveBtn.Click += SaveBtnClick;
            
        }
        /// <summary>
        /// Функция убирающая надпись о сохранении игры
        /// </summary>
        /// <param name="sender">Объект вызвавший событие</param>
        /// <param name="e">Аргументы события</param>
        private void TimerSaveGameTick(object sender, EventArgs e)
        {
            if (_timeSaveGame++ != 1) return;
            _timerSaveGame.Enabled = false;
            _timeSaveGame = 0;
            _timer.Enabled = true;
            ChangeEnabled(true);
            _saveGameLbl.Visible = false;
        }
        /// <summary>
        /// Функция делающая активными или не активными кнопки сохранения, меню и карты
        /// </summary>
        /// <param name="state">Состояние в которое перейдут кнопки</param>
        private void ChangeEnabled(bool state)
        {
            foreach (var card in _cards)
            {
                card.Image.Enabled = state;
            }

            _menuBtn.Enabled = state;
            _saveBtn.Enabled = state;
        }
        /// <summary>
        /// Функция выполняющая сохранение при нажатии на кнопку
        /// </summary>
        /// <param name="sender">Объект вызвавший событие</param>
        /// <param name="e">Аргументы события</param>
        private void SaveBtnClick(object sender, EventArgs e)
        {
            SaveGame();
        }
        /// <summary>
        /// Функция получения количества пар
        /// </summary>
        /// <param name="level">Уровень</param>
        /// <returns>Количество пар</returns>
        private int GetCountPair(int level)
        {
            switch (level)
            {
                case 1:
                    return 2;
                case 2:
                    return 4;
                case 3:
                    return 6;
                case 4:
                    return 9;
                case 5:
                    return 10;
                case 6:
                    return 12;
                case 7:
                    return 14;
                case 8:
                    return 16;
                case 9:
                    return 18;
            }
            return 0;
        }
        /// <summary>
        /// Функция проверяющая конец игры при открытии карт и закрывающая или убирающая карты
        /// </summary>
        /// <param name="sender">Объект вызвавший событие</param>
        /// <param name="e">Аргументы события</param>
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
                    EndGame();
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
        /// <summary>
        /// Функция изменяющая время игры
        /// </summary>
        /// <param name="sender">Объект вызвавший событие</param>
        /// <param name="e">Аргументы события</param>
        private void TimerOnTick(object sender, EventArgs e)
        {
            _timeLbl.Text = @"Время: " + CreateTimeString(++_time);
        }
        /// <summary>
        /// Функция переводящая время из одного формата в другой
        /// </summary>
        /// <param name="time">Текущее время</param>
        /// <returns></returns>
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
        /// <summary>
        /// Очищающая все контролы для данного уровня
        /// </summary>
        public void Dispose()
        {
            foreach (var t in _cards)
            {
                t.Image.Dispose();
            }
            _timeLbl.Dispose();
            _endGameBtn.Dispose();
            _clicksLbl.Dispose();
            _endGameLbl.Dispose();
            _menuBtn.Dispose();
            _saveBtn.Dispose();
            _levelLbl.Dispose();
        }
        /// <summary>
        /// Функция открывающая карты при нажатии на них мышью
        /// </summary>
        /// <param name="sender">Объект вызвавший событие</param>
        /// <param name="e">Аргументы события</param>
        private void MouseClick(object sender, EventArgs e)
        {
            if (_openCard[0] != -1 && _openCard[1] != -1)
                return;
            _clicks++;
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
        /// <summary>
        /// Функция выполняющая сохранение игры
        /// </summary>
        public void SaveGame()
        {
            string text = "";
            text += "Level: " + _levelLbl.Text.Split(' ')[1] + "\n";
            text += "Count cards: " + _cards.Count + "\n";
            foreach (var card in _cards)
            {
                text += "{\n";
                text += "\tIsDisposed: " + card.Image.IsDisposed + "\n";
                text += "\tLocation: " + card.Image.Location + "\n";
                text += "\tIndexImage: " + card.ImageType + "\n";
                text += "\tIsOpen: " + card.IsOpen + "\n";
                text += "\tScalingFactor: " + card.ScalingFactor + "\n";
                text += "}\n";
            }
            text += "OpenCard: " + _openCard[0] + "\n";
            text += "Time: " + _time + "\n";
            text += "Clicks: " + _clicks + "\n";
            text += "OpenPair: " + _openPair + "\n";
            text += "Successful save!";
            using (FileStream fstream = new FileStream("SaveFindAPair", FileMode.Create))
            {
                byte[] array = System.Text.Encoding.Default.GetBytes(text);
                fstream.Write(array, 0, array.Length);
            }
            _timerSaveGame.Enabled = true;
            _saveGameLbl.Visible = true;
            _timer.Enabled = false;
            ChangeEnabled(false);
        }
        /// <summary>
        /// Функция выполняющая открытие игры
        /// </summary>
        public void OpenGame()
        {
            string path = "SaveFindAPair";
            if (!File.Exists(path))
            {
                throw new Exception("Файл сохранения не найден.");
            }

            string textFromFile;
            using (FileStream fstream = File.OpenRead(path))
            {
                byte[] array = new byte[fstream.Length];
                fstream.Read(array, 0, array.Length);
                textFromFile = System.Text.Encoding.Default.GetString(array);
            }

            textFromFile = textFromFile.Replace("\t","");
            var Lines = textFromFile.Split('\n');
            if (Lines[Lines.Length - 1] != "Successful save!")
            {
                throw new Exception("Файл сохранения повреждён.");
            }

            _countPair = GetCountPair(Convert.ToInt32(Lines[0].Split(' ')[1]));
            _cards = new List<Card>();
            _openCard = new List<int> { -1, -1 };
            
            int j = 1;
            int countCard = Convert.ToInt32(Lines[1].Split(' ')[2]);
            
            for (int i = 0; i < countCard; i++)
            {
                int x = 0;
                int y = 0;
                int index = 0;
                bool isOpen = false;
                float scalingFactor = 1;
                bool isDisposed = true;
                while (Lines[j] != "}")
                {
                    j++;
                    if(Lines[j] == "{")
                        continue;

                    switch (Lines[j].Split(' ')[0])
                    {
                        case "IsDisposed:":
                            isDisposed = Convert.ToBoolean(Lines[j].Split(' ')[1]);
                            break;
                        case "Location:":
                            x = Convert.ToInt32(Lines[j].Split(' ')[1].Split(',')[0].Split('=')[1]);
                            y = Convert.ToInt32(Lines[j].Split(' ')[1].Split(',')[1].Split('=')[1].Split('}')[0]);
                            break;
                        case "IndexImage:":
                            index = Convert.ToInt32(Lines[j].Split(' ')[1]);
                            break;
                        case "IsOpen:":
                            isOpen = Convert.ToBoolean(Lines[j].Split(' ')[1]);
                            break;
                        case "ScalingFactor:":
                            scalingFactor = (float)(Convert.ToDouble(Lines[j].Split(' ')[1]));
                            break;
                    }
                }

                Bitmap faceImage = new Bitmap(Properties.Resources.Face);
                Bitmap innerImage =
                    new Bitmap((Bitmap)Properties.Resources.ResourceManager.GetObject("_" + index.ToString()));
                Graphics g = Graphics.FromImage(faceImage);
                g.DrawImage(innerImage, new Point(22, 62));
                var card = new Card(Properties.Resources.Back, faceImage, index, _control.Parent)
                {
                    IsOpen = isOpen,
                    ScalingFactor = scalingFactor,
                    Image = { Location = new Point(x, y) }
                };
                if (isDisposed)
                {
                    card.Image.Dispose();
                }
                _cards.Add(card);
                j++;
            }
            while(Lines[j] != "Successful save!")
            {
                switch (Lines[j].Split(' ')[0])
                {
                    case "OpenCard:":
                        _openCard[0] = Convert.ToInt32(Lines[j].Split(' ')[1]);
                        break;
                    case "Time:":
                        _time = Convert.ToInt32(Lines[j].Split(' ')[1]);
                        break;
                    case "Clicks:":
                        _clicks = Convert.ToInt32(Lines[j].Split(' ')[1]);
                        break;
                    case "OpenPair:":
                        _openPair = Convert.ToInt32(Lines[j].Split(' ')[1]);
                        break;
                }

                j++;
            }
            _timeLbl = new Label
            {
                Visible = true,
                Location = new Point(30, 10),
                Font = new Font(_font.Families[0], 20),
                Parent = _control.Parent,
                AutoSize = true,
                BackColor = Color.Transparent,
                TextAlign = ContentAlignment.MiddleCenter,
                Text = @"Время: " + CreateTimeString(_time)
        };
            _levelLbl = new Label
            {
                Visible = true,
                Location = new Point(75 + _timeLbl.Width, 10),
                Font = new Font(_font.Families[0], 20),
                Parent = _control.Parent,
                AutoSize = true,
                BackColor = Color.Transparent,
                TextAlign = ContentAlignment.MiddleCenter,
                Text = @"Уровень: " + Lines[0].Split(' ')[1]
            };
        }

        public void ShowRules()
        {
            throw new NotImplementedException();
        }

        public void ShowInfo()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Функция расставляющая и отрисывавающая карты в зависимости от уровня
        /// </summary>
        public void DrawField()
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
        /// <summary>
        /// Функция проверяющая окончание игры
        /// </summary>
        /// <returns>true - если игра окончена, false - если нет</returns>
        public bool IsFinish()
        {
            return _countPair == _openPair;
        }
        /// <summary>
        /// Функция выводящая надпись об окончании игры и статистику в конце игры
        /// </summary>
        private void EndGame()
        {
            _timer.Enabled = false;
            _endGameBtn.Visible = true;
            _clicksLbl.Text += _clicks;
            _clicksLbl.Location = new Point((1028 - _clicksLbl.Width) / 2, 300);
            _clicksLbl.Visible = true;
            _timeLbl.Location = new Point((1028 - _timeLbl.Width) / 2, 200);
            _endGameLbl.Visible = true;
            _menuBtn.Visible = false;
            _saveBtn.Visible = false;
            _levelLbl.Visible = false;
        }
        /// <summary>
        /// Функция завершающая игру при клике на кнопку в конце игры
        /// </summary>
        /// <param name="sender">Объект вызвавший событие</param>
        /// <param name="e">Аргументы события</param>
        private void EndGameBtnClick(object sender, EventArgs e)
        {
            _control.Visible = true;
            Dispose();
        }
    }
}
