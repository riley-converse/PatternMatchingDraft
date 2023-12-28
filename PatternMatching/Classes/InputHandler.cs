using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternMatching.Classes
{
    internal class InputHandler
    {
        private readonly FileStream _reader;
        private int _index;

        public InputHandler(string fileName) 
        { 
            _reader = File.OpenRead(fileName);
            _index = 0;
        }

        public async Task<char[]> ReadChunk(int bytes=1024)
        {
            byte[] buffer = new byte[bytes];
            _reader.Position = _index;
            await _reader.ReadAsync(buffer, 0, bytes);
            _index += bytes;

            Encoding encoding = Encoding.UTF8;
            char[] result = new char[bytes];
            result = encoding.GetChars(buffer, 0, bytes);

            return result;
        }
    }
}
