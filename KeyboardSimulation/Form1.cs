using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
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
            if (xTextBox1.Text != "")
                x = Convert.ToInt32(xTextBox1.Text);
        }

        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWind, int nCmdShow);
        [DllImport("user32.dll")]
        static extern bool SetForegroundWindow(IntPtr hWnd);
        private void hitButton_Click(object sender, EventArgs e)
        {
            if (xTextBox1.Text=="")
            {
                MessageBox.Show("Enter x", "Empty textbox", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //x = Convert.ToInt32(xTextBox1.Text);
            ShowWindow(hWndNotepad, 9);
            SetForegroundWindow(hWndNotepad);
            //hWndEdit = NativeMethods.FindWindowEx(hWndNotepad, IntPtr.Zero, "Edit", null);
            //NativeMethods.SetForegroundWindow(hWndNotepad);


            //NativeMethods.SendMessage(hWndEdit, WM_SETTEXT, 0, " key");

            switch (x)
            {
                case 2:
                    {
                        SendKeys.SendWait("{F5}");
                        SendKeys.SendWait("{e}");
                    }
                    break;
                case 3:
                    {
                        SendKeys.SendWait("{j}");
                        SendKeys.SendWait("{j}");
                        SendKeys.SendWait("{j}");
                        SendKeys.SendWait("{j}");
                        SendKeys.SendWait("{j}");
                    }
                    break;
                case 4:
                {
                        timer = new System.Timers.Timer();
                        timer.Interval = 30000;
                        timer.Elapsed += new ElapsedEventHandler(timer_Elapsed);
                        timer.Enabled = true;
                        running = true;
                    hitButton.Enabled = false;
                    xTextBox1.Enabled = false;
                        while (running)
                        {
                            SendKeys.SendWait("{i}");
                        }
                        timer.Enabled = false;
                        hitButton.Enabled = true;
                        xTextBox1.Enabled = true;
                    }
                    break;
                default:
                    MessageBox.Show("Wrong value of x", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
            

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
            var onlyfilename = Path.GetFileNameWithoutExtension(openFileDialog.FileName);
            //hWndNotepad = NativeMethods.FindWindow(programName, null);

            Process p = Process.GetProcessesByName(onlyfilename).FirstOrDefault();
            if (p != null)
            {
                hWndNotepad = p.MainWindowHandle;
                //SetForegroundWindow(hWndNotepad);
                //SendKeys.SendWait("k");
            }
            //textBox1.Clear();
            textBox2.Text = programName;
            
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
                    //var desc = FileVersionInfo.GetVersionInfo(p.MainModule.FileName);
                    textBox2.Text = p.ProcessName;
                    //SetForegroundWindow(hWndNotepad);
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

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                programName = textBox1.Text;

                Process p = Process.GetProcessesByName(programName).FirstOrDefault();
                if (p != null)
                {
                    hWndNotepad = p.MainWindowHandle;
                    //var desc = FileVersionInfo.GetVersionInfo(p.MainModule.FileName);
                    textBox2.Text = p.ProcessName;
                    //SetForegroundWindow(hWndNotepad);
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

        private void xTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
