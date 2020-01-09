using System;
using System.Text;
using Debugosaurus.BigUnits.Examples.FileSystem;

namespace Debugosaurus.BigUnits.Examples.CookiePopup.Implementation
{
    public class CookieMessageProvider : ICookieMessageProvider
    {
        private IFileSystem _fileSystem;

        public CookieMessageProvider(IFileSystem fileSystem)
        {
            _fileSystem = fileSystem;
        }

        public string GetMessageTemplate()
        {
            var result = _fileSystem.ReadAllText();

            var bom = Encoding.UTF8.GetString(Encoding.Unicode.GetPreamble());
            if(result.StartsWith(bom, StringComparison.Ordinal))
            {
                result = result.Remove(
                    0,
                    bom.Length);
            }

            return result;
        }
    }
}