using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace FDTDWPF.Models
{
    class Grid
    {
        public double[,,] Ex;
        public double[,,] Ey;
        public double[,,] Ez;
        public double[,,] Hz;
        public double[,,] Hy;
        public double[,,] Hx;
        private int x, y, z;
        public Grid(int x, int y, int z)
        {
            Hx = new double[x, y - 1, z - 1];
            Hy = new double[x - 1, y, z - 1];
            Hz = new double[x - 1, y - 1, z];
            Ex = new double[x - 1, y, z];
            Ey = new double[x, y - 1, z];
            Ez = new double[x, y, z - 1];
        }
        public void UpdateH()
        {

        }
        public void UpdateE()
        {
            // Update Ex
            for (int i = 0; i < x - 1; ++i)
            {
                for (int j = 1; j < y - 1; ++j)
                {
                    for (int k = 1; k < z - 1; ++k)
                    {
                        Ex[i, j, k] = Cexe[i, j, k] * Ex[i, j, k] + Cexh[i, j, k] * ((Hz[i, j, k] - Hz[i, j - 1, k]) - (Hy[i, j, k] - Hy[i, j, k - 1]));
                    }
                }
            }
            //Update Ey
            for (int i = 1; i < x - 1, ++i)
            {
                for (int j = 0; j < y - 1; ++j)
                {
                    for (int k = 1; k < z - 1; ++k)
                    {
                        Ey[i, j, k] = Ceye[i, j, k] * Ey[i, j, k] + Ceyh[i, j, k] * ((Hx[i, j, k] - Hx[i, j, k - 1]) - (Hz[i, j, k] - Hz[i - 1, j, k]));
                    }
                }
            }

            //Update Ez
            for (int i = 1; i < x - 1; ++i)
            {
                for (int j = 1; j < y - 1; ++j)
                {
                    for (int k = 0; k < z - 1; ++k)
                    {
                        Ez[i, j, k] = Ceze[i, j, k] * Ez[i, j, k] + Cezh[i, j, k] * ((Hy[i, j, k] - Hy[i - 1, j, k]) - (Hx[i, j, k] - Hx[i, j - 1, k]));
                    }
                }
            }
        }
    }
}
