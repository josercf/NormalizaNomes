using MetroFramework;
using NormalizaNomes.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NormalizaNomes
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        delegate void StringArgReturningVoidDelegate(LogType type, string text);

        public Form1()
        {
            InitializeComponent();
        }

        private async void btnProcess_Click(object sender, EventArgs e)
        {
            await Task.Factory.StartNew(async () =>
            {
                try
                {
                    if (metroProgressSpinner1.InvokeRequired)
                    {
                        metroProgressSpinner1.Invoke(new MethodInvoker(() =>
                        {
                            metroProgressSpinner1.Visible = true;
                        }));
                    }
                    else
                    {
                        metroProgressSpinner1.Visible = true;
                    }

                    var sheetService = new SheetService((type, log) =>
                    {
                        Color color = GetLogColor(type);
                        richTextBox1.AppendText(log, color, true);
                    });

                    await sheetService.Execute(txtPathOrigin.Text, chkChangeFile.Checked);

                    MetroMessageBox.Show(this, "Planilha processada com sucesso", "Pronto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MetroMessageBox.Show(this, $"Ocorreu um erro ao processar a planilha: {ex.Message}", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }).ContinueWith(_ =>
            {

                if (metroProgressSpinner1.InvokeRequired)
                {
                    metroProgressSpinner1.Invoke(new MethodInvoker(() =>
                    {

                        metroProgressSpinner1.Visible = false;
                    }));
                }
                else
                {
                    metroProgressSpinner1.Visible = false;
                }

            }); ;
        }

        private static Color GetLogColor(LogType type)
        {
            var color = Color.Black;

            switch (type)
            {
                case LogType.Trace:
                    color = Color.Blue;
                    break;
                case LogType.Information:
                    color = Color.Orange;
                    break;
                case LogType.Error:
                    color = Color.Red;
                    break;
                default:
                    break;
            }

            return color;
        }

        private void btnPathOrigin_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            txtPathOrigin.Text = openFileDialog1.FileName;
        }
    }
}
