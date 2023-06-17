

namespace School.Application.Core
{
    public interface IBaseService<TModelAdd, TModelMod, TModelRem>
    {
        ServiceResult Get();
        ServiceResult GetById(int id);
        ServiceResult Save(TModelAdd model);
        ServiceResult Update(TModelMod model);
       ServiceResult Remove(TModelRem model);
    }
}
