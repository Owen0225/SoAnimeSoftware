using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hyper_Useful_Injector
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void pathSelectButton_Click(object sender, EventArgs e)
        {
            var pathSelector = new OpenFileDialog() 
            { 
                Multiselect = false,
                Title = "Browse dll",
                DefaultExt = "dll",
                Filter = "dll files (*.dll)|*.dll|All files (*.*)|*.*"
             };
            var result = pathSelector.ShowDialog();
            if(result == DialogResult.OK)
            {
                pathTextBox.Text = pathSelector.FileName;
                Properties.Settings.Default.path = pathSelector.FileName;
                Properties.Settings.Default.Save();
            }
        }

        private void processComboBox_DropDown(object sender, EventArgs e)
        {
            processComboBox.Items.Clear();
            foreach (var item in Process.GetProcesses())
            {
                processComboBox.Items.Add(item.ProcessName);
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            processComboBox.Text = Properties.Settings.Default.process;
            pathTextBox.Text = Properties.Settings.Default.path;
            mainMethodCheckBox.Checked = Properties.Settings.Default.hasMainMethod;
            mainMethodTextBox.Text = Properties.Settings.Default.mainMethod;
            closeCheckBox.Checked = Properties.Settings.Default.autoClose;
            doCopyCheckBox.Checked = Properties.Settings.Default.doCopy;
            UpdateMainMethodTextBox();
        }

        private void mainMethodCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.hasMainMethod = mainMethodCheckBox.Checked;
            Properties.Settings.Default.Save();
            UpdateMainMethodTextBox();
        }

        private void UpdateMainMethodTextBox()
        {
            mainMethodTextBox.Enabled = Properties.Settings.Default.hasMainMethod;
        }

        private void mainMethodTextBox_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.mainMethod = mainMethodTextBox.Text;
            Properties.Settings.Default.Save();
        }

        private void closeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.autoClose = closeCheckBox.Checked;
            Properties.Settings.Default.Save();
        }

        private void processComboBox_TextUpdate(object sender, EventArgs e)
        {
            Properties.Settings.Default.process = processComboBox.Text;
            Properties.Settings.Default.Save();
        }

        private void injectButton_Click(object sender, EventArgs e)
        {
            var proc = Process.GetProcessesByName(processComboBox.Text).FirstOrDefault();
            if (proc == null)
                return;

            var path = pathTextBox.Text;
            if (path == "")
                return;

            var mainMethod = mainMethodCheckBox.Checked ? mainMethodTextBox.Text : null;
            if (mainMethodCheckBox.Checked && mainMethod == "")
                return;

            Injector.Inject(proc, path, mainMethod);

            if (closeCheckBox.Checked)
                Application.Exit();
        }

        private void doCopyCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.doCopy = doCopyCheckBox.Checked;
            Properties.Settings.Default.Save();
        }
    }
}
