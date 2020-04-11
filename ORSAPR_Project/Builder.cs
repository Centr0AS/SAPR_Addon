using Kompas6API5;
using Kompas6Constants;
using Kompas6Constants3D;
using KompasAPI7;

namespace Hive_Kompas
{
    class Builder
    {
        //KompasObject kompas;
        public ksPart iPart;
       // public HiveParams HiveParams;
        // public KompasConnector kompas;
        public void Build(ksPart iPart, KompasObject _kompas, HiveParams hiveparams)
        {
            this.iPart = iPart;
            CreateMain(iPart, _kompas,hiveparams);
            CreateLeg1(iPart, _kompas, hiveparams);
            CreateLeg2(iPart, _kompas, hiveparams);
            CreateLeg3(iPart, _kompas, hiveparams);
            CreateLeg4(iPart, _kompas, hiveparams);
            CreateRoof(iPart, _kompas, hiveparams);
            CreateHoles(iPart, _kompas, hiveparams);
            CreateBorder(iPart, _kompas, hiveparams);
        }
        public void CreateMain(ksPart iPart, KompasObject _kompas, HiveParams hiveParams)
        {
            double thickness = hiveParams.HiveLength;
            ksEntity iSketch;

            ksSketchDefinition iDefinitionSketch;

            CreateSketch(out iSketch, out iDefinitionSketch);

            // Интерфейс для рисования = на скетче;
            ksDocument2D iDocument2D = (ksDocument2D)iDefinitionSketch.BeginEdit();

            // Построить прямоугольник (x1,y1, x2,y2, style)
            ksRectangleParam par1 = (ksRectangleParam)_kompas.GetParamStruct((short)StructType2DEnum.ko_RectangleParam);
            par1.ang = 0; //Угол ?
                par1.x = 10;
                par1.y = 10;
                par1.width = hiveParams.HiveWidth;
                par1.height = hiveParams.HiveHeight; // Больше похоже на ширину, нежели высоту.
                par1.style = 1; // При нуле не видно деталь.
            iDocument2D.ksRectangle(par1);

            // Закончить редактировать эскиз
            iDefinitionSketch.EndEdit();

            ExctrusionSketch(iPart, iSketch, thickness, true);
        }
        public void CreateLeg1(ksPart iPart,KompasObject _kompas, HiveParams hiveParams)
        {
            double thickness = hiveParams.LegLength;
            ksEntity iSketch;

            ksSketchDefinition iDefinitionSketch;

            CreateSketch(out iSketch, out iDefinitionSketch);

            // Интерфейс для рисования = на скетче;
            ksDocument2D iDocument2D = (ksDocument2D)iDefinitionSketch.BeginEdit();

            ksRectangleParam par3 = (ksRectangleParam)_kompas.GetParamStruct((short)StructType2DEnum.ko_RectangleParam);
            par3.ang = 0; //Угол 
            par3.x = 10;
            par3.y = hiveParams.HiveHeight;
            par3.width = hiveParams.LegWidth;  
            par3.height = hiveParams.LegHeight; 
            par3.style = 1; 
            iDocument2D.ksRectangle(par3);

            // Закончить редактировать эскиз
            iDefinitionSketch.EndEdit();

            ExctrusionSketch(iPart, iSketch, thickness, true);
        }

        public void CreateLeg2(ksPart iPart, KompasObject _kompas, HiveParams hiveParams)
        {
            double thickness = hiveParams.LegLength;
            ksEntity iSketch;

            ksSketchDefinition iDefinitionSketch;

            CreateSketch(out iSketch, out iDefinitionSketch);

            // Интерфейс для рисования = на скетче;
            ksDocument2D iDocument2D = (ksDocument2D)iDefinitionSketch.BeginEdit();

            ksRectangleParam par4 = (ksRectangleParam)_kompas.GetParamStruct((short)StructType2DEnum.ko_RectangleParam);
            par4.ang = 0; //Угол
            par4.x =(hiveParams.HiveLength - (hiveParams.LegLength )) +10 ;
            par4.y = hiveParams.HiveHeight;
            par4.width = hiveParams.LegWidth;  
            par4.height = hiveParams.LegHeight; 
            par4.style = 1; 
            iDocument2D.ksRectangle(par4);
            // Закончить редактировать эскиз
            iDefinitionSketch.EndEdit();

            ExctrusionSketch(iPart, iSketch, thickness, true);
        }

