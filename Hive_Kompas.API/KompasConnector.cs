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
//TODO: ВСЕ ДОЛЖНО БЫТЬ XML
        // c помощью этого обьекта мы можем 
        // выбрать определенное окно приложения компас
        public KompasObject kompas = null;

        // с помощью этого обьекта мы можем
        // создать 3Д документ для построения предметов
        private ksDocument3D _doc3D = null;

        // c помощью этого обьекта мы можем
        // взять управление конкретно над интерфейсом программы
        public ksPart iPart = null;

        // public KompasConnector(HiveParams hiveParams)
        public KompasConnector(HiveParams hiveParams)
        {
            TakeKompas();
        }

        // Кнопка запустить компас, Береме контроль _kompas, и интерфейсом
        public void TakeKompas()
        {
            // если окно компаса не включено
            // создать обьект компаса (т.е. обьект будет в процессе но не виден)
            if (kompas == null)
            {
                Type t = Type.GetTypeFromProgID("KOMPAS.Application.5");
                kompas = (KompasObject)Activator.CreateInstance(t);
            }

            // показать компас          
            kompas.Visible = true;
            kompas.ActivateControllerAPI();


            // присвоить управление документами _doc3D
            _doc3D = (ksDocument3D)kompas.Document3D();

            // создать документ
            _doc3D.Create(false/*invisible*/, true);

            // получить интерфейс детали !!
            iPart = (ksPart)_doc3D.GetPart((short)Part_Type.pTop_Part);
        }

    }
}
