﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended;
using MonoGame.Utilities;
using Village;

namespace Village.Terrain
{
    class Terrain
    {
        Texture2D grass;
        Texture2D dirt;
        int grasssize;
        Random r;
        TerrainTile[,] tileArray;
        SimplexNoiseGenerator sng;

        public void Initialize(Vector2 mapsize)
        {
            tileArray = new TerrainTile[(int)mapsize.X, (int)mapsize.Y];    
        }

        public void LoadContent(Texture2D grass, Texture2D dirt, Config config)
        {
            this.grass = grass;
            this.dirt = dirt;
            grasssize = grass.Width;

            Texture2D curTexture;
            Color curColor;
            r = new Random();
            sng = new SimplexNoiseGenerator(config.seed);
            for (int i = 0; i < tileArray.GetLength(0); i++)
            {
                for (int j = 0; j < tileArray.GetLength(1); j++)
                {
                    
                    float noise = sng.getDensity(new Vector3(i,j,0));
                    if (noise < 0.0)
                    {
                        curTexture = grass;
                        curColor = Color.LightGreen;
                    }
                    else
                    {
                        curTexture = grass;
                        curColor = Color.BurlyWood;
                    }
                    tileArray[i, j] = new TerrainTile();
                    Vector2 position = new Vector2(i * grasssize, j * grasssize);
                    tileArray[i, j].Initialize(curTexture, position, curColor);
                    noise = 0;
                }
            }
        }

        public void Update(GameTime gameTime)
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < tileArray.GetLength(0); i++)
            {
                for (int j = 0; j < tileArray.GetLength(1); j++)
                {
                    tileArray[i, j].Draw(spriteBatch);
                }
            }
        }
    }
}
