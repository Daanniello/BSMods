using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;


namespace BSMods
{
    class ModReleaseLinks
    {
        public List<string[]> gitHubModReleaseLinks;
        public List<string[]> ImportantMods;
        public List<string[]> OtherMods;

        public ModReleaseLinks()
        {
            gitHubModReleaseLinks = new List<string[]>();
            ImportantMods = new List<string[]>();
            OtherMods = new List<string[]>();

            //Install Files
            AddImportantModLink("BS IPA", "https://github.com/nike4613/BeatSaber-IPA-Reloaded/releases/download/3.12.5/Release.zip");
            AddImportantModLink("Newtonsoft JSON", "https://bsaber.com/mods/newtonsoft-json-12.0.1.zip");
            AddImportantModLink("Harmony", "https://bsaber.com/mods/harmony-1.2.0.zip");
            AddImportantModLink("CustomUI", "https://cdn.discordapp.com/attachments/555803569379606529/563521440973062163/BeatSaberCustomUI.dll");
            AddImportantModLink("Ini-parser", "https://bsaber.com/mods/ini-parser-2.5.2.zip");
            AddImportantModLink("BS-utils", "https://bsaber.com/mods/bs-utils-1.2.2.zip");

            //Important mods
            AddImportantModLink("Songloader", "https://bsaber.com/mods/song-loader-6.9.5.zip");

            //Other mods
            AddOtherMod("Scoresaber", "https://cdn.discordapp.com/attachments/442697165513687062/563188455077707817/scoresaber-2.1.1-steam.zip");


            AddModReleaseLink("BeatSaber SongBrowser", "https://github.com/halsafar/BeatSaberSongBrowser/releases");
            AddModReleaseLink("Custom Menu Text", "https://github.com/artemiswkearney/CustomMenuText/releases");
        }

        public string[] AddImportantModLink(string name, string link)
        {
            ImportantMods.Add(new string[] { name, link });
            return new string[] { name, link };
        }

        public string[] AddOtherMod(string name, string link)
        {
            OtherMods.Add(new string[] { name, link });
            return new string[] { name, link };
        }

        public string[] AddModReleaseLink(string name, string link)
        {
            gitHubModReleaseLinks.Add(new string[]{name, link});
            return new string[] { name, link };
        }

        //public void CreateJsonFromModList(Main main)
        //{
        //    var filePath = "";
            
        //    var saveFileDialog = new SaveFileDialog();

        //    saveFileDialog.Title = "Save json as...";
        //    saveFileDialog.Filter = "JSON File|*.json";
        //    DialogResult result = saveFileDialog.ShowDialog();

        //    if (result == DialogResult.OK)
        //    {

        //    }

        //    using (StreamWriter file = File.CreateText(saveFileDialog.FileName))
        //    {
        //        JsonSerializer serializer = new JsonSerializer();
        //        //serialize object directly into file stream
        //        serializer.Serialize(file,  main.gitHubModReleaseLinks);
        //    }
        //}

        //public List<string[]> ImportModListFromJson()
        //{
        //    var fileDialog = new OpenFileDialog();
        //    if (fileDialog.ShowDialog() != DialogResult.OK) return new List<string[]>();


        //    using (StreamReader r = new StreamReader(fileDialog.FileName))
        //    {
        //        string json = r.ReadToEnd();
        //        gitHubModReleaseLinks = JsonConvert.DeserializeObject<List<string[]>>(json);
        //    }

        //    return gitHubModReleaseLinks;
        //}

        
    }
}
