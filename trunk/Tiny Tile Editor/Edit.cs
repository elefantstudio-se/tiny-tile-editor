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

namespace Tiny_Tile_Editor
{
    public class Edit
    {
        private Map undoMap, redoMap;

        public Edit(Map map)
        {
            undoMap = new Map(map);
        }

        public Map Redo()
        {
            if (redoMap == null) throw new ArgumentNullException("Redo layer is null.");

            return redoMap;
        }

        public Map Undo(Map activeMap)
        {
            redoMap = new Map(activeMap);

            return undoMap;
        }
    }
}
