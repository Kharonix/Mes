using Mes.Models.Enum;

namespace Mes.Models.WebUi
{
    //500 Internal server error — всё сломалось, но мы скоро починим
    //400 Bad request — а теперь у вас всё сломалось
    //403 Forbidden — вам сюда нельзя
    //404 Not found — по этому адресу никто не живёт
    //405 Method not allowed — нельзя такое делать
    //422 Unprocessable entity — исправьте и пришлите снова

    public class Error
    {
        public string Message { get; set; }
        public int Code { get; set; }
        public HttpCode HttpCode { get; set; }
    }
}