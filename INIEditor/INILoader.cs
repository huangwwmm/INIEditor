using System;
using System.Collections.Generic;
using System.IO;

namespace INIEditor
{
    public class INILoader
    {
        public const char COMMENT_SYMBOL1 = ';';
        public const char COMMENT_SYMBOL2 = '#';
        public const char COMBINE_GROUP_KEY = '_';

        private Dictionary<string, string> ms_Items = new Dictionary<string, string>();

        public void LoadFromFile(string filePath)
        {
            string[] lines = File.ReadAllLines(filePath);
            LoadFromLines(lines);
        }

        public void LoadFromLines(string[] lines)
        {
            string prefix = "";
            for (int iLine = 0; iLine < lines.Length; iLine++)
            {
                string iterLine = lines[iLine];
                // 忽略空行
                if (string.IsNullOrEmpty(iterLine))
                {
                    continue;
                }

                if (iterLine[0] == '[')
                {
                    prefix = iterLine.Substring(1, iterLine.IndexOf(']') - 1);
                    if (prefix.Length > 0)
                    {
                        prefix += '_';
                    }
                }
                // 注释
                else if (iterLine[0] == COMMENT_SYMBOL1
                    || iterLine[0] == COMMENT_SYMBOL2)
                {
                    continue;
                }
                else
                {
                    string key = prefix + iterLine.Substring(0, iterLine.IndexOf('='));
                    string value = iterLine.Substring(iterLine.IndexOf('=') + 1);
                    if (ms_Items.ContainsKey(key))
                    {
                        ms_Items[key] = value;
                    }
                    else
                    {
                        ms_Items.Add(key, value);
                    }
                }
            }
        }

        public string GetValue(string fullKey, string defaultValue = "")
        {
            bool sucess = TryGetValue(fullKey, out string value);
            if (sucess)
            {
                return value;
            }
            else
            {
                return defaultValue;
            }
        }

        public bool GetBoolValue(string fullKey, bool defaultValue = false)
        {
            if (!TryGetBoolValue(fullKey, out bool value))
            {
                value = defaultValue;
            }
            return value;
        }

        public float GetFloatValue(string fullKey, float defaultValue = 0)
        {
            if (!TryGetFloatValue(fullKey, out float value))
            {
                value = defaultValue;
            }
            return value;
        }

        public int GetIntValue(string fullKey, int defaultValue = 0)
        {
            if (!TryGetIntValue(fullKey, out int value))
            {
                value = defaultValue;
            }
            return value;
        }

        public bool TryGetValue(string fullKey, out string value)
        {
            bool sucess = ms_Items.TryGetValue(fullKey, out value);
            return sucess;
        }

        public bool TryGetIntValue(string fullKey, out int value)
        {
            if (TryGetValue(fullKey, out string sValue))
            {
                if (int.TryParse(sValue, out value))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                value = 0;
                return false;
            }
        }

        public bool TryGetFloatValue(string fullKey, out float value)
        {
            if (TryGetValue(fullKey, out string sValue))
            {
                if (float.TryParse(sValue, out value))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                value = 0;
                return false;
            }
        }

        public bool TryGetBoolValue(string fullKey, out bool value)
        {
            if (TryGetValue(fullKey, out string sValue))
            {
                if (bool.TryParse(sValue, out value))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                value = false;
                return false;
            }
        }

        public bool TryGetEnumValue<TEnum>(string fullKey, out TEnum value) where TEnum : struct
        {
            TryGetValue(fullKey, out string sValue);
            return Enum.TryParse(sValue, out value);
        }

        public bool TryGetEnumValue(string fullKey, Type enumType, out object value)
        {
            TryGetValue(fullKey, out string sValue);
            try
            {
                value = Enum.Parse(enumType, sValue);
                return true;
            }
            catch (Exception)
            {
                value = default;
                return false;
            }
        }

        public string CombineKey(string group, string key)
        {
            return $"{group}{COMBINE_GROUP_KEY}{key}";
        }

        public bool HasKey(string fullKey)
        {
            return ms_Items.ContainsKey(fullKey);
        }
    }
}
