using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Collections;
using System.Diagnostics;
using System.Text.RegularExpressions;
//using System.Windows.Forms;
namespace FileTransfer
{
    public partial class Form1 : Form
    {
        string source_deploy = string.Empty;
        string target_deploy = @"";
        string commitPath = string.Empty;
        public Form1()
        {
            InitializeComponent();
            txt_source_folder.Text = @"";
            txt_target_folder.Text = @"";
        }

        /// <summary>
        /// Split file from string with delimiter characters
        /// </summary>
        /// <param name="input_list_file"></param>
        /// <param name="delimiterChars"></param>
        /// <returns></returns>
        public List<string> fileSplit(string input_list_file, char[] delimiterChars)
        {
            List<string> file_list = new List<String>();
            //char[] delimiterChars = { '\r', ',', '.', ':', '\t' };
            file_list = input_list_file.Split(delimiterChars).ToList();
            // Keep the console window open in debug mode.
            for (int i = 0;i< file_list.Count();i++)
            {
                file_list[i] = file_list[i].Trim();
                file_list[i] = Regex.Replace(file_list[i], @"\r\n", "");
                if (file_list[i].Length < 3)
                {
                    file_list.RemoveAt(i);
                }
            }
            return file_list;
        }

        /// <summary>
        /// Get lastest version at source folder
        /// </summary>
        /// <param name="svn_path"></param>
        public void SVNUpdating(string svn_path)
        {
            string str_cmd_text;
            string processing_output;
            str_cmd_text = " update ";
            str_cmd_text += "\"";
            str_cmd_text += svn_path;
            str_cmd_text += "\"";
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            process.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            process.StartInfo.FileName = "svn.exe";
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardError = true;
            process.StartInfo.Arguments = str_cmd_text;
            process.Start();
            StreamReader reader = process.StandardOutput;
            while ((processing_output = process.StandardOutput.ReadLine()) != null)
            {
                txt_deployedfile.Text += processing_output + Environment.NewLine;
            }
            process.WaitForExit();
        }

