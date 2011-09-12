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
using System.Linq;
using System.Windows.Forms;

using Tiny_Tile_Editor.Properties;
using Tiny_Tile_Editor.Tiles;

namespace Tiny_Tile_Editor.Form_Controls
{
    public partial class AssignTileTypeForm : Form
    {
        private int index;
        private BindingList<TileType> tileTypes;
        private event Action tileTypeChanged;

        public AssignTileTypeForm(int index, BindingList<TileType> tileTypes, Action tileTypeChanged)
        {
            InitializeComponent();

            this.index = index;
            this.tileTypes = tileTypes;
            this.tileTypeChanged = tileTypeChanged;

            if (index == -1)
            {
                txtName.Text = @"New Tile Type";

                txtIdentifier.Text = (tileTypes[tileTypes.Count - 1].Identifier - 1).ToString();

                Random r = new Random();

                picColorPreview.BackColor = System.Drawing.Color.FromArgb(r.Next(0, 256), r.Next(0, 256), r.Next(0, 256));
            }
            else
            {
                TileType tileType = tileTypes[index];

                txtName.Text = tileType.Name;
                txtIdentifier.Text = tileType.Identifier.ToString();
                picColorPreview.BackColor = tileType.Color;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string tileName = txtName.Text.Trim();

            if (tileName == string.Empty)
            {
                MessageBox.Show(Resources.Text_Invalid_Tile_Type_Name, Resources.Caption_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int tileIdentifier;

            if (int.TryParse(txtIdentifier.Text, out tileIdentifier) && tileIdentifier < 0)
            {
                if (index == -1)
                {
                    if (tileTypes.Any(t => t.Identifier == tileIdentifier))
                    {
                        MessageBox.Show(Resources.Text_Identifier_In_Use, Resources.Caption_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);

                        return;
                    }

                    if (!EditTileTypesForm.ChangeMade)
                    {
                        if (tileTypeChanged != null)
                        {
                            tileTypeChanged();
                        }

                        EditTileTypesForm.ChangeMade = true;
                    }

                    tileTypes.Add(new TileType(tileName, tileIdentifier, picColorPreview.BackColor));
                }
                else
                {
                    TileType tileType = tileTypes[index];

                    if (!EditTileTypesForm.ChangeMade)
                    {
                        if (tileType.Name != tileName || tileType.Identifier != tileIdentifier || tileType.Color.ToArgb() != picColorPreview.BackColor.ToArgb())
                        {
                            tileTypeChanged();

                            EditTileTypesForm.ChangeMade = true;
                        }
                    }

                    tileType.Name = tileName;
                    tileType.Identifier = tileIdentifier;
                    tileType.Color = picColorPreview.BackColor;
                }

                Close();
            }
            else
            {
                MessageBox.Show(Resources.Text_Invalid_Tile_Type_Identifier, Resources.Caption_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtIdentifier_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar) || char.IsDigit(e.KeyChar) || e.KeyChar == '-') return;

            e.Handled = true;
        }

        private void picColorPreview_DoubleClick(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                picColorPreview.BackColor = colorDialog.Color;
            }
        }
    }
}
