using Hive_Kompas.Logic;
using Kompas6API5;
using Kompas6Constants;
using Kompas6Constants3D;

namespace Hive_Kompas.API
{
    public class Builder
    {
       private ksPart iPart;

        /// <summary>
        /// Функция, которая выполняет построение всех деталей.
        /// </summary>
        /// <param name="iPart"> интерфейс детали</param>
        /// <param name="kompas">  объект типа kompas</param>
        /// <param name="hiveparams"> класс, хранящий параметры улья</param>
        public void Build(ksPart iPart, KompasObject kompas, HiveParams hiveparams, bool BackSide, bool LeftSide, bool RightSide)
        {
            this.iPart = iPart;
            CreateMain(iPart, kompas, hiveparams);
            CreateLeg1(iPart, kompas, hiveparams);
            CreateLeg2(iPart, kompas, hiveparams);
            CreateLeg3(iPart, kompas, hiveparams);
            CreateLeg4(iPart, kompas, hiveparams);
            CreateRoof(iPart, kompas, hiveparams);
            CreateHoles(iPart, kompas, hiveparams);
            CreateBorder(iPart, kompas, hiveparams);

            if (BackSide)
                CreateBackHoles(iPart, kompas, hiveparams);

            if (LeftSide)
                CreateLeftHoles(iPart, kompas, hiveparams);
            
            if(RightSide)
                CreateRightHoles(iPart, kompas, hiveparams);
        }

        /// <summary>
        /// Функция выполняет построение основной части улья.
        /// </summary>
        private void CreateMain(ksPart iPart, KompasObject kompas, HiveParams hiveParams)
        {
            double thickness = hiveParams.HiveWidth;

            ksEntity iSketch;

            ksSketchDefinition iDefinitionSketch;

            CreateSketch(out iSketch, out iDefinitionSketch);
            
            ksDocument2D iDocument2D = (ksDocument2D)iDefinitionSketch.BeginEdit();
            
            ksRectangleParam par1 = 
                (ksRectangleParam)kompas.GetParamStruct((short)StructType2DEnum.ko_RectangleParam);
            par1.ang = 0; 
            par1.x = 10;
            par1.y = 10;
            par1.width = hiveParams.HiveLength;
            par1.height = hiveParams.HiveHeight; 
            par1.style = 1; 
            iDocument2D.ksRectangle(par1);

            iDefinitionSketch.EndEdit();

            ExctrusionSketch(iPart, iSketch, thickness, true);
        }

        /// <summary>
        ///  Функция выполяет построение 1ой ножки улья.
        /// </summary>
        private void CreateLeg1(ksPart iPart, KompasObject kompas, HiveParams hiveParams)
        {
            double thickness = hiveParams.LegWidth;

            ksEntity iSketch;

            ksSketchDefinition iDefinitionSketch;

            CreateSketch(out iSketch, out iDefinitionSketch);

            ksDocument2D iDocument2D = (ksDocument2D)iDefinitionSketch.BeginEdit();
            ksRectangleParam par3 =
                (ksRectangleParam)kompas.GetParamStruct((short)StructType2DEnum.ko_RectangleParam);

            par3.ang = 0; 
            par3.x = 10;
            par3.y = hiveParams.HiveHeight;
            par3.width = hiveParams.LegLength;
            par3.height = hiveParams.LegHeight;
            par3.style = 1;
            iDocument2D.ksRectangle(par3);

            iDefinitionSketch.EndEdit();

            ExctrusionSketch(iPart, iSketch, thickness, true);
        }

