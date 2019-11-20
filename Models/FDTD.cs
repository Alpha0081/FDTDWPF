namespace FDTDWPF.Models
{
    /// <summary>
    /// Класс отработки алгоритма fdtd.
    /// </summary>
    class FDTD
    {
        public FDTD(Grid G, Item O,  int time, Probe Z = null)        
        {
            for (int t = 0; t < time; ++t)
            {
                G.UpdateH();
                G.UpdateE();
                G.abc();
            }
        }
    }
}
