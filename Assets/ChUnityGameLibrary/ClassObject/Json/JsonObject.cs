using System;
using System.Collections.Generic;
using UnityEngine.UIElements;

namespace ChJson
{
    [Serializable]
    public class JsonObject : JsonBaseType
    {
        public const char START_CHAR = '{';
        public const char END_CHAR = '}';
        public const char CUT_CHAR = ',';
        public const char KEY_VALUE_CUT_CHAR = ':';

        public void Set(JsonBaseType _obj, string _key)
        {
            if (_obj == null) _obj = new JsonNull();

            values[_key] = _obj;
        }

        public JsonBaseType Get(string _key)
        {
            if (!values.ContainsKey(_key)) return null;

            return values[_key];
        }

        public bool GetBool(string _key)
        {
            if (!values.ContainsKey(_key)) return false;

            var flg = (JsonBoolean)values[_key];
            if (flg == null) return false;

            return flg.Get();
        }

        public string GetString(string _key)
        {
            if (!values.ContainsKey(_key)) return "";

            var str = (JsonString)values[_key];
            if (str == null) return "";

            return str.Get();
        }

        public double GetNumberDouble(string _key)
        {
            if (!values.ContainsKey(_key)) return 0.0;

            var num = (JsonNumber)values[_key];
            if (num == null) return 0.0;

            return num.GetDouble();
        }

        public int GetNumberInt(string _key)
        {
            if (!values.ContainsKey(_key)) return 0;

            var num = (JsonNumber)values[_key];
            if (num == null) return 0;

            return num.GetInt();
        }

        public JsonArray GetArray(string _key)
        {
            if (!values.ContainsKey(_key)) return null;

            return (JsonArray)values[_key];
        }

        public JsonObject GetObject(string _key)
        {
            if (!values.ContainsKey(_key)) return null;

            return (JsonObject)values[_key];
        }

        public int GetCount()
        {
            return values.Count;
        }

        public string[] GetKeys()
        {
            string[] res = new string[values.Keys.Count];
            values.Keys.CopyTo(res, 0);
            return res;
        }
        public JsonBaseType[] GetValues()
        {
            JsonBaseType[] res = new JsonBaseType[values.Values.Count];
            values.Values.CopyTo(res, 0);
            return res;
        }

        public void Add(JsonBaseType _obj, string _key)
        {
            if (_obj == null) _obj = new JsonNull();
            values[_key] = _obj;
        }

        public void Add(string _str, string _key)
        {
            values[_key] = new JsonString(_str);
        }

        public void Add(double _num, string _key)
        {
            values[_key]= new JsonNumber(_num);
        }

        public void Add(bool _flg, string _key)
        {
            values[_key] = new JsonBoolean(_flg);
        }

        public void Remove(string _key)
        {
            if (!values.ContainsKey(_key)) return;

            values.Remove(_key);
        }

        public bool IsContainsKey(string _key)
        {
            return values.ContainsKey(_key);
        }

        public bool IsContainsValue(JsonBaseType _value)
        {
            return values.ContainsValue(_value);
        }

        public override bool SetRawData(string _text)
        {
            if (_text.Length < 2) return false;
            if (_text[0] != START_CHAR || _text[_text.Length - 1] != END_CHAR) return false;
            string text = _text.Substring(1, _text.Length - 2);
            List<string> textList;
            if (!GetCutTextList(out textList, text)) return false;

            bool successFlg = true;

            for(int i = 0;i < textList.Count;i++)
            {
                var keyValue = CutKeyValue(textList[i]);
                if (keyValue == null) continue;

                var key = new JsonString();
                if(!key.SetRawData(keyValue.key))
                {
                    successFlg = false;
                    break;
                }

                var obj = Create(keyValue.value);
                if (obj ==  null)
                {
                    successFlg = false;
                    break;
                }

                values[key.Get()] = obj;
            }


            return successFlg;
        }

        public override string GetRawData()
        {
            string res = "";

            res += START_CHAR;

            var str = new JsonString();

            int count = 0;

            foreach (var keyValues in values)
            {
                str.Set(keyValues.Key);
                res += str.GetRawData();
                res += KEY_VALUE_CUT_CHAR;
                res += keyValues.Value.GetRawData();
                if (count < values.Count - 1)
                    res += CUT_CHAR;

                count++;
            }

            res += END_CHAR;

            return res;
        }

        class keyValue
        {
            public string key = "";
            public string value = "";
        }

        keyValue CutKeyValue(string _val)
        {
            bool inString = false;

            for(int i= 0;i<_val.Length;i++)
            {
                if (_val[i] == JsonString.START_END) inString = !inString;

                if (inString) continue;

                if (_val[i] != KEY_VALUE_CUT_CHAR) continue;

                keyValue res = new keyValue();

                res.key = _val.Substring(0, i);
                res.value = _val.Substring(i + 1);

                return res;

            }

            return null;
        }

        Dictionary<string,JsonBaseType>values = new Dictionary<string,JsonBaseType>();
    }

}