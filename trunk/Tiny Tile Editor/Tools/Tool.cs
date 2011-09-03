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

namespace Tiny_Tile_Editor.Tools
{
    public abstract class Tool
    {
        public abstract void Use(TileLayer layer, int tileX, int tileY, Rectangle selectorRect, Tile.Type tileType);

        public abstract void DrawRegularPreview(SpriteBatch spriteBatch, Texture2D tilesetTexture, Rectangle previewRect, Rectangle selectorRect);
        public abstract void DrawCollisionPreview(SpriteBatch spriteBatch, Rectangle previewRect);

        public enum PaintingType
        {
            Drawing,
            Erasing,
            None
        }

        public static Point Position = Point.Zero;
        public static PaintingType PaintType = PaintingType.None;

        public void PaintArea(TileLayer layer, int tileX, int tileY, Rectangle selectorRect, Tile.Type tileType)
        {
            int selectorTileWidth = selectorRect.Width / layer.TileSize;
            int selectorTileHeight = selectorRect.Height / layer.TileSize;

            for (int x = 0; x < selectorTileWidth; x++)
            {
                for (int y = 0; y < selectorTileHeight; y++)
                {
                    Tile replacementTile = new Tile(new Rectangle(selectorRect.X + (x * layer.TileSize), selectorRect.Y + (y * layer.TileSize), layer.TileSize, layer.TileSize), tileType);

                    bool inBounds = tileX + x >= 0 && tileY + y >= 0 && tileX + x < layer.Width && tileY + y < layer.Height;

                    if (inBounds)
                    {
                        if (layer.GetTile(tileX + x, tileY + y) == replacementTile)
                            continue;

                        layer.SetTile(tileX + x, tileY + y, replacementTile);
                    }
                }
            }
        }

        public abstract Rectangle PreviewRect
        {
            get;
        }
    }
}
