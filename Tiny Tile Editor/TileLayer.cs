//    This file is part of Tiny Tile Editor.
//
//    Tiny Tile Editor is free software: you can redistribute it and/or modify
//    it under the terms of the GNU General Public License as published by
//    the Free Software Foundation, either version 3 of the License, or
//    (at your option) any later version.
//
//    Tiny Tile Editor is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//    GNU General Public License for more details.
//
//    You should have received a copy of the GNU General Public License
//    along with Tiny Tile Editor.  If not, see <http://www.gnu.org/licenses/>.

using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Tiny_Tile_Editor
{
    public class TileLayer
    {
        private readonly Texture2D tileset;
        private int width, height, tileSize;
        private Tile[,] tiles;

        public int Width
        {
            get
            {
                return width;
            }
            set
            {
                ResizeLayer(value, height);

                width = value;
            }
        }

        public int Height
        {
            get
            {
                return height;
            }
            set
            {
                ResizeLayer(width, value);

                height = value;
            }
        }

        public int TileSize
        {
            get
            {
                return tileSize;
            }
            set
            {
                tileSize = value;

                Clear();
            }
        }

        public TileLayer(Texture2D tileset, int width, int height, int tileSize)
        {
            this.tileset = tileset;
            this.width = width;
            this.height = height;
            this.tileSize = tileSize;
            tiles = new Tile[height, width];

            Clear();
        }

        public TileLayer(TileLayer layer)
        {
            tileset = layer.tileset;
            width = layer.width;
            height = layer.height;
            tileSize = layer.tileSize;
            tiles = new Tile[height, width];

            // Because the tiles are of type Rectangle, and thus a reference type, we have to manually copy over every tile.
            // This is necessary because otherwise the two tiles would reference the same area in memory.
            // Changing one would change the other.

            Array.Copy(layer.tiles, tiles, width * height);
        }

        public Tile GetTile(int tileX, int tileY)
        {
            return tiles[tileY, tileX];
        }

        public void SetTile(int tileX, int tileY, Tile newCell)
        {
            tiles[tileY, tileX] = newCell;
        }

        public void SetTiles(Tile[,] newTiles)
        {
            tiles = newTiles;
        }

        public void Draw(SpriteBatch spriteBatch, Rectangle currentViewingRectangle)
        {
            int xBounds = (int)MathHelper.Min(currentViewingRectangle.Right, width);
            int yBounds = (int)MathHelper.Min(currentViewingRectangle.Bottom, height);

            for (int x = currentViewingRectangle.X; x < xBounds; x++)
                for (int y = currentViewingRectangle.Y; y < yBounds; y++)
                    tiles[y, x].Draw(spriteBatch, new Rectangle(x * TileSize, y * TileSize, TileSize, TileSize), tileset);
        }

        public void Draw(SpriteBatch spriteBatch, Rectangle previewRect, bool skipPreviewRectTiles, Rectangle currentViewingRectangle)
        {
            int xBounds = (int)MathHelper.Min(currentViewingRectangle.Right, width);
            int yBounds = (int)MathHelper.Min(currentViewingRectangle.Bottom, height);

            for (int x = currentViewingRectangle.X; x < xBounds; x++)
            {
                for (int y = currentViewingRectangle.Y; y < yBounds; y++)
                {
                    if (skipPreviewRectTiles && IsBetween(x, previewRect.X / tileSize, (previewRect.X + previewRect.Width) / tileSize) && IsBetween(y, previewRect.Y / tileSize, (previewRect.Y + previewRect.Height) / tileSize)) // Don't draw where the tool preview is going to be
                        continue;

                    tiles[y, x].Draw(spriteBatch, new Rectangle(x * TileSize, y * TileSize, TileSize, TileSize), tileset);
                }
            }
        }

        private static bool IsBetween(int actual, int lower, int upper)
        {
            return actual.CompareTo(lower) >= 0 && actual.CompareTo(upper) < 0;
        }

        public void Clear()
        {
            for (int x = 0; x < width; x++)
                for (int y = 0; y < height; y++)
                    SetTile(x, y, new Tile(Tile.Type.Empty));
        }

        private void ResizeLayer(int layerWidth, int layerHeight)
        {
            var newTiles = new Tile[layerHeight, layerWidth];

            for (int x = 0; x < layerWidth; x++)
                for (int y = 0; y < layerHeight; y++)
                    newTiles[y, x] = (x >= width) || (y >= height) ? new Tile(Tile.Type.Empty) : tiles[y, x];

            tiles = newTiles;
        }
    }
}
