using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Romanov_Rustam_ISEbd_21
{
    /// <summary>
    /// Класс-ошибка "Если не найден самолёт по определенному месту"
    /// </summary>
    public class ParkingNotFoundException : Exception
    {
        public ParkingNotFoundException(int i) : base("Не найден самолёт по месту " + i)
        { }
    }
}
