﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Sprint0.enemy
{
    public class enemyHand : IEnemySprite,IBoxCollider
    {

        public Texture2D Texture;

        private int currentFrame;

        private SpriteBatch batch;
        Random getDistance = new Random((int)DateTime.Now.Ticks);
        Random coinFlipForAxis = new Random((int)DateTime.Now.Ticks);
        Random coinFlipForDirection = new Random((int)DateTime.Now.Ticks);
        Player link;
        private Vector2 direction;
        private Vector2 currentPos;
        private Vector2 destination;
        int x = 400;
        int y = 200;
        private int frame;
        private TopLeft topLeft;
        private BottomRight botRight;
        private bool isAlive;
        private int trigger;
        private int hit;
        private int DeathCount;
        private int change;
        public int explosionFrame;
        private int row1;
        public int deathCount
        {
            get { return DeathCount; }
            set { DeathCount = value; }
        }
        public bool IsAlive
        {
            get { return isAlive; }
            set { isAlive = value; }
        }

        public TopLeft TopLeft
        {
            get { return topLeft; }
        }

        public BottomRight BottomRight
        {
            get { return botRight; }
        }
        public Vector2 position
        {
            get { return currentPos; }
            set
            {
                currentPos = value;
                UpdateCollisionBox();

            }
        }
        public Vector2 Destination
        {
            get { return destination; }
            set
            {
                destination = value;


            }
        }
        public enemyHand(Texture2D texture, SpriteBatch batch, Vector2 location,Player player)
        {

            Texture = texture;
            this.batch = batch;
            currentFrame = 0;
            currentPos = location;
            destination = location;
            link = player;
            topLeft = new TopLeft(400, 200, this);
            botRight = new BottomRight(440, 240, this);
            isAlive = true;

        }

        public void Update()
        {
            if (isAlive&& deathCount<3)
            {
                FrameChaningforEnemy action = new FrameChaningforEnemy(currentPos, direction, destination, currentFrame);
                MoveEnemy move = new MoveEnemy(direction, currentPos, destination);
                NewDestination makeNextMove = new NewDestination(direction, currentPos, destination);


                if (frame == 5)
                {

                    currentFrame = action.frameReturn();
                    frame = 0;
                }


                currentPos = move.Move();

                direction = makeNextMove.RollingDice1();

                destination = makeNextMove.RollingDice();

                frame++;
                UpdateCollisionBox();
            }
            

        }

        public void draw()
        {
            draw(0,0);
        }

        public void draw(int xOffset, int yOffset)
        {

            int row = currentFrame;
            if (isAlive)
            {
                Rectangle sourceRectangle = new Rectangle(32 * row + 846, 480, 32, 45);
                Rectangle destinationRectangle = new Rectangle((int)currentPos.X+xOffset, (int)currentPos.Y+yOffset, 40, 40);

                batch.Begin();
                if (deathCount < 3)
                {
                    if (trigger != deathCount && hit < 50)
                    {
                        if (hit % 2 == 0)
                        {
                            batch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
                        }
                        else
                        {
                            batch.Draw(Texture, destinationRectangle, sourceRectangle, Color.Red);
                        }

                        hit++;
                    }
                    else
                    {


                        batch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
                    }
                }
                if (deathCount >= 3)
                {

                    topLeft.X = 0;
                    topLeft.Y = 0;
                    botRight.X = 0;
                    botRight.Y = 0;

                    if (explosionFrame < 200)
                    {


                        batch.Draw(Texture, new Vector2((int)currentPos.X + change + xOffset, (int)currentPos.Y + change + yOffset), new Rectangle(18 * row1 + 820, 338, 18, 23), Color.White, 0.01f, new Vector2(0, 0), 1f, SpriteEffects.None, 1);
                        batch.Draw(Texture, new Vector2((int)currentPos.X + change + xOffset + 25, (int)currentPos.Y - change + yOffset + 25), new Rectangle(18 * row1 + 820, 338, 18, 23), Color.White, 135f, new Vector2(0, 0), 1f, SpriteEffects.FlipVertically, 1);
                        batch.Draw(Texture, new Vector2((int)currentPos.X - change + xOffset, (int)currentPos.Y - change + yOffset), new Rectangle(18 * row1 + 820, 338, 18, 23), Color.White, 0.01f, new Vector2(0, 0), 1f, SpriteEffects.None, 1);
                        batch.Draw(Texture, new Vector2((int)currentPos.X - change + xOffset, (int)currentPos.Y + change + yOffset), new Rectangle(18 * row1 + 820, 338, 18, 23), Color.White, 0.01f, new Vector2(0, 0), 1f, SpriteEffects.FlipHorizontally, 1);
                    }
                    else
                    {
                        isAlive = false;
                    }
                    row1++;
                    if (row1 == 5)
                    {
                        row1 = 0;
                    }
                    explosionFrame++;
                    change += 2;
                }

                batch.End();
                if (hit == 50)
                {
                    trigger++;
                    hit = 0;
                }
            }
        }

        private void UpdateCollisionBox()
        {
            
                topLeft.X = (int)currentPos.X;
                topLeft.Y = (int)currentPos.Y;
                botRight.X = (int)currentPos.X + 40;
                botRight.Y = (int)currentPos.Y + 40;
            
       

        }


    }
}
