﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Linq;

namespace Sprint0.enemy
{
	public class EnemyFactory
	{
		private Texture2D enemyTexture;
		private Texture2D dragonTexture;
		private Texture2D npcTexture; 
		private SpriteBatch batch;
		private Vector2 position;
		private Player _player;

		public enum Enemy
		{
			Gel			= 0,
			Goriya		= 1,
			Bat			= 2,
			Hand		= 3,
			Skeleton	= 4,
			OldMan		= 5,
			BossDragon	= 6

		}

		private static EnemyFactory instance = new EnemyFactory();

		public void initialize(SpriteBatch aBatch, Player player)
		{
			batch = aBatch;
			_player = player;
		}

		public static EnemyFactory Instance
		{
			get
			{
				return instance;
			}
		}

		private EnemyFactory()
		{
		}

		public void LoadAllTextures(ContentManager content)
		{
			enemyTexture = content.Load<Texture2D>("Enemy");
			npcTexture = content.Load<Texture2D>("oldman1");
			dragonTexture = content.Load<Texture2D>("dragon");
		}

		public IEnemySprite CreateItemSprite(Enemy itemNum, Vector2 pos)
		{
			position = pos;
			switch (itemNum)
			{
				case Enemy.Gel:
					return new enemyGel(enemyTexture, batch, pos, _player);
				case Enemy.Goriya:
					return new enemyGoriya(enemyTexture, batch, pos);
				case Enemy.Bat:
					return new enemyBat(enemyTexture, batch, pos, _player);
				case Enemy.Hand:
					return new enemyHand(enemyTexture, batch, pos, _player);
				case Enemy.Skeleton:
					return new enemySkeleton(enemyTexture, batch, pos, _player);
				case Enemy.OldMan:
					return new oldMan(npcTexture, batch, pos);
				case Enemy.BossDragon:
					return new bossDragon(dragonTexture, batch, pos);
				default:
					return new enemyGel(enemyTexture, batch, pos, _player);
			}
		}

	}
}
