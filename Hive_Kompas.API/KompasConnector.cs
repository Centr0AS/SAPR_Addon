using System;
using Hive_Kompas.Logic;
using Kompas6API5;
using Kompas6Constants3D;



namespace Hive_Kompas.API
{
    /// <summary>
    /// Соединение с через API Kompas
    /// </summary>
     public class KompasConnector
    {
        /// <summary>
        /// Объект Компас.
        /// </summary>
        public KompasObject kompas { get; set; }

        /// <summary>
        /// Документ компас3D.
        /// </summary>
        private ksDocument3D _doc3D ;

        /// <summary>
        /// Интерфейс компонента.
        /// </summary>
        public ksPart iPart { get; set; }

        /// <summary>
        /// Соединение с САПР и передача параметров.
        /// </summary>
        public KompasConnector()
        {
            TakeKompas();
        }

        /// <summary>
        /// Создать окно в САПР и взять над ним управление.
        /// </summary>
        public void TakeKompas()
        {
            if (kompas == null)
            {
                Type t = Type.GetTypeFromProgID("KOMPAS.Application.5");
                kompas = (KompasObject)Activator.CreateInstance(t);
            }

            kompas.Visible = true;

            kompas.ActivateControllerAPI();

            _doc3D = (ksDocument3D)kompas.Document3D();

            _doc3D.Create(false, true);

            iPart = (ksPart)_doc3D.GetPart((short)Part_Type.pTop_Part);
           
        }

    }
}
