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
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using Tiny_Tile_Editor.Properties;
using Tiny_Tile_Editor.Tiles;

namespace Tiny_Tile_Editor.Form_Controls
{
    public partial class EditTileTypesForm : Form
    {
        private TileLayer customLayer;
        private BindingList<TileType> tileTypes;

        public event Action TileTypeChanged;

        public static bool ChangeMade;

        public EditTileTypesForm(TileLayer customLayer, BindingList<TileType> tileTypes)
        {
            InitializeComponent();

            ChangeMade = false;

            this.customLayer = customLayer;
            this.tileTypes = tileTypes;

            listTileTypes.DataSource = tileTypes;

            listTileTypes.SelectedIndex = 0;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            using (AssignTileTypeForm assignTileTypeForm = new AssignTileTypeForm(-1, tileTypes, TileTypeChanged))
            {
                assignTileTypeForm.ShowDialog();

                listTileTypes.Invalidate();
            }
        }

        private void listTileTypes_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            btnEdit.PerformClick();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (listTileTypes.SelectedIndex == 0)
            {
                MessageBox.Show(Resources.Text_Cannot_Edit_Default_Tile_Type, Resources.Caption_Information, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                using (AssignTileTypeForm assignTileTypeForm = new AssignTileTypeForm(listTileTypes.SelectedIndex, tileTypes, TileTypeChanged))
                {
                    int prevTileType = tileTypes[listTileTypes.SelectedIndex].Identifier;

                    assignTileTypeForm.ShowDialog();

                    customLayer.ReplaceTileType(prevTileType, tileTypes[listTileTypes.SelectedIndex]);
                    
                    listTileTypes.Invalidate();
                }
            }
        }

        private void listTileTypes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                btnRemove.PerformClick();
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (listTileTypes.SelectedIndex == 0)
            {
                MessageBox.Show(Resources.Text_Cannot_Remove_Default_Tile_Type, Resources.Caption_Information, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (MessageBox.Show(Resources.Text_Confirm_Delete_Tile_Type, Resources.Caption_Confirmation, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (!ChangeMade)
                    {
                        if (TileTypeChanged != null)
                        {
                            TileTypeChanged();
                        }

                        ChangeMade = true;
                    }

                    int tileType = tileTypes[listTileTypes.SelectedIndex].Identifier;

                    tileTypes.RemoveAt(listTileTypes.SelectedIndex);

                    customLayer.ClearTileType(tileType);
                }
            }
        }

        private void listTileTypes_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();

            if (e.Index < tileTypes.Count) // After removing an item it may draw before the list items are updated via the data source
            {
                TileType tileType = tileTypes[e.Index];

                if (tileType != null)
                {
                    e.Graphics.FillRectangle(new SolidBrush(tileType.Color), new Rectangle(e.Bounds.Location, new Size(e.Bounds.Height, e.Bounds.Height)));

                    e.Graphics.DrawString(string.Format("     [{0}] {1}", tileType.Identifier, tileType.Name), e.Font, Brushes.Black, e.Bounds);
                }
            }

            e.DrawFocusRectangle();
        }

        private void EditTileTypesForm_Resize(object sender, EventArgs e)
        {
            listTileTypes.Invalidate();
        }
    }
}
