﻿using AutoMapper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    public static class AutoMapperHelper
    {
        /// <summary>
        ///  类型映射
        /// </summary>
        public static T MapTo<T>(this object obj)
        {
            if (obj == null)
            {
                return default(T);
            }
            //初始化转换类型
            Mapper.Initialize(o => o.CreateMap(obj.GetType(), typeof(T)));
            return Mapper.Map<T>(obj);
        }
        /// <summary>
        /// 集合列表类型映射
        /// </summary>
        public static List<TDestination> MapToList<TDestination>(this IEnumerable source)
        {
            foreach (var item in source)
            {
                var type = item.GetType();
                Mapper.Initialize(o => o.CreateMap(type, typeof(TDestination)));
                break;
            }
            return Mapper.Map<List<TDestination>>(source);
        }

        ///// <summary>
        ///// 集合列表类型映射
        ///// </summary>
        //public static List<TDestination> MapToList<TSource, TDestination>(this IEnumerable<TSource> source)
        //{
        //    //IEnumerable<T> 类型需要创建元素的映射
        //    Mapper.CreateMap<TSource, TDestination>();
        //    return Mapper.Map<List<TDestination>>(source);
        //}
        ///// <summary>
        ///// 类型映射
        ///// </summary>
        //public static TDestination MapTo<TSource, TDestination>(this TSource source, TDestination destination)
        //    where TSource : class
        //    where TDestination : class
        //{
        //    if (source == null) return destination;
        //    Mapper.CreateMap<TSource, TDestination>();
        //    return Mapper.Map(source, destination);
        //}
        ///// <summary>
        ///// DataReader映射
        ///// </summary>
        //public static IEnumerable<T> DataReaderMapTo<T>(this IDataReader reader)
        //{
        //    Mapper.Reset();
        //    Mapper.CreateMap<IDataReader, IEnumerable<T>>();
        //    return Mapper.Map<IDataReader, IEnumerable<T>>(reader);
        //}
    }
}
