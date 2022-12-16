using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Alchemy.Win32
{
   internal static class KeyboardInfo
   {
      public static KeyStateInfo GetKeyState(Keys key)
      {
         short keyState = NativeMethods.GetKeyState((int)key);
         bool pressed = (keyState & 0x8000) == 0x8000;
         bool toggled = (keyState & 0x0001) == 0x0001;
         return new KeyStateInfo(key, pressed, toggled);
      }
   }

   internal static class NativeMethods
   {
      [DllImport("user32")]
      internal static extern short GetKeyState(int vKey);
   }
}
