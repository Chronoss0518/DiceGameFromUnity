
using System;

namespace ChJson
{
    [Serializable]
    public class JsonBoolean : JsonBaseType
    {
        const string TRUE = "true";
        const string FALSE = "false";

        public JsonBoolean() { Set(false); }

        public JsonBoolean(bool _flg) {  Set(_flg); }

        static public bool operator ==(JsonBoolean _val, bool _flg)
        {
            if (_val is null) return false;
            return _flg == _val.flg;
        }
        static public bool operator !=(JsonBoolean _val, bool _flg)
        {
            if (_val is null) return true;
            return _flg != _val.flg;
        }

        public override bool Equals(object obj)
        {
            return flg.Equals(obj);
        }

        public override int GetHashCode()
        {
            return flg.GetHashCode();
        }

        public void Set(bool _flg) { flg  = _flg; }
        
        public bool Get() { return flg; }

        public bool Is(bool _flg) { return flg == _flg; }

        public override bool SetRawData(string _text)
        {
            if (TRUE != _text &&FALSE !=_text) return false;
            flg = TRUE ==_text;
            return true;
        }

        public override string GetRawData()
        {
            return flg ? TRUE : FALSE;
        }

        bool flg = false;
    }

}