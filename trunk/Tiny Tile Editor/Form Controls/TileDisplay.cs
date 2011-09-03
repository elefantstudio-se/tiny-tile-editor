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
using System.Drawing;
using System.Windows.Forms;

using Microsoft.Xna.Framework.Graphics;

using Rectangle = Microsoft.Xna.Framework.Rectangle;

#pragma warning disable 67

namespace Tiny_Tile_Editor.Form_Controls
{
    class TileDisplay : Control, IGraphicsDeviceService
    {
        private static readonly Color designerBackColor = Color.FromArgb(240, 240, 240);

        private static GraphicsDevice graphicsDevice;
        private static PresentationParameters parameters;

        public GraphicsDevice GraphicsDevice
        {
            get
            {
                return graphicsDevice;
            }
        }

        public event EventHandler OnInitialize;
        public event EventHandler OnDraw;

        protected void Initialize()
        {
            if (OnInitialize != null)
                OnInitialize(this, null);
        }

        protected void Draw()
        {
            if (OnDraw != null)
                OnDraw(this, null);
        }

        protected override void OnCreateControl()
        {
            if (!DesignMode)
            {
                if (parameters == null && graphicsDevice == null)
                {
                    CreateGraphicsDevice(Handle, ClientSize.Width, ClientSize.Height);
                }

                Initialize();
            }

            base.OnCreateControl();
        }

        private static void CreateGraphicsDevice(IntPtr windowHandle, int width, int height)
        {
            parameters = new PresentationParameters
            {
                BackBufferWidth = Math.Max(width, 1),
                BackBufferHeight = Math.Max(height, 1),
                BackBufferFormat = SurfaceFormat.Color,
                DepthStencilFormat = DepthFormat.Depth24,
                DeviceWindowHandle = windowHandle,
                PresentationInterval = PresentInterval.Immediate,
                IsFullScreen = false
            };

            graphicsDevice = new GraphicsDevice(GraphicsAdapter.DefaultAdapter, GraphicsProfile.Reach, parameters);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (CanDraw())
            {
                Draw();
                FinishDraw();
            }
            else
            {
                e.Graphics.Clear(designerBackColor);
            }
        }

        private bool CanDraw()
        {
            if (graphicsDevice == null || IsDeviceAvailable() == false)
                return false;

            GraphicsDevice.Viewport = new Viewport
            {
                X = 0,
                Y = 0,
                Width = ClientSize.Width,
                Height = ClientSize.Height,
                MinDepth = 0,
                MaxDepth = 1
            };

            return true;
        }

        private void FinishDraw()
        {
            try
            {
                Rectangle sourceRectangle = new Rectangle(0, 0, ClientSize.Width, ClientSize.Height);

                GraphicsDevice.Present(sourceRectangle, null, Handle);
            }
            catch
            {
                // GULP
            }
        }

        private bool IsDeviceAvailable()
        {
            bool deviceNeedsReset;

            switch (graphicsDevice.GraphicsDeviceStatus)
            {
                case GraphicsDeviceStatus.Lost:
                    return false;
                case GraphicsDeviceStatus.NotReset:
                    deviceNeedsReset = true;
                    break;
                default:
                    deviceNeedsReset = (ClientSize.Width > parameters.BackBufferWidth) || (ClientSize.Height > parameters.BackBufferHeight);
                    break;
            }

            if (deviceNeedsReset)
            {
                try
                {
                    ResetDevice(ClientSize.Width, ClientSize.Height);
                }
                catch
                {
                    return false;
                }
            }

            return true;
        }

        protected override void OnPaintBackground(PaintEventArgs p) { }

        public event EventHandler<EventArgs> DeviceCreated;
        public event EventHandler<EventArgs> DeviceDisposing;
        public event EventHandler<EventArgs> DeviceReset;
        public event EventHandler<EventArgs> DeviceResetting;

        protected override void Dispose(bool disposing)
        {
            if (graphicsDevice != null)
            {
                if (DeviceDisposing != null)
                    DeviceDisposing(this, EventArgs.Empty);

                graphicsDevice.Dispose();
            }

            graphicsDevice = null;

            base.Dispose(disposing);
        }

        public void ResetDevice(int width, int height)
        {
            if (DeviceResetting != null)
                DeviceResetting(this, EventArgs.Empty);

            parameters.BackBufferWidth = Math.Max(parameters.BackBufferWidth, width);
            parameters.BackBufferHeight = Math.Max(parameters.BackBufferHeight, height);

            graphicsDevice.Reset(parameters);

            if (DeviceReset != null)
                DeviceReset(this, EventArgs.Empty);
        }
    }
}
