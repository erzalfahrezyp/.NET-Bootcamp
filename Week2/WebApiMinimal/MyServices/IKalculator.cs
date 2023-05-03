using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyServices
{
    public interface IKalculator
    {
        int Tambah(int bil1, int bil2);
        int Kurang(int bil1, int bil2);
        int Kali(int bil1, int bil2);
        float Bagi(int bil1, int bil2);
    }
}
