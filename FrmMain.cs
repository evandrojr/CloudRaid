using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Reflection;

namespace CloudRaid
{
    public partial class FrmMain : Form
    {
        CloudRAID cr;
        private Thread trd;
        public FrmMain() {
            InitializeComponent();
            load();
        }


        delegate void SetControlValueCallback(Control oControl, string propName, object propValue);

        public void SetControlPropertyValue(Control oControl, string propName, object propValue) {
            if (oControl.InvokeRequired) {
                SetControlValueCallback d = new SetControlValueCallback(SetControlPropertyValue);
                oControl.Invoke(d, new object[] { oControl, propName, propValue });
            } else {
                Type t = oControl.GetType();
                PropertyInfo[] props = t.GetProperties();
                foreach (PropertyInfo p in props) {
                    if (p.Name.ToUpper() == propName.ToUpper()) {
                        p.SetValue(oControl, propValue, null);
                    }
                }
            }
        }


        private void btSyncronize_Click(object sender, EventArgs e) {
            progressBar.Value = 0;
            btChecks.Enabled = false;
            trd = new Thread(new ThreadStart(cr.Syncronize));
            trd.IsBackground = true;
            trd.Start();
            trd.Join();
            btChecks.Enabled = true;
            repaint();
        }

        private void load() {
            cr = new CloudRAID(this);

            cr.LoadConfig();
            txtSourceDirs.Text = "";
            txtOutputDirs.Text = "";
            foreach (string dir in cr.SourceDirs)
                txtSourceDirs.Text += dir + Environment.NewLine;
            foreach (CloudRAID.CloudStorage dir in cr.CloudStorageLst) {
                txtOutputDirs.Text += dir.Name + ";" + dir.Path + ";" + dir.Size / 1024 / 1024 + Environment.NewLine;
            }
        }

        private void save() {
            string dirs = txtSourceDirs.Text.Replace(Environment.NewLine, "|");
            string[] cloudStorage;
            cr.SourceDirs.Clear();
            cr.CloudStorageLst.Clear();
            if (dirs.EndsWith("|"))
                dirs = dirs.Substring(0, dirs.Length - 1);
            foreach (String dir in dirs.Split('|')) {
                if (dir != "")
                    cr.SourceDirs.Add(dir);
            }

            dirs = txtOutputDirs.Text.Replace(Environment.NewLine, "|");
            if (dirs.EndsWith("|"))
                dirs = dirs.Substring(0, dirs.Length - 1);
            foreach (String dir in dirs.Split('|')) {
                if (dir != "") {
                    cloudStorage = dir.Split(';');
                    cr.CloudStorageLst.Add(new CloudRAID.CloudStorage(cloudStorage[0], cloudStorage[1], Convert.ToInt64(cloudStorage[2]) * 1024 * 1024));
                }
            }
            cr.SaveConfig();
        }

        private void btChecks_Click(object sender, EventArgs e) {
            save();
            load();
            cr.Checks();
            repaint();
        }

        private void repaint() {
            lbSourceSize.Text = "Size: " + cr.SourceSize / 1024 / 1024 + " MB";
            lbOutputSize.Text = "Size: " + cr.OutputSize / 1024 / 1024 + " MB";
            lbOutputUsed.Text = "Used: " + cr.OutputUsed / 1024 / 1024 + " MB";
            lbOutputFree.Text = "Free: " + cr.OutputFree / 1024 / 1024 + " MB";
        }
    }
}
