﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.ItemClass;
using Sprint0.LevelClass;

namespace Sprint0
{
    public class LinkInventory
    {
        private Player player;
        private Player player2;
        LevelManager levelManager;


        private int rupeeCount;
        private int keyCount;
        private int bombCount;
        private int arrowCount;
        private int specialArrowCount;
        private int heartCountPlayer1;
        private int heartCountPlayer2;
        private int heartContainerCount;
        private int levelNumber;
        private int locationSquareX;
        private int locationSquareY;
        private int mapSquareX;
        private int mapSquareY;

        private Boolean firstRupee;
        private Boolean firstKey;
        private Boolean firstBomb;
        private Boolean firstBoomerang;
        private Boolean firstBow;
        private Boolean firstClock;
        private Boolean firstArrow;
        private Boolean firstHeart;
        private Boolean firstHeartContainer;
        private Boolean firstFairy;
        private Boolean firstMap;
        private Boolean firstCompass;
        private Boolean firstSpecialBoomerang;

        private Boolean bow;
        private Boolean map;
        private Boolean compass;
        private Boolean boomerang;
        private Boolean specialBoomerang;
        private Boolean clock;

        private Items[,] itemPositionIndex;
        private Items selectedItem;

        public int LevelNumber
        {
            get { return levelNumber; }
            set { levelNumber = value; }
        }
        public int RupeeCount
        {
            get { return rupeeCount; }
            set { rupeeCount = value; }
        }

        public int KeyCount
        {
            get { return keyCount; }
            set { keyCount = value; }
        }
        public int BombCount
        {
            get { return bombCount; }
            set { bombCount = value; }
        }

        public int ArrowCount
        {
            get { return arrowCount; }
            set { arrowCount = value; }
        }

        public int SpecialArrowCount
        {
            get { return specialArrowCount; }
            set { specialArrowCount = value; }
        }

        public int HeartCountPlayer1
        {
            get { return heartCountPlayer1; }
            set { heartCountPlayer1 = value; }
        }
        public int HeartCountPlayer2
        {
            get { return heartCountPlayer2; }
            set { heartCountPlayer2 = value; }
        }

        public int HeartContainerCount
        {
            get { return heartContainerCount; }
            set { heartContainerCount = value; }
        }

        public Boolean FirstArrow
        {
            get { return firstArrow; }
            set { firstArrow = value; }
        }
        public Boolean FirstBomb
        {
            get { return firstBomb; }
            set { firstBomb = value; }
        }
        public Boolean FirstBoomerang
        {
            get { return firstBoomerang; }
            set { firstBoomerang = value; }
        }

        public Boolean FirstSpecialBomerang
        {
            get { return firstSpecialBoomerang; }
            set { firstSpecialBoomerang = value; }
        }

        public Boolean FirstCompass
        {
            get { return firstCompass; }
            set { firstCompass = value; }
        }
        public Boolean FirstBow
        {
            get { return firstBow; }
            set { firstBow = value; }
        }
        public Boolean FirstClock
        {
            get { return firstClock; }
            set { firstClock = value; }
        }
       
        public Boolean FirstFairy
        {
            get { return firstFairy; }
            set { firstFairy = value; }
        }
        public Boolean FirstHeart
        {
            get { return firstHeart; }
            set { firstHeart = value; }
        }
        public Boolean FirstHeartContainer
        {
            get { return firstHeartContainer; }
            set { firstHeartContainer = value; }
        }
        public Boolean FirstKey
        {
            get { return firstKey; }
            set { firstKey = value; }
        }
        public Boolean FirstMap
        {
            get { return firstMap; }
            set { firstMap = value; }
        }
        public Boolean FirstRupee
        {
            get { return firstRupee; }
            set { firstRupee = value; }
        }
        public Boolean Bow
        {
            get { return bow; }
            set { bow = value; }
        }

        public Boolean Map
        {
            get { return map; }
            set { map = value; }
        }

        public Boolean Compass
        {
            get { return compass; }
            set { compass = value; }
        }

        public Boolean Boomerang
        {
            get { return boomerang; }
            set { boomerang = value; }
        }

        public Boolean SpecialBoomerang
        {
            get { return specialBoomerang; }
            set { specialBoomerang = value; }
        }

        public Boolean Clock
        {
            get { return clock; }
            set { clock = value; }
        }
        public int MapLocationX
        {
            get { return locationSquareX; }
            set { locationSquareX = value; }
        }

        public int MapLocationY
        {
            get { return locationSquareY; }
            set { locationSquareY = value; }
        }
        public int MapSquareLocationX
        {
            get { return mapSquareX; }
            set { mapSquareX = value; }
        }

        public int MapSquareLocationY
        {
            get { return mapSquareY; }
            set { mapSquareY = value; }
        }

        public Items[,] ItemPositionIndex
        {
            get { return itemPositionIndex; }
        }
        public Items Selected_Item
        {
            get { return selectedItem; }
            set { selectedItem = value; }
        }

        public enum Items
        {
            Boomerang,
            Bomb,
            BowAndArrow,
            SpecialBoomerang,
            SpecialBowAndArrow,
            None
        }
        public LinkInventory(Player player)
        {
            levelManager = LevelManager.Instance;
            this.player = player;
            if (levelManager.TwoPlayer)
            {
                player2 = levelManager.Player2;
             //   heartCountPlayer2 = player2.PlayerHp;
            }
            rupeeCount = 0;
            keyCount = 0;
            bombCount = 0;
            arrowCount = 10;
            specialArrowCount = 0;
            heartCountPlayer1 = player.PlayerHp;
            heartContainerCount = (player.MaxHp) / 2;
            levelNumber = 1;
            locationSquareX = 135;
            locationSquareY = 921;
            mapSquareX = 621;
            mapSquareY = 581;


            firstRupee = true;
            firstKey = true;
            firstBomb = true;
            firstBoomerang = true;
            firstBow = true;
            firstClock = true;
            firstArrow = true;
            firstHeart = true;
            firstHeartContainer = true;
            firstMap = true;
            firstFairy = true;
            firstCompass = true;
            firstSpecialBoomerang = true;

            bow = false;
            map = false;
            compass = false;
            boomerang = false;
            specialBoomerang = false;
            clock = false;

            selectedItem = Items.None;

            itemPositionIndex = new Items[2, 4] { { Items.Boomerang, Items.Bomb, Items.BowAndArrow, Items.SpecialBoomerang }, { Items.SpecialBowAndArrow, Items.None, Items.None, Items.None } };
        }

        public void Update()
        {
            heartContainerCount = (player.MaxHp) / 2;
            heartCountPlayer1 = player.PlayerHp;
            if (levelManager.TwoPlayer)
            {
            //    heartCountPlayer2 = player2.PlayerHp;
            }
        }

    }
}
