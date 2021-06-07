using System;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;


namespace ConsoleView
{
    public class ConsoleOutput
    {
        private static CharInfo[,] _buf;
        private static SmallRect _rect;
        private static short _width, _height;
        private static SafeFileHandle _h;

        [DllImport("Kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static extern SafeFileHandle CreateFile(
           string fileName,
           [MarshalAs(UnmanagedType.U4)] uint fileAccess,
           [MarshalAs(UnmanagedType.U4)] uint fileShare,
           IntPtr securityAttributes,
           [MarshalAs(UnmanagedType.U4)] FileMode creationDisposition,
           [MarshalAs(UnmanagedType.U4)] int flags,
           IntPtr template);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool WriteConsoleOutput(
          SafeFileHandle hConsoleOutput,
          CharInfo[] lpBuffer,
          Coord dwBufferSize,
          Coord dwBufferCoord,
          ref SmallRect lpWriteRegion);

        [StructLayout(LayoutKind.Sequential)]
        public struct Coord
        {
            public short X;
            public short Y;

            public Coord(short X, short Y)
            {
                this.X = X;
                this.Y = Y;
            }
        };

        [StructLayout(LayoutKind.Explicit)]
        public struct CharUnion
        {
            [FieldOffset(0)] public char UnicodeChar;
            [FieldOffset(0)] public byte AsciiChar;
        }

        [StructLayout(LayoutKind.Explicit)]
        public struct CharInfo
        {
            [FieldOffset(0)] public CharUnion Char;
            [FieldOffset(2)] public short Attributes;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct SmallRect
        {
            public short Left;
            public short Top;
            public short Right;
            public short Bottom;
        }

        /// <summary>
        /// Создание объекта
        /// </summary>
        static ConsoleOutput()
        {
            _h = CreateFile("CONOUT$", 0x40000000, 2, IntPtr.Zero, FileMode.Open, 0, IntPtr.Zero);

            _width = (short)System.Console.WindowWidth;
            _height = (short)System.Console.WindowHeight;

            if (!_h.IsInvalid)
            {
                _buf = new CharInfo[_height, _width];
                _rect = new SmallRect() { Left = 0, Top = 0, Right = _width, Bottom = _height };
            }
        }

        /// <summary>
        /// Записать строку для вывода в буфер
        /// </summary>
        /// <param name="parS">Строка</param>
        /// <param name="parX">Координата X</param>
        /// <param name="parY">Координата Y</param>
        /// <param name="parColor">Цвет вывода</param>
        public static void Write(string parS, int parX, int parY, ConsoleColor parColor)
        {
            var bytes = System.Console.OutputEncoding.GetBytes(parS);
            int offset = 0;
            byte previousByte = 0;
            foreach (var item in bytes)
            {
                if (parX + offset >= _width - 1 || item == 10 && previousByte == 13)
                {
                    parY++;
                    offset = 0;
                }
                if (item < 20)
                {
                    previousByte = item;
                    continue;
                }
                _buf[parY, parX + offset].Attributes = (byte)parColor;
                _buf[parY, parX + offset++].Char.AsciiChar = item;
                previousByte = item;
            }
        }
        /// <summary>
        /// Очистить буфер
        /// </summary>
        public static void Clear()
        {
            _buf = new CharInfo[_height, _width];
        }

        /// <summary>
        /// Вывод буфера на консоль
        /// </summary>
        public static void PrintOnConsole()
        {
            WriteConsoleOutput(_h, _buf.Cast<CharInfo>().ToArray(),
                  new Coord() { X = _width, Y = _height },
                  new Coord() { X = 0, Y = 0 },
                  ref _rect);
        }
    }
}
