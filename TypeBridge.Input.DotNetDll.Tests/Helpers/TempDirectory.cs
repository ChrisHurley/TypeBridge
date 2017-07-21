using System;
using System.IO;

namespace TypeBridge.Input.DotNetDll.Tests.Helpers
{
    public class TempDirectory : IDisposable
    {
        public string FolderPath { get; }

        private TempDirectory(string path)
        {
            FolderPath = path;
        }

        public static TempDirectory Create()
        {
            var path = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());

            Directory.CreateDirectory(path);

            return new TempDirectory(path);
        }

        public void Dispose()
        {
            Directory.Delete(FolderPath, true);
        }
    }
}
