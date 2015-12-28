using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using zlib;

namespace DatReader
{
    public class DatFile
    {
        private long archiveFullSize;
        private int treeSize;
        
        private string datFileName;
        private int fileLength;
		private int currentOffset;

		private int filesTotal;

		private int dirTreeOffset;

		private DirTreeEntry entry;

		private List<DirTreeEntry> entries = new List<DirTreeEntry> { };

		FileStream fileStream;


		public List<DirTreeEntry> Entries
		{
			get { return entries; }
		}

        public DatFile(string fileName)
        {
            datFileName = fileName;
			fileStream = new FileStream(datFileName, FileMode.Open);
			GetFileData();
			archiveFullSize = GetArchiveFullSize();
			treeSize = GetTreeSize();
			dirTreeOffset = fileLength - treeSize - 4;
			filesTotal = GetFilesTotal();
			currentOffset = dirTreeOffset;
			for (int i = 0; i<filesTotal; i++)
			{
				entry = GetTreeEntry(currentOffset);
				entries.Add(entry);
				currentOffset = entry.EndOffset;
			}

			fileStream.Close();
		}

		public byte[] GetFile(string fileName)
		{
			int entryIndex = Entries.BinarySearch(new DatReader.DirTreeEntry(fileName));


			return GetFile(Entries[entryIndex]);
		}

		public byte[] GetFile(DirTreeEntry entry)
		{
			byte[] result = new byte[entry.PackedSize];

			FileStream fileStream = new FileStream(datFileName, FileMode.Open);

			fileStream.Seek(entry.Offset, SeekOrigin.Begin);
			fileStream.Read(result, 0, entry.PackedSize);

			fileStream.Close();

			if (entry.IsCompressed)
				return DecompressFile(result, entry.RealSize);
			
			return result;
		}

		private byte[] DecompressFile(byte[] data, int uncompresedSize)
		{
			MemoryStream inputStream = new MemoryStream(data);
			MemoryStream outputStream = new MemoryStream();

			zlib.ZOutputStream outZStream = new zlib.ZOutputStream(outputStream);

			CopyStream(inputStream, outZStream);

			byte[] result = outputStream.ToArray();

			return result;
		}

		public static void CopyStream(System.IO.Stream input, System.IO.Stream output)
		{
			byte[] buffer = new byte[1];
			int len;
			while ((len = input.Read(buffer, 0, 1)) > 0)
			{
				output.Write(buffer, 0, len);
			}
			output.Flush();
		}

        private void GetFileData()
        {
            FileInfo fi = new FileInfo(datFileName);
            fileLength = Convert.ToInt32(fi.Length);
        }

        private int GetFilesTotal()
        {
			return GetDwordValue(dirTreeOffset - 4);
        }

        private long GetArchiveFullSize()
        {
			return GetDwordValue(fileLength - 4);
        }

		private int GetTreeSize()
		{
			return GetDwordValue(fileLength - 8);
		}

		private DirTreeEntry GetTreeEntry(int offset)
		{
			DirTreeEntry result = new DirTreeEntry();

			result.FileNameSize = GetDwordValue(offset);

			offset += 4;
			result.FileName = GetStringValue(offset, result.FileNameSize);
			offset += result.FileNameSize;
			result.IsCompressed = Convert.ToBoolean(GetByteValue(offset));
			offset += 1;
			result.RealSize = GetDwordValue(offset);
			offset += 4;
			result.PackedSize = GetDwordValue(offset);
			offset += 4;
			result.Offset = GetDwordValue(offset);
			result.EndOffset = offset + 4;

			return result;
		}

		private int GetDwordValue(int offset)
		{
			byte[] result = new byte[4];

			fileStream.Seek(offset, SeekOrigin.Begin);
			fileStream.Read(result, 0, 4);

			return BitConverter.ToInt32(result, 0);
		}

		private byte GetByteValue(int offset)
		{
			byte[] result = new byte[1];

			fileStream.Seek(offset, SeekOrigin.Begin);
			fileStream.Read(result, 0, 1);

			return result[0];
		}

		private string GetStringValue(int offset, int length)
		{
			byte[] mas = new byte[length];

			fileStream.Seek(offset, SeekOrigin.Begin);
			fileStream.Read(mas, 0, length);

			string result = string.Empty;

			foreach (byte b in mas)
				result += Convert.ToChar(b).ToString();

			return result;
		}

	}
}
