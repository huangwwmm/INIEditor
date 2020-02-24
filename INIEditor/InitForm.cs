using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace INIEditor
{
    public partial class InitForm : Form
    {
        public string TypeString;

        public InitForm()
        {
            InitializeComponent();
        }

        private void OnInitForm_Load(object sender, EventArgs e)
        {
            Type iConfigType = typeof(IConfig);
            Type[] ts = iConfigType.Assembly.GetTypes();

            string[] configTypes = iConfigType.Assembly.GetTypes().Where(t => t != iConfigType && iConfigType.IsAssignableFrom(t)).Select(t => t.FullName).ToArray();
            m_ConfigTypeComboBox.DataSource = configTypes;
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            TypeString = m_ConfigTypeComboBox.SelectedItem.ToString();
            Close();
        }
    }
}