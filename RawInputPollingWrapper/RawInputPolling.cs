using System;
using System.Windows.Forms;
using DXNET.Multimedia;
using DXNET.RawInput;


namespace RawInputPollingWrapper
{
    public class RawInputPolling
    {
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
            throw new NotImplementedException();
        }

        private void DeviceOnMouseInput(object? sender, MouseInputEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}