        public void CreateLeg3(ksPart iPart, KompasObject _kompas, HiveParams hiveParams)
        {
            double thickness = hiveParams.LegLength;
            double offset = hiveParams.HiveWidth - hiveParams.LegWidth;
            ksEntity iSketch;

            ksSketchDefinition iDefinitionSketch;

            CreateSketch(out iSketch, out iDefinitionSketch,offset);

            // Интерфейс для рисования = на скетче;
            ksDocument2D iDocument2D = (ksDocument2D)iDefinitionSketch.BeginEdit();

            ksRectangleParam par5 = (ksRectangleParam)_kompas.GetParamStruct((short)StructType2DEnum.ko_RectangleParam);
            par5.ang = 0; //Угол ?
            par5.x = 10;
            par5.y = hiveParams.HiveHeight;
            par5.width = hiveParams.LegWidth; 
            par5.height = hiveParams.LegHeight; 
            par5.style = 1; 
            iDocument2D.ksRectangle(par5);

            // Закончить редактировать эскиз
            iDefinitionSketch.EndEdit();

            ExctrusionSketch(iPart, iSketch, thickness, true);
        }
        public void CreateLeg4(ksPart iPart, KompasObject _kompas, HiveParams hiveParams)
        {
            double thickness = hiveParams.LegLength;
            double offset = hiveParams.HiveLength - hiveParams.LegWidth;
            ksEntity iSketch;

            ksSketchDefinition iDefinitionSketch;

            CreateSketch(out iSketch, out iDefinitionSketch,offset);

            // Интерфейс для рисования = на скетче;
            ksDocument2D iDocument2D = (ksDocument2D)iDefinitionSketch.BeginEdit();
            ksRectangleParam par6 = (ksRectangleParam)_kompas.GetParamStruct((short)StructType2DEnum.ko_RectangleParam);
            par6.ang = 0; //Угол 
            par6.x = (hiveParams.HiveLength - (hiveParams.LegLength)) + 10;
            par6.y = hiveParams.HiveHeight;
            par6.width = hiveParams.LegWidth; 
            par6.height = hiveParams.LegHeight; 
            par6.style = 1; // При нуле не видно деталь.
            iDocument2D.ksRectangle(par6);

            // Закончить редактировать эскиз
            iDefinitionSketch.EndEdit();

            ExctrusionSketch(iPart, iSketch, thickness, true);
        }

        public void CreateRoof(ksPart iPart, KompasObject _kompas, HiveParams hiveParams)
        {
            // double thickness = hiveParams.RoofThickness;
             double offset = - 10;
            //double offset = 0;
            double thickness = 5;
            ksEntity iSketch;

            ksSketchDefinition iDefinitionSketch;

            CreateSketch(out iSketch, out iDefinitionSketch,offset);

            // Интерфейс для рисования = на скетче;
            ksDocument2D iDocument2D = (ksDocument2D)iDefinitionSketch.BeginEdit();

            
            // Построить прямоугольник (x1,y1, x2,y2, style)
            ksRectangleParam par1 = (ksRectangleParam)_kompas.GetParamStruct((short)StructType2DEnum.ko_RectangleParam);
            par1.ang = 0; //Угол ?
            par1.x = 10 - 10   ;
            par1.y = 10;
            par1.width = hiveParams.HiveWidth +20 ;
            par1.height = thickness; // Больше похоже на ширину, нежели высоту.
            par1.style = 1; // При нуле не видно деталь.
            iDocument2D.ksRectangle(par1);

            // Закончить редактировать эскиз
            iDefinitionSketch.EndEdit();

            ExctrusionSketch(iPart, iSketch, hiveParams.HiveLength +20 , true);
         }

