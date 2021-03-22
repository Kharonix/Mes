using System.ComponentModel.DataAnnotations.Schema;

namespace Mes.Service.Abstract
{
    public interface IObjectState
    {
        [NotMapped]
        ObjectState ObjectState { get; set; }
    }
}