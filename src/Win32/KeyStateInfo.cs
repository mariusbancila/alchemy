using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Alchemy.Win32
{
   public struct KeyStateInfo
   {
      Keys _key;
      bool _isPressed;
      bool _isToggled;

      public KeyStateInfo(Keys key, bool ispressed, bool istoggled)
      {
         _key = key;
         _isPressed = ispressed;
         _isToggled = istoggled;
      }

      public static KeyStateInfo Default
      {
         get
         {
            return new KeyStateInfo(Keys.None, false, false);
         }
      }

      public Keys Key
      {
         get { return _key; }
      }

      public bool IsPressed
      {
         get { return _isPressed; }
      }

      public bool IsToggled
      {
         get { return _isToggled; }
      }
   }
}
