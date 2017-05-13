using System;
using System.Collections;

/**
* Response codes:
*  - 200: Connection successfull and return expected data
*  - 404: Connection successfull and return fail data
*  
*  - 400: Connection unsuccessfull
*/
public class ExceptionGame : IEnumerator {

    public enum ResponseCode {
        CODE_000, CODE_100, CODE_200, CODE_400, CODE_404
    }

    public ResponseCode code;
    public string message;

    public object Current {
        get {
            return message;
        }
    }

    public ExceptionGame(ResponseCode code, string message) {
        this.code = code;
        this.message = message;
    }

    public bool MoveNext() {
        return true;
    }

    public void Reset() {
        message = null;
        code = ResponseCode.CODE_000;
    }

    public static ExceptionGame.ResponseCode Parse(int code) {
        ExceptionGame.ResponseCode result = ExceptionGame.ResponseCode.CODE_000;
        switch (code) {
            case 200:
                result = ExceptionGame.ResponseCode.CODE_200;
                break;
            case 400:
                result = ExceptionGame.ResponseCode.CODE_400;
                break;
            case 404:
                result = ExceptionGame.ResponseCode.CODE_404;
                break;
        }
        return result;
    }
}
