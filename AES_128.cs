using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;
using System.Security.Cryptography;

namespace Encrypt_AES
{
    public class AES_128
    {
        //число столбцов (32-битных слов), составляющих State. Для AES Nb = 4
        static int Nb = 4;
        // число 32-битных слов, составляющих шифроключ
        static int Nk;
        // число раундов
        static int Nr;
        // массив ключей
        private static byte[,] w;
        // нелинейная таблица замен,
        // использующаяся в нескольких трансформациях замены байтов и в процедуре Key Expansion для взаимнооднозначной замены значения байта.
        public static int[] Sbox = {
        0x63, 0x7c, 0x77, 0x7b, 0xf2, 0x6b, 0x6f, 0xc5, 0x30, 0x01, 0x67, 0x2b, 0xfe, 0xd7, 0xab, 0x76,
        0xca, 0x82, 0xc9, 0x7d, 0xfa, 0x59, 0x47, 0xf0, 0xad, 0xd4, 0xa2, 0xaf, 0x9c, 0xa4, 0x72, 0xc0,
        0xb7, 0xfd, 0x93, 0x26, 0x36, 0x3f, 0xf7, 0xcc, 0x34, 0xa5, 0xe5, 0xf1, 0x71, 0xd8, 0x31, 0x15,
        0x04, 0xc7, 0x23, 0xc3, 0x18, 0x96, 0x05, 0x9a, 0x07, 0x12, 0x80, 0xe2, 0xeb, 0x27, 0xb2, 0x75,
        0x09, 0x83, 0x2c, 0x1a, 0x1b, 0x6e, 0x5a, 0xa0, 0x52, 0x3b, 0xd6, 0xb3, 0x29, 0xe3, 0x2f, 0x84,
        0x53, 0xd1, 0x00, 0xed, 0x20, 0xfc, 0xb1, 0x5b, 0x6a, 0xcb, 0xbe, 0x39, 0x4a, 0x4c, 0x58, 0xcf,
        0xd0, 0xef, 0xaa, 0xfb, 0x43, 0x4d, 0x33, 0x85, 0x45, 0xf9, 0x02, 0x7f, 0x50, 0x3c, 0x9f, 0xa8,
        0x51, 0xa3, 0x40, 0x8f, 0x92, 0x9d, 0x38, 0xf5, 0xbc, 0xb6, 0xda, 0x21, 0x10, 0xff, 0xf3, 0xd2,
        0xcd, 0x0c, 0x13, 0xec, 0x5f, 0x97, 0x44, 0x17, 0xc4, 0xa7, 0x7e, 0x3d, 0x64, 0x5d, 0x19, 0x73,
        0x60, 0x81, 0x4f, 0xdc, 0x22, 0x2a, 0x90, 0x88, 0x46, 0xee, 0xb8, 0x14, 0xde, 0x5e, 0x0b, 0xdb,
        0xe0, 0x32, 0x3a, 0x0a, 0x49, 0x06, 0x24, 0x5c, 0xc2, 0xd3, 0xac, 0x62, 0x91, 0x95, 0xe4, 0x79,
        0xe7, 0xc8, 0x37, 0x6d, 0x8d, 0xd5, 0x4e, 0xa9, 0x6c, 0x56, 0xf4, 0xea, 0x65, 0x7a, 0xae, 0x08,
        0xba, 0x78, 0x25, 0x2e, 0x1c, 0xa6, 0xb4, 0xc6, 0xe8, 0xdd, 0x74, 0x1f, 0x4b, 0xbd, 0x8b, 0x8a,
        0x70, 0x3e, 0xb5, 0x66, 0x48, 0x03, 0xf6, 0x0e, 0x61, 0x35, 0x57, 0xb9, 0x86, 0xc1, 0x1d, 0x9e,
        0xe1, 0xf8, 0x98, 0x11, 0x69, 0xd9, 0x8e, 0x94, 0x9b, 0x1e, 0x87, 0xe9, 0xce, 0x55, 0x28, 0xdf,
        0x8c, 0xa1, 0x89, 0x0d, 0xbf, 0xe6, 0x42, 0x68, 0x41, 0x99, 0x2d, 0x0f, 0xb0, 0x54, 0xbb, 0x16
        };
        // обратная таблица для Sbox
        private static int[] Inv_Sbox = {
        0x52, 0x09, 0x6a, 0xd5, 0x30, 0x36, 0xa5, 0x38, 0xbf, 0x40, 0xa3, 0x9e, 0x81, 0xf3, 0xd7, 0xfb,
        0x7c, 0xe3, 0x39, 0x82, 0x9b, 0x2f, 0xff, 0x87, 0x34, 0x8e, 0x43, 0x44, 0xc4, 0xde, 0xe9, 0xcb,
        0x54, 0x7b, 0x94, 0x32, 0xa6, 0xc2, 0x23, 0x3d, 0xee, 0x4c, 0x95, 0x0b, 0x42, 0xfa, 0xc3, 0x4e,
        0x08, 0x2e, 0xa1, 0x66, 0x28, 0xd9, 0x24, 0xb2, 0x76, 0x5b, 0xa2, 0x49, 0x6d, 0x8b, 0xd1, 0x25,
        0x72, 0xf8, 0xf6, 0x64, 0x86, 0x68, 0x98, 0x16, 0xd4, 0xa4, 0x5c, 0xcc, 0x5d, 0x65, 0xb6, 0x92,
        0x6c, 0x70, 0x48, 0x50, 0xfd, 0xed, 0xb9, 0xda, 0x5e, 0x15, 0x46, 0x57, 0xa7, 0x8d, 0x9d, 0x84,
        0x90, 0xd8, 0xab, 0x00, 0x8c, 0xbc, 0xd3, 0x0a, 0xf7, 0xe4, 0x58, 0x05, 0xb8, 0xb3, 0x45, 0x06,
        0xd0, 0x2c, 0x1e, 0x8f, 0xca, 0x3f, 0x0f, 0x02, 0xc1, 0xaf, 0xbd, 0x03, 0x01, 0x13, 0x8a, 0x6b,
        0x3a, 0x91, 0x11, 0x41, 0x4f, 0x67, 0xdc, 0xea, 0x97, 0xf2, 0xcf, 0xce, 0xf0, 0xb4, 0xe6, 0x73,
        0x96, 0xac, 0x74, 0x22, 0xe7, 0xad, 0x35, 0x85, 0xe2, 0xf9, 0x37, 0xe8, 0x1c, 0x75, 0xdf, 0x6e,
        0x47, 0xf1, 0x1a, 0x71, 0x1d, 0x29, 0xc5, 0x89, 0x6f, 0xb7, 0x62, 0x0e, 0xaa, 0x18, 0xbe, 0x1b,
        0xfc, 0x56, 0x3e, 0x4b, 0xc6, 0xd2, 0x79, 0x20, 0x9a, 0xdb, 0xc0, 0xfe, 0x78, 0xcd, 0x5a, 0xf4,
        0x1f, 0xdd, 0xa8, 0x33, 0x88, 0x07, 0xc7, 0x31, 0xb1, 0x12, 0x10, 0x59, 0x27, 0x80, 0xec, 0x5f,
        0x60, 0x51, 0x7f, 0xa9, 0x19, 0xb5, 0x4a, 0x0d, 0x2d, 0xe5, 0x7a, 0x9f, 0x93, 0xc9, 0x9c, 0xef,
        0xa0, 0xe0, 0x3b, 0x4d, 0xae, 0x2a, 0xf5, 0xb0, 0xc8, 0xeb, 0xbb, 0x3c, 0x83, 0x53, 0x99, 0x61,
        0x17, 0x2b, 0x04, 0x7e, 0xba, 0x77, 0xd6, 0x26, 0xe1, 0x69, 0x14, 0x63, 0x55, 0x21, 0x0c, 0x7d
        };
        // массив, который состоит из битов 32-разрядного слова и является постоянным для данного раунда. 
        private static int[,] Rcon = {
        {0x00, 0x00, 0x00, 0x00},
        {0x01, 0x00, 0x00, 0x00},
        {0x02, 0x00, 0x00, 0x00},
        {0x04, 0x00, 0x00, 0x00},
        {0x08, 0x00, 0x00, 0x00},
        {0x10, 0x00, 0x00, 0x00},
        {0x20, 0x00, 0x00, 0x00},
        {0x40, 0x00, 0x00, 0x00},
        {0x80, 0x00, 0x00, 0x00},
        {0x1b, 0x00, 0x00, 0x00},
        {0x36, 0x00, 0x00, 0x00}
        };
        // доп xor для слова целиком
        private static byte[] xor_word(byte[] x, byte[] y)
        {
            byte[] res = new byte[4];
            for (int i = 0; i < 4; i++)
            {
                res[i] = (byte)(x[i] ^ y[i]);
            }
            return res;
        }
        // трансформация при шифровании и обратном шифровании, при которой Round Key XOR’ится c State
        private static byte[,] AddRoundKey(byte[,] state, byte[,] w, int round_count)
        {
            byte[,] tmp = new byte[4, 4];
            for (int i = 0; i < Nb; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    tmp[j, i] = (byte)(state[j, i] ^ w[round_count * Nb + i, j]);
                }
            }
            return tmp;
        }
        // смешение столбцов
        private static byte[,] MixColumns(byte[,] state)
        {
            byte[,] res = new byte[4, 4];
            for (int i = 0; i < 4; i++)
            {
                res[0, i] = (byte)(Hex_mul(0x02, state[0, i]) ^ Hex_mul(0x03, state[1, i]) ^ state[2, i] ^ state[3, i]);
                res[1, i] = (byte)(state[0, i] ^ Hex_mul(0x02, state[1, i]) ^ Hex_mul(0x03, state[2, i]) ^ state[3, i]);
                res[2, i] = (byte)(state[0, i] ^ state[1, i] ^ Hex_mul(0x02, state[2, i]) ^ Hex_mul(0x03, state[3, i]));
                res[3, i] = (byte)(Hex_mul(0x03, state[0, i]) ^ state[1, i] ^ state[2, i] ^ Hex_mul(0x02, state[3, i]));
            }
            return res;
        }
        // обратная процедура для MixColumns при дешифровании
        private static byte[,] InvMixColumns(byte[,] state)
        {
            byte[,] res = new byte[4, 4];
            for (int i = 0; i < 4; i++)
            {
                res[0, i] = (byte)(Hex_mul(0x0e, state[0, i]) ^ Hex_mul(0x0b, state[1, i]) ^ Hex_mul(0x0d, state[2, i]) ^ Hex_mul(0x09, state[3, i]));
                res[1, i] = (byte)(Hex_mul(0x09, state[0, i]) ^ Hex_mul(0x0e, state[1, i]) ^ Hex_mul(0x0b, state[2, i]) ^ Hex_mul(0x0d, state[3, i]));
                res[2, i] = (byte)(Hex_mul(0x0d, state[0, i]) ^ Hex_mul(0x09, state[1, i]) ^ Hex_mul(0x0e, state[2, i]) ^ Hex_mul(0x0b, state[3, i]));
                res[3, i] = (byte)(Hex_mul(0x0b, state[0, i]) ^ Hex_mul(0x0d, state[1, i]) ^ Hex_mul(0x09, state[2, i]) ^ Hex_mul(0x0e, state[3, i]));
            }
            return res;
        }
        // смешение строк
        private static byte[,] ShiftRows(byte[,] state)
        {
            byte[,] res = new byte[4, 4];
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    res[i, j] = state[i, (j + i) % 4];
                }
            }
            return res;
        }
        // обратное смещение рядов
        private static byte[,] InvShiftRows(byte[,] state)
        {
            byte[,] res = new byte[4, 4];
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    res[i, (j + i) % 4] = state[i, j];
                }
            }
            return res;
        }
        // обработка умножения через полином 3 степени
        private static byte Hex_mul(byte x, byte y)
        {
            byte res = 0, t;
            byte x1 = x, y1 = y;
            while (x1 != 0)
            {
                if ((x1 & 1) != 0)
                    res = (byte)(res ^ y1);
                t = (byte)(y1 & 0x80);
                y1 = (byte)(y1 << 1);
                if (t != 0)
                    y1 = (byte)(y1 ^ 0x1b);
                x1 = (byte)((x1 & 0xff) >> 1);
            }
            return res;
        }
        // замена битов через Sbox
        public static byte[,] SubBytes(byte[,] state)
        {
            byte[,] res = new byte[4, 4];
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    res[i, j] = (byte)(Sbox[(state[i, j] & 0xff)] & 0xff);
                }
            }
            return res;
        }
        // обратная функция для SubBytes
        private static byte[,] InvSubBytes(byte[,] state)
        {
            byte[,] res = new byte[4, 4];
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    res[i, j] = (byte)(Inv_Sbox[(state[i, j] & 0xff)] & 0xff);
                }
            }
            return res;
        }
        // замена через Sbox для слвоа
        private static byte[] SubWord(byte[] x)
        {
            byte[] res = new byte[4];
            for (int i = 0; i < 4; i++)
            {
                res[i] = (byte)(Sbox[(x[i] & 0xff)] % 0xff);
            }
            return res;
        }
        // цинлическая перестановка
        private static byte[] RotWord(byte[] x)
        {
            byte[] res = new byte[4];
            res[0] = x[1];
            res[1] = x[2];
            res[2] = x[3];
            res[3] = x[0];
            return res;
        }
        // шифрование одного блока
        private static byte[] encryptBloc(byte[] bloc)
        {
            byte[] result = new byte[16];
            byte[,] state = new byte[4, 4];
            for (int i = 0; i < 16; i++)
            {
                state[i / 4, i % 4] = bloc[i % 4 * 4 + i / 4];
            }

            state = AddRoundKey(state, w, 0);
            for (int i = 1; i < Nr; i++)
            {
                state = SubBytes(state);
                state = ShiftRows(state);
                state = MixColumns(state);
                state = AddRoundKey(state, w, i);
            }

            state = SubBytes(state);
            state = ShiftRows(state);
            state = AddRoundKey(state, w, Nr);

            for (int i = 0; i < 16; i++)
            {
                result[i % 4 * 4 + i / 4] = state[i / 4, i % 4];
            }

            return result;
        }
        // основная функция шифрования
        public static byte[] encrypt(byte[] info, byte[] chiperkey)
        {
            Nb = 4;
            Nk = 4;
            Nr = 10;

            int i;
            int length;
            byte[] chipertext = info.Concat(generate_sign()).ToArray();
            if (chipertext.Length % 16 != 0)
            {
                length = 16 - chipertext.Length % 16;
            }
            else
            {
                length = 0;
            }

            // paddig дополнительные 0 байты, чтобы поделить данные без отстатка
            byte[] padding = new byte[length];
            for (int j = 0; j < length; j++)
            {
                padding[j] = 0;
            }
            byte[] tmp = chipertext.Concat(padding).ToArray();
            byte[] result = new byte[tmp.Length];
            int bloc_num = tmp.Length / 16;
            // генерация раундовых ключей
            w = KeyExpansion(chiperkey);
            // нарезаем данные на блоки, шифруем каждый и собираем в результирующий набор
            for (i = 0; i < bloc_num; i++)
            {
                byte[] bloc = new byte[16];
                Array.Copy(tmp, i * 16, bloc, 0, 16);
                bloc = encryptBloc(bloc);
                Array.Copy(bloc, 0, result, i * 16, 16);
            }

            return result;
        }
        // расшифрование блока
        private static byte[] decryptBloc(byte[] bloc)
        {
            byte[] result = new byte[16];
            byte[,] state = new byte[4, 4];
            for (int i = 0; i < 16; i++)
            {
                state[i / 4, i % 4] = bloc[i % 4 * 4 + i / 4];
            }

            state = AddRoundKey(state, w, Nr);
            for (int i = Nr - 1; i > 0; i--)
            {
                state = InvShiftRows(state);
                state = InvSubBytes(state);
                state = AddRoundKey(state, w, i);
                state = InvMixColumns(state);
            }

            state = InvShiftRows(state);
            state = InvSubBytes(state);
            state = AddRoundKey(state, w, 0);

            for (int i = 0; i < 16; i++)
            {
                result[i % 4 * 4 + i / 4] = state[i / 4, i % 4];
            }

            return result;
        }
        // расшифрование
        public static byte[] decrypt(byte[] chipertext, byte[] chiperkey)
        {
            Nb = 4;
            Nk = 4;
            Nr = 10;

            byte[] result = new byte[chipertext.Length];
            int bloc_num = chipertext.Length / 16;
            // генерация раундовых ключей
            w = KeyExpansion(chiperkey);
            // нарезаем данные на блоки, шифруем каждый и собираем в результирующий набор
            for (int i = 0; i < bloc_num; i++)
            {
                byte[] bloc = new byte[16];
                Array.Copy(chipertext, i * 16, bloc, 0, 16);
                bloc = decryptBloc(bloc);
                Array.Copy(bloc, 0, result, i * 16, 16);
            }

            return cleanup(result);
        }
        // удалить пустые байты, которыми мы дополняли блину
        private static byte[] cleanup(byte[] info)
        {

            int length = info.Length;
            int i = 1;
            while (i <= length && info[length - i] == 0)
            {
                i++;
            }
            length = length - i + 1;
            byte[] result = new byte[length];
            Array.Copy(info, 0, result, 0, length);
            return result;
        }
        // генерация раундовых ключей
        private static byte[,] KeyExpansion(byte[] chiperkey)
        {
            byte[,] res = new byte[Nb * (Nr + 1), 4];
            int i = 0;
            while (i < Nk)
            {
                res[i, 0] = chiperkey[i * 4];
                res[i, 1] = chiperkey[i * 4 + 1];
                res[i, 2] = chiperkey[i * 4 + 2];
                res[i, 3] = chiperkey[i * 4 + 3];
                i++;
            }

            while (i < Nb * (Nr + 1))
            {
                byte[] tmp = new byte[4];
                for (int j = 0; j < 4; j++)
                {
                    tmp[j] = res[i - 1, j];
                }
                if (i % Nk == 0)
                {
                    tmp = SubWord(RotWord(tmp));
                    for (int j = 0; j < 4; j++)
                    {
                        tmp[j] = (byte)(tmp[j] ^ Rcon[i / Nk, j]);
                    }
                }
                else if (Nk > 6 && i % Nk == 4)
                {
                    tmp = SubWord(tmp);
                }
                byte[] tmp2 = new byte[4] { res[i - Nk, 0], res[i - Nk, 1], res[i - Nk, 2], res[i - Nk, 3] };
                tmp = xor_word(tmp, tmp2);
                res[i, 0] = tmp[0];
                res[i, 1] = tmp[1];
                res[i, 2] = tmp[2];
                res[i, 3] = tmp[3];
                i++;
            }
            return res;
        }
        // подпись
        private static byte[] generate_sign() {
            var md5 = MD5.Create();
            byte[] result = md5.ComputeHash(Encoding.Default.GetBytes(Environment.OSVersion + Environment.UserName));
            return result;
        }
        // проверка наличия
        public static bool check_sign(byte[] info) {
            byte[] tmp = new byte[16];
            Array.Copy(info, info.Length - 16, tmp, 0, 16);
            bool res = Encoding.Default.GetString(tmp) == Encoding.Default.GetString(generate_sign());
            return res;
        }

        public static byte[] del_sign(byte[] info) {
            byte[] result;
            if (check_sign(info))
            {
                result = new byte[info.Length - 16];
                Array.Copy(info, 0, result, 0, info.Length - 16);
            }
            else {
                result = info;
            }
            return result;
        }
    }
}
