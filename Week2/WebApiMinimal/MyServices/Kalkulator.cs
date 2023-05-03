using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyServices
{
    public class Kalkulator : IKalculator
    {
        public int Tambah(int bil1, int bil2)
        {
            return bil1 + bil2;
        }

        public int Kurang(int bil1, int bil2)
        {
            return bil1 - bil2;
        }

        public int Kali(int bil1, int bil2)
        {
            return bil1 * bil2;
        }

        public float Bagi(int bil1, int bil2)
        {
            return (float)bil1 / bil2;
        }
    }
}
