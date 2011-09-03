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
    class Marquee : Tool
    {
        private readonly Selection selection;

        public Marquee(Selection selection)
        {
            this.selection = selection;
        }

        public override void Use(TileLayer layer, int tileX, int tileY, Rectangle selectorRect, Tile.Type tileType)
        {
            for (int x = 0; x < selection.Rectangle.Width / layer.TileSize; x += selectorRect.Width / layer.TileSize)
            {
                for (int y = 0; y < selection.Rectangle.Height / layer.TileSize; y += selectorRect.Height / layer.TileSize)
                {
                    Rectangle r = new Rectangle(selectorRect.X, selectorRect.Y, selection.Rectangle.Width - (x * layer.TileSize), selection.Rectangle.Height - (y * layer.TileSize));

                    PaintArea(layer, x + (selection.Rectangle.X / layer.TileSize), y + (selection.Rectangle.Y / layer.TileSize), r, tileType);
                }
            }
        }

        public override void DrawRegularPreview(SpriteBatch spriteBatch, Texture2D tilesetTexture, Rectangle previewRect, Rectangle selectorRect)
        {
            if (PaintType == PaintingType.Drawing)
            {
                selection.DrawMarqueeSelectorPreview(spriteBatch, tilesetTexture, selectorRect);
            }
        }

        public override void DrawCollisionPreview(SpriteBatch spriteBatch, Rectangle previewRect)
        {
            if (PaintType == PaintingType.Drawing)
            {
                Utility.DrawRectangle(spriteBatch, previewRect, Tile.CollisionTileColor);
            }
        }

        public override Rectangle PreviewRect
        {
            get
            {
                return (PaintType == PaintingType.Drawing || PaintType == PaintingType.Erasing) ? selection.Rectangle : Rectangle.Empty;
            }
        }
    }
}
