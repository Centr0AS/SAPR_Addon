using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KAPITypes;
//using KompasAPI7;
//using Kompas6Constants3D;
using Kompas6API5;
using Kompas6Constants;
using Kompas6Constants3D;
//using KAPITypes;
//using Kompas6Constants;


namespace Hive_Kompas
{
     class KompasConnector
    {
        // c помощью этого обьекта мы можем 
        // выбрать определенное окно приложения компас
        public KompasObject _kompas = null;

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
            if (_kompas == null)
            {
                Type t = Type.GetTypeFromProgID("KOMPAS.Application.5");
                _kompas = (KompasObject)Activator.CreateInstance(t);
            }

            // показать компас          
            _kompas.Visible = true;
            _kompas.ActivateControllerAPI();


            // присвоить управление документами _doc3D
            _doc3D = (ksDocument3D)_kompas.Document3D();

            // создать документ
            _doc3D.Create(false/*invisible*/, true);

            // получить интерфейс детали !!
            iPart = (ksPart)_doc3D.GetPart((short)Part_Type.pTop_Part);
        }

    }
}
