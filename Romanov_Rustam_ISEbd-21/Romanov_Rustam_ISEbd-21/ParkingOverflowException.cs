using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Romanov_Rustam_ISEbd_21
{
    /// <summary>
    /// Класс-ошибка "Если на парковке уже заняты все места"
    /// </summary>
    public class ParkingOverflowException : Exception
    {
        public ParkingOverflowException() : base("На парковке нет свободных мест")
        { }
    }
}