        public void CreateHoles(ksPart iPart, KompasObject _kompas, HiveParams hiveParams)
        {
            int floorCount = (int)(hiveParams.HiveHeight / 300);
            double offset = hiveParams.HiveLength + 20;
            //double offset = -20;
            double radius = hiveParams.InletDiameters;
            ksEntity iSketch;

            ksSketchDefinition iDefinitionSketch;

            CreateSketch(out iSketch, out iDefinitionSketch, offset);

            // Интерфейс для рисования = на скетче;
            ksDocument2D iDocument2D = (ksDocument2D)iDefinitionSketch.BeginEdit();
            // excess - Переменная, которая хранит в себе излишки(превышения) размера этажа, используется для 
            //правильной центровки отверстий.
            switch (floorCount)
            {
                case 1:
                    iDocument2D.ksCircle((hiveParams.HiveLength / 2) +10, hiveParams.HiveHeight / 2, radius, 1);
                    break;
                case 2:
                    iDocument2D.ksCircle((hiveParams.HiveLength / 2) + 10, (hiveParams.HiveHeight /4), radius, 1);
                    iDocument2D.ksCircle((hiveParams.HiveLength / 2) +10, (hiveParams.HiveHeight /4) *3, radius, 1);
                    break;
                case 3:
                    iDocument2D.ksCircle((hiveParams.HiveLength / 2) + 10, (hiveParams.HiveHeight / 6), radius, 1);
                    iDocument2D.ksCircle((hiveParams.HiveLength / 2) + 10, (hiveParams.HiveHeight / 6)*3, radius, 1);
                    iDocument2D.ksCircle((hiveParams.HiveLength / 2) + 10, (hiveParams.HiveHeight / 6)*5, radius, 1);
                    break;
                case 4:
                    iDocument2D.ksCircle((hiveParams.HiveLength / 2) + 10, (hiveParams.HiveHeight / 8) * 1, radius, 1);
                    iDocument2D.ksCircle((hiveParams.HiveLength / 2) + 10, (hiveParams.HiveHeight / 8) * 3, radius, 1);
                    iDocument2D.ksCircle((hiveParams.HiveLength / 2) + 10, (hiveParams.HiveHeight / 8) * 5, radius, 1);
                    iDocument2D.ksCircle((hiveParams.HiveLength / 2) + 10, (hiveParams.HiveHeight / 8) * 7, radius, 1);
                    break;
                case 5:
                    iDocument2D.ksCircle((hiveParams.HiveLength / 2) + 10, (hiveParams.HiveHeight / 10) * 1, radius, 1);
                    iDocument2D.ksCircle((hiveParams.HiveLength / 2) + 10, (hiveParams.HiveHeight / 10) * 3, radius, 1);
                    iDocument2D.ksCircle((hiveParams.HiveLength / 2) + 10, (hiveParams.HiveHeight / 10) * 5, radius, 1);
                    iDocument2D.ksCircle((hiveParams.HiveLength / 2) + 10, (hiveParams.HiveHeight / 10) * 7, radius, 1);
                    iDocument2D.ksCircle((hiveParams.HiveLength / 2) + 10, (hiveParams.HiveHeight / 10) * 9, radius, 1);
                    break;
                case 6:
                    iDocument2D.ksCircle((hiveParams.HiveLength / 2) + 10, (hiveParams.HiveHeight / 12) * 1, radius, 1);
                    iDocument2D.ksCircle((hiveParams.HiveLength / 2) + 10, (hiveParams.HiveHeight / 12) * 3, radius, 1);
                    iDocument2D.ksCircle((hiveParams.HiveLength / 2) + 10, (hiveParams.HiveHeight / 12) * 5, radius, 1);
                    iDocument2D.ksCircle((hiveParams.HiveLength / 2) + 10, (hiveParams.HiveHeight / 12) * 7, radius, 1);
                    iDocument2D.ksCircle((hiveParams.HiveLength / 2) + 10, (hiveParams.HiveHeight / 12) * 9, radius, 1);
                    iDocument2D.ksCircle((hiveParams.HiveLength / 2) + 10, (hiveParams.HiveHeight / 12) * 11, radius, 1);
                    break;
                default:
                    iDocument2D.ksCircle((hiveParams.HiveLength / 2) + 10, hiveParams.HiveHeight / 2, radius, 1);
                    break;

            }
            //iDocument2D.ksColouring(2);
            //iDocument2D.ksLineSeg(50, 50, -50, 50, 1);
            //iDocument2D.ksLineSeg(50, -50, -50, -50, 1);
            //iDocument2D.ksLineSeg(50, -50, 50, 50, 1);
            //iDocument2D.ksLineSeg(-50, -50, -50, 50, 1);
            //iDocument2D.ksCutLine(par1)
            // Закончить редактировать эскиз
            iDefinitionSketch.EndEdit();

            //**
            ksEntity entityCutExtr = (ksEntity)iPart.NewEntity((short)Obj3dType.o3d_cutExtrusion);
            ksCutExtrusionDefinition cutExtrDef = (ksCutExtrusionDefinition)entityCutExtr.GetDefinition();
            cutExtrDef.SetSketch(iSketch);    // установим эскиз операции
            cutExtrDef.directionType = (short)Direction_Type.dtNormal; //прямое направление
            cutExtrDef.SetSideParam(true, (short)End_Type.etBlind, 50, 20, false);
            cutExtrDef.SetThinParam(false, 0, 0, 0);
            entityCutExtr.Create(); // создадим операцию вырезание выдавливанием
                                    //**

            // ExctrusionSketch(iPart, iSketch, thickness+1010, true);
        }


