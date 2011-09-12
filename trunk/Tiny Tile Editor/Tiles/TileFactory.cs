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

namespace Tiny_Tile_Editor.Tiles
{
    static class TileFactory
    {
        public static Tile Get(TileType tileType, Rectangle tileRect, int tilesetTileWidth)
        {
            switch (tileType.Identifier)
            {
                case RegularTile.Identifier:
                    return new RegularTile(tileRect, tilesetTileWidth);
                case EmptyTile.Identifier:
                    return new EmptyTile();
                default:
                    return new CustomTile(tileType);
            }
        }
    }
}
