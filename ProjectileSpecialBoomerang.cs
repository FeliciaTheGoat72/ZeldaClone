﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0
{
    public class ProjectileSpecialBoomerang : IProjectile
    {
        private Vector2 position;
        private Vector2 direction;

        private Rectangle sourceRect;
        private Rectangle destinationRect;
        private Texture2D texture;
        private SpriteBatch batch;

        private int frame;
        private float rotation;
        private Boolean isRunning;

        public Boolean IsRunning
        {
            get { return isRunning; }
            set { isRunning = value; }
        }

        public Vector2 Position
        {
            get;
            set;
        }

        public ProjectileSpecialBoomerang(Texture2D texture, SpriteBatch batch, Vector2 position, Vector2 direction)
        {
            this.texture = texture;
            this.batch = batch;
            this.position = position;
            this.direction = direction;

            sourceRect = new Rectangle(137, 280, 14, 20);

            frame = 0;
            isRunning = false;
            rotation = 0f;
        }

        public void GetRotation(Vector2 direction)
        {
            if (direction.X == 0 && direction.Y > 0)
            {
                rotation = (float)Math.PI * 3f / 2f;
            }
            else if (direction.X == 0 && direction.Y < 0)
            {
                rotation = (float)Math.PI / 2f;
            }
            else if (direction.X > 0 && direction.Y == 0)
            {
                rotation = 0f;
            }
            else if (direction.X < 0 && direction.Y == 0)
            {
                rotation = (float)Math.PI;
            }
        }
        public void Update()
        {
            destinationRect = new Rectangle((int)position.X, (int)position.Y, 14, 20);
            GetRotation(direction);
            frame++;

            if (frame < 30)
            {
                IsRunning = true;
                position.X += direction.X * 3f;
                position.Y += direction.Y * 3f;
                rotation += (float)Math.PI / 4f;
            }
            else if (frame >= 30 && frame < 40)
            {
                position.X += direction.X;
                position.Y += direction.Y;
                rotation += (float)Math.PI / 4f;
            }
            else if (frame >= 40 && frame < 45)
            {
                position.X += direction.X * 0f;
                position.Y += direction.Y * 0f;
                rotation += (float)Math.PI / 4f;
            }
            else if (frame >= 45 && frame < 55)
            {
                position.X += direction.X * -1f;
                position.Y += direction.Y * -1f;
                rotation += (float)Math.PI / 4f;
            }
            else if (frame >= 55 && frame < 85)
            {
                position.X += direction.X * -3f;
                position.Y += direction.Y * -3f;
                rotation += (float)Math.PI / 4f;
            }
            else
            {
                IsRunning = false;
                sourceRect = new Rectangle(400, 400, 0, 0);
            }
        }

        public void Draw()
        {
            batch.Begin();
            batch.Draw(
                 texture,
                 destinationRect,
                 sourceRect,
                Color.White,
                rotation,
                new Vector2(sourceRect.Width / 2, sourceRect.Height / 2),
                SpriteEffects.None,
                0f
                );
            batch.End();
        }

    }
}