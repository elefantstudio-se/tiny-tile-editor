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
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Tiny_Tile_Editor.Properties;
using Tiny_Tile_Editor.Tools;
using Tiny_Tile_Editor.IO;
using Tiny_Tile_Editor.Tiles;
using System.ComponentModel;

namespace Tiny_Tile_Editor.Form_Controls
{
    public partial class MainForm : Form
    {
        #region Variables

        private Map map = new Map();

        private Stack<Edit> undoStack = new Stack<Edit>(), redoStack = new Stack<Edit>();

        private Selection selectorTileset = new Selection(), selectorMarquee = new Selection();

        private Dictionary<ToolStripButton, Tool> tools = new Dictionary<ToolStripButton, Tool>();

        private Tool currentTool;

        private bool tilesetLoaded;

        private string currentFilename = string.Empty;

        private int stepsSinceLastSave;

        private bool ignoreValueChanged;

        private bool mouseInMapDisplay;

        private DisplayDrawer displayDrawer;

        private string dragFilename = string.Empty;

        private BindingList<TileType> tileTypes = new BindingList<TileType>();

        private ComboBox tileTypesComboBox;

        #endregion

        #region Initialization

        public MainForm()
        {
            InitializeComponent();
            InitializeBindings();
            InitializeToolStripCollections();
            InitializeTileTypesComboBox();

            dispTileset.OnDraw += dispTileset_OnDraw;
            dispMap.OnDraw += dispMap_OnDraw;

            MouseWheel += MainForm_MouseWheel;

            Application.Idle += Application_Idle;
        }

        private void InitializeBindings()
        {
            hscMap.DataBindings.Add(new Binding("LargeChange", dispMap, "Width"));
            vscMap.DataBindings.Add(new Binding("LargeChange", dispMap, "Height"));

            hscTileset.DataBindings.Add(new Binding("LargeChange", dispTileset, "Width"));
            vscTileset.DataBindings.Add(new Binding("LargeChange", dispTileset, "Height"));
        }

        private void InitializeToolStripCollections()
        {
            tools.Add(tspBrush, new Brush(selectorTileset));
            tools.Add(tspFill, new Fill());
            tools.Add(tspMarquee, new Marquee(selectorMarquee));

            currentTool = tools[tspBrush];
        }

        private void InitializeTileTypesComboBox()
        {
            tileTypesComboBox = (ComboBox)tspTileTypes.Control;

            tileTypes.Add(new TileType(TileType.DefaultName, 0, System.Drawing.Color.Black));
            tileTypes.Add(new TileType("Collision", -1, System.Drawing.Color.Red));

            tileTypesComboBox.DataSource = tileTypes;

            tileTypesComboBox.DisplayMember = "Name";
            tileTypesComboBox.ValueMember = "Identifier";

            map.TileTypes = tileTypes;

            tileTypesComboBox.SelectedIndex = 0;
        }

        private void dispTileset_OnInitialize(object sender, EventArgs e)
        {
            displayDrawer = new DisplayDrawer(new SpriteBatch(dispTileset.GraphicsDevice), selectorTileset);
        }

        private void Application_Idle(object sender, EventArgs e)
        {
            dispMap.Invalidate();
            dispTileset.Invalidate();
        }

        #endregion

        #region Menu Strip Event Handlers

        private void newMapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (AskSaveMap() == DialogResult.Cancel)
                return;

            ResetEditor();
        }

        private void ResetEditor()
        {
            ClearUndoRedoStack();

            map.Clear();

            Text = Resources.ApplicationName;
            currentFilename = string.Empty;

            hscMap.Value = vscMap.Value = hscTileset.Value = vscTileset.Value = stepsSinceLastSave = map.ActiveLayerIndex = 0;

            SetCurrentLayerText();
        }

        private void SetCurrentLayerText()
        {
            tspLayer.Text = string.Format("{0} / {1}", (map.ActiveLayerIndex + 1), map.TileLayers.Count);
        }

