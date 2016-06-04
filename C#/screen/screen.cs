using System.Drawing;  
using System.Drawing.Imaging; 
using System.Windows.Forms;

class A
{
  public static void Main(string[] args)
  {  
    Bitmap printscreen = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
    Graphics graphics = Graphics.FromImage(printscreen as Image);
    graphics.CopyFromScreen(0, 0, 0, 0, printscreen.Size);
    printscreen.Save("printscreen.png", ImageFormat.Png);
  }
}