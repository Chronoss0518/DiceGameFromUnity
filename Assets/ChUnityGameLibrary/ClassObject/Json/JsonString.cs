using System;

namespace ChJson
{
    [Serializable]

    public class JsonString : JsonBaseType
    {
        public const char START_END = '\"';

        public JsonString() { Set(""); }

        public JsonString(string _val) { Set(_val); }

        static public bool operator ==(JsonString _val, string _str)
        {
            if(_val is null) return false;
            return _str == _val.val;
        }
        static public bool operator !=(JsonString _val, string _str)
        {
            if (_val is null) return false;
            return _str != _val.val;
        }

        public override bool Equals(object obj)
        {
            return val.Equals(obj);
        }

        public override int GetHashCode()
        {
            return val.GetHashCode();
        }

        public void Set(string _val) { val = _val; }

        public string Get() { return val; }

        public bool Is(string _str) { return val == _str; }

        public override bool SetRawData(string _text)
        {
            if (_text.Length < 2) return false;
            if (_text[0] != START_END || _text[_text.Length - 1] != START_END) return false;
            string testText = _text.Substring(1, _text.Length - 2);
            val = testText.StringToEscapeSequence();
            return true;
        }

        public override string GetRawData()
        {
            return START_END + val.StringFromEscapeSequence() + START_END;
        }

        string val = "";
    }

}