        public void CreateBorder(ksPart iPart, KompasObject _kompas, HiveParams hiveParams)
        {
            double offset = -10;
            double thickness = 5;
            int floorCount = (int)(hiveParams.HiveHeight / 300);
            ksEntity iSketch;

            ksSketchDefinition iDefinitionSketch;
            CreateSketch(out iSketch, out iDefinitionSketch, offset);
            ksDocument2D iDocument2D = (ksDocument2D)iDefinitionSketch.BeginEdit();
            switch (floorCount)
            {
                case 1:
                    break;
                case 2:  
                    ksRectangleParam par7 = (ksRectangleParam)_kompas.GetParamStruct((short)StructType2DEnum.ko_RectangleParam);
                    par7.ang = 0; //Угол 
                    par7.x = 10 - 10;
                    par7.y = (hiveParams.HiveHeight / 2);
                    par7.width = hiveParams.HiveWidth + 20;
                    par7.height = thickness; // Больше похоже на ширину, нежели высоту.
                    par7.style = 1;
                    iDocument2D.ksRectangle(par7);
                    // Закончить редактировать эскиз
                    iDefinitionSketch.EndEdit();

                    ExctrusionSketch(iPart, iSketch, hiveParams.HiveLength + 20, true);
                    break;
                case 3:
                    ksRectangleParam par8 = (ksRectangleParam)_kompas.GetParamStruct((short)StructType2DEnum.ko_RectangleParam);
                    par8.ang = 0; //Угол 
                    par8.x = 10 - 10;
                    par8.y = (hiveParams.HiveHeight / 6)*2;
                    par8.width = hiveParams.HiveWidth + 20;
                    par8.height = thickness; // Больше похоже на ширину, нежели высоту.
                    par8.style = 1;
                    iDocument2D.ksRectangle(par8);
                    par8.y = (hiveParams.HiveHeight / 6)*4;
                    iDocument2D.ksRectangle(par8);
                    // Закончить редактировать эскиз
                    iDefinitionSketch.EndEdit();
                    ExctrusionSketch(iPart, iSketch, hiveParams.HiveLength + 20, true);
                    break;
                case 4:
                    ksRectangleParam par9 = (ksRectangleParam)_kompas.GetParamStruct((short)StructType2DEnum.ko_RectangleParam);
                    par9.ang = 0; //Угол 
                    par9.x = 10 - 10;
                    par9.y = (hiveParams.HiveHeight / 8) * 2;
                    par9.width = hiveParams.HiveWidth + 20;
                    par9.height = thickness; // Больше похоже на ширину, нежели высоту.
                    par9.style = 1; // При нуле не видно деталь.
                    iDocument2D.ksRectangle(par9);
                    par9.y = (hiveParams.HiveHeight / 8) * 4;
                    iDocument2D.ksRectangle(par9);
                    par9.y = (hiveParams.HiveHeight / 8) * 6;
                    iDocument2D.ksRectangle(par9);
                    // Закончить редактировать эскиз
                    iDefinitionSketch.EndEdit();

                    ExctrusionSketch(iPart, iSketch, hiveParams.HiveLength + 20, true);
                    break;
                case 5:
                    ksRectangleParam par10 = (ksRectangleParam)_kompas.GetParamStruct((short)StructType2DEnum.ko_RectangleParam);
                    par10.ang = 0; //Угол 
                    par10.x = 10 - 10;
                    par10.y = (hiveParams.HiveHeight / 10) * 2;
                    par10.width = hiveParams.HiveWidth + 20;
                    par10.height = thickness; // Больше похоже на ширину, нежели высоту.
                    par10.style = 1; // При нуле не видно деталь.
                    iDocument2D.ksRectangle(par10);
                    par10.y = (hiveParams.HiveHeight / 10) * 4;
                    iDocument2D.ksRectangle(par10);
                    par10.y = (hiveParams.HiveHeight / 10) * 6;
                    iDocument2D.ksRectangle(par10);
                    par10.y = (hiveParams.HiveHeight / 10) * 8;
                    iDocument2D.ksRectangle(par10);
                   
                    // Закончить редактировать эскиз
                    iDefinitionSketch.EndEdit();

                    ExctrusionSketch(iPart, iSketch, hiveParams.HiveLength + 20, true);
                    break;
                case 6:
                    ksRectangleParam par11 = (ksRectangleParam)_kompas.GetParamStruct((short)StructType2DEnum.ko_RectangleParam);
                    par11.ang = 0; //Угол 
                    par11.x = 10 - 10;
                    //par11.y = 300;
                    par11.y = (hiveParams.HiveHeight / 12) * 2;
                    par11.width = hiveParams.HiveWidth + 20;
                    par11.height = thickness; // Больше похоже на ширину, нежели высоту.
                    par11.style = 1; // При нуле не видно деталь.
                    iDocument2D.ksRectangle(par11);
                    //par11.y = 600;
                    par11.y = (hiveParams.HiveHeight / 12) * 4;
                    iDocument2D.ksRectangle(par11);
                    //par11.y = 900;
                    par11.y = (hiveParams.HiveHeight / 12) * 6;
                    iDocument2D.ksRectangle(par11);
                    //par11.y = 1200;
                    par11.y = (hiveParams.HiveHeight / 12) * 8;
                    iDocument2D.ksRectangle(par11);
                    //par11.y = 1500;
                    par11.y = (hiveParams.HiveHeight / 12) * 10;
                    iDocument2D.ksRectangle(par11);
                    // Закончить редактировать эскиз
                    iDefinitionSketch.EndEdit();

                    ExctrusionSketch(iPart, iSketch, hiveParams.HiveLength + 20, true);
                    break;

            }
        }

