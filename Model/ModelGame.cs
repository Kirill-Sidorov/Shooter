using Model.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// Делегат
    /// </summary>
    public delegate void DModel();

    public class ModelGame
    {
        public const int WIDTH_GAME_FIELD = 800;
        public const int HEIGHT_GAME_FIELD = 600;

        public event DModel NeedRedraw = null;
        public event DModel GameOver = null;

        public List<Bullet> Bullets;

        public Player Player { get; set; }

        public Ammo Ammo { get; set; }

        public int NumberAmmo { get; private set; }

        public int NumberKilledZombies { get; private set; }

        private static ModelGame _instance = null;

        private Random _random = new Random();

        private Thread _thread;

        private object _locker;

        private Zombie[] _zombies;

        private bool _isUp;
        private bool _isDown;
        private bool _isRight;
        private bool _isLeft;
        private bool _isShot;

        private bool _isGameOver;

        public static ModelGame GetInstance()
        {
            if (_instance == null)
            {
                _instance = new ModelGame();
            }   
            return _instance;
        }

        private ModelGame()
        {
            Player = new Player();
            Player.Speed = 5;
            _locker = new object();
            Bullets = new List<Bullet>();
            Ammo = new Ammo();
            _zombies = new Zombie[5];
        }

        private void ResetGame()
        {
            _isGameOver = false;
            Ammo.IsExist = false;
            Player.Health = 100;
            NumberAmmo = 5;
            NumberKilledZombies = 0;
            _isUp = false;
            _isDown = false;
            _isRight = false;
            _isLeft = false;
            _isShot = false;
            InitZombiesArray();
        }

        private void InitZombiesArray()
        {
            for (int i = 0; i < _zombies.Length; i++)
            {
                _zombies[i] = new Zombie(_random.Next(0, 800), _random.Next(0, 600));
            }
        }

        private void InitZombie(Zombie parZombie)
        {
            parZombie.X = _random.Next(0, 800);
            parZombie.Y = _random.Next(0, 600);
        }

        public ref Zombie[] GetRefArrayZombies()
        {
            return ref _zombies;
        }

        public void StartGame()
        {
            ResetGame();
            _thread = new Thread(RunGame);
            _thread.Start();
        }

        public void StopGame()
        {
            _thread.Abort();
        }

        public void MakePlayerAction(bool parIsUp, bool parIsDown, bool parIsRight, bool parIsLeft, bool parIsShot)
        {
            if (!_isGameOver)
            {
                _isUp = parIsUp;
                _isDown = parIsDown;
                _isRight = parIsRight;
                _isLeft = parIsLeft;
                _isShot = parIsShot;
            }
            else
            {
                _thread.Abort();
                GameOver?.Invoke();
            }
        }

        private void RunGame()
        {
            while (true)
            {
                lock (_locker)
                {
                    RecalculateGameModel();
                    NeedRedraw?.Invoke();
                    Thread.Sleep(10);
                }
            }
        }

        private void RecalculateGameModel()
        {
            if (Player.Health < 1)
            {
                _isGameOver = true;
            }
            else
            {
                MovePlayer();
                MoveZombies();
                MoveBulletsList();
            }
        }

        private void MovePlayer()
        {
            if (_isLeft && Player.X > 0)
            {
                Player.X -= Player.Speed;
                Player.Direction = Direction.LEFT;
            }
            if (_isRight && Player.X < WIDTH_GAME_FIELD)
            {
                Player.X += Player.Speed;
                Player.Direction = Direction.RIGHT;
            }
            if (_isUp && Player.Y > 0)
            {
                Player.Y -= Player.Speed;
                Player.Direction = Direction.UP;
            }
            if (_isDown && Player.Y < HEIGHT_GAME_FIELD)
            {
                Player.Y += Player.Speed;
                Player.Direction = Direction.DOWN;
            }
            if (_isShot)
            {
                MakeShot();
            }
            if (Ammo.IsExist)
            {
                CheckPlayerCollisions(Player.X, Player.Y);
            }
        }

        private void CheckPlayerCollisions(int parX, int parY)
        {
            if ((Ammo.X + 20) > parX &&
                (Ammo.X - 20) < parX &&
                (Ammo.Y + 20) > parY &&
                (Ammo.Y - 20) < parY)
            {
                NumberAmmo = 5;
                Ammo.IsExist = false;
            }
        }

        private void MoveZombies()
        {
            foreach (Zombie zombie in _zombies)
            {
                if (Player.X > zombie.X)
                {
                    zombie.X += zombie.Speed;
                    zombie.Direction = Direction.RIGHT;
                }
                if (Player.X < zombie.X)
                {
                    zombie.X -= zombie.Speed;
                    zombie.Direction = Direction.LEFT;
                }
                if (Player.Y > zombie.Y)
                {
                    zombie.Y += zombie.Speed;
                    zombie.Direction = Direction.DOWN;
                }
                if (Player.Y < zombie.Y)
                {
                    zombie.Y -= zombie.Speed;
                    zombie.Direction = Direction.UP;
                }
                CheckZombieCollisions(zombie.X, zombie.Y);
            }
        }

        private void CheckZombieCollisions(int parX, int parY)
        {
            if ((Player.X + 10) > parX &&
                (Player.X - 10) < parX &&
                (Player.Y + 10) > parY &&
                (Player.Y - 10) < parY)
            {
                Player.Health--;
            }
        }

        private void MoveBulletsList()
        {
            for (int i = 0; i < Bullets.Count; i++)
            {
                if (MoveBullet(Bullets[i]))
                {
                    Bullets.RemoveAt(i);
                    i--;
                }
            }
        }

        private bool MoveBullet(Bullet bullet)
        {
            switch (bullet.Direction)
            {
                case Direction.DOWN:
                    if (bullet.Y < HEIGHT_GAME_FIELD)
                    {
                        bullet.Y += bullet.Speed;
                        return CheckBulletCollisions(bullet.X, bullet.Y);
                    }
                    break;
                case Direction.LEFT:
                    if (bullet.X > 0)
                    {
                        bullet.X -= bullet.Speed;
                        return CheckBulletCollisions(bullet.X, bullet.Y);
                    }
                    break;
                case Direction.RIGHT:
                    if (bullet.X < WIDTH_GAME_FIELD)
                    {
                        bullet.X += bullet.Speed;
                        return CheckBulletCollisions(bullet.X, bullet.Y);
                    }
                    break;
                case Direction.UP:
                    if (bullet.Y > 0)
                    {
                        bullet.Y -= bullet.Speed;
                        return CheckBulletCollisions(bullet.X, bullet.Y);
                    }
                    break;
            }
            return true;
        }

        private bool CheckBulletCollisions(int parX, int parY)
        {
            foreach (Zombie zombie in _zombies)
            {
                if ((zombie.X + 10) > parX &&
                    (zombie.X - 10) < parX &&
                    (zombie.Y + 10) > parY &&
                    (zombie.Y - 10) < parY)
                {
                    InitZombie(zombie);
                    NumberKilledZombies++;
                    return true;
                }
            }
            return false;
        }

        private void MakeShot()
        {
            if (NumberAmmo != 0)
            {
                _isShot = false;
                NumberAmmo--;
                Bullets.Add(new Bullet(Player.X, Player.Y, Player.Direction));
            }
            if (NumberAmmo == 0 && !Ammo.IsExist)
            {
                CreateAmmo();
            }
        }

        private void CreateAmmo()
        {
            Ammo.X = _random.Next(0, 800); 
            Ammo.Y = _random.Next(0, 600);
            Ammo.IsExist = true;
        }
    }
}
