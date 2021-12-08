using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DXNET.Multimedia;
using DXNET.RawInput;


namespace RawInputPollingWrapper
{
    public class RawInputPolling
    {
        private HashSet<uint> keysDown = new HashSet<uint>();
        private int mouseX=0;
        private int mouseY=0;
        private int wheelDelta=0;
        private int mouseButtonPressed = 0;

        public int MouseX
        {
            get => mouseX;
        }
        
        public int MouseY
        {
            get => mouseY;
            
        }

        public int MouseWheel
        {
            get => wheelDelta;
        }
        
        public int MouseButtons
        {
            get => mouseButtonPressed;

        }

        public uint[] KeysPressed
        {
            get => keysDown.ToArray();
        }

        RawInputPolling()
        {
            // setup the device
            Device.RegisterDevice(UsagePage.Generic, UsageId.GenericMouse, DeviceFlags.None);
            Device.MouseInput += DeviceOnMouseInput;

            Device.RegisterDevice(UsagePage.Generic, UsageId.GenericKeyboard, DeviceFlags.None);
            Device.KeyboardInput += DeviceOnKeyboardInput;
            
            Device.RegisterDevice(UsagePage.Generic, UsageId.GenericJoystick, DeviceFlags.None);
            Device.RawInput += DeviceOnRawInput;

            Application.Run(); // just message pump, no window
        }

        private void DeviceOnRawInput(object? sender, RawInputEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void DeviceOnKeyboardInput(object? sender, KeyboardInputEventArgs e)
        {
            if (e.State == KeyState.KeyDown)
            {
                keysDown.Add((uint)e.Key);
            }
            else if (e.State == KeyState.KeyUp)
            {
                keysDown.Remove((uint) e.Key);
            }
        }

        private void DeviceOnMouseInput(object? sender, MouseInputEventArgs e)
        {
            if (e.Mode == MouseMode.MoveAbsolute)
            {
                mouseX = e.X;
                mouseY = e.Y;
            }
            else
            {
                mouseX += e.X;
                mouseY += e.Y;
            }
            wheelDelta += e.WheelDelta;
            mouseButtonPressed = e.Buttons;
        }
        
      
    }
}