using Sniper.Core.Domain.Directory;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sniper.Services.Directory
{
    /// <summary>
    /// 测量维度服务接口
    /// </summary>
    public partial interface IMeasureService
    {
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="measureDimension"></param>
        void DeleteMeasureDimension(MeasureDimension measureDimension);

        /// <summary>
        /// 获取测量维度
        /// </summary>
        /// <param name="measureDimensionId"></param>
        /// <returns></returns>
        MeasureDimension GetMeasureDimensionById(int measureDimensionId);

        /// <summary>
        /// 获取
        /// </summary>
        /// <param name="systemKeyword"></param>
        /// <returns></returns>
        MeasureDimension GetMeasureDimensionBySystemKeyword(string systemKeyword);

        /// <summary>
        /// 获取所有
        /// </summary>
        /// <returns></returns>
        IList<MeasureDimension> GetAllMeasureDimensions();

        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="measure"></param>
        void InsertMeasureDimension(MeasureDimension measure);

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="measure"></param>
        void UpdateMeasureDimension(MeasureDimension measure);

        /// <summary>
        /// 转换
        /// </summary>
        /// <param name="value"></param>
        /// <param name="sourceMeasureDimension"></param>
        /// <param name="targetMeasureDimension"></param>
        /// <param name="round"></param>
        /// <returns></returns>
        decimal ConvertDimension(decimal value,MeasureDimension sourceMeasureDimension, MeasureDimension targetMeasureDimension, bool round = true);

        /// <summary>
        /// 转换
        /// </summary>
        /// <param name="value"></param>
        /// <param name="sourceMeasureDimension"></param>
        /// <returns></returns>
        decimal ConvertToPrimaryMeasureDimension(decimal value,MeasureDimension sourceMeasureDimension);

        /// <summary>
        /// 转换
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetMeasureDimension"></param>
        /// <returns></returns>
        decimal ConvertFromPrimaryMeasureDimension(decimal value,MeasureDimension targetMeasureDimension);

        /// <summary>
        /// 删除测量重量
        /// </summary>
        /// <param name="measureWeight"></param>
        void DeleteMeasureWeight(MeasureWeight measureWeight);

        /// <summary>
        /// 获取
        /// </summary>
        /// <param name="measureWeightId"></param>
        /// <returns></returns>
        MeasureWeight GetMeasureWeightById(int measureWeightId);

        /// <summary>
        /// 获取
        /// </summary>
        /// <param name="systemKeyword"></param>
        /// <returns></returns>
        MeasureWeight GetMeasureWeightBySystemKeyword(string systemKeyword);

        /// <summary>
        /// 获取所有
        /// </summary>
        /// <returns></returns>
        IList<MeasureWeight> GetAllMeasureWeights();

        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="measure"></param>
        void InsertMeasureWeight(MeasureWeight measure);

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="measure"></param>
        void UpdateMeasureWeight(MeasureWeight measure);

        /// <summary>
        /// Converts weight
        /// </summary>
        /// <param name="value">Value to convert</param>
        /// <param name="sourceMeasureWeight">Source weight</param>
        /// <param name="targetMeasureWeight">Target weight</param>
        /// <param name="round">A value indicating whether a result should be rounded</param>
        /// <returns>Converted value</returns>
        decimal ConvertWeight(decimal value,
            MeasureWeight sourceMeasureWeight, MeasureWeight targetMeasureWeight, bool round = true);

        /// <summary>
        /// Converts to primary measure weight
        /// </summary>
        /// <param name="value">Value to convert</param>
        /// <param name="sourceMeasureWeight">Source weight</param>
        /// <returns>Converted value</returns>
        decimal ConvertToPrimaryMeasureWeight(decimal value, MeasureWeight sourceMeasureWeight);

        /// <summary>
        /// Converts from primary weight
        /// </summary>
        /// <param name="value">Value to convert</param>
        /// <param name="targetMeasureWeight">Target weight</param>
        /// <returns>Converted value</returns>
        decimal ConvertFromPrimaryMeasureWeight(decimal value,
            MeasureWeight targetMeasureWeight);
    }
}
