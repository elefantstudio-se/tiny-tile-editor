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
    class Fill : Tool
    {
        public override void Use(TileLayer layer, int tileX, int tileY, Rectangle selectorRect, Tile.Type tileType)
        {
            int tileWidth = selectorRect.Width / layer.TileSize;
            int tileHeight = selectorRect.Height / layer.TileSize;

            for (int x = 0; x < layer.Width; x += tileWidth)
                for (int y = 0; y < layer.Height; y += tileHeight)
                    PaintArea(layer, x, y, selectorRect, tileType);
        }

        public override void DrawRegularPreview(SpriteBatch spriteBatch, Texture2D tilesetTexture, Rectangle previewRect, Rectangle selectorRect)
        {
            // The fill tool has no preview
        }

        public override void DrawCollisionPreview(SpriteBatch spriteBatch, Rectangle previewRect)
        {
            // The fill tool has no preview
        }

        public override Rectangle PreviewRect
        {
            get
            {
                return Rectangle.Empty;
            }
        }
    }
}