        /// <summary>
        /// Функция выполняет построение 2й ножки улья.
        /// </summary>
        private void CreateLeg2(ksPart iPart, KompasObject kompas, HiveParams hiveParams)
        {
            double thickness = hiveParams.LegWidth;

            ksEntity iSketch;

            ksSketchDefinition iDefinitionSketch;

            CreateSketch(out iSketch, out iDefinitionSketch);

            ksDocument2D iDocument2D = (ksDocument2D)iDefinitionSketch.BeginEdit();

            ksRectangleParam par4 = 
                (ksRectangleParam)kompas.GetParamStruct((short)StructType2DEnum.ko_RectangleParam);
            par4.ang = 0; 
            par4.x = (hiveParams.HiveLength - (hiveParams.LegLength)) + 10;
            par4.y = hiveParams.HiveHeight;
            par4.width = hiveParams.LegLength;
            par4.height = hiveParams.LegHeight;
            par4.style = 1;

            iDocument2D.ksRectangle(par4);

            iDefinitionSketch.EndEdit();

            ExctrusionSketch(iPart, iSketch, thickness, true);
        }



        /// <summary>
        /// Функция выполняет построение 3ей ножки улья
        /// </summary>
        private void CreateLeg3(ksPart iPart, KompasObject kompas, HiveParams hiveParams)
        {
            double thickness = hiveParams.LegWidth;

            double offset = ((hiveParams.HiveWidth - hiveParams.LegWidth)); 

            ksEntity iSketch;

            ksSketchDefinition iDefinitionSketch;

            CreateSketch(out iSketch, out iDefinitionSketch, offset);

            ksDocument2D iDocument2D = (ksDocument2D)iDefinitionSketch.BeginEdit();
            ksRectangleParam par5 = 
                (ksRectangleParam)kompas.GetParamStruct((short)StructType2DEnum.ko_RectangleParam);
            par5.ang = 0;
            par5.x = 10;
            par5.y = hiveParams.HiveHeight;
            par5.width = hiveParams.LegLength;
            par5.height = hiveParams.LegHeight;
            par5.style = 1;

            iDocument2D.ksRectangle(par5);
            
            iDefinitionSketch.EndEdit();

            ExctrusionSketch(iPart, iSketch, thickness, true);
        }

        /// <summary>
        /// Функция выполняет построение 4ой ножки улья
        /// </summary>
        private void CreateLeg4(ksPart iPart, KompasObject kompas, HiveParams hiveParams)
        {
            double thickness = hiveParams.LegWidth;

            double offset = ((hiveParams.HiveWidth - hiveParams.LegWidth));

            ksEntity iSketch;

            ksSketchDefinition iDefinitionSketch;

            CreateSketch(out iSketch, out iDefinitionSketch, offset);

            ksDocument2D iDocument2D = (ksDocument2D)iDefinitionSketch.BeginEdit();
            ksRectangleParam par6 = (ksRectangleParam)kompas.GetParamStruct((short)StructType2DEnum.ko_RectangleParam);
            par6.ang = 0; 
            par6.x = (hiveParams.HiveLength - (hiveParams.LegLength)) + 10;
            par6.y = hiveParams.HiveHeight;
            par6.width = hiveParams.LegLength;
            par6.height = hiveParams.LegHeight;
            par6.style = 1;
            iDocument2D.ksRectangle(par6);

            iDefinitionSketch.EndEdit();

            ExctrusionSketch(iPart, iSketch, thickness, true);
        }

        /// <summary>
        /// Функция выполняет построение крыши улья.
        /// </summary>
        private void CreateRoof(ksPart iPart, KompasObject kompas, HiveParams hiveParams)
        {
            double offset = -10;

            double thickness = hiveParams.RoofThickness;

            ksEntity iSketch;

            ksSketchDefinition iDefinitionSketch;

            CreateSketch(out iSketch, out iDefinitionSketch, offset);

            ksDocument2D iDocument2D = (ksDocument2D)iDefinitionSketch.BeginEdit();

            ksRectangleParam par1 = 
                (ksRectangleParam)kompas.GetParamStruct((short)StructType2DEnum.ko_RectangleParam);
            par1.ang = 0; 
            par1.x = 0;
            par1.y = 10;
            par1.width = hiveParams.HiveLength + 20;
            par1.height = thickness; // Больше похоже на ширину, нежели высоту.
            par1.style = 1; // При нуле не видно деталь.

            iDocument2D.ksRectangle(par1);

            // Закончить редактировать эскиз
            iDefinitionSketch.EndEdit();

            ExctrusionSketch(iPart, iSketch, hiveParams.HiveWidth + 20, true);
        }

