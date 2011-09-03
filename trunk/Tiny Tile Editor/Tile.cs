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

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Tiny_Tile_Editor
{
    public class Tile
    {
        private Rectangle rectangle;
        private Type type;

        public static readonly Color CollisionTileColor = new Color(255, 0, 0, 50);

        public Rectangle Rectangle
        {
            get
            {
                return rectangle;
            }
        }

        public Tile(Type type)
        {
            this.type = type;

            rectangle = Rectangle.Empty;
        }

        public Tile(Rectangle rectangle, Type type)
        {
            this.type = type;
            this.rectangle = rectangle;

            if (type == Type.Collision || type == Type.Empty)
                this.rectangle = Rectangle.Empty;
        }

        public enum Type
        {
            Collision,
            Empty,
            Regular
        }

        public Type TileType
        {
            get
            {
                return type;
            }
            set
            {
                type = value;

                if (type == Type.Collision || type == Type.Empty)
                    rectangle = Rectangle.Empty;
            }
        }

        public void Draw(SpriteBatch spriteBatch, Rectangle destination, Texture2D tileset)
        {
            switch (type)
            {
                case Type.Collision:
                    Utility.DrawRectangle(spriteBatch, destination, CollisionTileColor);
                    break;
                case Type.Regular:
                    spriteBatch.Draw(tileset, destination, rectangle, Color.White);
                    break;
            }
        }
    }
}
