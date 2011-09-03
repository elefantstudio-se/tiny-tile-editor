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
    class Utility
    {
        private static Texture2D whitePixel;

        public static void DrawRectangle(SpriteBatch spriteBatch, int borderWidth, Rectangle r, Color tint)
        {
            if (whitePixel == null)
            {
                CreateWhitePixel(spriteBatch.GraphicsDevice);
            }

            spriteBatch.Draw(whitePixel, new Rectangle(r.Left, r.Top, borderWidth, r.Height), tint); // Left
            spriteBatch.Draw(whitePixel, new Rectangle(r.Right, r.Top, borderWidth, r.Height), tint); // Right
            spriteBatch.Draw(whitePixel, new Rectangle(r.Left, r.Top, r.Width, borderWidth), tint); // Top
            spriteBatch.Draw(whitePixel, new Rectangle(r.Left, r.Bottom, r.Width, borderWidth), tint); // Bottom
        }

        public static void DrawRectangle(SpriteBatch spriteBatch, Rectangle r, Color tint)
        {
            if (whitePixel == null)
            {
                CreateWhitePixel(spriteBatch.GraphicsDevice);
            }

            spriteBatch.Draw(whitePixel, r, tint);
        }

        private static void CreateWhitePixel(GraphicsDevice graphicsDevice)
        {
            whitePixel = new Texture2D(graphicsDevice, 1, 1);
            whitePixel.SetData(new[] { Color.White });
        }
    }
}
