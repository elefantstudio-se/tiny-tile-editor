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

namespace Tiny_Tile_Editor.Tools
{
    public abstract class Tool
    {
        public abstract void Use(TileLayer layer, int tileX, int tileY, Rectangle selectorRect, TileType tileType);

        public abstract void DrawRegularTilePreview(SpriteBatch spriteBatch, Texture2D tilesetTexture, Rectangle previewRect, Rectangle selectorRect);
        public abstract void DrawCustomTilePreview(SpriteBatch spriteBatch, Rectangle previewRect, TileType tileType);

        public enum PaintingType
        {
            Drawing,
            Erasing,
            None
        }

        public static Point Position = Point.Zero;
        public static PaintingType PaintType = PaintingType.None;

        public void PaintArea(TileLayer layer, int tileX, int tileY, Rectangle selectorRect, TileType tileType)
        {
            int selectorTileWidth = selectorRect.Width / layer.TileSize;
            int selectorTileHeight = selectorRect.Height / layer.TileSize;

            for (int x = 0; x < selectorTileWidth; x++)
            {
                for (int y = 0; y < selectorTileHeight; y++)
                {
                    Rectangle tileRect = new Rectangle(selectorRect.X + (x * layer.TileSize), selectorRect.Y + (y * layer.TileSize), layer.TileSize, layer.TileSize);

                    Tile replacementTile = TileFactory.Get(tileType, tileRect, layer.TilesetTileWidth);

                    bool inBounds = tileX + x >= 0 && tileY + y >= 0 && tileX + x < layer.Width && tileY + y < layer.Height;

                    if (inBounds)
                    {
                        if (layer.GetTile(tileX + x, tileY + y).Value == replacementTile.Value)
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
