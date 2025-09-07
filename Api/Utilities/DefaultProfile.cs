using AutoMapper;
using AutoMapper.Internal;
using Mapster;

namespace Acc.Api.Utilities
{
    public class DefaultProfile : Profile
    {
        public DefaultProfile()
        {
          //  CreateMap<long?, long>().ConvertUsing<NullableLongToLongConverter>(); //Long? to long from proto to entity id
                

        }
    }
    public interface IDefaultProfile : IRegister
    {

    }
}
