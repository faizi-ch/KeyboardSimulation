using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using Microsoft.Win32;

namespace KeyboardSimulation
{
    public partial class Form1 : Form
    {
        private const int WM_SETTEXT = 0x000c;

        private const int WM_KEYDOWN = 0x0100;

        private IntPtr hWndNotepad;
        private IntPtr hWndEdit;
        private System.Timers.Timer timer;
        private int x=0;
        private bool running;
        private string programName ="";
        public Form1()
        {
            InitializeComponent();

        }

        private void xTextBox1_TextChanged(object sender, EventArgs e)
        {
            x = Convert.ToInt32(xTextBox1.Text);
        }

        private void hitButton_Click(object sender, EventArgs e)
        {
            if (xTextBox1.Text=="")
            {
                MessageBox.Show("Enter x", "Empty textbox", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            x = Convert.ToInt32(xTextBox1.Text);
           

            hWndEdit = NativeMethods.FindWindowEx(hWndNotepad, IntPtr.Zero, "Edit", null);
            NativeMethods.SetForegroundWindow(hWndNotepad);

            //NativeMethods.SendMessage(hWndEdit, WM_SETTEXT, 0, " key");

            switch (x)
            {
                case 2:
                    {
                        SendKeys.SendWait("{k}");
                        NativeMethods.PostMessage(hWndNotepad, WM_KEYDOWN, Keys.E, IntPtr.Zero);
                        NativeMethods.PostMessage(hWndNotepad, WM_KEYDOWN, Keys.E, IntPtr.Zero);
                    }
                    break;
                case 3:
                    {
                        NativeMethods.PostMessage(hWndNotepad, WM_KEYDOWN, Keys.J, IntPtr.Zero);
                        NativeMethods.PostMessage(hWndNotepad, WM_KEYDOWN, Keys.J, IntPtr.Zero);
                        NativeMethods.PostMessage(hWndNotepad, WM_KEYDOWN, Keys.J, IntPtr.Zero);
                        NativeMethods.PostMessage(hWndNotepad, WM_KEYDOWN, Keys.J, IntPtr.Zero);
                        NativeMethods.PostMessage(hWndNotepad, WM_KEYDOWN, Keys.J, IntPtr.Zero);
                    }
                    break;
                case 4:
                {
                        timer = new System.Timers.Timer();
                        timer.Interval = 3000;
                        timer.Elapsed += new ElapsedEventHandler(timer_Elapsed);
                        timer.Enabled = true;
                        running = true;
                    hitButton.Enabled = false;
                    xTextBox1.Enabled = false;
                        while (running)
                        {
                            NativeMethods.PostMessage(hWndEdit, WM_KEYDOWN, Keys.I, IntPtr.Zero);
                        }
                        timer.Enabled = false;
                        hitButton.Enabled = true;
                        xTextBox1.Enabled = true;
                    }
                    break;
            }
            

        }
        [DllImport("user32.dll")]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);
        [DllImport("user32.dll")]
        public static extern IntPtr PostMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

        public static void sendKeystroke(Keys k)
        {
            const uint WM_KEYDOWN = 0x100;
            const uint WM_SYSCOMMAND = 0x018;
            const uint SC_CLOSE = 0x053;

            IntPtr WindowToFind = FindWindow("Notepad", null);

            IntPtr result3 = PostMessage(WindowToFind, WM_KEYDOWN, ((IntPtr)k), (IntPtr)0);
            //IntPtr result3 = SendMessage(WindowToFind, WM_KEYUP, ((IntPtr)c), (IntPtr)0);
        }
        public void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            running = false;
            
        }

        private void selectButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Executable Program File (*.exe)|*.exe";
            openFileDialog.CheckFileExists = true;
            openFileDialog.CheckPathExists = true;
            openFileDialog.ShowDialog();
            if (openFileDialog.FileName == "")
            {
                return;
            }
            FileVersionInfo myFileVersionInfo =
                FileVersionInfo.GetVersionInfo(openFileDialog.FileName);
            programName = myFileVersionInfo.FileDescription;

            //hWndNotepad = NativeMethods.FindWindow(programName, null);

            Process p = Process.GetProcessesByName(programName).FirstOrDefault();
            if (p != null)
            {
                hWndNotepad = p.MainWindowHandle;
                //SetForegroundWindow(h);
                //SendKeys.SendWait("k");
            }

            if (openFileDialog.FileName!="")
            {
                hitButton.Enabled = true;
                xTextBox1.Enabled = true;
                xTextBox1.Focus();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                programName = textBox1.Text;

                Process p = Process.GetProcessesByName(programName).FirstOrDefault();
                if (p != null)
                {
                    hWndNotepad = p.MainWindowHandle;
                    //SetForegroundWindow(h);
                    //SendKeys.SendWait("k");
                }

                hitButton.Enabled = true;
                xTextBox1.Enabled = true;
                //xTextBox1.Focus();
            }
            if (textBox1.Text == "")
            {
                //programName = textBox1.Text;
                hitButton.Enabled = false;
                xTextBox1.Enabled = false;
                //xTextBox1.Focus();
            }
        }
    }
}
