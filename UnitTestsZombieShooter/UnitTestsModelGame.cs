using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using Model.GameObjects;

namespace UnitTestsZombieShooter
{
    [TestClass]
    public class UnitTestsModelGame
    {
        [TestMethod]
        public void TestMakePlayerActionCheckMoveUp()
        {
            bool isUp = true;
            bool isDown = false;
            bool isRight = false;
            bool isLeft = false;
            bool isShot = false;

            ModelGame modelGame = ModelGame.GetInstance();

            modelGame.StartGame();
            modelGame.MakePlayerAction(isUp, isDown, isRight, isLeft, isShot);
            Thread.Sleep(10);
            Direction actualDirection = modelGame.Player.Direction;
            modelGame.StopGame();
   
            Direction expectedDirection = Direction.UP;

            Assert.AreEqual(expectedDirection, actualDirection);
        }

        [TestMethod]
        public void TestMakePlayerActionCheckMoveDown()
        {
            bool isUp = false;
            bool isDown = true;
            bool isRight = false;
            bool isLeft = false;
            bool isShot = false;

            ModelGame modelGame = ModelGame.GetInstance();

            modelGame.StartGame();
            modelGame.MakePlayerAction(isUp, isDown, isRight, isLeft, isShot);
            Thread.Sleep(10);
            Direction actualDirection = modelGame.Player.Direction;
            modelGame.StopGame();

            Direction expectedDirection = Direction.DOWN;

            Assert.AreEqual(expectedDirection, actualDirection);
        }

        [TestMethod]
        public void TestMakePlayerActionCheckMoveRight()
        {
            bool isUp = false;
            bool isDown = false;
            bool isRight = true;
            bool isLeft = false;
            bool isShot = false;

            ModelGame modelGame = ModelGame.GetInstance();

            modelGame.StartGame();
            modelGame.MakePlayerAction(isUp, isDown, isRight, isLeft, isShot);
            Thread.Sleep(10);
            Direction actualDirection = modelGame.Player.Direction;
            modelGame.StopGame();

            Direction expectedDirection = Direction.RIGHT;

            Assert.AreEqual(expectedDirection, actualDirection);
        }

        [TestMethod]
        public void TestMakePlayerActionCheckMoveLeft()
        {
            bool isUp = false;
            bool isDown = false;
            bool isRight = false;
            bool isLeft = true;
            bool isShot = false;

            ModelGame modelGame = ModelGame.GetInstance();

            modelGame.StartGame();
            modelGame.MakePlayerAction(isUp, isDown, isRight, isLeft, isShot);
            Thread.Sleep(10);
            Direction actualDirection = modelGame.Player.Direction;
            modelGame.StopGame();

            Direction expectedDirection = Direction.LEFT;

            Assert.AreEqual(expectedDirection, actualDirection);
        }

        [TestMethod]
        public void TestMakePlayerActionCheckShot()
        {
            bool isUp = false;
            bool isDown = false;
            bool isRight = false;
            bool isLeft = false;
            bool isShot = true;

            ModelGame modelGame = ModelGame.GetInstance();

            modelGame.StartGame();
            modelGame.MakePlayerAction(isUp, isDown, isRight, isLeft, isShot);
            Thread.Sleep(1);
            int actualNumberFlyBullets = modelGame.Bullets.Count;
            modelGame.StopGame();

            int expectedNumberFlyBullets = 1;

            Assert.AreEqual(expectedNumberFlyBullets, actualNumberFlyBullets);
        }

        [TestMethod]
        public void TestMakePlayerActionCheckNumberAmmo()
        {
            bool isUp = false;
            bool isDown = false;
            bool isRight = false;
            bool isLeft = false;
            bool isShot = true;

            ModelGame modelGame = ModelGame.GetInstance();

            modelGame.StartGame();
            modelGame.MakePlayerAction(isUp, isDown, isRight, isLeft, isShot);
            Thread.Sleep(1);
            int actualNumberAmmo = modelGame.NumberAmmo;
            modelGame.StopGame();

            int expectedNumberAmmo = 4;

            Assert.AreEqual(expectedNumberAmmo, actualNumberAmmo);
        }

        [TestMethod]
        public void TestGetInstancet()
        {
            Assert.IsNotNull(ModelGame.GetInstance());
        }

        [TestMethod]
        public void TestGetRefArrayZombies()
        {
            Assert.IsNotNull(ModelGame.GetInstance().GetRefArrayZombies());
        }
    }
}
