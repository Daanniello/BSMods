using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO.Compression;
using System.Windows.Controls;
using System.Net;
using System.IO;

namespace BSMods
{
    class BSModsMain
    {
        public string beatSaberPath = "C:\\Program Files (x86)\\Steam\\steamapps\\common\\Beat Saber";
        public List<string[]> gitHubModReleaseLinks;
        public List<string[]> ImportantMods;
        public List<string[]> OtherMods;

        public DBConnection Database;

        public BSModsMain()
        {
            gitHubModReleaseLinks = new ModReleaseLinks().gitHubModReleaseLinks;
            ImportantMods = new ModReleaseLinks().ImportantMods;
            OtherMods = new ModReleaseLinks().OtherMods;

            Database = new DBConnection();
        }

        

        public async void InstallMods(ListBox checkedListBoxMods)
        {
         
            var checkedItems = checkedListBoxMods.Items;
            foreach (CheckBox checkedReleaseLink in checkedItems)
            {
                if (checkedReleaseLink.IsChecked == false) continue;

                ////----------------------------------------------GithubMods mods
                //foreach (var modRelease in gitHubModReleaseLinks)
                //{
                //    if (checkedReleaseLink.Content == modRelease[0])
                //    {
                //        await FetchDownload.InsertZipFileFromDownloadLinkToTemp(modRelease[1], beatSaberPath + "\\ZipFiles\\" + checkedReleaseLink.Content + ".zip");

                //        try
                //        {
                //            var zipPath = beatSaberPath + "\\ZipFiles\\" + checkedReleaseLink.Content + ".zip" + "\\" + checkedReleaseLink.Content + ".zip";
                //            ExternExtensions.ExtractToDirectory(ZipFile.Open(zipPath, ZipArchiveMode.Read), beatSaberPath, true);
                //        }
                //        catch
                //        {

                //        }

                //    }
                //}
                //----------------------------------------------Important mods
                foreach (var modRelease in ImportantMods)
                {
                    if (checkedReleaseLink.Content == modRelease[0])
                    {
                        var extension = modRelease[1].Split('.');
                        await FetchDownload.DownloadAndInsertZipFileFromDownloadLink(modRelease[1], beatSaberPath + "\\ZipFiles\\" + checkedReleaseLink.Content + "." + extension[extension.Length - 1]);

                        var zipPath = "";

                        try
                        {
                            zipPath = beatSaberPath + "\\ZipFiles\\" + checkedReleaseLink.Content + "." + extension[extension.Length - 1] + "\\" + checkedReleaseLink.Content + "." + extension[extension.Length - 1];
                            ExternExtensions.ExtractToDirectory(ZipFile.Open(zipPath, ZipArchiveMode.Read), beatSaberPath, true);
                            

                        }
                        catch(Exception ex)
                        {


                            try
                            {
                                using (WebClient wc = new WebClient())
                                {
                                    var destinationFile = beatSaberPath.Split('\\');

                                    if (!Directory.Exists(beatSaberPath + "\\Plugins"))
                                    {
                                        
                                        Directory.CreateDirectory(beatSaberPath + "\\Plugins");
                                    }

                                    
                                    await wc.DownloadFileTaskAsync(
                                        new System.Uri(zipPath),
                                        beatSaberPath + "\\Plugins\\" + modRelease[0] + ".dll"
                                    );
                                }
                            }
                            catch
                            {
                                Console.WriteLine(modRelease[0] + " Failed!");
                                //return;
                            }
                            
                        }

                    }
                }
                //---------------------------------------------OtherMods
                foreach (var modRelease in OtherMods)
                {
                    if (checkedReleaseLink.Content == modRelease[0])
                    {
                        var extension = modRelease[1].Split('.');
                        await FetchDownload.DownloadAndInsertZipFileFromDownloadLink(modRelease[1], beatSaberPath + "\\ZipFiles\\" + checkedReleaseLink.Content + "." + extension[extension.Length - 1]);

                        var zipPath = "";

                        try
                        {
                            zipPath = beatSaberPath + "\\ZipFiles\\" + checkedReleaseLink.Content + "." + extension[extension.Length - 1] + "\\" + checkedReleaseLink.Content + "." + extension[extension.Length - 1];
                            ExternExtensions.ExtractToDirectory(ZipFile.Open(zipPath, ZipArchiveMode.Read), beatSaberPath, true);


                        }
                        catch (Exception ex)
                        {
                            try
                            {
                                using (WebClient wc = new WebClient())
                                {
                                    var destinationFile = beatSaberPath.Split('\\');
                                    await wc.DownloadFileTaskAsync(
                                        new System.Uri(zipPath),
                                        beatSaberPath + "\\Plugins\\" + modRelease[0] + ".dll"
                                    );
                                }
                            }
                            catch
                            {

                            }
                        }

                    }
                }

            }

            //Process.Start(beatSaberPath + "\\IPA.exe");
            LaunchCommandLineApp(beatSaberPath + "\\IPA.exe", beatSaberPath);

        }

        static void LaunchCommandLineApp(string path, string installDirectory)
        {

            Process.Start(new ProcessStartInfo
            {
                FileName = path,
                WindowStyle = ProcessWindowStyle.Hidden,
                WorkingDirectory = installDirectory,
                Arguments = "-fn"
            }).WaitForExit();

        }

        //public void SetBeatSaberPath(FolderBrowserDialog folderBrowserDialog)
        //{
        //    var result = folderBrowserDialog.ShowDialog();
        //    beatSaberPath = folderBrowserDialog.SelectedPath;
        //}
        }
}