        /// <summary>
        /// Read text from file
        /// </summary>
        /// <param name="input_file_path"></param>
        /// <returns></returns>
        public string textReading(string input_file_path)
        {
            string textFileContent;
            try
            {
                textFileContent = System.IO.File.ReadAllText(input_file_path);
                return textFileContent.ToString();
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }

        /// <summary>
        /// that will create new folder in tags folder base on SreenID after update
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_submited_click(object sender, EventArgs e)
        {
            string source_path;
            string target_path;
            source_path = this.txt_source_folder.Text.ToString();
            target_path = this.txt_target_folder.Text.ToString();
            bool fileNotExist = false;
            List<string> listFileDeploy;
            listFileDeploy = fileSplit(txt_deployedfile.Text.ToString(), Environment.NewLine.ToCharArray());

            if (!chk_batchscr.Checked)
            {
                if (txt_screenID.Text == string.Empty)
                {
                    MessageBox.Show("Please input Screen ID !!!");
                    return;
                }
                else if (txt_request_user.Text == string.Empty)
                {
                    MessageBox.Show("Please input name of request user !!!");
                    return;
                }

                else if (string.IsNullOrEmpty(source_path))
                {
                    MessageBox.Show("Please input source folder");
                    return;
                }
                else if (!Directory.Exists(source_path))
                {
                    MessageBox.Show("Your source folder is not exist !!!");
                    return;
                }
                else if (string.IsNullOrEmpty(target_path))
                {
                    MessageBox.Show("Please input target folder");
                    return;
                }
                else if (!Directory.Exists(target_path))
                {
                    MessageBox.Show("Your target folder is not exist !!!");
                    return;
                }

                else
                {
                    txt_deployedfile.Text = string.Empty;
                    foreach (string deployFileName in listFileDeploy)
                    {
                        if (!File.Exists(txt_source_folder.Text + "\\" + deployFileName))
                        {
                            fileNotExist = true;
                            txt_deployedfile.AppendText("\\");
                            txt_deployedfile.AppendText(deployFileName);
                            int selectionStart = txt_deployedfile.Text.Length;
                            txt_deployedfile.AppendText(" Doesn't exist. Please check !");
                            txt_deployedfile.AppendText(Environment.NewLine);
                            txt_deployedfile.Select(selectionStart, selectionStart+31);
                            txt_deployedfile.SelectionColor = Color.Red;
                       }
                    }
                    if (fileNotExist)
                        return;
                    //txt_deployedfile.Text = string.Empty;
                    //this.SVNUpdateAll();
                }

                string today_folder_name = DateTime.Now.ToString("yyyyMMdd");

                //if screen ID folder is already exits 
                if (!this.create_directory_screenid(this.txt_target_folder.Text.ToString()))
                {
                    string tagsIdPath = this.txt_target_folder.Text.ToString() + "\\" + txt_screenID.Text.ToString();
                    string folderNameList = "";
                    DirectoryInfo tagsIdFolder = new DirectoryInfo(tagsIdPath);
                    DirectoryInfo[] idScreenArray = tagsIdFolder.GetDirectories();
                    foreach (DirectoryInfo subDir in idScreenArray)
                    {
                        folderNameList += subDir.Name.ToString();
                        folderNameList += Environment.NewLine;
                    }
                    string newestFolderName = this.newestFolderFinding(folderNameList);
                    string todayFolderName = DateTime.Now.ToString("yyyyMMdd");
                    if (!(newestFolderName == todayFolderName) && (newestFolderName.Length == 8))
                    {
                        foreach (DirectoryInfo subDir in idScreenArray)
                        {
                            if (subDir.Name.ToString() == newestFolderName)
                            {
                                todayFolderName = Directory.GetParent(subDir.FullName.ToString()).FullName.ToString() + "\\" + todayFolderName.ToString();
                                DirectoryCopy(subDir.FullName.ToString(), todayFolderName, true);
                                txt_deployedfile.Text += Environment.NewLine;
                                txt_deployedfile.Text += "Folder " + subDir.FullName.ToString() + "have been copied !!!";
                                newestFolderName = DateTime.Now.ToString("yyyyMMdd").ToString();
                                break;
                            }
                        }
                    }
                    else
                    {
                        newestFolderName = DateTime.Now.ToString("yyyyMMdd").ToString();
                    }
                    txt_deployedfile.Text = string.Empty;
                    foreach (string deployFileName in listFileDeploy)
                    {
                        string sourceFileCopy = txt_source_folder.Text + "\\" + deployFileName;
                        string targetFileCopy = txt_target_folder.Text + "\\" + txt_screenID.Text + "\\" + newestFolderName + "\\" + deployFileName;
                        try
                        { 
                            Directory.CreateDirectory(Path.GetDirectoryName(targetFileCopy));
                            File.Copy(sourceFileCopy, targetFileCopy, true);
                            txt_deployedfile.AppendText(targetFileCopy);
                            int selectionStart = txt_deployedfile.Text.Length;
                            txt_deployedfile.AppendText(" copy success");
                            txt_deployedfile.AppendText(Environment.NewLine);
                            txt_deployedfile.Select(selectionStart, selectionStart + 14);
                            txt_deployedfile.SelectionColor = Color.Green;
                            targetFileCopy = string.Empty;
                        }
                        catch (Exception ex)
                        {
                            txt_deployedfile.Text = ex.ToString();
                            return;
                        }
                    }
                    commitPath = txt_target_folder.Text + "\\" + txt_screenID.Text + "\\" + newestFolderName;
                }

                //if screen ID folder isn't already exist
                else
                {
                    foreach (string deployFileName in listFileDeploy)
                    {
                        string sourceFileCopy = txt_source_folder.Text + "\\" + deployFileName;
                        string targetFileCopy = txt_target_folder.Text + "\\" + txt_screenID.Text + "\\" + today_folder_name + "\\" + deployFileName;
                        if (deployFileName.Length < 3)
                            continue;
                        try
                        {
                            Directory.CreateDirectory(Path.GetDirectoryName(targetFileCopy));
                            File.Copy(sourceFileCopy, targetFileCopy, true);
                            txt_deployedfile.AppendText(targetFileCopy);
                            int selectionStart = txt_deployedfile.Text.Length;
                            txt_deployedfile.AppendText(" copy success");
                            txt_deployedfile.AppendText(Environment.NewLine);
                            txt_deployedfile.Select(selectionStart, selectionStart + 14);
                            txt_deployedfile.SelectionColor = Color.Green;
                        }
                        catch (Exception ex)
                        {
                            txt_deployedfile.Text = ex.ToString();
                            return;
                        }
                    }
                    commitPath = txt_target_folder.Text + "\\" + txt_screenID.Text;
                }
            }
            else
            {

            }
            source_deploy = txt_target_folder.Text + "\\" + txt_screenID.Text + "\\" + DateTime.Now.ToString("yyyyMMdd").ToString();

        }

        /// <summary>
        /// Find newest folder based on name (yyyymmdd)
        /// </summary>
        /// <param name="files_list"></param>
        /// <returns></returns>
        public string newestFolderFinding(string folder_text)
        {
            string newestFileName = "";
            int max = 0;
            List<string> folderList;
            char[] delimiterChars = { '\r', '\n' };
            folderList = this.fileSplit(folder_text, delimiterChars);
            for (int i = 0; i < folderList.Count(); i++)
            {
                if (folderList[i].Length == 8)
                {
                    if (int.Parse(folderList[i]) > max)
                    {
                        max = int.Parse(folderList[i]);
                    }
                }
            }
            newestFileName = max.ToString();
            return newestFileName;
        }

        /// <summary>
        /// Update lastest version of trunk and tags folder
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_svn_update_Click(object sender, EventArgs e)
        {
            this.SVNUpdateAll();
        }

        /// <summary>
        /// update svn tags and trunk folder
        /// </summary>
        public void SVNUpdateAll()
        {
            string source_path;
            string target_path;
            source_path = this.txt_source_folder.Text.ToString();
            target_path = this.txt_target_folder.Text.ToString();
            if (string.IsNullOrEmpty(source_path))
            {
                MessageBox.Show("Please input source folder");
            }
            else if (!Directory.Exists(source_path))
            {
                MessageBox.Show("Your source folder is not exist !!!");
            }
            else if (string.IsNullOrEmpty(target_path))
            {
                MessageBox.Show("Please input target folder");
            }
            else if (!Directory.Exists(target_path))
            {
                MessageBox.Show("Your target folder is not exist !!!");
            }
            else
            {
                txt_deployedfile.Text = string.Empty;
                this.SVNUpdating(source_path);
                this.SVNUpdating(target_path);
            }
        }

        /// <summary>
        /// Disable source path for save
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chk_fixed_source_MouseClick(object sender, MouseEventArgs e)
        {
            if (chk_fixed_source.Checked == true)
            {
                this.txt_source_folder.Enabled = false;
            }
            else
            {
                this.txt_source_folder.Enabled = true;
            }
        }

        /// <summary>
        /// Disable target path for save
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chk_fixed_target_MouseClick(object sender, MouseEventArgs e)
        {
            if (chk_fixed_target.Checked == true)
            {
                this.txt_target_folder.Enabled = false;
            }
            else
            {
                this.txt_target_folder.Enabled = true;
            }
        }

        /// <summary>
        /// Copy source from tags folder and deploy to root foler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_deploy_Click(object sender, EventArgs e)
        {
            try
            {
                DirectoryCopy(source_deploy, target_deploy, true);
            }
            catch (Exception ex)
            {
                txt_deployedfile.Text = ex.ToString();
            }
        }

        /// <summary>
        /// Commit file at tags folder
        /// </summary>
        /// <param name="commit_path"></param>
        public void commit_svn(string commit_path)
        {
            if (txt_screenID.Text == string.Empty)
            {
                MessageBox.Show("Please input Screen ID !!!");
                return;
            }
            else if (txt_request_user.Text == string.Empty)
            {
                MessageBox.Show("Please input name of request user !!!");
                return;
            }
            else
            {
                string addFileArgument;
                string commitArgument;
                string processing_output;

                addFileArgument = " add ";
                addFileArgument += "\"";
                addFileArgument += commit_path;
                addFileArgument += "\"";

                commitArgument = " commit -m \"requested by ";
                commitArgument += txt_request_user.Text + " \" ";
                commitArgument += "\"";
                commitArgument += commit_path;
                commitArgument += "\"";

                System.Diagnostics.Process process = new System.Diagnostics.Process();
                process.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                process.StartInfo.FileName = "svn.exe";
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.RedirectStandardError = true;

                process.StartInfo.Arguments = addFileArgument;
                process.Start();
                StreamReader reader = process.StandardOutput;
                while ((processing_output = process.StandardOutput.ReadLine()) != null)
                {
                    txt_deployedfile.Text += processing_output + Environment.NewLine;
                }
                process.WaitForExit();

                process.StartInfo.Arguments = commitArgument;
                process.Start();
                while ((processing_output = process.StandardOutput.ReadLine()) != null)
                {
                    txt_deployedfile.Text += processing_output + Environment.NewLine;
                }
                process.WaitForExit();
            }
        }

        /// <summary>
        /// Clear content to make a new session
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_new_session_Click(object sender, EventArgs e)
        {
            this.txt_deployedfile.Text = string.Empty;
            this.txt_request_user.Text = string.Empty;
            this.txt_screenID.Text = string.Empty;
        }

        /// <summary>
        /// Exit Application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_exit_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Application will be closed !!!!!", "Exit confirmation", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                this.Close();
                this.Dispose();
                Application.Exit();
            }
            else if (dialogResult == DialogResult.No)
            {
                this.Show();
            }
        }

