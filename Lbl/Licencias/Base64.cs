using System;

namespace Lbl.Licencias
{

    public class Base64
    {
        private static readonly char[] A_Renamed = ("ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/").ToCharArray();
        private static readonly int[] B = new int['?'];

        static Base64()
        {
            Arrays.Fill(B, -1);
            int i = 0;
            int j = A_Renamed.Length;
            while (i < j)
            {
                B[A_Renamed[i]] = i;
                i++;
            }
            B[61] = 0;
        }

        public static char[] encodeToChar(byte[] paramArrayOfByte, bool paramBoolean)
        {
            int i = paramArrayOfByte != null ? paramArrayOfByte.Length : 0;
            if (i == 0)
            {
                return new char[0];
            }
            int j = i / 3 * 3;
            int k = (i - 1) / 3 + 1 << 2;
            int m = k + (paramBoolean ? (k - 1) / 76 << 1 : 0);
            char[] arrayOfChar = new char[m];
            int n = 0;
            int i1 = 0;
            int i2 = 0;
            while (n < j)
            {
                int i3 = A(paramArrayOfByte[(n++)]) << 16 | A(paramArrayOfByte[(n++)]) << 8 | A(paramArrayOfByte[(n++)]);
                arrayOfChar[(i1++)] = A_Renamed[((int)((uint)i3 >> 18) & 0x3F)];
                arrayOfChar[(i1++)] = A_Renamed[((int)((uint)i3 >> 12) & 0x3F)];
                arrayOfChar[(i1++)] = A_Renamed[((int)((uint)i3 >> 6) & 0x3F)];
                arrayOfChar[(i1++)] = A_Renamed[(i3 & 0x3F)];
                if (paramBoolean)
                {
                    i2++;
                    if ((i2 == 19) && (i1 < m - 2))
                    {
                        arrayOfChar[(i1++)] = '\r';
                        arrayOfChar[(i1++)] = '\n';
                        i2 = 0;
                    }
                }
            }
            n = i - j;
            if (n > 0)
            {
                i1 = A(paramArrayOfByte[j]) << 10 | (n == 2 ? A(paramArrayOfByte[(i - 1)]) << 2 : 0);
                arrayOfChar[(m - 4)] = A_Renamed[(i1 >> 12)];
                arrayOfChar[(m - 3)] = A_Renamed[((int)((uint)i1 >> 6) & 0x3F)];
                arrayOfChar[(m - 2)] = (n == 2 ? A_Renamed[(i1 & 0x3F)] : '=');
                arrayOfChar[(m - 1)] = '=';
            }
            return arrayOfChar;
        }

        //public static byte[] decode(char[] paramArrayOfChar)
        //{
        //    int i = paramArrayOfChar != null ? paramArrayOfChar.Length : 0;
        //    if (i == 0)
        //    {
        //        return new byte[0];
        //    }
        //    int j = 0, k = 0;
        //    for (; k < i; k++)
        //    {
        //        if (B[paramArrayOfChar[k]] < 0)
        //        {
        //            j++;
        //        }
        //    }
        //    if ((i - j) % 4 != 0)
        //    {
        //        return null;
        //    }
        //    k = paramArrayOfChar[(i - 1)] == '=' ? 1 : paramArrayOfChar[(i - 2)] == '=' ? 2 : 0;
        //    int m = ((i - j) * 6 >> 3) - k;
        //    byte[] arrayOfByte = new byte[m];
        //    int n = 0;
        //    int i1 = 0;
        //    while (i1 < m)
        //    {
        //        int i2 = 0;
        //        for (int i3 = 0; i3 < 4; i3++)
        //        {
        //            int i4 = B[paramArrayOfChar[(n++)]];
        //            if (i4 >= 0)
        //            {
        //                i2 |= i4 << 18 - i3 * 6;
        //            }
        //            else
        //            {
        //                i3--;
        //            }
        //        }
        //        arrayOfByte[(i1++)] = ((byte)(i2 >> 16));
        //        if (i1 < m)
        //        {
        //            arrayOfByte[(i1++)] = ((byte)(i2 >> 8));
        //            if (i1 < m)
        //            {
        //                arrayOfByte[(i1++)] = ((byte)i2);
        //            }
        //        }
        //    }
        //    return arrayOfByte;
        //}

