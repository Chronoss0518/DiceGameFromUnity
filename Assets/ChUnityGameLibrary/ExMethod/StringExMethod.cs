using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SocialPlatforms;

static public class StringExMethod
{
    //10進数//
    public const string DECIMAL_NUMBUR = "01234456789";
    //16進数//
    public const string HEXA_DECIMAL = "0123456789ABCDEF";
    //8進数//
    public const string OCTAL = "012344567";
    //2進数//
    public const string BINARY_NUMBER = "01";
    //64進数//
    public const string BASE_NUMBER_64 = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/";

    //文字列からエスケープシーケンスへ置換する//
    static public string StringToEscapeSequence(this string _val)
    {
        string res = "";

        for (int i = 0; i < _val.Length; i++) 
        {
            char c = _val[i];

            if(c == '\\' && _val.Length > i + 1)
            {
                i++;
                if ((_val[i] == 'o' ||_val[i] == 'x') && _val.Length > i + 3)
                {
                    string baseType = _val[i] == 'o' ? OCTAL : HEXA_DECIMAL;
                    string value = "";

                    for (int j = 0; j < 2; j++)
                    {
                        value+= _val[i + 1 + j];
                    }
                    int num = 0;

                    if (BaseNumberToDecimalNumber(out num, value, baseType))
                    {
                        i+=2;
                        res += (char)num;
                        continue;
                    }
                    res += "\\";

                    continue;
                }

                if (TO_ESCAPE_SEQUENCE_MAP.ContainsKey(_val[i]))
                {
                    res += TO_ESCAPE_SEQUENCE_MAP[_val[i]];
                    continue;
                }

                res += "\\\\";
                continue;
            }

            res += c;
        }

        return res;
    }

    //エスケープシーケンスから文字列へ置換する//
    static public string StringFromEscapeSequence(this string _val)
    {
        string res = "";
        
        for (int i = 0;i < _val.Length;i++)
        {
            char c = _val[i];

            if (FROM_ESCAPE_SEQUENCE_MAP.ContainsKey(c))
            {
                res += FROM_ESCAPE_SEQUENCE_MAP[c];
                continue;
            }

            if (c <= 0x1e)
            {
                string baseNum = DecimalNumberToBaseNumber(c, HEXA_DECIMAL);

                res += "\\x"+ baseNum;

                continue;
            }

            res += c;
        }

        return res;
    }

    //10進数の数値を入れると指定した配列によって生成された進数表記で出力される//
    static public string DecimalNumberToBaseNumber(
    int _decimal,
    string _baseNumber)
    {
        int decimalVal = _decimal;

        int size = _baseNumber.Length;

        string testRes = "";

        if (_decimal< 0)
        {
            decimalVal = -_decimal;
            testRes += "-";
        }

        int baseVal = decimalVal / size;

        testRes += _baseNumber[decimalVal % size];

        if (baseVal == 0)
        {
            return testRes;
        }

        string res = DecimalNumberToBaseNumber(baseVal, _baseNumber);

        res = res + testRes[0];

        return res;
    }


    //指定した進数の配列を入れると10進数の数値が出力される//
    static public bool BaseNumberToDecimalNumber(
    out int _res,
    string _decimal,
    string _baseNumber)
    {
        _res = 0;
        int res = 0;
        Dictionary<char, int> numMap = new Dictionary<char, int>();

        int size = _baseNumber.Length;

        numMap['-'] = size;

        for (int i = 0; i < size; i++)
        {
            numMap[_baseNumber[i]] = i;
        }

        bool mFlg = numMap[_decimal[0]] == size;

        for (int i = 0; i < (mFlg ? _decimal.Length - 1 : _decimal.Length); i++)
        {
            int tmp = i;

            bool isNumMapChar = numMap.ContainsKey(_decimal[_decimal.Length - tmp - 1]);

            if (!isNumMapChar) return false;

            int sum = numMap[_decimal[_decimal.Length - tmp - 1]];

            for (int j = 0; j < (!mFlg ? tmp : tmp - 1); j++)
            {
                sum *= size;
            }

            res += sum;
        }

        if (mFlg) res = -res;

        _res = res;

        return true;
    }


    static readonly Dictionary<char, string> TO_ESCAPE_SEQUENCE_MAP = new Dictionary<char,string>()
    {
        {'a',"\a" },
        {'b',"\b" },
        {'f',"\f" },
        {'n',"\n" },
        {'r',"\r" },
        {'t',"\t" },
        {'v',"\v" },
        {'\"',"\\\"" },
        {'\'',"\\\'" },
    };

    static readonly Dictionary<char, string> FROM_ESCAPE_SEQUENCE_MAP = new Dictionary<char, string>()
    {
        {'\a',"\\a" },
        {'\b',"\\b" },
        {'\f',"\\f" },
        {'\n',"\\n" },
        {'\r',"\\r" },
        {'\t',"\\t" },
        {'\v',"\\v" },
        {'\"',"\\\"" },
        {'\'',"\\\'" },
        {'\\',"\\\\" },
    };

}
