using System.ComponentModel;

namespace RoomBook.BusinessLogic.Enums;

public enum EErrorMessages
{
    [Description("InternalServerError: algum erro ocorreu.")]
    INTERNAL_SERVER_ERROR = 1,

    [Description("BadRequest: requisição inválida.")]
    BAD_REQUEST = 2,

    [Description("BadRequest: email é inválido.")]
    BAD_REQUEST_INVALID_EMAIL = 3,

    [Description("BadRequest: quarto não está disponível.")]
    BAD_REQUEST_OCCUPIED_ROOM = 4,

    [Description("BadRequest: pagamento não realizado.")]
    BAD_REQUEST_UNSUCCESSFULL_PAYMENT = 5,

    [Description("BadRequest: quarto não existe.")]
    BAD_REQUEST_ROOM_DOESNOTEXIST = 6
}
