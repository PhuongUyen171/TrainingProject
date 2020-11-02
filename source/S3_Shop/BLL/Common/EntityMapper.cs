using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BLL.Common
{
    public class EntityMapper<TSource, TDestination> where TSource : class where TDestination : class
    {
        public EntityMapper()
        {
            Mapper.CreateMap<Model.CategoryModel,DAL.EF.CATEGORY>();
            Mapper.CreateMap<DAL.EF.CATEGORY, Model.CategoryModel>();
            Mapper.CreateMap<Model.NewsModel, DAL.EF.NEWS>();
            Mapper.CreateMap<DAL.EF.NEWS, Model.NewsModel>();
        }
        public TDestination Translate(TSource obj)
        {
            return Mapper.Map<TDestination>(obj);
        }
    }
}