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
    public class Selection
    {
        private int tileSize;

        private Vector2 origin;
        private Rectangle rectangle;

        public Selection()
        {
            Reset();
        }

        public Selection(int clientX, int clientY, int tileSize)
        {
            this.tileSize = tileSize;

            rectangle = new Rectangle(clientX / tileSize * tileSize, clientY / tileSize * tileSize, tileSize, tileSize);
            origin = new Vector2(rectangle.X, rectangle.Y);
        }

        public Rectangle Rectangle
        {
            get
            {
                return rectangle;
            }
        }

        public void Reset()
        {
            tileSize = 32;

            rectangle = new Rectangle(0, 0, tileSize, tileSize);
            origin = new Vector2(rectangle.X, rectangle.Y);
        }

        public void ChangeTileSize(int newTileSize)
        {
            if (tileSize == newTileSize)
                return;

            tileSize = newTileSize;

            rectangle = new Rectangle(NormalizeRectangleField(rectangle.X), NormalizeRectangleField(rectangle.Y), NormalizeRectangleField(rectangle.Width), NormalizeRectangleField(rectangle.Height));
            origin = new Vector2(rectangle.X, rectangle.Y);
        }

        public int TileSize
        {
            get
            {
                return tileSize;
            }
        }

        private int NormalizeRectangleField(int field) // Magic
        {
            return ((field + tileSize / 2) / tileSize) * tileSize;
        }

        public void UpdateRectangle(int clientX, int clientY)
        {
            rectangle.X = clientX / tileSize * tileSize;
            rectangle.Y = clientY / tileSize * tileSize;

            FixRectangle(clientX, clientY);
        }

        public void UpdateOrigin(int clientX, int clientY)
        {
            origin.X = clientX / tileSize * tileSize;
            origin.Y = clientY / tileSize * tileSize;
        }

        private void FixRectangle(int clientX, int clientY) // Gets rid of rectangles of negative width and height
        {
            Vector2 direction = new Vector2(clientX, clientY) - origin;

            if (direction.X > 0)
            {
                rectangle.X = (int)origin.X;
                rectangle.Width = (int)Math.Ceiling(direction.X / tileSize) * tileSize;
            }
            else if (direction.X < 0)
            {
                rectangle.X = clientX / tileSize * tileSize;
                rectangle.Width = (int)Math.Ceiling(-direction.X / tileSize) * tileSize + tileSize;

                if (clientX < 0)
                    rectangle.X -= tileSize;
            }

            if (direction.Y > 0)
            {
                rectangle.Y = (int)origin.Y;
                rectangle.Height = (int)Math.Ceiling(direction.Y / tileSize) * tileSize;
            }
            else if (direction.Y < 0)
            {
                rectangle.Y = clientY / tileSize * tileSize;
                rectangle.Height = (int)Math.Ceiling(-direction.Y / tileSize) * tileSize + tileSize;

                if (clientY < 0)
                    rectangle.Y -= tileSize;
            }
        }

        public void DrawMarqueeSelectorPreview(SpriteBatch spriteBatch, Texture2D tilesetTexture, Rectangle tileset)
        {
            for (int x = 0; x < rectangle.Width; x += tileset.Width)
            {
                for (int y = 0; y < rectangle.Height; y += tileset.Height)
                {
                    int sourceWidth = Math.Min(rectangle.Width - x, tileset.Width);
                    int sourceHeight = Math.Min(rectangle.Height - y, tileset.Height);

                    var dest = new Rectangle(rectangle.X + x, rectangle.Y + y, sourceWidth, sourceHeight);
                    var source = new Rectangle(tileset.X, tileset.Y, sourceWidth, sourceHeight);

                    spriteBatch.Draw(tilesetTexture, dest, source, Color.White);
                }
            }
        }
    }
}
