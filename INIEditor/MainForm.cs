using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace INIEditor
{
    public partial class MainForm : Form
    {
        private string m_TypeString;
        private string m_INIPath;

        private Dictionary<string, string[]> m_FastCommands;

        public MainForm(string typeString, string iniPath)
        {
            m_TypeString = typeString;
            m_INIPath = iniPath;
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(m_TypeString))
            {
                InitForm initForm = new InitForm();
                initForm.ShowDialog();
                m_TypeString = initForm.TypeString;
            }

            if (string.IsNullOrEmpty(m_TypeString))
            {
                Close();
                return;
            }

            RefreshTitle();

            IConfig config = (IConfig)Activator.CreateInstance(Type.GetType(m_TypeString), true);
            config.ReasetToDefault();
            config.LoadFromFile(m_INIPath);
            m_PropertyGrid.SelectedObject = config;

            m_FastCommands = new Dictionary<string, string[]>();
            LoadFastCommands($"{AppDomain.CurrentDomain.SetupInformation.ApplicationBase}Fast-{m_TypeString.Replace('.', '_')}.ini");
        }

        private void LoadFastCommands(string path)
        {
            if (!File.Exists(path))
            {
                return;
            }

            m_FastCommands.Clear();
            m_CommandToolStripMenuItem.DropDownItems.Clear();

            string[] lines = File.ReadAllLines(path);
            string commandName = string.Empty;
            string tooltip = string.Empty;
            List<string> commandLines = new List<string>();
            for (int iLine = 0; iLine < lines.Length; iLine++)
            {
                string iterLine = lines[iLine].Trim();
                if (iterLine.StartsWith("{")
                    && iterLine.EndsWith("}"))
                {
                    if (!string.IsNullOrEmpty(commandName))
                    {
                        AddFastCommand(commandName, commandLines.ToArray(), tooltip);
                        tooltip = string.Empty;
                    }
                    commandLines.Clear();
                    commandName = iterLine.Substring(1, iterLine.Length - 2);
                }
                else if (iterLine.StartsWith("#"))
                {
                    tooltip = $"{tooltip}{iterLine.Substring(1)}\n";
                }
                else
                {
                    commandLines.Add(iterLine);
                }
            }

            if (!string.IsNullOrEmpty(commandName))
            {
                AddFastCommand(commandName, commandLines.ToArray(), tooltip);
            }
        }

        private void AddFastCommand(string namePath, string[] commands, string tooltip)
        {
            m_FastCommands.Add(namePath, commands);

            ToolStripMenuItem parentItem = m_CommandToolStripMenuItem;
            string[] names = namePath.Split('/');
            for (int iName = 0; iName < names.Length; iName++)
            {
                string iterName = names[iName];
                ToolStripMenuItem currentItem = null;
                ToolStripItemCollection toolStripItemCollection = parentItem.DropDownItems;
                for (int iChildItem = 0; iChildItem < toolStripItemCollection.Count; iChildItem++)
                {
                    ToolStripMenuItem iterChild = toolStripItemCollection[iChildItem] as ToolStripMenuItem;
                    if (iterChild.Text == iterName)
                    {
                        currentItem = iterChild;
                        break;
                    }
                }

                if (currentItem == null)
                {
                    currentItem = new ToolStripMenuItem();
                    currentItem.Name = iterName;
                    currentItem.Size = new System.Drawing.Size(112, 22);
                    currentItem.Text = iterName;
                    parentItem.DropDownItems.Add(currentItem);
                }

                parentItem = currentItem;

                if (iName == names.Length - 1)
                {
                    currentItem.Tag = namePath;
                    currentItem.ToolTipText = tooltip;
                    if (commands.Length > 0)
                    {
                        currentItem.Click += new EventHandler(this.OnFastCommandToolStripMenuItem_Click);
                    }
                }
            }
        }

        private void OnFastCommandToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string commandName = (sender as ToolStripMenuItem).Tag as string;
            if (m_FastCommands.TryGetValue(commandName, out string[] lines))
            {
                IConfig config = (IConfig)m_PropertyGrid.SelectedObject;
                m_PropertyGrid.SelectedObject = null;
                config.LoadFromLines(lines);
                m_PropertyGrid.SelectedObject = config;
            }
        }

        private void RefreshTitle()
        {
            Text = $"{m_TypeString} - {m_INIPath}";
        }

        private void Save(string path)
        {
            IConfig config = (IConfig)m_PropertyGrid.SelectedObject;
            try
            {
                config.SaveToFile(path);
                MessageBox.Show("保存成功\n" + path, "保存成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"保存失败\n{path}\n\n{ex.ToString()}", "保存失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Open(string path)
        {
            IConfig config = (IConfig)m_PropertyGrid.SelectedObject;
            m_PropertyGrid.SelectedObject = null;
            config.ReasetToDefault();
            config.LoadFromFile(path);
            m_PropertyGrid.SelectedObject = config;
        }

        private void OnOpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Multiselect = false;
            fileDialog.Title = "打开";
            fileDialog.CheckFileExists = false;
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                m_INIPath = fileDialog.FileName;
                RefreshTitle();
                Open(m_INIPath);
            }
        }

        private void OnSaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(m_INIPath))
            {
                OpenFileDialog fileDialog = new OpenFileDialog();
                fileDialog.Multiselect = false;
                fileDialog.Title = "保存";
                fileDialog.CheckFileExists = false;
                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    m_INIPath = fileDialog.FileName;
                    RefreshTitle();
                    Save(m_INIPath);
                }
            }
            else
            {
                Save(m_INIPath);
            }
        }

        private void OnSaveToToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Multiselect = false;
            fileDialog.Title = "保存为";
            fileDialog.CheckFileExists = false;
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                Save(fileDialog.FileName);
            }
        }

        private void OnCloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void OnResetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Open(m_INIPath);
        }

        private void OnResetToDefaultToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IConfig config = (IConfig)m_PropertyGrid.SelectedObject;
            m_PropertyGrid.SelectedObject = null;
            config.ReasetToDefault();
            m_PropertyGrid.SelectedObject = config;
        }

        private void OnCopyHelpTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FieldInfo coccommentFieldInfo = typeof(PropertyGrid).GetField("doccomment", BindingFlags.NonPublic | BindingFlags.Instance);
            object doccomment = coccommentFieldInfo.GetValue(m_PropertyGrid);
            FieldInfo descFieldInfo = doccomment.GetType().GetField("m_labelDesc", BindingFlags.NonPublic | BindingFlags.Instance);
            Clipboard.SetText((descFieldInfo.GetValue(doccomment) as Label).Text);
        }
    }
}