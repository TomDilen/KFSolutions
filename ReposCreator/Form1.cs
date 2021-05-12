using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReposCreator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("using System;");
            sb.Append(Environment.NewLine);
            sb.Append("using System.Collections.Generic;");
            sb.Append(Environment.NewLine);
            sb.Append("using System.Linq;");
            sb.Append(Environment.NewLine);
            sb.Append("using System.Text;");
            sb.Append(Environment.NewLine);
            sb.Append("using System.Threading.Tasks;");
            sb.Append(Environment.NewLine);
            sb.Append("using KFSolutionsModel;");
            sb.Append(Environment.NewLine);
            sb.Append("using TDSrepository;");
            sb.Append(Environment.NewLine); sb.Append(Environment.NewLine);
            sb.Append("namespace KFSrepository_EF6");
            sb.Append(Environment.NewLine);
            sb.Append("{");
            sb.Append(Environment.NewLine); sb.Append(Environment.NewLine); sb.Append(Environment.NewLine);
            sb.Append($"    public interface I{txtInput.Text}Repository : ITDSrepository<{txtInput.Text}>");
            sb.Append(Environment.NewLine);
            sb.Append("    {");
            sb.Append(Environment.NewLine); sb.Append(Environment.NewLine);
            sb.Append("    }");
            sb.Append(Environment.NewLine); sb.Append(Environment.NewLine);
            sb.Append($"    public class {txtInput.Text}Repository : TDSrepository<{txtInput.Text}>, I{txtInput.Text}Repository");
            sb.Append(Environment.NewLine);
            sb.Append("    {");
            sb.Append(Environment.NewLine);
            sb.Append($"        public {txtInput.Text}Repository(string aConnectionstring) : base(aConnectionstring)");
            sb.Append(Environment.NewLine);
            sb.Append("        {");
            sb.Append(Environment.NewLine); sb.Append(Environment.NewLine);
            sb.Append("        }");
            sb.Append(Environment.NewLine);
            sb.Append("    }");
            sb.Append(Environment.NewLine);
            sb.Append($"public readonly I{txtInput.Text}Repository {txtInput.Text};");
            sb.Append(Environment.NewLine);
            sb.Append($"{txtInput.Text} = new {txtInput.Text}Repository(aConnectionString);");
            sb.Append(Environment.NewLine);
            sb.Append($"public DbSet<{txtInput.Text}> {txtInput.Text}s {{ get; set; }}");
            sb.Append(Environment.NewLine);
            sb.Append("}");
            sb.Append(Environment.NewLine);

            textBox1.Text = sb.ToString();
        }
    }
}
