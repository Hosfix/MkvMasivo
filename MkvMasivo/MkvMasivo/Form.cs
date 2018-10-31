using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MkvMasivo
{
    public partial class Form : System.Windows.Forms.Form
    {
        private object _filesGlobal = null;
        private string[] _videoFormats = new string[] { "webm", "mkv", "vob", "ogv", "ogg", "drc", "gif", "gifv", "mng", "avi", "MTS", "M2TS", "mov", "qt", "wmv", "yuv", "rm", "rmvb", "asf", "amv", "mp4", "m4p", "m4v", "mpg", "mp2", "mpe", "mpv", "mpeg", "m2v", "svi", "3gp", "3g2", "mxf", "roq", "nsv", "flv", "f4v", "f4p", "f4a", "f4b" };
        private bool _fileExist = false;
        private string[] _filesFound = new string[0];
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

                    _filesGlobal = files;
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
            richCommand.Text = null;
            txtFolder.Text = null;
            _fileExist = false;
            _filesGlobal = null;
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
            richCommand.Text = Clipboard.GetText();
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(richCommand.Text);
        }

        private async void btnStart_Click(object sender, EventArgs e)
        {
            var files = _filesGlobal as string[];
            var extensions = new string[0];
            if (files == null || files.Count() <= 0)
            {
                MessageBox.Show("No hay ficheros", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (chkExtensions.CheckedItems.Count <= 0)
            {
                MessageBox.Show("No hay extensiones a modificar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (String.IsNullOrEmpty(richCommand.Text))
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
                        await ProcessData(_filesGlobal as string[], fbd.SelectedPath, extensions, richCommand.Text, progress);

                        MessageBox.Show("Proceso Terminado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        if (_fileExist)
                        {
                            string existingFiles = "";
                            foreach (var fileName in _filesFound)
                            {
                                existingFiles = existingFiles + "\r\n" + fileName;
                            }
                            MessageBox.Show("Los siguientes ficheros ya existian " + existingFiles, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        ClearAll();
                    }
                }
            }
        }

        private Task ProcessData(string[] files, string outputFolder, string[] extensions, string command, IProgress<ProgressReport> progress)
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
                        ExecuteCmd(file, outputFolder, command);
                    }
                }
            });
        }

        private void ExecuteCmd(string file, string outputFolder, string command)
        {
            var destinyPath = outputFolder + "\\" + file.Split('\\').Last();
            destinyPath = destinyPath.Substring(0, destinyPath.LastIndexOf(".")) + ".mkv";

            if (File.Exists(destinyPath))
            {
                _fileExist = true;
                var oldLength = _filesFound.Length;
                Array.Resize(ref _filesFound, oldLength + 1);
                _filesFound[oldLength] = file.Split('\\').Last();
                return;
            }

            string trueCommand = command.Substring(command.IndexOf("--language 0:"));
            string fileName = file.Substring(0, file.LastIndexOf("."));
            string pattern = @"(\^\""\^\(\^\"" \^\"")(.*?)(\....\^\"" \^\""\^\)\^\"")";
            var cmd =  "/c start /wait G:/Programas/MkvToolnix/mkvmerge.exe -o \"" + destinyPath + "\" " + Regex.Replace(trueCommand, pattern, "$1" + fileName + "$3");

            Process process = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                WindowStyle = System.Diagnostics.ProcessWindowStyle.Minimized,
                FileName = "cmd.exe",
                Arguments = cmd
            };
            process.StartInfo = startInfo;
            process.Start();
            process.WaitForExit();
        }
    }
}