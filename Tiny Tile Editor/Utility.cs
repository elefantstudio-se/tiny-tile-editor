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
using Tiny_Tile_Editor.Tiles;

namespace Tiny_Tile_Editor
{
    static class Utility
    {
        private static Texture2D whitePixel;

        public static void DrawRectangle(SpriteBatch spriteBatch, int borderWidth, Rectangle r, Color tint)
        {
            Texture2D workingPixel = whitePixel ?? CreateWhitePixel(spriteBatch.GraphicsDevice);

            spriteBatch.Draw(workingPixel, new Rectangle(r.Left, r.Top, borderWidth, r.Height), tint); // Left
            spriteBatch.Draw(workingPixel, new Rectangle(r.Right, r.Top, borderWidth, r.Height), tint); // Right
            spriteBatch.Draw(workingPixel, new Rectangle(r.Left, r.Top, r.Width, borderWidth), tint); // Top
            spriteBatch.Draw(workingPixel, new Rectangle(r.Left, r.Bottom, r.Width, borderWidth), tint); // Bottom
        }

        public static void DrawRectangle(SpriteBatch spriteBatch, Rectangle r, Color tint)
        {
            Texture2D workingPixel = whitePixel ?? CreateWhitePixel(spriteBatch.GraphicsDevice);

            spriteBatch.Draw(workingPixel, r, tint);
        }

        public static void DrawCustomTile(SpriteBatch spriteBatch, Rectangle r, TileType tileType)
        {
            Texture2D workingPixel = whitePixel ?? CreateWhitePixel(spriteBatch.GraphicsDevice);

            const float alphaAmount = 0.5f;

            int colorR = (int)(tileType.Color.R * alphaAmount);
            int colorG = (int)(tileType.Color.G * alphaAmount);
            int colorB = (int)(tileType.Color.B * alphaAmount);
            int colorA = (int)(tileType.Color.A * alphaAmount);

            Color transparentColor = new Color(colorR, colorG, colorB, colorA);

            spriteBatch.Draw(workingPixel, r, transparentColor);
        }

        private static Texture2D CreateWhitePixel(GraphicsDevice graphicsDevice)
        {
            whitePixel = new Texture2D(graphicsDevice, 1, 1);
            whitePixel.SetData(new[] { Color.White });

            return whitePixel;
        }
    }
}
