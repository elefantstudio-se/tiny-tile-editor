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
using Tiny_Tile_Editor.Tiles;

namespace Tiny_Tile_Editor.Tools
{
    class Brush : Tool
    {
        private readonly Selection selectorTileset;

        public Brush(Selection selectorTileset)
        {
            this.selectorTileset = selectorTileset;
        }

        public override void Use(TileLayer layer, int tileX, int tileY, Rectangle selectorRect, TileType tileType)
        {
            PaintArea(layer, tileX, tileY, selectorRect, tileType);
        }

        public override void DrawRegularTilePreview(SpriteBatch spriteBatch, Texture2D tilesetTexture, Rectangle previewRect, Rectangle selectorRect)
        {
            spriteBatch.Draw(tilesetTexture, previewRect, selectorRect, Color.White);
        }

        public override void DrawCustomTilePreview(SpriteBatch spriteBatch, Rectangle previewRect, TileType tileType)
        {
            Utility.DrawCustomTile(spriteBatch, previewRect, tileType);
        }

        public override Rectangle PreviewRect
        {
            get
            {
                return new Rectangle(Math.Max(Position.X / selectorTileset.TileSize * selectorTileset.TileSize, 0), Math.Max(Position.Y / selectorTileset.TileSize * selectorTileset.TileSize, 0), selectorTileset.Rectangle.Width, selectorTileset.Rectangle.Height); 
            }
        }
    }
}