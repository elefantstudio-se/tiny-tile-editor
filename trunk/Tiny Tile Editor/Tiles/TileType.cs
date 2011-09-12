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

using System.Drawing;

namespace Tiny_Tile_Editor.Tiles
{
    public class TileType
    {
        public const string DefaultName = "Regular";

        public string Name { get; set; }
        public int Identifier { get; set; }
        public Color Color { get; set; }

        public TileType(string name, int identifier) : this(name, identifier, Color.White) { }

        public TileType(string name, int identifier, Color color)
        {
            Name = name;
            Identifier = identifier;
            Color = color;
        }

        public TileType(TileType copy)
        {
            Name = copy.Name;
            Identifier = copy.Identifier;
            Color = copy.Color;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