        /// <summary>
        /// Create new folder based on screen ID
        /// </summary>
        /// <param name="directory_path"></param>
        public bool create_directory_screenid(string directory_path)
        {
            string id_folder_path;
            id_folder_path = directory_path + "\\" + txt_screenID.Text.ToString();
            if (!Directory.Exists(id_folder_path))
            {
                string notify_msg = "Do you want to create folder [" + txt_screenID.Text.ToString() + "]  !!!!!";
                DialogResult dialogResult = MessageBox.Show(notify_msg, "Exit confirmation", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    try
                    {
                        Directory.CreateDirectory(id_folder_path);
                    }
                    catch (Exception ex)
                    {
                        txt_deployedfile.Text = ex.ToString();
                        return false;
                    }
                }
                else {
                    this.Close();
                    Application.Exit();
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// this will copy directory from source folder to destination folder
        /// </summary>
        /// <param name="sourceDirName"></param>
        /// <param name="destDirName"></param>
        /// <param name="copySubDirs"></param>
        private static void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs)
        {
            // Get the subdirectories for the specified directory.
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);

            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException(
                    "Source directory does not exist or could not be found: "
                    + sourceDirName);
            }

            DirectoryInfo[] dirs = dir.GetDirectories();
            // If the destination directory doesn't exist, create it.
            if (!Directory.Exists(destDirName))
            {
                Directory.CreateDirectory(destDirName);
            }

            // Get the files in the directory and copy them to the new location.
            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                string temppath = Path.Combine(destDirName, file.Name);
                file.CopyTo(temppath, false);
            }

