using System;

namespace ChJson
{
    [Serializable]
    public class JsonNumber : JsonBaseType
    {

        public JsonNumber() { Set(0.0); }

        public JsonNumber(double _val) { Set(_val); }

        static public bool operator ==(JsonNumber _val, double _num)
        {
            if (_val is null) return false;
            return _num == _val.val;
        }
        static public bool operator !=(JsonNumber _val, double _num)
        {
            if (_val is null) return true;
            return _num != _val.val;
        }

        public override bool Equals(object obj)
        {
            return val.Equals(obj);
        }

        public override int GetHashCode()
        {
            return val.GetHashCode();
        }

        public void Set(double _val) { val = _val; }

        public double GetDouble() { return val; }

        public int GetInt() { return (int)val; }

        public bool Is(double _val) { return _val == val; }

        public override bool SetRawData(string _text)
        {
            if (!double.TryParse(_text, out val)) return false;
            return true;
        }

        public override string GetRawData()
        {
            return val.ToString();
        }

        double val = 0.0f;
    }

}