using Mes.Service.Abstract;
using System.Collections.Generic;

namespace Mes.Models.WebUi
{
    public class BaseResponse
    {
        public BaseResponse()
        {
            data = new List<BaseResponseObject>();
        }
        public bool success { get; set; }
        public Error error { get; set; }
        public virtual ICollection<BaseResponseObject> data { get; set; }
        public IObjectState Obj { get; set; }
        public int? newObjId { get; set; }
    }
}