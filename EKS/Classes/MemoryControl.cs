using System;
using System.Runtime.InteropServices;

namespace EKS.Classes
{
    interface IMemoryLaw
    {
        void MemoryStart();
    }

    class MemoryControl : IMemoryLaw
    {
        public MemoryControl()
        {
            Console.WriteLine("Memory Controller Constractor.");
        }

        [DllImportAttribute("kernel32.dll", EntryPoint = "SetProcessWorkingSetSize", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        private static extern int SetProcessWorkingSetSize(IntPtr process, int minumumWorkingSetSize, int maximumWorkingSetSize);
        
        public void MemoryStart()
        {
            FlushMemory();
        }
        ///<summary>
        ///Belleğin Silindiği Metot
        ///</summary>
        private static void FlushMemory()
        {
            GC.Collect();

            GC.WaitForPendingFinalizers();

            if (Environment.OSVersion.Platform == PlatformID.Win32NT)
            {
                SetProcessWorkingSetSize(System.Diagnostics.Process.GetCurrentProcess().Handle, -1, -1);
            }
        }
    }
}

