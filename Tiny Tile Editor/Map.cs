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

using System.Collections.Generic;

using Microsoft.Xna.Framework.Graphics;

namespace Tiny_Tile_Editor
{
    public class Map // Mostly a container
    {
        public int ActiveLayerIndex;

        public TileLayer CollisionLayer;

        public List<TileLayer> TileLayers = new List<TileLayer>();

        public Texture2D TilesetTexture;

        public Map()
        {

        }

        public Map(Map mapCopy)
        {
            TilesetTexture = mapCopy.TilesetTexture;

            CollisionLayer = new TileLayer(mapCopy.CollisionLayer);
            TileLayers = new List<TileLayer>();

            foreach (TileLayer layer in mapCopy.TileLayers)
                TileLayers.Add(new TileLayer(layer));
        }

        public TileLayer ActiveLayer
        {
            get
            {
                return TileLayers[ActiveLayerIndex];
            }
        }

        public int Width
        {
            get
            {
                return CollisionLayer.Width;
            }
            set
            {
                foreach (TileLayer layer in TileLayers)
                    layer.Width = value;

                CollisionLayer.Width = value;
            }
        }

        public int WidthInPixels
        {
            get
            {
                return CollisionLayer.Width * CollisionLayer.TileSize;
            }
        }

        public int Height
        {
            get
            {
                return CollisionLayer.Height;
            }
            set
            {
                foreach (TileLayer layer in TileLayers)
                    layer.Height = value;

                CollisionLayer.Height = value;
            }
        }

        public int HeightInPixels
        {
            get
            {
                return CollisionLayer.Height * CollisionLayer.TileSize;
            }
        }

        public int TileSize
        {
            get
            {
                return CollisionLayer.TileSize;
            }
            set
            {
                foreach (TileLayer layer in TileLayers)
                    layer.TileSize = value;

                CollisionLayer.TileSize = value;
            }
        }

        public void Clear()
        {
            foreach (TileLayer layer in TileLayers)
                layer.Clear();

            CollisionLayer.Clear();
        }
    }
}