        /// <summary>
        /// Создать эскиз
        /// </summary>
        /// <param name="iSketch">Эскиз</param>
        /// <param name="iDefinitionSketch">Определение эскиза</param>
        /// <param name="offset">Смещение от начальной плоскости</param>
        private void CreateSketch(out ksEntity iSketch, out ksSketchDefinition iDefinitionSketch, double offset = 0)
        {
            #region Создание смещенную плоскость -------------------------
            // интерфейс смещенной плоскости
            ksEntity iPlane = (ksEntity)iPart.NewEntity((short)Obj3dType.o3d_planeOffset);

            // Получаем интрефейс настроек смещенной плоскости
            ksPlaneOffsetDefinition iPlaneDefinition = (ksPlaneOffsetDefinition)iPlane.GetDefinition();

            // Настройки : начальная позиция, направление смещения, расстояние от плоскости, принять все настройки (create)
            iPlaneDefinition.SetPlane(iPart.GetDefaultEntity((short)Obj3dType.o3d_planeXOZ));
            iPlaneDefinition.direction = true;
            iPlaneDefinition.offset = offset;
            iPlane.Create();
            #endregion --------------------------------------------------

            // Создаем обьект эскиза
            iSketch = (ksEntity)iPart.NewEntity((short)Obj3dType.o3d_sketch);

            // Получаем интерфейс настроек эскиза
            iDefinitionSketch = iSketch.GetDefinition();

            // Устанавливаем плоскость эскиза
            iDefinitionSketch.SetPlane(iPlane);

            // Теперь когда св-ва эскиза установлены можно его создать 
            iSketch.Create();
        }

        /// <summary>
        /// Выдавливание по эскизу
        /// </summary>
        /// <param name="iPart">Интерфейс детали</param>
        /// <param name="iSketch">Эскиз</param>
        /// <param name="depth">Глубина выдавливания</param>
        /// <param name="direction">Направление выдавливания</param>
        private void ExctrusionSketch(ksPart iPart, ksEntity iSketch, double depth, bool direction)
        {
            //Операция выдавливание
            ksEntity entityExtr = (ksEntity)iPart.NewEntity((short)Obj3dType.o3d_bossExtrusion);

            //Интерфейс операции выдавливания
            ksBossExtrusionDefinition extrusionDef = (ksBossExtrusionDefinition)entityExtr.GetDefinition();

            //Интерфейс структуры параметров выдавливания
            ksExtrusionParam extrProp = (ksExtrusionParam)extrusionDef.ExtrusionParam();

            //Эскиз операции выдавливания
            extrusionDef.SetSketch(iSketch);

            //Направление выдавливания
            if (direction == false)
            {
                extrProp.direction = (short)Direction_Type.dtReverse;
            }
            else
            {
                extrProp.direction = (short)Direction_Type.dtNormal;
            }

            //Тип выдавливания
            extrProp.typeNormal = (short)End_Type.etBlind;

            //Глубина выдавливания
            if (direction == false)
            {
                extrProp.depthReverse = depth;
            }
            else
            {
                extrProp.depthNormal = depth;
            }
            //Создание операции ???
            entityExtr.Create();
        }

    }
}
