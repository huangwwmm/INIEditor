using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace INIEditor
{
    public class BaseConfig : IConfig
    {
        public void LoadFromLines(string[] lines)
        {
            INILoader ini = new INILoader();
            ini.LoadFromLines(lines);
            LoadFromINILoader(ini);
        }

        public void LoadFromFile(string path)
        {
            if (!File.Exists(path))
            {
                return;
            }

            INILoader ini = new INILoader();
            ini.LoadFromFile(path);
            LoadFromINILoader(ini);
        }

        public void SaveToFile(string path)
        {
            StringBuilder stringBuilder = new StringBuilder();
            Type type = GetType();
            DescriptionAttribute typeDescriptionAttribute = type.GetCustomAttribute<DescriptionAttribute>();
            if (typeDescriptionAttribute != null)
            {
                stringBuilder.Append(INILoader.COMMENT_SYMBOL1).Append(' ')
                    .Append(typeDescriptionAttribute.Description.Replace("\r\n", $"\n{INILoader.COMMENT_SYMBOL1} "))
                    .Append('\n');
            }

            PropertyInfo[] properties = GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
            string lastGroup = string.Empty;
            for (int iProperty = 0; iProperty < properties.Length; iProperty++)
            {
                PropertyInfo iterProperty = properties[iProperty];
                CategoryAttribute categoryAttribute = iterProperty.GetCustomAttribute<CategoryAttribute>();
                if (categoryAttribute.Category != lastGroup)
                {
                    lastGroup = categoryAttribute.Category;
                    stringBuilder.Append('\n')
                        .Append('[').Append(lastGroup).Append(']')
                        .Append('\n');
                }

                DescriptionAttribute descriptionAttribute = iterProperty.GetCustomAttribute<DescriptionAttribute>();
                if (descriptionAttribute != null)
                {
                    stringBuilder.Append(INILoader.COMMENT_SYMBOL1).Append(' ')
                        .Append(descriptionAttribute.Description.Replace("\r\n", $"\n{INILoader.COMMENT_SYMBOL1} "))
                        .Append('\n');
                }

                object valueObject = iterProperty.GetValue(this);
                string value = valueObject == null ? string.Empty : valueObject.ToString();
                if (string.IsNullOrEmpty(value))
                {
                    stringBuilder.Append(INILoader.COMMENT_SYMBOL1).Append(' ');
                }
                stringBuilder.Append(iterProperty.Name).Append('=').Append(value).Append('\n');
            }

            File.WriteAllText(path, stringBuilder.ToString());
        }

        public void ReasetToDefault()
        {
            PropertyInfo[] properties = GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
            for (int iProperty = 0; iProperty < properties.Length; iProperty++)
            {
                PropertyInfo iterProperty = properties[iProperty];
                DefaultValueAttribute defaultValueAttribute = iterProperty.GetCustomAttribute<DefaultValueAttribute>();
                if (defaultValueAttribute != null)
                {
                    iterProperty.SetValue(this, defaultValueAttribute.Value);
                }
            }
        }

        private void LoadFromINILoader(INILoader ini)
        {
            PropertyInfo[] properties = GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
            for (int iProperty = 0; iProperty < properties.Length; iProperty++)
            {
                PropertyInfo iterProperty = properties[iProperty];
                CategoryAttribute categoryAttribute = iterProperty.GetCustomAttribute<CategoryAttribute>();
                string key = categoryAttribute != null
                    ? ini.CombineKey(categoryAttribute.Category, iterProperty.Name)
                    : iterProperty.Name;
                if (!ini.HasKey(key))
                {
                    continue;
                }

                if (iterProperty.PropertyType == typeof(string))
                {
                    if (ini.TryGetValue(key, out string value))
                    {
                        iterProperty.SetValue(this, value);
                    }
                }
                else if (iterProperty.PropertyType == typeof(int))
                {
                    if (ini.TryGetIntValue(key, out int value))
                    {
                        iterProperty.SetValue(this, value);
                    }
                }
                else if (iterProperty.PropertyType == typeof(float))
                {
                    if (ini.TryGetFloatValue(key, out float value))
                    {
                        iterProperty.SetValue(this, value);
                    }
                }
                else if (iterProperty.PropertyType == typeof(bool))
                {
                    if (ini.TryGetBoolValue(key, out bool value))
                    {
                        iterProperty.SetValue(this, value);
                    }
                }
                else if (iterProperty.PropertyType.IsEnum)
                {
                    if (ini.TryGetEnumValue(key, iterProperty.PropertyType, out object value))
                    {
                        iterProperty.SetValue(this, value);
                    }
                }
            }
        }
    }
}
