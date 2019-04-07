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
            AddOtherMod("Scoresaber (Steam)", "https://cdn.discordapp.com/attachments/442697165513687062/563188455077707817/scoresaber-2.1.1-steam.zip");
            AddOtherMod("Scoresaber (Oculus)", "https://cdn.discordapp.com/attachments/442697165513687062/563188454536773632/scoresaber-2.1.1-oculus.zip");
            AddOtherMod("EnhancedStreamChat","https://cdn.discordapp.com/attachments/555803569379606529/563513516129124372/EnhancedStreamChat.zip");
            AddOtherMod("BeatSaverDownloader", "https://bsaber.com/mods/beatsaverdownloader-3.3.1.zip");
            AddOtherMod("Camera+", "https://bsaber.com/mods/camera-plus-3.2.6.zip");
            AddOtherMod("Custom Menu text", "https://bsaber.com/mods/custommenutext-3.0.1.zip");
            AddOtherMod("HTTP Status", "https://bsaber.com/mods/http-status-1.4.1.zip");
            AddOtherMod("Perfection Display", "https://bsaber.com/mods/perfectiondisplay-1.5.1.zip");
            AddOtherMod("Counters+", "https://bsaber.com/mods/countersplus-1.5.2.zip");
            AddOtherMod("Simplest Rainbow Mod", "https://bsaber.com/mods/simplest-rainbow-mod-1.5.1.zip");
            AddOtherMod("SongBrowserPlugin", "https://bsaber.com/mods/songbrowserplugin-3.0.4.zip");
            AddOtherMod("LeaderboardInSong", "https://bsaber.com/mods/leaderboardinsong-1.1.2.zip");
            AddOtherMod("Beat Saber Tweaks", "https://bsaber.com/mods/beat-saber-tweaks-4.4.1.zip");
            AddOtherMod("Practice Plugin", "https://bsaber.com/mods/practice-plugin-4.2.4.zip");
            AddOtherMod("IntroSkip", "https://bsaber.com/mods/introskip-2.2.2.zip");
            AddOtherMod("Gameplay Restrictions Plus", "https://bsaber.com/mods/gameplay-restrictions-plus-1.2.0.zip");
            AddOtherMod("Gameplay Modifiers Plus", "https://bsaber.com/mods/gameplay-modifiers-plus-1.9.2.zip");
            AddOtherMod("Custom Sabers", "https://github.com/Kylemc1413/CustomSaberPlugin/releases/download/2.8.3/CustomSabers2.8.3.zip");
            AddOtherMod("Mapping Extensions", "https://bsaber.com/mods/mapping-extensions-1.1.1.zip");

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
