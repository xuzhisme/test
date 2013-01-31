using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace GIFViewer
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (args.Length == 1)
            {
                string file = args[0];
               
                if (System.IO.File.Exists(file))
                {
                    if (file.EndsWith(".gif"))
                    {
                        try
                        {
                            System.Drawing.Image gif = System.Drawing.Image.FromFile(file);
                            Application.Run(new FormMain(gif));
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            Environment.Exit(0);
                        }

                    }
                    else
                    {
                        Application.Run(new FormMain(file));
                    }
                   
                }
                else
                {
                    MessageBox.Show("文件不存在!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                Application.Run(new FormMain());
            }
        }
    }
}
