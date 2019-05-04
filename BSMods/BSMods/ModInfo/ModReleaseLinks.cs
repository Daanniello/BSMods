using System;
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

            AddModReleaseLink("[title]Core", "");
            AddModReleaseLink("[important]BSIPA", "https://github.com/nike4613/BeatSaber-IPA-Reloaded/releases/download/3.12.5/Release.zip"); //dll
            //AddModReleaseLink("BSIPA Modlist","https://github.com/beat-saber-modding-group/BeatSaber-IPA-Reloaded/releases/download/3.12.13/ModList.zip"); // dll
            AddModReleaseLink("[important]Songloader", "https://github.com/Kylemc1413/BeatSaberSongLoader/releases");
            AddImportantModLink("Scoresaber (steam)",
                "https://cdn.discordapp.com/attachments/442697165513687062/563188455077707817/scoresaber-2.1.1-steam.zip");
            AddImportantModLink("Scoresaber (oculus)",
                "https://cdn.discordapp.com/attachments/442697165513687062/563188454536773632/scoresaber-2.1.1-oculus.zip");

            AddModReleaseLink("[important]Beatsaver downloader", "https://github.com/andruzzzhka/BeatSaverDownloader/releases");
            AddModReleaseLink("Camera plus", "https://github.com/brian91292/CameraPlus/releases");

            AddModReleaseLink("[title]Dependencies", "");
            AddModReleaseLink("[important]CustomUI", "https://github.com/brian91292/BeatSaber-CustomUI/releases");
            AddModReleaseLink("[important]Newtonsoft.Json", "https://github.com/JamesNK/Newtonsoft.Json/releases");
            AddModReleaseLink("[important]Harmony", "https://bsaber.com/mods/harmony-1.2.0.zip"); //dll
            AddModReleaseLink("[important]Init File Parser", "https://bsaber.com/mods/ini-parser-2.5.2.zip"); //dll
            AddModReleaseLink("[important]Beat saber utils", "https://bsaber.com/mods/bs-utils-1.2.2.zip"); //dll
            AddModReleaseLink("[important]StreamCore",
                "https://github.com/brian91292/StreamCore/releases/download/1.0.3/StreamCore.dll");

            AddModReleaseLink("[title]Reshine", "Reshine Tourney");
            AddModReleaseLink("[important] Reshine mod",
                "https://cdn.discordapp.com/attachments/561300682179870740/566698017432797194/ReshineModKit.zip");

            AddModReleaseLink("[title]Cosmetic Changes", "");
            AddModReleaseLink("Custom Menu Text", "https://github.com/artemiswkearney/CustomMenuText/releases");
            AddModReleaseLink("Custom Sabers", "https://github.com/Kylemc1413/CustomSaberPlugin/releases");
            AddModReleaseLink("Custom Avatars", "https://github.com/xyonico/CustomAvatarsPlugin/releases");
            //AddModReleaseLink("Custom Platforms", "https://github.com/rolopogo/CustomPlatforms/releases/download/2.5.0/CustomPlatforms.dll"); //dll
            AddModReleaseLink("Custom Colors", "https://github.com/Kylemc1413/BeatSaber-CustomColors/releases");
            AddModReleaseLink("Music video player", "https://github.com/rolopogo/MusicVideoPlayer/releases");
            AddModReleaseLink("Transparent wall", "https://github.com/PureDark/BSTransparentWall/releases");
            AddModReleaseLink("[title]Practice / Training", "");
            AddModReleaseLink("Counter plus", "https://github.com/Caeden117/CountersPlus/releases");
            AddModReleaseLink("Hit score visualizer", "https://github.com/artemiswkearney/HitScoreVisualizer/releases");
            AddModReleaseLink("Intro skip", "https://github.com/Kylemc1413/Intro-Skip/releases");
            AddModReleaseLink("Missed counter", "https://github.com/Caeden117/MissedCounter/releases");
            AddModReleaseLink("Notes left counter", "https://github.com/Kylemc1413/NotesLeftCounter/releases");
            AddModReleaseLink("Perfection display", "https://github.com/monkeymanboy/BeatSaberPerfectionDisplay/releases");
            AddModReleaseLink("Practice plugin", "https://github.com/Kylemc1413/PracticePlugin/releases");
            AddModReleaseLink("Progress counter", "https://github.com/Strackeror/BeatSaberProgressCounter/releases");
            AddModReleaseLink("[title]Gameplay changes", "");
            AddModReleaseLink("Daily challenges", "https://github.com/monkeymanboy/BeatSaberDailyChallenges/releases");
            AddModReleaseLink("Darthmaul", "https://github.com/Kylemc1413/BSDarthMaul/releases");
            AddModReleaseLink("Gameplay modifier plus", "https://github.com/Kylemc1413/GameplayModifiersPlus/releases");
            AddModReleaseLink("Gameplay restriction plus", "https://github.com/Kylemc1413/GameplayRestrictionsPlus/releases");
            AddModReleaseLink("Hidden blocks", "https://github.com/brian91292/BeatSaberHiddenBlocks/releases");
            AddModReleaseLink("Hit swap", "https://github.com/ItsNovaHere/HitSwap/releases");
            AddModReleaseLink("Saber tailer", "https://github.com/SteffanDonal/BeatSaber-SaberTailor/releases");
            AddModReleaseLink("Mapping extensions", "https://github.com/Kylemc1413/MappingExtensions/releases");
            AddModReleaseLink("[title]Multiplayer", "");
            AddModReleaseLink("Unofficial multiplayer", "https://github.com/andruzzzhka/BeatSaberMultiplayer/releases");
            AddModReleaseLink("[title]Stream tools", "");
            AddModReleaseLink("Twitch integration", "https://github.com/MrMoogles/Beat-Saber-Twitch-Integration/releases/download/3.0.7/TwitchIntegrationPlugin.zip");
            AddModReleaseLink("Enhanced stream chat", "https://github.com/brian91292/EnhancedStreamChat/releases/download/2.0.1/EnhancedStreamChat.dll"); //dll
            AddModReleaseLink("Song request manager", "https://github.com/angturil/SongRequestManager/releases");
            AddModReleaseLink("HTTP status", "https://github.com/opl-/beatsaber-http-status/releases");
            AddModReleaseLink("Song status", "https://github.com/OshiHidra/BeatSaber-SongStatus/releases");
            AddModReleaseLink("[title]Tweaks / Tools", "");
            AddModReleaseLink("Custom menu text", "https://github.com/artemiswkearney/CustomMenuText/releases");
            AddModReleaseLink("Auto pause", "https://github.com/AurosTV/Auros-s-Auto-Pause/releases");
            AddModReleaseLink("Beat saber tweaks", "https://github.com/Kylemc1413/BeatSaberTweaks/releases");
            AddModReleaseLink("Clock", "https://github.com/AurosTV/Clock/releases");
            AddModReleaseLink("Custom menu music", "https://github.com/Lunikc/CustomMenuMusic/releases");
            AddModReleaseLink("[title]Other", "");
            AddModReleaseLink("Custom exit", "https://github.com/Shoko84/BeatSaberCustomExit/releases");
            AddModReleaseLink("Drink water", "https://github.com/Shoko84/BeatSaberDrinkWater/releases");
            AddModReleaseLink("Bloom mod", "https://github.com/Ibodan/BloomMod/releases");
            AddModReleaseLink("Discord presence", "https://cdn.discordapp.com/attachments/555803569379606529/563485001614753813/DiscordPresencePlugin.v2.1.1.zip"); //dll
            AddModReleaseLink("Leaderboard in song", "https://github.com/Kylemc1413/LeaderboardInSong/releases");
            AddModReleaseLink("Rumble enchancer", "https://github.com/mischiminator/RumbleEnhancer/releases");
            AddModReleaseLink("Random song", "https://github.com/taz030485/RandomSong/releases");
            AddModReleaseLink("Try everything", "https://github.com/Sellorio/try-everything/releases");
            AddModReleaseLink("Sync saber", "https://github.com/brian91292/SyncSaber/releases");
            AddModReleaseLink("[title]Unofficial", "");
            AddModReleaseLink("BeatSaber SongBrowser", "https://github.com/halsafar/BeatSaberSongBrowser/releases");
            AddModReleaseLink("Bail out", "https://github.com/JumpmanSr/BailOutMode/releases");
            AddModReleaseLink("Beat saber online", "https://github.com/vanZeben/BeatSaberOnline/releases");
            AddModReleaseLink("Beatsinger", "https://github.com/71/BeatSinger/releases");
            AddModReleaseLink("Next rank plugin", "https://github.com/peterwooley/NextRankPlugin/releases");
            AddModReleaseLink("Note miss effect remover", "https://github.com/brian91292/BeatSaber-NoteMissEffectRemover/releases");
            AddModReleaseLink("Shitmap detector", "https://github.com/brian91292/BeatSaber-ShitMapDetector/releases");



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
