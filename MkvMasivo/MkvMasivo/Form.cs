﻿using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MkvMasivo
{
    public partial class Form : System.Windows.Forms.Form
    {
        private object filesGlobal = null;
        private string[] _videoFormats = new string[] { "webm", "mkv", "vob", "ogv", "ogg", "drc", "gif", "gifv", "mng", "avi", "MTS", "M2TS", "mov", "qt", "wmv", "yuv", "rm", "rmvb", "asf", "amv", "mp4", "m4p", "m4v", "mpg", "mp2", "mpe", "mpv", "mpeg", "m2v", "svi", "3gp", "3g2", "mxf", "roq", "nsv", "flv", "f4v", "f4p", "f4a", "f4b" };

        public Form()
        {
            InitializeComponent();
            FileVersionInfo fileVersion = FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly().Location);
            this.Text = "MkvMassive " + fileVersion.FileVersion;

            if (!File.Exists("mkvmerge.exe"))
            {
                MessageBox.Show("El programa debe estar en la misma carpeta que el mkvmerge.exe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                System.Environment.Exit(1);
            }
        }

        private void btnForlder_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                fbd.Description = "Carpeta de origen";
                DialogResult result = fbd.ShowDialog();
                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    Cursor = Cursors.WaitCursor;
                    string[] files = GetAllFilesRecursive(fbd.SelectedPath, new string[0]);
                    string[] extensions = GetAllExtension(files);

                    filesGlobal = files;
                    txtFolder.Text = fbd.SelectedPath;
                    chkExtensions.DataSource = extensions;
                    Cursor = Cursors.Default;
                }
            }
        }

        private void ClearAll()
        {
            progressBar.Value = 0;
            chkExtensions.DataSource = null;
            richLanguage.Text = null;
            txtFolder.Text = null;
            richOrder.Text = null;
        }
        private string[] GetAllFilesRecursive(string folderPath, string[] files)
        {
            var folderFiles = Directory.GetFiles(folderPath);
            var folders = Directory.GetDirectories(folderPath);

            foreach (var folder in folders)
            {
                files = GetAllFilesRecursive(folder, files);
            }

            string[] completeFiles = files.Concat(folderFiles).ToArray();
            return completeFiles;
        }

        private string[] GetAllExtension(string[] files)
        {
            var completeFiles = new string[0];

            foreach (var file in files)
            {
                var extension = file.Split('.').Last();
                if (_videoFormats.Contains(extension) && !completeFiles.Contains(extension))
                {
                    var oldLength = completeFiles.Length;
                    Array.Resize(ref completeFiles, oldLength + 1);
                    completeFiles[oldLength] = extension;
                }

            }

            return completeFiles;
        }

        private void btnPaste_Click(object sender, EventArgs e)
        {
            richLanguage.Text = Clipboard.GetText().Replace("^", "");
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(richLanguage.Text);
        }

        private void btnCopyOrder_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(richOrder.Text);
        }

        private void btnPasteOrder_Click(object sender, EventArgs e)
        {
            richOrder.Text = Clipboard.GetText();
        }

        private Task ProcessData(string[] files, string outputFolder, string[] extensions, string language, string trackOrder, IProgress<ProgressReport> progress)
        {

            int index = 1;
            int totalProcess = files.Length;
            var progressReport = new ProgressReport();
            return Task.Run(() =>
            {
                foreach (var file in files)
                {
                    progressReport.PercentComplete = index++ * 100 / totalProcess;
                    progress.Report(progressReport);

                    if (extensions.Contains(file.Split('.').Last()))
                    {
                        ExecuteCmd(file, outputFolder, language, trackOrder);
                    }
                }
            });
        }

        private void ExecuteCmd(string file, string outputFolder, string language, string trackOrder)
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo
            {
                WindowStyle = System.Diagnostics.ProcessWindowStyle.Minimized,
                FileName = "cmd.exe",
                Arguments = "/c start /wait mkvmerge.exe -o \"" + outputFolder + "\\" + file.Split('\\').Last() + "\" " + language + " \"" + file + "\" " + trackOrder
            };
            process.StartInfo = startInfo;
            process.Start();
            process.WaitForExit();
        }

        private async void btnStart_Click(object sender, EventArgs e)
        {
            var files = filesGlobal as string[];
            var extensions = new string[0];
            if (files == null || files.Count() <= 0)
            {
                MessageBox.Show("No hay ficheros", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (chkExtensions.CheckedItems.Count <= 0)
            {
                MessageBox.Show("No hay extensiones a modificar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (String.IsNullOrEmpty(richLanguage.Text))
            {
                MessageBox.Show("No se ha insertado el comando de MKVToolnix", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (String.IsNullOrEmpty(richOrder.Text))
            {
                MessageBox.Show("No se ha insertado el comando de MKVToolnix", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                foreach (var check in chkExtensions.CheckedItems)
                {
                    var oldLength = extensions.Length;
                    Array.Resize(ref extensions, oldLength + 1);
                    extensions[oldLength] = check.ToString();
                }

                using (var fbd = new FolderBrowserDialog())
                {
                    fbd.Description = "Carpeta de destino";

                    DialogResult result = fbd.ShowDialog();

                    if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                    {
                        var progress = new Progress<ProgressReport>();
                        progress.ProgressChanged += (o, report) =>
                        {
                            progressBar.Value = report.PercentComplete;
                            progressBar.Update();
                        };
                        await ProcessData(filesGlobal as string[], fbd.SelectedPath, extensions, richLanguage.Text, richOrder.Text, progress);
                        MessageBox.Show("Proceso Terminado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearAll();
                    }
                }
            }
        }
    }
}
