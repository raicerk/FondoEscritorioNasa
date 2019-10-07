using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FondoEscritorioNasa
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        [SuppressUnmanagedCodeSecurity, SecurityCritical,

        DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool SystemParametersInfo(int nAction,int nParam, string value, int ignore);

        private void Button1_Click(object sender, EventArgs e)
        {
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    String wallpaper = openFileDialog1.FileName;
                    //Mediante la API de windows actualizamos el fondo de escritorio pasando el path en la variable wallpaper
                    SystemParametersInfo(20, 0, wallpaper, 0);
                    //Mediante el registro de windows Actualizamos el valor que es el path del wallpaper
                    //Registry.CurrentUser.OpenSubKey(@"Control Panel\Desktop", RegistryKeyPermissionCheck.ReadWriteSubTree).SetValue("wallpaper", wallpaper);
                }
            }
        }
    }
}
