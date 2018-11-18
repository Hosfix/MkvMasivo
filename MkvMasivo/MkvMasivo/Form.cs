using Octokit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MkvMasivo
{
    public partial class Form : System.Windows.Forms.Form
    {
        private List<string> _filesGlobal = new List<string>();
        private string[] _videoFormats = new string[] { "webm", "mkv", "vob", "ogv", "ogg", "drc", "gif", "gifv", "mng", "avi", "MTS", "M2TS", "mov", "qt", "wmv", "yuv", "rm", "rmvb", "asf", "amv", "mp4", "m4p", "m4v", "mpg", "mp2", "mpe", "mpv", "mpeg", "m2v", "svi", "3gp", "3g2", "mxf", "roq", "nsv", "flv", "f4v", "f4p", "f4a", "f4b" };
        private bool _fileExist = false;
        private List<string> _filesFound = new List<string>();
        private bool _startStop = false;
        private string _mkvPath = "mkvmerge.exe";
        private static readonly string _pattern = @"(\^\""\^\(\^\"" \^\"")(.*?)(\....\^\"" \^\""\^\)\^\"")";
        private static readonly string _patternExtension = @"(\^\""\^\(\^\"" \^\"")(.*?)(\^\"" \^\""\^\)\^\"")";
        private string _originPath = "";
        private FileVersionInfo fileVersion = null;

        #region Constructor

        public Form()
        {
            InitializeComponent();
            fileVersion = FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly().Location);
            this.Text = "MkvMassive " + fileVersion.FileVersion;

            ClearAll();

            var result = Task.Run(async () => { return await GetReleases(); }).Result;

            if (!File.Exists("mkvmerge.exe"))
            {
                MessageBox.Show("El programa debe estar en la misma carpeta que el mkvmerge.exe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                System.Environment.Exit(1);
            }
        }

        #endregion Constructor

        #region Events

        private void btnForlder_Click(object sender, EventArgs e)
        {
            try
            {
                using (var fbd = new FolderBrowserDialog())
                {
                    fbd.Description = "Carpeta de origen";
                    DialogResult result = fbd.ShowDialog();
                    if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                    {
                        Cursor = Cursors.WaitCursor;
                        _originPath = fbd.SelectedPath;
                        string[] files = GetAllFilesRecursive(fbd.SelectedPath, new string[0]);
                        string[] extensions = GetAllExtension(files);

                        _filesGlobal = files.ToList();
                        txtFolder.Text = fbd.SelectedPath;
                        chkExtensions.DataSource = extensions;
                        Cursor = Cursors.Default;
                    }
                }
            }
            catch (Exception ex)
            {
                CreateLogFiles Err = new CreateLogFiles();
                Err.ErrorLog("Logs/", ex.Message);
                MessageBox.Show("Error fatal: más información en el fichero log de errores", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_startStop)
            {
                if (MessageBox.Show("¿Quiere cancelar la operación?", "Información", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    _startStop = false;
                e.Cancel = true;
            }
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(richCommand.Text);
        }

        private void btnPaste_Click(object sender, EventArgs e)
        {
            richCommand.Text = Clipboard.GetText();
        }

        private async void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                if (!_startStop)
                {
                    var extensions = new string[0];
                    if (_filesGlobal == null || _filesGlobal.Count() <= 0)
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
                                _startStop = true;
                                CambiarEstadoControles(false);

                                BtnRun.Text = "Stop";
                                var progress = new Progress<ProgressReport>();
                                progress.ProgressChanged += (o, report) =>
                                {
                                    progressBar.Value = report.PercentComplete;
                                    LabelInformation.Text = report.Information + " " + report.PercentComplete + "%";
                                    progressBar.Update();
                                };
                                await ProcessData(_filesGlobal, fbd.SelectedPath, extensions, richCommand.Text, progress);

                                if (_startStop)
                                    MessageBox.Show("Proceso Terminado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                else
                                    MessageBox.Show("Se ha cancelado el proceso", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                if (_fileExist)
                                {
                                    string existingFiles = "";
                                    foreach (var fileName in _filesFound)
                                    {
                                        existingFiles = existingFiles + ", " + fileName;
                                    }
                                    MessageBox.Show("Los siguientes ficheros ya existian " + existingFiles, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }

                                _startStop = false;
                                ClearAll();
                                CambiarEstadoControles(true);
                                BtnRun.Text = "Start";

                            }
                        }
                    }
                }
                else
                {
                    if (MessageBox.Show("¿Quiere cancelar la operación?", "Información", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                        _startStop = false;
                }
            }
            catch (Exception ex)
            {
                CreateLogFiles Err = new CreateLogFiles();
                Err.ErrorLog("Logs/", ex.Message);
                MessageBox.Show("Error fatal: más información en el fichero log de errores", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion Events

        #region Process

        private async Task<Release> GetReleases()
        {
            var client = new Octokit.GitHubClient(new Octokit.ProductHeaderValue("MkvMasivo"));
            var release = await client.Repository.Release.GetLatest("Hosfix", "MkvMasivo");

            if (release != null && !String.IsNullOrEmpty(release.TagName))
            {
                if (!release.TagName.Equals(fileVersion.FileVersion))
                {
                    if (MessageBox.Show("Se ha encontrado la versión " + release.TagName + ". ¿Desea que se le abra un enlace de descarga?", "Nueva versión", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        Process.Start(release.Assets[0].BrowserDownloadUrl);
                        Close();
                    }
                }
            }
            return release;
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

        private void CambiarEstadoControles(bool status)
        {
            chkExtensions.Enabled = status;
            BtnCopy.Enabled = status;
            BtnForlder.Enabled = status;
            BtnPaste.Enabled = status;
        }

        private void ClearAll()
        {
            progressBar.Value = 0;
            chkExtensions.DataSource = null;
            richCommand.Text = null;
            txtFolder.Text = null;
            _fileExist = false;
            _filesGlobal = null;
            LabelInformation.Text = null;
        }

        private Task ProcessData(List<string> files, string outputFolder, string[] extensions, string command, IProgress<ProgressReport> progress)
        {
            List<string> ficherosFiltrados = new List<string>();

            ficherosFiltrados = files.FindAll(f => extensions.Contains(f.Split('.').Last()));

            int index = 0;
            int totalProcess = ficherosFiltrados.Count;
            var progressReport = new ProgressReport();
            return Task.Run(() =>
            {
                foreach (var file in ficherosFiltrados)
                {
                    progressReport.PercentComplete = index++ * 100 / totalProcess;
                    progressReport.Information = file.Split('\\').Last() + " (" + index + "/" + totalProcess + ")  ";
                    progress.Report(progressReport);

                    if (!_startStop)
                        break;

                    ExecuteCommand(file, outputFolder, command);

                    progressReport.PercentComplete = index * 100 / totalProcess;
                    progressReport.Information = file.Split('\\').Last() + " (" + index + "/" + totalProcess + ")  ";
                    progress.Report(progressReport);
                }
            });
        }

        private void ExecuteCommand(string file, string outputFolder, string command)
        {
            var filterPath = file.Replace(_originPath + "\\", "");
            var folder = filterPath.Split('\\');
            var destinyFolder = outputFolder;
            for (int i = 0; i < folder.Count() - 1; i++)
            {
                destinyFolder = destinyFolder + "\\" + folder[i];
                Directory.CreateDirectory(destinyFolder);
            }

            var destinyPath = destinyFolder + "\\" + file.Split('\\').Last();
            destinyPath = destinyPath.Substring(0, destinyPath.LastIndexOf(".")) + ".mkv";

            if (File.Exists(destinyPath))
            {
                _fileExist = true;
                _filesFound.Add(file.Split('\\').Last());
                Thread.Sleep(50);
                return;
            }

            string trueCommand = command.Substring(command.IndexOf("--language 0:"));
            string fileName = file.Substring(0, file.LastIndexOf("."));
            string fileNameAndExtension = file.Split('\\').Last();

            Regex rgx = new Regex(_patternExtension);
            string firstProcess = Regex.Replace(trueCommand, _pattern, "$1" + fileName + "$3");
            string finalResult = rgx.Replace(firstProcess, "$1" + fileName + "." + file.Split('.').Last() + "$3", 1);

            ExecuteProcess(_mkvPath + " --output \"" + destinyPath + "\" " + finalResult + " & exit");
        }

        public void ExecuteProcess(string Command)
        {
            ProcessStartInfo ProcessInfo;
            Process Process;

            ProcessInfo = new ProcessStartInfo("cmd.exe", "/K " + Command);
            ProcessInfo.WindowStyle = ProcessWindowStyle.Hidden;
            ProcessInfo.CreateNoWindow = true;
            ProcessInfo.UseShellExecute = true;

            Process = Process.Start(ProcessInfo);
            Process.WaitForExit();
        }

        #endregion Process
    }
}