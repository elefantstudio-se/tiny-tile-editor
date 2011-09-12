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

namespace Tiny_Tile_Editor.Form_Controls
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newMapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openMapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveMapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveMapAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.loadTilesetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.editTileTypesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.clearActiveLayerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearCustomLayerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearMapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showMapGridToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showTilesetGridToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.showOtherLayersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showCollisionLayerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tipsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.hscMap = new System.Windows.Forms.HScrollBar();
            this.vscMap = new System.Windows.Forms.VScrollBar();
            this.dispMap = new Tiny_Tile_Editor.Form_Controls.TileDisplay();
            this.hscTileset = new System.Windows.Forms.HScrollBar();
            this.vscTileset = new System.Windows.Forms.VScrollBar();
            this.dispTileset = new Tiny_Tile_Editor.Form_Controls.TileDisplay();
            this.lblTileSize = new System.Windows.Forms.Label();
            this.lblHeight = new System.Windows.Forms.Label();
            this.lblWidth = new System.Windows.Forms.Label();
            this.lblLayers = new System.Windows.Forms.Label();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.tspBrush = new System.Windows.Forms.ToolStripButton();
            this.tspFill = new System.Windows.Forms.ToolStripButton();
            this.tspMarquee = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.tspLayerDown = new System.Windows.Forms.ToolStripButton();
            this.tspLayer = new System.Windows.Forms.ToolStripLabel();
            this.tspLayerUp = new System.Windows.Forms.ToolStripButton();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.tspTileTypes = new System.Windows.Forms.ToolStripComboBox();
            this.numTileSize = new Tiny_Tile_Editor.Form_Controls.NonScrollingNumericUpDown();
            this.numHeight = new Tiny_Tile_Editor.Form_Controls.NonScrollingNumericUpDown();
            this.numWidth = new Tiny_Tile_Editor.Form_Controls.NonScrollingNumericUpDown();
            this.numLayers = new Tiny_Tile_Editor.Form_Controls.NonScrollingNumericUpDown();
            this.menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.toolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTileSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLayers)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.Color.Transparent;
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(974, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newMapToolStripMenuItem,
            this.openMapToolStripMenuItem,
            this.saveMapToolStripMenuItem,
            this.saveMapAsToolStripMenuItem,
            this.toolStripMenuSeparator1,
            this.loadTilesetToolStripMenuItem,
            this.toolStripMenuSeparator2,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newMapToolStripMenuItem
            // 
            this.newMapToolStripMenuItem.Enabled = false;
            this.newMapToolStripMenuItem.Image = global::Tiny_Tile_Editor.Properties.Resources.map_new;
            this.newMapToolStripMenuItem.Name = "newMapToolStripMenuItem";
            this.newMapToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newMapToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.newMapToolStripMenuItem.Text = "&New Map";
            this.newMapToolStripMenuItem.Click += new System.EventHandler(this.newMapToolStripMenuItem_Click);
            // 
            // openMapToolStripMenuItem
            // 
            this.openMapToolStripMenuItem.Enabled = false;
            this.openMapToolStripMenuItem.Image = global::Tiny_Tile_Editor.Properties.Resources.map_open;
            this.openMapToolStripMenuItem.Name = "openMapToolStripMenuItem";
            this.openMapToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openMapToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.openMapToolStripMenuItem.Text = "&Open Map";
            this.openMapToolStripMenuItem.Click += new System.EventHandler(this.openMapToolStripMenuItem_Click);
            // 
            // saveMapToolStripMenuItem
            // 
            this.saveMapToolStripMenuItem.Enabled = false;
            this.saveMapToolStripMenuItem.Image = global::Tiny_Tile_Editor.Properties.Resources.map_save;
            this.saveMapToolStripMenuItem.Name = "saveMapToolStripMenuItem";
            this.saveMapToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveMapToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.saveMapToolStripMenuItem.Text = "&Save Map";
            this.saveMapToolStripMenuItem.Click += new System.EventHandler(this.saveMapToolStripMenuItem_Click);
            // 
            // saveMapAsToolStripMenuItem
            // 
            this.saveMapAsToolStripMenuItem.Enabled = false;
            this.saveMapAsToolStripMenuItem.Image = global::Tiny_Tile_Editor.Properties.Resources.map_save_as;
            this.saveMapAsToolStripMenuItem.Name = "saveMapAsToolStripMenuItem";
            this.saveMapAsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift)
                        | System.Windows.Forms.Keys.S)));
            this.saveMapAsToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.saveMapAsToolStripMenuItem.Text = "S&ave Map As";
            this.saveMapAsToolStripMenuItem.Click += new System.EventHandler(this.saveMapAsToolStripMenuItem_Click);
            // 
            // toolStripMenuSeparator1
            // 
            this.toolStripMenuSeparator1.Name = "toolStripMenuSeparator1";
            this.toolStripMenuSeparator1.Size = new System.Drawing.Size(210, 6);
            // 
            // loadTilesetToolStripMenuItem
            // 
            this.loadTilesetToolStripMenuItem.Image = global::Tiny_Tile_Editor.Properties.Resources.tileset_load;
            this.loadTilesetToolStripMenuItem.Name = "loadTilesetToolStripMenuItem";
            this.loadTilesetToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.L)));
            this.loadTilesetToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.loadTilesetToolStripMenuItem.Text = "&Load Tileset";
            this.loadTilesetToolStripMenuItem.Click += new System.EventHandler(this.loadTilesetToolStripMenuItem_Click);
            // 
            // toolStripMenuSeparator2
            // 
            this.toolStripMenuSeparator2.Name = "toolStripMenuSeparator2";
            this.toolStripMenuSeparator2.Size = new System.Drawing.Size(210, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Image = global::Tiny_Tile_Editor.Properties.Resources.exit;
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoToolStripMenuItem,
            this.redoToolStripMenuItem,
            this.toolStripMenuSeparator3,
            this.editTileTypesToolStripMenuItem,
            this.toolStripMenuSeparator4,
            this.clearActiveLayerToolStripMenuItem,
            this.clearCustomLayerToolStripMenuItem,
            this.clearMapToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Enabled = false;
            this.undoToolStripMenuItem.Image = global::Tiny_Tile_Editor.Properties.Resources.undo;
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.undoToolStripMenuItem.Text = "&Undo";
            this.undoToolStripMenuItem.Click += new System.EventHandler(this.undoToolStripMenuItem_Click);
            // 
            // redoToolStripMenuItem
            // 
            this.redoToolStripMenuItem.Enabled = false;
            this.redoToolStripMenuItem.Image = global::Tiny_Tile_Editor.Properties.Resources.redo;
            this.redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            this.redoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
            this.redoToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.redoToolStripMenuItem.Text = "&Redo";
            this.redoToolStripMenuItem.Click += new System.EventHandler(this.redoToolStripMenuItem_Click);
            // 
            // toolStripMenuSeparator3
            // 
            this.toolStripMenuSeparator3.Name = "toolStripMenuSeparator3";
            this.toolStripMenuSeparator3.Size = new System.Drawing.Size(174, 6);
            // 
            // editTileTypesToolStripMenuItem
            // 
            this.editTileTypesToolStripMenuItem.Enabled = false;
            this.editTileTypesToolStripMenuItem.Image = global::Tiny_Tile_Editor.Properties.Resources.edit_tile_types;
            this.editTileTypesToolStripMenuItem.Name = "editTileTypesToolStripMenuItem";
            this.editTileTypesToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.editTileTypesToolStripMenuItem.Text = "Edit Tile Types";
            this.editTileTypesToolStripMenuItem.Click += new System.EventHandler(this.editTileTypesToolStripMenuItem_Click);
            // 
            // toolStripMenuSeparator4
            // 
            this.toolStripMenuSeparator4.Name = "toolStripMenuSeparator4";
            this.toolStripMenuSeparator4.Size = new System.Drawing.Size(174, 6);
            // 
            // clearActiveLayerToolStripMenuItem
            // 
            this.clearActiveLayerToolStripMenuItem.Enabled = false;
            this.clearActiveLayerToolStripMenuItem.Image = global::Tiny_Tile_Editor.Properties.Resources.clear_active_layer;
            this.clearActiveLayerToolStripMenuItem.Name = "clearActiveLayerToolStripMenuItem";
            this.clearActiveLayerToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.clearActiveLayerToolStripMenuItem.Text = "Clear Active Layer";
            this.clearActiveLayerToolStripMenuItem.Click += new System.EventHandler(this.clearLayerToolStripMenuItem_Click);
            // 
            // clearCustomLayerToolStripMenuItem
            // 
            this.clearCustomLayerToolStripMenuItem.Enabled = false;
            this.clearCustomLayerToolStripMenuItem.Image = global::Tiny_Tile_Editor.Properties.Resources.clear_collision_layer;
            this.clearCustomLayerToolStripMenuItem.Name = "clearCustomLayerToolStripMenuItem";
            this.clearCustomLayerToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.clearCustomLayerToolStripMenuItem.Text = "Clear Custom Layer";
            this.clearCustomLayerToolStripMenuItem.Click += new System.EventHandler(this.clearCollisionToolStripMenuItem_Click);
            // 
            // clearMapToolStripMenuItem
            // 
            this.clearMapToolStripMenuItem.Enabled = false;
            this.clearMapToolStripMenuItem.Image = global::Tiny_Tile_Editor.Properties.Resources.clear_map;
            this.clearMapToolStripMenuItem.Name = "clearMapToolStripMenuItem";
            this.clearMapToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.clearMapToolStripMenuItem.Text = "Clear Map";
            this.clearMapToolStripMenuItem.Click += new System.EventHandler(this.clearMapToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showMapGridToolStripMenuItem,
            this.showTilesetGridToolStripMenuItem,
            this.toolStripMenuSeparator5,
            this.showOtherLayersToolStripMenuItem,
            this.showCollisionLayerToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // showMapGridToolStripMenuItem
            // 
            this.showMapGridToolStripMenuItem.Checked = true;
            this.showMapGridToolStripMenuItem.CheckOnClick = true;
            this.showMapGridToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showMapGridToolStripMenuItem.Image = global::Tiny_Tile_Editor.Properties.Resources.show_grid;
            this.showMapGridToolStripMenuItem.Name = "showMapGridToolStripMenuItem";
            this.showMapGridToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.showMapGridToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.showMapGridToolStripMenuItem.Text = "Show &Map Grid";
            // 
            // showTilesetGridToolStripMenuItem
            // 
            this.showTilesetGridToolStripMenuItem.Checked = true;
            this.showTilesetGridToolStripMenuItem.CheckOnClick = true;
            this.showTilesetGridToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showTilesetGridToolStripMenuItem.Image = global::Tiny_Tile_Editor.Properties.Resources.show_grid;
            this.showTilesetGridToolStripMenuItem.Name = "showTilesetGridToolStripMenuItem";
            this.showTilesetGridToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.showTilesetGridToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.showTilesetGridToolStripMenuItem.Text = "Show &Tileset Grid";
            // 
            // toolStripMenuSeparator5
            // 
            this.toolStripMenuSeparator5.Name = "toolStripMenuSeparator5";
            this.toolStripMenuSeparator5.Size = new System.Drawing.Size(199, 6);
            // 
            // showOtherLayersToolStripMenuItem
            // 
            this.showOtherLayersToolStripMenuItem.Checked = true;
            this.showOtherLayersToolStripMenuItem.CheckOnClick = true;
            this.showOtherLayersToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showOtherLayersToolStripMenuItem.Image = global::Tiny_Tile_Editor.Properties.Resources.show_other_layers;
            this.showOtherLayersToolStripMenuItem.Name = "showOtherLayersToolStripMenuItem";
            this.showOtherLayersToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F3;
            this.showOtherLayersToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.showOtherLayersToolStripMenuItem.Text = "Show &Other Layers";
            // 
            // showCollisionLayerToolStripMenuItem
            // 
            this.showCollisionLayerToolStripMenuItem.Checked = true;
            this.showCollisionLayerToolStripMenuItem.CheckOnClick = true;
            this.showCollisionLayerToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showCollisionLayerToolStripMenuItem.Image = global::Tiny_Tile_Editor.Properties.Resources.show_collision_layer;
            this.showCollisionLayerToolStripMenuItem.Name = "showCollisionLayerToolStripMenuItem";
            this.showCollisionLayerToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F4;
            this.showCollisionLayerToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.showCollisionLayerToolStripMenuItem.Text = "Show &Collision Layer";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem,
            this.tipsToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Image = global::Tiny_Tile_Editor.Properties.Resources.about;
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "&About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // tipsToolStripMenuItem
            // 
            this.tipsToolStripMenuItem.Image = global::Tiny_Tile_Editor.Properties.Resources.tips;
            this.tipsToolStripMenuItem.Name = "tipsToolStripMenuItem";
            this.tipsToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.tipsToolStripMenuItem.Text = "&Tips";
            this.tipsToolStripMenuItem.Click += new System.EventHandler(this.tipsToolStripMenuItem_Click);
            // 
            // loadFileDialog
            // 
            this.loadFileDialog.Filter = "Image Files |*.jpg;*.jpeg;*.gif;*.png;|JPEG Files (*.jpg;*.jpeg)|*.jpg;*.jpeg|GIF" +
                " Files (*.gif)|*.gif|PNG Files (*.png)|*.png";
            // 
            // splitContainer
            // 
            this.splitContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer.Location = new System.Drawing.Point(12, 52);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.hscMap);
            this.splitContainer.Panel1.Controls.Add(this.vscMap);
            this.splitContainer.Panel1.Controls.Add(this.dispMap);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.hscTileset);
            this.splitContainer.Panel2.Controls.Add(this.vscTileset);
            this.splitContainer.Panel2.Controls.Add(this.dispTileset);
            this.splitContainer.Size = new System.Drawing.Size(950, 623);
            this.splitContainer.SplitterDistance = 471;
            this.splitContainer.TabIndex = 0;
            this.splitContainer.TabStop = false;
            this.splitContainer.SplitterMoving += new System.Windows.Forms.SplitterCancelEventHandler(this.splitContainer_SplitterMoving);
            // 
            // hscMap
            // 
            this.hscMap.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.hscMap.Enabled = false;
            this.hscMap.Location = new System.Drawing.Point(0, 606);
            this.hscMap.Name = "hscMap";
            this.hscMap.Size = new System.Drawing.Size(454, 17);
            this.hscMap.TabIndex = 0;
            this.hscMap.Scroll += new System.Windows.Forms.ScrollEventHandler(this.Map_Scroll);
            // 
            // vscMap
            // 
            this.vscMap.Dock = System.Windows.Forms.DockStyle.Right;
            this.vscMap.Enabled = false;
            this.vscMap.Location = new System.Drawing.Point(454, 0);
            this.vscMap.Name = "vscMap";
            this.vscMap.Size = new System.Drawing.Size(17, 623);
            this.vscMap.TabIndex = 0;
            this.vscMap.Scroll += new System.Windows.Forms.ScrollEventHandler(this.Map_Scroll);
            // 
            // dispMap
            // 
            this.dispMap.AllowDrop = true;
            this.dispMap.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dispMap.Location = new System.Drawing.Point(3, 3);
            this.dispMap.Name = "dispMap";
            this.dispMap.Size = new System.Drawing.Size(448, 600);
            this.dispMap.TabIndex = 0;
            this.dispMap.TabStop = false;
            this.dispMap.Text = "Map Display";
            this.dispMap.DragDrop += new System.Windows.Forms.DragEventHandler(this.dispMap_DragDrop);
            this.dispMap.DragEnter += new System.Windows.Forms.DragEventHandler(this.dispMap_DragEnter);
            this.dispMap.DragLeave += new System.EventHandler(this.display_DragLeave);
            this.dispMap.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dispMap_MouseDown);
            this.dispMap.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dispMap_MouseMove);
            this.dispMap.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dispMap_MouseUp);
            this.dispMap.Resize += new System.EventHandler(this.dispMap_Resize);
            // 
            // hscTileset
            // 
            this.hscTileset.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.hscTileset.Enabled = false;
            this.hscTileset.Location = new System.Drawing.Point(0, 606);
            this.hscTileset.Name = "hscTileset";
            this.hscTileset.Size = new System.Drawing.Size(458, 17);
            this.hscTileset.TabIndex = 0;
            this.hscTileset.Scroll += new System.Windows.Forms.ScrollEventHandler(this.Tileset_Scroll);
            // 
            // vscTileset
            // 
            this.vscTileset.Dock = System.Windows.Forms.DockStyle.Right;
            this.vscTileset.Enabled = false;
            this.vscTileset.Location = new System.Drawing.Point(458, 0);
            this.vscTileset.Name = "vscTileset";
            this.vscTileset.Size = new System.Drawing.Size(17, 623);
            this.vscTileset.TabIndex = 0;
            this.vscTileset.Scroll += new System.Windows.Forms.ScrollEventHandler(this.Tileset_Scroll);
            // 
            // dispTileset
            // 
            this.dispTileset.AllowDrop = true;
            this.dispTileset.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dispTileset.Location = new System.Drawing.Point(3, 3);
            this.dispTileset.Name = "dispTileset";
            this.dispTileset.Size = new System.Drawing.Size(452, 600);
            this.dispTileset.TabIndex = 0;
            this.dispTileset.TabStop = false;
            this.dispTileset.Text = "Tileset Display";
            this.dispTileset.OnInitialize += new System.EventHandler(this.dispTileset_OnInitialize);
            this.dispTileset.DragDrop += new System.Windows.Forms.DragEventHandler(this.dispTileset_DragDrop);
            this.dispTileset.DragEnter += new System.Windows.Forms.DragEventHandler(this.dispTileset_DragEnter);
            this.dispTileset.DragLeave += new System.EventHandler(this.display_DragLeave);
            this.dispTileset.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dispTileset_MouseDown);
            this.dispTileset.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dispTileset_MouseMove);
            this.dispTileset.Resize += new System.EventHandler(this.dispTileset_Resize);
            // 
            // lblTileSize
            // 
            this.lblTileSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTileSize.AutoSize = true;
            this.lblTileSize.BackColor = System.Drawing.Color.Transparent;
            this.lblTileSize.Enabled = false;
            this.lblTileSize.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTileSize.Location = new System.Drawing.Point(832, 28);
            this.lblTileSize.Margin = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.lblTileSize.Name = "lblTileSize";
            this.lblTileSize.Size = new System.Drawing.Size(52, 15);
            this.lblTileSize.TabIndex = 0;
            this.lblTileSize.Text = "Tile Size:";
            // 
            // lblHeight
            // 
            this.lblHeight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblHeight.AutoSize = true;
            this.lblHeight.Enabled = false;
            this.lblHeight.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblHeight.Location = new System.Drawing.Point(717, 28);
            this.lblHeight.Margin = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.lblHeight.Name = "lblHeight";
            this.lblHeight.Size = new System.Drawing.Size(46, 15);
            this.lblHeight.TabIndex = 0;
            this.lblHeight.Text = "Height:";
            // 
            // lblWidth
            // 
            this.lblWidth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblWidth.AutoSize = true;
            this.lblWidth.Enabled = false;
            this.lblWidth.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblWidth.Location = new System.Drawing.Point(606, 28);
            this.lblWidth.Margin = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.lblWidth.Name = "lblWidth";
            this.lblWidth.Size = new System.Drawing.Size(42, 15);
            this.lblWidth.TabIndex = 0;
            this.lblWidth.Text = "Width:";
            // 
            // lblLayers
            // 
            this.lblLayers.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLayers.AutoSize = true;
            this.lblLayers.Enabled = false;
            this.lblLayers.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblLayers.Location = new System.Drawing.Point(494, 28);
            this.lblLayers.Margin = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.lblLayers.Name = "lblLayers";
            this.lblLayers.Size = new System.Drawing.Size(43, 15);
            this.lblLayers.TabIndex = 0;
            this.lblLayers.Text = "Layers:";
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.DefaultExt = "xml";
            this.saveFileDialog.Filter = "Map Files (*.xml)|*.xml";
            // 
            // openFileDialog
            // 
            this.openFileDialog.DefaultExt = "xml";
            this.openFileDialog.Filter = "Map Files (*.xml)|*.xml";
            // 
            // tspBrush
            // 
            this.tspBrush.Checked = true;
            this.tspBrush.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tspBrush.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tspBrush.Image = global::Tiny_Tile_Editor.Properties.Resources.tool_brush;
            this.tspBrush.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tspBrush.Name = "tspBrush";
            this.tspBrush.Size = new System.Drawing.Size(23, 22);
            this.tspBrush.Text = "Brush (Q)";
            this.tspBrush.Click += new System.EventHandler(this.tspTool_Click);
            // 
            // tspFill
            // 
            this.tspFill.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tspFill.Image = global::Tiny_Tile_Editor.Properties.Resources.tool_fill;
            this.tspFill.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tspFill.Name = "tspFill";
            this.tspFill.Size = new System.Drawing.Size(23, 22);
            this.tspFill.Text = "Fill (W)";
            this.tspFill.Click += new System.EventHandler(this.tspTool_Click);
            // 
            // tspMarquee
            // 
            this.tspMarquee.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tspMarquee.Image = global::Tiny_Tile_Editor.Properties.Resources.tool_marquee;
            this.tspMarquee.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tspMarquee.Name = "tspMarquee";
            this.tspMarquee.Size = new System.Drawing.Size(23, 22);
            this.tspMarquee.Text = "Marquee (E)";
            this.tspMarquee.Click += new System.EventHandler(this.tspTool_Click);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // tspLayerDown
            // 
            this.tspLayerDown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tspLayerDown.Image = global::Tiny_Tile_Editor.Properties.Resources.layer_down;
            this.tspLayerDown.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tspLayerDown.Name = "tspLayerDown";
            this.tspLayerDown.Size = new System.Drawing.Size(23, 22);
            this.tspLayerDown.Text = "Layer Down (A)";
            this.tspLayerDown.Click += new System.EventHandler(this.tspLayerDown_Click);
            // 
            // tspLayer
            // 
            this.tspLayer.BackColor = System.Drawing.Color.Transparent;
            this.tspLayer.Name = "tspLayer";
            this.tspLayer.Size = new System.Drawing.Size(30, 22);
            this.tspLayer.Text = "1 / 3";
            this.tspLayer.ToolTipText = "Current Layer";
            // 
            // tspLayerUp
            // 
            this.tspLayerUp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tspLayerUp.Image = global::Tiny_Tile_Editor.Properties.Resources.layer_up;
            this.tspLayerUp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tspLayerUp.Name = "tspLayerUp";
            this.tspLayerUp.Size = new System.Drawing.Size(23, 22);
            this.tspLayerUp.Text = "Layer Up (S)";
            this.tspLayerUp.Click += new System.EventHandler(this.tspLayerUp_Click);
            // 
            // toolStrip
            // 
            this.toolStrip.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip.Enabled = false;
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tspBrush,
            this.tspFill,
            this.tspMarquee,
            this.toolStripSeparator,
            this.tspLayerDown,
            this.tspLayer,
            this.tspLayerUp,
            this.tspTileTypes});
            this.toolStrip.Location = new System.Drawing.Point(0, 24);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(974, 25);
            this.toolStrip.TabIndex = 0;
            this.toolStrip.Text = "Tool Strip";
            // 
            // tspTileTypes
            // 
            this.tspTileTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tspTileTypes.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.tspTileTypes.Name = "tspTileTypes";
            this.tspTileTypes.Size = new System.Drawing.Size(121, 25);
            // 
            // numTileSize
            // 
            this.numTileSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numTileSize.Enabled = false;
            this.numTileSize.Location = new System.Drawing.Point(885, 26);
            this.numTileSize.Margin = new System.Windows.Forms.Padding(1, 3, 3, 3);
            this.numTileSize.Maximum = new decimal(new int[] {
            256,
            0,
            0,
            0});
            this.numTileSize.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numTileSize.Name = "numTileSize";
            this.numTileSize.Size = new System.Drawing.Size(60, 20);
            this.numTileSize.TabIndex = 4;
            this.numTileSize.Value = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.numTileSize.ValueChanged += new System.EventHandler(this.numTileSize_ValueChanged);
            this.numTileSize.KeyDown += new System.Windows.Forms.KeyEventHandler(this.numUpDown_KeyDown);
            // 
            // numHeight
            // 
            this.numHeight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numHeight.Enabled = false;
            this.numHeight.Location = new System.Drawing.Point(764, 26);
            this.numHeight.Margin = new System.Windows.Forms.Padding(1, 3, 3, 3);
            this.numHeight.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numHeight.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numHeight.Name = "numHeight";
            this.numHeight.Size = new System.Drawing.Size(60, 20);
            this.numHeight.TabIndex = 3;
            this.numHeight.Value = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.numHeight.ValueChanged += new System.EventHandler(this.numHeight_ValueChanged);
            this.numHeight.KeyDown += new System.Windows.Forms.KeyEventHandler(this.numUpDown_KeyDown);
            // 
            // numWidth
            // 
            this.numWidth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numWidth.Enabled = false;
            this.numWidth.Location = new System.Drawing.Point(649, 26);
            this.numWidth.Margin = new System.Windows.Forms.Padding(1, 3, 3, 3);
            this.numWidth.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numWidth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numWidth.Name = "numWidth";
            this.numWidth.Size = new System.Drawing.Size(60, 20);
            this.numWidth.TabIndex = 2;
            this.numWidth.Value = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.numWidth.ValueChanged += new System.EventHandler(this.numWidth_ValueChanged);
            this.numWidth.KeyDown += new System.Windows.Forms.KeyEventHandler(this.numUpDown_KeyDown);
            // 
            // numLayers
            // 
            this.numLayers.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numLayers.Enabled = false;
            this.numLayers.Location = new System.Drawing.Point(538, 26);
            this.numLayers.Margin = new System.Windows.Forms.Padding(1, 3, 3, 3);
            this.numLayers.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numLayers.Name = "numLayers";
            this.numLayers.Size = new System.Drawing.Size(60, 20);
            this.numLayers.TabIndex = 1;
            this.numLayers.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numLayers.ValueChanged += new System.EventHandler(this.numLayers_ValueChanged);
            this.numLayers.KeyDown += new System.Windows.Forms.KeyEventHandler(this.numUpDown_KeyDown);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(974, 687);
            this.Controls.Add(this.numTileSize);
            this.Controls.Add(this.numHeight);
            this.Controls.Add(this.numWidth);
            this.Controls.Add(this.numLayers);
            this.Controls.Add(this.lblLayers);
            this.Controls.Add(this.lblWidth);
            this.Controls.Add(this.lblHeight);
            this.Controls.Add(this.lblTileSize);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.MinimumSize = new System.Drawing.Size(690, 425);
            this.Name = "MainForm";
            this.Text = "Tiny Tile Editor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTileSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLayers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TileDisplay dispMap;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newMapToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openMapToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveMapToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuSeparator1;
        private System.Windows.Forms.ToolStripMenuItem loadTilesetToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuSeparator2;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redoToolStripMenuItem;
        private TileDisplay dispTileset;
        private System.Windows.Forms.OpenFileDialog loadFileDialog;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showMapGridToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showTilesetGridToolStripMenuItem;
        private System.Windows.Forms.HScrollBar hscMap;
        private System.Windows.Forms.VScrollBar vscMap;
        private System.Windows.Forms.HScrollBar hscTileset;
        private System.Windows.Forms.VScrollBar vscTileset;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuSeparator3;
        private System.Windows.Forms.ToolStripMenuItem clearMapToolStripMenuItem;
        private System.Windows.Forms.Label lblTileSize;
        private System.Windows.Forms.Label lblHeight;
        private System.Windows.Forms.Label lblWidth;
        private System.Windows.Forms.Label lblLayers;
        private System.Windows.Forms.ToolStripMenuItem clearActiveLayerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showOtherLayersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showCollisionLayerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearCustomLayerToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.ToolStripMenuItem saveMapAsToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tipsToolStripMenuItem;
        private NonScrollingNumericUpDown numLayers;
        private NonScrollingNumericUpDown numWidth;
        private NonScrollingNumericUpDown numHeight;
        private NonScrollingNumericUpDown numTileSize;
        private System.Windows.Forms.ToolStripButton tspBrush;
        private System.Windows.Forms.ToolStripButton tspFill;
        private System.Windows.Forms.ToolStripButton tspMarquee;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripButton tspLayerDown;
        private System.Windows.Forms.ToolStripLabel tspLayer;
        private System.Windows.Forms.ToolStripButton tspLayerUp;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuSeparator5;
        private System.Windows.Forms.ToolStripComboBox tspTileTypes;
        private System.Windows.Forms.ToolStripMenuItem editTileTypesToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuSeparator4;
    }
}

