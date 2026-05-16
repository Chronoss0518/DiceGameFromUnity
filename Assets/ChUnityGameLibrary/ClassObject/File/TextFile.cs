using System.IO;

namespace ChStd
{
    public class TextFile : FileBase
    {
        ~TextFile()
        {
            Close();
        }

        public override void Open(string _fileName, bool _updateFlg = false)
        {
            if (isOpen) return;

            base.Open(_fileName, _updateFlg);

            try
            {
                var reader = new StreamReader(absolutePath, false);

                text = reader.ReadToEnd();

                reader.Close();
            }
            catch (System.Exception e) { text = ""; }


        }

        public string GetText() { return text; }

        public void SetText(string _text) { text = _text; }

        public void AddText(string _text) { text = text + _text; }

        public override void Close()
        {
            if (!isOpen) return;

            if (updateFlg)
            {
                var writer = new StreamWriter(absolutePath, false);

                writer.Write(text);

                writer.Close();
            }

            base.Close();
        }

        string text = "";
    }

}