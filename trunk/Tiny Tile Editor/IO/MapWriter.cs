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

using System.Xml;

namespace Tiny_Tile_Editor.IO
{
    class MapWriter
    {
        private const string tileSeparator = ",";

        private Map map;

        private int tilesetTileWidth;

        public void Write(string filename, Map map)
        {
            this.map = map;

            tilesetTileWidth = map.TilesetTexture.Width / map.TileSize;

            using (XmlWriter writer = XmlWriter.Create(filename))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("Map");

                WriteDimensions(writer);
                WriteLayout(writer);

                writer.WriteEndElement();
                writer.WriteEndDocument();
            }
        }

        private void WriteDimensions(XmlWriter writer)
        {
            writer.WriteStartElement("Dimensions");

            writer.WriteElementString("Width", map.Width.ToString());
            writer.WriteElementString("Height", map.Height.ToString());
            writer.WriteElementString("TileSize", map.TileSize.ToString());
            writer.WriteElementString("LayerCount", map.TileLayers.Count.ToString());

            writer.WriteEndElement();
        }

        private void WriteLayout(XmlWriter writer)
        {
            writer.WriteStartElement("Layout");

            for (int i = 0; i < map.TileLayers.Count; i++)
            {
                writer.WriteStartElement("Layer");

                writer.WriteStartAttribute("ID");
                writer.WriteValue(i);
                writer.WriteEndAttribute();

                WriteRows(writer, map.TileLayers[i]);

                writer.WriteEndElement();
            }

            writer.WriteStartElement("CollisionLayer");
            WriteRows(writer, map.CollisionLayer);
            writer.WriteEndElement();

            writer.WriteEndElement();
        }

        private void WriteRows(XmlWriter writer, TileLayer layer)
        {
            for (int y = 0; y < map.Height; y++)
            {
                writer.WriteStartElement("Row");

                var row = new string[map.Width];

                for (int x = 0; x < map.Width; x++)
                {
                    Tile tile = layer.GetTile(x, y);

                    switch (tile.TileType)
                    {
                        case Tile.Type.Empty:
                            row[x] = "-1";
                            break;
                        case Tile.Type.Collision:
                            row[x] = "0";
                            break;
                        case Tile.Type.Regular:
                            row[x] = (tile.Rectangle.Y / tile.Rectangle.Height * tilesetTileWidth + tile.Rectangle.X / tile.Rectangle.Width).ToString();
                            break;
                        default:
                            row[x] = "-1";
                            break;
                    }                        
                }

                writer.WriteValue(string.Join(tileSeparator, row));

                writer.WriteEndElement();
            }
        }
    }
}