        private void openMapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                OpenMap(openFileDialog.FileName);
            }
        }

        private void saveMapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveMap(false);
        }

        private void saveMapAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveMap(true);
        }

        private void loadTilesetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (loadFileDialog.ShowDialog() == DialogResult.OK)
            {
                LoadTileset(loadFileDialog.FileName);
            }
        }

        private void LoadTileset(string filename)
        {
            if (AskSaveMap() == DialogResult.Cancel)
                return;

            selectorMarquee.Reset();
            selectorTileset.Reset();

            map.TilesetTexture = Texture2D.FromStream(dispTileset.GraphicsDevice, new StreamReader(filename).BaseStream);

            hscTileset.Maximum = map.TilesetTexture.Width;
            vscTileset.Maximum = map.TilesetTexture.Height;

            int layerWidth = (int)numWidth.Value;
            int layerHeight = (int)numHeight.Value;
            int tileSize = (int)numTileSize.Value;

            map.TileLayers.Clear();

            for (int i = 0; i < numLayers.Value; i++)
                map.TileLayers.Add(new TileLayer(map.TilesetTexture, layerWidth, layerHeight, tileSize));

            map.CustomLayer = new TileLayer(map.TilesetTexture, layerWidth, layerHeight, tileSize);

            hscMap.Maximum = map.WidthInPixels;
            vscMap.Maximum = map.HeightInPixels;

            if (!tilesetLoaded)
                BeginEditing();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (AskSaveMap() == DialogResult.Cancel)
                e.Cancel = true;
        }

        private DialogResult AskSaveMap()
        {
            if (stepsSinceLastSave != 0)
            {
                string mapName = File.Exists(currentFilename) ? currentFilename : "this map";

                DialogResult dialogResult = MessageBox.Show(string.Format("Do you want to save changes to {0}?", mapName), Resources.Caption_Unsaved_Changes, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                switch (dialogResult)
                {
                    case DialogResult.Yes:
                        SaveMap(false);
                        return DialogResult.Yes;
                    case DialogResult.Cancel:
                        return DialogResult.Cancel;
                }
            }

            return DialogResult.None;
        }

        private void OpenMap(string filename)
        {
            if (AskSaveMap() == DialogResult.Cancel)
                return;

            MapReader mapReader = new MapReader();

            try
            {
                mapReader.Read(filename, map, tileTypes);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, Resources.Caption_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            ResetForm(filename);
        }

        private void ResetForm(string filename)
        {
            ClearUndoRedoStack();

            stepsSinceLastSave = 0;

            Text = string.Format("{0} - {1}", Resources.ApplicationName, Path.GetFileName(filename));
            currentFilename = filename;

            ChangeActiveLayer(0);

            ignoreValueChanged = true;

            numLayers.Value = map.TileLayers.Count;
            numWidth.Value = map.Width;
            numHeight.Value = map.Height;
            numTileSize.Value = map.TileSize;

            ignoreValueChanged = false;

            selectorMarquee.ChangeTileSize(map.TileSize);
            selectorTileset.ChangeTileSize(map.TileSize);

            hscMap.Value = 0;
            vscMap.Value = 0;

            hscMap.Maximum = map.WidthInPixels;
            vscMap.Maximum = map.HeightInPixels;
        }

        private void SaveMap(bool showDialog)
        {
            MapWriter mapWriter = new MapWriter();

            if (showDialog)
            {
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    mapWriter.Write(saveFileDialog.FileName, map, tileTypes);

                    Text = string.Format("{0} - {1}", Resources.ApplicationName, Path.GetFileName(saveFileDialog.FileName));
                    currentFilename = saveFileDialog.FileName;

                    MessageBox.Show(Resources.Text_Map_Saved, Resources.Caption_Status, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                if (File.Exists(currentFilename))
                    mapWriter.Write(currentFilename, map, tileTypes);
                else
                    SaveMap(true);
            }

            stepsSinceLastSave = 0;
        }

        private void BeginEditing()
        {
            tilesetLoaded = true;

            EnableMenu();
            EnableControls(Controls);

            undoToolStripMenuItem.Enabled = false;
            redoToolStripMenuItem.Enabled = false;

            tspTileTypes.SelectedIndex = 0;
        }

        private void EnableMenu()
        {
            foreach (ToolStripMenuItem menuItem in menuStrip.Items)
                foreach (ToolStripItem item in menuItem.DropDownItems)
                    item.Enabled = true;
        }

        private void EnableControls(Control.ControlCollection Controls)
        {
            foreach (Control c in Controls)
            {
                c.Enabled = true;

                if (c.HasChildren)
                    EnableControls(c.Controls);
            }
        }

        // Edit Menu

        private void clearLayerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PushUndoStack();

            map.ActiveLayer.Clear();
        }

        private void clearCollisionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PushUndoStack();

            map.CustomLayer.Clear();
        }

        private void clearMapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PushUndoStack();

            map.Clear();
        }

        // Help Menu

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Resources.Text_About, Resources.Caption_About, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void tipsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Resources.Text_Tips, Resources.Caption_Tips, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #endregion

        #region ToolStrip Event Handlers

        private void tspTool_Click(object sender, EventArgs e)
        {
            Tool.PaintType = Tool.PaintingType.None;

            var menuItem = (ToolStripButton)sender;

            currentTool = tools[menuItem];

            foreach (ToolStripButton button in tools.Keys)
                button.Checked = false;

            menuItem.Checked = true;
        }

        private void tspLayerDown_Click(object sender, EventArgs e)
        {
            ChangeActiveLayer(Math.Max(map.ActiveLayerIndex - 1, 0));
        }

        private void tspLayerUp_Click(object sender, EventArgs e)
        {
            ChangeActiveLayer(Math.Min(map.ActiveLayerIndex + 1, map.TileLayers.Count - 1));
        }

        private void ChangeActiveLayer(int layerIndex)
        {
            map.ActiveLayerIndex = layerIndex;

            SetCurrentLayerText();
        }

        private void HandleToolStripHotkey(Keys key)
        {
            switch (key)
            {
                case Keys.Q:
                    tspTool_Click(tspBrush, EventArgs.Empty);
                    break;
                case Keys.W:
                    tspTool_Click(tspFill, EventArgs.Empty);
                    break;
                case Keys.E:
                    tspTool_Click(tspMarquee, EventArgs.Empty);
                    break;
                case Keys.A:
                    tspLayerDown_Click(tspLayerDown, EventArgs.Empty);
                    break;
                case Keys.S:
                    tspLayerUp_Click(tspLayerUp, EventArgs.Empty);
                    break;
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (tilesetLoaded && !tspTileTypes.Focused)
                HandleToolStripHotkey(keyData);

            return base.ProcessCmdKey(ref msg, keyData);
        }

        #endregion

        #region Draw TileDisplays

        private void dispMap_OnDraw(object sender, EventArgs e)
        {
            int viewWidth = tilesetLoaded ? Math.Min(dispMap.Width, map.WidthInPixels) : dispMap.Width;
            int viewHeight = tilesetLoaded ? Math.Min(dispMap.Height, map.HeightInPixels) : dispMap.Height;

            Rectangle toolPreviewRect = dragFilename == string.Empty && mouseInMapDisplay ? currentTool.PreviewRect : Rectangle.Empty;
            Rectangle viewingRectangle = new Rectangle(hscMap.Value, vscMap.Value, viewWidth, viewHeight);

            displayDrawer.DrawMap(map, currentTool, toolPreviewRect, viewingRectangle, tileTypes[tileTypesComboBox.SelectedIndex], showOtherLayersToolStripMenuItem.Checked, showCollisionLayerToolStripMenuItem.Checked, showMapGridToolStripMenuItem.Checked, tilesetLoaded);
        }

        private void dispTileset_OnDraw(object sender, EventArgs e)
        {
            int viewWidth = tilesetLoaded ? Math.Min(dispTileset.Width, map.TilesetTexture.Width) : dispTileset.Width;
            int viewHeight = tilesetLoaded ? Math.Min(dispTileset.Height, map.TilesetTexture.Height) : dispTileset.Height;

            Rectangle viewingRectangle = new Rectangle(hscTileset.Value, vscTileset.Value, viewWidth, viewHeight);

            displayDrawer.DrawTileset(map, viewingRectangle, showTilesetGridToolStripMenuItem.Checked, tilesetLoaded);
        }

        #endregion

        #region TileDisplay Mouse Handlers

        private void dispMap_MouseDown(object sender, MouseEventArgs e)
        {
            if (!tilesetLoaded)
                return;

            if ((Tool.PaintType == Tool.PaintingType.Drawing && e.Button == MouseButtons.Right) || (Tool.PaintType == Tool.PaintingType.Erasing && e.Button == MouseButtons.Left)) // If the user cancels the current drawing operation
            {
                if (currentTool is Brush || currentTool is Fill) // If the tool was the marquee the tiles would not have been placed yet and wouldn't need undo-ing
                {
                    map = undoStack.Pop().Undo(map);

                    stepsSinceLastSave--;
                }

                Tool.PaintType = Tool.PaintingType.None;

                return;
            }

            if (Tool.PaintType == Tool.PaintingType.Drawing || Tool.PaintType == Tool.PaintingType.Erasing || (e.Button != MouseButtons.Left && e.Button != MouseButtons.Right)) // If already painting or the user hits non-painting mouse buttons just return
                return;

            dispMap.Focus();

            PushUndoStack();

            selectorMarquee.UpdateOrigin(Tool.Position.X, Tool.Position.Y);

            UseTool(e);

            stepsSinceLastSave++;
        }

        private void dispMap_MouseMove(object sender, MouseEventArgs e)
        {
            Tool.Position = new Point(e.X + hscMap.Value, e.Y + vscMap.Value);

            mouseInMapDisplay = true;

            if (!tilesetLoaded || Tool.PaintType == Tool.PaintingType.None)
                return;

            if (undoStack.Count == 0) // Necessary because if moving very quickly some people can get LMB + MouseMove to fire before MouseDown
                PushUndoStack();

            UseTool(e);
        }

        private void dispMap_MouseUp(object sender, MouseEventArgs e)
        {
            if (!tilesetLoaded || (e.Button != MouseButtons.Left && e.Button != MouseButtons.Right))
                return;

            if (currentTool is Marquee && (Tool.PaintType == Tool.PaintingType.Drawing || Tool.PaintType == Tool.PaintingType.Erasing))
                PaintWithTool();

            if ((e.Button == MouseButtons.Left && Tool.PaintType == Tool.PaintingType.Drawing) || (e.Button == MouseButtons.Right && Tool.PaintType == Tool.PaintingType.Erasing))
                Tool.PaintType = Tool.PaintingType.None;
        }

        private void UseTool(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && Tool.PaintType != Tool.PaintingType.Erasing)
                Tool.PaintType = Tool.PaintingType.Drawing;
            else if (e.Button == MouseButtons.Right && Tool.PaintType != Tool.PaintingType.Drawing)
                Tool.PaintType = Tool.PaintingType.Erasing;

            if (currentTool is Marquee)
                selectorMarquee.UpdateRectangle(Tool.Position.X, Tool.Position.Y);
            else
                PaintWithTool();
        }

        private void PaintWithTool()
        {
            TileType tileType = new TileType(TileType.DefaultName, 1);

            if (tileTypesComboBox.SelectedIndex > 0)
            {
                tileType = new TileType(tileTypes[tileTypesComboBox.SelectedIndex]);
            }

            if (Tool.PaintType == Tool.PaintingType.Erasing)
            {
                tileType.Identifier = 0;
            }

            currentTool.Use(tileTypesComboBox.SelectedIndex == 0 ? map.ActiveLayer : map.CustomLayer, Tool.Position.X / map.TileSize, Tool.Position.Y / map.TileSize, selectorTileset.Rectangle, tileType);
        }

        private bool PaintingConditionsMet(MouseEventArgs e, int xOffset, int yOffset, int xBoundary, int yBoundary)
        {
            return (e.Button == MouseButtons.Left || e.Button == MouseButtons.Right) &&
                   (e.X >= 0 && e.Y >= 0 && e.X + xOffset <= xBoundary && e.Y + yOffset <= yBoundary);
        }

        private void dispTileset_MouseDown(object sender, MouseEventArgs e)
        {
            if (!tilesetLoaded || !PaintingConditionsMet(e, hscTileset.Value, vscTileset.Value, map.TilesetTexture.Width, map.TilesetTexture.Height))
                return;

            dispTileset.Focus();

            selectorTileset.UpdateOrigin(e.X + hscTileset.Value, e.Y + vscTileset.Value);
            selectorTileset.UpdateRectangle(e.X + hscTileset.Value, e.Y + vscTileset.Value);
        }

        private void dispTileset_MouseMove(object sender, MouseEventArgs e)
        {
            mouseInMapDisplay = false;

            if (!tilesetLoaded || !PaintingConditionsMet(e, hscTileset.Value, vscTileset.Value, map.TilesetTexture.Width, map.TilesetTexture.Height))
                return;

            selectorTileset.UpdateRectangle(e.X + hscTileset.Value, e.Y + vscTileset.Value);
        }

        private void MainForm_MouseWheel(object sender, MouseEventArgs e)
        {
            if (mouseInMapDisplay)
            {
                ScrollDisplay(hscMap, vscMap, e.Delta);
            }
            else
            {
                ScrollDisplay(hscTileset, vscTileset, e.Delta);
            }
        }

        private static void ScrollDisplay(ScrollBar hsc, ScrollBar vsc, int delta)
        {
            ScrollBar scr = Microsoft.Xna.Framework.Input.Keyboard.GetState().IsKeyDown(Microsoft.Xna.Framework.Input.Keys.LeftShift) ? hsc : vsc;

            const int scrollAmount = 32;

            scr.Value = delta > 0 ? Math.Max(0, scr.Value - scrollAmount) : Math.Min(scr.Maximum - scr.LargeChange + 1, scr.Value + scrollAmount);
        }

        #endregion

        #region NumericUpDown Map Properties Handlers

        private void numUpDown_KeyDown(object sender, KeyEventArgs e)
        {
            char key = (char)e.KeyCode;

            if (char.IsControl(key) || char.IsDigit(key)) return;

            e.Handled = true;
            e.SuppressKeyPress = true;
        }

        private void numLayers_ValueChanged(object sender, EventArgs e)
        {
            if (ignoreValueChanged) return;

            PushUndoStack();

            int layerValue = (int)numLayers.Value;
            int layerCountDifference = layerValue - map.TileLayers.Count;

            if (layerCountDifference > 0) // Add layers
            {
                List<TileLayer> newLayers = new List<TileLayer>();

                for (int i = 0; i < layerCountDifference; i++)
                    newLayers.Add(new TileLayer(map.TilesetTexture, map.Width, map.Height, map.TileSize));

                map.TileLayers.AddRange(newLayers);
            }
            else if (layerCountDifference < 0) // Remove layers
            {
                List<TileLayer> prevLayers = new List<TileLayer>();

                for (int i = layerValue; i < map.TileLayers.Count; i++)
                    prevLayers.Add(map.TileLayers[i]);

                map.TileLayers.RemoveRange(layerValue, map.TileLayers.Count - layerValue);

                if (map.TileLayers.Count <= map.ActiveLayerIndex)
                    map.ActiveLayerIndex = layerValue - 1;
            }

            SetCurrentLayerText();
        }

        private void numWidth_ValueChanged(object sender, EventArgs e)
        {
            if (ignoreValueChanged) return;

            PushUndoStack();

            map.Width = (int)numWidth.Value;

            hscMap.Maximum = map.WidthInPixels;
            ClampScrollbarValue(hscMap);
        }

        private void numHeight_ValueChanged(object sender, EventArgs e)
        {
            if (ignoreValueChanged) return;

            PushUndoStack();

            map.Height = (int)numHeight.Value;

            vscMap.Maximum = map.HeightInPixels;
            ClampScrollbarValue(vscMap);
        }

        private void numTileSize_ValueChanged(object sender, EventArgs e)
        {
            if (ignoreValueChanged) return;

            if (MessageBox.Show(Resources.Text_Warning_Erase_Map, Resources.Caption_Confirmation, MessageBoxButtons.OKCancel) == DialogResult.Cancel)
            {
                ignoreValueChanged = true;
                numTileSize.Value = map.TileSize;
                ignoreValueChanged = false;
                return;
            }

            PushUndoStack();

            map.TileSize = (int)numTileSize.Value;

            selectorMarquee.ChangeTileSize(map.TileSize);
            selectorTileset.ChangeTileSize(map.TileSize);

            hscMap.Maximum = map.WidthInPixels;
            vscMap.Maximum = map.HeightInPixels;

            ClampScrollbarValue(hscMap);
            ClampScrollbarValue(vscMap);
        }

        #endregion

        #region Undo Redo Support

        private void UpdateControls()
        {
            ignoreValueChanged = true;

            numLayers.Value = map.TileLayers.Count;
            numWidth.Value = map.Width;
            numHeight.Value = map.Height;
            numTileSize.Value = map.TileSize;

            ignoreValueChanged = false;

            hscMap.Maximum = map.WidthInPixels;
            vscMap.Maximum = map.HeightInPixels;

            ClampScrollbarValue(hscMap);
            ClampScrollbarValue(vscMap);

            selectorMarquee.ChangeTileSize(map.TileSize);
            selectorTileset.ChangeTileSize(map.TileSize);

            if (map.TileLayers.Count <= map.ActiveLayerIndex)
                map.ActiveLayerIndex = (int)numLayers.Value - 1;

            SetCurrentLayerText();
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (undoStack.Count < 1)
                return;

            Edit edit = undoStack.Pop();

            map = edit.Undo(map);

            tileTypes = map.TileTypes;

            redoStack.Push(edit);

            stepsSinceLastSave--;

            UpdateControls();

            redoToolStripMenuItem.Enabled = true;

            undoToolStripMenuItem.Enabled = undoStack.Count > 0;
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (redoStack.Count < 1)
                return;

            Edit edit = redoStack.Pop();

            map = edit.Redo();

            tileTypes = map.TileTypes;

            undoStack.Push(edit);

            stepsSinceLastSave++;

            UpdateControls();

            undoToolStripMenuItem.Enabled = true;

            redoToolStripMenuItem.Enabled = redoStack.Count > 0;
        }

        private void PushUndoStack()
        {
            redoStack.Clear();

            redoToolStripMenuItem.Enabled = false;

            undoStack.Push(new Edit(map));

            undoToolStripMenuItem.Enabled = true;
        }

        private void ClearUndoRedoStack()
        {
            undoStack.Clear();
            redoStack.Clear();

            undoToolStripMenuItem.Enabled = redoToolStripMenuItem.Enabled = false;
        }

        #endregion

        #region Scroll Propertly

        private void ClampScrollbarValue(ScrollBar scr)
        {
            scr.Value = (int)MathHelper.Clamp(scr.Value, 0, scr.Maximum - scr.LargeChange + 1);
        }

        private void dispMap_Resize(object sender, EventArgs e)
        {
            ResizeDisplay(hscMap, vscMap, dispMap);
        }

        private void dispTileset_Resize(object sender, EventArgs e)
        {
            ResizeDisplay(hscTileset, vscTileset, dispTileset);
        }

        private void splitContainer_SplitterMoving(object sender, SplitterCancelEventArgs e)
        {
            ResizeDisplay(hscMap, vscMap, dispMap);
            ResizeDisplay(hscTileset, vscTileset, dispTileset);
        }

        private void ResizeDisplay(HScrollBar hsc, VScrollBar vsc, TileDisplay display)
        {
            hsc.LargeChange = display.Width;
            vsc.LargeChange = display.Height;

            ClampScrollbarValue(hsc);
            ClampScrollbarValue(vsc);
        }

        private void Map_Scroll(object sender, ScrollEventArgs e)
        {
            dispMap.Invalidate();
        }

        private void Tileset_Scroll(object sender, ScrollEventArgs e)
        {
            dispTileset.Invalidate();
        }

        #endregion

        #region Drag And Drop Support

        private void GetDragData(DragEventArgs e)
        {
            string[] draggedFilenames = (string[])e.Data.GetData(DataFormats.FileDrop);

            dragFilename = draggedFilenames[0] ?? string.Empty;
        }

        private void dispMap_DragEnter(object sender, DragEventArgs e)
        {
            GetDragData(e);

            string[] extensions = { ".xml" };

            string extension = Path.GetExtension(dragFilename);

            e.Effect = extension != null && (extensions.Any(extension.Contains) && tilesetLoaded) ? DragDropEffects.Move : DragDropEffects.None;
        }

        private void dispTileset_DragEnter(object sender, DragEventArgs e)
        {
            GetDragData(e);

            string[] extensions = { ".png", ".gif", ".jpg", ".jpeg" };

            string extension = Path.GetExtension(dragFilename);

            e.Effect = extension != null && extensions.Any(extension.Contains) ? DragDropEffects.Move : DragDropEffects.None;
        }

        private void dispMap_DragDrop(object sender, DragEventArgs e)
        {
            if (tilesetLoaded)
                OpenMap(dragFilename);

            dragFilename = string.Empty;
        }

        private void dispTileset_DragDrop(object sender, DragEventArgs e)
        {
            LoadTileset(dragFilename);

            dragFilename = string.Empty;
        }

        private void display_DragLeave(object sender, EventArgs e)
        {
            dragFilename = string.Empty;
        }

        #endregion

        private void editTileTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (EditTileTypesForm form = new EditTileTypesForm(map.CustomLayer, tileTypes))
            {
                form.TileTypeChanged += form_TileTypeChanged;

                form.ShowDialog();

                tileTypesComboBox.DataSource = null;

                tileTypesComboBox.DataSource = tileTypes; // Forces the ComboBox to update
            }
        }

        private void form_TileTypeChanged()
        {
            PushUndoStack();
        }
    }
}
