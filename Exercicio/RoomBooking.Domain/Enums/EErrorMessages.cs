using System.ComponentModel;

namespace RoomBooking.Domain.Enums;

public enum EErrorMessages
{
    [Description("InternalServerError: algum erro ocorreu.")]
    INTERNAL_SERVER_ERROR = 1,

    [Description("BadRequest: requisição inválida.")]
    BAD_REQUEST = 2
}
