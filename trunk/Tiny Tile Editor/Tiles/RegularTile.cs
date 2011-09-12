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

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Tiny_Tile_Editor.Tiles
{
    class RegularTile : Tile
    {
        public const int Identifier = 1;

        private readonly Rectangle rectangle;
        private readonly int tilesetTileWidth;

        public RegularTile(Rectangle rectangle, int tilesetTileWidth)
        {
            this.rectangle = rectangle;
            this.tilesetTileWidth = tilesetTileWidth;
        }

        public int Value
        {
            get
            {
                return (rectangle.Y / rectangle.Height * tilesetTileWidth + rectangle.X / rectangle.Width) + 1;
            }
        }

        public void Draw(SpriteBatch spriteBatch, Rectangle destination, Texture2D tileset)
        {
            spriteBatch.Draw(tileset, destination, rectangle, Color.White);
        }
    }
}
