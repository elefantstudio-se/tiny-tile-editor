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
using Tiny_Tile_Editor.Tools;

namespace Tiny_Tile_Editor
{
    class DisplayDrawer
    {
        private readonly Color displayClearColor = new Color(240, 240, 240);

        private readonly SpriteBatch spriteBatch;
        private readonly Selection selectorTileset;

        public DisplayDrawer(SpriteBatch spriteBatch, Selection selectorTileset)
        {
            this.spriteBatch = spriteBatch;
            this.selectorTileset = selectorTileset;
        }

        public void DrawMap(Map map, Tool currentTool, Rectangle toolPreviewRect, Rectangle viewingRectangle, TileType tileType, bool showOtherLayers, bool showCollisionLayer, bool showGrid, bool renderDisplay)
        {
            Vector3 previewCamera = new Vector3(-viewingRectangle.X, -viewingRectangle.Y, 0f);

            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, null, null, null, null, Matrix.CreateTranslation(previewCamera));

            spriteBatch.GraphicsDevice.Clear(displayClearColor);

            if (renderDisplay)
            {
                DrawLayersWithToolPreviews(map, currentTool, toolPreviewRect, viewingRectangle, tileType, showOtherLayers, showCollisionLayer);

                if (showGrid)
                    DrawGrid(map.TileSize, viewingRectangle);
            }

            spriteBatch.End();
        }

        public void DrawTileset(Map map, Rectangle viewingRectangle, bool showGrid, bool renderDisplay)
        {
            Vector3 tilesetCamera = new Vector3(-viewingRectangle.X, -viewingRectangle.Y, 0f);

            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, null, null, null, null, Matrix.CreateTranslation(tilesetCamera));

            spriteBatch.GraphicsDevice.Clear(displayClearColor);

            if (renderDisplay)
            {
                spriteBatch.Draw(map.TilesetTexture, Vector2.Zero, Color.White);

                if (showGrid)
                    DrawGrid(map.TileSize, viewingRectangle);

                Utility.DrawRectangle(spriteBatch, 3, selectorTileset.Rectangle, Color.Red); // Tileset selector border
            }

            spriteBatch.End();
        }

        private void DrawGrid(int tileSize, Rectangle viewingRectangle)
        {
            for (int x = viewingRectangle.X; x < viewingRectangle.Width + viewingRectangle.X; x += tileSize)
                for (int y = viewingRectangle.Y; y < viewingRectangle.Height + viewingRectangle.Y; y += tileSize)
                    Utility.DrawRectangle(spriteBatch, 1, new Rectangle(x / tileSize * tileSize, y / tileSize * tileSize, tileSize, tileSize), Color.Black);
        }

        private void DrawLayersWithToolPreviews(Map map, Tool currentTool, Rectangle toolPreviewRect, Rectangle viewingRectangle, TileType tileType, bool showOtherLayers, bool showCollisionLayer)
        {
            Rectangle currentViewingRectangle = new Rectangle(viewingRectangle.X / map.TileSize, viewingRectangle.Y / map.TileSize, viewingRectangle.Width / map.TileSize + 3, viewingRectangle.Height / map.TileSize + 3); // Draw a couple more just in case

            bool isCustomTile = tileType.Identifier != 0;

            foreach (TileLayer layer in map.TileLayers)
            {
                bool isLayerActive = map.ActiveLayerIndex == map.TileLayers.IndexOf(layer);

                if (isLayerActive)
                {
                    if (!isCustomTile)
                    {
                        currentTool.DrawRegularTilePreview(spriteBatch, map.TilesetTexture, toolPreviewRect, selectorTileset.Rectangle);
                    }

                    layer.Draw(spriteBatch, toolPreviewRect, !isCustomTile, currentViewingRectangle); // Draws the layer and skips tiles covered by the tool preview
                }
                else
                {
                    if (showOtherLayers)
                    {
                        layer.Draw(spriteBatch, currentViewingRectangle);
                    }
                }
            }

            if (isCustomTile)
                currentTool.DrawCustomTilePreview(spriteBatch, toolPreviewRect, tileType);

            if (showCollisionLayer)
                map.CustomLayer.Draw(spriteBatch, toolPreviewRect, isCustomTile, currentViewingRectangle); // Draw the collision layer and skip tiles that are covered by the tool preview

            if (toolPreviewRect != Rectangle.Empty)
                Utility.DrawRectangle(spriteBatch, 3, toolPreviewRect, Color.Orange); // Draw border around selector
        }
    }
}
