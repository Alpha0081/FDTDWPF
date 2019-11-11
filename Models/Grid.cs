using System;
namespace FDTDWPF.Models
{
    /// <summary>
    /// Класс создания сетки.
    /// </summary>
    class Grid
    {
        public double[,,] Ex;
        public double[,,] Ey;
        public double[,,] Ez;
        public double[,,] Hz;
        public double[,,] Hy;
        public double[,,] Hx;
        private double[,,] Chxh;
        private double[,,] Chxe;
        private double[,,] Chyh;
        private double[,,] Chye;
        private double[,,] Chzh;
        private double[,,] Chze;
        private double[,,] Cexe;
        private double[,,] Cexh;
        private double[,,] Ceye;
        private double[,,] Ceyh;
        private double[,,] Ceze;
        private double[,,] Cezh;
        private double[,] Eyx0;
        private double[,] Ezx0;
        private double[,] Eyx1;
        private double[,] Ezx1;

        private double[,] Exy0;
        private double[,] Ezy0;
        private double[,] Exy1;
        private double[,] Ezy1;

        private double[,] Exz0;
        private double[,] Eyz0;
        private double[,] Exz1;
        private double[,] Eyz1;

        private int x, y, z;
        private double c_abc;
        public Grid(int x, int y, int z)
        {
            Hx = new double[x, y - 1, z - 1];
            Hy = new double[x - 1, y, z - 1];
            Hz = new double[x - 1, y - 1, z];
            Ex = new double[x - 1, y, z];
            Ey = new double[x, y - 1, z];
            Ez = new double[x, y, z - 1];
            Chxh = new double[x, y - 1, z - 1];
            Chxe = new double[x, y - 1, z - 1];
            Chyh = new double[x - 1, y, z - 1];
            Chye = new double[x - 1, y, z - 1];
            Chzh = new double[x - 1, y - 1, z];
            Chze = new double[x - 1, y - 1, z];
            Cexe = new double[x - 1, y, z];
            Cexh = new double[x - 1, y, z];
            Ceye = new double[x, y - 1, z];
            Ceyh = new double[x, y - 1, z];
            Ceze = new double[x, y, z - 1];
            Cezh = new double[x, y, z - 1];

            Eyx0 = new double[y - 1, z];
            Ezx0 = new double[y, z - 1];
            Eyx1 = new double[y - 1, z];
            Ezx1 = new double[y, z - 1];

            Exy0 = new double[x - 1, z];
            Ezy0 = new double[x, z - 1];
            Exy1 = new double[x - 1, z];
            Ezy0 = new double[x, z - 1];

            Exz0 = new double[x - 1, y];
            Eyz0 = new double[x, y - 1];
            Exz1 = new double[x - 1, y];
            Eyz1 = new double[x, y - 1];

            double cn = 1.0 / Math.Sqrt(3);

            c_abc = (cn - 1) / (cn + 1); 

            for (int i = 0; i < x - 1; ++i)
            {
                for (int j = 0; j < y; ++j)
                {
                    for (int k = 0; k < z; ++k)
                    {
                        Cexe[i, j, k] = 1;
                        Cexh[i, j, k] = cn * 377;
                    }
                }
            }

            for (int i = 0; i < x; ++i)
            {
                for (int j = 0; j < y - 1; ++j)
                {
                    for (int k  = 0; k < z; ++k)
                    {
                        Ceye[i, j, k] = 1;
                        Ceyh[i, j, k] = cn * 377;
                    }
                }
            }

            for (int i = 0; i < x; ++i)
            {
                for (int j = 0; j < y; ++j)
                {
                    for (int k = 0; k < z - 1; ++k)
                    {
                        Ceze[i, j, k] = 1;
                        Cezh[i, j, k] = cn * 377;
                    }
                }
            }

            for (int i = 0; i < x; ++i)
            {
                for (int j = 0; j < y - 1; ++j)
                {
                    for (int k = 0; k < z - 1; ++k)
                    {
                        Chxe[i, j, k] = 1;
                        Chxe[i, j, k] = cn / 377;
                    }
                }
            }

            for (int i = 0; i < x - 1; ++i)
            {
                for (int j = 0; j < y; ++j)
                {
                    for (int k = 0; k < z - 1; ++k)
                    {
                        Chyh[i, j, k] = 1;
                        Chye[i, j, k] = cn / 377;
                    }
                }
            }

            for (int i = 0; i < x - 1; ++i)
            {
                for (int j = 0; j < y - 1; ++j)
                {
                    for (int k = 0; k < z; ++k)
                    {
                        Chzh[i, j, k] = 1;
                        Chze[i, j, k] = cn / 377;
                    }
                }
            }
        }


