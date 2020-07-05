using System;

namespace Orikivo.Wrappers.Unstable
{
    public static class ProcessManager
    {
        public static Process New(string file)
            => new Process(new ProcessOptions(file));
    }

    public class Process
    {
        public Process(ProcessOptions options)
        {

        }
    }

    public class ProcessOptions
    {
        public ProcessOptions(string file)
        {

        }

    }

    public interface IProcess<T>
    {
        
    }

    // handles as a basic client structure for wrappers.
    public interface IAuthenticatedWrapperClient : IWrapperClient
    {
        string Token { get; }
    }

    public interface IWrapperClient
    {
        string HomePath { get; }
    }

    public interface IProcessClient
    {
        string ExecutableName { get; }
    }

    // handles basic methods and such. 
    public class YoutubeDownloaderClient : IProcessClient
    {  
        public string ExecutableName { get { return "youtube-dl"; } }
        public void Help() {}
        public void GetVersion() {}
        public void Update() {}
    }

    public class YoutubeDownloaderData
    {
        public YoutubeDownloaderOptions Options;
        public void SetConfigPath(string path)
        {
            
        }
    }

    public class YoutubeDownloaderOptions
    {

    }

    public class DefaultOptions
    {
        public bool IgnoreErrors;
        public bool CloseOnError;
        public bool MarkWatched; // if true, mark-watched, else no-mark-watched
    }

    public class NetworkOptions
    {
        public bool ForceIpv4;
        public bool ForceIpv6;
    }

    public class VideoSelectionOptions
    {
        public int PlaylistStartIndex;
        public int PlaylistEndIndex;
        public int[] PlaylistIndexes;
        public string MatchTitle;
        public string RejectTitle;
        public int DownloadLimit;
        public int MinFileSize;
        public int MaxFileSize;
        public DateTime Date;
        public DateTime BeforeDate;
        public DateTime AfterDate;
        public int MinViewCount;
        public int MaxViewCount;
        public MatchFilter MatchFilter;
        public bool? IgnorePlaylist; // T = --no-playlist, F = --yes-playlist
        public int AgeLimit;
        public bool DownloadArchive;
        public string DownloadArchivePath;
        public bool IncludeAds;
    }
    
}