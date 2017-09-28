using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtendedString
{
    /// <summary>
    /// a extended class must be modified by static, also the method
    /// the first parameter must the object that needs to be modified, type "this" in front of it
    /// using the extended class in code before using it's head name.
    /// </summary>
    public static class StringHelper
    {


        /// <summary>
        /// Appends the string str onto the end of this string.
        /// </summary>
        /// <param name="_input"></param>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string Append(this string _input,string str)
        {
            return _input += str;
        }
        /// <summary>
        /// Appends the char ch onto the end of this string.
        /// </summary>
        /// <param name="_input"></param>
        /// <param name="ch"></param>
        /// <returns></returns>
        public static string Append(this string _input,char ch)
        {
            return _input += ch;
        }

        /// <summary>
        /// returns a string of size width that contains this string padded by the fill character.
        /// it will return null if the width is less than the length of the string.
        /// </summary>
        /// <param name="_input"></param>
        /// <param name="width"></param>
        /// <param name="fill"></param>
        /// <returns></returns>
        public static string LeftJustified(this string _input,int width,char fill)
        {
            if (_input.Length > width)
                return null;
            while (_input.Length < width)
                _input += fill;
            return _input;
        }
        /// <summary>
        /// return byte array of the string
        /// </summary>
        /// <param name="_input"></param>
        /// <returns></returns>
        public static byte[] ToAsciiArray(this string _input)
        {
            return System.Text.Encoding.ASCII.GetBytes(_input);
        }
        /// <summary>
        /// returns hex array of the string
        /// </summary>
        /// <param name="_input"></param>
        /// <returns></returns>
        public static byte[] ToHexArray(this string _input)
        {
            if (_input == null)
                return null;
            byte[] ByteArray = System.Text.Encoding.ASCII.GetBytes(_input.ToLower());
            for (int i=0;i<ByteArray.Count();i++)
            {
                if (ByteArray[i] <= 0x39)
                    ByteArray[i] -= 0x30;
                else
                    ByteArray[i] -= 0x57;
            }
            return ByteArray;
        }
    }
}