            // If copying subdirectories, copy them and their contents to new location.
            if (copySubDirs)
            {
                foreach (DirectoryInfo subdir in dirs)
                {
                    string temppath = Path.Combine(destDirName, subdir.Name);
                    DirectoryCopy(subdir.FullName, temppath, copySubDirs);
                }
            }
        }

        private void btn_fileImport_Click(object sender, EventArgs e)
        {
            int size = -1;
            txt_deployedfile.Text = string.Empty;
            OpenFileDialog requestFileDialog = new OpenFileDialog();
            DialogResult result = requestFileDialog.ShowDialog(); // Show the dialog.
            string requeatFile = requestFileDialog.FileName;
            if (String.IsNullOrEmpty(requeatFile))
                return;
            string requestSafeFileName = requestFileDialog.SafeFileName.ToString();
            string requestFileContent = File.ReadAllText(requeatFile).ToString();

            if (result == DialogResult.OK) // Test result.
            {
                try
                {
                    size = requestFileContent.Length;
                    txt_deployedfile.Text += requestFileContent;
                    txt_screenID.Text = requestSafeFileName.Substring(0, requestSafeFileName.IndexOf("_")).Trim();
                    int secondUnderscoreIndex = requestSafeFileName.IndexOf("_", requestSafeFileName.IndexOf("_") + 1);
                    txt_request_user.Text = requestSafeFileName.Substring(secondUnderscoreIndex + 1, requestSafeFileName.IndexOf("@") - secondUnderscoreIndex + 13).Trim();
                }
                catch (IOException ex)
                {
                    txt_deployedfile.Text = ex.ToString();
                }
            }
            if (result == DialogResult.Cancel)
                this.Show();
        }

        private void btn_svn_commit_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(commitPath))
            {
                try
                {
                    this.commit_svn(commitPath);
                    source_deploy = commitPath + "\\" + DateTime.Now.ToString("yyyyMMdd");
                }
                catch (Exception ex)
                {
                    txt_deployedfile.Text = ex.ToString();
                }
            }
            else
                txt_deployedfile.Text = "Please check your commit path !!!";
        }
    }
}