        public static byte[] encodeToByte(byte[] paramArrayOfByte, bool paramBoolean)
        {
            int i = paramArrayOfByte != null ? paramArrayOfByte.Length : 0;
            if (i == 0)
            {
                return new byte[0];
            }
            int j = i / 3 * 3;
            int k = (i - 1) / 3 + 1 << 2;
            int m = k + (paramBoolean ? (k - 1) / 76 << 1 : 0);
            byte[] arrayOfByte = new byte[m];
            int n = 0;
            int i1 = 0;
            int i2 = 0;
            while (n < j)
            {
                int i3 = A(paramArrayOfByte[(n++)]) << 16 | A(paramArrayOfByte[(n++)]) << 8 | A(paramArrayOfByte[(n++)]);
                arrayOfByte[(i1++)] = ((byte)A_Renamed[((int)((uint)i3 >> 18) & 0x3F)]);
                arrayOfByte[(i1++)] = ((byte)A_Renamed[((int)((uint)i3 >> 12) & 0x3F)]);
                arrayOfByte[(i1++)] = ((byte)A_Renamed[((int)((uint)i3 >> 6) & 0x3F)]);
                arrayOfByte[(i1++)] = ((byte)A_Renamed[(i3 & 0x3F)]);
                if (paramBoolean)
                {
                    i2++;
                    if ((i2 == 19) && (i1 < m - 2))
                    {
                        arrayOfByte[(i1++)] = 13;
                        arrayOfByte[(i1++)] = 10;
                        i2 = 0;
                    }
                }
            }
            n = i - j;
            if (n > 0)
            {
                i1 = A(paramArrayOfByte[j]) << 10 | (n == 2 ? A(paramArrayOfByte[(i - 1)]) << 2 : 0);
                arrayOfByte[(m - 4)] = ((byte)A_Renamed[(i1 >> 12)]);
                arrayOfByte[(m - 3)] = ((byte)A_Renamed[((int)((uint)i1 >> 6) & 0x3F)]);
                if (n == 2)
                    arrayOfByte[(m - 2)] = (byte)A_Renamed[(i1 & 0x3F)];
                else
                    arrayOfByte[(m - 2)] = 61;
                arrayOfByte[(m - 1)] = 61;
            }
            return arrayOfByte;
        }

        public static byte[] decode(byte[] paramArrayOfByte)
        {
            int i = paramArrayOfByte != null ? paramArrayOfByte.Length : 0;
            if (i == 0)
            {
                return new byte[0];
            }
            int j = 0, m = 0,k = 0;
            for (; k < i; k++)
            {
                m = paramArrayOfByte[k];
                if ((m < 0) || (B[m] < 0))
                {
                    j++;
                }
            }
            if ((i - j) % 4 != 0)
            {
                return null;
            }
            k = paramArrayOfByte[(i - 1)] == 61 ? 1 : paramArrayOfByte[(i - 2)] == 61 ? 2 : 0;
            m = ((i - j) * 6 >> 3) - k;
            byte[] arrayOfByte = new byte[m];
            int n = 0;
            int i1 = 0;
            while (i1 < m)
            {
                int i2 = 0;
                for (int i3 = 0; i3 < 4; i3++)
                {
                    int i4 = B[paramArrayOfByte[(n++)]];
                    if (i4 >= 0)
                    {
                        i2 |= i4 << 18 - i3 * 6;
                    }
                    else
                    {
                        i3--;
                    }
                }
                arrayOfByte[(i1++)] = ((byte)(i2 >> 16));
                if (i1 < m)
                {
                    arrayOfByte[(i1++)] = ((byte)(i2 >> 8));
                    if (i1 < m)
                    {
                        arrayOfByte[(i1++)] = ((byte)i2);
                    }
                }
            }
            return arrayOfByte;
        }

        public static string encodeToString(byte[] paramArrayOfByte, bool paramBoolean)
        {
            return new string(encodeToChar(paramArrayOfByte, paramBoolean));
        }

        public static byte[] decode(string paramString)
        {
            int i = !string.ReferenceEquals(paramString, null) ? paramString.Length : 0;
            if (i == 0)
            {
                return new byte[0];
            }
            int j = 0, k = 0;
            for (; k < i; k++)
            {
                if (B[paramString[k]] < 0)
                {
                    j++;
                }
            }
            if ((i - j) % 4 != 0)
            {
                return null;
            }
            k = paramString[i - 1] == '=' ? 1 : paramString[i - 2] == '=' ? 2 : 0;
            int m = ((i - j) * 6 >> 3) - k;
            byte[] arrayOfByte = new byte[m];
            int n = 0;
            int i1 = 0;
            while (i1 < m)
            {
                int i2 = 0;
                for (int i3 = 0; i3 < 4; i3++)
                {
                    int i4 = B[paramString[n++]];
                    if (i4 >= 0)
                    {
                        i2 |= i4 << 18 - i3 * 6;
                    }
                    else
                    {
                        i3--;
                    }
                }
                arrayOfByte[(i1++)] = ((byte)(i2 >> 16));
                if (i1 < m)
                {
                    arrayOfByte[(i1++)] = ((byte)(i2 >> 8));
                    if (i1 < m)
                    {
                        arrayOfByte[(i1++)] = ((byte)i2);
                    }
                }
            }
            return arrayOfByte;
        }

        private static int A(byte paramByte)
        {
            return paramByte < 0 ? paramByte + 256 : paramByte;
        }
    }

    internal static class Arrays
    {
        internal static T[] CopyOf<T>(T[] original, int newLength)
        {
            T[] dest = new T[newLength];
            System.Array.Copy(original, dest, newLength);
            return dest;
        }

        internal static T[] CopyOfRange<T>(T[] original, int fromIndex, int toIndex)
        {
            int length = toIndex - fromIndex;
            T[] dest = new T[length];
            System.Array.Copy(original, fromIndex, dest, 0, length);
            return dest;
        }

        internal static void Fill<T>(T[] array, T value)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = value;
            }
        }

        internal static void Fill<T>(T[] array, int fromIndex, int toIndex, T value)
        {
            for (int i = fromIndex; i < toIndex; i++)
            {
                array[i] = value;
            }
        }
    }
}