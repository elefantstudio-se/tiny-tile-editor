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
using System.Xml.Linq;
using System.Collections.Generic;

using Microsoft.Xna.Framework;

namespace Tiny_Tile_Editor.IO
{
    class MapReader
    {
        private const char tileSeparator = ',';

        private Map map;

        private List<Tile[,]> tileLayers = new List<Tile[,]>();
        private Tile[,] collisionLayer;

        private MapDimensions mapDimensions;

        private struct MapDimensions
        {
            public int Width, Height, TileSize, LayerCount;
        }

        public void Read(string filename, Map map)
        {
            this.map = map;

            XDocument xReader = XDocument.Load(filename);

            ParseDimensions(xReader);

            InitializeMap();

            ParseLayout(xReader);

            WriteToLayers();
        }

        private void ParseDimensions(XDocument xReader)
        {
            IEnumerable<XElement> dimensions = xReader.Descendants("Dimensions").Elements();

            Dictionary<string, int> mapDimensionsDictionary = new Dictionary<string, int>();

            foreach (XElement e in dimensions)
            {
                string elementName = e.Name.ToString();

                int elementValue;

                if (int.TryParse(e.Value, out elementValue))
                    mapDimensionsDictionary[elementName] = elementValue;
                else
                    throw new FormatException("The map file could not be read because its " + elementName.ToLower() + " is not an integer.");
            }

            if (mapDimensionsDictionary.ContainsKey("Width")) mapDimensions.Width = mapDimensionsDictionary["Width"];
            else throw new KeyNotFoundException("The map file could not be read because the map's width was not found.");

            if (mapDimensionsDictionary.ContainsKey("Height")) mapDimensions.Height = mapDimensionsDictionary["Height"];
            else throw new KeyNotFoundException("The map file could not be read because the map's height was not found.");

            if (mapDimensionsDictionary.ContainsKey("TileSize")) mapDimensions.TileSize = mapDimensionsDictionary["TileSize"];
            else throw new KeyNotFoundException("The map file could not be read because the map's tile size was not found.");

            if (mapDimensionsDictionary.ContainsKey("LayerCount")) mapDimensions.LayerCount = mapDimensionsDictionary["LayerCount"];
            else throw new KeyNotFoundException("The map file could not be read because the map's layer count was not found.");
        }

        private void InitializeMap()
        {
            for (int i = 0; i < mapDimensions.LayerCount; i++)
            {
                tileLayers.Add(new Tile[mapDimensions.Height, mapDimensions.Width]);
            }

            collisionLayer = new Tile[mapDimensions.Height, mapDimensions.Width];
        }

        private void ParseLayout(XDocument xReader)
        {
            IEnumerable<XElement> layout = xReader.Descendants("Layout").Elements();

            foreach (XElement layer in layout)
                ParseLayer(layer);
        }

        private void ParseLayer(XElement layer)
        {
            IEnumerable<XElement> rows = layer.Elements();

            int y = 0;

            int currentLayerIndex = -1;

            if (layer.HasAttributes)
            {
                XAttribute layerID = layer.Attribute("ID");

                if (layerID != null && !int.TryParse(layerID.Value, out currentLayerIndex))
                    throw new FormatException("The map file could not be read because one of its layers has a malformed ID.");
            }

            foreach (XElement row in rows)
            {
                string[] contents = row.Value.Split(tileSeparator);

                for (int x = 0; x < contents.Length; x++)
                {
                    ParseTile(currentLayerIndex, contents[x], x, y);
                }

                y++;
            }
        }

        private void ParseTile(int currentLayerIndex, string tileContent, int x, int y)
        {
            int tileValue;

            if (int.TryParse(tileContent, out tileValue))
            {
                int tilesetTileWidth = map.TilesetTexture.Width / mapDimensions.TileSize;

                int ts = mapDimensions.TileSize;

                Tile newTile = tileValue == -1 ? new Tile(Tile.Type.Empty) : new Tile(new Rectangle((tileValue % tilesetTileWidth) * ts, (tileValue / tilesetTileWidth) * ts, ts, ts), Tile.Type.Regular);

                if (currentLayerIndex == -1 && tileValue == 0)
                    newTile.TileType = Tile.Type.Collision;

                if (currentLayerIndex == -1)
                    collisionLayer[y, x] = newTile;
                else
                    tileLayers[currentLayerIndex][y, x] = newTile;
            }
            else
            {
                throw new FormatException(string.Format("The map file could not be read because the tile at layer {0}, row {1}, column {2} is malformed.", currentLayerIndex + 1, y + 1, x + 1));
            }
        }

        private void WriteToLayers()
        {
            map.TileLayers.Clear();

            for (int i = 0; i < mapDimensions.LayerCount; i++)
            {
                map.TileLayers.Add(new TileLayer(map.TilesetTexture, mapDimensions.Width, mapDimensions.Height, mapDimensions.TileSize));

                map.TileLayers[i].SetTiles(tileLayers[i]);
            }

            map.CollisionLayer = new TileLayer(map.TilesetTexture, mapDimensions.Width, mapDimensions.Height, mapDimensions.TileSize);

            map.CollisionLayer.SetTiles(collisionLayer);
        }
    }
}
