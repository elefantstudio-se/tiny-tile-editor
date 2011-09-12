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
using System.ComponentModel;

using Microsoft.Xna.Framework.Graphics;
using Tiny_Tile_Editor.Tiles;

namespace Tiny_Tile_Editor
{
    public class Map // Mostly a container
    {
        public List<TileLayer> TileLayers = new List<TileLayer>();

        public BindingList<TileType> TileTypes = new BindingList<TileType>();

        public Map()
        {

        }

        public Map(Map mapCopy)
        {
            TileTypes = new BindingList<TileType>();

            foreach (TileType tileType in mapCopy.TileTypes)
            {
                TileTypes.Add(new TileType(tileType));
            }

            TilesetTexture = mapCopy.TilesetTexture;

            CustomLayer = new TileLayer(mapCopy.CustomLayer);
            TileLayers = new List<TileLayer>();

            foreach (TileLayer layer in mapCopy.TileLayers)
                TileLayers.Add(new TileLayer(layer));
        }

        public int ActiveLayerIndex
        {
            get;
            set;
        }

        public Texture2D TilesetTexture
        {
            get;
            set;
        }

        public TileLayer CustomLayer
        {
            get;
            set;
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
                return CustomLayer.Width;
            }
            set
            {
                foreach (TileLayer layer in TileLayers)
                    layer.Width = value;

                CustomLayer.Width = value;
            }
        }

        public int WidthInPixels
        {
            get
            {
                return CustomLayer.Width * CustomLayer.TileSize;
            }
        }

        public int Height
        {
            get
            {
                return CustomLayer.Height;
            }
            set
            {
                foreach (TileLayer layer in TileLayers)
                    layer.Height = value;

                CustomLayer.Height = value;
            }
        }

        public int HeightInPixels
        {
            get
            {
                return CustomLayer.Height * CustomLayer.TileSize;
            }
        }

        public int TileSize
        {
            get
            {
                return CustomLayer.TileSize;
            }
            set
            {
                foreach (TileLayer layer in TileLayers)
                    layer.TileSize = value;

                CustomLayer.TileSize = value;
            }
        }

        public void Clear()
        {
            foreach (TileLayer layer in TileLayers)
                layer.Clear();

            CustomLayer.Clear();
        }
    }
}
