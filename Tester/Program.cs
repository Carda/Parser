
using GenericParser.ParserWorker;
using System.IO;
using System.IO.MemoryMappedFiles;


namespace Tester
{
    class Program
    {

        static void Main(string[] args)
        {
            string FileNamestr = @"C:\hede\TRAN0630";
            long fileLength = (new FileInfo(FileNamestr)).Length;
            byte[] buff = new byte[fileLength];
            using (MemoryMappedFile mmf = MemoryMappedFile.CreateFromFile(FileNamestr, FileMode.Open, "Text", 0, MemoryMappedFileAccess.Read))
            {
                using (var reader = mmf.CreateViewAccessor(0, 0, MemoryMappedFileAccess.Read))
                {
                    reader.ReadArray<byte>(0, buff, 0, (int)fileLength);
                }
            }

            ParseIt.Instance.ConvertFromText<TranObj>(buff, 4724, 6627960, 135);
        }
    }
}