        /// <summary>
        /// Функция создает отверстия в улье для пчёл
        /// </summary>
        private void CreateHoles(ksPart iPart, KompasObject kompas, HiveParams hiveParams)
        {
            int floorCount = (int)(hiveParams.HiveHeight / 300);

            double offset = hiveParams.HiveWidth;

            double radius = hiveParams.InletDiameters;

            ksEntity iSketch;

            ksSketchDefinition iDefinitionSketch;

            CreateSketch(out iSketch, out iDefinitionSketch, offset);

            ksDocument2D iDocument2D = (ksDocument2D)iDefinitionSketch.BeginEdit();
            
            switch (floorCount)
            {
                case 1:
                    iDocument2D.ksCircle((hiveParams.HiveLength / 2) + 10, hiveParams.HiveHeight / 2, radius, 1);
                    break;
                case 2:
                    iDocument2D.ksCircle((hiveParams.HiveLength / 2) + 10, (hiveParams.HiveHeight / 4), radius, 1);
                    iDocument2D.ksCircle((hiveParams.HiveLength / 2) + 10, (hiveParams.HiveHeight / 4) * 3, radius, 1);
                    break;
                case 3:
                    iDocument2D.ksCircle((hiveParams.HiveLength / 2) + 10, (hiveParams.HiveHeight / 6), radius, 1);
                    iDocument2D.ksCircle((hiveParams.HiveLength / 2) + 10, (hiveParams.HiveHeight / 6) * 3, radius, 1);
                    iDocument2D.ksCircle((hiveParams.HiveLength / 2) + 10, (hiveParams.HiveHeight / 6) * 5, radius, 1);
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
            
            iDefinitionSketch.EndEdit();
   
            ksEntity entityCutExtr = 
                (ksEntity)iPart.NewEntity((short)Obj3dType.o3d_cutExtrusion);
            ksCutExtrusionDefinition cutExtrDef = 
                (ksCutExtrusionDefinition)entityCutExtr.GetDefinition();

            cutExtrDef.SetSketch(iSketch);   

            cutExtrDef.directionType = (short)Direction_Type.dtNormal;
            cutExtrDef.SetSideParam(true, (short)End_Type.etBlind, 50, 20, false);
            cutExtrDef.SetThinParam(false, 0, 0, 0);

            entityCutExtr.Create(); 
        }

        /// <summary>
        /// Функция создает дополнительные крыши для этажей.
        /// </summary>
        private void CreateBorder(ksPart iPart, KompasObject kompas, HiveParams hiveParams)
        {
            double offset = -10;
            double thickness = hiveParams.RoofThickness;
            int floorCount = (int)(hiveParams.HiveHeight / 300);
            ksEntity iSketch;

            ksSketchDefinition iDefinitionSketch;

            CreateSketch(out iSketch, out iDefinitionSketch, offset);

            ksDocument2D iDocument2D = (ksDocument2D)iDefinitionSketch.BeginEdit();

            switch (floorCount)
            {
                case 1:
                    iDefinitionSketch.EndEdit();
                    break;
                case 2:
                    ksRectangleParam par7 =
                        (ksRectangleParam)kompas.GetParamStruct((short)StructType2DEnum.ko_RectangleParam);
                    par7.ang = 0; 
                    par7.x = 0;
                    par7.y = (hiveParams.HiveHeight / 2);
                    par7.width = hiveParams.HiveLength + 20;
                    par7.height = thickness;
                    par7.style = 1;
                    iDocument2D.ksRectangle(par7);
                    
                    iDefinitionSketch.EndEdit();
                    
                    ExctrusionSketch(iPart, iSketch, hiveParams.HiveWidth + 20, true);
                    break;
                case 3:
                    ksRectangleParam par8 = 
                        (ksRectangleParam)kompas.GetParamStruct((short)StructType2DEnum.ko_RectangleParam);
                    par8.ang = 0; 
                    par8.x = 0;
                    par8.y = (hiveParams.HiveHeight / 6) * 2;
                    par8.width = hiveParams.HiveLength + 20;
                    par8.height = thickness; 
                    par8.style = 1;
                    iDocument2D.ksRectangle(par8);
                    par8.y = (hiveParams.HiveHeight / 6) * 4;
                    iDocument2D.ksRectangle(par8);
                    
                    iDefinitionSketch.EndEdit();

                    ExctrusionSketch(iPart, iSketch, hiveParams.HiveWidth + 20, true);
                    break;
                case 4:
                    ksRectangleParam par9 = 
                        (ksRectangleParam)kompas.GetParamStruct((short)StructType2DEnum.ko_RectangleParam);
                    par9.ang = 0; 
                    par9.x = 0;
                    par9.y = (hiveParams.HiveHeight / 8) * 2;
                    par9.width = hiveParams.HiveLength + 20;
                    par9.height = thickness; 
                    par9.style = 1; 
                    iDocument2D.ksRectangle(par9);
                    par9.y = (hiveParams.HiveHeight / 8) * 4;
                    iDocument2D.ksRectangle(par9);
                    par9.y = (hiveParams.HiveHeight / 8) * 6;
                    iDocument2D.ksRectangle(par9);

                    iDefinitionSketch.EndEdit();

                    ExctrusionSketch(iPart, iSketch, hiveParams.HiveWidth + 20, true);
                    break;
                case 5:
                    ksRectangleParam par10 = 
                        (ksRectangleParam)kompas.GetParamStruct((short)StructType2DEnum.ko_RectangleParam);
                    par10.ang = 0; 
                    par10.x = 0;
                    par10.y = (hiveParams.HiveHeight / 10) * 2;
                    par10.width = hiveParams.HiveLength + 20;
                    par10.height = thickness; 
                    par10.style = 1; 
                    iDocument2D.ksRectangle(par10);
                    par10.y = (hiveParams.HiveHeight / 10) * 4;
                    iDocument2D.ksRectangle(par10);
                    par10.y = (hiveParams.HiveHeight / 10) * 6;
                    iDocument2D.ksRectangle(par10);
                    par10.y = (hiveParams.HiveHeight / 10) * 8;
                    iDocument2D.ksRectangle(par10);
   
                    iDefinitionSketch.EndEdit();

                    ExctrusionSketch(iPart, iSketch, hiveParams.HiveWidth + 20, true);
                    break;
                case 6:
                    ksRectangleParam par11 = 
                        (ksRectangleParam)kompas.GetParamStruct((short)StructType2DEnum.ko_RectangleParam);
                    par11.ang = 0; 
                    par11.x = 0;
                    par11.y = (hiveParams.HiveHeight / 12) * 2;
                    par11.width = hiveParams.HiveLength + 20;
                    par11.height = thickness; 
                    par11.style = 1; 
                    iDocument2D.ksRectangle(par11);
                    par11.y = (hiveParams.HiveHeight / 12) * 4;
                    iDocument2D.ksRectangle(par11);
                    par11.y = (hiveParams.HiveHeight / 12) * 6;
                    iDocument2D.ksRectangle(par11);
                    par11.y = (hiveParams.HiveHeight / 12) * 8;
                    iDocument2D.ksRectangle(par11);
                    par11.y = (hiveParams.HiveHeight / 12) * 10;
                    iDocument2D.ksRectangle(par11);

                    iDefinitionSketch.EndEdit();

                    ExctrusionSketch(iPart, iSketch, hiveParams.HiveWidth + 20, true);
                    break;
            }
        }

       /// <summary>
       /// Выполняет построение отверстий с задней стороны
       /// </summary>
        private void CreateBackHoles(ksPart iPart, KompasObject kompas, HiveParams hiveParams)
        {
            int floorCount = (int)(hiveParams.HiveHeight / 300);

            double offset = 0;

            double radius = hiveParams.InletDiameters;

            ksEntity iSketch;

            ksSketchDefinition iDefinitionSketch;

            CreateSketch(out iSketch, out iDefinitionSketch, offset);

            ksDocument2D iDocument2D = (ksDocument2D)iDefinitionSketch.BeginEdit();

            switch (floorCount)
            {
                case 1:
                    iDocument2D.ksCircle((hiveParams.HiveLength / 2) + 10, hiveParams.HiveHeight / 2, radius, 1);
                    break;
                case 2:
                    iDocument2D.ksCircle((hiveParams.HiveLength / 2) + 10, (hiveParams.HiveHeight / 4), radius, 1);
                    iDocument2D.ksCircle((hiveParams.HiveLength / 2) + 10, (hiveParams.HiveHeight / 4) * 3, radius, 1);
                    break;
                case 3:
                    iDocument2D.ksCircle((hiveParams.HiveLength / 2) + 10, (hiveParams.HiveHeight / 6), radius, 1);
                    iDocument2D.ksCircle((hiveParams.HiveLength / 2) + 10, (hiveParams.HiveHeight / 6) * 3, radius, 1);
                    iDocument2D.ksCircle((hiveParams.HiveLength / 2) + 10, (hiveParams.HiveHeight / 6) * 5, radius, 1);
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

            iDefinitionSketch.EndEdit();

            ksEntity entityCutExtr =
                (ksEntity)iPart.NewEntity((short)Obj3dType.o3d_cutExtrusion);
            ksCutExtrusionDefinition cutExtrDef =
                (ksCutExtrusionDefinition)entityCutExtr.GetDefinition();

            cutExtrDef.SetSketch(iSketch);

            cutExtrDef.directionType = (short)Direction_Type.dtReverse; 
            cutExtrDef.SetSideParam(true, (short)End_Type.etBlind, 50, 20, false);
            cutExtrDef.SetThinParam(false, 0, 0, 0);

            entityCutExtr.Create(); 
        }

        /// <summary>
        /// Выполняет построение отверстий с правой стороны
        /// </summary>
        private void CreateRightHoles(ksPart iPart, KompasObject kompas, HiveParams hiveParams)
        {
            int floorCount = (int)(hiveParams.HiveHeight / 300);

            double offset = -10;

            double radius = hiveParams.InletDiameters;

            ksEntity iSketch;

            ksSketchDefinition iDefinitionSketch;

            OffsetCreateSketch(out iSketch, out iDefinitionSketch, offset);

            ksDocument2D iDocument2D = (ksDocument2D)iDefinitionSketch.BeginEdit();

            switch (floorCount)
            {
                case 1:
                    iDocument2D.ksCircle((hiveParams.HiveHeight / 2) , ((hiveParams.HiveWidth / 2)) *(-1), radius, 1);
                    break;
                case 2:
                    iDocument2D.ksCircle((hiveParams.HiveHeight / 4), ((hiveParams.HiveWidth / 2)) * (-1), radius, 1);
                    iDocument2D.ksCircle(((hiveParams.HiveHeight / 4)) * 3, (((hiveParams.HiveWidth / 2)) * (-1) ), radius, 1);
                    break;
                case 3:
                    iDocument2D.ksCircle((hiveParams.HiveHeight / 6), ((hiveParams.HiveWidth / 2)) * (-1), radius, 1);
                    iDocument2D.ksCircle(((hiveParams.HiveHeight / 6)) * 3, (((hiveParams.HiveWidth / 2)) * (-1)), radius, 1);
                    iDocument2D.ksCircle(((hiveParams.HiveHeight / 6)) * 5, (((hiveParams.HiveWidth / 2)) * (-1)), radius, 1);
                    break;
                case 4:
                    iDocument2D.ksCircle(((hiveParams.HiveHeight / 8)) * 1, (((hiveParams.HiveWidth / 2)) * (-1)), radius, 1);
                    iDocument2D.ksCircle(((hiveParams.HiveHeight / 8)) * 3, (((hiveParams.HiveWidth / 2)) * (-1)), radius, 1);
                    iDocument2D.ksCircle(((hiveParams.HiveHeight / 8)) * 5, (((hiveParams.HiveWidth / 2)) * (-1)), radius, 1);
                    iDocument2D.ksCircle(((hiveParams.HiveHeight / 8)) * 7, (((hiveParams.HiveWidth / 2)) * (-1)), radius, 1);
                    break;
                case 5:
                    iDocument2D.ksCircle(((hiveParams.HiveHeight / 10)) * 1, (((hiveParams.HiveWidth / 2)) * (-1)), radius, 1);
                    iDocument2D.ksCircle(((hiveParams.HiveHeight / 10)) * 3, (((hiveParams.HiveWidth / 2)) * (-1)), radius, 1);
                    iDocument2D.ksCircle(((hiveParams.HiveHeight / 10)) * 5, (((hiveParams.HiveWidth / 2)) * (-1)), radius, 1);
                    iDocument2D.ksCircle(((hiveParams.HiveHeight / 10)) * 7, (((hiveParams.HiveWidth / 2)) * (-1)), radius, 1);
                    iDocument2D.ksCircle(((hiveParams.HiveHeight / 10)) * 9, (((hiveParams.HiveWidth / 2)) * (-1)), radius, 1);
                    break;
                case 6:
                    iDocument2D.ksCircle(((hiveParams.HiveHeight / 12)) * 1, (((hiveParams.HiveWidth / 2)) * (-1)), radius, 1);
                    iDocument2D.ksCircle(((hiveParams.HiveHeight / 12)) * 3, (((hiveParams.HiveWidth / 2)) * (-1)), radius, 1);
                    iDocument2D.ksCircle(((hiveParams.HiveHeight / 12)) * 5, (((hiveParams.HiveWidth / 2)) * (-1)), radius, 1);
                    iDocument2D.ksCircle(((hiveParams.HiveHeight / 12)) * 7, (((hiveParams.HiveWidth / 2)) * (-1)), radius, 1);
                    iDocument2D.ksCircle(((hiveParams.HiveHeight / 12)) * 9, (((hiveParams.HiveWidth / 2)) * (-1)), radius, 1);
                    iDocument2D.ksCircle(((hiveParams.HiveHeight / 12)) * 11, (((hiveParams.HiveWidth / 2)) * (-1)), radius, 1);
                    break;
                default:
                    iDocument2D.ksCircle((hiveParams.HiveHeight / 2), ((hiveParams.HiveWidth / 2)) * (-1), radius, 1);
                    break;
            }

            iDefinitionSketch.EndEdit();

            ksEntity entityCutExtr =
                (ksEntity)iPart.NewEntity((short)Obj3dType.o3d_cutExtrusion);
            ksCutExtrusionDefinition cutExtrDef =
                (ksCutExtrusionDefinition)entityCutExtr.GetDefinition();

            cutExtrDef.SetSketch(iSketch);

            cutExtrDef.directionType = (short)Direction_Type.dtNormal; 
            cutExtrDef.SetSideParam(true, (short)End_Type.etBlind, 50, 20, false);
            cutExtrDef.SetThinParam(false, 0, 0, 0);

            entityCutExtr.Create();
        }

        /// <summary>
        /// Выполняет построение отверстий с левой стороны
        /// </summary>
        private void CreateLeftHoles(ksPart iPart, KompasObject kompas, HiveParams hiveParams)
        {
            int floorCount = (int)(hiveParams.HiveHeight / 300);

            double offset = ((hiveParams.HiveLength +10)) * -1;

            double radius = hiveParams.InletDiameters;

            ksEntity iSketch;

            ksSketchDefinition iDefinitionSketch;

            OffsetCreateSketch(out iSketch, out iDefinitionSketch, offset);

            ksDocument2D iDocument2D = (ksDocument2D)iDefinitionSketch.BeginEdit();

            switch (floorCount)
            {
                case 1:
                    iDocument2D.ksCircle((hiveParams.HiveHeight / 2), ((hiveParams.HiveWidth / 2) * -1), radius, 1);
                    break;
                case 2:
                    iDocument2D.ksCircle((hiveParams.HiveHeight / 4), ((hiveParams.HiveWidth / 2)) * (-1), radius, 1);
                    iDocument2D.ksCircle(((hiveParams.HiveHeight / 4)) * 3, (((hiveParams.HiveWidth / 2)) * (-1)), radius, 1);
                    break;
                case 3:
                    iDocument2D.ksCircle((hiveParams.HiveHeight / 6), ((hiveParams.HiveWidth / 2)) * (-1), radius, 1);
                    iDocument2D.ksCircle(((hiveParams.HiveHeight / 6)) * 3, (((hiveParams.HiveWidth / 2)) * (-1)), radius, 1);
                    iDocument2D.ksCircle(((hiveParams.HiveHeight / 6)) * 5, (((hiveParams.HiveWidth / 2)) * (-1)), radius, 1);
                    break;
                case 4:
                    iDocument2D.ksCircle(((hiveParams.HiveHeight / 8)) * 1, (((hiveParams.HiveWidth / 2)) * (-1)), radius, 1);
                    iDocument2D.ksCircle(((hiveParams.HiveHeight / 8)) * 3, (((hiveParams.HiveWidth / 2)) * (-1)), radius, 1);
                    iDocument2D.ksCircle(((hiveParams.HiveHeight / 8)) * 5, (((hiveParams.HiveWidth / 2)) * (-1)), radius, 1);
                    iDocument2D.ksCircle(((hiveParams.HiveHeight / 8)) * 7, (((hiveParams.HiveWidth / 2)) * (-1)), radius, 1);
                    break;
                case 5:
                    iDocument2D.ksCircle(((hiveParams.HiveHeight / 10)) * 1, (((hiveParams.HiveWidth / 2)) * (-1)), radius, 1);
                    iDocument2D.ksCircle(((hiveParams.HiveHeight / 10)) * 3, (((hiveParams.HiveWidth / 2)) * (-1)), radius, 1);
                    iDocument2D.ksCircle(((hiveParams.HiveHeight / 10)) * 5, (((hiveParams.HiveWidth / 2)) * (-1)), radius, 1);
                    iDocument2D.ksCircle(((hiveParams.HiveHeight / 10)) * 7, (((hiveParams.HiveWidth / 2)) * (-1)), radius, 1);
                    iDocument2D.ksCircle(((hiveParams.HiveHeight / 10)) * 9, (((hiveParams.HiveWidth / 2)) * (-1)), radius, 1);
                    break;
                case 6:
                    iDocument2D.ksCircle(((hiveParams.HiveHeight / 12)) * 1, (((hiveParams.HiveWidth / 2)) * (-1)), radius, 1);
                    iDocument2D.ksCircle(((hiveParams.HiveHeight / 12)) * 3, (((hiveParams.HiveWidth / 2)) * (-1)), radius, 1);
                    iDocument2D.ksCircle(((hiveParams.HiveHeight / 12)) * 5, (((hiveParams.HiveWidth / 2)) * (-1)), radius, 1);
                    iDocument2D.ksCircle(((hiveParams.HiveHeight / 12)) * 7, (((hiveParams.HiveWidth / 2)) * (-1)), radius, 1);
                    iDocument2D.ksCircle(((hiveParams.HiveHeight / 12)) * 9, (((hiveParams.HiveWidth / 2)) * (-1)), radius, 1);
                    iDocument2D.ksCircle(((hiveParams.HiveHeight / 12)) * 11, (((hiveParams.HiveWidth / 2)) * (-1)), radius, 1);
                    break;
                default:
                    iDocument2D.ksCircle((hiveParams.HiveHeight / 2), ((hiveParams.HiveWidth / 2) * -1), radius, 1);
                    break;
            }

            iDefinitionSketch.EndEdit();

            ksEntity entityCutExtr =
                (ksEntity)iPart.NewEntity((short)Obj3dType.o3d_cutExtrusion);
            ksCutExtrusionDefinition cutExtrDef =
                (ksCutExtrusionDefinition)entityCutExtr.GetDefinition();

            cutExtrDef.SetSketch(iSketch);

            //cutExtrDef.directionType = (short)Direction_Type.dtNormal; 
            cutExtrDef.directionType = (short)Direction_Type.dtReverse;
            cutExtrDef.SetSideParam(true, (short)End_Type.etBlind, 50, 20, false);
            cutExtrDef.SetThinParam(false, 0, 0, 0);

            entityCutExtr.Create(); 
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

            iSketch = (ksEntity)iPart.NewEntity((short)Obj3dType.o3d_sketch);

            iDefinitionSketch = iSketch.GetDefinition();

            iDefinitionSketch.SetPlane(iPlane);

            iSketch.Create();
        }

        /// <summary>
        /// Создание скетча с координатной сеткой YOZ
        /// </summary>
        /// <param name="iSketch">Эскиз</param>
        /// <param name="iDefinitionSketch">Определение эскиза</param>
        /// <param name="offset">Смещение от начальной плоскости</param>
        private void OffsetCreateSketch(out ksEntity iSketch, out ksSketchDefinition iDefinitionSketch, double offset = 0)
        {
            #region Создание смещенную плоскость -------------------------
           
            ksEntity iPlane = (ksEntity)iPart.NewEntity((short)Obj3dType.o3d_planeOffset);

            ksPlaneOffsetDefinition iPlaneDefinition = (ksPlaneOffsetDefinition)iPlane.GetDefinition();

            iPlaneDefinition.SetPlane(iPart.GetDefaultEntity((short)Obj3dType.o3d_planeYOZ));
            iPlaneDefinition.direction = true;
            iPlaneDefinition.offset = offset;
            iPlane.Create();
            #endregion --------------------------------------------------

            iSketch = (ksEntity)iPart.NewEntity((short)Obj3dType.o3d_sketch);

            iDefinitionSketch = iSketch.GetDefinition();

            iDefinitionSketch.SetPlane(iPlane);

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
            ksEntity entityExtr = (ksEntity)iPart.NewEntity((short)Obj3dType.o3d_bossExtrusion);

            ksBossExtrusionDefinition extrusionDef = (ksBossExtrusionDefinition)entityExtr.GetDefinition();

            ksExtrusionParam extrProp = (ksExtrusionParam)extrusionDef.ExtrusionParam();

            extrusionDef.SetSketch(iSketch);

            if (direction == false)
            {
                extrProp.direction = (short)Direction_Type.dtReverse;
            }
            else
            {
                extrProp.direction = (short)Direction_Type.dtNormal;
            }

            extrProp.typeNormal = (short)End_Type.etBlind;

            if (direction == false)
            {
                extrProp.depthReverse = depth;
            }
            else
            {
                extrProp.depthNormal = depth;
            }

            entityExtr.Create();
        }
    }
}
