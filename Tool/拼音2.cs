using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.International.Converters.PinYinConverter;

namespace Tool
{
    public class 拼音2
    {
        public static string getFirstPinYin(string chr)
        {
            try
            {
                if (chr.Length != 0)
                {
                    StringBuilder fullSpell = new StringBuilder();
                    for (int i = 0; i < chr.Length; i++)
                    {
                        bool isChineses = ChineseChar.IsValidChar(chr[i]);
                        if (isChineses)
                        {
                            ChineseChar chineseChar = new ChineseChar(chr[i]);
                            foreach (string value in chineseChar.Pinyins)
                            {
                                if (!string.IsNullOrEmpty(value))
                                {
                                    //fullSpell.Append(value.Remove(value.Length - 1, 1));
                                    fullSpell.Append(value.Substring(0, 1));
                                    break;
                                }
                            }
                        }
                        else
                        {
                            fullSpell.Append(chr[i]);
                        }
                    }

                    return fullSpell.ToString().ToUpper();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("全拼转化出错！" + e.Message);
            }

            return string.Empty;
        }
    }
}