        /// <summary>
        /// Обновление магнитного поля
        /// </summary>
        public void UpdateH()
        {
            // Update Hx
            for (int i = 0; i < x; ++i)
            {
                for (int j = 0; j < y - 1; ++j)
                {
                    for (int k = 0; k < z - 1; ++k)
                    {
                        Hx[i, j, k] = Chxh[i, j, k] * Hx[i, j, k] + Chxe[i, j, k] * ((Ey[i, j, k + 1] - Ey[i, j, k]) - (Ez[i, j + 1, k] - Ez[i, j, k]));
                    }
                }
            }
            // Update Hy
            for (int i = 0; i < x - 1; ++i)
            {
                for (int j = 0; j < y; ++j)
                {
                    for (int k = 0; k < z - 1; ++k)
                    {
                        Hy[i, j, k] = Chyh[i, j, k] * Hy[i, j, k] + Chye[i, j, k] * ((Ez[i + 1, j, k] - Ez[i, j, k]) - (Ex[i, j, k + 1] - Ex[i, j, k]));
                    }
                }
            }
            
            // Update Hz
            for (int i = 0; i < x - 1; ++i)
            { 
                for (int j = 0; j < y - 1; ++j)
                {
                    for (int k = 0; k < z; ++k)
                    {
                        Hz[i, j, k] = Chzh[i, j, k] * Hz[i, j, k] + Chze[i, j, k] * ((Ex[i, j + 1, k] - Ex[i, j, k]) - (Ey[i + 1, j, k] - Ey[i, j, k]));
                    }
                }
            }
        }
        /// <summary>
        /// Обновление электрического поля
        /// </summary>
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
            for (int i = 1; i < x - 1; ++i)
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
        public void abc()
        {
            int i = 0, k, j;
            for (j = 0; j < y - 1; ++j)
            {
                for (k = 0; k < z; ++k)
                {
                    Ey[i, j, k] = Eyx0[j, k] + c_abc * (Ey[i + 1, j, k] - Ey[i, j, k]);
                    Eyx0[j, k] = Ey[i + 1, j, k];
                }
            }

            for (j = 0; j < y; ++j)
            {
                for (k = 0; k < z - 1; ++k)
                {
                    Ez[i, j, k] = Ezx0[j, k] + c_abc * (Ez[i + 1, j, k] - Ez[i, j, k]);
                    Ezx0[j, k] = Ez[i + 1, j, k];
                }
            }

            i = x - 1;
            for (j = 0; j < y - 1; ++j)
                for (k = 0; k < z; ++k)
                {
                    Ey[i, j, k] = Eyx1[j, k] + c_abc * (Ey[i - 1, j, k] - Ey[i, j, k]);
                    Eyx1[i, j] = Ey[i - 1, j, k];
                }
            for (j = 0; j < y; ++j)
                for (k = 0; k < z - 1; ++k)
                {
                    Ez[i, j, k] = Ezx1[j, k] + c_abc * (Ez[i - 1, j, k] - Ez[i, j, k]);
                    Ezx1[j, k] = Ez[i - 1, j, k];
                }

            j = 0;
            for (i = 0; i < x - 1; ++i)
                for (k = 0; k < z; ++k)
                {
                    Ex[i, j, k] = Exy0[i, k] + c_abc * (Ex[i, j + 1, k] - Ex[i, j, k]);
                    Exy0[i, k] = Ex[i, j + 1, k];
                }
            for (i = 0; i < x; ++i)
                for (k = 0; k < z - 1; ++k)
                {
                    Ez[i, j, k] = Ezy0[i, k] + c_abc * (Ez[i, j + 1, k] - Ez[i, j, k]);
                    Ezy0[i, k] = Ez[i, j + 1, k];
                }

            j = y - 1;
            for (i = 0; i < x - 1; ++i)
                for (k = 0; k < z; ++k)
                {
                    Ex[i, j, k] = Exy1[i, k] + c_abc * (Ex[i, j - 1, k] - Ex[i, j, k]);
                    Exy1[i, k] = Ex[i, j - 1, k];
                }
            for (i = 0; i < x; ++i)
                for (k = 0; k < z - 1; ++k)
                {
                    Ez[i, j, k] = Ezy1[i, k] + c_abc * (Ez[i, j - 1, k] - Ez[i, j, k]);
                    Ezy1[i, k] = Ez[i, j - 1, k];
                }

            k = 0;
            for (i = 0; i < x - 1; ++i)
                for (j = 0; j < y; ++j)
                {
                    Ex[i, j, k] = Exz0[i, j] + c_abc * (Ex[i, j, k + 1] - Ex[i, j, k]);
                    Exz0[i, j] = Ex[i, j, k + 1];
                }
            for (i = 0; i < x; ++i)
                for (j = 0; j < y - 1; ++j)
                {
                    Ey[i, j, k] = Eyz0[i, j] + c_abc * (Ey[i, j, k + 1] - Ey[i, j, k]);
                    Eyz0[i, j] = Ey[i, j, k + 1];
                }

            k = z - 1;
            for (i = 0; i < x - 1; ++i)
                for (j = 0; j < y; ++j)
                {
                    Ex[i, j, k] = Exz1[i, j] + c_abc * (Ex[i, j, k - 1] - Ex[i, j, k]);
                    Exz1[i, j] = Ex[i, j, k - 1];
                }
            for (i = 0; i < x; ++i)
                for (j = 0; j < y - 1; ++j)
                {
                    Ey[i, j, k] = Eyz1[i, j] + c_abc * (Ey[i, j, k - 1] - Ey[i, j, k]);
                    Eyz1[i, j] = Ey[i, j, k - 1];
                }
        }
    }
}
