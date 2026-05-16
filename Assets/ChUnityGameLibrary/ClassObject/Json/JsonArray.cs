using System;
using System.Collections.Generic;


namespace ChJson
{
    [Serializable]
    public class JsonArray : JsonBaseType
    {
        public const char START_CHAR = '[';
        public const char END_CHAR = ']';
        public const char CUT_CHAR = ',';

        public void Set(JsonBaseType _obj,int _index)
        {
            if (!IsInArrayRangeNum(_index)) return;
            if (_obj == null) _obj = new JsonNull();

            arrayVal[_index] = _obj;
        }

        public JsonBaseType Get(int _index)
        {
            if (!IsInArrayRangeNum(_index)) return null;

            return arrayVal[_index];
        }

        public bool GetBool(int _index)
        {
            if (!IsInArrayRangeNum(_index)) return false;

            var flg = (JsonBoolean)arrayVal[_index];
            if (flg == null) return false;

            return flg.Get();
        }

        public string GetString(int _index)
        {
            if (!IsInArrayRangeNum(_index)) return "";

            var str = (JsonString)arrayVal[_index];
            if (str == null) return "";

            return str.Get();
        }

        public double GetNumberDouble(int _index)
        {
            if (!IsInArrayRangeNum(_index)) return 0.0;

            var num = (JsonNumber)arrayVal[_index];
            if (num == null) return 0.0;

            return num.GetDouble();
        }

        public int GetNumberInt(int _index)
        {
            if (!IsInArrayRangeNum(_index)) return 0;

            var num = (JsonNumber)arrayVal[_index];
            if (num == null) return 0;

            return num.GetInt();
        }

        public JsonArray GetArray(int _index)
        {
            if (!IsInArrayRangeNum(_index)) return null;

            return (JsonArray)arrayVal[_index];
        }

        public JsonObject GetObject(int _index)
        {
            if (!IsInArrayRangeNum(_index)) return null;

            return (JsonObject)arrayVal[_index];
        }

        public int GetCount()
        {
            return arrayVal.Count;
        }

        public void Add(JsonBaseType _obj)
        {
            if(_obj == null)_obj = new JsonNull();
            arrayVal.Add(_obj);
        }

        public void Add(string _str)
        {
            arrayVal.Add(new JsonString(_str));
        }

        public void Add(double _num)
        {
            arrayVal.Add(new JsonNumber(_num));
        }

        public void Add(bool _flg)
        {
            arrayVal.Add(new JsonBoolean(_flg));
        }

        public void RemoveAt(int _index)
        {
            if (!IsInArrayRangeNum(_index)) return;

            arrayVal.RemoveAt(_index);
        }

        public override bool SetRawData(string _text)
        {
            if (_text.Length < 2) return false;
            if (_text[0] != START_CHAR || _text[_text.Length - 1] != END_CHAR) return false;
            string text = _text.Substring(1, _text.Length - 2);
            List<string> textList;
            if(!GetCutTextList(out textList, text))return false;

            for (int i = 0; i < textList.Count; i++)
            {
                var obj = Create(textList[i]);
                Add(obj);
            }

            return true;
        }

        public override string GetRawData()
        {
            string res = "";

            res += START_CHAR;

            for(int i =  0;i< arrayVal.Count;i++)
            {
                res += arrayVal[i].GetRawData();
                if (i < arrayVal.Count - 1)
                    res += CUT_CHAR;
            }

            res += END_CHAR;

            return res;
        }

        private bool IsInArrayRangeNum(int _index)
        {
            return arrayVal.Count > _index && 0 >= _index;
        }

        List<JsonBaseType>arrayVal = new List<JsonBaseType>();
    }

}
